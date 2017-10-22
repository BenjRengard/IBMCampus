using IBMCampus.Pages.Profil_Utilisateur;
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
        Repository repo = App.Current.BindingContext as Repository;

        public PageProfilUtilisateur()
        {

            InitializeComponent();

            BindingContext = repo.User;
            UtilisateurModel utilisateur = repo.User;
        }

        public PageProfilUtilisateur(UtilisateurModel user)
        {
            InitializeComponent();
            BindingContext = user;
            UtilisateurModel utilisateur = user;

        }


        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            var user = BindingContext as UtilisateurModel;

            if (user.IdUtilisateur != repo.User.IdUtilisateur)
            {
                await DisplayAlert("Action non autorisée", "Vous ne pouvez modifier le profil de quelqu'un d'autre.", "OK");
            }
            else
            {

                await Navigation.PushAsync(new ModificationProfil(repo.User));
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PushAsync(new PageUtilisateurTest());
        }
    }
}