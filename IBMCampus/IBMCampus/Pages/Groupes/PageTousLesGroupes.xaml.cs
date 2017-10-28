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
	public partial class PageTousLesGroupes : ContentPage
	{
        #region Fields de la page

        Repository repo = App.Current.BindingContext as Repository;
        #endregion

        #region Constructeurs de la page

        public PageTousLesGroupes ()
		{
			InitializeComponent ();
		}
        #endregion

        #region Méthodes d'action

        private async void liste_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            if (liste.SelectedItem == null)
            {
                return;
            }
            var groupe = e.SelectedItem as GroupeModel;
            await Navigation.PushAsync(new TabbedPageDetailCompletGroupe(groupe));
            liste.SelectedItem = null;
        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FormCreationGroupe());
        }

        private async void liste_Refreshing(object sender, EventArgs e)
        {
            await Load();
            liste.EndRefresh();
        }

        #endregion

        #region Méthodes de chargement

        public async Task Load()
        {
            
            //liste.ItemsSource = null;
            liste.ItemsSource = await repo.RecupererAllGroupes();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            liste.IsRefreshing = true;
            await Load();
            liste.IsRefreshing = false;
        }
        #endregion
    }
}