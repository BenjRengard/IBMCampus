using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{
    /// <summary>
    /// Proxy table InscriptionEventCovoiturage
    /// </summary>
    class ListeChauffeursProxy
    {
        /// <summary>
        /// Identifiant chauffeur
        /// </summary>
        public int iec_id { get; set; }

        /// <summary>
        /// Identifiant utilisateur
        /// </summary>
        public int iec_user_id { get; set; }

        /// <summary>
        /// Identifiant itinairaire
        /// </summary>
        public int iec_etc_id { get; set; }

        public ListeChauffeursProxy()
        {


        }
    }
}
