using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IBMCampus
{
    public class EvenementsModel
    {
        public DateTime DebutEvenement { get; set; }

        public DateTime FinEvenement { get; set; }

        public int IdGroupe { get; set; }

        public ObservableCollection<UtilisateurModel> Participants { get; set; }

        public string LocalisationEvenement { get; set; }

        public int NombreMaximumParticipant { get; set; }

        public int NombreParticipants { get; set; }

        public bool IsRecurentHebdo { get; set; }

        public string NomEvenement { get; set; }

        public int IdEvent { get; set; }

        public string NumeroRueEvenement { get; set; }

        public string TypeVoieEvenement { get; set; }

        public string NomVoieEvenement { get; set; }

        public string CodePostalEvenement { get; set; }

        public string VilleEvenement { get; set; }

        public int EventHebdo
        {
            get { return IsRecurentHebdo ? 1 : 0; }
            set { }
        }
        

        public EvenementsModel()
        {
            DebutEvenement = new DateTime();
            FinEvenement = new DateTime();
            //GroupeDeLevenement = new GroupeModel();
            Participants = new ObservableCollection<UtilisateurModel>();
            LocalisationEvenement = string.Empty;
            NombreMaximumParticipant = 0;
            NombreParticipants = 0;
            IsRecurentHebdo = false;
            NomEvenement = string.Empty;
            //EventHebdo = string.Empty;
        }
    }
}