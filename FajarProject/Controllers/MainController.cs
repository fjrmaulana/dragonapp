using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FajarProject.Controllers
{
    public class MainController : MenuController
    {
        // GET: Main
        public ActionResult Index()
        {
            if (Session[IDS.Tool.GlobalVariable.SESSION_USER_ID] == null)
                return RedirectToAction("Index", "login");

            new ILCS.Maintenance.UsersRoles().Create_Initial();
            new ILCS.Maintenance.Users().Create_Initial();
            ViewBag.UserId = Session[IDS.Tool.GlobalVariable.SESSION_USER_NAME].ToString();
            ViewBag.UserMenu = new ILCS.Maintenance.MenuTreeview().Get_Access_Menu(Session[IDS.Tool.GlobalVariable.SESSION_USER_ROLE].ToString());
           return View();
        }

        public ActionResult Signout()
        {
            Session[IDS.Tool.GlobalVariable.SESSION_USER_NAME] = null;
            Session[IDS.Tool.GlobalVariable.SESSION_USER_ROLE] = null;
            Session[IDS.Tool.GlobalVariable.SESSION_USER_ID] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Login", new { area = "" });
        }

        [HttpPost]
        public JsonResult GetTotalStatus(string dat,string status_send)
        {
            object o = new { status = "error", count = "0" };
            System.DateTime d = System.DateTime.Now;
            int Month_ = GetMonthNumber_From_MonthName(d.ToString("MMM"));
            int year_ = int.Parse(d.ToString("yyyy"));
            if (!string.IsNullOrEmpty(dat))
            {
                System.DateTime oDate = DateTime.ParseExact(dat, "MMM yyyy", null);
                Month_= GetMonthNumber_From_MonthName(oDate.ToString("MMM"));
                year_ = int.Parse(oDate.ToString("yyyy"));
                o = new { status = "success", count = ILCS.GeneralTable.nle_sp2_itgr_HEADER.GetCount(Month_,year_,status_send) };
                return Json(o, JsonRequestBehavior.AllowGet);
            }
            return Json(o, JsonRequestBehavior.AllowGet);
        }

        public static int GetMonthNumber_From_MonthName(string monthname)
        {
            int monthNumber = 0;
            monthNumber = DateTime.ParseExact(monthname, "MMM", System.Globalization.CultureInfo.CurrentCulture).Month;
            return monthNumber;
        }

    }
}