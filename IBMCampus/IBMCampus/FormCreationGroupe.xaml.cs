using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormCreationGroupe : ContentPage
    {
        public FormCreationGroupe()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var repo = App.Current.BindingContext as FakeGroupes;
            int nbParticip;
            var result = int.TryParse(NombreParticipantsMax.Text, out nbParticip);
            if (!result)
            {
                nbParticip = 1;
            }
            if (nbParticip <= 0)
            {
                nbParticip = 1;
            }
            GroupeModel nouveauGroupe = new GroupeModel()
            {
                NomGroupe = NomNouveauGroupe.Text,
                SportDuGroupe = new SportModel()
                {
                    NomSport = SportNouveauGroupe.Text
                },
                UtilisateursDuGroupe = new ObservableCollection<UtilisateurModel>() { repo.User },
                IdGroupe = (repo.ListeFauxGroupes.Count + 1),
                ParticipantsMax = nbParticip,
                LocalisationCodePostal = CodePostal.Text,
                LocalisationNomRue = NomVoie.Text,
                LocalisationNumero = NumeroVoie.Text,
                LocalisationTypeVoie = TypeVoie.Text,
                LocalisationVille = Ville.Text

            };
            repo.ListeFauxGroupes.Add(nouveauGroupe);
            repo.User.GroupesUtilisateur.Add(nouveauGroupe.IdGroupe);
            App.Current.BindingContext = repo;
            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PopAsync();

        }
    }
}