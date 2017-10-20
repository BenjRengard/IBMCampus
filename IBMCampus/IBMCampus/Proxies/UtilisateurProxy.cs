using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{
    /// <summary>
    /// Proxy table utilisateur
    /// </summary>
    public class UtilisateurProxy
    {
        /// <summary>
        /// Identifiant utilisateur
        /// </summary>
        public int usr_Id { get; set; }

        /// <summary>
        /// Prenom
        /// </summary>
        public string usr_firstname { get; set; }

        /// <summary>
        /// Nom
        /// </summary>
        public string usr_lastname { get; set; }

        /// <summary>
        /// Mail
        /// </summary>
        public string usr_mail { get; set; }

        /// <summary>
        /// Numeor telephone
        /// </summary>
        public string usr_phonenumber { get; set; }

        /// <summary>
        /// Mdp
        /// </summary>
        public string usr_password { get; set; }

        /// <summary>
        /// Ville
        /// </summary>
        public string usr_city { get; set; }

        /// <summary>
        /// Bureau utilisateur
        /// </summary>
        public string usr_office { get; set; }

        /// <summary>
        /// Conducteur oui/non
        /// </summary>
        public int usr_driver { get; set; }

        /// <summary>
        /// Photo ?? 
        /// </summary>
        public string usr_picture { get; set; }
        
        //public string MotDePasseUtilisateur { get; set; }

        //public bool Vehicule { get; set; }

        //public int NombrePlaces { get; set; }

        public UtilisateurProxy()
        {

        }
    }
}

