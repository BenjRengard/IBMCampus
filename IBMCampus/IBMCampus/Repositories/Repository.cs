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

        #region Exemple pour utiliser les api

        /*
         * 
         * EXEMPLE POUR CONSOMMER UNE API
         * 
         * 
         * 
         *  //public async void MaMethodeBidon()
         *  //{
         *  //    var url = "https://ceciestuneapibidon/recupdedonnes";
         *  //    var retourApi = await _client.GetStringAsync(url);
         *  //    var result = JsonConvert.DeserializeObject<ObjetDRresultat>(retourApi);
         *  
         *        
         *  //}
         *  
         *  
         *  SI c'est une liste 
         *  //public async void MaMethodeBidon()
         *  //{
         *  //    var url = "https://ceciestuneapibidon/recupdedonnes";
         *  //    var retourApi = await _client.GetStringAsync(url);
         *  //    var result = JsonConvert.DeserializeObject<List<ObjetDRresultat>>(retourApi);
         *  
         *        var _result = new ObservableCollection<ObjetDResultat>(result);
         *  //}
         *  
         * 
         */



        /*
         * 
         *EXEMPLE POUR ENVOYER DANS L'API 
         * 
         * 
         * 
         * public async void MaMethodePostBidon()
         * {
         *      var url = "https://ceciestuneapibidon/recupdedonnes";
         *      var ObjetAEnvoyer = **MON OBJET RECUPERE OU CREEE **
         *      
         *      var content = JsonConvert.SerilizeObject(ObjetAEnvoyer);
         *      await _client.PostAsync(url, new StringContent(content));
         *      
         *      //ENREGISTRER L'OBJET DANS L'APPLI
         * }
         * 
         * 
         */

        /*
         * 
         *EXEMPLE POUR FAIRE UNE MAJ DE DONNEES DE LA BDD
         * 
         * 
         * 
         * public async void MaMethodePostBidon()
         * {
         *      var url = "https://ceciestuneapibidon/recupdedonnes";
         *      var ObjetAMaj = **MON OBJET RECUPERE OU ACTUEL **
         *      
         *      var content = JsonConvert.SerilizeObject(ObjetAMaj);
         *      await _client.PutAsync(url + "/" + ObjetAMaj.id, new StringContent(content));
         *     
         *     //METTRE A JOUR L'OBJET DANS L'APPLI
         * }
         * 
         * 
         */

        /*
        * 
        *EXEMPLE POUR FAIRE LA SUPPRESSION 
        * 
        * 
        * 
        * public async void MaMethodePostBidon()
        * {
        *      var url = "https://ceciestuneapibidon/recupdedonnes";
        *      var ObjetASupp = **MON OBJET RECUPERE OU ACTUEL **
        *      
        *      await _client.DeleteAsync(url + "/" + ObjetAMaj.id);
        *      
        *      //REMOVE L'OBJET DANS L'APPLI
        * }
        * 
        * 
        */

        #endregion

        /// <summary>
        /// Méthode pour récupérer les groupes de l'utilisateur
        /// </summary>
        /// <param name="user">Utilisateur</param>
        /// <returns>Liste en observablecollection de groupes models</returns>
        public ObservableCollection<GroupeModel> RecupererGroupesUtilisateur(UtilisateurModel user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour récupérer tous les groupes à afficher (on ne gèrera pas la limitation pour le moment)
        /// </summary>
        /// <returns>Liste en observablecollection de groupemodel</returns>
        public ObservableCollection<GroupeModel> RecupererTousLesGroupes()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour récupérer tous les chauffeurs inscrits.
        /// </summary>
        /// <returns>Liste en observablecollection de chauffeurmodel.</returns>
        public ObservableCollection<ChauffeurModel> RecupererTousChauffeurs()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour récupérer tous les évènements à afficher (on ne gèrera pas la limitation pour le moment).
        /// </summary>
        /// <returns>Liste en observablecollection d'evenementmodel.</returns>
        public ObservableCollection<EvenementsModel> RecupererTousLesEvents()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour récupérer tous les évènements d'un utilisateur (on ne gèrera pas la limitation pour le moment).
        /// </summary>
        /// <param name="user">Utilisateur</param>
        /// <returns>Liste en observablecollection d'evenementmodel. A ranger si possible du plus récent au plus ancien.</returns>
        public ObservableCollection<EvenementsModel> RecupererEvenementUtilisateur(UtilisateurModel user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour récupérer tous les évènements d'un groupe (on ne gèrera pas la limitation pour le moment).
        /// </summary>
        /// <param name="groupe">Groupe dont on veut récupérer les évènements.</param>
        /// <returns>Liste en observablecollection d'evenementmodel. A ranger si possible du plus récent au plus ancien.</returns>
        public ObservableCollection<EvenementsModel> RecupererEvenementGroupe(GroupeModel groupe)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour récupérer tous les utilisateurs d'un groupe.
        /// </summary>
        /// <param name="groupe">Groupe dont on veut récupérer les utilisateurs.</param>
        /// <returns>Liste en observablecollection d'utilisateurmodel.</returns>
        public ObservableCollection<UtilisateurModel> RecupererUtilisateursGroupe(GroupeModel groupe)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour récupérer les infos d'un user.
        /// </summary>
        /// <param name="id">Id du user</param>
        /// <returns>Utilisateur model</returns>
        public UtilisateurModel RecupererInfosUtilisateur(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour récupérer les infos du groupe.
        /// </summary>
        /// <param name="id">Id du groupe</param>
        /// <returns></returns>
        public GroupeModel RecupererInfosGroupe(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour récupérer les infos d'un évènement.
        /// </summary>
        /// <param name="id">Id de l'évènement</param>
        /// <returns></returns>
        public EvenementsModel RecupererInfosEnvement(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour lister les id des utilisateurs.
        /// </summary>
        /// <returns></returns>
        public List<int> ListerIdUtilisateur()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour lister les id des groupes.
        /// </summary>
        /// <returns></returns>
        public List<int> ListerIdGroupe()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode pour lister les id des évènements.
        /// </summary>
        /// <returns></returns>
        public List<int> ListerIdEvenement()
        {
            throw new NotImplementedException();
        }



    }
}
