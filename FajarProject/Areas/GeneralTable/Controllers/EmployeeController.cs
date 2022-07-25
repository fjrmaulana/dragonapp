using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace FajarProject.Areas.GeneralTable.Controllers
{
    public class EmployeeController  : FajarProject.Controllers.MenuController
    {
        // GET: GeneralTable/Employee
        public ActionResult Index()
        {
            if (Session[IDS.Tool.GlobalVariable.SESSION_USER_ID] == null)
                return RedirectToAction("index", "login");

            ViewBag.UserId = Session[IDS.Tool.GlobalVariable.SESSION_USER_NAME].ToString();
            ViewBag.UserMenu = new ILCS.Maintenance.MenuTreeview().Get_Access_Menu(Session[IDS.Tool.GlobalVariable.SESSION_USER_ROLE].ToString());
            return View();
        }

        [HttpPost]
        public JsonResult GetData()
        {
            JsonResult result = new JsonResult();
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int totalRecords = 0; // Total keseluruhan data
                int totalRecordsShowing = 0; // Total data setelah filter / search
                List<FajarProject.GeneralTable.Employee> SSP = FajarProject.GeneralTable.Employee.GetEmployeeForDataSource();

                totalRecords = SSP.Count;

                // Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    switch (sortColumn.ToLower())
                    {
                        default:
                            SSP = SSP.OrderBy(sortColumn + " " + sortColumnDir).ToList();
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    string searchValueLower = searchValue.ToLower();
                    SSP = SSP.Where(x => x.NIPP.ToString().ToLower().Contains(searchValueLower) || x.NAMA.ToString().Contains(searchValueLower)).ToList();
                }

                totalRecordsShowing = SSP.Count();

                // Paging
                SSP = SSP.Skip(skip).Take(pageSize).ToList();

                // Returning Json Data
                result = this.Json(new { recordsFiltered = totalRecordsShowing, recordsTotal = totalRecords, data = SSP }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception er)
            {
                System.Diagnostics.Debug.WriteLine(er.Message);
            }
            return result;
        }
    }
    
}