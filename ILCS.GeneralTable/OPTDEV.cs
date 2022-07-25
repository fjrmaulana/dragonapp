using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILCS.GeneralTable
{
  public  class OPTDEV
    {
        public int person_id { get; set; }
        public string person_name { get; set; }
        public string person_last_name { get; set; }
        public OPTDEV()
        {

        }

        public static int SaveData(OPTDEV oPTDEV)
        {
            int return_ = 0;
            using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
            {
                try
                {
                    db.Open();
                    db.CommandText = "INSERT INTO OPTDEV (PERSON_NAME,PERSON_LAST_NAME) values(:person_name,:person_last_name)";
                    db.AddParameter("person_name", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, oPTDEV.person_name);
                    db.AddParameter("person_last_name", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, oPTDEV.person_last_name);
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