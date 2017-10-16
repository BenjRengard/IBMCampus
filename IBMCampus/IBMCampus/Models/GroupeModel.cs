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

        public string LocalisationNomRue { get; set; }

        public string LocalisationTypeVoie { get; set; }

        public string LocalisationNumero { get; set; }

        public string LocalisationCodePostal { get; set; }

        public string LocalisationVille { get; set; }

        public string LocalisationComplete { get
            {
                return string.Format("{0} {1} {2}\n{3} {4}", LocalisationNumero, LocalisationTypeVoie, LocalisationNomRue, LocalisationCodePostal, LocalisationVille);
            } }





    }
}