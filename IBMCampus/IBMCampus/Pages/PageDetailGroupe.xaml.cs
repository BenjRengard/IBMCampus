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
            BindingContext = groupeAAfficher;
            listeUtilisateurGroupe.ItemsSource = groupe.UtilisateursDuGroupe;
            foreach (var user in groupe.UtilisateursDuGroupe)
            {
                if (user == AppData.User)
                {
                    BoutonInscription.IsVisible = false;
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var groupeAffiche = BindingContext as GroupeModel;
            var AppData= App.Current.BindingContext as FakeGroupes;
            groupeAffiche.UtilisateursDuGroupe.Add(AppData.User);

            //Ajouter l'utilisateur dans le groupe.
            DisplayAlert("S'inscrire", string.Format("Vous avez été ajouté au groupe {0}", groupeAffiche.NomGroupe), "Retour");
        }
    }
}
