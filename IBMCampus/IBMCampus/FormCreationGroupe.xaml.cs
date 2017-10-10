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
	public partial class FormCreationGroupe : ContentPage
	{
		public FormCreationGroupe ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            GroupeModel nouveauGroupe = new GroupeModel()
            {
                NomGroupe = NomNouveauGroupe.Text,
                SportDuGroupe = new SportModel()
                {
                    NomSport = SportNouveauGroupe.Text
                }
            };
            FakeGroupes repo = new FakeGroupes();
            repo.ListeFauxGroupes.Add(nouveauGroupe);
            //A ne pas faire. Il ne faut pas utiliser PushAsync, mais PopAsync. Ici, c'était uniquement pour le test.
            await Navigation.PushAsync(new PageTousLesGroupes(repo));

        }
    }
}