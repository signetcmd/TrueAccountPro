using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class adjustmentOpr
    {
        DbTask myDbTask = new DbTask();

        public bool InsertAdjustment(adjustmentInfo myAdjustmentInfo,SqlTransaction myTran)
        {
            bool LineFlag = false;
            object[,] obj = new object[7, 2]
            {
                { "@entry_no",myAdjustmentInfo.ourEntryNo },
                { "@entry_id", myAdjustmentInfo.ourEntryId},
                { "@account",myAdjustmentInfo.ourAccountId },
                { "@particular", myAdjustmentInfo.ourParticular},
                { "@add_minus",myAdjustmentInfo.ourAddOrMinus },
                { "@percentage", myAdjustmentInfo.ourPercentage},
                { "@amount",myAdjustmentInfo.ourAmount }
            };
            if (myDbTask.ExecuteNonQuery_SP("insert_adjustment", obj, myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }

        public DataSet selectAAdjustmentByEntryNO(adjustmentInfo myAdjustmentInfo)
        {
            object[,] arg = new object[1, 2]
        {

                { "@quary_varc","select * from tblAdjustment where entry_no='"+myAdjustmentInfo .ourEntryNo+"'and entry_id='" +myAdjustmentInfo .ourEntryId + "'"},
            };
            return myDbTask.ExecuteQuery_SP("execute_simple_queries", arg);
        }

        public bool DeleteAdjustment(adjustmentInfo myAdjustmentInfo,SqlTransaction myTran)
        {
            bool LineFlag = false;
            object[,] arg = new object[1, 2]
        {
                { "@quary_varc","delete  from tblAdjustment where entry_no='"+myAdjustmentInfo .ourEntryNo+"'and entry_id='" +myAdjustmentInfo .ourEntryId + "'"},
            };
            if (myDbTask.ExecuteNonQuery_SP("execute_simple_queries", arg, myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
        public DataSet BindingParticulars()
        {
            object[,] obj = new object[1, 2]
            {
                { "@quary_varc","SELECT DISTINCT particular FROM tblAdjustment"},
                };
            DataSet allDetails = myDbTask.ExecuteQuery_SP("execute_simple_queries", obj);
            return allDetails;
        }
    }
}
