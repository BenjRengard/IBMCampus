using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IBMCampus
{
    public class GroupeModel
    {
        
        public int IdGroupe { get; set; }

        public string NomGroupe { get; set; }

        public int ParticipantsActuelsGroupe { get; set; }

        public int ParticipantsMaxGroupe { get; set; }
        
        public string NumeroRueGroupe { get; set; }

        public string TypeVoieGroupe { get; set; }

        public string NomVoieGroupe { get; set; }

        public string CodePostalGroupe { get; set; }

        public string VilleGroupe { get; set; }

        public int IdSport { get; set; }

        public string NomSport { get; set; }

        public string LocalisationComplete { get
            {
                return string.Format("{0} {1} {2}\n{3} {4}", NumeroRueGroupe, TypeVoieGroupe, NomVoieGroupe, CodePostalGroupe, VilleGroupe);
            } }
        public ObservableCollection<UtilisateurModel> UtilisateurGroupe { get; set; }

        public SportModel SportGroupe { get; set; }

        public ObservableCollection<EvenementsModel> EvenementsGroupe { get; set; }

        public GroupeModel()
        {
            UtilisateurGroupe = new ObservableCollection<UtilisateurModel>();
            SportGroupe = new SportModel();
            EvenementsGroupe = new ObservableCollection<EvenementsModel>();
        }


    }
}