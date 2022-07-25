using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILCS.GeneralTable
{
  public  class nle_sp2_itgr_det
    {
        public string ID { get; set; }
        public string CONTAINER_NO { get; set; }
        public string CONTAINER_SIZE { get; set; }
        public string CONTAINER_TYPE { get; set; }
        public string GETPASS { get; set; }

        public nle_sp2_itgr_det()
        {

        }

        public static int SaveData(nle_sp2_itgr_det s)
        {
            int return_ = 0;
            using (FajarProject.DataAccess.Oracle db = new FajarProject.DataAccess.Oracle())
            {
                try
                {
                    db.Open();
                    db.CommandText = "INSERT INTO NLE_SP2_ITGR_DET(ID, CONTAINER_NO, CONTAINER_SIZE, CONTAINER_TYPE, GATE_PASS)VALUES(:ID, :CONTAINER_NO, :CONTAINER_SIZE, :CONTAINER_TYPE, :GATE_PASS)";
                    db.AddParameter("ID", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.ID);
                    db.AddParameter("CONTAINER_NO", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,s.CONTAINER_NO);
                    db.AddParameter("CONTAINER_SIZE", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2, s.CONTAINER_NO);
                    db.AddParameter("CONTAINER_TYPE", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,s.CONTAINER_TYPE);
                    db.AddParameter("GATE_PASS", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2,s.GETPASS);
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
