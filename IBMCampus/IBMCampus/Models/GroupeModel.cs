using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IBMCampus
{
    public class GroupeModel
    {
        public string NomGroupe { get; set; }

        public ObservableCollection<UtilisateurModel> UtilisateursDuGroupe { get; set; }

        public SportModel SportDuGroupe { get; set; }

        public ObservableCollection<EvenementsModel> EvenementsDuGroupe { get; set; }

        public int IdGroupe { get; set; }

        public int ParticipantsMax { get; set; }

        public int ParticipantsActuels
        {
            get
            {
                return this.UtilisateursDuGroupe.Count; 
            }
        }





    }
}