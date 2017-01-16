using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace DAL
{
   public class DbTask
    {
        public DbTask()
        {
        }
        private static SqlTransaction sqlTransObj;

        public DataSet ExecuteQuery(string strQuery)
        {
            DataSet DS = new DataSet();

            SqlCon.OpenSqlCon();

            SqlDataAdapter SQLDA = new SqlDataAdapter(strQuery, SqlCon.SqlConnection);
            SQLDA.Fill(DS, "List");

            CloseAllDBConnections();

            return DS;
        }

        public bool ExecuteNonQuery_SP(string ProcedureName, object[,] ParamArrayName, SqlTransaction myTran)
        {
            bool LineFlag = false;
            int RowAffect = 0;
            SqlCommand SQLCmd = new SqlCommand();
            SQLCmd.Connection = SqlCon.SqlConnection;
            SQLCmd.CommandText = ProcedureName;
            SQLCmd.CommandType = CommandType.StoredProcedure;
            SQLCmd.Connection = myTran.Connection;
            SQLCmd.Transaction = myTran;
            try
            {
                string ParameterName;
                object ParemeterValue;
                for (int i = 0; i < ParamArrayName.Length / 2; i++)
                {
                    ParameterName = ParamArrayName[i, 0].ToString();
                    ParemeterValue = ParamArrayName[i, 1];
                    SQLCmd.Parameters.AddWithValue(ParameterName, ParemeterValue);
                }
                RowAffect = SQLCmd.ExecuteNonQuery();
                if (RowAffect > 0)
                    LineFlag = true;
                else
                    LineFlag = false;
                return LineFlag;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public bool ExecuteNonQuery_SP(string ProcedureName)
        {
            SqlCon.OpenSqlCon();

            SqlCommand SQLCmd = new SqlCommand();
            SQLCmd.Connection = SqlCon.SqlConnection;
            SQLCmd.CommandText = ProcedureName;
            SQLCmd.CommandType = CommandType.StoredProcedure;

            SqlTransaction SqlTran;
            SqlTran = SqlCon.SqlConnection.BeginTransaction();

            try
            {
                SQLCmd.Transaction = SqlTran;

                SQLCmd.ExecuteNonQuery();

                SqlTran.Commit();

                CloseAllDBConnections();
                return true;
            }
            catch (SqlException ex)
            {
                SqlTran.Rollback();

                //Log.Error(ex);
                CloseAllDBConnections();
                return false;
            }
        }


        private void SetParameterType(string Type, ref SqlParameter SQLP)
        {
            switch (Type)
            {
                case "datetime":
                    SQLP.SqlDbType = SqlDbType.DateTime;
                    break;
                case "decimal":
                    SQLP.SqlDbType = SqlDbType.Decimal;
                    break;
                case "numeric":
                    SQLP.SqlDbType = SqlDbType.Decimal;
                    break;
                case "varchar":
                    SQLP.SqlDbType = SqlDbType.VarChar;
                    break;
                case "int":
                    SQLP.SqlDbType = SqlDbType.Int;
                    break;
                case "integer":
                    SQLP.SqlDbType = SqlDbType.Int;
                    break;
                case "smallint":
                    SQLP.SqlDbType = SqlDbType.Int;
                    break;
                case "nchar":
                    SQLP.SqlDbType = SqlDbType.NChar;
                    break;
                case "nvarchar":
                    SQLP.SqlDbType = SqlDbType.NVarChar;
                    break;
                case "smalldatetime":
                    SQLP.SqlDbType = SqlDbType.SmallDateTime;
                    break;
                default:
                    SQLP.SqlDbType = SqlDbType.NVarChar;
                    break;
            }
        }

        public DataSet ExecuteQuery_SP(string ProcedureName)
        {
            DataSet DS = new DataSet();

            SqlCon.OpenSqlCon();

            SqlCommand SQLCmd = new SqlCommand();
            SQLCmd.Connection = SqlCon.SqlConnection;

            SQLCmd.CommandText = ProcedureName;
            SQLCmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SQLDA = new SqlDataAdapter(SQLCmd);

            SQLDA.Fill(DS);

            CloseAllDBConnections();

            return DS;
        }

        public DataSet ExecuteQuery_SP(string ProcedureName, object[,] ParameterNameValue)
        {
            DataSet DS = new DataSet();
            SqlCon.OpenSqlCon();
            SqlCommand SQLCmd = new SqlCommand();
            SQLCmd.Connection = SqlCon.SqlConnection;
            SQLCmd.CommandText = ProcedureName;
            SQLCmd.CommandType = CommandType.StoredProcedure;
            // Attach Paremeter 
            string ParameterName;
            object ParemeterValue;
            for (int i = 0; i < ParameterNameValue.Length / 2; i++)
            {
                ParameterName = ParameterNameValue[i, 0].ToString();
                ParemeterValue = ParameterNameValue[i, 1];
                SQLCmd.Parameters.AddWithValue(ParameterName, ParemeterValue);
            }
            SqlDataAdapter SQLDA = new SqlDataAdapter(SQLCmd);
            SQLDA.Fill(DS, "List");
            CloseAllDBConnections();
            return DS;
        }

        public DataSet ExecuteQuery_SP(string ProcedureName, object[,] ParameterNameValue, SqlTransaction myTran)
        {
            DataSet DS = new DataSet();
            SqlCommand SQLCmd = new SqlCommand();
            SQLCmd.Connection = SqlCon.SqlConnection;
            SQLCmd.CommandText = ProcedureName;
            SQLCmd.CommandType = CommandType.StoredProcedure;
            SQLCmd.Connection = myTran.Connection;
            SQLCmd.Transaction = myTran;
            try
            {
                // Attach Paremeter 
                string ParameterName;
                object ParemeterValue;
                for (int i = 0; i < ParameterNameValue.Length / 2; i++)
                {
                    ParameterName = ParameterNameValue[i, 0].ToString();
                    ParemeterValue = ParameterNameValue[i, 1];
                    SQLCmd.Parameters.AddWithValue(ParameterName, ParemeterValue);
                }
                SqlDataAdapter SQLDA = new SqlDataAdapter(SQLCmd);
                SQLDA.Fill(DS);
                return DS;
            }
            catch (Exception ex)
            {
                //Log.Error(ex);
                throw ex;
            }
        }
        public DataSet ExecuteQuery_SP(string ProcedureName, object[,] ParameterNameValue, bool canCommit)
        {
            DataSet DS = new DataSet();

            SqlCon.OpenSqlCon();

            SqlCommand SQLCmd = new SqlCommand();
            SQLCmd.Connection = SqlCon.SqlConnection;
            SQLCmd.CommandText = ProcedureName;
            SQLCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (sqlTransObj == null)
                {
                    sqlTransObj = SqlCon.SqlConnection.BeginTransaction();
                }
                SQLCmd.Transaction = sqlTransObj;

                // Attach Paremeter 

                string ParameterName;
                object ParemeterValue;

                for (int i = 0; i < ParameterNameValue.Length / 2; i++)
                {
                    ParameterName = ParameterNameValue[i, 0].ToString();
                    ParemeterValue = ParameterNameValue[i, 1];
                    SQLCmd.Parameters.AddWithValue(ParameterName, ParemeterValue);
                }

                SqlDataAdapter SQLDA = new SqlDataAdapter(SQLCmd);

                SQLDA.Fill(DS, "List");

                if (canCommit)
                {
                    sqlTransObj.Commit();
                    sqlTransObj = null;
                    CloseAllDBConnections();
                }

                return DS;
            }
            catch (Exception ex)
            {
                sqlTransObj.Rollback();
                sqlTransObj = null;
                CloseAllDBConnections();

                //Log.Error(ex);
                throw;
            }
        }
        public bool ExecuteNonQuery_SP(string ProcedureName, object[,] ParamArrayName, bool canCommit)
        {
            SqlCon.OpenSqlCon();
            SqlCommand SQLCmd = new SqlCommand();
            SQLCmd.Connection = SqlCon.SqlConnection;
            SQLCmd.CommandText = ProcedureName;
            SQLCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (sqlTransObj == null)
                {
                    sqlTransObj = SqlCon.SqlConnection.BeginTransaction();
                }
                SQLCmd.Transaction = sqlTransObj;
                // Attach Paremeter 
                string ParameterName;
                object ParemeterValue;
                for (int i = 0; i < ParamArrayName.Length / 2; i++)
                {
                    ParameterName = ParamArrayName[i, 0].ToString();
                    ParemeterValue = ParamArrayName[i, 1];
                    SQLCmd.Parameters.AddWithValue(ParameterName, ParemeterValue);
                }
                SQLCmd.ExecuteNonQuery();
                if (canCommit)
                {
                    sqlTransObj.Commit();
                    sqlTransObj = null;
                    CloseAllDBConnections();
                }
                return true;
            }
            catch (Exception ex)
            {
                sqlTransObj.Rollback();
                sqlTransObj = null;
                CloseAllDBConnections();
                //Log.Error(ex);
                throw;
            }
        }

        public object ExecuteScalar_SP(string ProcedureName, object[,] ParameterNameValue)
        {
            object objValue = "";

            SqlCon.OpenSqlCon();
            SqlCommand SQLCmd = new SqlCommand();
            SQLCmd.Connection = SqlCon.SqlConnection;
            SQLCmd.CommandText = ProcedureName;
            SQLCmd.CommandType = CommandType.StoredProcedure;

            // Attach Paremeter 

            string ParameterName;
            object ParemeterValue;

            for (int i = 0; i < ParameterNameValue.Length / 2; i++)
            {

                ParameterName = ParameterNameValue[i, 0].ToString();
                ParemeterValue = ParameterNameValue[i, 1];
                SQLCmd.Parameters.AddWithValue(ParameterName, ParemeterValue);
            }

            objValue = SQLCmd.ExecuteScalar();

            CloseAllDBConnections();

            return objValue;
        }

        public object ExecuteScalar_SP(string ProcedureName)
        {
            object objValue = "";

            SqlCon.OpenSqlCon();

            SqlCommand SQLCmd = new SqlCommand();
            SQLCmd.Connection = SqlCon.SqlConnection;
            SQLCmd.CommandText = ProcedureName;
            SQLCmd.CommandType = CommandType.StoredProcedure;

            objValue = SQLCmd.ExecuteScalar();

            CloseAllDBConnections();

            return objValue;
        }

        public DataSet MasterDBExecuteQuery(string strQuery)
        {
            DataSet DS = new DataSet();

            SqlCon.OpenSqlCon();

            SqlDataAdapter SQLDA = new SqlDataAdapter(strQuery, SqlCon.SqlConnection);
            SQLDA.Fill(DS);

            CloseAllDBConnections();

            return DS;
        }

        public bool MasterDBExecuteNonQuery(string qry)
        {
            SqlCon.OpenSqlCon();

            SqlCommand cmdMaxid = new SqlCommand();
            cmdMaxid.CommandText = qry;
            cmdMaxid.Connection = SqlCon.SqlConnection;
            cmdMaxid.ExecuteNonQuery();

            CloseAllDBConnections();

            return true;
        }

        public bool ExecuteNonQuery(string qry)
        {
            SqlCon.OpenSqlCon();

            SqlCommand cmdMaxid = new SqlCommand();
            cmdMaxid.CommandText = qry;
            cmdMaxid.Connection = SqlCon.SqlConnection;
            cmdMaxid.ExecuteNonQuery();

            CloseAllDBConnections();

            return true;
        }

        public object ExecuteScalar(string query)
        {
            object objValue = "";

            SqlCon.OpenSqlCon();
            SqlCommand SQLCmd = new SqlCommand();
            SQLCmd.Connection = SqlCon.SqlConnection;
            SQLCmd.CommandText = query;

            SqlTransaction aSqlTransaction;
            aSqlTransaction = SqlCon.SqlConnection.BeginTransaction();
            SQLCmd.Transaction = aSqlTransaction;

            objValue = SQLCmd.ExecuteScalar();
            aSqlTransaction.Commit();

            objValue = SQLCmd.ExecuteScalar();

            CloseAllDBConnections();

            return objValue;
        }

        /// <summary>
        /// Closes all database connections.
        /// </summary>
        public static void CloseAllDBConnections()
        {
            SqlCon.CloseAllCon();
        }

        /// <summary>
        /// Finalize transaction by committing the transaction object.
        /// </summary>
        public static void FinalizeCommitTransaction()
        {
            if (sqlTransObj != null)
            {
                sqlTransObj.Commit();
                sqlTransObj = null;

                CloseAllDBConnections();
            }
        }

        /// <summary>
        /// Finalize the rollback activity.
        /// </summary>
        public static void FinalizeRollBackActivity()
        {
            if (sqlTransObj != null)
            {
                sqlTransObj.Rollback();
                sqlTransObj = null;

                CloseAllDBConnections();
            }
        }
    }
}
