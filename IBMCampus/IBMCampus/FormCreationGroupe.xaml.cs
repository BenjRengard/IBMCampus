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
            GroupeModel nouveauGroupe = new GroupeModel()
            {
                NomGroupe = NomNouveauGroupe.Text,
                SportDuGroupe = new SportModel()
                {
                    NomSport = SportNouveauGroupe.Text
                },
                UtilisateursDuGroupe = new ObservableCollection<UtilisateurModel>() { repo.User }

            };
            repo.ListeFauxGroupes.Add(nouveauGroupe);
            App.Current.BindingContext = repo;
            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PopAsync();

        }
    }
}