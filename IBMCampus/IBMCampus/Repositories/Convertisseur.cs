using System;

namespace IBMCampus
{
    public static class Convertisseur
    {
        public static UtilisateurProxy ConvertirUtilisateurModelEnProxy(UtilisateurModel model)
        {
            return new UtilisateurProxy()
            {
                usr_city = model.LocalisationUtilisateur,
                usr_driver = (model.Vehicule==true) ? 1 : 0,
                usr_firstname = model.PrenomUtilisateur,
                usr_lastname = model.NomUtilisateur,
                usr_mail = model.EMailUtilisateur,
                usr_password = model.MotDePasseUtilisateur,
                usr_phonenumber = model.TelephoneUtilisateur
            };
            
        }

        public static UtilisateurModel ConvertirUtilisateurProxyEnModel(UtilisateurProxy proxy)
        {
            throw new NotImplementedException();
        }

        public static EvenementProxy ConvertirEvenementModelEnProxy(EvenementsModel model)
        {
            throw new NotImplementedException();

        }

        public static EvenementsModel ConvertirEvenementProxyEnModel(EvenementProxy proxy)
        {
            throw new NotImplementedException();

        }

        public static GroupeProxy ConvertirGroupeModelEnProxy(GroupeModel model)
        {
            throw new NotImplementedException();

        }

        public static GroupeModel ConvertirGroupeProxyEnModel(GroupeProxy proxy)
        {
            throw new NotImplementedException();

        }
    }
}
