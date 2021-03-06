﻿
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageTousLesEvents : ContentPage
    {
        #region Fields de la page

        Repository repo = App.Current.BindingContext as Repository;
        EvenementsModel events = new EvenementsModel();
        #endregion

        #region Constructeurs

        public PageTousLesEvents()
        {
            InitializeComponent();
            //Load();

        }

        ///// <summary>
        ///// Constrcuteur obsolète
        ///// </summary>
        ///// <param name="repo"></param>
        //public PageTousLesEvents(FakeRepository repo)
        //{
        //    InitializeComponent();

        //    liste.ItemsSource = repo.RecupererTousLesEvents();
        //}
        #endregion

        #region Méthodes d'action

        private async void liste_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (liste.SelectedItem == null)
            {
                return;
            }
            var Event = e.SelectedItem as EvenementsModel;
            await Navigation.PushAsync(new PageDetailEvent(Event));
            liste.SelectedItem = null;
        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageFormCreationEvent());
        }

        private async void liste_Refreshing(object sender, EventArgs e)
        {
            await Load();
            liste.EndRefresh();
        }
        #endregion

        #region Méthodes de chargement

        public async Task Load()
        {

            liste.ItemsSource = null;
            var listeAffiche = new ObservableCollection<EvenementsModel>();

            var groupesUser = await repo.RecupererGroupesUser(repo.User.IdUtilisateur.ToString());
            if (groupesUser == null || groupesUser.Count <= 0)
            {
                await DisplayAlert("Evènements", "Aucun évènement à afficher", "OK");
            }
            else
            {

                foreach (var groupe in groupesUser)
                {
                    var eventsDuGroupe = await repo.RecupererEvenementsGroupe(groupe.IdGroupe.ToString());
                    if (eventsDuGroupe != null && eventsDuGroupe.Count > 0)
                    {
                        foreach (var evenement in eventsDuGroupe)
                        {
                            listeAffiche.Add(evenement);
                        }
                    }
              
                }
                liste.ItemsSource = listeAffiche;
            }
        }

        protected override async void OnAppearing()
        {
            //await DisplayAlert("ATTENTION", "Le chargement de cette page peut prendre un certain temps. Veuillez patienter.", "Je suis prêt à patienter", "Je ne veux pas patienter");
            liste.IsRefreshing = true;
            await Load();
            

            base.OnAppearing();
            liste.IsRefreshing = false;
        }
        #endregion
    }
}