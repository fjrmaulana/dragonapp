using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILCS.Maintenance
{
   public class UsersRoles
    {
        public UsersRoles()
        {

        }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleStatus { get; set; }
        public void Create_Initial()
        {
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Users");
            string emat_setting_txt = "roles.txt";
            string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!System.IO.Directory.Exists(System.IO.Path.Combine(GuarnteedWritePath, directoryname)))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(GuarnteedWritePath, directoryname));
            }

            string FilePath = System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt);
            if (!System.IO.File.Exists(FilePath))
            {
                List<UsersRoles> e = UsersRoles.RolesForDataSource_First();
                using (System.IO.FileStream fs = System.IO.File.Create(FilePath))
                {
                    string dataasstring = Newtonsoft.Json.JsonConvert.SerializeObject(e); //your data
                    byte[] info = new System.Text.UTF8Encoding(true).GetBytes(dataasstring);
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }
            }
        }
        public static List<UsersRoles> RolesForDataSource_First()
        {
            List<UsersRoles> d = new List<UsersRoles>();
            d.Add(new UsersRoles { RoleId = "rAdmin", RoleName = "Admin", RoleStatus = true });
            d.Add(new UsersRoles { RoleId = "rUser", RoleName = "User", RoleStatus = true });
            d.Add(new UsersRoles { RoleId = "rMaintenance", RoleName = "Maintenance", RoleStatus = true });
            d.Add(new UsersRoles { RoleId = "rDev", RoleName = "Development", RoleStatus = true });
            return d;
        }

        public static List<UsersRoles> RolesForDataSource()
        {
            List<UsersRoles> menuChildren = new List<UsersRoles>();
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Users");
            string emat_setting_txt = "roles.txt";
            string jsontext = System.IO.File.ReadAllText(System.IO.Path.Combine(directoryname, emat_setting_txt));
            menuChildren = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UsersRoles>>(jsontext);
            return menuChildren;
        }
    }
}
