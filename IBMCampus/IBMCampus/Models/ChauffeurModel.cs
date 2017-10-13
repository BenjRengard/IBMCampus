using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace IBMCampus.Models
{
    public class ChauffeurModel : ContentPage
    {
        public int NombrePlace { get; set; }

        public string Localisation { get; set; }

        public DateTime HeureRdv { get; set; }

        public bool VisibiliteTelephone { get; set; }

        public string LocalisationEvenement { get; set; }

        public bool IsRecurentHebdo { get; set; }
    }
}