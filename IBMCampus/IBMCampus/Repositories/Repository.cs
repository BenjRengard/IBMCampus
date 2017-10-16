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
        

        //public async void MaMethodeBidon()
        //{
        //    var url = "https://ceciestuneapibidon/recupdedonnes";
        //    var retourApi = await _client.GetStringAsync(url);
        //    var result = JsonConvert.DeserializeObject<ObjetDRresultat>(retourApi);
        //}

        */
    }
}
