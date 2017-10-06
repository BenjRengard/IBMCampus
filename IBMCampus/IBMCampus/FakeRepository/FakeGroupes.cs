using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{
    public class FakeGroupes
    {
        public ObservableCollection<GroupeModel> ListeFauxGroupes { get; set; }

        public FakeGroupes()
        {
            this.ListeFauxGroupes = new ObservableCollection<GroupeModel>();

            var groupe1 = new GroupeModel()
            {
                NomGroupe = "Groupe 1",
                SportDuGroupe = new SportModel() { NomSport = "Rugby"},
                
            };

            ListeFauxGroupes.Add(groupe1);

            var groupe2 = new GroupeModel()
            {
                NomGroupe = "Groupe 2",
                SportDuGroupe = new SportModel() { NomSport = "Rugby" },

            };

            ListeFauxGroupes.Add(groupe2);

            var groupe3 = new GroupeModel()
            {
                NomGroupe = "Groupe 3",
                SportDuGroupe = new SportModel() { NomSport = "Foot-Ball" },

            };

            ListeFauxGroupes.Add(groupe3);
        }

        public ObservableCollection<GroupeModel> Donnees()
        {
            return ListeFauxGroupes;
        }
    }
}
