using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Connexion : ContentPage
    {
        public Connexion()
        {
            InitializeComponent();
            NomUtilisateur.Text = @"batman@batman.com";
            Mdp.Text = "123bat";
            
        }

        private async void Button_Connexion(object sender, EventArgs e)
        {
            UtilisateurModel nouvelUtilisateur = new UtilisateurModel()
            {
                NomUtilisateur = NomUtilisateur.Text,
                MotDePasseUtilisateur = Mdp.Text
            };

            var repo = App.Current.BindingContext as FakeGroupes;
            if (NomUtilisateur.Text != repo.User.EMailUtilisateur || Mdp.Text != repo.User.MotDePasseUtilisateur)
            {
                await DisplayAlert("Problème de connexion", "Le user ou le mot de passe est incorrect", "Réessayer");
            }
            else
            {
                await Navigation.PushAsync(new MainPage());

            }

        }

        private async void Button_Inscription(object sender, EventArgs e)
        {
           
            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PushAsync(new Inscription());
        }
    }
}