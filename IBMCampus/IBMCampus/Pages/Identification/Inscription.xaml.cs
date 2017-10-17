using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inscription : ContentPage
    {
        private const string Url = "http://mooguer.fr/inscription.php?json=";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<UtilisateurTestModel> _utilisateur;

        public Inscription()
        {
            InitializeComponent();
        }

        private async void Button_Inscription(object sender, EventArgs e)
        {
            try
            {
                int age;
                var result = int.TryParse(AgeUser.Text, out age);
                if (result == false)
                {
                    age = 0;
                }

                UtilisateurTestModel nouvelUser = new UtilisateurTestModel
                {
                    usr_lastname = NomUtilisateur.Text,
                    usr_firstname = PrenomUtilisateur.Text,
                    usr_mail = EMailUtilisateur.Text,
                    usr_password = MdpUser.Text,
                    usr_phonenumber = TelephoneUtilisateur.Text
                };
                
                string content = JsonConvert.SerializeObject(nouvelUser);
                await _client.PostAsync(Url, new StringContent(content));

            }
            catch (Exception err)
           {
                Log.Warning("download", err.ToString());


            await DisplayAlert("Problème", "Problème de connexion au serveur", "OK");
                //throw;
            }
            //int age;
            //var result = int.TryParse(AgeUser.Text, out age);
            //if (result == false)
            //{
            //    age = 0;
            //}
            //UtilisateurModel nouvelUtilisateur = new UtilisateurModel()
            //{
            //    NomUtilisateur = NomUtilisateur.Text,
            //    PrenomUtilisateur = PrenomUtilisateur.Text,
            //    EMailUtilisateur = EMailUtilisateur.Text,
            //    TelephoneUtilisateur = TelephoneUtilisateur.Text,
            //    AgeUtilisateur = age,
            //    MotDePasseUtilisateur = MdpUser.Text,
            //    Vehicule = Conducteur.IsToggled
            //};

            //var repo = App.Current.BindingContext as FakeRepository;
            //repo.UtilisateursEnregistres.Add(nouvelUtilisateur);
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