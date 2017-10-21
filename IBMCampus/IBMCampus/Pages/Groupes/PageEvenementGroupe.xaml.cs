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
    public partial class PageEvenementGroupe : ContentPage
    {
        #region Fields de la page

        public UtilisateurModel User;

        public GroupeModel Groupe;

        Repository repo = App.Current.BindingContext as Repository;
        #endregion
        #region Constructeurs

        public PageEvenementGroupe(GroupeModel groupe)
        {
            InitializeComponent();

            BindingContext = groupe;
        }

        #endregion

        #region Méthodes d'action

        private async void liste_Refreshing(object sender, EventArgs e)
        {
            await Load();
            liste.IsRefreshing = false;
        }

        private async void liste_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (liste.SelectedItem == null)
            {
                return;
            }

            var Event = e.SelectedItem as EvenementsModel;
            await Navigation.PushAsync(new PageDetailEvent(Event));
            liste.SelectedItem = null;

        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            var groupe = BindingContext as GroupeModel;
            var match = false;
            foreach (var user in groupe.UtilisateurGroupe)
            {
                if (user.IdUtilisateur == repo.User.IdUtilisateur)
                {
                    match = true;
                    break;
                }
            }
            if (!match)
            {
                await DisplayAlert("Action", "Vous ne pouvez pas créer un évènement dans un groupe auquel nous n'appartenez pas", "OK");
            }
            else
            {
                await Navigation.PushAsync(new PageFormCreationEvent(groupe));
            }
        }
        #endregion

        #region Méthode de chargement

        private async Task Load()
        {
            var groupe = BindingContext as GroupeModel;


            var listeACharger = await repo.RecupererEvenementsGroupe(groupe.IdGroupe.ToString());
            liste.ItemsSource = listeACharger;
            if (listeACharger == null)
            {
                await DisplayAlert("Problème", repo.MessageErreur, "OK");
            }
        }

        protected override async void OnAppearing()
        {

            await Load();

            base.OnAppearing();
        }
        #endregion
    }
}