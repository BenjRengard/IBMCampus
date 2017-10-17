using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }
    }
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