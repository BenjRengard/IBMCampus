using System;
using System.Collections;
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
                    
                },
                IdGroupe = 1

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
                },
                IdGroupe = 2
                
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
                },
                IdGroupe = 3

            };

            ListeFauxGroupes.Add(groupe3);

            var groupe4 = new GroupeModel()
            {
                NomGroupe = "Les joueur",
                SportDuGroupe = new SportModel() { NomSport = "Escrime" },
                UtilisateursDuGroupe = new ObservableCollection<UtilisateurModel>()
                {
                   benj,
                   thibaut,
                   bat
                },
                IdGroupe = 4

            };

            ListeFauxGroupes.Add(groupe4);
        }

        internal ObservableCollection<GroupeModel>RecupererGroupesUtilisateur(UtilisateurModel user)
        {
            var listeARetourner = new ObservableCollection<GroupeModel>();
            foreach (var idgroupe in user.GroupesUtilisateur)
            {
                var groupe = ListeFauxGroupes.FirstOrDefault(g => g.IdGroupe == idgroupe);
                listeARetourner.Add(groupe);
            }
            return listeARetourner;
        }

        public ObservableCollection<GroupeModel> RecupererTousLesGroupes()
        {
            return ListeFauxGroupes;
        }


    }
}
