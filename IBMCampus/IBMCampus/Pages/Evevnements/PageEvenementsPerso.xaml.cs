
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
        Repository repo = App.Current.BindingContext as Repository;

        UtilisateurModel _utilisateur = new UtilisateurModel();

		public PageEvenementsPerso ()
		{
			InitializeComponent ();
            _utilisateur = repo.User;
            //Load();
		}

        public PageEvenementsPerso(UtilisateurModel user)
        {
            InitializeComponent();
            _utilisateur = user;
        }

        private async void liste_Refreshing(object sender, EventArgs e)
        {
            await Load();
            liste.EndRefresh();
        }

        public async Task Load()
        {
            liste.ItemsSource = null;
            var Evenements = await repo.RecupererEvenementsUtilisateur(_utilisateur.IdUtilisateur);
            if (Evenements == null || Evenements.Count <=0)
            {
                await DisplayAlert("Evènements", "Aucun évènement trouvé", "OK");
            }
            liste.ItemsSource = Evenements;
            

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


        private async void ToolbarItem_Activated_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageFormCreationEvent());
        }
        protected override async  void OnAppearing()
        {
            base.OnAppearing();
            await Load();
        }
    }
}