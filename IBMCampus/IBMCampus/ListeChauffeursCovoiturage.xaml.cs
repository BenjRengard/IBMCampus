using IBMCampus.FakeRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeChauffeursCovoiturage : ContentPage
    {
        public ListeChauffeursCovoiturage()
        {
            InitializeComponent();
            Load();
        }
        

        public void Load()
        {
            var repo = App.Current.BindingContext as FakeGroupes;
            liste.ItemsSource = repo.RecupererTousChauffeurs();
            
        }

        private void liste_Refreshing(object sender, EventArgs e)
        {
            Load();
            liste.EndRefresh();
        }
    }

}