using System.Collections.Generic;

namespace IBMCampus
{
    public class SportModel
    {
        public string NomSport { get; set; }

        public List<GroupeModel> GroupesDuSport { get; set; }

        public string Localisation { get; set; }

        public int IdSport { get; set; }
    }
}