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
    public class barCodeRegistryOpr
    {
        DbTask myDbTask = new DbTask();
        #region InsertBarCodeRegistry
        public bool InsertBarCodeRegistry(barCodeRegistryInfo myBarCodeRegInfo,SqlTransaction myTran)
        {
            bool LineFlag = false;
            object[,] obj;
            if (myBarCodeRegInfo.ourCount == 1)
            {
                obj = new object[27, 2]
                {
                {"@Count",myBarCodeRegInfo.ourCount},
                {"@BarCode_ID",myBarCodeRegInfo.ourBarCodeId},
                {"@BarCode",myBarCodeRegInfo.ourBarCode},
                {"@item_id",myBarCodeRegInfo.ourItemId},
                {"@company_id",myBarCodeRegInfo.ourCompanyId},
                {"@category_id",myBarCodeRegInfo.ourCategoryId},
                {"@model_id",myBarCodeRegInfo.ourModelId},
                {"@brand_id",myBarCodeRegInfo.ourBrandId},
                {"@colour_id",myBarCodeRegInfo.ourColourId},
                {"@size_id",myBarCodeRegInfo.ourSizeId},
                {"@batch",myBarCodeRegInfo.ourBatch},
                {"@exp_date",myBarCodeRegInfo.ourExpDate },
                {"@add_cost",myBarCodeRegInfo.ourAddCost},
                {"@cost",myBarCodeRegInfo.ourCost},
                {"@reatil_rate_pro",myBarCodeRegInfo.ourReatilRatePro},
                {"@retail_rate",myBarCodeRegInfo.ourRetailRate},
                {"@mrp_pro",myBarCodeRegInfo.ourMrpPro},
                {"@mrp",myBarCodeRegInfo.ourMrp},
                {"@special_rate_pro",myBarCodeRegInfo.ourSpecialRatePro},
                {"@special_rate",myBarCodeRegInfo.ourSpecialRate},
                {"@whoe_sale_pro",myBarCodeRegInfo.ourWhoeSalePro},
                {"@whole_sale",myBarCodeRegInfo.ourWholeSale},
                {"@branch_rate_pro",myBarCodeRegInfo.ourBranchRatePro },
                {"@branch_rate",myBarCodeRegInfo.ourBranchRate},
                {"@item_bar_code",myBarCodeRegInfo.ourItemBarCode},
                {"@entry_id",myBarCodeRegInfo.ourEntryId},
                {"@entry_no",myBarCodeRegInfo.ourEntryNo }
                };
            }
            else
            {
                obj = new object[26, 2]
                {
                {"@Count",myBarCodeRegInfo.ourCount},
                {"@BarCode_ID",myBarCodeRegInfo.ourBarCodeId},
                {"@item_id",myBarCodeRegInfo.ourItemId},
                {"@company_id",myBarCodeRegInfo.ourCompanyId},
                {"@category_id",myBarCodeRegInfo.ourCategoryId},
                {"@model_id",myBarCodeRegInfo.ourModelId},
                {"@brand_id",myBarCodeRegInfo.ourBrandId},
                {"@colour_id",myBarCodeRegInfo.ourColourId},
                {"@size_id",myBarCodeRegInfo.ourSizeId},
                {"@batch",myBarCodeRegInfo.ourBatch},
                {"@exp_date",myBarCodeRegInfo.ourExpDate },
                {"@add_cost",myBarCodeRegInfo.ourAddCost},
                {"@cost",myBarCodeRegInfo.ourCost},
                {"@reatil_rate_pro",myBarCodeRegInfo.ourReatilRatePro},
                {"@retail_rate",myBarCodeRegInfo.ourRetailRate},
                {"@mrp_pro",myBarCodeRegInfo.ourMrpPro},
                {"@mrp",myBarCodeRegInfo.ourMrp},
                {"@special_rate_pro",myBarCodeRegInfo.ourSpecialRatePro},
                {"@special_rate",myBarCodeRegInfo.ourSpecialRate},
                {"@whoe_sale_pro",myBarCodeRegInfo.ourWhoeSalePro},
                {"@whole_sale",myBarCodeRegInfo.ourWholeSale},
                {"@branch_rate_pro",myBarCodeRegInfo.ourBranchRatePro },
                {"@branch_rate",myBarCodeRegInfo.ourBranchRate},
                {"@item_bar_code",myBarCodeRegInfo.ourItemBarCode},
                {"@entry_id",myBarCodeRegInfo.ourEntryId},
                {"@entry_no",myBarCodeRegInfo.ourEntryNo }
                };
            }
            if (myDbTask.ExecuteNonQuery_SP("insert_barcode_registry", obj, myTran))
            {
                LineFlag = true;
            }
            else
                LineFlag = false;
            return LineFlag;
        }
        #endregion InsertBarCodeRegistry
        public DataSet selectitemDetailsByBarCode(barCodeRegistryInfo myBarCodeRegInfo)
        {
            object[,] obj = new object[1, 2]
            {
                { "@quary_varc","select * from tblBarCodeRegistry where bar_code='" + myBarCodeRegInfo.ourBarCode  + "'or item_bar_code='"+myBarCodeRegInfo.ourBarCode+"'"},

            };
            return myDbTask.ExecuteQuery_SP("execute_simple_queries", obj);
        }
        #region SelectUnitRateDetails
        public DataSet SelectUnitRateDetails(barCodeRegistryInfo myBarCodeRegInfo)
        {
            object[,] obj = new object[1, 2]
            {
                { "@quary_varc","SELECT * FROM tblRateDetails WHERE entry_id='" + myBarCodeRegInfo.ourEntryId +"' AND entry_no='"+ myBarCodeRegInfo.ourEntryNo+"'"},
            };
            return myDbTask.ExecuteQuery_SP("execute_simple_queries", obj);
        }
        #endregion SelectUnitRateDetails
        #region SelectLastInsertedBarCode
        public DataSet SelectLastInsertedBarCode(SqlTransaction myTran)
        {

            object[,] obj = new object[1, 2]
            {
                { "@quary_varc","SELECT ISNULL(MAX(bar_code),0)bar_code,ISNULL(MAX(bar_code_id),0)bar_code_id FROM tblBarCodeRegistry"},

            };
            return myDbTask.ExecuteQuery_SP("execute_simple_queries", obj,myTran);
        }
        #endregion SelectLastInsertedBarCode
        #region DeleteBarCodeItem
        public bool DeleteBarCodeItem(barCodeRegistryInfo myBarCodeRegInfo,SqlTransaction myTran)
        {
            bool LineFlag = false;
            object[,] obj = new object[1, 2]
            {
                { "@quary_varc","delete from tblBarCodeRegistry where bar_code_id='" + myBarCodeRegInfo.ourBarCodeId +"'"},
            };
            if (myDbTask.ExecuteNonQuery_SP("execute_simple_queries", obj, myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
        #endregion DeleteBarCodeItem
        public DataSet selectRateDetailsByBarcodeId(barCodeRegistryInfo myBarCodeRegInfo)
        {
            object[,] obj = new object[1, 2]
          {
                { "@barcode",myBarCodeRegInfo.ourBarCode},
          };
            return myDbTask.ExecuteQuery_SP("select_rate_details_by_barcode", obj);
        }
        public DataSet selectItemAgainstPurchAndOP(barCodeRegistryInfo myBarCodeRegInfo)
        {
            object[,] obj = new object[1, 2]
          {
                { "@itemid",myBarCodeRegInfo.ourItemId }
          };
            return myDbTask.ExecuteQuery_SP("select_items_barcode_reg_by_item_id", obj);
        }
        #region SearchBarCodeDetails
        public DataSet SearchBarCodeDetails(barCodeRegistryInfo myBarCodeRegInfo)
        {
            object[,] obj = new object[1, 2]
          {
                { "@SearchText",myBarCodeRegInfo.ourSearchText }
          };
            return myDbTask.ExecuteQuery_SP("Search_BarCode_Item", obj);
        }
        #endregion SearchBarCodeDetails
        #region InsertUnitRateDetails
        public bool InsertUnitRateDetails( barCodeRegistryInfo myBarCodeRegInfo,SqlTransaction myTran)
        {
            bool LineFlag = false;
            object[,] obj = new object[15, 2]
           {
                {"@bar_code_id",myBarCodeRegInfo.ourBarCodeId },
                {"@unit_id",myBarCodeRegInfo.ourUnitId },
                {"@cost",myBarCodeRegInfo.ourCost},
                {"@reatil_rate_pro",myBarCodeRegInfo.ourReatilRatePro},
                {"@retail_rate",myBarCodeRegInfo.ourRetailRate},
                {"@mrp_pro",myBarCodeRegInfo.ourMrpPro},
                {"@mrp",myBarCodeRegInfo.ourMrp},
                {"@special_rate_pro",myBarCodeRegInfo.ourSpecialRatePro},
                {"@special_rate",myBarCodeRegInfo.ourSpecialRate},
                {"@whoe_sale_pro",myBarCodeRegInfo.ourWhoeSalePro},
                {"@whole_sale" ,myBarCodeRegInfo.ourWholeSale},
                {"@branch_rate_pro",myBarCodeRegInfo.ourBranchRatePro},
                {"@branch_rate",myBarCodeRegInfo.ourBranchRate},
                {"@entry_id",myBarCodeRegInfo.ourEntryId},
                {"@entry_no",myBarCodeRegInfo.ourEntryNo}
           };
            if (myDbTask.ExecuteNonQuery_SP("insert_unit_rate_details", obj, myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
        #endregion InsertUnitRateDetails
        #region SelectBarCodeUnitDetails
        public DataSet SelectBarCodeUnitDetails(barCodeRegistryInfo myBarCodeRegInfo)
        {
            object[,] obj = new object[1, 2]
          {
                { "@barcode_id",myBarCodeRegInfo.ourBarCodeId },
          };
            return myDbTask.ExecuteQuery_SP("select_barcode_details", obj);
        }
        #endregion SelectBarCodeUnitDetails
        public DataSet selectRateDetailsByBarcodeAndUnit(barCodeRegistryInfo myBarCodeRegInfo)
        {
            object[,] obj = new object[1, 2]
          {
                { "@barcode_id",myBarCodeRegInfo.ourBarCodeId },
                //{ "@unit_id",myBarCodeRegInfo.ourUnitId},
          };
            return myDbTask.ExecuteQuery_SP("select_rate_details_by_barcode_and_unit", obj);
        }
        #region CheckBarCodeInSL
        public DataSet CheckBarCodeInSL(barCodeRegistryInfo myBarCodeRegInfo, SqlTransaction myTran)
        {
            DataSet ds = new DataSet();
            object[,] arg = new object[1, 2]
        {
                //{ "@quary_varc","SELECT COUNT(bar_code_id)[Count] FROM tblStockLedger WHERE bar_code_id='"+myBarCodeRegInfo .ourBarCodeId+"' AND (entry_id='PV' OR entry_id='OP')"},
                { "@quary_varc","SELECT COUNT(bar_code_id)[Count] FROM tblStockLedger WHERE bar_code_id='"+myBarCodeRegInfo .ourBarCodeId+"'"},
            };
            return ds = myDbTask.ExecuteQuery_SP("execute_simple_queries", arg, myTran);
        }
        #endregion CheckBarCodeInSL
        #region CheckBarCodeInSLWithoutTran
        public DataSet CheckBarCodeInSLWithoutTran(barCodeRegistryInfo myBarCodeRegInfo)
        {
            DataSet ds = new DataSet();
            object[,] arg = new object[1, 2]
        {
                //{ "@quary_varc","SELECT COUNT(bar_code_id)[Count] FROM tblStockLedger WHERE bar_code_id='"+myBarCodeRegInfo .ourBarCodeId+"' AND (entry_id='PV' OR entry_id='OP')"},
                { "@quary_varc","SELECT COUNT(bar_code_id)[Count] FROM tblStockLedger WHERE bar_code_id='"+myBarCodeRegInfo .ourBarCodeId+"'"},
            };
            return ds = myDbTask.ExecuteQuery_SP("execute_simple_queries", arg);
        }
        #endregion CheckBarCodeInSLWithoutTran
        #region DeleteBarcodeItem
        public bool DeleteBarcodeItem(barCodeRegistryInfo myBarCodeRegInfo, SqlTransaction myTran)
        {
            object[,] obj = new object[1, 2]
            {
                { "@quary_varc","DELETE FROM tblBarCodeRegistry WHERE bar_code_id='" + myBarCodeRegInfo.ourBarCodeId +"'"},
            };
            if (myDbTask.ExecuteNonQuery_SP("execute_simple_queries", obj, myTran))
                return true;
            else
                return false;
        }
        #endregion DeleteBarcodeItem
        #region DeleteUnitRateDetails
        public bool DeleteUnitRateDetails(barCodeRegistryInfo myBarCodeRegInfo, SqlTransaction myTran)
        {
            object[,] obj = new object[1, 2]
            {
                { "@quary_varc","DELETE FROM tblRateDetails WHERE entry_id='" + myBarCodeRegInfo.ourEntryId +"' AND entry_no='"+ myBarCodeRegInfo.ourEntryNo+"'"},
            };
            if (myDbTask.ExecuteNonQuery_SP("execute_simple_queries", obj, myTran))
                return true;
            else
                return false;
        }
        #endregion DeleteUnitRateDetails
        #region DeleteUnitRateDetailsFromUpdate
        public bool DeleteUnitRateDetailsFromUpdate(barCodeRegistryInfo myBarCodeRegInfo, SqlTransaction myTran)
        {
            object[,] obj = new object[1, 2]
            {
                { "@quary_varc","DELETE FROM tblRateDetails WHERE bar_code_id='"+ myBarCodeRegInfo.ourBarCodeId+"'"},
                // entry_id='" + myBarCodeRegInfo.ourEntryId +"' AND entry_no='"+ myBarCodeRegInfo.ourEntryNo+"' AND
            };
            if (myDbTask.ExecuteNonQuery_SP("execute_simple_queries", obj, myTran))
                return true;
            else
                return false;
        }
        #endregion DeleteUnitRateDetailsFromUpdate
        public DataSet GetUnitRateDetails(barCodeRegistryInfo myBarCodeRegInfo)
        {
            object[,] obj = new object[1, 2]
            {
                { "@quary_varc","SELECT * FROM tblRateDetails WHERE bar_code_id='" + myBarCodeRegInfo.ourBarCodeId +"'"},
            };
            return myDbTask.ExecuteQuery_SP("execute_simple_queries", obj);
        }
    }
}
