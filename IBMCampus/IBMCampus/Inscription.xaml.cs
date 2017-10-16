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
            int age;
            var result = int.TryParse(AgeUser.Text, out age);
            if (result == false)
            {
                age = 0;
            }
            UtilisateurModel nouvelUtilisateur = new UtilisateurModel()
            {
                NomUtilisateur = NomUtilisateur.Text,
                PrenomUtilisateur = PrenomUtilisateur.Text,
                EMailUtilisateur = EMailUtilisateur.Text,
                TelephoneUtilisateur = TelephoneUtilisateur.Text,
                AgeUtilisateur = age,
                MotDePasseUtilisateur = MdpUser.Text,
                Vehicule = Conducteur.IsToggled
            };

            var repo = App.Current.BindingContext as FakeGroupes;
            repo.UtilisateursEnregistres.Add(nouvelUtilisateur);
            //repo.User = nouvelUtilisateur;
            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PopAsync();

        }

        private async void Button_Annuler(object sender, EventArgs e)
        {

            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PopAsync();
        }
    }
}