using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{
    public class UtilisateurModel
    {
        [Required(ErrorMessage ="Un nom est requis")]
        public string NomUtilisateur { get; set; }
        [Required(ErrorMessage ="Un prénom est requis")]
        public string PrenomUtilisateur { get; set; }

        public int AgeUtilisateur { get; set; }

        public string TelephoneUtilisateur { get; set; }
        [Required]
        public string EMailUtilisateur { get; set; }

        public List<GroupeModel> GroupesUtilisateur { get; set; }

        public List<SportModel> SportsUtilisateur { get; set; }

        public List<EvenementsModel> EvenementsUtilisateur { get; set; }

        public string LocalisationUtilisateur { get; set; }

        [Required]
        public string MotDePasseUtilisateur { get; set; }
    }
}
