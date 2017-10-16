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
    public partial class TabbedPageUtilisateurAutre : TabbedPage
    {
        public TabbedPageUtilisateurAutre()
        {
            InitializeComponent();
            
        }

        public TabbedPageUtilisateurAutre(UtilisateurModel user)
        {
            InitializeComponent();
            BindingContext = user;
            this.Children.Add(new PageProfilUtilisateur(user));
            this.Children.Add(new PageGroupesDeLUtilisateur(user));
        }
    }
}