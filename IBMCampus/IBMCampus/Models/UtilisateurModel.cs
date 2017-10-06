using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{
    public class UtilisateurModel
    {
        public string NomUtilisateur { get; set; }

        public string PrenomUtilisateur { get; set; }

        public int AgeUtilisateur { get; set; }

        public string TelephoneUtilisateur { get; set; }

        public string EMailUtilisateur { get; set; }

        public List<GroupeModel> GroupesUtilisateur { get; set; }

        public List<SportModel> SportsUtilisateur { get; set; }

        public List<EvenementsModel> EvenementsUtilisateur { get; set; }

        public string LocalisationUtilisateur { get; set; }
    }
}
