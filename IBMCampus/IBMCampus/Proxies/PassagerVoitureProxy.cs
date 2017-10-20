using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{
    /// <summary>
    /// Proxy table InscriptionGroupeCoivoiturage
    /// </summary>
    class PassagerVoitureProxy
    {
        /// <summary>
        /// Identifiant inscription
        /// </summary>
        public int igc_id { get; set; }

        /// <summary>
        /// Identifiant passager
        /// </summary>
        public int igc_user_id { get; set; }

        /// <summary>
        /// Identifiant itinairaire
        /// </summary>
        public int igc_gtc_id { get; set; }

    }
}
