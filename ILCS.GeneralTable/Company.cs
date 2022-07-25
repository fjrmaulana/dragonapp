using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FajarProject.GeneralTable
{
    public class Company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string NPWP { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string CompanyType { get; set; }
        public bool statusactive { get; set; }
        public string CustCode { get; set; }
        public Company()
        {

        }

        public static bool SaveCompany(Company c)
        {
            bool return_ = false;
            try
            {
                List<Company> r = Company.GetCompanyForDataSource();
                r.Insert(0, c);
                SaveAllCompany(r);
                return_ = true;
            }
            catch (Exception es)
            {
                return_ = false;
                System.Diagnostics.Debug.WriteLine(es);
            }
            return return_;
        }

        public static bool DeleteCompany(string c)
        {
            bool return_ = false;
            try
            {
                List<Company> r = Company.GetCompanyForDataSource();
                r.RemoveAll(x => x.CustCode == c);
                SaveAllCompany(r);
                return_ = true;
            }
            catch (Exception es)
            {
                return_ = false;
                System.Diagnostics.Debug.WriteLine(es);
            }
            return return_;
        }

        public static List<Company> GetCompanyFirst()
        {
            List<Company> l = new List<Company>();
            l.Add(new Company { ID = 1, CompanyName = "CompanyName1", CompanyAddress = "CompanyAddress1", NPWP = "NPWP1", ContactPerson = "ContactPerson1", ContactPhone = "ContactPhone1", CompanyType = "CompanyType1", CustCode = "CustCode1", statusactive=true });
            l.Add(new Company { ID = 2, CompanyName = "CompanyName2", CompanyAddress = "CompanyAddress2", NPWP = "NPWP2", ContactPerson = "ContactPerson2", ContactPhone = "ContactPhone2", CompanyType = "CompanyType2", CustCode = "CustCode2",statusactive=true });
            return l;
        }

        public static List<Company> GetCompanyForDataSource()
        {
            List<Company> e = new List<Company>();
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Company");
            string emat_setting_txt = "company.txt";

            string jsontext = System.IO.File.ReadAllText(System.IO.Path.Combine(directoryname, emat_setting_txt));
            e = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Company>>(jsontext);
            return e;
        }

        public void Create_Initial()
        {
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Company");
            string emat_setting_txt = "company.txt";
            string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!System.IO.Directory.Exists(System.IO.Path.Combine(GuarnteedWritePath, directoryname)))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(GuarnteedWritePath, directoryname));
            }

            string FilePath = System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt);
            if (!System.IO.File.Exists(FilePath))
            {
                List<Company> e = Company.GetCompanyFirst();
                using (System.IO.FileStream fs = System.IO.File.Create(FilePath))
                {
                    string dataasstring = Newtonsoft.Json.JsonConvert.SerializeObject(e); //your data
                    byte[] info = new System.Text.UTF8Encoding(true).GetBytes(dataasstring);
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }
            }
        }

        public static void SaveAllCompany(List<Company> s)
        {
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Company");
            string emat_setting_txt = "company.txt";
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

       

    }
}
