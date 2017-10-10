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
            //var liste = new ListView(ListViewCachingStrategy.RecycleElement);
            var repo = new FakeGroupes();
            var groupes = new ObservableCollection<string>() { "Groupe1", "Groupe2" };

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
    }
}