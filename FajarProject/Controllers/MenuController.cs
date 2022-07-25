using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Mvc.Routing;
using System.Web.Mvc.Razor;

namespace FajarProject.Controllers
{
    public class MenuController : Controller
    {
        protected string MainMenu = "";

        public MenuController()
        {
            MainMenu = ParseMenuToHTML();
        }

        public static string ParseMenuToHTML()
        {
            string menuStamp_ = AddMenuStamp();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<ul class=\"nav nav-pills nav-sidebar flex-column nav-child-indent\" data-widget=\"treeview\" role=\"menu\" data-accordion=\"false\">");
            sb.Append(menuStamp_);
            sb.Append("</ul>");
            return sb.ToString();
        }

        private static string GetMenuChildFromMenuMaster(string KodeMenu)
        {
            System.Text.StringBuilder b = new System.Text.StringBuilder();
            List<ILCS.Maintenance.MenuChild> menuChildren = ILCS.Maintenance.MenuChild.GetManuChildFromMenuMaster(KodeMenu);
            foreach (var x in menuChildren)
            {
                b.AppendLine(" <ul class='nav nav-treeview'>");
                b.AppendLine("     <li class='nav-item'>");
                b.AppendLine("         <a href='"+"/"+x.AreaName+"/"+x.ControllerName +"/"+x.ActionName +"' class='nav-link'>");
                b.AppendLine("            <i class='nav-icon "+x.Img+"' style='font-size: 10px;'></i>");
                b.AppendLine("           <p class='font-weight-bold'>"+x.Nama+"</p>");
                b.AppendLine("        </a>");
                b.AppendLine("    </li>");
                b.AppendLine(" </ul>");
            }
            return b.ToString();
        }
        private static string AddMenuStamp()
        {
            List<ILCS.Maintenance.MenuMaster> menuMasters = ILCS.Maintenance.MenuMaster.GetMenuMasterForRealView();
            System.Text.StringBuilder MenuBuilder = new System.Text.StringBuilder();
           
            foreach (var x in menuMasters)
            {
                // MasterManu Start
                MenuBuilder.AppendLine("<li class='nav-item'>");
                MenuBuilder.AppendLine("    <a href='#' class='nav-link'>");
                MenuBuilder.AppendLine("        <i class='"+x.Img+"'></i>");
                MenuBuilder.AppendLine("         <p class='font-weight-bold'>");
                MenuBuilder.AppendLine(x.Nama);
                MenuBuilder.AppendLine("           <i class='fas fa-angle-left right'></i>");
                MenuBuilder.AppendLine("          <span class='badge badge-info right'>"+ ILCS.Maintenance.MenuChild.GetCountChild(x.Kode+"#") +"</span>");
                MenuBuilder.AppendLine("       </p>");
                MenuBuilder.AppendLine("    </a>");

                MenuBuilder.AppendLine(GetMenuChildFromMenuMaster(x.Kode));

                MenuBuilder.AppendLine("</li>");
            }
            return MenuBuilder.ToString();
        }
    }
}