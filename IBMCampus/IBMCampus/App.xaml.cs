//using IBMCampus.FakeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace IBMCampus
{
    public partial class App : Application
    {

        //public FakeRepository Repo = new FakeRepository();
        public Repository Data = new Repository();


        public App()
        {
            InitializeComponent();
             
            
            BindingContext = Data;

            MainPage = new NavigationPage(new Connexion());
            //MainPage = new PageUtilisateurTest();

            //MainPage = new MasterDetailPage1();
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
