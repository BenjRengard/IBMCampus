using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using IBMCampus.FakeRepository;
//using IBMCampus.Models;

namespace IBMCampus
{
    public class FakeRepository
    {
        public ObservableCollection<GroupeModel> ListeFauxGroupes = new ObservableCollection<GroupeModel>();
        public UtilisateurModel User = new UtilisateurModel();
        public ObservableCollection<UtilisateurModel> UtilisateursEnregistres = new ObservableCollection<UtilisateurModel>();

       
        public ObservableCollection<UtilisateurModel> ChauffeurEnregistres = new ObservableCollection<UtilisateurModel>();

        public ObservableCollection<ChauffeurModel> ListeFauxChauffeur = new ObservableCollection<ChauffeurModel>();
        public ObservableCollection<EvenementsModel> ListeFauxEvent = new ObservableCollection<EvenementsModel>();

        public FakeRepository()
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

            var event1 = new EvenementsModel()
            {
                NomEvenement = "Airsoft",
                DebutEvenement = new DateTime(2017, 10, 16, 12, 05, 00),
                FinEvenement = new DateTime(2017, 10, 16, 12, 05, 00),
                IsRecurentHebdo = true,
                LocalisationEvenement = "Lambersart",
                Participants = new List<UtilisateurModel>()
                {
                    alex,
                    benj,
                    bat,
                    superman,
                    aurel
                },
                NombreMaximumParticipant = 15,
                NombreParticipants = 5
            };

            var event2 = new EvenementsModel()
            {
                NomEvenement = "Raclette",
                DebutEvenement = new DateTime(2017, 11, 16, 12, 30, 00),
                FinEvenement = new DateTime(2017, 11, 16, 12, 40, 00),
                IsRecurentHebdo = false,
                LocalisationEvenement = "Lomme",
                Participants = new List<UtilisateurModel>()
                {
                    superman,
                    cive
                },
                NombreMaximumParticipant = 5,
                NombreParticipants = 2
            };

            ListeFauxEvent.Add(event1);
            ListeFauxEvent.Add(event2);

            var Chauffeur1 = new ChauffeurModel()
            {
                NomChauffeur = benj.NomUtilisateur,
                NombrePlace = 3,
                Localisation = "Teraneo",
                HeureRdv = new DateTime(2017, 10, 16, 12, 05, 00),
                VisibiliteTelephone = true,
                ListePassager = new List<UtilisateurModel>()
                {
                    alex
                },
                


            };

            ListeFauxChauffeur.Add(Chauffeur1);

            var groupe1 = new GroupeModel()
            {
                NomGroupe = "Groupe de rugbymen d'IBM",
                SportGroupe = new SportModel() { NomSport = "Rugby" },
                UtilisateurGroupe = new ObservableCollection<UtilisateurModel>()
                {
                    benj,
                    cive,
                    alex,
                    bat
                    
                },
                IdGroupe = 1,
                ParticipantsMax = 10,
                NumeroRueGroupe = "120",
                TypeVoieGroupe = "Avenue de",
                NomVoieGroupe = "Joie",
                CodePostalGroupe = "59000",
                VilleGroupe = "Lille"

            };

            ListeFauxGroupes.Add(groupe1);

            var groupe2 = new GroupeModel()
            {
                NomGroupe = "Groupe de mecs qui font du Bad",
                SportGroupe = new SportModel() { NomSport = "Badminton" },
                UtilisateurGroupe = new ObservableCollection<UtilisateurModel>()
                {
                    superman,
                    cive
                },
                IdGroupe = 2,
                ParticipantsMax = 2,
                NumeroRueGroupe = "12",
                TypeVoieGroupe = "Rue de",
                NomVoieGroupe = "courbier",
                CodePostalGroupe = "59800",
                VilleGroupe = "Lille"


            };

            ListeFauxGroupes.Add(groupe2);

            var groupe3 = new GroupeModel()
            {
                NomGroupe = "Les footeux",
                SportGroupe = new SportModel() { NomSport = "Football" },
                UtilisateurGroupe = new ObservableCollection<UtilisateurModel>()
                {
                   aurel,
                   thibaut,
                   jerome
                },
                IdGroupe = 3,
                ParticipantsMax = 10

            };

            ListeFauxGroupes.Add(groupe3);

            var groupe4 = new GroupeModel()
            {
                NomGroupe = "Les joueurs",
                SportGroupe = new SportModel() { NomSport = "Escrime" },
                UtilisateurGroupe = new ObservableCollection<UtilisateurModel>()
                {
                   benj,
                   thibaut,
                   bat
                },
                IdGroupe = 4,
                ParticipantsMax = 10


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

        public ObservableCollection<ChauffeurModel> RecupererTousChauffeurs()
        {
            return ListeFauxChauffeur;
        }

        public ObservableCollection<EvenementsModel> RecupererTousLesEvents()
        {
            return ListeFauxEvent;
        }

        public ObservableCollection<EvenementsModel> RecupererEvenementUtilisateur(UtilisateurModel user)
        {
            return ListeFauxEvent;
            //throw new NotImplementedException();
        }

        internal ObservableCollection<EvenementsModel> RecupererEvenementGroupe(GroupeModel groupe)
        {
            return ListeFauxEvent;
            //throw new NotImplementedException();
        }

    }
}
