using System;
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

        private bool EnregistrerClique = false;

        public FormCreationGroupe()
        {
            InitializeComponent();
            EnregistrerClique = false;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (EnregistrerClique)
            {
                await DisplayAlert("Enregistrement déjà effectué", @"Vous avez déjà essayer de créer le groupe. Veuillez vérifier si celui-ci n'existe pas déjà dans 'Tous les groupes'", "OK");
                await Navigation.PopAsync();
            }
            else
            {

                EnregistrerClique = true;
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
                                await DisplayAlert("Enregistrement", string.Format("Le groupe {0} a bien été créé. Vous y êtes inscrit.", newGroupe.NomGroupe), "OK");
                                await Navigation.PopAsync();
                                EnregistrerClique = false;
                            }

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
            if (_Sports == null || _Sports.Count <= 0)
            {
                await DisplayAlert("Problème", "Problème lors de la récupération des sports. Veuillez ressayer", "OK");
            }
            foreach (var sport in _Sports)
            {
                DropDownSport.Items.Add(sport.NomSport);
            }
            base.OnAppearing();
        }
    }
}