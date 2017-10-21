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
	public partial class PageDetailEvent : ContentPage
	{
        Repository repo = App.Current.BindingContext as Repository;


        public PageDetailEvent(EvenementsModel evenement)
        {
            InitializeComponent();

            BindingContext = evenement;

            //var AppData = App.Current.BindingContext as FakeRepository;
            //var eventAAfficher = evenement ?? throw new ArgumentNullException("evenement");
            //InitializeComponent();
            //Load(eventAAfficher, AppData);
        }

        public async Task Load(EvenementsModel evenement, UtilisateurModel utilisateur)
        {
            var LEvenement = BindingContext as EvenementsModel;

            listeUtilisateurEvenement.ItemsSource = LEvenement.Participants;
        }

        private void Refresh()
        {
            //var eventAffiche = BindingContext as EvenementsModel;
            //var AppData = App.Current.BindingContext as FakeRepository;
            //InitializeComponent();
            //Load(eventAffiche, AppData);
        }

        private void listeUtilisateurEvenement_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var evenement = BindingContext as EvenementsModel;
            await Load(evenement, repo.User);
        }
    }
}