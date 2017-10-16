using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus.FakeRepository
{
    public class FakeUtilisateurs
    {
        public ObservableCollection<UtilisateurModel> Utilisateurs = new ObservableCollection<UtilisateurModel>();

        public FakeUtilisateurs()
        {
            var batman = new UtilisateurModel()
            {
                NomUtilisateur = "Wayne",
                PrenomUtilisateur = "Bruce",
                AgeUtilisateur = 30,
                EMailUtilisateur = @"batman@batman.com",
                MotDePasseUtilisateur = "123bat",
                GroupesUtilisateur = new List<int> { 1, 4}
            };

            Utilisateurs.Add(batman);

            var superman = new UtilisateurModel()
            {
                NomUtilisateur = "Kent",
                PrenomUtilisateur = "Clark",
                AgeUtilisateur = 28,
                EMailUtilisateur = @"superman@batman.com",
                MotDePasseUtilisateur = "123sm",
                GroupesUtilisateur = new List<int> { 2 }

            };
            Utilisateurs.Add(superman);

            var benj = new UtilisateurModel()
            {
                NomUtilisateur = "Rengard",
                AgeUtilisateur = 25,
                PrenomUtilisateur = "Benjamin",
                EMailUtilisateur = @"rengard.benjamin@fauxmail.fr",
                MotDePasseUtilisateur = "123benj",
                GroupesUtilisateur = new List<int> { 1, 4 }

            };
            Utilisateurs.Add(benj);

            var cive = new UtilisateurModel()
            {
                NomUtilisateur = "Cive",
                AgeUtilisateur = 25,
                PrenomUtilisateur = "Jean",
                EMailUtilisateur = @"jean.cive@test.com",
                MotDePasseUtilisateur = "123cive",
                GroupesUtilisateur = new List<int> { 1, 2 }

            };
            Utilisateurs.Add(cive);

            var jerome = new UtilisateurModel()
            {
                NomUtilisateur = "Laquay",
                AgeUtilisateur = 25,
                PrenomUtilisateur = "Jérôme",
                EMailUtilisateur = @"jeromelaquay@bidon.com",
                MotDePasseUtilisateur = "123jer",
                GroupesUtilisateur = new List<int> { 3 }

            };
            Utilisateurs.Add(jerome);

            var alex = new UtilisateurModel()
            {
                NomUtilisateur = "Moorels",
                AgeUtilisateur = 25,
                PrenomUtilisateur = "Alexis",
                EMailUtilisateur = @"alex@bidon.com",
                MotDePasseUtilisateur = "123alex",
                GroupesUtilisateur = new List<int> { 1 }

            };
            Utilisateurs.Add(alex);

            var aurel = new UtilisateurModel()
            {
                NomUtilisateur = "Ducloy",
                AgeUtilisateur = 21,
                PrenomUtilisateur = "Aurélien",
                EMailUtilisateur = @"aurelien@bidon.com",
                MotDePasseUtilisateur = "123aurel",
                GroupesUtilisateur = new List<int> { 3 }

            };
            Utilisateurs.Add(aurel);

            var thibaut = new UtilisateurModel()
            {
                NomUtilisateur = "Chauchoy",
                AgeUtilisateur = 20,
                PrenomUtilisateur = "Thibaut",
                EMailUtilisateur = @"choc@bidon.com",
                MotDePasseUtilisateur = "123thib",
                GroupesUtilisateur = new List<int> { 3, 4 }

            };
            Utilisateurs.Add(thibaut);



        }
    }
}
