using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace IBMCampus.Repositories
{
    public class Repository
    {
        private HttpClient _client = new HttpClient();

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



       

    }
}
