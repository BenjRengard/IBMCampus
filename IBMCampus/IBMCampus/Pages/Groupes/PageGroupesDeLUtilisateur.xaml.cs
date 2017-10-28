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
        #region Fields de la page

        /// <summary>
        /// Utilisateur si en consultation.
        /// </summary>
        public UtilisateurModel user;

        /// <summary>
        /// Repository de l'application.
        /// </summary>
        Repository repo = App.Current.BindingContext as Repository;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur de base. Appellé lors de la l'affichage pour les groupes de l'utilisateur actuel.
        /// </summary>
        public PageGroupesDeLUtilisateur()
        {
            InitializeComponent();
            user = repo.User;
        }

        /// <summary>
        /// Constructeur particulier. Appellé lors de l'affichage pour les groupes d'un utilisateur selectionné (pour simple consultation).
        /// </summary>
        /// <param name="utilisateur">Utilisateur selectionné en consultation.</param>
        public PageGroupesDeLUtilisateur(UtilisateurModel utilisateur)
        {
            InitializeComponent();
            user = utilisateur;
        }
        #endregion

        #region Méthodes d'action

        /// <summary>
        /// Asynchrone. Méthode pour charger la page de groupe du groupe selectionné dans la liste.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Méthode pour ouvrir la page de création de groupe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            if (user != repo.User)
            {
                await DisplayAlert("Action non autorisée", "Vous ne pouvez pas créer de groupe sur la page d'un autre utilisateur.", "OK");
            }
            else
            {

                await Navigation.PushAsync(new FormCreationGroupe());
            }
        }

        /// <summary>
        /// Méthode de rafraichissement de la liste.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private async void liste_Refreshing(object sender, EventArgs e)
        {
            await Load(user);
            liste.EndRefresh();
        }
        #endregion

        #region Méthodes de rechargement


        /// <summary>
        /// Asynchrone. Méthode pour chargé les données de la liste.
        /// </summary>
        /// <param name="utilisateur">Paramètre optionnel. Utilisateur en consultation ou null.</param>
        /// <returns></returns>
        private async Task Load(UtilisateurModel utilisateur = null)
        {
            //Si utilisateur en consultation n'est pas renseigné, utilisateur de l'application.
            if (utilisateur == null)
            {
                user = repo.User;
            }
            //Sinon, utilisateur en consultation.
            else
            {
                user = utilisateur as UtilisateurModel;

            }

            //Liste chargé avec un appel api.

            var listeACharger = await repo.RecupererGroupesUser(user.IdUtilisateur.ToString());

            liste.ItemsSource = listeACharger;
            repo.User.GroupesUtilisateur = listeACharger;

            if (listeACharger == null)
            {
                await DisplayAlert("Information", "Aucune inscription à un groupe", "OK");
            }
            if (repo.MessageErreur != null)
            {
                await DisplayAlert("Problème", repo.MessageErreur, "OK");
            }
        }

        /// <summary>
        /// Méthode ovverider de l'apparition de la page. Permet de charger la liste en asynchrone au moment de l'affichage.
        /// </summary>
        protected override async void OnAppearing()
        {
            liste.IsRefreshing = true;
            if (user == null)
            {
                await Load();
                liste.IsRefreshing = false;
            }
            else
            {
                await Load(user);
                liste.IsRefreshing = false;
            }
            base.OnAppearing();

        }
        #endregion


    }
}