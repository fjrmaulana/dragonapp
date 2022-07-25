using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILCS.Maintenance
{
   public class MenuChild
    {
        public int id { get; set; }
        public string Nama { get; set; }
        public string Parent { get; set; }
        public string Img { get; set; }
        public string Kode { get; set; }
        public string mlm { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string AreaName { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime Update { get; set; }
        public MenuChild(){}
        //select count(*) from MenuChild where mlm like'%#mgt%'

        public static int GetCountChild(string s)
        {
            List<MenuChild> menuChildren = MenuChild.menuChildrenForDataSource();
            int count = (from item in menuChildren
                         where item.mlm.Contains(s)
                         select item).Count();
            return count;
            //int result = 0;
            //using (IDS.DataAccess.SqlServer db = new IDS.DataAccess.SqlServer())
            //{
            //    db.CommandText = "select count(*) as total from MenuChild where mlm like'%"+s+"%'";
            //    db.CommandType = System.Data.CommandType.Text;
            //    db.Open();
            //    db.ExecuteReader();
            //    using (System.Data.SqlClient.SqlDataReader dr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
            //    {
            //        if (dr.HasRows)
            //        {
            //            dr.Read();
            //            result= FajarProject.Tool.GeneralHelper.NullToInt(dr["total"], 0);
            //        }
            //        if (!dr.IsClosed) dr.Close();
            //    }
            //    db.Close();
            //}
            //return result;
        }

        public static bool IsKodeExist(string Kode)
        {
            List<MenuChild> menuChildren = MenuChild.menuChildrenForDataSource();
            return menuChildren.Find(r => r.Kode == Kode) == null ? false : true;
            //bool return_ = false;
            //using (IDS.DataAccess.SqlServer db = new IDS.DataAccess.SqlServer())
            //{
            //    db.CommandText = "SELECT Kode from MenuChild WHERE Kode=@Kode";
            //    db.AddParameter("@Kode", System.Data.SqlDbType.VarChar, Kode);
            //    db.CommandType = System.Data.CommandType.Text;
            //    db.Open();
            //    db.ExecuteReader();
            //    using (System.Data.SqlClient.SqlDataReader dr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
            //    {
            //        if (dr.HasRows)
            //        {
            //            dr.Read();
            //            return_ = true;
            //        }
            //        else
            //        {
            //            return_ = false;
            //        }
            //        if (!dr.IsClosed) dr.Close();
            //    }
            //    db.Close();
            //}
            //return return_;
        }
        public static List<MenuChild> GetManuChildFromMenuMaster(string menumasterkode)
        {
            List<MenuChild> menuChildren = MenuChild.menuChildrenForDataSource();
            var allCorrect = menuChildren.Where(a => a.Parent==menumasterkode).ToList();
            return allCorrect;
            //List<MenuChild> menuChildren = new List<MenuChild>();
            //using (IDS.DataAccess.SqlServer db = new IDS.DataAccess.SqlServer())
            //{
            //    db.CommandText = "select id,Nama,parent,Img,Kode,mlm,ControllerName,ActionName,AreaName,Created,[Update],Role from MenuChild where parent=@parent";
            //    db.AddParameter("@parent", System.Data.SqlDbType.VarChar,menumasterkode);
            //    db.CommandType = System.Data.CommandType.Text;
            //    db.Open();
            //    db.ExecuteReader();
            //    using (System.Data.SqlClient.SqlDataReader dr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
            //    {
            //        if (dr.HasRows)
            //        {
            //            while (dr.Read())
            //            {
            //                MenuChild m = new MenuChild
            //                {
            //                    ActionName = dr["ActionName"].ToString(),
            //                    AreaName = dr["AreaName"].ToString(),
            //                    ControllerName = dr["ControllerName"].ToString(),
            //                    Created = FajarProject.Tool.GeneralHelper.NullToDateTime(dr["Created"], System.DateTime.Now),
            //                    id = FajarProject.Tool.GeneralHelper.NullToInt(dr["id"], 1),
            //                    Img = dr["Img"].ToString(),
            //                    Kode = dr["Kode"].ToString(),
            //                    mlm = dr["Mlm"].ToString(),
            //                    Nama = dr["Nama"].ToString(),
            //                    Parent = dr["Parent"].ToString(),
            //                    Role = dr["Role"].ToString(),
            //                    Update = FajarProject.Tool.GeneralHelper.NullToDateTime(dr["Update"], System.DateTime.Now)
            //                };
            //                menuChildren.Add(m);
            //            }
            //        }
            //        if (!dr.IsClosed) dr.Close();
            //    }
            //    db.Close();
            //}
            //return menuChildren;
        }
        public static List<MenuChild> menuChildrenForDataSource()
        {
            List<MenuChild> menuChildren = new List<MenuChild>();
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Menu");
            string emat_setting_txt = "menuchild.txt";

            string jsontext = System.IO.File.ReadAllText(System.IO.Path.Combine(directoryname, emat_setting_txt));
            menuChildren = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MenuChild>>(jsontext);
            return menuChildren;
            //List<MenuChild> menuChildren = new List<MenuChild>();
            //using (IDS.DataAccess.SqlServer db = new IDS.DataAccess.SqlServer())
            //{
            //    db.CommandText = "select id,Nama,parent,Img,Kode,mlm,ControllerName,ActionName,AreaName,Created,[Update],Role from MenuChild";
            //    db.CommandType = System.Data.CommandType.Text;
            //    db.Open();
            //    db.ExecuteReader();
            //    using (System.Data.SqlClient.SqlDataReader dr = db.DbDataReader as System.Data.SqlClient.SqlDataReader)
            //    {
            //        if (dr.HasRows)
            //        {
            //            while (dr.Read())
            //            {
            //                MenuChild m = new MenuChild
            //                {
            //                    ActionName = dr["ActionName"].ToString(),
            //                    AreaName = dr["AreaName"].ToString(),
            //                    ControllerName = dr["ControllerName"].ToString(),
            //                    Created = FajarProject.Tool.GeneralHelper.NullToDateTime(dr["Created"], System.DateTime.Now),
            //                    id = FajarProject.Tool.GeneralHelper.NullToInt(dr["id"], 1),
            //                    Img = dr["Img"].ToString(),
            //                    Kode = dr["Kode"].ToString(),
            //                    mlm = dr["Mlm"].ToString(),
            //                    Nama = dr["Nama"].ToString(),
            //                    Parent = dr["Parent"].ToString(),
            //                    Role = dr["Role"].ToString(),
            //                    Update = FajarProject.Tool.GeneralHelper.NullToDateTime(dr["Update"], System.DateTime.Now)
            //                };
            //                menuChildren.Add(m);
            //             }
            //        }
            //        if (!dr.IsClosed) dr.Close();
            //    }
            //    db.Close();
            //}
            //return menuChildren;
        }

        public static MenuChild menuChildrenForDataSource(string m)
        {
            List<MenuChild> menuMasters = MenuChild.menuChildrenForDataSource();
            var b = menuMasters.Where(a => a.Kode == m).FirstOrDefault();
            return b;
        }

        public static int DeleteMenuChild(MenuChild m)
        {
            int result = 1;
            List<MenuChild> menuMasters = MenuChild.menuChildrenForDataSource();
            menuMasters.RemoveAll(x => x.Kode == m.Kode);
            SaveMenuChildFromList(menuMasters);
            return result;
            //using (IDS.DataAccess.SqlServer db = new IDS.DataAccess.SqlServer())
            //{
            //    try
            //    {
            //        db.CommandText = "DELETE FROM MenuChild WHERE Kode=@Kode";
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
            return result;
        }
        public static int UpdateMenuChild(MenuChild m)
        {
            int result = 1;
            List<MenuChild> menuMasters = MenuChild.menuChildrenForDataSource();
            menuMasters.RemoveAll(x => x.Kode == m.Kode);
            menuMasters.Insert(0, m);
            SaveMenuChildFromList(menuMasters);
            return result;
            //using (IDS.DataAccess.SqlServer db = new IDS.DataAccess.SqlServer())
            //{
            //    try
            //    {
            //        db.CommandText = "UPDATE MenuChild SET Nama=@Nama,parent=@parent,Img=@Img,Kode=@Kode,mlm=@mlm,ControllerName=@ControllerName,ActionName=@ActionName,AreaName=@AreaName,Created=@Created,[Update]=@Update_,Role=@Role WHERE Kode=@Kode";
            //        db.AddParameter("@Nama", System.Data.SqlDbType.VarChar, m.Nama);
            //        db.AddParameter("@parent", System.Data.SqlDbType.VarChar, m.Parent);
            //        db.AddParameter("@Img", System.Data.SqlDbType.VarChar, m.Img);
            //        //db.AddParameter("@Kode", System.Data.SqlDbType.VarChar, m.Kode);
            //        db.AddParameter("@mlm", System.Data.SqlDbType.VarChar, m.mlm);
            //        db.AddParameter("@ControllerName", System.Data.SqlDbType.VarChar, m.ControllerName);
            //        db.AddParameter("@ActionName", System.Data.SqlDbType.VarChar, m.ActionName);
            //        db.AddParameter("@AreaName", System.Data.SqlDbType.VarChar, m.AreaName);
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
        public static int SaveMenuChildFromList(List<MenuChild> m)
        {
            int result = 1;
            List<MenuChild> menuMasters = m;
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Menu");
            string emat_setting_txt = "menuchild.txt";
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
        public static int SaveMenuChild(MenuChild m)
        {
            int result = 1;
            List<MenuChild> menuMasters = MenuChild.menuChildrenForDataSource();
            menuMasters.Insert(0, m);
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Menu");
            string emat_setting_txt = "menuchild.txt";
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
            //using (IDS.DataAccess.SqlServer db = new IDS.DataAccess.SqlServer()) {
            //    try
            //    {
            //        db.CommandText = "insert into MenuChild(Nama,parent,Img,Kode,mlm,ControllerName,ActionName,AreaName,Created,[Update],Role) values (@Nama,@parent,@Img,@Kode,@mlm,@ControllerName,@ActionName,@AreaName,@Created,@Update_,@Role)";
            //        db.AddParameter("@Nama", System.Data.SqlDbType.VarChar, m.Nama);
            //        db.AddParameter("@parent", System.Data.SqlDbType.VarChar, m.Parent);
            //        db.AddParameter("@Img", System.Data.SqlDbType.VarChar, m.Img);
            //        db.AddParameter("@Kode", System.Data.SqlDbType.VarChar, m.Kode);
            //        db.AddParameter("@mlm", System.Data.SqlDbType.VarChar, m.mlm);
            //        db.AddParameter("@ControllerName", System.Data.SqlDbType.VarChar, m.ControllerName);
            //        db.AddParameter("@ActionName", System.Data.SqlDbType.VarChar, m.ActionName);
            //        db.AddParameter("@AreaName", System.Data.SqlDbType.VarChar, m.AreaName);
            //        db.AddParameter("@Created", System.Data.SqlDbType.DateTime, DateTime.Now);
            //        db.AddParameter("@Update_", System.Data.SqlDbType.DateTime, DateTime.Now);
            //        db.AddParameter("@Role", System.Data.SqlDbType.VarChar, m.Role);
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

        public void Create_Initial()
        {
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Menu");
            string emat_setting_txt = "menuchild.txt";
            string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!System.IO.Directory.Exists(System.IO.Path.Combine(GuarnteedWritePath, directoryname)))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(GuarnteedWritePath, directoryname));
            }

            string FilePath = System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt);
            if (!System.IO.File.Exists(FilePath))
            {
                List<MenuChild> e = MenuChild.menuChildrenForDataSource();
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
