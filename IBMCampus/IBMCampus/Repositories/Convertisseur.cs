using System;

namespace IBMCampus
{
    public static class Convertisseur
    {
        public static string ConvertirDateTimeEnDateMySqlAvecHeure(DateTime dateAConvertir)
        {
            return dateAConvertir.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ConvertirDateTimeEnDateMySqlSansHeure(DateTime dateAConvertir)
        {
            return dateAConvertir.ToString("yyyy-MM-dd");
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UtilisateurProxy ConvertirUtilisateurModelEnProxy(UtilisateurModel model)
        {
            return new UtilisateurProxy()
            {
                usr_city = model.AdresseUtilisateur,
                //usr_driver = (model.Vehicule==true) ? 1 : 0,
                usr_firstname = model.PrenomUtilisateur,
                usr_lastname = model.NomUtilisateur,
                usr_mail = model.EMailUtilisateur,
                usr_password = model.MotDePasseUtilisateur,
                usr_phonenumber = model.TelephoneUtilisateur
            };
            
        }

        /// <summary>
        /// Uniquement avec EMAIL, ID, PRENOM et NOM
        /// </summary>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public static UtilisateurModel ConvertirUtilisateurProxyEnModel(UtilisateurProxy proxy)
        {
            return new UtilisateurModel()
            {
                EMailUtilisateur = proxy.usr_mail,
                IdUtilisateur = proxy.usr_Id,
                PrenomUtilisateur = proxy.usr_firstname,
                NomUtilisateur = proxy.usr_lastname
            };
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
            return new GroupeModel()
            {
                IdGroupe = proxy.gs_Id,
                NomGroupe = proxy.gs_Nom,
                ParticipantsMaxGroupe = proxy.gs_Nbr_Membre_Max,
                
            };

        }
    }
}
