using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBMCampus.FakeRepository;

namespace IBMCampus
{
    public class FakeGroupes
    {
        public ObservableCollection<GroupeModel> ListeFauxGroupes = new ObservableCollection<GroupeModel>();
        public UtilisateurModel User = new UtilisateurModel();
        public ObservableCollection<UtilisateurModel> UtilisateursEnregistres = new ObservableCollection<UtilisateurModel>();

        public FakeGroupes()
        {
            var repoUser = new FakeUtilisateurs();
            UtilisateursEnregistres = repoUser.Utilisateurs;

            var benj = repoUser.Utilisateurs.First(u => u.NomUtilisateur == "Rengard");
            var alex = repoUser.Utilisateurs.First(u => u.NomUtilisateur == "Moorels");
            var bat = repoUser.Utilisateurs.First(u => u.NomUtilisateur == "Wayne");
            var superman = repoUser.Utilisateurs.First(u => u.NomUtilisateur == "Kent");
            var thibaut = repoUser.Utilisateurs.First(u => u.NomUtilisateur == "Chauchoy");
            var jerome = repoUser.Utilisateurs.First(u => u.NomUtilisateur == "Laquay");
            var aurel = repoUser.Utilisateurs.First(u => u.NomUtilisateur == "Ducloy");
            var cive = repoUser.Utilisateurs.First(u => u.NomUtilisateur == "Cive");

            var groupe1 = new GroupeModel()
            {
                NomGroupe = "Groupe de rugbymen d'IBM",
                SportDuGroupe = new SportModel() { NomSport = "Rugby" },
                UtilisateursDuGroupe = new ObservableCollection<UtilisateurModel>()
                {
                    benj,
                    cive,
                    alex,
                    bat
                    
                }

            };

            ListeFauxGroupes.Add(groupe1);

            var groupe2 = new GroupeModel()
            {
                NomGroupe = "Groupe de mecs qui font du Bad",
                SportDuGroupe = new SportModel() { NomSport = "Badminton" },
                UtilisateursDuGroupe = new ObservableCollection<UtilisateurModel>()
                {
                    superman,
                    cive
                }

            };

            ListeFauxGroupes.Add(groupe2);

            var groupe3 = new GroupeModel()
            {
                NomGroupe = "Les footeux",
                SportDuGroupe = new SportModel() { NomSport = "Football" },
                UtilisateursDuGroupe = new ObservableCollection<UtilisateurModel>()
                {
                   aurel,
                   thibaut,
                   jerome
                }

            };

            ListeFauxGroupes.Add(groupe3);
        }

        public ObservableCollection<GroupeModel> RecupererTousLesGroupes()
        {
            return ListeFauxGroupes;
        }


    }
}
