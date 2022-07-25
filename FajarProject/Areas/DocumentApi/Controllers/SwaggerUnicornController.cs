using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FajarProject.Areas.DocumentApi.Controllers
{
    public class SwaggerUnicornController : FajarProject.Controllers.MenuController
    {
        // GET: DocumentApi/SwaggerUnicorn
        public ActionResult Index()
        {
            if (Session[IDS.Tool.GlobalVariable.SESSION_USER_ID] == null)
                return RedirectToAction("Index", "login");

            return RedirectToAction("ui/index", "swagger", new { area = "" });//--> Untuk Swagger
        }

        [HttpGet]
        public JsonResult CheckingNetwork()
        {
            object o = new { status = "offline" };
            bool networkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (networkUp)
            {
                o = new { status = "online" };
                return Json(o, JsonRequestBehavior.AllowGet);
            }
            return Json(o, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GenerateId()
        {
            System.Guid guid = System.Guid.NewGuid();
            string dateNya ="optid-"+ System.DateTime.Now.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            object o = new { status = "ok", guid =guid.ToString(),time=dateNya};
            return Json(o, JsonRequestBehavior.AllowGet);
        }
    }
}