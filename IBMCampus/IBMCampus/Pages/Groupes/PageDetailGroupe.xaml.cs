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
        public PageDetailGroupe(GroupeModel groupe)
        {
            var AppData = App.Current.BindingContext as UtilisateurModel;
            var groupeAAfficher = groupe ?? throw new ArgumentNullException("groupe");
            InitializeComponent();
            Load(groupeAAfficher, AppData);

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var groupeAffiche = BindingContext as GroupeModel;
            var utilisateur = App.Current.BindingContext as UtilisateurModel;
            

            
            utilisateur.GroupesUtilisateur.Add(groupeAffiche.IdGroupe);
            groupeAffiche.UtilisateurGroupe.Add(utilisateur);

            Load(groupeAffiche, utilisateur);


            await DisplayAlert("S'inscrire", string.Format("Vous avez été ajouté au groupe {0}", groupeAffiche.NomGroupe), "Retour");

            Refresh();

        }

        public void Load(GroupeModel groupe, UtilisateurModel utilisateur)
        {

            BindingContext = groupe;
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

        private async void BoutonDesinscription_Clicked(object sender, EventArgs e)
        {
            var groupeAffiche = BindingContext as GroupeModel;
            var utilisateur = App.Current.BindingContext as UtilisateurModel;
            groupeAffiche.UtilisateurGroupe.Remove(utilisateur);
            utilisateur.GroupesUtilisateur.Remove(groupeAffiche.IdGroupe);

            Load(groupeAffiche, utilisateur);


            await DisplayAlert("Désinscription", string.Format("Vous avez été désinscris du groupe {0}", groupeAffiche.NomGroupe), "Retour");
            Refresh();

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

        private void Refresh()
        {
            var groupeAffiche = BindingContext as GroupeModel;
            var utilisateur = App.Current.BindingContext as UtilisateurModel;
            InitializeComponent();
            Load(groupeAffiche, utilisateur);
        }

        
    }
}
