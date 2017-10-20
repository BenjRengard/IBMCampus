﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageGroupesDeLUtilisateur : ContentPage
    {
        public PageGroupesDeLUtilisateur()
        {
            InitializeComponent();
            Load();
        }

        public PageGroupesDeLUtilisateur(UtilisateurModel utilisateur)
        {
            InitializeComponent();
            Load(utilisateur);
        }

        //public PageGroupesDeLUtilisateur(UtilisateurModel user)
        //{
        //    InitializeComponent();
        //    var repo = App.Current.BindingContext as UtilisateurModel;

        //    //liste.ItemsSource = repo.RecupererGroupesUtilisateur(user);
        //    //liste.ItemsSource = new FakeRepository().RecupererGroupesUtilisateur(user);
        //}

        private void Load()
        {
            var user = App.Current.BindingContext as UtilisateurModel;
            //liste.ItemsSource = repo.RecupererGroupesUtilisateur(user);
            //liste.ItemsSource = new FakeRepository().RecupererGroupesUtilisateur(user);
        }

        private void Load(UtilisateurModel utilisateur)
        {
            var user = utilisateur as UtilisateurModel;
            liste.ItemsSource = null;
            //liste.ItemsSource = utilisateur.RecupererGroupesUtilisateur(user);
        }

        private async void liste_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (liste.SelectedItem == null)
            {
                return;
            }
            var groupe = e.SelectedItem as GroupeModel;
            await Navigation.PushAsync(new TabbedPageDetailCompletGroupe(groupe));
            liste.SelectedItem = null;
        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FormCreationGroupe());
        }

        private void liste_Refreshing(object sender, EventArgs e)
        {
            Load();
            liste.EndRefresh();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Load();
        }

        
    }
}