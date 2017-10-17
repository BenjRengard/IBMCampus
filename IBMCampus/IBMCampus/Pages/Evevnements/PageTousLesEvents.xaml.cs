using IBMCampus.Pages;
using IBMCampus.Pages.Evevnements;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageTousLesEvents : ContentPage
    {

        EvenementsModel events = new EvenementsModel();

        public PageTousLesEvents()
        {
            InitializeComponent();
            Load();

        }
        /// <summary>
        /// Constrcuteur obsolète
        /// </summary>
        /// <param name="repo"></param>
        public PageTousLesEvents(FakeRepository repo)
        {
            InitializeComponent();

            liste.ItemsSource = repo.RecupererTousLesEvents();
        }

        private async void liste_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (liste.SelectedItem == null)
            {
                return;
            }
            var events = e.SelectedItem as EvenementsModel;
            await Navigation.PushAsync(new PageDetailEvent(events));
            liste.SelectedItem = null;
        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FormCreationEvent());
        }

        private void liste_Refreshing(object sender, EventArgs e)
        {
            Load();
            liste.EndRefresh();
        }

        public void Load()
        {
            var repo = App.Current.BindingContext as FakeRepository;

            liste.ItemsSource = null;
            liste.ItemsSource = repo.RecupererTousLesEvents();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Load();
        }
    }
}