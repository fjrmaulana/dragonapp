using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FajarProject.GeneralTable
{
   public class Employee
    {
        public int PERSON_ID { get; set; }
        public int NIPP { get; set; }
        public DateTime DATE_OFF_BIRTH { get; set; }
        public string PRIMARY_EMAIL { get; set; }
        public string POSISI { get; set; }
        public string ORGANISASI_ID { get; set; }
        public string POSITION_ID { get; set; }
        public string LOCATION_ID { get; set; }
        public string ORGANISASI { get; set; }
        public string NAMA { get; set; }
        public DateTime UPDATED { get; set; }
        public int FG_ACTIVE { get; set; }
        public Employee()
        {

        }

        public static List<Employee> GetEmployeeForDataSource()
        {
            List<Employee> l = new List<Employee>();
            try
            {
                using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
                {
                    db.CommandText = "SELECT PERSON_ID,NIPP,DATE_OF_BIRTH,PRIMARY_EMAIL,POSISI,ORGANISASI_ID,POSITION_ID,LOCATION_ID,ORGANISASI,NAMA,UPDATED,FG_ACTIVE FROM TX_EMPLOYEE";
                    db.CommandType = System.Data.CommandType.Text;
                    db.Open();
                    db.ExecuteReader();
                    using (Oracle.ManagedDataAccess.Client.OracleDataReader rdr = db.DbDataReader as Oracle.ManagedDataAccess.Client.OracleDataReader)
                    {
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                Employee emp = new Employee();
                                emp.PERSON_ID = FajarProject.Tool.GeneralHelper.NullToInt(rdr["PERSON_ID"], 0);
                                emp.NIPP = FajarProject.Tool.GeneralHelper.NullToInt(rdr["NIPP"], 0);
                                emp.DATE_OFF_BIRTH = FajarProject.Tool.GeneralHelper.NullToDateTime(rdr["DATE_OF_BIRTH"], System.DateTime.Now);
                                emp.PRIMARY_EMAIL = rdr["PRIMARY_EMAIL"].ToString();
                                emp.POSISI = rdr["POSISI"].ToString();
                                emp.ORGANISASI_ID = rdr["ORGANISASI_ID"].ToString();
                                emp.POSITION_ID = rdr["POSITION_ID"].ToString();
                                emp.LOCATION_ID = rdr["LOCATION_ID"].ToString();
                                emp.ORGANISASI = rdr["ORGANISASI"].ToString();
                                emp.NAMA = rdr["NAMA"].ToString();
                                emp.UPDATED = FajarProject.Tool.GeneralHelper.NullToDateTime(rdr["UPDATED"], System.DateTime.Now);
                                emp.FG_ACTIVE = FajarProject.Tool.GeneralHelper.NullToInt(rdr["FG_ACTIVE"], 0);
                                l.Add(emp);
                            }
                        }
                        if (!rdr.IsClosed) rdr.Close();
                    }
                    db.Close();
                }
              
            }
            catch (Exception ser)
            {
                System.Diagnostics.Debug.WriteLine(ser.Message);
            }
            return l;
        }
    }
}
