using System.Collections.Generic;

namespace IBMCampus
{
    public class GroupeModel
    {
        public string NomGroupe { get; set; }

        public List<UtilisateurModel> UtilisateursDuGroupe { get; set; }

        public SportModel SportDuGroupe { get; set; }

        public List<EvenementsModel> EvenementsDuGroupe { get; set; }


    }
}