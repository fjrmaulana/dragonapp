using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using Newtonsoft.Json;

namespace FajarProject.Areas.DocumentApi.Controllers
{
    public class NLEController :FajarProject.Controllers.MenuController
    {
        // GET: DocumentApi/NLE
        public ActionResult Index()
        {
            if (Session[IDS.Tool.GlobalVariable.SESSION_USER_ID] == null)
                return RedirectToAction("index", "login");

            new BaseUrl.Url_().Create_Initial();
            ViewData["TermialList"] = new SelectList(ILCS.GeneralTable.nle_sp2_itgr_HEADER.getTerminalForDatasource(), "Value", "Text","ALL");
            ViewData["bList"] = new SelectList(ILCS.GeneralTable.nle_sp2_itgr_HEADER.getBlistForDatasource(), "Value", "Text", "ALL");
            ViewData["bLimit"] = new SelectList(ILCS.GeneralTable.nle_sp2_itgr_HEADER.GetSelectDropDownLimit(), "Value", "Text", "20");
            ViewData["ApikeyList"] = new SelectList(BaseUrl.Url_.BaseUrlForList(), "Value", "Text");

            ViewBag.UserId = Session[IDS.Tool.GlobalVariable.SESSION_USER_NAME].ToString();
            ViewBag.UserMenu = new ILCS.Maintenance.MenuTreeview().Get_Access_Menu(Session[IDS.Tool.GlobalVariable.SESSION_USER_ROLE].ToString());
            return View();
        }

        // "data": { "terminal": terminal, "blno_": blno, "tglfrom_": tglfrom,"tglto_":tglto,"limit_":limit },
        [HttpPost]
        public JsonResult GetData(string terminal_,string blno_,string tglfrom_,string tglto_,string limit_,string status_sent_)
        {
            string T_FROM = ""; string T_TO = "";
            if (string.IsNullOrEmpty(tglfrom_))
            {
                T_FROM = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                T_FROM = System.Convert.ToDateTime(tglfrom_).ToString("yyyy-MM-dd");
            }
            if (string.IsNullOrEmpty(tglto_))
            {
               T_TO = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
              T_TO = System.Convert.ToDateTime(tglto_).ToString("yyyy-MM-dd");
            }
            string limit = "";
            string query = "";
            if (string.IsNullOrEmpty(limit_)){
                limit = "20";
            }else{
                limit = limit_;
            }
            // terminal
            if (terminal_.ToLower()=="all")
            {
                if (blno_.ToLower() == "all")
                {
                    if (status_sent_.ToLower()=="all")
                    {
                        query = "SELECT BL_NO,NM_CARGOOWNER,PRICE,TERMINAL,STATUS_SENT,MESSAGE_SENT,TO_CHAR(CREATED_DATE,'YYYY-MM-DD HH:MI:SS')CREATED_DATE_,TO_CHAR(SEND_DATE,'YYYY-MM-DD HH:MI:SS')SEND_DATE_ FROM nle_sp2_itgr where CREATED_DATE >= TO_DATE('" + T_FROM + "', 'yyyy-mm-dd') AND CREATED_DATE <= TO_DATE('" + T_TO + "', 'yyyy-mm-dd')+1 FETCH FIRST " + limit + " ROWS ONLY";
                    }
                    else
                    {
                        query = "SELECT BL_NO,NM_CARGOOWNER,PRICE,TERMINAL,STATUS_SENT,MESSAGE_SENT,TO_CHAR(CREATED_DATE,'YYYY-MM-DD HH:MI:SS')CREATED_DATE_,TO_CHAR(SEND_DATE,'YYYY-MM-DD HH:MI:SS')SEND_DATE_ FROM nle_sp2_itgr where CREATED_DATE >= TO_DATE('" + T_FROM + "', 'yyyy-mm-dd') AND CREATED_DATE <= TO_DATE('" + T_TO + "', 'yyyy-mm-dd')+1 AND STATUS_SENT='"+status_sent_+"' FETCH FIRST " + limit + " ROWS ONLY";
                    }
                }
                else
                {
                    if (status_sent_.ToLower() == "all")
                    {
                        query = "SELECT BL_NO,NM_CARGOOWNER,PRICE,TERMINAL,STATUS_SENT,MESSAGE_SENT,TO_CHAR(CREATED_DATE,'YYYY-MM-DD HH:MI:SS')CREATED_DATE_,TO_CHAR(SEND_DATE,'YYYY-MM-DD HH:MI:SS')SEND_DATE_ FROM nle_sp2_itgr where CREATED_DATE >= TO_DATE('" + T_FROM + "', 'yyyy-mm-dd') AND CREATED_DATE <= TO_DATE('" + T_TO + "', 'yyyy-mm-dd')+1 AND BL_NO LIKE'%" + blno_.Trim() + "%' FETCH FIRST " + limit + " ROWS ONLY";
                    }
                    else
                    {
                        query = "SELECT BL_NO,NM_CARGOOWNER,PRICE,TERMINAL,STATUS_SENT,MESSAGE_SENT,TO_CHAR(CREATED_DATE,'YYYY-MM-DD HH:MI:SS')CREATED_DATE_,TO_CHAR(SEND_DATE,'YYYY-MM-DD HH:MI:SS')SEND_DATE_ FROM nle_sp2_itgr where CREATED_DATE >= TO_DATE('" + T_FROM + "', 'yyyy-mm-dd') AND CREATED_DATE <= TO_DATE('" + T_TO + "', 'yyyy-mm-dd')+1 AND BL_NO LIKE'%" + blno_.Trim() + "%' AND STATUS_SENT='"+status_sent_+"' FETCH FIRST " + limit + " ROWS ONLY";
                    }
                }
            }
            else
            {
                if (blno_.ToLower() == "all")
                {
                    if (status_sent_.ToLower() == "all")
                    {
                        query = "SELECT BL_NO,NM_CARGOOWNER,PRICE,TERMINAL,STATUS_SENT,MESSAGE_SENT,TO_CHAR(CREATED_DATE,'YYYY-MM-DD HH:MI:SS')CREATED_DATE_,TO_CHAR(SEND_DATE,'YYYY-MM-DD HH:MI:SS')SEND_DATE_ FROM nle_sp2_itgr WHERE KD_TERMINAL='" + terminal_ + "' AND CREATED_DATE >= TO_DATE('" + T_FROM + "', 'yyyy-mm-dd') AND CREATED_DATE <= TO_DATE('" + T_TO + "', 'yyyy-mm-dd')+1 FETCH FIRST " + limit + " ROWS ONLY";
                    }
                    else
                    {
                        query = "SELECT BL_NO,NM_CARGOOWNER,PRICE,TERMINAL,STATUS_SENT,MESSAGE_SENT,TO_CHAR(CREATED_DATE,'YYYY-MM-DD HH:MI:SS')CREATED_DATE_,TO_CHAR(SEND_DATE,'YYYY-MM-DD HH:MI:SS')SEND_DATE_ FROM nle_sp2_itgr WHERE KD_TERMINAL='" + terminal_ + "' AND CREATED_DATE >= TO_DATE('" + T_FROM + "', 'yyyy-mm-dd') AND CREATED_DATE <= TO_DATE('" + T_TO + "', 'yyyy-mm-dd')+1 AND STATUS_SENT='"+status_sent_+"' FETCH FIRST " + limit + " ROWS ONLY";
                    }
                }
                else
                {
                    if(status_sent_.ToLower() == "all")
                    {
                        query = "SELECT BL_NO,NM_CARGOOWNER,PRICE,TERMINAL,STATUS_SENT,MESSAGE_SENT,TO_CHAR(CREATED_DATE,'YYYY-MM-DD HH:MI:SS')CREATED_DATE_,TO_CHAR(SEND_DATE,'YYYY-MM-DD HH:MI:SS')SEND_DATE_ FROM nle_sp2_itgr WHERE KD_TERMINAL='" + terminal_ + "' AND CREATED_DATE >= TO_DATE('" + T_FROM + "', 'yyyy-mm-dd') AND CREATED_DATE <= TO_DATE('" + T_TO + "', 'yyyy-mm-dd')+1 AND BL_NO LIKE'%" + blno_.Trim() + "%' FETCH FIRST " + limit + " ROWS ONLY";
                    }
                    else
                    {
                        query = "SELECT BL_NO,NM_CARGOOWNER,PRICE,TERMINAL,STATUS_SENT,MESSAGE_SENT,TO_CHAR(CREATED_DATE,'YYYY-MM-DD HH:MI:SS')CREATED_DATE_,TO_CHAR(SEND_DATE,'YYYY-MM-DD HH:MI:SS')SEND_DATE_ FROM nle_sp2_itgr WHERE KD_TERMINAL='" + terminal_ + "' AND CREATED_DATE >= TO_DATE('" + T_FROM + "', 'yyyy-mm-dd') AND CREATED_DATE <= TO_DATE('" + T_TO + "', 'yyyy-mm-dd')+1 AND BL_NO LIKE'%" + blno_.Trim() + "%' AND STATUS_SENT='"+status_sent_+"' FETCH FIRST " + limit + " ROWS ONLY";
                    }
                 
                }

            }

            //SELECT  DISTINCT TO_DATE(CREATED_DATE) AS yesterday_date FROM nle_sp2_itgr
            // SELECT BL_NO,NM_CARGOOWNER,PRICE,TERMINAL,STATUS_SENT,MESSAGE_SENT,CREATED_DATE,SEND_DATE FROM nle_sp2_itgr WHERE CREATED_DATE >= TO_DATE('2020-09-10', 'yyyy-mm-dd') AND CREATED_DATE <= TO_DATE('2020-09-29', 'yyyy-mm-dd');

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
                List<ILCS.GeneralTable.nle_sp2_itgr_HEADER> SSP = ILCS.GeneralTable.nle_sp2_itgr_HEADER.Get_nle_sp2_itgr_HeaderforDatasource(query);

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
                    SSP = SSP.Where(x => x.BL_NO.ToString().ToLower().Contains(searchValueLower) || x.NM_CARGOOWNER.ToString().ToLower().Contains(searchValueLower)).ToList();
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
        public JsonResult Blist(string terminal_,string bl_no_,string from_,string  to_,string  limit_)
        {
            object o = new { status = "error", data = "Hai" };
            string T_FROM = "";  string T_TO = "";
            if (string.IsNullOrEmpty(from_))
            {
                T_FROM = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                T_FROM = System.Convert.ToDateTime(from_).ToString("yyyy-MM-dd");
            }
            if (string.IsNullOrEmpty(to_))
            {
                T_TO = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                T_TO = System.Convert.ToDateTime(to_).ToString("yyyy-MM-dd");
            }
            string limit = "";
            string query = "";
            if (string.IsNullOrEmpty(limit_))
            {
                limit = "20";
            }
            else
            {
                limit = limit_;
            }
            // terminal
            if (terminal_.ToLower() == "all")
            {
                query = "SELECT DISTINCT BL_NO,NM_CARGOOWNER FROM nle_sp2_itgr WHERE CREATED_DATE >= TO_DATE('" + T_FROM + "', 'yyyy-mm-dd') AND CREATED_DATE <= TO_DATE('" + T_TO + "', 'yyyy-mm-dd')+1 FETCH FIRST " + limit + " ROWS ONLY";
            }
            else
            {
                query = "SELECT DISTINCT BL_NO,NM_CARGOOWNER FROM nle_sp2_itgr WHERE KD_TERMINAL='" + terminal_ + "' AND CREATED_DATE >= TO_DATE('" + T_FROM + "', 'yyyy-mm-dd') AND CREATED_DATE <= TO_DATE('" + T_TO + "', 'yyyy-mm-dd')+1 FETCH FIRST " + limit + " ROWS ONLY";
            }
            List<dynamic> Get_List_BlNo_ = ILCS.GeneralTable.nle_sp2_itgr_HEADER.Get_List_BlNo(query);
            if (Get_List_BlNo_.Count>0)
            {
                o = new { status = "success", data = Get_List_BlNo_ };
                return Json(o, JsonRequestBehavior.AllowGet);
            }
            return Json(o, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetDetailData(string bl_no)
        {
            object  o = new { status = "success", data = ILCS.GeneralTable.nle_sp2_itgr_HEADER.Get_Detail_Json(bl_no) };
            return Json(o, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ResenDData([System.Web.Http.FromBody] ILCS.GeneralTable.Lessee_Root lrt)
        {
            object o = new {status="initial",data="" };
            dynamic output = new List<dynamic>();
            //dynamic row = new System.Dynamic.ExpandoObject();

            if (lrt.Lessee.Count>0)
            {
                // pilih base url dan nle-api-key yang akan di gunakan sesuai nama transaksi
                BaseUrl.Url_ Base_Url_with_end_point = BaseUrl.Url_.GetBaseUrlFromTrxName("SaveBookingH2h");

                //Ambil json body dari table nle_sp2_itgr berdasarkan bl-no from List
                foreach (var x in lrt.Lessee)
                {
                    //Ambil json body dari table nle_sp2_itgr berdasarkan bl-no from Item
                    ILCS.GeneralTable.nle_sp2_itgr nle_Sp2_Itgr = ILCS.GeneralTable.nle_sp2_itgr.itgr_from_blno(x.bl_no);

                    //Setelah dapat json body lalu Cetak/Convert sesuaikan dengan model class
                    SaveBookingH2h.SaveBookingH2h_data json_text=Newtonsoft.Json.JsonConvert.DeserializeObject<SaveBookingH2h.SaveBookingH2h_data>(nle_Sp2_Itgr.JSON_TEXT);

                    //Proses Save booking H2h ke server beacukai
                    SaveBookingH2h.Response response = SaveBookingH2h.Response.GetResponse_(json_text, Base_Url_with_end_point.url,Base_Url_with_end_point.kode);

                    // hasil response
                    if (response.status.ToString().ToLower() == "success")
                    {
                        //status sukses
                        //status_sent=1,message_sent= {'id_document_sp2':'e3ba2fa3-d40a-455c-a013-61dc6f6347fe','status':'Success'}
                        ILCS.GeneralTable.nle_sp2_itgr.UpdateStatus("1", Newtonsoft.Json.JsonConvert.SerializeObject(response, Formatting.Indented), x.bl_no);
                        var data = new { blno = x.bl_no, status = response.status, doc = response.id_document_sp2 };
                        output.Add(data);
                    }
                    else
                    {
                        //status gagal
                        ILCS.GeneralTable.nle_sp2_itgr.UpdateStatus("500", Newtonsoft.Json.JsonConvert.SerializeObject(response, Formatting.Indented), x.bl_no);
                    }

                }

                if (output.Count > 0)
                {
                    o = new { sts = "success", data = output };
                    return Json(o, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    o = new { sts = "error", data = output };
                    return Json(o, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(o, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveBaseUrl(string nama,string kode,string url,string status)
        {
            object o = new { status = "success" };
            List<BaseUrl.Url_> baseurl = BaseUrl.Url_.GetForDataSource();
            baseurl.RemoveAll(x => x.nama == nama);
            baseurl.Insert(0, new BaseUrl.Url_ { id = baseurl.Count() + 1, kode = kode, nama = nama, url = url, status = bool.Parse(status), created = System.DateTime.Now, update = System.DateTime.Now });
            BaseUrl.Url_.SaveAllBaseUrl(baseurl);
            return Json(o, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteBaseUrl([System.Web.Http.FromBody] BaseUrl.ApiNama c)
        {
            object o = new { status = "success" };
            List<BaseUrl.Url_> baseurl = BaseUrl.Url_.GetForDataSource();
            foreach (var xx in c.cAu)
            {
                baseurl.RemoveAll(x => x.nama == xx.NamaApi);
            }
            BaseUrl.Url_.SaveAllBaseUrl(baseurl);
            return Json(o, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RefreshbaseUrl()
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
                List<BaseUrl.Url_> SSP = BaseUrl.Url_.GetForDataSource();

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
                    SSP = SSP.Where(x => x.kode.ToString().ToLower().Contains(searchValueLower) || x.nama.ToString().ToLower().Contains(searchValueLower)).ToList();
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

        public JsonResult PostData()
        {
            object o = new { status = "error", data = "" };
            SaveBookingH2h.SaveBookingH2h_data nLE = SaveBookingH2h.SaveBookingH2h_data.GetRoot_Data();
            SaveBookingH2h.Response response = SaveBookingH2h.Response.GetResponse(nLE, "575c8ae3-a185-457a-a6f8-2ce8233ec4ee");
            if (response.status.ToLower().Contains("success"))
            {
                o = new { status = "success", data = response };
                return Json(o, JsonRequestBehavior.AllowGet);
            }
            else
            {
                o = new { status = "error", data = response };
                return Json(o, JsonRequestBehavior.AllowGet);
            }
        }
    }
}