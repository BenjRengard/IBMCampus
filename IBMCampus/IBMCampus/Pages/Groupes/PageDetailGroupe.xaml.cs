﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IBMCampus
{
    public partial class PageDetailGroupe : ContentPage
    {
        public PageDetailGroupe(GroupeModel groupe)
        {
            var AppData = App.Current.BindingContext as FakeRepository;
            var groupeAAfficher = groupe ?? throw new ArgumentNullException("groupe");
            InitializeComponent();
            Load(groupeAAfficher, AppData);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var groupeAffiche = BindingContext as GroupeModel;
            var AppData = App.Current.BindingContext as FakeRepository;
            

            
            AppData.User.GroupesUtilisateur.Add(groupeAffiche.IdGroupe);
            groupeAffiche.UtilisateursDuGroupe.Add(AppData.User);

            Load(groupeAffiche, AppData);


            await DisplayAlert("S'inscrire", string.Format("Vous avez été ajouté au groupe {0}", groupeAffiche.NomGroupe), "Retour");

            Refresh();

        }

        public void Load(GroupeModel groupe, FakeRepository appData)
        {

            BindingContext = groupe;
            listeUtilisateurGroupe.ItemsSource = groupe.UtilisateursDuGroupe;
            if (!groupe.UtilisateursDuGroupe.Any())
            {
                BoutonInscription.IsVisible = true;
                BoutonDesinscription.IsVisible = false;
            }
            else
            {

                foreach (var user in groupe.UtilisateursDuGroupe)
                {


                    if (user == appData.User)
                    {
                        BoutonInscription.IsVisible = false;
                        BoutonDesinscription.IsVisible = true;
                        break;
                    }
                    else
                    {
                        BoutonInscription.IsVisible = true;
                        BoutonDesinscription.IsVisible = false;
                    }
                }
            }
            if (groupe.ParticipantsActuels == groupe.ParticipantsMax)
            {
                BoutonInscription.IsVisible = false;
            }
        }

        private async void BoutonDesinscription_Clicked(object sender, EventArgs e)
        {
            var groupeAffiche = BindingContext as GroupeModel;
            var AppData = App.Current.BindingContext as FakeRepository;
            groupeAffiche.UtilisateursDuGroupe.Remove(AppData.User);
            AppData.User.GroupesUtilisateur.Remove(groupeAffiche.IdGroupe);

            Load(groupeAffiche, AppData);


            await DisplayAlert("Désinscription", string.Format("Vous avez été désinscris du groupe {0}", groupeAffiche.NomGroupe), "Retour");
            Refresh();

        }

        private async void listeUtilisateurGroupe_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listeUtilisateurGroupe.SelectedItem == null)
            {
                return;
            }
            var userSelected = e.SelectedItem as UtilisateurModel;
            await Navigation.PushAsync(new TabbedPageUtilisateurAutre(userSelected));
            listeUtilisateurGroupe.SelectedItem = null;
        }

        private void Refresh()
        {
            var groupeAffiche = BindingContext as GroupeModel;
            var AppData = App.Current.BindingContext as FakeRepository;
            InitializeComponent();
            Load(groupeAffiche, AppData);
        }

        
    }
}