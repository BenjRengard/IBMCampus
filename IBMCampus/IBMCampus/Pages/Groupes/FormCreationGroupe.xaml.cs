﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormCreationGroupe : ContentPage
    {
        Repository repo = App.Current.BindingContext as Repository;

        ObservableCollection<SportModel> _Sports = new ObservableCollection<SportModel>();

        SportModel _sportSelection = null;

        public FormCreationGroupe()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            int nbParticip;

            var result = int.TryParse(NombreParticipantsMax.Text, out nbParticip);

            if (!result || nbParticip <= 0)
            {
                await DisplayAlert("Nombre de participants", "Le nombre de participant entré est incorrect", "OK");
            }
            else
            {
                if (_sportSelection == null)
                {
                    await DisplayAlert("Sport du groupe", "Vous devez choisir un sport dans la liste pour finaliser la création", "OK");

                }
                else
                {

                    GroupeModel nouveauGroupe = new GroupeModel()
                    {
                        NomGroupe = NomNouveauGroupe.Text,
                        SportGroupe = _sportSelection,
                        UtilisateurGroupe = new ObservableCollection<UtilisateurModel>() { repo.User },
                        ParticipantsMax = nbParticip,
                        CodePostalGroupe = CodePostal.Text,
                        NomVoieGroupe = NomVoie.Text,
                        NumeroRueGroupe = NumeroVoie.Text,
                        TypeVoieGroupe = TypeVoie.Text,
                        VilleGroupe = Ville.Text

                    };
                  
                    var newGroupe = await repo.CreerNouveauGroupe(nouveauGroupe);
                    if (repo.MessageErreur != null || newGroupe == null)
                    {
                        await DisplayAlert("Problème!", repo.MessageErreur, "OK");
                    }
                    else
                    {

                        await repo.InscriptionGroupe(repo.User.IdUtilisateur, newGroupe.IdGroupe);
                        if (repo.MessageErreur != null)
                        {
                            await DisplayAlert("Problème!", repo.MessageErreur, "OK");
                        }
                        else
                        {
                        await Navigation.PopAsync();
                        }

                    }

                }
            }

        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sportName = DropDownSport.Items[DropDownSport.SelectedIndex];

            _sportSelection = new SportModel();
            _sportSelection = _Sports.Single(sp => sp.NomSport == sportName);
        }

        protected override async void OnAppearing()
        {
            _Sports = await repo.RecupererAllSports();
            foreach (var sport in _Sports)
            {
                DropDownSport.Items.Add(sport.NomSport);
            }
            base.OnAppearing();
        }
    }
}