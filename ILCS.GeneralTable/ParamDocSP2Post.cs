using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILCS.GeneralTable
{
    public class ParamDocSP2Post
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
        public ParamDocSP2Post()
        {

        }

    }

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
}
