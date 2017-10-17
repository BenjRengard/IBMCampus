//using IBMCampus.FakeRepository;
using IBMCampus.Models;
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
    public partial class ListeChauffeursCovoiturage : ContentPage
    {
        public ListeChauffeursCovoiturage()
        {
            InitializeComponent();
            Load();
        }
        
        public void Load()
        {
            var repo = App.Current.BindingContext as FakeRepository;
            liste.ItemsSource = null;
            liste.ItemsSource = repo.RecupererTousChauffeurs();
            
        }

        private void liste_Refreshing(object sender, EventArgs e)
        {
            Load();
            liste.EndRefresh();
        }

        private async void liste_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (liste.SelectedItem == null)
            {
                return;
            }
            var chauffeur = e.SelectedItem as ChauffeurModel;
            await Navigation.PushAsync(new DetailChauffeur(chauffeur));
            liste.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Load();
        }

    }

}