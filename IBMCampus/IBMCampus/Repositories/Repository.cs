using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace IBMCampus
{
    /// <summary>
    /// Repository de la totalité de l'application. Possède des méthodes pour récupérer les informations des api et les objets de session pour l'application.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// Client pour utilisation des api.
        /// </summary>
        private HttpClient _client = new HttpClient();

        /// <summary>
        /// Utilisateur enregistré dans l'application après la connexion.
        /// </summary>
        public UtilisateurModel User = new UtilisateurModel();

        public string MessageErreur { get; set; }

        #region Repository de l'ancienne API



        //#region Exemple pour utiliser les api

        ///*
        // * 
        // * EXEMPLE POUR CONSOMMER UNE API
        // * 
        // * 
        // * 
        // *  //public async void MaMethodeBidon()
        // *  //{
        // *  //    var url = "https://ceciestuneapibidon/recupdedonnes";
        // *  //    var retourApi = await _client.GetStringAsync(url);
        // *  //    var result = JsonConvert.DeserializeObject<ObjetDRresultat>(retourApi);
        // *  
        // *        
        // *  //}
        // *  
        // *  
        // *  SI c'est une liste 
        // *  //public async void MaMethodeBidon()
        // *  //{
        // *  //    var url = "https://ceciestuneapibidon/recupdedonnes";
        // *  //    var retourApi = await _client.GetStringAsync(url);
        // *  //    var result = JsonConvert.DeserializeObject<List<ObjetDRresultat>>(retourApi);
        // *  
        // *        var _result = new ObservableCollection<ObjetDResultat>(result);
        // *  //}
        // *  
        // * 
        // */



        ///*
        // * 
        // *EXEMPLE POUR ENVOYER DANS L'API 
        // * 
        // * 
        // * 
        // * public async void MaMethodePostBidon()
        // * {
        // *      var url = "https://ceciestuneapibidon/recupdedonnes";
        // *      var ObjetAEnvoyer = **MON OBJET RECUPERE OU CREEE **
        // *      
        // *      var content = JsonConvert.SerilizeObject(ObjetAEnvoyer);
        // *      await _client.PostAsync(url, new StringContent(content));
        // *      
        // *      //ENREGISTRER L'OBJET DANS L'APPLI
        // * }
        // * 
        // * 
        // */

        ///*
        // * 
        // *EXEMPLE POUR FAIRE UNE MAJ DE DONNEES DE LA BDD
        // * 
        // * 
        // * 
        // * public async void MaMethodePostBidon()
        // * {
        // *      var url = "https://ceciestuneapibidon/recupdedonnes";
        // *      var ObjetAMaj = **MON OBJET RECUPERE OU ACTUEL **
        // *      
        // *      var content = JsonConvert.SerilizeObject(ObjetAMaj);
        // *      await _client.PutAsync(url + "/" + ObjetAMaj.id, new StringContent(content));
        // *     
        // *     //METTRE A JOUR L'OBJET DANS L'APPLI
        // * }
        // * 
        // * 
        // */

        ///*
        //* 
        //*EXEMPLE POUR FAIRE LA SUPPRESSION 
        //* 
        //* 
        //* 
        //* public async void MaMethodePostBidon()
        //* {
        //*      var url = "https://ceciestuneapibidon/recupdedonnes";
        //*      var ObjetASupp = **MON OBJET RECUPERE OU ACTUEL **
        //*      
        //*      await _client.DeleteAsync(url + "/" + ObjetAMaj.id);
        //*      
        //*      //REMOVE L'OBJET DANS L'APPLI
        //* }
        //* 
        //* 
        //*/

        //#endregion


        //#region Méthodes pour récupérer les id

        ///// <summary>
        ///// Méthode pour lister les id des évènements.
        ///// </summary>
        ///// <returns></returns>
        //public async Task<List<int>> ListerTousLesIdEvenement()
        //{
        //    try
        //    {
        //        var Url = "http://mooguer.fr/SelectIdEvent.php";
        //        var json = await _client.GetStringAsync(Url);
        //        var resultatApi = JsonConvert.DeserializeObject<List<EvenementProxy>>(json);
        //        //ListeId = idUser;
        //        var idEvent = new List<int>();
        //        foreach (var evenement in resultatApi)
        //        {
        //            idEvent.Add(Convert.ToInt32(evenement.es_Id));
        //        }
        //        return idEvent;
        //    }
        //    catch (Exception)
        //    {
        //        MessageErreur = "Problème lors de la récupération des données.";
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// Méthode pour lister les id des groupes.
        ///// </summary>
        ///// <returns></returns>
        //public async Task<ObservableCollection<int>> ListerTousLesIdGroupe()
        //{
        //    try
        //    {
        //        var Url = "http://mooguer.fr/SelectIdGroupeSport.php";
        //        var json = await _client.GetStringAsync(Url);
        //        var resultatApi = JsonConvert.DeserializeObject<List<GroupeProxy>>(json);
        //        var listeIdGroupeSport = new ObservableCollection<int>();
        //        foreach (var id in resultatApi)
        //        {
        //            listeIdGroupeSport.Add(id.gs_Id);
        //        }
        //        return listeIdGroupeSport;
        //    }
        //    catch (Exception)
        //    {
        //        MessageErreur = "Problème lors de la récupération des données.";
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// Méthode pour lister les id des utilisateurs.
        ///// </summary>
        ///// <returns></returns>
        //public async Task<ObservableCollection<int>> ListerTousLesIdUtilisateur()
        //{
        //    try
        //    {
        //        var Url = "http://mooguer.fr/SelectIdUser.php";
        //        var json = await _client.GetStringAsync(Url);
        //        var resultatApi = JsonConvert.DeserializeObject<List<UtilisateurProxy>>(json);
        //        //ListeId = idUser;
        //        var idUsers = new ObservableCollection<int>();
        //        foreach (var user in resultatApi)
        //        {
        //            idUsers.Add(Convert.ToInt32(user.usr_Id));
        //        }
        //        return idUsers;
        //    }
        //    catch (Exception)
        //    {
        //        MessageErreur = "Problème lors de la récupération des données.";
        //        return null;
        //    }

        //}

        /////// <summary>
        /////// Méthode pour récupérer les id des utilisateurs d'un groupe.
        /////// </summary>
        /////// <param name="groupe"></param>
        /////// <returns></returns>
        ////public async Task<ObservableCollection<int>> ListerIdUtilisateursGroupe(GroupeModel groupe)
        ////{

        ////    throw new NotImplementedException();
        ////}


        /////// <summary>
        /////// Méthode pour récupérer les id des évènements d'un groupe.
        /////// </summary>
        /////// <param name="groupe"></param>
        /////// <returns></returns>
        ////public async Task<ObservableCollection<int>> ListerIdEvenementGroupe(GroupeModel groupe)
        ////{
        ////    throw new NotImplementedException();

        ////}

        ///// <summary>
        ///// Méthode pour récupérer les id des groupes d'un utilisateur.
        ///// </summary>
        ///// <param name="user"></param>
        ///// <returns></returns>
        //public async Task<ObservableCollection<ListeGroupeUtilisateurProxy>> ListerIdGroupesUtilisateur(UtilisateurModel user)
        //{
        //    try
        //    {
        //        var Url = "http://mooguer.fr/SelectGroupeUser.php?";
        //        var json = await _client.GetStringAsync(Url + "id=" + user.IdUtilisateur);
        //        var resultatApi = JsonConvert.DeserializeObject<List<ListeGroupeUtilisateurProxy>>(json);
        //        //ListeId = idUser;
        //        var GroupeUser = new ObservableCollection<ListeGroupeUtilisateurProxy>();

        //        if (resultatApi.Count > 0)
        //        {
        //            foreach (var groupe in resultatApi)
        //            {
        //                GroupeUser.Add(groupe);
        //            }
        //            return GroupeUser;

        //        }
        //        else
        //        {
        //            MessageErreur = "Vous n'avez pas de groupe.";
        //            return null;

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageErreur = "Problème lors de la récupération des données.";
        //        return null;
        //    }


        //}



        ///// <summary>
        ///// Méthode pour récupérer les id des évènements d'un utilisateur.
        ///// </summary>
        ///// <param name="user"></param>
        ///// <returns></returns>
        //public async Task<ObservableCollection<int>> ListerIdEvenementUtilisateur(UtilisateurModel user)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion


        //#region Méthodes pour convertir les id en Objets


        ///// <summary>
        ///// Méthode pour récupérer les infos d'un user.
        ///// </summary>
        ///// <param name="id">Id du user</param>
        ///// <returns>Utilisateur model</returns>
        //public async Task<UtilisateurModel> RecupererUniqueUtilisateur(int id)
        //{
        //    UtilisateurProxy utilisateurEnBase = await RechercheUtilisateurParId(id);

        //    return Convertisseur.ConvertirUtilisateurProxyEnModel(utilisateurEnBase);
        //}



        ///// <summary>
        ///// Méthode pour récupérer les infos du groupe.
        ///// </summary>
        ///// <param name="id">Id du groupe</param>
        ///// <returns></returns>
        //public async Task<GroupeModel> RecupererUniqueGroupe(int id)
        //{
        //    GroupeProxy groupeEnBase = await RechercheGroupeParId(id);

        //    return Convertisseur.ConvertirGroupeProxyEnModel(groupeEnBase);

        //}


        ///// <summary>
        ///// Méthode pour récupérer les infos d'un évènement.
        ///// </summary>
        ///// <param name="id">Id de l'évènement</param>
        ///// <returns></returns>
        //public async Task<EvenementsModel> RecupererUniqueEnvement(int id)
        //{
        //    EvenementProxy evenementEnBase = await RechercheEvenementParId(id);

        //    return Convertisseur.ConvertirEvenementProxyEnModel(evenementEnBase);
        //}



        //#endregion


        //#region Méthodes pour retourner des listes d'objets

        ///// <summary>
        ///// Méthode pour récupérer les groupes de l'utilisateur
        ///// </summary>
        ///// <param name="user">Utilisateur</param>
        ///// <returns>Liste en observablecollection de groupes models</returns>
        //public async Task<ObservableCollection<GroupeModel>> RecupererGroupesUtilisateur(UtilisateurModel user)
        //{
        //    try
        //    {
        //        var Url = "http://mooguer.fr/SelectGroupeUser.php?";
        //        var json = await _client.GetStringAsync(Url + "id=" + user.IdUtilisateur);
        //        var resultatApi = JsonConvert.DeserializeObject<List<ListeGroupeUtilisateurProxy>>(json);
        //        //ListeId = idUser;
        //        var GroupeUser = new ObservableCollection<GroupeModel>();

        //        if (resultatApi.Count > 0)
        //        {
        //            foreach (var idgroupe in resultatApi)
        //            {
        //                var groupe = RecupererUniqueGroupe(idgroupe.igs_gs_id);
        //                var model = Convertisseur.ConvertirGroupeProxyEnModel(groupe);
        //                model.UtilisateursDuGroupe = await RecupererUtilisateursGroupe(model);
        //                GroupeUser.Add(model);
        //            }
        //            return GroupeUser;

        //        }
        //        else
        //        {
        //            MessageErreur = "Vous n'avez pas de groupe.";
        //            return null;

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageErreur = "Problème lors de la récupération des données.";
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// Méthode pour récupérer tous les groupes à afficher (on ne gèrera pas la limitation pour le moment)
        ///// </summary>
        ///// <returns>Liste en observablecollection de groupemodel</returns>
        //public async Task<ObservableCollection<GroupeModel>> RecupererTousLesGroupes()
        //{
        //    // Instanciation de la liste à retourner.
        //    var listeARetourner = new ObservableCollection<GroupeModel>();

        //    //Récupération de tous les id.
        //    var listeId = await ListerTousLesIdGroupe();

        //    //Pour chacun des id de la liste, rechercher l'objet en base, et le reformater en Model.
        //    foreach (var id in listeId)
        //    {
        //        //Ajouter à la liste à retourner.
        //        listeARetourner.Add(await RecupererUniqueGroupe(id));
        //    }

        //    return listeARetourner;
        //}

        ///// <summary>
        ///// Méthode pour récupérer tout les utilisateurs en base.
        ///// </summary>
        ///// <returns></returns>
        //public ObservableCollection<UtilisateurModel> RecupererTousLesUtilisateurs()
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Méthode pour récupérer tous les chauffeurs inscrits.
        ///// </summary>
        ///// <returns>Liste en observablecollection de chauffeurmodel.</returns>
        //public ObservableCollection<ChauffeurModel> RecupererTousChauffeurs()
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Méthode pour récupérer tous les évènements à afficher (on ne gèrera pas la limitation pour le moment).
        ///// </summary>
        ///// <returns>Liste en observablecollection d'evenementmodel.</returns>
        //public ObservableCollection<EvenementsModel> RecupererTousLesEvents()
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Méthode pour récupérer tous les évènements d'un utilisateur (on ne gèrera pas la limitation pour le moment).
        ///// </summary>
        ///// <param name="user">Utilisateur</param>
        ///// <returns>Liste en observablecollection d'evenementmodel. A ranger si possible du plus récent au plus ancien.</returns>
        //public ObservableCollection<EvenementsModel> RecupererEvenementUtilisateur(UtilisateurModel user)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Méthode pour récupérer tous les évènements d'un groupe (on ne gèrera pas la limitation pour le moment).
        ///// </summary>
        ///// <param name="groupe">Groupe dont on veut récupérer les évènements.</param>
        ///// <returns>Liste en observablecollection d'evenementmodel. A ranger si possible du plus récent au plus ancien.</returns>
        //public ObservableCollection<EvenementsModel> RecupererEvenementGroupe(GroupeModel groupe)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Méthode pour récupérer tous les utilisateurs d'un groupe.
        ///// </summary>
        ///// <param name="groupe">Groupe dont on veut récupérer les utilisateurs.</param>
        ///// <returns>Liste en observablecollection d'utilisateurmodel.</returns>
        //public async Task<ObservableCollection<UtilisateurModel>> RecupererUtilisateursGroupe(GroupeModel groupe)
        //{
        //    var result = new ObservableCollection<UtilisateurModel>();
        //    try
        //    {
        //        var Url = "A modifier";
        //        var json = await _client.GetStringAsync(Url + "id=" + groupe.IdGroupe);
        //        var resultatApi = JsonConvert.DeserializeObject<ObservableCollection<UtilisateurProxy>>(json);
        //        if (resultatApi.Count >0)
        //        {
        //            foreach (var user in resultatApi)
        //            {
        //                var model = Convertisseur.ConvertirUtilisateurProxyEnModel(user);
        //                //var model = new UtilisateurModel();
        //                result.Add(model);
        //            }
        //        }
        //        else
        //        {
        //            MessageErreur = "Aucun utilisateur";
        //            result.Add(new UtilisateurModel());
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        MessageErreur = "Problème lors de la récupération des données Utilisateur.";
        //        result.Add(new UtilisateurModel());
        //    }
        //    return result;
        //}

        //#endregion


        //#region Rechercher un objet par id

        ///// <summary>
        ///// Méthode pour rechercher un groupe via son id.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<GroupeProxy> RechercheGroupeParId(int id)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Méthode pour rechercher un évènement via son id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<EvenementProxy> RechercheEvenementParId(int id)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Méthode pour rechercher un utilisateur via son id.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<UtilisateurProxy> RechercheUtilisateurParId(int id)
        //{
        //    try
        //    {
        //        var Url = "http://mooguer.fr/SelectUserUnique.php?";
        //        var json = await _client.GetStringAsync(Url + "id=" + id);
        //        var resultatApi = JsonConvert.DeserializeObject<List<UtilisateurProxy>>(json);
        //        var user = new UtilisateurProxy();

        //        user = resultatApi.First();
        //        return user;
        //        //if (resultatApi != null)
        //        //{
        //        //    user = resultatApi;
        //        //    return GroupeUser;

        //        //}
        //        //else
        //        //{
        //        //    MessageErreur = "Vous n'avez pas de groupe.";
        //        //    return null;

        //        //}
        //    }
        //    catch (Exception)
        //    {
        //        MessageErreur = "Problème lors de la récupération des données.";
        //        return null;
        //    }


        //}
        //#endregion


        //#region Méthodes de création

        ////public async void CreationGroupe()
        ////{

        ////}

        ////public async void CreationEvenement()
        ////{

        ////}

        //#endregion

        #endregion

        public async void ConnexionApplication(string email, string motDePasse)
        {
            var _utilisateur = new UtilisateurModel();
            string UrlControle = "http://mooguer.fr/VerifUserUnique.php?";

            var controle = await _client.GetStringAsync(UrlControle + "mail=" + '"' + email + '"');
            var user = JsonConvert.DeserializeObject<ObservableCollection<UtilisateurModel>>(controle);

            if (user.Count > 0)
            {
                _utilisateur = user.First();
            }

            if (_utilisateur != null)
            {
                if (motDePasse == _utilisateur.MotDePasseUtilisateur)
                {

                    this.User.NomUtilisateur = _utilisateur.NomUtilisateur;
                    this.User.PrenomUtilisateur = _utilisateur.PrenomUtilisateur;
                    this.User.EMailUtilisateur = _utilisateur.EMailUtilisateur;
                    this.User.TelephoneUtilisateur = _utilisateur.TelephoneUtilisateur;
                    this.User.AdresseUtilisateur = _utilisateur.AdresseUtilisateur;
                    this.User.Vehicule = _utilisateur.Vehicule;
                    MessageErreur = null;

                    //return _utilisateur;
                }
                else
                {
                    MessageErreur = "Le user ou le mot de passe est incorrect.";
                }
            }
            else
            {
                MessageErreur = "Le user ou le mot de passe est incorrect.";
            }




        }

