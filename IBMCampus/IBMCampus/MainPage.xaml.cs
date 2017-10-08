using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IBMCampus
{
    public partial class MainPage : ContentPage
    {
        public MainPage(GroupeModel groupe)
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
