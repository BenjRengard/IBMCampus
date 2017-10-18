using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus.Pages.Profil_Utilisateur
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModificationProfil : ContentPage
	{
        public ModificationProfil()
        {
            InitializeComponent();
        }

		public ModificationProfil (UtilisateurModel user)
		{
			InitializeComponent ();
            BindingContext = user;
            NomUtilisateur.Text = user.NomUtilisateur;
            PrenomUtilisateur.Text = user.PrenomUtilisateur;
            EMailUtilisateur.Text = user.EMailUtilisateur;
            AgeUser.Text = ""+user.AgeUtilisateur;
        }
	}
}