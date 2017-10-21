using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IBMCampus
{
    public class EvenementsModel
    {
        public int IdEvenement { get; set; }

        public string DateDebutEvent { get; set; }

        public string DateFinEvent { get; set; }

        public int IdGroupe { get; set; }

        public int NombreParticipants { get; set; }

        public int NombreParticipantsMax { get; set; }

        public bool IsRecurentHebdo { get; set; }

        public string NumeroVoieEvent { get; set; }

        public string TypeVoieEvent { get; set; }

        public string NomVoieEvent { get; set; }

        public string CodePostalEvent { get; set; }

        public string VilleEvent { get; set; }

        public DateTime DebutEvenement { get; set; }

        public DateTime FinEvenement { get; set; }
        

        public ObservableCollection<UtilisateurModel> Participants { get; set; }

        public string LocalisationEvenement { get; set; }
        
        public string NomEvenement { get; set; }
        

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
            NombreParticipantsMax = 0;
            NombreParticipants = 0;
            IsRecurentHebdo = false;
            NomEvenement = string.Empty;
            //EventHebdo = string.Empty;
        }
    }
}