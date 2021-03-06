﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IBMCampus
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Connexion : ContentPage
    {
        private const string UrlInsert = "http://mooguer.fr/inscription.php?";
        private const string UrlControle = "http://mooguer.fr/VerifUserUnique.php?";
        private HttpClient _client = new HttpClient();
        private UtilisateurModel _utilisateur;
        private bool BoutonClique = false;
        Repository repo = App.Current.BindingContext as Repository;


        //private string url = "http:/9.129.126.182/api/Profil";
        //private HttpClient _client = new HttpClient();
        public Connexion()
        {
            InitializeComponent();
            BoutonClique = false;
            EmailUtilisateur.Text = @"batman@batman.com";
            MotDePasse.Text = "123bat";

        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    try
        //    {
        //        var retour = await _client.GetStringAsync(url);
        //        var result = JsonConvert.DeserializeObject<string>(retour);
        //        EmailUtilisateur.Text = result;
        //    }
        //    catch (Exception)
        //    {

        //        EmailUtilisateur.Text = @"fonctionne pas";
        //    }

        //}

        private async void Button_Connexion(object sender, EventArgs e)
        {
            if (BoutonClique)
            {
                await DisplayAlert("Patience", "Veuillez patienter le temps du chargement", "OK");
            }
            else
            {

                BoutonClique = true;

                try
                {
                    var utilisateur = await repo.ConnexionApplication(EmailUtilisateur.Text, MotDePasse.Text);

                    if (repo.MessageErreur != null)
                    {
                        await DisplayAlert("Problème de connexion", repo.MessageErreur, "Réessayer");
                        BoutonClique = false;
                    }
                    else
                    {
                        repo.User = utilisateur;
                        if (repo.User.GroupesUtilisateur == null)
                        {
                            repo.User.GroupesUtilisateur = new ObservableCollection<GroupeModel>();
                        }
                        if (string.IsNullOrWhiteSpace(repo.User.AdresseUtilisateur))
                        {
                            repo.User.AdresseUtilisateur = "A modifier";
                        }
                        await Navigation.PushModalAsync(new MasterDetailPage1());
                        BoutonClique = false;
                    }

                    #region Ancien code commenté
                    //var controle = await _client.GetStringAsync(UrlControle + "mail=" + '"' + EmailUtilisateur.Text + '"');
                    //var user = JsonConvert.DeserializeObject<ObservableCollection<UtilisateurModel>>(controle);

                    //if (user.Count > 0)
                    //{
                    //    _utilisateur = user.First();
                    //}

                    //if (_utilisateur != null)
                    //{
                    //    if (MotDePasse.Text == _utilisateur.MotDePasseUtilisateur)
                    //    {

                    //        repo.User.NomUtilisateur = _utilisateur.NomUtilisateur;
                    //        repo.User.PrenomUtilisateur = _utilisateur.PrenomUtilisateur;
                    //        repo.User.EMailUtilisateur = _utilisateur.EMailUtilisateur;
                    //        repo.User.TelephoneUtilisateur = _utilisateur.TelephoneUtilisateur;
                    //        repo.User.AdresseUtilisateur = _utilisateur.AdresseUtilisateur;
                    //        repo.User.Vehicule = _utilisateur.Vehicule ;



                    //        await Navigation.PushModalAsync(new MasterDetailPage1());
                    //    }
                    //    else
                    //    {
                    //        await DisplayAlert("Problème de connexion", "Le user ou le mot de passe est incorrect", "Réessayer");
                    //    }
                    //}
                    //    else
                    //    {
                    //        await DisplayAlert("Problème de connexion", "Le user ou le mot de passe est incorrect", "Réessayer");
                    //    }
                    #endregion
                    //else
                    //{
                    //    App.Current.BindingContext = repo;
                    //    await Navigation.PushModalAsync(new MasterDetailPage1());

                    //}


                }
                catch (Exception ex)
                {

                    await DisplayAlert("Problème de connexion", ex.ToString(), "Réessayer");
                    BoutonClique = false;

                }

            }

        }



        //Fin de mon code

        //var repo = App.Current.BindingContext as FakeRepository;

        //    var utilisateur = repo.UtilisateursEnregistres.FirstOrDefault(u => u.EMailUtilisateur == EmailUtilisateur.Text);
        //    if (utilisateur == null)
        //    {
        //        await DisplayAlert("Problème de connexion", "Le user est incorrect", "Réessayer");

        //    }

        //    if (MotDePasse.Text == (utilisateur.MotDePasseUtilisateur))
        //    {
        //        repo.User = utilisateur;
        //        await Navigation.PushModalAsync(new MasterDetailPage1());


        //    }
        //    else
        //    {
        //        await DisplayAlert("Problème de connexion", "Le user ou le mot de passe est incorrect", "Réessayer");

        //    }


        //}

        private async void Button_Inscription(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Inscription());
        }
    }
}