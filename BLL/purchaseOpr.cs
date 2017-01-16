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
    public class purchaseOpr
    {
        DbTask myTbTask = new DbTask();
        public bool InsertPurchaseMaster(purchaseInfo myPuchaseInfo, SqlTransaction myTran)
        {
            bool LineFlag = false;
            object[,] obj;
                obj = new object[28, 2]
                {
                            {"@entry_no"   ,myPuchaseInfo.ourEntryNo },
                            {"@entry_date" ,myPuchaseInfo.ourEntryDate },
                            {"@entry_time" ,myPuchaseInfo.ourEntryTime },
                            {"@invoice_no", myPuchaseInfo.ourInvoiceNo},
                            {"@invoice_date" ,myPuchaseInfo.ourInvoiceDate},
                            {"@account_id", myPuchaseInfo.ourAccountId},
                            {"@suppiler_name" , myPuchaseInfo.ourSupplierName},
                            {"@suppler_address"   , myPuchaseInfo.ourAddress},
                            {"@supplier_mobile"    , myPuchaseInfo.ourMobile},
                            {"@description"  , myPuchaseInfo.ourDescription},
                            {"@tin_no" , myPuchaseInfo.ourTinNo},
                            {"@cst_no" , myPuchaseInfo.ourCstNo},
                            {"@c_form" , myPuchaseInfo.ourCFormNo},
                            {"@c_form_date" , myPuchaseInfo.ourCFromDate},
                            {"@natr_of_purch"  , myPuchaseInfo.ourNtrOfPurch},
                            {"@delivery_date"  , myPuchaseInfo.ourDeliveryDate},
                            {"@form_type"  , myPuchaseInfo.ourFromType},
                            {"@round_off" , myPuchaseInfo.ourRoundOff},
                            {"@round_off_check" , myPuchaseInfo.ourRoundOffCheck},
                            {"@grand_total" , myPuchaseInfo.ourGrandTotal},
                            {"@net_amount" , myPuchaseInfo.ourNetTotal},
                            {"@amount_paid"   , myPuchaseInfo.ourAmountPaid},
                            {"@balance"   , myPuchaseInfo.ourBalance},
                            {"@old_balance"   , myPuchaseInfo.ourOldBalance},
                            {"@closing_balance"   , myPuchaseInfo.ourClosingBalance},
                            {"@adjustment"   , myPuchaseInfo.ourAdjustment},
                            {"@due_date"   ,myPuchaseInfo.ourDueDate},
                            {"@user_id",myPuchaseInfo.ourUserId }
                };
            if (myTbTask.ExecuteNonQuery_SP("insert_purchase_master", obj, myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
        //public void updatePurchaseMaster(purchaseInfo myPuchaseInfo)
        //{
        //    object[,] obj;

        //    if (myPuchaseInfo.ourDueDate == null)
        //    {
        //        obj = new object[21, 2]
        //        {
        //                    {"@entry_no"   ,myPuchaseInfo.ourEntryNo },
        //                    {"@entry_date" ,myPuchaseInfo.ourEntryDate },
        //                    {"@entry_time" ,myPuchaseInfo.ourEntryTime },
        //                    {"@invoice_no", myPuchaseInfo.ourInvoiceNo},
        //                    {"@invoice_date" ,myPuchaseInfo.ourInvoiceDate},
        //                    {"@account_id", myPuchaseInfo.ourAccountId},
        //                    {"@suppiler_name" , myPuchaseInfo.ourSupplierName},
        //                    {"@suppler_address"   , myPuchaseInfo.ourAddress},
        //                    {"@supplier_mobile"    , myPuchaseInfo.ourMobile},
        //                    {"@description"  , myPuchaseInfo.ourDescription},
        //                    {"@tin_no" , myPuchaseInfo.ourTinNo},
        //                    {"@cst_no" , myPuchaseInfo.ourCstNo},
        //                    {"@c_form" , myPuchaseInfo.ourCFormNo},
        //                    {"@c_form_date" , myPuchaseInfo.ourCFromDate},
        //                    {"@natr_of_purch"  , myPuchaseInfo.ourNtrOfPurch},
        //                    {"@delivery_date"  , myPuchaseInfo.ourDeliveryDate},
        //                    {"@form_type"  , myPuchaseInfo.ourFromType},
        //                    {"@round_off" , myPuchaseInfo.ourRoundOff},
        //                    { "@amount_paid"   , myPuchaseInfo.ourAmountPaid},
        //                    {"@due_date"   ,DBNull.Value},
        //                    {"@user_id",myPuchaseInfo.ourUserId }
        //        };
        //    }
        //    else
        //    {
        //        obj = new object[21, 2]
        //           {
        //                    {"@entry_no"   ,myPuchaseInfo.ourEntryNo },
        //                    {"@entry_date" ,myPuchaseInfo.ourEntryDate },
        //                    {"@entry_time" ,myPuchaseInfo.ourEntryTime },
        //                    {"@invoice_no", myPuchaseInfo.ourInvoiceNo},
        //                    {"@invoice_date" ,myPuchaseInfo.ourInvoiceDate},
        //                    {"@account_id", myPuchaseInfo.ourAccountId},
        //                    {"@suppiler_name" , myPuchaseInfo.ourSupplierName},
        //                    {"@suppler_address"   , myPuchaseInfo.ourAddress},
        //                    {"@supplier_mobile"    , myPuchaseInfo.ourMobile},
        //                    {"@description"  , myPuchaseInfo.ourDescription},
        //                    {"@tin_no" , myPuchaseInfo.ourTinNo},
        //                    {"@cst_no" , myPuchaseInfo.ourCstNo},
        //                    {"@c_form" , myPuchaseInfo.ourCFormNo},
        //                    {"@c_form_date" , myPuchaseInfo.ourCFromDate},
        //                    {"@natr_of_purch"  , myPuchaseInfo.ourNtrOfPurch},
        //                    {"@delivery_date"  , myPuchaseInfo.ourDeliveryDate},
        //                    {"@form_type"  , myPuchaseInfo.ourFromType},
        //                    {"@round_off" , myPuchaseInfo.ourRoundOff},
        //                    { "@amount_paid"   , myPuchaseInfo.ourAmountPaid},
        //                    {"@due_date"   ,myPuchaseInfo.ourDueDate },
        //                    {"@user_id",myPuchaseInfo.ourUserId }
        //           };
        //    }
        //    myTbTask.ExecuteQuery_SP("update_purchase_master", obj);
        //}
        public bool InsertPurchaseDetails(purchaseInfo myPuchaseInfo, SqlTransaction myTran)
        {
            bool LineFlag = false;
            object[,] obj = new object[23, 2]
                {
                   {"@entry_no",myPuchaseInfo.ourEntryNo },
                   {"@bar_code_id",myPuchaseInfo.ourBarCodeId },
                   {"@item_id",myPuchaseInfo.ourItemId },
                   {"@add_descrip",myPuchaseInfo.ourAddiDescrip },
                   {"@unit",myPuchaseInfo.ourUnit },
                   {"@qty",myPuchaseInfo.ourQty },
                   {"@free_qty_unit",myPuchaseInfo.ourFreeQtyUnit },
                   {"@free_qty",myPuchaseInfo.ourFreeQty },
                   {"@qty_2",myPuchaseInfo.ourQty2 },
                   {"@total_qty",myPuchaseInfo.ourTotalQty },
                   {"@sticker_qty",myPuchaseInfo.ourStickerQty },
                   {"@return_qty",myPuchaseInfo.ourReturnQty },
                   {"@godown_id",myPuchaseInfo.ourGodownId },
                   {"@unit_id",myPuchaseInfo.ourUnitId},
                   {"@unit_rate",myPuchaseInfo.ourUnitRate},
                   {"@disc_perc",myPuchaseInfo.ourDiscPerc},
                   {"@disc2",myPuchaseInfo.ourDisc2 },
                   {"@exice_duty_perc",myPuchaseInfo.ourExiceDutyPerc},
                   {"@gst_perc",myPuchaseInfo.ourGstPerc},
                   {"@net_value",myPuchaseInfo.ourNetValue},
                   {"@vat_perc",myPuchaseInfo.ourVatPerc},
                   {"@cess_perc",myPuchaseInfo.ourCessPerc},
                   {"@grand_total",myPuchaseInfo.ourGrndTotal}
                };
            if (myTbTask.ExecuteNonQuery_SP("insert_purchase_details", obj, myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
        public DataSet selectAPurchaseMasterDetailByEntryNo(purchaseInfo myPurchaseinfo)
        {
            object[,] arg = new object[1, 2]
           {
                { "@quary_varc","select * FROM tblPurchaseMaster where entry_no='"   + myPurchaseinfo.ourEntryNo + "'"},
               };
            return myTbTask.ExecuteQuery_SP("execute_simple_queries", arg);
        }
        public DataSet selectAPurchaseDetailsByEntryNo(purchaseInfo myPurchaseinfo)
        {
            object[,] arg = new object[1, 2]
          {
                { "@entry_no",myPurchaseinfo.ourEntryNo},
              };
            return myTbTask.ExecuteQuery_SP("select_purchase_detail_by_entry_no", arg);
        }

        public bool DeletePurchaseDetails(purchaseInfo myPurchaseinfo,SqlTransaction myTran)
        {
            bool LineFlag = false;
            object[,] arg = new object[1, 2]
          {
                { "@quary_varc","delete from tblPurchaseDetails where entry_no='"   + myPurchaseinfo.ourEntryNo + "'"},
              };
            if (myTbTask.ExecuteNonQuery_SP("execute_simple_queries", arg, myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
        public bool DeletePurchaseMaster(purchaseInfo myPurchaseinfo,SqlTransaction myTran)
        {
            object[,] arg = new object[1, 2]
          {
                { "@quary_varc","DELETE FROM tblPurchaseMaster WHERE  entry_no='"   + myPurchaseinfo.ourEntryNo + "'"},
              };
            if (myTbTask.ExecuteNonQuery_SP("execute_simple_queries", arg, myTran))
                return true;
            else
                return false;
        }
    }
}
