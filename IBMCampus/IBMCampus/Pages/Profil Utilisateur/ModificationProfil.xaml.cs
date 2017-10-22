using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus.Pages.Profil_Utilisateur
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModificationProfil : ContentPage
    {

        Repository repo = App.Current.BindingContext as Repository;

        public ModificationProfil()
        {
            InitializeComponent();
        }

        public ModificationProfil(UtilisateurModel user)
        {
            InitializeComponent();
            BindingContext = user;
            NomUtilisateur.Text = user.NomUtilisateur;
            PrenomUtilisateur.Text = user.PrenomUtilisateur;
            //EMailUtilisateur.Text = user.EMailUtilisateur;
            //AgeUser.Text = user.AgeUtilisateur.ToString();
            if (user.Vehicule == "1")
            {
                Conducteur.IsToggled = true;
            }
            else
            {
                Conducteur.IsToggled = false;
            }
            //Conducteur.IsToggled = Convert.ToBoolean(user.Vehicule);
            Bureau.Text = user.AdresseUtilisateur;
            TelephoneUtilisateur.Text = user.TelephoneUtilisateur;
            NombrePlace.Text = user.NombrePlaceVoiture.ToString();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var utilisateurModifie = new UtilisateurModel();
            utilisateurModifie = repo.User;

            if (utilisateurModifie.NomUtilisateur != NomUtilisateur.Text)
                utilisateurModifie.NomUtilisateur = NomUtilisateur.Text;
            if (utilisateurModifie.TelephoneUtilisateur != TelephoneUtilisateur.Text)
                utilisateurModifie.TelephoneUtilisateur = TelephoneUtilisateur.Text;
            if (utilisateurModifie.AdresseUtilisateur != Bureau.Text)
                utilisateurModifie.AdresseUtilisateur = Bureau.Text;
            if (utilisateurModifie.NombrePlaceVoiture.ToString() != NombrePlace.Text)
            {
                if (string.IsNullOrWhiteSpace(NombrePlace.Text))
                {
                    utilisateurModifie.NombrePlaceVoiture = 1;
                }
                else
                {
                    utilisateurModifie.NombrePlaceVoiture = Convert.ToInt32(NombrePlace.Text);

                }
            }
            //if (user.NomUtilisateur != NomUtilisateur.Text)
            //    user.NomUtilisateur = NomUtilisateur.Text;

            if (utilisateurModifie.PrenomUtilisateur != PrenomUtilisateur.Text)
                utilisateurModifie.PrenomUtilisateur = PrenomUtilisateur.Text;

            //if (Convert.ToBoolean(utilisateurModifie.Vehicule) != Conducteur.IsToggled)
            //    utilisateurModifie.Vehicule = Conducteur.IsToggled.ToString();

            await repo.ModifierProfilUtilisateur(utilisateurModifie);

            if (repo.MessageErreur != null)
            {
                await DisplayAlert("Modification", repo.MessageErreur, "Ok");
                await Navigation.PopAsync();
            }
            else
            {
                repo.User = utilisateurModifie;
                await DisplayAlert("Modification du profil", "Votre profil a été modifié", "OK");
                await Navigation.PopAsync();
            }
            
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}