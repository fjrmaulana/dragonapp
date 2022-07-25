using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace FajarProject.Areas.Maintenance.Controllers
{
    public class MenuMasterController : FajarProject.Controllers.MenuController
    {
        // GET: Maintenance/MenuMaster
        public ActionResult Index()
        {
            if (Session[IDS.Tool.GlobalVariable.SESSION_USER_ID] == null)
                return RedirectToAction("index", "login");

            ViewBag.UserId = Session[IDS.Tool.GlobalVariable.SESSION_USER_NAME].ToString();
            ViewBag.UserMenu = new ILCS.Maintenance.MenuTreeview().Get_Access_Menu(Session[IDS.Tool.GlobalVariable.SESSION_USER_ROLE].ToString());
            return View();
        }
        [HttpPost]
        public JsonResult GetDataChild()
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
                List<ILCS.Maintenance.MenuChild> SSP = ILCS.Maintenance.MenuChild.menuChildrenForDataSource();

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
                    SSP = SSP.Where(x => x.Kode.ToString().ToLower().Contains(searchValueLower) || x.Nama.ToString().Contains(searchValueLower)).ToList();
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
        [HttpPost]
        public JsonResult GetDataMaster()
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
                List<ILCS.Maintenance.MenuMaster> SSP = ILCS.Maintenance.MenuMaster.GetMenuMasterForDataSource();

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
                    SSP = SSP.Where(x => x.Kode.ToString().ToLower().Contains(searchValueLower) || x.Nama.ToString().Contains(searchValueLower)).ToList();
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

        [HttpPost]
        public JsonResult CreateMaster([System.Web.Http.FromBody]  ILCS.Maintenance.MenuMaster menuMaster )
        {
            object o = new { status = "success",msg="Kode "+menuMaster.Kode+" Hasbeen Saved" };
            if (ILCS.Maintenance.MenuMaster.IsKodeExist(menuMaster.Kode))
            {
                o = new { status = "error",msg="Kode:"+ menuMaster.Kode +" Already Exists!" };
                return Json(o, JsonRequestBehavior.AllowGet);
            }

            int ret = ILCS.Maintenance.MenuMaster.SaveMenuMaster(menuMaster);
            if (ret>0)
            {
                o = new { status = "success", msg = "Kode " + menuMaster.Kode + " Hasbeen Saved" };
                return Json(o, JsonRequestBehavior.AllowGet);
            }

            return Json(o, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateChild([System.Web.Http.FromBody] ILCS.Maintenance.MenuChild child)
        {
            object o = new { status = "success", msg = "Kode " + child.Kode + " Hasbeen Saved" };
            if (ILCS.Maintenance.MenuChild.IsKodeExist(child.Kode))
            {
                o = new { status = "error", msg = "Kode:" + child.Kode + " Already Exists!" };
                return Json(o, JsonRequestBehavior.AllowGet);
            }

            int ret = ILCS.Maintenance.MenuChild.SaveMenuChild(child);
            if (ret > 0)
            {
                o = new { status = "success", msg = "Kode " + child.Kode + " Hasbeen Saved" };
                return Json(o, JsonRequestBehavior.AllowGet);
            }

            return Json(o, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteMaster(string kode)
        {
            object o = new { status = "error" };
            ILCS.Maintenance.MenuMaster menuMaster = ILCS.Maintenance.MenuMaster.GetMenuMasterForDataSource(kode);
            int ret = ILCS.Maintenance.MenuMaster.DeleteMenuMaster(menuMaster);
            if (ret>0)
            {
                o = new { status = "success" };
                return Json(o, JsonRequestBehavior.AllowGet);
            }
            return Json(o, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteChild(string kode)
        {
            object o = new { status = "error" };
            ILCS.Maintenance.MenuChild menuChild = ILCS.Maintenance.MenuChild.menuChildrenForDataSource(kode);
            int ret = ILCS.Maintenance.MenuChild.DeleteMenuChild(menuChild);
            if (ret > 0)
            {
                o = new { status = "success" };
                return Json(o, JsonRequestBehavior.AllowGet);
            }
            return Json(o, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetList()
        {
            object o = new { status = "error" };
            List<dynamic> kodemaster = new List<dynamic>();
            List< ILCS.Maintenance.MenuMaster> menuMaster = ILCS.Maintenance.MenuMaster.GetMenuMasterForDataSource();
            foreach (var x in menuMaster) {
                var masteritem = new{Id = x.Kode,Name = x.Nama+" - "+x.Kode};
                kodemaster.Add(masteritem);
            }

            List<dynamic> kodechild = new List<dynamic>();
            List<ILCS.Maintenance.MenuChild> mc = ILCS.Maintenance.MenuChild.menuChildrenForDataSource();
            foreach (var x in mc)
            {
                var masteritem = new { mlm = x.mlm, Name = x.Nama+" - "+x.mlm };
                kodechild.Add(masteritem);
            }

            List<string> ilist = new List<string>();
            List<ILCS.Maintenance.FaIcons> fi = ILCS.Maintenance.FaIcons.GetFaiconforDataSource();
            foreach (var x in fi)
            {
                ilist.Add(x.Far_fa_circle);
                ilist.Add(x.Far_fa_circle);
                ilist.Add(x.fas_fa_box);
            }
            o = new {status="sukses",master=kodemaster,child=kodechild,icon= ilist };

            return Json(o, JsonRequestBehavior.AllowGet);
        }
    }
}