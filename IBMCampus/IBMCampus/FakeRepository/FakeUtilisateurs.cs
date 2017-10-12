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
                MotDePasseUtilisateur = "123bat"
            };

            Utilisateurs.Add(batman);

            var superman = new UtilisateurModel()
            {
                NomUtilisateur = "Kent",
                PrenomUtilisateur = "Clark",
                AgeUtilisateur = 28,
                EMailUtilisateur = @"superman@batman.com",
                MotDePasseUtilisateur = "123sm"
            };
            Utilisateurs.Add(superman);

            var benj = new UtilisateurModel()
            {
                NomUtilisateur = "Rengard",
                AgeUtilisateur = 25,
                PrenomUtilisateur = "Benjamin",
                EMailUtilisateur = @"rengard.benjamin@fauxmail.fr",
                MotDePasseUtilisateur = "123benj"
            };
            Utilisateurs.Add(benj);

            var cive = new UtilisateurModel()
            {
                NomUtilisateur = "Cive",
                AgeUtilisateur = 25,
                PrenomUtilisateur = "Jean",
                EMailUtilisateur = @"jean.cive@test.com",
                MotDePasseUtilisateur = "123cive"
            };
            Utilisateurs.Add(cive);

            var jerome = new UtilisateurModel()
            {
                NomUtilisateur = "Laquay",
                AgeUtilisateur = 25,
                PrenomUtilisateur = "Jérôme",
                EMailUtilisateur = @"jeromelaquay@bidon.com",
                MotDePasseUtilisateur = "123jer"
            };
            Utilisateurs.Add(jerome);

            var alex = new UtilisateurModel()
            {
                NomUtilisateur = "Moorels",
                AgeUtilisateur = 25,
                PrenomUtilisateur = "Alexis",
                EMailUtilisateur = @"alex@bidon.com",
                MotDePasseUtilisateur = "123alex"
            };
            Utilisateurs.Add(alex);

            var aurel = new UtilisateurModel()
            {
                NomUtilisateur = "Ducloy",
                AgeUtilisateur = 21,
                PrenomUtilisateur = "Aurélien",
                EMailUtilisateur = @"aurelien@bidon.com",
                MotDePasseUtilisateur = "123aurel"
            };
            Utilisateurs.Add(aurel);

            var thibaut = new UtilisateurModel()
            {
                NomUtilisateur = "Chauchoy",
                AgeUtilisateur = 20,
                PrenomUtilisateur = "Thibaut",
                EMailUtilisateur = @"choc@bidon.com",
                MotDePasseUtilisateur = "123thib"
            };
            Utilisateurs.Add(thibaut);



        }
    }
}
