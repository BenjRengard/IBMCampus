using System;

namespace IBMCampus
{
    /// <summary>
    /// Proxy de la table EvenementSport
    /// </summary>
    public class EvenementProxy
    {
        /// <summary>
        /// identifiant evenement
        /// </summary>
        public int es_Id { get; set; }

        /// <summary>
        /// Identifiant groupe de sport
        /// </summary>
        public int es_gs_Id { get; set; }

        /// <summary>
        /// heure début
        /// </summary>
        public DateTime es_Date_Debut { get; set; }

        /// <summary>
        /// Heure fin
        /// </summary>
        public DateTime es_Date_Fin { get; set; }

        /// <summary>
        /// Nombre minimum de participant
        /// </summary>
        public int es_Nombre_Participants_Min { get; set; }

        /// <summary>
        /// Nombre maximum de participant
        /// </summary>
        public int es_Nombre_Particiants_Max { get; set; }

        public EvenementProxy()
        {


        }
    }

}
