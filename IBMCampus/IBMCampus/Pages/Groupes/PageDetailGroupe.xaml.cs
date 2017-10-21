using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IBMCampus
{
    public partial class PageDetailGroupe : ContentPage
    {
        #region Fields de la page

        Repository repo = App.Current.BindingContext as Repository;

        #endregion

        #region Constructeurs

        public PageDetailGroupe(GroupeModel groupe)
        {
            var groupeAAfficher = groupe ?? throw new ArgumentNullException("groupe");
            InitializeComponent();
            BindingContext = groupe;

        }
        #endregion

        #region Méthodes d'actions

        private async void ButtonInscription_Clicked(object sender, EventArgs e)
        {
            var groupeAffiche = BindingContext as GroupeModel;

            await repo.InscriptionGroupe(repo.User.IdUtilisateur, groupeAffiche.IdGroupe);

            if (repo.MessageErreur != null)
            {
                await DisplayAlert("Problème!", repo.MessageErreur, "OK");
                await Refresh();
            }
            else
            {

                repo.User.GroupesUtilisateur.Add(groupeAffiche);
                groupeAffiche.UtilisateurGroupe.Add(repo.User);

                await DisplayAlert("S'inscrire", string.Format("Vous avez été ajouté au groupe {0}", groupeAffiche.NomGroupe), "Retour");

                await Refresh();

            }
        }


        private async void BoutonDesinscription_Clicked(object sender, EventArgs e)
        {
            var groupeAffiche = BindingContext as GroupeModel;

            await repo.DesinscriptionGroupe(repo.User.IdUtilisateur, groupeAffiche.IdGroupe);

            if (repo.MessageErreur != null)
            {
                await DisplayAlert("Problème!", repo.MessageErreur, "OK");
                await Refresh();
            }
            else
            {

                groupeAffiche.UtilisateurGroupe.Remove(repo.User);
                repo.User.GroupesUtilisateur.Remove(groupeAffiche);

                await DisplayAlert("Désinscription", string.Format("Vous avez été désinscris du groupe {0}", groupeAffiche.NomGroupe), "Retour");

                await Refresh();
            }

        }

        private async void listeUtilisateurGroupe_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listeUtilisateurGroupe.SelectedItem == null)
            {
                return;
            }
            var userSelected = e.SelectedItem as UtilisateurModel;
            await Navigation.PushAsync(new TabbedPageUtilisateurAutre(userSelected));
            listeUtilisateurGroupe.SelectedItem = null;
        }
        #endregion

        #region Méthode de chargements

        private async Task Refresh()
        {
            var groupeAffiche = BindingContext as GroupeModel;

            InitializeComponent();

            await Load(groupeAffiche, repo.User);
        }

        public async Task Load(GroupeModel groupe, UtilisateurModel utilisateur)
        {
            groupe.UtilisateurGroupe = await repo.RecupererUtilisateursDunGroupe(groupe.IdGroupe);

            listeUtilisateurGroupe.ItemsSource = groupe.UtilisateurGroupe;
            if (!groupe.UtilisateurGroupe.Any())
            {
                BoutonInscription.IsVisible = true;
                BoutonDesinscription.IsVisible = false;
            }
            else
            {

                foreach (var user in groupe.UtilisateurGroupe)
                {


                    if (user == utilisateur)
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
            if (groupe.ParticipantsActuelsGroupe == groupe.ParticipantsMax)
            {
                BoutonInscription.IsVisible = false;
            }
        }

        protected override async void OnAppearing()
        {
            var groupe = BindingContext as GroupeModel;
            await Load(groupe, repo.User);
            base.OnAppearing();
        }
        #endregion

    }
}
