using System;
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

        private void Load()
        {
            var repo = App.Current.BindingContext as FakeGroupes;
            var user = repo.User as UtilisateurModel;
            liste.ItemsSource = repo.RecupererGroupesUtilisateur(user);
        }

        private async void liste_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (liste.SelectedItem == null)
            {
                return;
            }
            var groupe = e.SelectedItem as GroupeModel;
            await Navigation.PushAsync(new PageDetailGroupe(groupe));
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
    }
}