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
            var groupeAAfficher = groupe ?? throw new ArgumentNullException("groupe");
            InitializeComponent();
            BindingContext = groupeAAfficher;
            listeUtilisateurGroupe.ItemsSource = groupe.UtilisateursDuGroupe;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var groupeAffiche = BindingContext as GroupeModel;

            groupeAffiche.UtilisateursDuGroupe.Add(new UtilisateurModel()
            {
                NomUtilisateur = "Utilisateur",
                PrenomUtilisateur = "Actuel"
            });

            //Ajouter l'utilisateur dans le groupe.
            DisplayAlert(groupeAffiche.NomGroupe, string.Format("Vous avez été ajouté au groupe {0}", groupeAffiche.NomGroupe), "Retour");
        }
    }
}
