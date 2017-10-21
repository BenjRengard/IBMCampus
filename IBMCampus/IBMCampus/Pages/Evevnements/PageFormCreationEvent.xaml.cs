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
    public partial class PageFormCreationEvent : ContentPage
    {
        public PageFormCreationEvent()
        {

        }

        public PageFormCreationEvent(GroupeModel groupe)
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var repo = App.Current.BindingContext as FakeRepository;

            int nbParticip;
            var result = int.TryParse(NombreParticipantsMax.Text, out nbParticip);

            if (!result)
                nbParticip = 1;

            if (nbParticip <= 0)
                nbParticip = 1;

            EvenementsModel nouvelEvent = new EvenementsModel()
            {
                //DebutEvenement = EventDebut.DateTime,
                //FinEvenement = EventFin.DateTime,
                NomEvenement = NomNouvelEvent.Text,
                //GroupeDeLevenement = GroupeEvent.Text,
                NombreMaximumParticipant = nbParticip,
                LocalisationEvenement = Lieu.Text,
                //IsRecurentHebdo = Hebdo.IsToggled
            };



            //repo.ListeFauxEvent.Add(nouvelEvent);
            //repo.User.GroupesUtilisateur.Add(nouvelEvent.IdEvent);
            App.Current.BindingContext = repo;
            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PopAsync();
        }
    }
}