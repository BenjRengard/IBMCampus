﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{
    /// <summary>
    /// Proxy table InscriptionGroupeSprot
    /// </summary>
    public class ListeGroupeUtilisateurProxy
    {
        /// <summary>
        /// identifiant inscription groupe
        /// </summary>
        public int igs_id { get; set; }

        /// <summary>
        /// Identifiant utilisateur inscrit
        /// </summary>
        public int igs_user_id { get; set; }

        /// <summary>
        /// identifiant du groupe de sport
        /// </summary>
        public int igs_gs_id { get; set; }

        public ListeGroupeUtilisateurProxy()
        {


        }
    }
}
