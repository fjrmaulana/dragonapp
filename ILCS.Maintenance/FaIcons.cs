using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILCS.Maintenance
{
   
    public class FaIcons
    {
        public  string Fas_fa_circle { get; set; }
        public string Far_fa_circle { get; set; }
        public string fas_fa_box { get; set; }
        public FaIcons()
        {
           
        }

        public static List<FaIcons> GetFaiconforDataSource()
        {
            List<FaIcons> l = new List<FaIcons>();
            FaIcons f = new FaIcons();
            f.Fas_fa_circle = "fas fa-circle";
            f.Far_fa_circle = "far fa-circle";
            f.fas_fa_box = "fas fa-box";
            l.Add(f);
            return l;
        }
    }
}
