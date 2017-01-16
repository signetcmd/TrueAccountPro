using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class cashLedgerOpr
    {
        DbTask myDbTask = new DbTask();
        public bool InsertCashLedger(cashLedgerInfo myCashledgerInfo, SqlTransaction myTran)
        {
            bool LineFlag = false;
            object[,] obj = new object[9, 2]
            {
                {"@entry_identity",myCashledgerInfo.ourEntryIdentity},
                { "@entry_no",myCashledgerInfo.ourEntryNo},
                {"@voucher_no",myCashledgerInfo.ourVoucherNo },
                { "@entry_date",myCashledgerInfo.ourEntryDate},
                { "@entry_time",myCashledgerInfo.ourEntryTime},
                { "@account_id",myCashledgerInfo.ourAccountId},
                { "@debit",myCashledgerInfo.ourDebit},
                { "@credit",myCashledgerInfo.ourCredit},
                { "@group_id",myCashledgerInfo.ourGroupId}
            };
            if (myDbTask.ExecuteNonQuery_SP("insert_cash_ledger", obj,myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
        public bool DeleteCashLedger(cashLedgerInfo myCashledgerInfo,SqlTransaction myTran)
        {
            bool LineFlag = false;
            object[,] arg = new object[1, 2]
           {
                { "@quary_varc","delete from tblCashLedger where entry_identity='"+ myCashledgerInfo.ourEntryIdentity  +"' and entry_no='" +myCashledgerInfo.ourEntryNo+ "'"},
               };
            if (myDbTask.ExecuteNonQuery_SP("execute_simple_queries", arg, myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
    }
}
