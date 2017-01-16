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
    public class stockOpr
    {
        DbTask myDbTask = new DbTask();
        public bool DeleteStockLedger(stockInfo stockLedgerInfo,SqlTransaction myTran)
        {
            bool LineFlag = false;
            object[,] stock = new object[1, 2]
            {
                {"@quary_varc","delete from tblStockLedger where entry_id='" + stockLedgerInfo.ourEntryId +"' and entry_no='" + stockLedgerInfo.ourEntryNo +"'" }     
            };
            if (myDbTask.ExecuteNonQuery_SP("execute_simple_queries", stock,myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }

        public bool InsertStockLedger(stockInfo stockLedgerInfo,SqlTransaction myTran)
        {
            bool LineFlag = false;
            object[,] stock = new object[14, 2]
             {
                    { "@entry_date",stockLedgerInfo.ourEntryDate },
                    { "@entry_time",stockLedgerInfo.ourEntryTime },
                    { "@entry_id"   ,stockLedgerInfo.ourEntryId },
                    { "@entry_no"  ,stockLedgerInfo.ourEntryNo },
                    { "@item_id"   ,stockLedgerInfo.ourItemId },
                    { "@bar_code_id"   ,stockLedgerInfo.ourBarCode },
                    { "@godown_id"  ,stockLedgerInfo.ourGodownId },
                    { "@inward_qty" ,stockLedgerInfo.ourInwardQty },
                    { "@inward_qty2"    ,stockLedgerInfo.ourInwardQty2 },
                    { "@outward_qty" ,stockLedgerInfo.ourOutwardQty },
                    { "@outward_qty2",stockLedgerInfo.ourOutwardQty2 },
                    { "@inward_net_value" ,stockLedgerInfo.ourInwardNetValue },
                    { "@outward_net_value" ,stockLedgerInfo.ourOutwardNetValue },
                    { "@addi_descrip" ,stockLedgerInfo.ourAddDescrip }
             };
            if(myDbTask.ExecuteNonQuery_SP("insert_stock_ledger", stock, myTran))
                 LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }

        public DataSet getStockGodownWise(stockInfo stockLedgerInfo)
        {
            object[,] stock = new object[1, 2]
             {

                    { "@id",stockLedgerInfo.ourBarCode },
                  
             };
            DataSet details = myDbTask.ExecuteQuery_SP("select_stock_godown_wise", stock);
            return details;
             
        }

        //public void deleteStockLedger(stockInfo myStockInfo)
        //{
        //    object[,] arg = new object[1, 2]
        //{

        //        { "@quary_varc","delete  from tblStockLedger where entry_no='"+myStockInfo .ourEntryNo+"'and entry_id='" +myStockInfo .ourEntryId + "'"},
        //    };
        //    myDbTask.ExecuteQuery_SP("execute_simple_queries", arg);
        //}
    }
}
