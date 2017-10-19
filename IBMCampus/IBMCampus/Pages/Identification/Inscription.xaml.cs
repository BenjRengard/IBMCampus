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
        private const string UrlInsert = "http://mooguer.fr/inscription.php?";
        private const string UrlControle = "http://mooguer.fr/VerifUserUnique.php?";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<UtilisateurProxy> _utilisateur;

        public Inscription()
        {
            InitializeComponent();
        }

        private async void Button_Inscription(object sender, EventArgs e)
        {


            UtilisateurProxy nouvelUser = new UtilisateurProxy
            {
                usr_lastname = NomUtilisateur.Text,
                usr_firstname = PrenomUtilisateur.Text,
                usr_mail = EMailUtilisateur.Text,
                usr_password = MdpUser.Text,
                usr_phonenumber = TelephoneUtilisateur.Text,
                usr_driver = Conducteur.IsToggled ? 1 : 0
            };

            var controle = await _client.GetStringAsync(UrlControle + "mail=" + '"' + nouvelUser.usr_mail + '"');
            var user = JsonConvert.DeserializeObject<List<UtilisateurProxy>>(controle);
            _utilisateur = new ObservableCollection<UtilisateurProxy>(user);

            if (MdpUser.Text != MdpUser1.Text)
            {
                await DisplayAlert("Problème", "Mot de passe différent", "OK");

                NomUtilisateur.Text = nouvelUser.usr_lastname;
                PrenomUtilisateur.Text = nouvelUser.usr_lastname;
                TelephoneUtilisateur.Text = nouvelUser.usr_lastname;
                EMailUtilisateur.Text = nouvelUser.usr_mail;
            }
            else

            if (_utilisateur.Count > 0)
            {
                await DisplayAlert("Problème", "Email déjà utilisé", "OK");

                NomUtilisateur.Text = nouvelUser.usr_lastname;
                PrenomUtilisateur.Text = nouvelUser.usr_lastname;
                TelephoneUtilisateur.Text = nouvelUser.usr_lastname;

            }
            else
            {
                try
                {
                    string content = JsonConvert.SerializeObject(nouvelUser);
                    string insert = UrlInsert + "firstname=" + nouvelUser.usr_firstname
                                      + "&lastname=" + nouvelUser.usr_lastname
                                      + "&mail=" + nouvelUser.usr_mail
                                      + "&password=" + nouvelUser.usr_password
                                      + "&phoneNumber=" + nouvelUser.usr_phonenumber
                                      + "&driver=" + nouvelUser.usr_driver;

                    await _client.GetStringAsync(insert);
                    
                }
                catch (Exception err)
                {
                    Log.Warning("download", err.ToString());


                    await DisplayAlert("Problème", "Problème de connexion au serveur", "OK");
                    //throw;
                }
                
                await Navigation.PopAsync();

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


        }

        private async void Button_Annuler(object sender, EventArgs e)
        {

            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PopAsync();
        }
    }
}