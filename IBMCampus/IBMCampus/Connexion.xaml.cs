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
        }

        private async void Button_Connexion(object sender, EventArgs e)
        {
            UtilisateurModel nouvelUtilisateur = new UtilisateurModel()
            {
                NomUtilisateur = NomUtilisateur.Text,
                Mdp = Mdp.Text
            };

            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PushAsync(new MainPage());
        }

        private async void Button_Inscription(object sender, EventArgs e)
        {
           
            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PushAsync(new Inscription());
        }
    }
}