using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{
    /// <summary>
    /// Proxy table GroupeTrajetCovoiturage
    /// </summary>
    class ItinairaireProxy
    {
        /// <summary>
        /// identifiant itinairaire
        /// </summary>
        public int gtc_id { get; set; }

        /// <summary>
        /// Lieu de départ (bureau)
        /// </summary>
        public string gtc_lieu_depart { get; set; }

        /// <summary>
        /// Lieu d'arrivee (adresse sport)
        /// </summary>
        public string gtc_lieu_arrivee { get; set; }


        public ItinairaireProxy()
        {


        }
    }
}
