using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FajarProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult index(Models.UserLogin login)
        {
            if (User != null)
            {
                ViewBag.ValidationResult = "";
                bool isValid = false;

                if (string.IsNullOrWhiteSpace(login.UserID) || string.IsNullOrWhiteSpace(login.Password))
                {
                    ViewBag.ValidationResult = "Incorrect user ID or Password";
                    isValid = false;
                }
                else
                {
                  IDS.Tool.clsCryptho crypt = new IDS.Tool.clsCryptho();
                    string encryptPassword = crypt.Encrypt(login.Password.ToLower(), "@Pelindo");
                    ILCS.Maintenance.Users user = ILCS.Maintenance.Users.UserLogin(login.UserID, encryptPassword);
                    if (user != null){
                        if (!user.Active)
                        {
                            ViewBag.ValidationResult = "Your account is not active or has been block. Please contact your administrator.";
                            isValid = false;
                            return View(login);
                        }
                        else
                        {
                            Session[IDS.Tool.GlobalVariable.SESSION_USER_ID] = user.UserId;
                            Session[IDS.Tool.GlobalVariable.SESSION_USER_NAME] = user.UserName;
                            Session[IDS.Tool.GlobalVariable.SESSION_USER_ROLE] = user.UserRolesId;
                            return RedirectToAction("index", "Main");
                        }
                    }
                    else
                    {
                        isValid = false;
                        ViewBag.ValidationResult = "Incorrect user ID or Password";
                        return View(login);
                    }
                }
            }
            return View(login);// update
        }//
    }
}