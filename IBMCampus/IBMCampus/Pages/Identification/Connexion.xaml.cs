using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Connexion : ContentPage
    {  
        private string url = "http:/9.129.126.182/api/Profil";
        private HttpClient _client = new HttpClient();
        public Connexion()
        {
            InitializeComponent();
            EmailUtilisateur.Text = @"batman@batman.com";
            MotDePasse.Text = "123bat";

        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    try
        //    {
        //        var retour = await _client.GetStringAsync(url);
        //        var result = JsonConvert.DeserializeObject<string>(retour);
        //        EmailUtilisateur.Text = result;
        //    }
        //    catch (Exception)
        //    {

        //        EmailUtilisateur.Text = @"fonctionne pas";
        //    }
            
        //}

        private async void Button_Connexion(object sender, EventArgs e)
        {
            var repo = App.Current.BindingContext as FakeRepository;

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