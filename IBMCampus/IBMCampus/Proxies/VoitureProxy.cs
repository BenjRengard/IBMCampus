using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{
    /// <summary>
    /// Proxy table EvenementTrajetCovoiturage
    /// </summary>
    class VoitureProxy
    {
        /// <summary>
        /// Identifiant voiture
        /// </summary>
        public int etc_id { get; set; }

        /// <summary>
        /// Identifiant itinairaire
        /// </summary>
        public int etc_gtc_id { get; set; }

        /// <summary>
        /// Date départ
        /// </summary>
        public DateTime date_depart { get; set; }

        /// <summary>
        /// Date arrivee
        /// </summary>
        public DateTime date_arrivee { get; set; }

        /// <summary>
        /// Nombre de place
        /// </summary>
        public int etc_nbr_max { get; set; }

        /// <summary>
        /// Fin de sinscription
        /// </summary>
        public DateTime etc_date_cloture_inscription { get; set; }

        public VoitureProxy()
        {

        }

    }
}
