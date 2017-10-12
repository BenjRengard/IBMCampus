using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IBMCampus
{
    public partial class PageDetailGroupe : ContentPage
    {
        public PageDetailGroupe(GroupeModel groupe)
        {
            var AppData = App.Current.BindingContext as FakeGroupes;
            var groupeAAfficher = groupe ?? throw new ArgumentNullException("groupe");
            InitializeComponent();
            Load(groupeAAfficher, AppData);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var groupeAffiche = BindingContext as GroupeModel;
            var AppData= App.Current.BindingContext as FakeGroupes;
            AppData.User.GroupesUtilisateur.Add(groupeAffiche.IdGroupe);
            groupeAffiche.UtilisateursDuGroupe.Add(AppData.User);

            Load(groupeAffiche, AppData);


            await DisplayAlert("S'inscrire", string.Format("Vous avez été ajouté au groupe {0}", groupeAffiche.NomGroupe), "Retour");
            
        }

        public void Load(GroupeModel groupe, FakeGroupes appData)
        {
            BindingContext = groupe;
            listeUtilisateurGroupe.ItemsSource = groupe.UtilisateursDuGroupe;
            foreach (var user in groupe.UtilisateursDuGroupe)
            {
                if (user == appData.User)
                {
                    BoutonInscription.IsVisible = false;
                }
            }
        }
    }
}
