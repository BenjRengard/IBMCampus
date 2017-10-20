namespace IBMCampus
{
    /// <summary>
    /// Proxy de la table GroupeSport
    /// </summary>
    public class GroupeProxy
    {
        /// <summary>
        /// Identifiant groupe de sport
        /// </summary>
        public int gs_Id { get; set; }

        /// <summary>
        /// Identifiant sport
        /// </summary>
        public int gs_Id_Sport { get; set; }

        /// <summary>
        /// Nombre maximum de membre
        /// </summary>
        public int gs_Nbr_Membre_Max { get; set; }

        /// <summary>
        /// Nombre de membre actuel
        /// </summary>
        public int gs_Nbr_Membre_Actuel { get; set; }

        /// <summary>
        /// Jour sport
        /// </summary>
        public string gs_Jour_Prefere { get; set; }

        /// <summary>
        /// Nom du groupe
        /// </summary>
        public string gs_Nom { get; set; }

        public GroupeProxy()
        {


        }
    }
}