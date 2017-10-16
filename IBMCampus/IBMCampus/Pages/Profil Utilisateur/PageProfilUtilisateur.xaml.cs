using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageProfilUtilisateur : ContentPage
    {
        public PageProfilUtilisateur()
        {
            InitializeComponent();
            var repoApp = App.Current.BindingContext as FakeRepository;
            BindingContext = repoApp.User;
        }

        public PageProfilUtilisateur(UtilisateurModel user)
        {
            InitializeComponent();
            BindingContext = user;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            
            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PushAsync(new PageUtilisateurTest());
        }
    }
}