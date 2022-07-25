using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILCS.Maintenance
{
   public class Users
    {
        public Users()
        {

        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string UserRolesId { get; set; }
        public bool Active { get; set; }
        public DateTime UserCreated { get; set; }
        public DateTime UserUpdated { get; set; }

        public void Create_Initial()
        {
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Users");
            string emat_setting_txt = "users.txt";
            string GuarnteedWritePath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!System.IO.Directory.Exists(System.IO.Path.Combine(GuarnteedWritePath, directoryname)))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(GuarnteedWritePath, directoryname));
            }

            string FilePath = System.IO.Path.Combine(GuarnteedWritePath, directoryname, emat_setting_txt);
            if (!System.IO.File.Exists(FilePath))
            {
                List<Users> e = Users.UsersForDataSource_First();
                using (System.IO.FileStream fs = System.IO.File.Create(FilePath))
                {
                    string dataasstring = Newtonsoft.Json.JsonConvert.SerializeObject(e); //your data
                    byte[] info = new System.Text.UTF8Encoding(true).GetBytes(dataasstring);
                    fs.Write(info, 0, info.Length);
                    fs.Close();
                }
            }
        }

        public static List<Users> UsersForDataSource_First()
        {
            List<Users> d = new List<Users>();
            d.Add(new Users { Id =1, UserId = "dev", UserName = "dev", UserPass = "dev1234", UserRolesId = "rdev", UserCreated = System.DateTime.Now, UserUpdated = System.DateTime.Now, Active=true });
            return d;
        }

        public static List<Users> UsersForDataSource()
        {
            List<Users> menuChildren = new List<Users>();
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Users");
            string emat_setting_txt = "users.txt";
            string jsontext = System.IO.File.ReadAllText(System.IO.Path.Combine(directoryname, emat_setting_txt));
            menuChildren = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Users>>(jsontext);
            return menuChildren;
        }

        public static Users UserLogin(string userID, string password)
        {
            IDS.Tool.clsCryptho crypt = new IDS.Tool.clsCryptho();
            string passwd = crypt.Encrypt(password, "@Pelindo");
            List<Users> users = Users.UsersForDataSource();
            var b = users.Where(a => a.UserPass == passwd && a.UserId.ToLower()==userID.ToLower()).FirstOrDefault();
            return b;
        }

    }
}
