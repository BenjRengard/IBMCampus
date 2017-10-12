﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace IBMCampus
{
    public partial class App : Application
    {

        public FakeGroupes Repo = new FakeGroupes();

        public App()
        {
            InitializeComponent();
             
            
            BindingContext = Repo;

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
