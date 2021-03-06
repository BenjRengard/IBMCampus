﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IBMCampus
{
    public class EvenementsModel
    {
        public int IdEvenement { get; set; }

        public string DateEvent { get; set; }

        public string DateFinEvent { get; set; }

        public string HeureDebut { get; set; }

        public string HeureFin { get; set; }

        public int IdGroupe { get; set; }

        public int NombreParticipants { get; set; }

        public int NombreParticipantsMax { get; set; }

        public int IsRecurentHebdo { get; set; }

        public string NumeroVoieEvent { get; set; }

        public string TypeVoieEvent { get; set; }

        public string NomVoieEvent { get; set; }

        public string CodePostalEvent { get; set; }

        public string VilleEvent { get; set; }

        public DateTime DebutEvenement { get; set; }

        public DateTime FinEvenement { get; set; }

        public TimeSpan HeureDebutTimeSpan { get; set; }

        public TimeSpan HeureFinTimeSpan { get; set; }


        public ObservableCollection<UtilisateurModel> Participants { get; set; }

        public string LocalisationEvenement { get; set; }

        public string NomEvenement { get; set; }


        public string EventHebdo { get; set; }

        public string NomGroupeEvenement { get; set; }

        public string Hebdomadaire
        {
            get
            {
                if (IsRecurentHebdo == 1)
                {
                    return "Oui";
                }
                else
                {
                    return "Non";
                }
            }
        }

        public string LocalisationComplete
        {
            get
            {
                return string.Format("{0} {1} {2}\n{3} {4}", NumeroVoieEvent, TypeVoieEvent, NomVoieEvent, CodePostalEvent, VilleEvent);
            }
        }

        public string DateAffiche
        {
            get
            {
                return DebutEvenement.ToString("dd/MM/yyyy");
            }
        }


        public EvenementsModel()
        {
            DebutEvenement = new DateTime();
            FinEvenement = new DateTime();
            //GroupeDeLevenement = new GroupeModel();
            Participants = new ObservableCollection<UtilisateurModel>();
            LocalisationEvenement = string.Empty;
            NombreParticipantsMax = 0;
            NombreParticipants = 0;
            //IsRecurentHebdo = false;
            NomEvenement = string.Empty;
            //EventHebdo = string.Empty;

        }
    }
}