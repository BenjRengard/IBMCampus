﻿using IBMCampus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    public partial class DetailChauffeur : ContentPage
    {
        public DetailChauffeur()
        {
            InitializeComponent();
        }

        public DetailChauffeur(ChauffeurModel chauffeur)
        {
            var AppData = App.Current.BindingContext as FakeGroupes;
            var chauffeurAAfficher = chauffeur ?? throw new ArgumentNullException("groupe");
            InitializeComponent();
            Load(chauffeurAAfficher, AppData);

        }

        private async void liste_Refreshing(object sender, EventArgs e)
        {
            var chauffeur = BindingContext as ChauffeurModel;
            await Navigation.PushAsync(new DetailChauffeur(chauffeur));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var chauffeur = BindingContext as ChauffeurModel;
            chauffeur.NombrePlace--;
            var AppData = App.Current.BindingContext as FakeGroupes;



            AppData.ListeFauxChauffeur.Remove(chauffeur);
            AppData.ListeFauxChauffeur.Add(chauffeur);
            chauffeur.ListePassager.Add(AppData.User);

            Load(chauffeur, AppData);


            await DisplayAlert("S'inscrire", string.Format("Vous avez été ajouté à la voiture de {0}", chauffeur.NomChauffeur), "Retour");

        }


        private async void BoutonDesinscription_Clicked(object sender, EventArgs e)
        {
            var chauffeur = BindingContext as ChauffeurModel;
            chauffeur.NombrePlace++;
            var AppData = App.Current.BindingContext as FakeGroupes;
            chauffeur.ListePassager.Remove(AppData.User);

            AppData.ListeFauxChauffeur.Remove(chauffeur);
            AppData.ListeFauxChauffeur.Add(chauffeur);

            Load(chauffeur, AppData);


            await DisplayAlert("Désinscription", string.Format("Vous avez été retiré de la voiture de {0}", chauffeur.NomChauffeur), "Retour");

        }


        public void Load(ChauffeurModel chauffeur, FakeGroupes appData)
        {

            BindingContext = chauffeur;
            liste.ItemsSource = chauffeur.ListePassager;
            if (!chauffeur.ListePassager.Any())
            {
                BoutonInscription.IsVisible = true;
                BoutonDesinscription.IsVisible = false;
            }
            else
            {

                foreach (var user in chauffeur.ListePassager)
                {


                    if (user == appData.User)
                    {
                        BoutonInscription.IsVisible = false;
                        BoutonDesinscription.IsVisible = true;
                    }
                    else
                    {
                        BoutonInscription.IsVisible = true;
                        BoutonDesinscription.IsVisible = false;
                    }
                }
            }
            if (chauffeur.NombrePlace == chauffeur.ListePassager.Count)
            {
                BoutonInscription.IsVisible = false;
            }
        }
    }
}