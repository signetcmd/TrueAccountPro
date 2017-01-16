using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
namespace TrueAccountPro
{
    class SqlCon
    {
        private static string _connectionString;
        private static SqlConnection _sqlCon;
        private static string myDataBasePath;

        static SqlCon()
        {

            //myDataBasePath = Application.StartupPath + "\\Data\\BuildSoft.mdf";
            //_connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + myDataBasePath + ";Integrated Security=True;User Instance=True";
            _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=TrueAccountPro;Integrated Security=True";

        }
        private static void SetConString()
        {


//          _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=BuildSoft;Integrated Security=True";
    
        }

        /// <summary>
        /// //Opens a SQL connection to application database.
        /// </summary>
        public static void OpenSqlCon()
        {
            SetConString();
            if (_sqlCon != null &&
                _sqlCon.State != System.Data.ConnectionState.Broken &&
                _sqlCon.State != System.Data.ConnectionState.Closed)
            {
                //already connected to the application database
                //no need to connect again
                return;
            }
            _sqlCon = new SqlConnection(_connectionString);
            _sqlCon.Open();
        }

        /// <summary>
        /// Get current SQL connection to application database.
        /// </summary>
        public static SqlConnection SqlConnection
        {
            get
            {
                return _sqlCon;
            }
        }

        /// <summary>
        /// Close all SQL Connectons
        /// </summary>
        public static void CloseAllCon()
        {
            if (_sqlCon != null)
            {
                _sqlCon.Close();
                _sqlCon.Dispose();
            }
        }
    }
}
