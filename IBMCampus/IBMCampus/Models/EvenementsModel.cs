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

        public bool IsRecurentHebdo { get; set; }
    }
}