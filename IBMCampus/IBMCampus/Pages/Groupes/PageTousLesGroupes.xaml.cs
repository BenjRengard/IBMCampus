﻿using System;
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

        public PageTousLesGroupes ()
		{
			InitializeComponent ();
            Load();
		}

        /// <summary>
        /// Constrcuteur obsolète
        /// </summary>
        /// <param name="repo"></param>
        public PageTousLesGroupes(FakeRepository repo)
        {
            InitializeComponent();

            liste.ItemsSource = repo.RecupererTousLesGroupes();
        }

        private async void liste_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            if (liste.SelectedItem == null)
            {
                return;
            }
            var groupe = e.SelectedItem as GroupeModel;
            await Navigation.PushAsync(new PageDetailGroupe(groupe));
            liste.SelectedItem = null;
        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FormCreationGroupe());
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
            liste.ItemsSource = repo.RecupererTousLesGroupes();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Load();
        }
    }
}