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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageUtilisateurTest : ContentPage
    {
        private const string Url = "http://mooguer.fr/api.php";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<UtilisateurProxy> _utilisateur = new ObservableCollection<UtilisateurProxy>();
        private ObservableCollection<EvenementProxy> _evenement = new ObservableCollection<EvenementProxy>();


        public PageUtilisateurTest()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            //try
            //{
            //    var content = await _client.GetStringAsync(Url);
            //    var user = JsonConvert.DeserializeObject<List<UtilisateurProxy>>(content);
            //    _utilisateur = new ObservableCollection<UtilisateurProxy>(user);
            //    liste.ItemsSource = _utilisateur;
            //}
            //catch (Exception )
            //{
            //    await DisplayAlert("Problème", "Problème de connexion au serveur", "OK");
            //    //throw;
            //}
            Repository repo = new Repository();
            //var listeId = new List<int>();
            //await repo.ListerIdUtilisateur(listeId);
            var listeIdUser = await repo.ListerTousLesIdUtilisateur();
            var listeIdEvent = await repo.ListerTousLesIdEvenement();
            //if (repo.MessageErreur != null)
            //{
            //    await DisplayAlert("Méthode", repo.MessageErreur, "OK");
            //}
            if (listeIdUser == null)
            {
                await DisplayAlert(repo.MessageErreur, "Problème de connexion au serveur", "OK");
                _utilisateur.Add(new UtilisateurProxy() { usr_Id = 0 });
            }
            else
            {
                foreach (var id in listeIdUser)
                {
                    _utilisateur.Add(new UtilisateurProxy() { usr_Id = id });
                }
            }


            liste.ItemsSource = _utilisateur;

            if (listeIdEvent == null)
            {
                await DisplayAlert(repo.MessageErreur, "Problème de connexion au serveur", "OK");
                _evenement.Add(new EvenementProxy() { es_Id = 0 });
            }
            else
            {
                foreach (var id in listeIdEvent)
                {
                    _evenement.Add(new EvenementProxy() { es_Id = id });
                }
            }

            liste.ItemsSource = _evenement;
            base.OnAppearing();
        }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        var content = await _client.GetStringAsync(Url);
        //        var user = JsonConvert.DeserializeObject<List<UtilisateurTestModel>>(content);
        //        _utilisateur = new ObservableCollection<UtilisateurTestModel>(user);
        //        liste.ItemsSource = _utilisateur;

        //        Log.Warning("OK", content);

        //    }
        //    catch (Exception err)
        //    {
        //        Log.Warning("download", err.ToString());


        //        //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.

        //    }
        //    await Navigation.PushAsync(new PageUtilisateurTest());
        //}
    }
}