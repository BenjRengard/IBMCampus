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
    public partial class Inscription : ContentPage
    {

        public Inscription()
        {
            InitializeComponent();
        }
        
        private async void Button_Inscription(object sender, EventArgs e)
        {
            UtilisateurModel nouvelUtilisateur = new UtilisateurModel()
            {
                NomUtilisateur = NomUtilisateur.Text,
                PrenomUtilisateur = PrenomUtilisateur.Text,
                EMailUtilisateur = EMailUtilisateur.Text,
                TelephoneUtilisateur = TelephoneUtilisateur.Text,
                AgeUtilisateur = Convert.ToInt32(AgeUser.Text),
                MotDePasseUtilisateur = MdpUser.Text
            };

            var repo = App.Current.BindingContext as FakeGroupes;
            repo.UtilisateursEnregistres.Add(nouvelUtilisateur);
            repo.User = nouvelUtilisateur;
            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PushAsync(new Connexion());
            Navigation.RemovePage(this);

        }

        private async void Button_Annuler(object sender, EventArgs e)
        {

            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PushAsync(new Connexion());
        }
    }
}