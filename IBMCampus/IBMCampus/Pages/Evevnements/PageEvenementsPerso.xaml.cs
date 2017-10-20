
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
	public partial class PageEvenementsPerso : ContentPage
	{
		public PageEvenementsPerso ()
		{
			InitializeComponent ();
            Load();
		}

        public PageEvenementsPerso(UtilisateurModel user)
        {
            //var repo = App.Current.BindingContext as Repository;
            //liste.ItemsSource = repo.RecupererEvenementUtilisateur(user);
            //liste.ItemsSource = new FakeRepository().RecupererEvenementUtilisateur(user);
        }

        private void liste_Refreshing(object sender, EventArgs e)
        {
            Load();
            liste.EndRefresh();
        }

        public void Load()
        {
            //var repo = App.Current.BindingContext as Repository;
            liste.ItemsSource = null;
            //liste.ItemsSource = repo.RecupererTousLesEvents();
            //liste.ItemsSource = new FakeRepository().RecupererEvenementUtilisateur(repo.User);

        }

        private async void liste_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (liste.SelectedItem == null)
            {
                return;
            }
            var evenement = e.SelectedItem as EvenementsModel;
            await Navigation.PushAsync(new PageDetailEvent(evenement));
            liste.SelectedItem = null;
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new FormCreationEvent());
        }

        private async void ToolbarItem_Activated_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageFormCreationEvent());
        }
    }
}