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
            if (groupe == null)
            {
                throw new ArgumentNullException("groupe");
            }
            InitializeComponent();
            BindingContext = groupe;
        }
    }
}
