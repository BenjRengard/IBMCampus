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
	public partial class PageDetailEvent : ContentPage
	{
		public PageDetailEvent ()
		{
			InitializeComponent ();
		}

        public PageDetailEvent(EvenementsModel evenement)
        {
            var AppData = App.Current.BindingContext as FakeRepository;
            var eventAAfficher = evenement ?? throw new ArgumentNullException("evenement");
            InitializeComponent();
            Load(eventAAfficher, AppData);
        }

        public void Load(EvenementsModel evenement, FakeRepository appData)
        {

            BindingContext = evenement;
        }

        private void Refresh()
        {
            var eventAffiche = BindingContext as EvenementsModel;
            var AppData = App.Current.BindingContext as FakeRepository;
            InitializeComponent();
            Load(eventAffiche, AppData);
        }
    }
}