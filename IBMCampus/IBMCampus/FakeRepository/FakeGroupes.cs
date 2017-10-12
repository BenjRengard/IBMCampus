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
        public ObservableCollection<GroupeModel> ListeFauxGroupes = new ObservableCollection<GroupeModel>();
        public UtilisateurModel User = new UtilisateurModel();

        public FakeGroupes()
        {
            //this.ListeFauxGroupes = new ObservableCollection<GroupeModel>();
            //this.FauxUser = new UtilisateurModel();

            this.User = new UtilisateurModel()
            {
                NomUtilisateur = "Wayne",
                PrenomUtilisateur = "Bruce",
                AgeUtilisateur = 30,
                EMailUtilisateur = @"batman@batman.com",
                MotDePasseUtilisateur = "123bat"
            };

            var groupe1 = new GroupeModel()
            {
                NomGroupe = "Groupe de rugbymen d'IBM",
                SportDuGroupe = new SportModel() { NomSport = "Rugby"},
                UtilisateursDuGroupe = new ObservableCollection<UtilisateurModel>()
                {
                    new UtilisateurModel()
                    {
                        NomUtilisateur = "Rengard",
                        AgeUtilisateur = 25,
                        PrenomUtilisateur = "Benjamin",
                        EMailUtilisateur = @"rengard.benjamin@fauxmail.fr"
                        
                    },
                     new UtilisateurModel()
                    {
                        NomUtilisateur = "Cive",
                        AgeUtilisateur = 25,
                        PrenomUtilisateur = "Jean",
                        EMailUtilisateur = @"jean.cive@test.com"

                    }
                }
                
            };

            ListeFauxGroupes.Add(groupe1);

            var groupe2 = new GroupeModel()
            {
                NomGroupe = "Groupe de mecs qui font du Bad",
                SportDuGroupe = new SportModel() { NomSport = "Badminton" },
                UtilisateursDuGroupe = new ObservableCollection<UtilisateurModel>()

            };

            ListeFauxGroupes.Add(groupe2);

            var groupe3 = new GroupeModel()
            {
                NomGroupe = "Les footeux",
                SportDuGroupe = new SportModel() { NomSport = "Football" },
                UtilisateursDuGroupe = new ObservableCollection<UtilisateurModel>()
                {
                    new UtilisateurModel()
                    {
                        NomUtilisateur = "Jérôme",
                        AgeUtilisateur = 25,
                        PrenomUtilisateur = "Laquay",
                        EMailUtilisateur = @"jeromelaquay@bidon.com"

                    },
                     new UtilisateurModel()
                    {
                        NomUtilisateur = "Cive",
                        AgeUtilisateur = 25,
                        PrenomUtilisateur = "Jean",
                        EMailUtilisateur = @"jean.cive@test.com"

                    }
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
