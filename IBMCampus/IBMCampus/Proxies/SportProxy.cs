using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{
    /// <summary>
    /// Proxy table sports
    /// </summary>
    class SportProxy
    {
        /// <summary>
        /// Identifiant sport
        /// </summary>
        public int sp_id { get; set; }

        /// <summary>
        /// Nom du sport
        /// </summary>
        public string sp_nom_sport { get; set; }

        /// <summary>
        /// Adresse
        /// </summary>
        public string localisation { get; set; }

        /// <summary>
        /// Description du sport
        /// </summary>
        public string sp_description { get; set; }

        public SportProxy()
        {


        }
    }
}
