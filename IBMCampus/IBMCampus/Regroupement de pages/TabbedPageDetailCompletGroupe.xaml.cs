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
    public partial class TabbedPageDetailCompletGroupe : TabbedPage
    {
        public TabbedPageDetailCompletGroupe(GroupeModel groupe)
        {
            InitializeComponent();
            this.Children.Add(new PageDetailGroupe(groupe));
            this.Children.Add(new PageEvenementGroupe(groupe));
            BindingContext = groupe;
        }
    }
}