using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{
    /// <summary>
    /// Proxy table InscriptionEventSport
    /// </summary>
    class EvenementUtilisateur
    {
        /// <summary>
        /// Identifiant evenement de l'utilisateur
        /// </summary>
        public int ies_id { get; set; }

        /// <summary>
        /// Identifiant utilisateur
        /// </summary>
        public int ies_user_id { get; set; }
        
        /// <summary>
        /// Identifiant evenement sport
        /// </summary>
        public int ies_es_id { get; set; }


        public EvenementUtilisateur()
        {

        }
    }
}
