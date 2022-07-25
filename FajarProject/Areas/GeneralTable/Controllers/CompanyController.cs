using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FajarProject.Areas.GeneralTable.Controllers
{
    public class CompanyController : FajarProject.Controllers.MenuController
    {
        // GET: GeneralTable/Company
        public ActionResult Index()
        {

            if (Session[IDS.Tool.GlobalVariable.SESSION_USER_ID] == null)
                return RedirectToAction("index", "login");

            new FajarProject.GeneralTable.Company().Create_Initial();

            ViewBag.UserId = Session[IDS.Tool.GlobalVariable.SESSION_USER_NAME].ToString();
            ViewBag.UserMenu = new ILCS.Maintenance.MenuTreeview().Get_Access_Menu(Session[IDS.Tool.GlobalVariable.SESSION_USER_ROLE].ToString());
            return View();
        }

        [HttpPost]
        public JsonResult GetData()
        {
            List<FajarProject.GeneralTable.Company> company = FajarProject.GeneralTable.Company.GetCompanyForDataSource();
            return Json(company, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewData["listTypeCompany"] = new SelectList(GetListTypeCompany(), "Value", "Text");
            return PartialView("Create");
        }

        [HttpPost]
        public JsonResult Delete(string custid)
        {
            object o = new { status = "error",data="" };
            if (FajarProject.GeneralTable.Company.DeleteCompany(custid))
            {
                o = new { status = "success", JsonRequestBehavior.AllowGet };
            }
            return Json(o, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Create([System.Web.Http.FromBody] FajarProject.GeneralTable.Company c)
        {
            object o = new { status = "error" };
            if (FajarProject.GeneralTable.Company.SaveCompany(c)) {
                o = new { status = "success" };
            }
            return Json(o, JsonRequestBehavior.AllowGet);
        }

        private List<System.Web.Mvc.SelectListItem> GetListTypeCompany()
        {
            List<System.Web.Mvc.SelectListItem> l = new List<SelectListItem>();
            l.Add(new SelectListItem { Text = "BUMN", Value = "BUMN" });
            l.Add(new SelectListItem { Text = "SWASTA", Value = "SWASTA" });
            l.Add(new SelectListItem { Text = "TNI-POLRI", Value = "TNI-POLRI" });
            return l;
        }

    }
}