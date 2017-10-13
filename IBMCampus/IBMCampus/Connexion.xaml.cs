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
            EmailUtilisateur.Text = @"batman@batman.com";
            MotDePasse.Text = "123bat";

        }

        private async void Button_Connexion(object sender, EventArgs e)
        {
            var repo = App.Current.BindingContext as FakeGroupes;

            var utilisateur = repo.UtilisateursEnregistres.FirstOrDefault(u => u.EMailUtilisateur == EmailUtilisateur.Text);
            if (utilisateur == null)
            {
                await DisplayAlert("Problème de connexion", "Le user est incorrect", "Réessayer");

            }

            if (MotDePasse.Text == (utilisateur.MotDePasseUtilisateur))
            {
                repo.User = utilisateur;
                await Navigation.PushModalAsync(new MasterDetailPage1());


            }
            else
            {
                await DisplayAlert("Problème de connexion", "Le user ou le mot de passe est incorrect", "Réessayer");

            }


        }

        private async void Button_Inscription(object sender, EventArgs e)
        {

            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PushAsync(new Inscription());
        }
    }
}