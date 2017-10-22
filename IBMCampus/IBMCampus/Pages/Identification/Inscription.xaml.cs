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
        private ObservableCollection<UtilisateurModel> _utilisateur = new ObservableCollection<UtilisateurModel>();

        public Inscription()
        {
            InitializeComponent();
        }

        private async void Button_Inscription(object sender, EventArgs e)
        {

            UtilisateurModel nouvelUser = new UtilisateurModel()
            {
                EMailUtilisateur = EMailUtilisateur.Text,
                MotDePasseUtilisateur = MdpUser.Text,
                NomUtilisateur = NomUtilisateur.Text,
                PrenomUtilisateur = PrenomUtilisateur.Text,
                TelephoneUtilisateur = TelephoneUtilisateur.Text,
                Vehicule = Conducteur.IsToggled.ToString()
            };
            //UtilisateurProxy nouvelUser = new UtilisateurProxy
            //{
            //    usr_lastname = NomUtilisateur.Text,
            //    usr_firstname = PrenomUtilisateur.Text,
            //    usr_mail = EMailUtilisateur.Text,
            //    usr_password = MdpUser.Text,
            //    usr_phonenumber = TelephoneUtilisateur.Text,
            //    usr_driver = Conducteur.IsToggled ? 1 : 0
            //};

            var controle = await _client.GetStringAsync(UrlControle + "mail=" + '"' + EMailUtilisateur.Text + '"');
            var user = JsonConvert.DeserializeObject<ObservableCollection<UtilisateurModel>>(controle);
            //_utilisateur = new ObservableCollection<UtilisateurModel>(user);

            if (MdpUser.Text != MdpUser1.Text)
            {
                await DisplayAlert("Problème", "Mot de passe différent", "OK");

                NomUtilisateur.Text = nouvelUser.NomUtilisateur;
                PrenomUtilisateur.Text = nouvelUser.PrenomUtilisateur;
                TelephoneUtilisateur.Text = nouvelUser.TelephoneUtilisateur;
                EMailUtilisateur.Text = nouvelUser.EMailUtilisateur;
            }
            else
            {
                if (user.Count > 0)
                {
                    await DisplayAlert("Problème", "Email déjà utilisé", "OK");

                    NomUtilisateur.Text = nouvelUser.NomUtilisateur;
                    PrenomUtilisateur.Text = nouvelUser.PrenomUtilisateur;
                    TelephoneUtilisateur.Text = nouvelUser.TelephoneUtilisateur;

                }
                else
                {
                    try
                    {
                        int drive = (Convert.ToBoolean(nouvelUser.Vehicule)) ? 1 : 0;
                        string content = JsonConvert.SerializeObject(nouvelUser);
                        string insert = UrlInsert + "prenom=" + nouvelUser.PrenomUtilisateur
                                          + "&nom=" + nouvelUser.NomUtilisateur
                                          + "&mail=" + nouvelUser.EMailUtilisateur
                                          + "&mdp=" + nouvelUser.MotDePasseUtilisateur
                                          + "&NumeroTelephone=" + nouvelUser.TelephoneUtilisateur
                                          + "&Vehicule=" + drive;

                        await _client.GetStringAsync(insert);
                        await DisplayAlert("Création d'un profil", string.Format("Le profil de {0} {1} a bien été crée", nouvelUser.PrenomUtilisateur, nouvelUser.NomUtilisateur), "OK");
                        await Navigation.PopAsync();

                    }
                    catch (Exception err)
                    {
                        Log.Warning("download", err.ToString());


                        await DisplayAlert("Problème", "Problème de connexion au serveur", "OK");
                        //throw;
                    }


                }
                #region Code commenté
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
                #endregion

            }


        }

        private async void Button_Annuler(object sender, EventArgs e)
        {

            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PopAsync();
        }
    }
}