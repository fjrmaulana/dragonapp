using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace FajarProject.DataAccess
{
   public class Oracle:AbsractOracle
   {
        public System.Data.CommandType CommandType
        {
            get { return DbCommand.CommandType; }
            set
            {
                DbCommand.CommandType = value;
            }
        }
        public string CommandText
        {
            get { return DbCommand.CommandText; }
            set
            {
                DbCommand.CommandText = value;
            }
        }

        //public string 

        public Oracle()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConn"].ConnectionString;
            DbConnection = new OracleConnection(ConnectionString);
            DbCommand = new OracleCommand();
            DbCommand = DbConnection.CreateCommand();
            DbCommand.Connection = DbConnection;
            DbCommand.Transaction = Trx;
        }

        public Oracle(string mConnectionString)
        {
            ConnectionString = mConnectionString;
            DbConnection = new OracleConnection(ConnectionString);
            DbCommand = new OracleCommand();
            DbCommand.Connection = DbConnection;
            Transaction = (OracleTransaction)DbConnection.BeginTransaction();

            //ConnectionString = mConnectionString;
            //DbConnection = new OracleConnection(ConnectionString);
            //DbCommand = new OracleCommand();
            //DbCommand.Connection = DbConnection;
            //Transaction = (OracleTransaction)DbConnection.BeginTransaction();
        }

        public void AddParameter(OracleParameter param)
        {
            DbCommand.Parameters.Add(param);
        }
        public void AddParameterRange(OracleParameter[] param)
        {
            if (param != null && param.Count() > 0)
            {
                for (int i = 0; i < param.Count(); i++)
                {
                    DbCommand.Parameters.Add(param[i]);
                }
            }
        }
        public void AddParameter(string paramName, OracleDbType sqlDbType, object value)
        {
            OracleParameter param = new OracleParameter();
            param.ParameterName = paramName;
            param.OracleDbType = (OracleDbType) sqlDbType;
            param.Value = value;

            if (DbCommand.Parameters.Contains(paramName))
                return;
            DbCommand.Parameters.Add(param);
        }
        public void AddParameter(string paramName, OracleDbType sqlDbType, object value, bool isNullable)
        {
            OracleParameter param = new OracleParameter();
            param.ParameterName = paramName;
            param.OracleDbType = sqlDbType;
            param.IsNullable = isNullable;
            param.Value = value;

            if (DbCommand.Parameters.Contains(paramName))
                return;
            DbCommand.Parameters.Add(param);
        }

        public void AddParameter(string paramName, OracleDbType sqlDbType, bool isNullable, int size, System.Data.ParameterDirection paramDirection)
        {
            OracleParameter param = new OracleParameter();
            param.ParameterName = paramName;
            param.OracleDbType = sqlDbType;
            param.Size = size;
            param.IsNullable = isNullable;
            param.Direction=paramDirection;

            if (DbCommand.Parameters.Contains(paramName))
                return;
            DbCommand.Parameters.Add(param);
        }

        public void AddParameter(string paramName, OracleDbType sqlDbType, int size, System.Data.ParameterDirection direction)
        {
            OracleParameter param = new OracleParameter();
            param.ParameterName = paramName;
            param.OracleDbType = sqlDbType;
            param.Size = size;
            param.Direction = direction;

            if (DbCommand.Parameters.Contains(paramName))
                return;
            DbCommand.Parameters.Add(param);
        }



        public void ClearParameter()
        {
            DbCommand.Parameters.Clear();
        }

        public override void Open()
        {
            if (DbConnection.State != System.Data.ConnectionState.Open)
                DbConnection.Open();
        }

        public override void BeginTransaction()
        {
            if (DbConnection.State == System.Data.ConnectionState.Open)
                Transaction = (OracleTransaction)DbConnection.BeginTransaction();
            DbCommand.Transaction = Trx;
            DbCommand.Transaction = Transaction;

            //if (DbConnection.State == System.Data.ConnectionState.Open)
            //    Transaction = DbConnection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            //DbCommand.Transaction = Trx;
            //DbCommand.Transaction = Transaction;
        }

        public void BeginTransaction(System.Data.IsolationLevel isolationLevel)
        {
            if (DbConnection.State == System.Data.ConnectionState.Open)
                Transaction = (OracleTransaction)DbConnection.BeginTransaction(isolationLevel);
            DbCommand.Transaction = Trx;
      
        }

        public override void CommitTransaction()
        {
            if (Transaction != null)
                Transaction.Commit();
        }

        public override void RollbackTransaction()
        {
            if (Transaction != null)
                Transaction.Rollback();
        }

        public int ExecuteNonQuery()
        {
            int result = 0;

            try
            {
                Open();
                if (Transaction == null)
                    throw new Exception("Transaction has not been set yet");

                DbCommand.Connection = DbConnection;
                DbCommand.Transaction = Trx;
                result = DbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Transaction == null)
                    if (DbConnection.State != System.Data.ConnectionState.Closed)
                        Close();
                DbCommand.Parameters.Clear();
            }
            return result;
        }

        public int ExecuteNonQueryWithParamOutput()
        {
            int result = 0;

            try
            {
                Open();
                if (Transaction == null)
                    throw new Exception("Transaction has not been set yet");

                DbCommand.Connection = DbConnection;
                result = DbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Transaction == null)
                    if (DbConnection.State != System.Data.ConnectionState.Closed)
                        Close();
            }
            return result;
        }

        public void ExecuteReader()
        {
            try
            {
                DbDataReader = DbCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbCommand.Parameters.Clear();
            }
        }

        public object ExecuteScalar()
        {
            object result = null;
            try
            {
                Open();
                result = DbCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Transaction == null)
                    if (DbConnection.State != System.Data.ConnectionState.Closed)
                        Close();
                DbCommand.Parameters.Clear();
            }

            return result;
        }

        public override System.Data.DataSet GetDataSet()
        {
            DataSet = new System.Data.DataSet();
            try
            {
                if (DbDataAdapter == null)
                    DbDataAdapter = new OracleDataAdapter();

                DbDataAdapter.SelectCommand = DbCommand;
                DbDataAdapter.Fill(DataSet);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbCommand.Parameters.Clear();
            }

            return DataSet;
        }

        public override System.Data.DataSet GetDataSet(string dataSetName)
        {
            DataSet = new System.Data.DataSet();
            try
            {
                if (DbDataAdapter == null)
                    DbDataAdapter = new OracleDataAdapter();

                DbDataAdapter.SelectCommand = DbCommand;
                DbDataAdapter.Fill(DataSet);
                DataSet.DataSetName = dataSetName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbCommand.Parameters.Clear();
            }
            return DataSet;
        }

        public override System.Data.DataTable GetDataTable()
        {
            DataSet = new System.Data.DataSet();
            try
            {
                if (DbDataAdapter == null)
                {
                    DbDataAdapter = new OracleDataAdapter();
                }

                DbDataAdapter.SelectCommand = DbCommand;
                DbDataAdapter.Fill(DataSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbCommand.Parameters.Clear();
            }

            return DataSet.Tables[0];
        }

        public override System.Data.DataTable GetDataTable(string dataTableName)
        {
            DataSet = new System.Data.DataSet();
            try
            {
                if (DbDataAdapter == null)
                    DbDataAdapter = new OracleDataAdapter();
                DbDataAdapter.SelectCommand = DbCommand;
                DbDataAdapter.Fill(DataSet);
                DataSet.Tables[0].TableName = dataTableName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbCommand.Parameters.Clear();
            }

            return DataSet.Tables[dataTableName];
        }

        public void ExecuteReader(System.Data.CommandBehavior behavior)
        {
            try
            {
                DbDataReader = DbCommand.ExecuteReader(behavior);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbCommand.Parameters.Clear();
            }
        }

        public string GetServerName()
        {
            return (this.DbConnection as OracleConnection).DataSource;
        }

        public string GetDatabaseName()
        {
            return (this.DbConnection as OracleConnection).Database;
        }
    }

    public abstract class AbsractOracle: IDisposable
   {
        private string connectionString;
        private System.Data.IDbConnection dbConnection;
        private System.Data.IDbCommand dbCommand;
        private OracleTransaction transaction;
        private System.Data.IDataReader dbDataReader;
        private System.Data.IDbDataAdapter dbDataAdapter;
        private System.Data.DataSet dataSet;
        private OracleTransaction trx;

        public OracleTransaction Trx
        {
            get { return trx; }
            protected set { trx = value; }
        }

        public System.Data.DataSet DataSet
        {
            get { return dataSet; }
            protected set { dataSet = value; }
        }

        public System.Data.IDbDataAdapter DbDataAdapter
        {
            get { return dbDataAdapter; }
            set { dbDataAdapter = value; }
        }

        public System.Data.IDataReader DbDataReader
        {
            get { return dbDataReader; }
            set { dbDataReader = value; }
        }

        public OracleTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }

        public System.Data.IDbCommand DbCommand
        {
            get { return dbCommand; }
            set { dbCommand = value; }
        }

        public System.Data.IDbConnection DbConnection
        {
            get { return dbConnection; }
            set { dbConnection = value; }
        }

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }


        public abstract void Open();
        public abstract void BeginTransaction();
        public abstract void CommitTransaction();
        public abstract void RollbackTransaction();

        public abstract System.Data.DataSet GetDataSet();
        public abstract System.Data.DataSet GetDataSet(string dataSetName);
        public abstract System.Data.DataTable GetDataTable();
        public abstract System.Data.DataTable GetDataTable(string dataTableName);

        public void Close()
        {
            if (DbConnection.State == System.Data.ConnectionState.Open || DbConnection.State == System.Data.ConnectionState.Fetching)
                DbConnection.Close();
        }
        // bawah connetion string
        public void Dispose()
        {
            dbConnection.Close();
            dbConnection.Dispose();
            dbCommand.Dispose();

            if (dbDataReader != null)
            {
                dbDataReader.Close();
                dbDataReader.Dispose();
            }

            if (dbDataAdapter != null)
            {
                dbDataAdapter = null;
            }

            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }

}
