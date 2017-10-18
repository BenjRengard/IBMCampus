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
    public partial class PageEvenementGroupe : ContentPage
    {
        private FakeRepository repo;

        public PageEvenementGroupe(GroupeModel groupe)
        {
            InitializeComponent();
            Load(groupe);
           
            BindingContext = groupe;
        }

        private void Load(GroupeModel groupe)
        {
            this.repo = App.Current.BindingContext as FakeRepository;
            liste.ItemsSource = repo.RecupererEvenementGroupe(groupe);
        }

        private void liste_Refreshing(object sender, EventArgs e)
        {

        }
        
        private void liste_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            var groupe = BindingContext as GroupeModel;
            var match = false;
            foreach (var user in groupe.UtilisateursDuGroupe)
            {
                if (user == repo.User)
                {
                    match = true;
                    break;
                }
            }
            if (match == false)
            {
                await DisplayAlert("Action", "Vous ne pouvez pas créer un évènement dans un groupe auquel nous n'appartenez pas", "OK");
            }
            else
            {
                await Navigation.PushAsync(new PageFormCreationEvent(groupe));

            }
        }
    }
}