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
            LEvenement.Participants = await repo.RecupererUtilisateursDunEvenement(LEvenement.IdEvenement);
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
            if (evenement.NombreParticipants == evenement.NombreParticipantsMax)
            {
                BoutonInscription.IsVisible = false;
            }
        }

        public async Task Refresh()
        {
            var eventAffiche = BindingContext as EvenementsModel;
            //var AppData = App.Current.BindingContext as FakeRepository;
            InitializeComponent();
            await Load(eventAffiche, repo.User);
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

        private async void BoutonInscription_Clicked(object sender, EventArgs e)
        {
            var eventAAfficher = BindingContext as EvenementsModel;

            await repo.InscriptionEvent(repo.User.IdUtilisateur, eventAAfficher.IdGroupe, eventAAfficher.IdEvenement);

            if (repo.MessageErreur != null)
            {
                await DisplayAlert("Problème!", repo.MessageErreur, "OK");
                await Refresh();
            }
            else
            {
                if (repo.User.EventUtilisateur == null)
                {
                    repo.User.EventUtilisateur = new ObservableCollection<EvenementsModel>();
                }
                repo.User.EventUtilisateur.Add(eventAAfficher);
                eventAAfficher.Participants.Add(repo.User);

                await DisplayAlert("S'inscrire", "Vous avez été ajouté à l'évènement", "Retour");

                await Refresh();
            }

            
        }

        private async void BoutonDesinscription_Clicked(object sender, EventArgs e)
        {
            var eventAAfficher = BindingContext as EvenementsModel;

            await repo.DesinscriptionEvenement(repo.User.IdUtilisateur, eventAAfficher);

            if (repo.MessageErreur != null)
            {
                await DisplayAlert("Problème!", repo.MessageErreur, "OK");
                await Refresh();
            }
            else
            {

                repo.User.EventUtilisateur.Remove(eventAAfficher);
                eventAAfficher.Participants.Remove(repo.User);

                await DisplayAlert("S'inscrire", "Vous avez été désinscrit de l'évènement", "Retour");

                await Refresh();
            }
        }
    }
}