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
    public partial class CovoiturageChauffeur : ContentPage
    {
        public CovoiturageChauffeur()
        {
            InitializeComponent();
        }
        

        private async void Button_Enregistrer(object sender, EventArgs e)
        {
            var chauffeur = new ChauffeurModel()
            {
                NombrePlace = Convert.ToInt32(NombreDePlace.Text),
                Localisation = Batiment.Text,
                HeureRdv = Convert.ToDateTime(Horaire.Text),
                VisibiliteTelephone = TelephoneVisible.IsToggled

            };
            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await DisplayAlert("Covoiturage", "Votre demande a bien été prise en compte", "Retour");
            await Navigation.PopAsync();
        }

        private async void Button_Annuler(object sender, EventArgs e)
        {
            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PushAsync(new ListeChauffeursCovoiturage());
        }


    }
}