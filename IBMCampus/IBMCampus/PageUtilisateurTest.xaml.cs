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
        private ObservableCollection<UtilisateurTestModel> _utilisateur;

        public PageUtilisateurTest()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            try
            {
                var content = await _client.GetStringAsync(Url);
                var user = JsonConvert.DeserializeObject<List<UtilisateurTestModel>>(content);
                _utilisateur = new ObservableCollection<UtilisateurTestModel>(user);
                liste.ItemsSource = _utilisateur;
            }
            catch (Exception )
            {
                await DisplayAlert("Problème", "Problème de connexion au serveur", "OK");
                //throw;
            }
           

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