using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public string EMailUtilisateur { get; set; }

        public string TelephoneUtilisateur { get; set; }

        public string AdresseUtilisateur { get; set; }

        public string Vehicule { get; set; }

        public int? NombrePlaceVoiture { get; set; }

        public string MotDePasseUtilisateur { get; set; }

        //public List<EvenementsModel> EvenementsUtilisateur { get; set; }

        public ObservableCollection<GroupeModel> GroupesUtilisateur { get; set; }

        public ObservableCollection<EvenementsModel> EventUtilisateur { get; set; }

        public UtilisateurModel()
        {
            //this.AgeUtilisateur = 0;
            this.EMailUtilisateur = string.Empty;
            //this.EvenementsUtilisateur = new List<EvenementsModel>();
            this.GroupesUtilisateur = new ObservableCollection<GroupeModel>();
            this.EventUtilisateur = new ObservableCollection<EvenementsModel>();
            this.AdresseUtilisateur = string.Empty;

        }
    }
}
