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
        public ModificationProfil()
        {
            InitializeComponent();
        }

		public ModificationProfil (UtilisateurModel user)
		{
			InitializeComponent ();
            BindingContext = user;
            NomUtilisateur.Text = user.NomUtilisateur;
            PrenomUtilisateur.Text = user.PrenomUtilisateur;
            EMailUtilisateur.Text = user.EMailUtilisateur;
            //AgeUser.Text = user.AgeUtilisateur.ToString();
            Conducteur.IsToggled = Convert.ToBoolean(user.Vehicule);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var user = BindingContext as UtilisateurModel;

            if (user.NomUtilisateur != NomUtilisateur.Text)
                user.NomUtilisateur = NomUtilisateur.Text;

            if (user.PrenomUtilisateur != PrenomUtilisateur.Text)
                user.PrenomUtilisateur = PrenomUtilisateur.Text;

            if (user.EMailUtilisateur != EMailUtilisateur.Text)
                user.EMailUtilisateur = EMailUtilisateur.Text;

            //if (user.AgeUtilisateur.ToString() != AgeUser.Text)
            //{
            //    int age;
            //    var result = int.TryParse(AgeUser.Text, out age);
            //    if (result)
            //    {
            //        if (age <= 0)
            //        {
            //            await DisplayAlert("Problème lors de la modification", "L'âge entré est incorrect", "OK");
            //        }
            //        user.AgeUtilisateur = age;
            //    }
            //    else
            //    {
            //        await DisplayAlert("Problème lors de la modification", "L'âge entré est incorrect", "OK");
            //    }
            //}
                

            if (Convert.ToBoolean(user.Vehicule) != Conducteur.IsToggled)
                user.Vehicule = Conducteur.IsToggled.ToString();

            await DisplayAlert("Modification du profil", "Votre profil a été modifié", "OK");
            await Navigation.PopAsync();

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}