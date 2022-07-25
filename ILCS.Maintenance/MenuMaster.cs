using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILCS.Maintenance
{
   public class MenuMaster
    {
        public int id { get; set; }
        public string Nama { get; set; }
        public string Kode { get; set; }
        public string Img { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }
        public MenuMaster(){  }

        public static int DeleteMenuMaster(MenuMaster m)
        {
            int result = 1;
            List<MenuMaster> menuMasters = MenuMaster.GetMenuMasterForDataSource();
            menuMasters.RemoveAll(x => x.Kode == m.Kode);
            SaveMenuMasterFromList(menuMasters);
            return result;
            //using (IDS.DataAccess.SqlServer db = new IDS.DataAccess.SqlServer())
            //{
            //    try
            //    {
            //        db.CommandText = "delete from MenuMaster where Kode=@Kode";
            //        db.AddParameter("@Kode", System.Data.SqlDbType.VarChar, m.Kode);
            //        db.CommandType = System.Data.CommandType.Text;
            //        db.Open();
            //        db.BeginTransaction();
            //        result = db.ExecuteNonQuery();
            //        db.CommitTransaction();
            //    }
            //    catch (System.Data.SqlClient.SqlException err)
            //    {
            //        if (db.Transaction != null)
            //            db.RollbackTransaction();

            //        switch (err.Number)
            //        {
            //            case 2627:
            //                throw new Exception("Combination of Account Number and Currency data are already exists. Please choose other Account No and Currency.");
            //            default:
            //                throw;
            //        }
            //    }
            //    catch
            //    {
            //        if (db.Transaction != null)
            //            db.RollbackTransaction();

            //        throw;
            //    }
            //    finally
            //    {
            //        db.Close();
            //    }
            //}
            //return result;
        }

        public static int UpdateMenuMaster(MenuMaster m)
        {
            int result = 1;
            List<MenuMaster> m_ = MenuMaster.GetMenuMasterForDataSource();
            m_.RemoveAll(x => x.Kode == m.Kode);
            m_.Insert(0, m);
            SaveMenuMasterFromList(m_);
            return result;
            // Bawah asli
            //int result = 0;
            //using (IDS.DataAccess.SqlServer db = new IDS.DataAccess.SqlServer())
            //{
            //    try
            //    {
            //        db.CommandText = "Update MenuMaster SET Nama=@Nama,Kode=@Kode,Img=@Img,Created=@Created,[Update]=@Update_,Role=@Role Where Kode=@Kode";
            //        db.AddParameter("@Nama", System.Data.SqlDbType.VarChar, m.Nama);
            //        db.AddParameter("@Kode", System.Data.SqlDbType.VarChar, m.Kode);
            //        db.AddParameter("@Img", System.Data.SqlDbType.VarChar, m.Img);
            //        db.AddParameter("@Role", System.Data.SqlDbType.VarChar, m.Role);
            //        //db.AddParameter("@Created", System.Data.SqlDbType.DateTime, DateTime.Now);
            //        db.AddParameter("@Update_", System.Data.SqlDbType.TinyInt, DateTime.Now);
            //        db.CommandType = System.Data.CommandType.Text;
            //        db.Open();
            //        db.BeginTransaction();
            //        result = db.ExecuteNonQuery();
            //        db.CommitTransaction();
            //    }
            //    catch (System.Data.SqlClient.SqlException err)
            //    {
            //        if (db.Transaction != null)
            //            db.RollbackTransaction();

            //        switch (err.Number)
            //        {
            //            case 2627:
            //                throw new Exception("Combination of Account Number and Currency data are already exists. Please choose other Account No and Currency.");
            //            default:
            //                throw;
            //        }
            //    }
            //    catch
            //    {
            //        if (db.Transaction != null)
            //            db.RollbackTransaction();

            //        throw;
            //    }
            //    finally
            //    {
            //        db.Close();
            //    }
            //}
            //return result;
        }

        public static int SaveMenuMasterFromList(List<MenuMaster> m)
        {
            int result = 1;
            List<MenuMaster> menuMasters = m;
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Menu");
            string emat_setting_txt = "menumaster.txt";
            string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            try
            {
                using (System.IO.StreamWriter stream = new System.IO.StreamWriter(System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt), false))
                {
                    stream.Write(Newtonsoft.Json.JsonConvert.SerializeObject(menuMasters));
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return result;
        }

        public static bool IsKodeExist(string Kode)
        {
            bool return_ = false;

            List<MenuMaster> menuMasters = MenuMaster.GetMenuMasterForDataSource();
            return_ = menuMasters.Find(r => r.Kode == Kode) == null ? false : true;
            return return_;
        }

        public static int SaveMenuMaster(MenuMaster m)
        {
            int result = 1;
            List<MenuMaster> menuMasters = MenuMaster.GetMenuMasterForDataSource();
            menuMasters.Insert(0, m);
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Menu");
            string emat_setting_txt = "menumaster.txt";
            string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            try
            {
                using (System.IO.StreamWriter stream = new System.IO.StreamWriter(System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt), false))
                {
                    stream.Write(Newtonsoft.Json.JsonConvert.SerializeObject(menuMasters));
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return result;
            //int result = 0;
            //using (IDS.DataAccess.SqlServer db = new IDS.DataAccess.SqlServer())
            //{
            //    try
            //    {
            //        db.CommandText = "insert into MenuMaster(Nama,Kode,Img,Created,[Update],Role) values (@Nama,@Kode,@Img,@Created,@Update_,@Role)";
            //        db.AddParameter("@Nama", System.Data.SqlDbType.VarChar, m.Nama);
            //        db.AddParameter("@Kode", System.Data.SqlDbType.VarChar, m.Kode);
            //        db.AddParameter("@Role", System.Data.SqlDbType.VarChar, m.Role);
            //        db.AddParameter("@Img", System.Data.SqlDbType.VarChar, m.Img);
            //        db.AddParameter("@Created", System.Data.SqlDbType.DateTime, DateTime.Now);
            //        db.AddParameter("@Update_", System.Data.SqlDbType.DateTime, DateTime.Now);
            //        db.CommandType = System.Data.CommandType.Text;
            //        db.Open();
            //        db.BeginTransaction();
            //        result = db.ExecuteNonQuery();
            //        db.CommitTransaction();
            //    }
            //    catch (System.Data.SqlClient.SqlException err)
            //    {
            //        if (db.Transaction != null)
            //            db.RollbackTransaction();

            //        switch (err.Number)
            //        {
            //            case 2627:
            //                throw new Exception("Combination of Account Number and Currency data are already exists. Please choose other Account No and Currency.");
            //            default:
            //                throw;
            //        }
            //    }
            //    catch
            //    {
            //        if (db.Transaction != null)
            //            db.RollbackTransaction();

            //        throw;
            //    }
            //    finally
            //    {
            //        db.Close();
            //    }
            //}
            //return result;
        }

        public static List<MenuMaster> GetMenuMasterForDataSource()
        {
            List<MenuMaster> L = new List<MenuMaster>();
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Menu");
            string emat_setting_txt = "menumaster.txt";

            string jsontext = System.IO.File.ReadAllText(System.IO.Path.Combine(directoryname, emat_setting_txt));
            L = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MenuMaster>>(jsontext);
            return L;
        }

        public static List<MenuMaster> GetMenuMasterForRealView()
        {
            List<MenuMaster> menuMasters = MenuMaster.GetMenuMasterForDataSource();
            var allCorrect = menuMasters.Where(a => a.Active == bool.Parse("true")).ToList();
            return allCorrect;
        }

        public static MenuMaster GetMenuMasterForDataSource(string m)
        {
            List<MenuMaster> menuMasters = MenuMaster.GetMenuMasterForDataSource();
            MenuMaster l = new MenuMaster();
            var b = menuMasters.Where(a => a.Kode==m).FirstOrDefault();
            return b;
        }
           
        public void Create_Initial()
        {
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Menu");
            string emat_setting_txt = "menumaster.txt";
            string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!System.IO.Directory.Exists(System.IO.Path.Combine(GuarnteedWritePath, directoryname)))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(GuarnteedWritePath, directoryname));
            }

            string FilePath = System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt);
            if (!System.IO.File.Exists(FilePath))
            {
                List<MenuMaster> e =MenuMaster.GetMenuMasterForDataSource();
                using (System.IO.FileStream fs = System.IO.File.Create(FilePath))
                {
                    string dataasstring = Newtonsoft.Json.JsonConvert.SerializeObject(e); //your data
                    byte[] info = new System.Text.UTF8Encoding(true).GetBytes(dataasstring);
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }
            }
        }
    }
}
