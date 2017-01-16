using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class genaralFunctions
    {
        DbTask myDbTask = new DbTask();
        public string ValidateInput(object vlue)
        {
            string stringValue = "0";

            stringValue = vlue == null ? "0" : vlue.ToString();
            stringValue = stringValue.Trim();
            stringValue = stringValue == "" ? "0" : stringValue;
            stringValue = stringValue.ToString() == "." ? "0" : stringValue;

            if (stringValue.Length > 1)
            {
                stringValue = stringValue.Substring(0, 2) == ".." ? "0" : stringValue;
            }
            stringValue = stringValue.ToString() == "-" ? "0" : stringValue;
            stringValue = stringValue.ToString() == "+" ? "0" : stringValue;
            stringValue = stringValue.ToString() == "-." ? "0" : stringValue;

            return stringValue;
        }
        public string FormatDecimalPlace(string text, int decimalPlace)
        {
            Object objString = text;
            decimal decimalValue = Convert.ToDecimal(ValidateInput(objString));
            string stringFormat = "{0:f" + decimalPlace + "}";
            return string.Format(stringFormat, decimalValue);
        }
        public void RestrictIntegerCharacters(ref KeyEventArgs e)
        {
            if (e.Control != true && e.Alt != true)
            {
                if (e.KeyCode != Keys.D0 &&
                e.KeyCode != Keys.D1 &&
                e.KeyCode != Keys.D2 &&
                e.KeyCode != Keys.D3 &&
                e.KeyCode != Keys.D4 &&
                e.KeyCode != Keys.D5 &&
                e.KeyCode != Keys.D6 &&
                e.KeyCode != Keys.D7 &&
                e.KeyCode != Keys.D8 &&
                e.KeyCode != Keys.D9 &&

                e.KeyCode != Keys.NumPad0 &&
                e.KeyCode != Keys.NumPad1 &&
                e.KeyCode != Keys.NumPad2 &&
                e.KeyCode != Keys.NumPad3 &&
                e.KeyCode != Keys.NumPad4 &&
                e.KeyCode != Keys.NumPad5 &&
                e.KeyCode != Keys.NumPad6 &&
                e.KeyCode != Keys.NumPad7 &&
                e.KeyCode != Keys.NumPad8 &&
                e.KeyCode != Keys.NumPad9 &&

                //Allowing the Alt+F4 key combination
                e.KeyCode != Keys.F4 &&
                // to close the form
                e.KeyCode != Keys.Alt &&

                e.KeyCode != Keys.Back &&
                e.KeyCode != Keys.Delete &&
                e.KeyCode != Keys.End &&
                e.KeyCode != Keys.Home &&
                e.KeyCode != Keys.Right &&
                e.KeyCode != Keys.Left &&
                e.KeyCode != Keys.Up &&
                e.KeyCode != Keys.Down &&
                e.KeyCode != Keys.Enter
                )
                {
                    e.SuppressKeyPress = true;
                }
            }
        }
        public int getMaxValueOfFiledInTable(string filedName, string tableName)
        {
            object[,] obj = new object[1, 2]
            {
                {"@quary_varc", "SELECT ISNULL(MAX(" + filedName + " + 1), 1) AS EntryNo FROM  " + tableName}
            };
            DataSet maxNumber = myDbTask.ExecuteQuery_SP("execute_simple_queries", obj);
            return Convert.ToInt32(maxNumber.Tables[0].Rows[0][0].ToString());
        }
        public int getMaxValueFromTable(string filedName, string tableName, SqlTransaction myTran)
        {
            object[,] obj = new object[1, 2]
            {
                {"@quary_varc", "SELECT ISNULL(MAX(" + filedName + " + 1), 1) AS EntryNo FROM  " + tableName}
            };
            DataSet maxNumber = myDbTask.ExecuteQuery_SP("execute_simple_queries", obj, myTran);
            return Convert.ToInt32(maxNumber.Tables[0].Rows[0][0].ToString());
        }
        public DataSet IsPrintBarCodeUpdate(bool Check)
        {
            object[,] obj = new object[1, 2]
            {
                { "@quary_varc","UPDATE tblGenaralSettings SET BarCode_Print='"+Check+"'"},
            };
            return myDbTask.ExecuteQuery_SP("execute_simple_queries", obj);
        }
        public DataSet IsPrintBarCodeLoad()
        {
            object[,] obj = new object[1, 2]
            {
                { "@quary_varc","SELECT top(1)BarCode_Print FROM tblGenaralSettings"},
            };
            return myDbTask.ExecuteQuery_SP("execute_simple_queries", obj);
        }
    }

}
