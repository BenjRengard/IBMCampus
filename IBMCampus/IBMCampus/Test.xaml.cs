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
	public partial class Test : ContentPage
	{
		public Test ()
		{
			InitializeComponent ();
            //var liste = new ListView(ListViewCachingStrategy.RecycleElement);
            var repo = new FakeGroupes();
            var groupes = new ObservableCollection<string>() { "Groupe1", "Groupe2" };
            liste.ItemsSource = repo.Donnees();

		}
	}
}