using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBMCampus
{

    public class MasterDetailPageTestMenuItem
    {
        public MasterDetailPageTestMenuItem()
        {
            TargetType = typeof(PageProfilUtilisateur);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}