using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveBookingH2h
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Container
    {
        public string container_no { get; set; }
        public string container_size { get; set; }
        public string container_type { get; set; }
        public string gate_pass { get; set; }
    }

    public class Dokuman
    {
        public string document_no { get; set; }
        public string document_date { get; set; }
        public string document_status { get; set; }
        public string link_document { get; set; }
    }

    public class SaveBookingH2h_data
    {
        public string request_booking_id { get; set; }
        public string platform_booking_id { get; set; }
        public string kd_document_type { get; set; }
        public string npwpCargoOwner { get; set; }
        public string nm_cargoowner { get; set; }
        public string npwp_ppjk { get; set; }
        public string nm_ppjk { get; set; }
        public string no_doc_release { get; set; }
        public string date_doc_release { get; set; }
        public string bl_no { get; set; }
        public string bl_date { get; set; }
        public string id_platform { get; set; }
        public string terminal { get; set; }
        public string port_of_loading { get; set; }
        public string port_of_discharge { get; set; }
        public string pelabuhan { get; set; }
        public string paid_thrud_date { get; set; }
        public string proforma { get; set; }
        public string proforma_date { get; set; }
        public int price { get; set; }
        public string status { get; set; }
        public int is_finished { get; set; }
        public int party { get; set; }
        public string jenis_sp2 { get; set; }
        public string jenis_channel { get; set; }
        public string sppb_no { get; set; }
        public string sppb_date { get; set; }
        public List<Dokuman> dokumen { get; set; }
        public List<Container> container { get; set; }
        public SaveBookingH2h_data()        {        }

        public static SaveBookingH2h_data GetRoot_Data()
        {
           SaveBookingH2h_data e = new SaveBookingH2h_data();
            string directoryname = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/NLE");
            string emat_setting_txt = "data.txt";

            string jsontext = System.IO.File.ReadAllText(System.IO.Path.Combine(directoryname, emat_setting_txt));
            //System.Diagnostics.Debug.WriteLine(jsontext);
            e = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveBookingH2h_data>(jsontext);
            return e;
        }

        public static bool PostData(SaveBookingH2h_data data,string nle_api_key)
        {
            bool return_ = false;
            var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://nlehub.kemenkeu.go.id/nlesp2/v1/sp2/Booking/SaveBooking");
            httpWebRequest.Headers.Add("nle-api-key", nle_api_key);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                streamWriter.Write(json);
            }
            var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
            {
                return_ = true;
                System.Diagnostics.Debug.WriteLine(streamReader.ReadToEnd());
            }
            return return_;
        }


    }

    public class Response
    {
        public string id_document_sp2 { get; set; }
        public string status { get; set; }
        public Response(){}

        public static Response GetResponse(SaveBookingH2h_data data, string nle_api_key)
        {
            Response r = new Response();
            var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://nlehub.kemenkeu.go.id/nlesp2/v1/sp2/Booking/SaveBooking");
            httpWebRequest.Headers.Add("nle-api-key", nle_api_key);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                streamWriter.Write(json);
            }
            var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
            {
                r = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(streamReader.ReadToEnd());
            }
            return r;
        }

        public static Response GetResponse_(SaveBookingH2h_data data, string BaseUrl, string nle_api_key)
        {
            Response r = new Response();
            var httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(BaseUrl);
            httpWebRequest.Headers.Add("nle-api-key", nle_api_key);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new System.IO.StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                streamWriter.Write(json);
            }
            var httpResponse = (System.Net.HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
            {
                r = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(streamReader.ReadToEnd());
            }
            return r;
        }
    }
}