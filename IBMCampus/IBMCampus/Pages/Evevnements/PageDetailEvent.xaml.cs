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
            LEvenement.Participants = await repo.RecupererUtilisateursDunEvenement(LEvenement.IdEvent);
            if (repo.MessageErreur != null)
            {
                await DisplayAlert("Participants", repo.MessageErreur, "OK");

            }

            listeUtilisateurEvenement.ItemsSource = LEvenement.Participants;

            if (!evenement.Participants.Any())
            {
                BoutonInscription.IsVisible = true;
                BoutonDesinscription.IsVisible = false;
            }
            else
            {

                foreach (var user in evenement.Participants)
                {


                    if (user.IdUtilisateur == utilisateur.IdUtilisateur)
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
            if (evenement.NombreParticipants == evenement.NombreMaximumParticipant)
            {
                BoutonInscription.IsVisible = false;
            }
        }

        private void Refresh()
        {
            //var eventAffiche = BindingContext as EvenementsModel;
            //var AppData = App.Current.BindingContext as FakeRepository;
            //InitializeComponent();
            //Load(eventAffiche, AppData);
        }

        private async void listeUtilisateurEvenement_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listeUtilisateurEvenement.SelectedItem == null)
            {
                return;
            }
            var userSelected = e.SelectedItem as UtilisateurModel;
            await Navigation.PushAsync(new TabbedPageUtilisateurAutre(userSelected));
            listeUtilisateurEvenement.SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var evenement = BindingContext as EvenementsModel;
            await Load(evenement, repo.User);
        }

        private void BoutonInscription_Clicked(object sender, EventArgs e)
        {

        }

        private void BoutonDesinscription_Clicked(object sender, EventArgs e)
        {

        }
    }
}