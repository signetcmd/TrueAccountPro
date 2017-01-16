using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class settingsOpr
    {
        DbTask myDbTask = new DbTask();

        public DataSet selectAllSalesRateLabels()
        {
            object[,] ledgerArg = new object[1, 2]
          {
                 {"@quary_varc","select * from tblSalesRateLabel" }


          };

          DataSet detials=  myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return detials;
        }

        public DataSet selectAllGenarlSettings()
        {
            object[,] ledgerArg = new object[1, 2]
          {
                 {"@quary_varc","select * from tblGenaralSettings" }


          };

            DataSet detials = myDbTask.ExecuteQuery_SP("execute_simple_queries", ledgerArg);
            return detials;
        }

    }
}
