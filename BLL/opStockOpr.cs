using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class opStockOpr
    {
        DbTask myDbTask = new DbTask();
        public void deleteOpStockDetails(opStockInfo myOpStockInfo)
        {
            object[,] stock = new object[1, 2]
           {
                {"@quary_varc","delete from tblOpStockDetials where entry_no='" + myOpStockInfo.EntryNo +"'" }


           };

            myDbTask.ExecuteQuery_SP("execute_simple_queries", stock);

        }

        public void deleteOpStockMaster(opStockInfo myOpStockInfo)
        {
            object[,] stock = new object[1, 2]
           {
                {"@quary_varc","delete from tblOpStockMaster where entry_no='" + myOpStockInfo.EntryNo +"'" }


           };

            myDbTask.ExecuteQuery_SP("execute_simple_queries", stock);

        }
        public void insertOpStockDetails(opStockInfo myOpStockInfo)
        {
            object[,] obj;

            if (myOpStockInfo.ExpDate == null)
            {
                obj = new object[48, 2]
                {
                {"@entry_no",myOpStockInfo.EntryNo },
                {"@bar_code",myOpStockInfo.BarCode},
                {"@item_id",myOpStockInfo.ItemId},
                {"@company_id",myOpStockInfo.CompanyId},
                {"@category_id",myOpStockInfo.CategoryId},
                {"@model_id",myOpStockInfo.ModelId},
                {"@brand_id",myOpStockInfo.BrandId},
                {"@colour_id",myOpStockInfo.ColourId},
                {"@size_id",myOpStockInfo.SizeId},
                {"@supplier_id",myOpStockInfo.SupplierId},
                {"@addi_descrip",myOpStockInfo.AddiDescrip},
                {"@batch",myOpStockInfo.Batch},
                {"@exp_date",DBNull.Value },
                {"@qty",myOpStockInfo.Qty},
                {"@free_qty",myOpStockInfo.FreeQty},
                {"@qty_2",myOpStockInfo.Qty2},
                {"@total_qty",myOpStockInfo.TotalQty},
                {"@sticker_qty",myOpStockInfo.StickerQty},
                {"@unit_rate",myOpStockInfo.UnitRate},
                {"@total_Amount",myOpStockInfo.TotalAmount},
                {"@disc_perc",myOpStockInfo.DiscPerc},
                {"@discount",myOpStockInfo.Discount},
                {"@discount_2",myOpStockInfo.Discount2},
                {"@gross_value",myOpStockInfo.GrossValue },
                {"@exice_duty_perc",myOpStockInfo.ExiceDuty},
                {"@exice_duty",myOpStockInfo.ExiceDutyPerc},
                {"@gst_perc",myOpStockInfo.GstPerc},
                {"@gst_amount",myOpStockInfo.GstAmount},
                {"@net_value",myOpStockInfo.NetValue},
                {"@vat_perc",myOpStockInfo.VatPerc},
                {"@vat_amount",myOpStockInfo.VatAmount},
                {"@cess_perc",myOpStockInfo.CessPerc},
                {"@cess_amount",myOpStockInfo.CessAmount},
                {"@grand_total",myOpStockInfo.GrandTotal},
                {"@add_cost",myOpStockInfo.AddCost},
                {"@cost",myOpStockInfo.Cost},
                {"@reatil_rate_pro",myOpStockInfo.ReatilRatePro},
                {"@retail_rate",myOpStockInfo.RetailRate},
                {"@mrp_pro",myOpStockInfo.MrpPro},
                {"@mrp",myOpStockInfo.Mrp},
                {"@special_rate_pro",myOpStockInfo.SpecialRatePro},
                {"@special_rate",myOpStockInfo.SpecialRate},
                {"@whoe_sale_pro",myOpStockInfo.WhoeSalePro},
                {"@whole_sale",myOpStockInfo.WholeSale},
                {"@branch_rate_pro",myOpStockInfo.BranchRatePro},
                {"@branch_rate",myOpStockInfo.BranchRate},
                {"@item_bar_code",myOpStockInfo.ItemBarCode},
                {"@godown_id",myOpStockInfo.GodownId}
                };

            }
            else
            {
                obj = new object[48, 2]
                {
                {"@entry_no",myOpStockInfo.EntryNo },
                {"@bar_code",myOpStockInfo.BarCode},
                {"@item_id",myOpStockInfo.ItemId},
                {"@company_id",myOpStockInfo.CompanyId},
                {"@category_id",myOpStockInfo.CategoryId},
                {"@model_id",myOpStockInfo.ModelId},
                {"@brand_id",myOpStockInfo.BrandId},
                {"@colour_id",myOpStockInfo.ColourId},
                {"@size_id",myOpStockInfo.SizeId},
                {"@supplier_id",myOpStockInfo.SupplierId},
                {"@addi_descrip",myOpStockInfo.AddiDescrip},
                {"@batch",myOpStockInfo.Batch},
                {"@exp_date",myOpStockInfo.ExpDate},
                {"@qty",myOpStockInfo.Qty},
                {"@free_qty",myOpStockInfo.FreeQty},
                {"@qty_2",myOpStockInfo.Qty2},
                {"@total_qty",myOpStockInfo.TotalQty},
                {"@sticker_qty",myOpStockInfo.StickerQty},
                {"@unit_rate",myOpStockInfo.UnitRate},
                {"@total_Amount",myOpStockInfo.TotalAmount},
                {"@disc_perc",myOpStockInfo.DiscPerc},
                {"@discount",myOpStockInfo.Discount},
                {"@discount_2",myOpStockInfo.Discount2},
                {"@gross_value",myOpStockInfo.GrossValue },
                {"@exice_duty_perc",myOpStockInfo.ExiceDuty},
                {"@exice_duty",myOpStockInfo.ExiceDutyPerc},
                {"@gst_perc",myOpStockInfo.GstPerc},
                {"@gst_amount",myOpStockInfo.GstAmount},
                {"@net_value",myOpStockInfo.NetValue},
                {"@vat_perc",myOpStockInfo.VatPerc},
                {"@vat_amount",myOpStockInfo.VatAmount},
                {"@cess_perc",myOpStockInfo.CessPerc},
                {"@cess_amount",myOpStockInfo.CessAmount},
                {"@grand_total",myOpStockInfo.GrandTotal},
                {"@add_cost",myOpStockInfo.AddCost},
                {"@cost",myOpStockInfo.Cost},
                {"@reatil_rate_pro",myOpStockInfo.ReatilRatePro},
                {"@retail_rate",myOpStockInfo.RetailRate},
                {"@mrp_pro",myOpStockInfo.MrpPro},
                {"@mrp",myOpStockInfo.Mrp},
                {"@special_rate_pro",myOpStockInfo.SpecialRatePro},
                {"@special_rate",myOpStockInfo.SpecialRate},
                {"@whoe_sale_pro",myOpStockInfo.WhoeSalePro},
                {"@whole_sale",myOpStockInfo.WholeSale},
                {"@branch_rate_pro",myOpStockInfo.BranchRatePro},
                {"@branch_rate",myOpStockInfo.BranchRate},
                {"@item_bar_code",myOpStockInfo.ItemBarCode},
                {"@godown_id",myOpStockInfo.GodownId}
                };

            }
            //myDbTask.ExecuteNonQuery_SP("insert_opening_stock_details", obj);
        }
        public void insertOpStockMaster(opStockInfo myOpStockInfo)
        {
            object[,] obj = new object[6, 2]
                {
                    {"@entry_no",myOpStockInfo.EntryNo },
                    {"@entry_date",myOpStockInfo.EntryDate },
                    {"@entry_time",myOpStockInfo.EntryTime },
                    {"@update_date",myOpStockInfo.UpdateDate },
                    {"@update_time",myOpStockInfo.UpdateTime },
                    {"@description",myOpStockInfo.Description }
                };
            //myDbTask.ExecuteNonQuery_SP("insert_opening_stock_master", obj);
        

          
        }
        public void updateOpStockMaster(opStockInfo myOpStockInfo)
        {
            object[,] obj = new object[6, 2]
                {
                     {"@entry_no",myOpStockInfo.EntryNo },
                    {"@entry_date",myOpStockInfo.EntryDate },
                    {"@entry_time",myOpStockInfo.EntryTime },
                    {"@update_date",myOpStockInfo.UpdateDate },
                    {"@update_time",myOpStockInfo.UpdateTime },
                    {"@description",myOpStockInfo.Description }
                };
            //myDbTask.ExecuteNonQuery_SP("update_opening_stock_master", obj);
        }
        public DataSet selectAOpStockDetails(opStockInfo myOpStockInfo)
        {
            object[,] obj = new object[1, 2]
                   {
                    {"@entry_no",myOpStockInfo.EntryNo },

                   };
            DataSet details = myDbTask.ExecuteQuery_SP("select_a_opening_stock_details", obj);

            return details;
        }

    }
}
