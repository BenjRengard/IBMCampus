using System;
using System.Collections.Generic;

namespace IBMCampus
{
    public class EvenementsModel
    {
        public DateTime DebutEvenement { get; set; }

        public DateTime FinEvenement { get; set; }

        public GroupeModel GroupeDeLevenement { get; set; }

        public List<UtilisateurModel> Participants { get; set; }

        public string LocalisationEvenement { get; set; }

        public int NombreMaximumParticipant { get; set; }

        public int NombreParticipants { get; set; }

        public bool IsRecurentHebdo { get; set; }

        public string NomEvenement { get; set; }

        public int IdEvent { get; set; }

        public const string EvenHebdo = "Est un évènement hebdomadaire";

        public const string EventNonHebdo = "N'est pas un évènement hébdomadaire";

        public EvenementsModel()
        {
            DebutEvenement = new DateTime();
            FinEvenement = new DateTime();
            GroupeDeLevenement = new GroupeModel();
            Participants = new List<UtilisateurModel>();
            LocalisationEvenement = string.Empty;
            NombreMaximumParticipant = 0;
            NombreParticipants = 0;
            IsRecurentHebdo = false;
            NomEvenement = string.Empty;
        }
    }
}