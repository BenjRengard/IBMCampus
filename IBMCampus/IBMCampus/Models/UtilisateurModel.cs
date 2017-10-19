using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{
    public class UtilisateurModel
    {
        public int IdUtilisateur { get; set; }

        public string NomUtilisateur { get; set; }

        public string PrenomUtilisateur { get; set; }

        //public int AgeUtilisateur { get; set; }

        public string TelephoneUtilisateur { get; set; }

        public string EMailUtilisateur { get; set; }

        public List<int> GroupesUtilisateur { get; set; }

        public List<int> SportsUtilisateur { get; set; }

        public List<EvenementsModel> EvenementsUtilisateur { get; set; }

        public string LocalisationUtilisateur { get; set; }


        public string MotDePasseUtilisateur { get; set; }

        public bool Vehicule { get; set; }

        public int NombrePlaces { get; set; }

        public UtilisateurModel()
        {
            //this.AgeUtilisateur = 0;
            this.EMailUtilisateur = string.Empty;
            this.EvenementsUtilisateur = new List<EvenementsModel>();
            this.GroupesUtilisateur = new List<int>();
            this.LocalisationUtilisateur = string.Empty;

        }
    }
}
