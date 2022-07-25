using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUrl
{
    public class Url_ 
    {
        public int id { get; set; }
        public string nama { get; set; }
        public string kode { get; set; }
        public string url { get; set; }
        public bool status { get; set; }
        public DateTime created { get; set; }
        public DateTime update { get; set; }
        public Url_(){}

        public static List<Url_> GetForDataSource()
        {
            List<Url_> L = new List<Url_>();
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/BaseUrl");
            string emat_setting_txt = "url.txt";

            string jsontext = System.IO.File.ReadAllText(System.IO.Path.Combine(directoryname, emat_setting_txt));
            L = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Url_>>(jsontext);
            return L;
        }

        public static List<Url_> CreateFirst()
        {
            List<Url_> url_s = new List<Url_>();
            Url_ l = new Url_ { created = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd")), id = 0, kode = "nle1", nama = "nle", status = true, update = Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd")), url = "https://nlehub.kemenkeu.go.id/nlesp2/v1/sp2/Booking/SaveBooking" };
            url_s.Add(l);
            return url_s;

        }

        public static Url_ GetBaseUrlFromTrxName(string namaTransaksi)
        {
            Url_ url_ = new Url_();
            List<Url_> baseUrls = BaseUrl.Url_.GetForDataSource();
            url_ = baseUrls.Where(x => x.nama.ToLower()==namaTransaksi.ToLower()).FirstOrDefault();
            return url_;
        }

        public void Create_Initial()
        {
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/BaseUrl");
            string emat_setting_txt = "url.txt";
            string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!System.IO.Directory.Exists(System.IO.Path.Combine(GuarnteedWritePath, directoryname)))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(GuarnteedWritePath, directoryname));
            }

            string FilePath = System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt);
            if (!System.IO.File.Exists(FilePath))
            {
                List<Url_> e =Url_.CreateFirst();
                using (System.IO.FileStream fs = System.IO.File.Create(FilePath))
                {
                    string dataasstring = Newtonsoft.Json.JsonConvert.SerializeObject(e); //your data
                    byte[] info = new System.Text.UTF8Encoding(true).GetBytes(dataasstring);
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }
            }
        }

        public static void SaveAllBaseUrl(List<Url_> s)
        {
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/BaseUrl");
            string emat_setting_txt = "url.txt";
            string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            try
            {
                using (System.IO.StreamWriter stream = new System.IO.StreamWriter(System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt), false))
                {
                    stream.Write(Newtonsoft.Json.JsonConvert.SerializeObject(s));
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public static List<System.Web.Mvc.SelectListItem> BaseUrlForList()
        {
            List<System.Web.Mvc.SelectListItem> groups = new List<System.Web.Mvc.SelectListItem>();
            List<Url_> baseUrls = BaseUrl.Url_.GetForDataSource();
            foreach (var x in baseUrls)
            {
                System.Web.Mvc.SelectListItem item = new System.Web.Mvc.SelectListItem();
                object o = new { nama = x.nama, kode = x.kode, url = x.url };
                item.Value = Newtonsoft.Json.JsonConvert.SerializeObject(o);
                item.Text = x.nama;
                groups.Add(item);
            }
            return groups;
        }

    }

    public class CAu
    {
        public string NamaApi { get; set; }
    }

    public class ApiNama
    {
        public List<CAu> cAu { get; set; }
    }
}