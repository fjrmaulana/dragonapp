using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILCS.GeneralTable
{
    public class nle_sp2_itgr
    {
        public string ID { get; set; }
        public string TIPE { get; set; }
        public string KD_TERMINAL { get; set; }
        public string KD_DOCUMENT_TYPE { get; set; }
        public string NPWPCARGOOWNER { get; set; }
        public string NM_CARGOOWNER { get; set; }
        public string DOCUMENT_NO { get; set; }
        public string NO_DOC_RELEASE { get; set; }
        public string DATE_DOC_RELEASE { get; set; }
        public string DOCUMENT_STATUS { get; set; }
        public string BL_NO { get; set; }
        public string BL_DATE { get; set; }
        public string ID_PLATFORM { get; set; }
        public string TERMINAL { get; set; }
        public string PAID_THRUD_DATE { get; set; }
        public string PROFORMA { get; set; }
        public string PROFORMA_DATE { get; set; }
        public string PRICE { get; set; }
        public string STATUS { get; set; }
        public string IS_FINISHED { get; set; }
        public string PARTY { get; set; }
        public string JSON_TEXT { get; set; }
        public string STATUS_SENT { get; set; }
        public string MESSAGE_SENT { get; set; }
        public string DOCUMENT_DATE { get; set; }
        public System.DateTime CREATE_DATE { get; set; }
        public System.DateTime SEND_DATE { get; set; }
        public nle_sp2_itgr() { }

        public static List<nle_sp2_itgr> Get_nle_sp2_itgr_forDatasource()
        {
            List<nle_sp2_itgr> l = new List<nle_sp2_itgr>();
            using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
            {
                db.CommandText = "SELECT ID,TIPE,KD_TERMINAL,KD_DOCUMENT_TYPE,NPWPCARGOOWNER,NM_CARGOOWNER,DOCUMENT_NO,NO_DOC_RELEASE,DATE_DOC_RELEASE,DOCUMENT_STATUS,BL_NO,BL_DATE,ID_PLATFORM,TERMINAL,PAID_THRUD_DATE,PROFORMA,PROFORMA_DATE,PRICE,STATUS,IS_FINISHED,PARTY,JSON_TEXT,STATUS_SENT,MESSAGE_SENT,DOCUMENT_DATE,CREATED_DATE,SEND_DATE FROM nle_sp2_itgr FETCH FIRST 5 ROWS ONLY";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader rdr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            nle_sp2_itgr sp2 = new nle_sp2_itgr();
                            sp2.MESSAGE_SENT = rdr["MESSAGE_SENT"].ToString();
                            sp2.BL_DATE = rdr["BL_DATE"].ToString();
                            sp2.BL_NO = rdr["BL_NO"].ToString();
                            sp2.DATE_DOC_RELEASE = rdr["DATE_DOC_RELEASE"].ToString();
                            sp2.DOCUMENT_DATE = rdr["DOCUMENT_DATE"].ToString();
                            sp2.DOCUMENT_NO = rdr["DOCUMENT_NO"].ToString();
                            sp2.DOCUMENT_STATUS = rdr["DOCUMENT_STATUS"].ToString();
                            sp2.ID = rdr["ID"].ToString();
                            sp2.ID_PLATFORM = rdr["ID_PLATFORM"].ToString();
                            sp2.IS_FINISHED = rdr["IS_FINISHED"].ToString();
                            sp2.JSON_TEXT = rdr["JSON_TEXT"].ToString();
                            sp2.KD_DOCUMENT_TYPE = rdr["KD_DOCUMENT_TYPE"].ToString();
                            sp2.KD_TERMINAL = rdr["KD_TERMINAL"].ToString();
                            sp2.NM_CARGOOWNER = rdr["NM_CARGOOWNER"].ToString();
                            sp2.NO_DOC_RELEASE = rdr["NO_DOC_RELEASE"].ToString();
                            sp2.NPWPCARGOOWNER = rdr["NPWPCARGOOWNER"].ToString();
                            sp2.PAID_THRUD_DATE = rdr["PAID_THRUD_DATE"].ToString();
                            sp2.PARTY = rdr["PARTY"].ToString();
                            sp2.PRICE = rdr["PRICE"].ToString();
                            sp2.PROFORMA = rdr["PROFORMA"].ToString();
                            sp2.PROFORMA_DATE = rdr["PROFORMA_DATE"].ToString();
                            sp2.STATUS = rdr["STATUS"].ToString();
                            sp2.STATUS_SENT = rdr["STATUS_SENT"].ToString();
                            sp2.TERMINAL = rdr["TERMINAL"].ToString();
                            sp2.TIPE = rdr["TIPE"].ToString();
                            l.Add(sp2);
                        }
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return l;
        }

        public static nle_sp2_itgr itgr_from_blno(string bl_no)
        {
            nle_sp2_itgr return_ = new nle_sp2_itgr();
            using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
            {
                db.CommandText = "SELECT ID,TIPE,KD_TERMINAL,KD_DOCUMENT_TYPE,NPWPCARGOOWNER,NM_CARGOOWNER,DOCUMENT_NO,NO_DOC_RELEASE,DATE_DOC_RELEASE,DOCUMENT_STATUS,BL_NO,BL_DATE,ID_PLATFORM,TERMINAL,PAID_THRUD_DATE,PROFORMA,PROFORMA_DATE,PRICE,STATUS,IS_FINISHED,PARTY,JSON_TEXT,STATUS_SENT,MESSAGE_SENT,DOCUMENT_DATE,CREATED_DATE,SEND_DATE FROM nle_sp2_itgr WHERE BL_NO='"+bl_no+"' FETCH FIRST 1 ROWS ONLY";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader rdr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        return_.MESSAGE_SENT = rdr["MESSAGE_SENT"].ToString();
                        return_.BL_DATE = rdr["BL_DATE"].ToString();
                        return_.BL_NO = rdr["BL_NO"].ToString();
                        return_.DATE_DOC_RELEASE = rdr["DATE_DOC_RELEASE"].ToString();
                        return_.DOCUMENT_DATE = rdr["DOCUMENT_DATE"].ToString();
                        return_.DOCUMENT_NO = rdr["DOCUMENT_NO"].ToString();
                        return_.DOCUMENT_STATUS = rdr["DOCUMENT_STATUS"].ToString();
                        return_.ID = rdr["ID"].ToString();
                        return_.ID_PLATFORM = rdr["ID_PLATFORM"].ToString();
                        return_.IS_FINISHED = rdr["IS_FINISHED"].ToString();
                        return_.JSON_TEXT = rdr["JSON_TEXT"].ToString();
                        return_.KD_DOCUMENT_TYPE = rdr["KD_DOCUMENT_TYPE"].ToString();
                        return_.KD_TERMINAL = rdr["KD_TERMINAL"].ToString();
                        return_.NM_CARGOOWNER = rdr["NM_CARGOOWNER"].ToString();
                        return_.NO_DOC_RELEASE = rdr["NO_DOC_RELEASE"].ToString();
                        return_.NPWPCARGOOWNER = rdr["NPWPCARGOOWNER"].ToString();
                        return_.PAID_THRUD_DATE = rdr["PAID_THRUD_DATE"].ToString();
                        return_.PARTY = rdr["PARTY"].ToString();
                        return_.PRICE = rdr["PRICE"].ToString();
                        return_.PROFORMA = rdr["PROFORMA"].ToString();
                        return_.PROFORMA_DATE = rdr["PROFORMA_DATE"].ToString();
                        return_.STATUS = rdr["STATUS"].ToString();
                        return_.STATUS_SENT = rdr["STATUS_SENT"].ToString();
                        return_.TERMINAL = rdr["TERMINAL"].ToString();
                        return_.TIPE = rdr["TIPE"].ToString();
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return return_;
        }

        public static void UpdateStatus(string STATUS_SENT ,string MESSAGE_SENT,string BL_NO)
        {
            using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
            {
                try {
                    db.Open();
                    db.CommandText = "UPDATE NLE_SP2_ITGR SET STATUS_SENT=:STATUS_SENT, MESSAGE_SENT=:MESSAGE_SENT WHERE BL_NO=:BL_NO";
                    db.AddParameter("STATUS_SENT", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,STATUS_SENT);
                    db.AddParameter("MESSAGE_SENT", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,MESSAGE_SENT);
                    db.AddParameter("BL_NO", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, BL_NO);
                    db.CommandType = System.Data.CommandType.Text;
                    db.BeginTransaction();
                    db.ExecuteNonQuery();
                    db.CommitTransaction();
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException e)
                {
                    if (db.Transaction != null)
                        db.RollbackTransaction();
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
                catch
                {
                    if (db.Transaction != null)
                        db.RollbackTransaction();

                    throw;
                }
                finally
                {
                    db.Close();
                }
            }
        }
        
        public static int SaveData(nle_sp2_itgr nle_Sp2_Itgr_)
        {
            int return_ = 0;
            using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
            {
                try
                {
                    db.Open();
                    db.CommandText = "INSERT INTO NLE_SP2_ITGR(ID, TIPE, KD_TERMINAL, KD_DOCUMENT_TYPE, NPWPCARGOOWNER, NM_CARGOOWNER, DOCUMENT_NO, NO_DOC_RELEASE, DATE_DOC_RELEASE, DOCUMENT_STATUS, BL_NO, BL_DATE, ID_PLATFORM, TERMINAL, PAID_THRUD_DATE, PROFORMA, PROFORMA_DATE, PRICE, STATUS, IS_FINISHED, PARTY, JSON_TEXT, STATUS_SENT, MESSAGE_SENT, DOCUMENT_DATE, CREATED_DATE, SEND_DATE)VALUES(:id_, :tipe_, :kd_terminal_, :kd_document_type_, :npwpcargoowner_, :nm_cargoowner_, :document_no_, :no_doc_release_, :date_doc_release_, :document_status_, :bl_no_, :bl_date_, :id_platform_, :terminal_, :paid_thrud_date_, :proforma_, :proforma_date, :price_, :status_, :is_finished_, :party_, :json_text, :status_sent_, :message_sent_, :document_date, SYSDATE, :send_date_)";
                    db.AddParameter("id_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.ID);
                    db.AddParameter("tipe_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.TIPE);
                    db.AddParameter("kd_terminal_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.KD_TERMINAL);
                    db.AddParameter("kd_document_type", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.KD_DOCUMENT_TYPE);
                    db.AddParameter("npwpcargoowner_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.NPWPCARGOOWNER);
                    db.AddParameter("nm_cargoowner_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.NM_CARGOOWNER);
                    db.AddParameter("document_no_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.DOCUMENT_NO);
                    db.AddParameter("no_doc_release_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.NO_DOC_RELEASE);
                    db.AddParameter("date_doc_release_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.DATE_DOC_RELEASE);
                    db.AddParameter("document_status_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.DOCUMENT_STATUS);
                    db.AddParameter("bl_no_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.BL_NO);
                    db.AddParameter("bl_date_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.BL_DATE);
                    db.AddParameter("id_platform_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.ID_PLATFORM);
                    db.AddParameter("terminal_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.TERMINAL);
                    db.AddParameter("paid_thrud_date_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.PAID_THRUD_DATE);
                    db.AddParameter("proforma_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.PROFORMA);
                    db.AddParameter("proforma_date_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.PROFORMA_DATE);
                    db.AddParameter("price_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.PRICE);
                    db.AddParameter("status_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.STATUS);
                    db.AddParameter("is_finished_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.IS_FINISHED);
                    db.AddParameter("party_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.PARTY);
                    db.AddParameter("json_text_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.JSON_TEXT);
                    db.AddParameter("status_sent_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.STATUS_SENT);
                    db.AddParameter("message_sent_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.MESSAGE_SENT);
                    db.AddParameter("document_date_", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, nle_Sp2_Itgr_.DOCUMENT_DATE);
                    db.AddParameter("send_date_", Oracle.ManagedDataAccess.Client.OracleDbType.Date, nle_Sp2_Itgr_.SEND_DATE);
                    db.CommandType = System.Data.CommandType.Text;
                    db.BeginTransaction();
                    return_ = db.ExecuteNonQuery();
                    db.CommitTransaction();
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException e)
                {
                    if (db.Transaction != null)
                        db.RollbackTransaction();
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }
                catch
                {
                    if (db.Transaction != null)
                        db.RollbackTransaction();

                    throw;
                }
                finally
                {
                    db.Close();
                }
            }
            return return_;
        }
    }
}

namespace ILCS.GeneralTable
{
    public class nle_sp2_itgr_HEADER
    {
        public string BL_NO { get; set; }
        public string NM_CARGOOWNER { get; set; }
        public decimal PRICE { get; set; }
        public string TERMINAL { get; set; }
        public string STATUS_SENT { get; set; }
        public string MESSAGE_SENT { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public System.DateTime SEND_DATE { get; set; }
        public nle_sp2_itgr_HEADER() { }

        public static List<System.Web.Mvc.SelectListItem> getTerminalForDatasource()
        {
            List<System.Web.Mvc.SelectListItem> groups = new List<System.Web.Mvc.SelectListItem>();

            using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
            {
                db.CommandText = "SELECT DISTINCT KD_TERMINAL,TERMINAL FROM nle_sp2_itgr ORDER BY KD_TERMINAL";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader dr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            System.Web.Mvc.SelectListItem item = new System.Web.Mvc.SelectListItem();
                            var valnya = FajarProject.Tool.GeneralHelper.NullToString(dr["KD_TERMINAL"]);
                            var textNya = FajarProject.Tool.GeneralHelper.NullToString(dr["TERMINAL"]);
                            item.Value = valnya;
                            item.Text = textNya + " - " + valnya;
                            groups.Add(item);
                        }
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
                db.Close();
            }
            groups.Insert(0, new System.Web.Mvc.SelectListItem { Text = "ALL", Value = "ALL" });
            return groups;
        }

        public static List<System.Web.Mvc.SelectListItem> GetSelectDropDownLimit()
        {
            List<System.Web.Mvc.SelectListItem> groups = new List<System.Web.Mvc.SelectListItem>();
            groups.Add(new System.Web.Mvc.SelectListItem { Text = "20", Value = "20" });
            groups.Add(new System.Web.Mvc.SelectListItem { Text = "50", Value = "50" });
            groups.Add(new System.Web.Mvc.SelectListItem { Text = "100", Value = "100" });
            groups.Add(new System.Web.Mvc.SelectListItem { Text = "500", Value = "500" });
            groups.Add(new System.Web.Mvc.SelectListItem { Text = "1000", Value = "1000" });
            groups.Add(new System.Web.Mvc.SelectListItem { Text = "1000", Value = "5000" });
            groups.Add(new System.Web.Mvc.SelectListItem { Text = "1000", Value = "10000" });
            return groups;
        }

        public static List<System.Web.Mvc.SelectListItem> getBlistForDatasource()
        {
            List<System.Web.Mvc.SelectListItem> groups = new List<System.Web.Mvc.SelectListItem>();

            using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
            {
                db.CommandText = "SELECT DISTINCT BL_NO,NM_CARGOOWNER FROM nle_sp2_itgr ORDER BY BL_NO FETCH FIRST 100 ROWS ONLY";
                //db.CommandText = "SELECT DISTINCT BL_NO,NM_CARGOOWNER FROM nle_sp2_itgr WHERE BL_NO IS NOT NULL AND NM_CARGOOWNER IS NOT NULL FETCH FIRST 5 ROWS ONLY";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader dr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            System.Web.Mvc.SelectListItem item = new System.Web.Mvc.SelectListItem();
                            var v_ = FajarProject.Tool.GeneralHelper.NullToString(dr["BL_NO"]);
                            var t_ = FajarProject.Tool.GeneralHelper.NullToString(dr["NM_CARGOOWNER"]);
                            item.Value = v_;
                            item.Text = v_ + " - " + t_;
                            groups.Add(item);
                        }
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
                db.Close();
            }
            groups.Insert(0, new System.Web.Mvc.SelectListItem { Text = "ALL", Value = "ALL" });
            return groups;
        }

        public static List<dynamic> Get_List_BlNo(string query)
        {
            List<dynamic> l = new List<dynamic>();
            using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
            {
                db.CommandText = query;
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader dr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var v_ = FajarProject.Tool.GeneralHelper.NullToString(dr["BL_NO"]);
                            var t_ = FajarProject.Tool.GeneralHelper.NullToString(dr["NM_CARGOOWNER"]);
                            var blno_item = new { blno = v_, nm_cargoowner = v_ + " - " + t_ };
                            l.Add(blno_item);
                        }
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
                db.Close();
            }
            l.Insert(0, new { blno = "ALL", nm_cargoowner = "ALL" });
            return l;
        }
        public static List<nle_sp2_itgr_HEADER> Get_nle_sp2_itgr_HeaderforDatasource(string query)
        {
            List<nle_sp2_itgr_HEADER> l = new List<nle_sp2_itgr_HEADER>();
            using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
            {
                db.CommandText = query;
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader rdr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            nle_sp2_itgr_HEADER sp2 = new nle_sp2_itgr_HEADER
                            {
                                CREATED_DATE = FajarProject.Tool.GeneralHelper.NullToDateTime(rdr["CREATED_DATE_"], System.DateTime.Now),
                                BL_NO = FajarProject.Tool.GeneralHelper.NullToString(rdr["BL_NO"]),
                                MESSAGE_SENT = FajarProject.Tool.GeneralHelper.NullToString(rdr["MESSAGE_SENT"]),
                                NM_CARGOOWNER = FajarProject.Tool.GeneralHelper.NullToString(rdr["NM_CARGOOWNER"]),
                                PRICE = FajarProject.Tool.GeneralHelper.NullToDecimal(rdr["PRICE"], 0),
                                SEND_DATE = FajarProject.Tool.GeneralHelper.NullToDateTime(rdr["SEND_DATE_"], System.DateTime.Now),
                                STATUS_SENT = FajarProject.Tool.GeneralHelper.NullToString(rdr["STATUS_SENT"]),
                                TERMINAL = FajarProject.Tool.GeneralHelper.NullToString(rdr["TERMINAL"])
                            };
                            l.Add(sp2);
                        }
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return l;
        }

        public static string Get_Detail_Json(string bl_no)
        {
            string l = "";
            using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
            {
                db.CommandText = "SELECT JSON_TEXT FROM nle_sp2_itgr WHERE BL_NO LIKE '%" + bl_no.Trim() + "%' ORDER BY BL_NO FETCH FIRST 1 ROWS ONLY";
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader dr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        l = dr["JSON_TEXT"].ToString();// FajarProject.Tool.GeneralHelper.NullToString(dr["BL_NO"]);
                    }
                    if (!dr.IsClosed)
                        dr.Close();
                }
                db.Close();
            }
            return l;
        }//

        public static int GetCount(int mont, int yer, string status_sent)
        {
            int return_ = 0;
            string sql = "SELECT COUNT(CREATED_DATE) as COUNT FROM NLE_SP2_ITGR WHERE EXTRACT(MONTH from CREATED_DATE) =" + mont + " and EXTRACT(YEAR from CREATED_DATE) =" + yer + " AND STATUS_SENT ='" + status_sent + "' ORDER BY CREATED_DATE";
            //System.Diagnostics.Debug.WriteLine(sql);
            using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
            {
                //db.CommandText = "SELECT COUNT(*) as COUNT FROM NLE_SP2_ITGR WHERE EXTRACT(MONTH from CREATED_DATE) =@month and EXTRACT(YEAR from CREATED_DATE) =@year AND STATUS_SENT =@status;";
                //db.CommandText = "SELECT COUNT(*) as COUNT FROM NLE_SP2_ITGR WHERE EXTRACT(MONTH from CREATED_DATE) ="+mont+" and EXTRACT(YEAR from CREATED_DATE) ="+yer+" AND STATUS_SENT ='"+status_sent+"';";
                db.CommandText = sql;

                //db.CommandText = "SELECT COUNT(*) as COUNT FROM NLE_SP2_ITGR WHERE EXTRACT(MONTH from CREATED_DATE) =" + mont + " and EXTRACT(YEAR from CREATED_DATE) =" + yer + " AND STATUS_SENT ='" + status_sent + "';";

                //db.AddParameter("@month",Oracle.ManagedDataAccess.Client.OracleDbType.Int16, mont);
                //db.AddParameter("@year", Oracle.ManagedDataAccess.Client.OracleDbType.Int16, yer);
                //db.AddParameter("@status", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, status_sent);
                db.CommandType = System.Data.CommandType.Text;
                db.Open();
                db.ExecuteReader();
                using (Oracle.ManagedDataAccess.Client.OracleDataReader rdr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                {
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        return_ = FajarProject.Tool.GeneralHelper.NullToInt(rdr["COUNT"], 0);
                    }
                    if (!rdr.IsClosed) rdr.Close();
                }
                db.Close();
            }
            return return_;
        }
    }

    public class Lessee
    {
        public string bl_no { get; set; }
    }

    public class Lessee_Root
    {
        public List<Lessee> Lessee { get; set; }
    }
}

