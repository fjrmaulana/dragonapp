using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILCS.GeneralTable
{    
  public  class Pelabuhan
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Kota { get; set; }
        public Pelabuhan()
        {

        }

        public static List<Pelabuhan> GetPelabuhanForDataSource()
        {
            List<Pelabuhan> pelabuhans = new List<Pelabuhan>();
            pelabuhans.Add(new Pelabuhan { Id = 1, Kota = "Bekasi", Nama = "Fajar" });
            pelabuhans.Add(new Pelabuhan { Id = 2, Kota = "Jakarta", Nama = "Dzaki" });
            pelabuhans.Add(new Pelabuhan { Id = 3, Kota = "Lampung", Nama = "Iqbal" });
            return pelabuhans;
        }
    }
}
