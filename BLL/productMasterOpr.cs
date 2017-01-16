using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DAL;
using BEL;

namespace BLL
{
    public class productMasterOpr
    {
        DbTask mydbtas = new DbTask();
        public DataSet selectMasterSelectedItems_ProductGroup()
        {
            object[,] postImageRetrive = new object[1, 2]
          {

                { "@quary_varc","select * from tblProductGroup"},
              };
            DataSet allrouteDs = mydbtas.ExecuteQuery_SP("execute_simple_queries", postImageRetrive);
            return allrouteDs;
        }
        public DataSet selectMasterSelectedItems_ProductCompany()
        {
            object[,] postImageRetrive = new object[1, 2]
          {

                { "@quary_varc","select * from tblProductCompany"},
              };
            DataSet allrouteDs = mydbtas.ExecuteQuery_SP("execute_simple_queries", postImageRetrive);
            return allrouteDs;
        }
        public DataSet selectMasterSelectedItems_Category()
        {
            object[,] postImageRetrive = new object[1, 2]
          {

                { "@quary_varc","select * from tblProductCategory"},
              };
            DataSet allrouteDs = mydbtas.ExecuteQuery_SP("execute_simple_queries", postImageRetrive);
            return allrouteDs;
        }
        public DataSet selectMasterSelectedItems_Model()
        {
            object[,] postImageRetrive = new object[1, 2]
          {

                { "@quary_varc","select * from tblModel"},
              };
            DataSet allrouteDs = mydbtas.ExecuteQuery_SP("execute_simple_queries", postImageRetrive);
            return allrouteDs;
        }
        public DataSet selectMasterSelectedItems_Brand()
        {
            object[,] postImageRetrive = new object[1, 2]
          {

                { "@quary_varc","select * from tblBrand"},
              };
            DataSet allrouteDs = mydbtas.ExecuteQuery_SP("execute_simple_queries", postImageRetrive);
            return allrouteDs;
        }
        public DataSet selectMasterSelectedItems_Unit()
        {
            object[,] postImageRetrive = new object[1, 2]
          {

                { "@quary_varc","select * from tblUnit"},
              };
            DataSet allrouteDs = mydbtas.ExecuteQuery_SP("execute_simple_queries", postImageRetrive);
            return allrouteDs;
        }
        public DataSet selectMasterSelectedItems_ProductUnit()
        {
            object[,] postImageRetrive = new object[1, 2]
          {

                { "@quary_varc","select * from tblUnit "},
              };
            DataSet allrouteDs = mydbtas.ExecuteQuery_SP("execute_simple_queries", postImageRetrive);
            return allrouteDs;
        }
        public DataSet selectMasterSelectedItems_ProductUnits()
        {
            object[,] postImageRetrive = new object[1, 2]
          {

                { "@quary_varc","select * from tblUnit "},
              };
            DataSet allrouteDs = mydbtas.ExecuteQuery_SP("execute_simple_queries", postImageRetrive);
            return allrouteDs;
        }
        public long insertProductMasters(productMasterInfo Pmstrs)
        {
            object[,] productInserts = new object[5, 2]
            {

                  { "@product_name", Pmstrs.ProductName},
                  { "@product_code", Pmstrs.ProductCode},
                  { "@alternate_name",Pmstrs.Alternate_name},
                  { "@additional_description",Pmstrs.Additionaldescription},
                  { "@bar_Code", Pmstrs.BarCode}
                };
            DataSet Ds = mydbtas.ExecuteQuery_SP("insert_product_Master", productInserts);
            return Convert.ToInt64(Ds.Tables[0].Rows[0][0]);

        }
        public void insertProductMastersAttribute(productMasterInfo Pmstrs)
        {
            object[,] productInserts = new object[1, 2]
            {
                ////
                
                { "@quary_varc","insert into [dbo].[tblProductAttribute](product_Id, product_group_id,pro_company_id,pro_category_id,model_id,brand_id) values ('"+Pmstrs.ProductId+"','" + Pmstrs.ProductGroupid+ "','" +Pmstrs.ProductCompanyId + "','" +Pmstrs.ProductCategoryId + "','" + Pmstrs.ModelId + "','" + Pmstrs.BrandId + "')"},

                };
            //mydbtas.ExecuteNonQuery_SP("execute_simple_queries", productInserts);


        }
        public void insertProductMastersTaxDetails(productMasterInfo PmstrsInfo)
        {
            object[,] productInserts = new object[1, 2]
            {

                 {"@quary_varc","insert into [dbo].[tblTaxDetails](product_Id, rate_of_tax_sale,rate_of_tax_purchase,rate_of_cess,Commodity_Code,exice_duty,gst) values ('"+PmstrsInfo.ProductId+"','" + PmstrsInfo.RateofTaxSale+ "','" +PmstrsInfo.RateofTaxPurchase + "','" +PmstrsInfo.RateofCess + "','" + PmstrsInfo.CommodityCode + "','" + PmstrsInfo.ExiceDuty + "','"+PmstrsInfo.GST+"')"},

                };
            //mydbtas.ExecuteNonQuery_SP("execute_simple_queries", productInserts);


        }
        public void insertProductMasterStockDetails(productMasterInfo PmasterInfo)
        {
            object[,] productMasterStockInserts = new object[1, 2]
            {
                {"@quary_varc","insert into [dbo].[tblStockDetails](product_Id, stock_type,min_stock,max_stock,reorder_level) values ('"+PmasterInfo.ProductId+"','" + PmasterInfo.StockType+ "','" +PmasterInfo.MinStock + "','" +PmasterInfo.MaxStock + "','"+PmasterInfo.ReOrderLevel+"')" },
            };
            //mydbtas.ExecuteNonQuery_SP("execute_simple_queries", productMasterStockInserts);
        }

        public void insertProductMasterUnitDetails(productMasterInfo PmasterInfo)
        {
            object[,] productMasterStockInserts = new object[1, 2]
            {
                {"@quary_varc","insert into [dbo].[tblUnitDetails](product_Id, dimension,volume,weight,unit) values ('"+PmasterInfo.ProductId+"','" + PmasterInfo.Dimension+ "','" +PmasterInfo.Volume + "','" +PmasterInfo.Weight + "','"+PmasterInfo.Unit+"')" },
            };
            //mydbtas.ExecuteNonQuery_SP("execute_simple_queries", productMasterStockInserts);
        }
        public void insertProductUnits(productMasterInfo PmasterInfo)
        {
            object[,] productMasterStockInserts = new object[1, 2]
        {
                {"@quary_varc","insert into [dbo].[tblProductUnit](product_Id,unit_No,factor,disc_Qty,purchase_rate,purchase_Disc,mrp,mrp_Disc,retail,retail_Disc,special_rate,special_Disc,whole_sale,whole_sale_Disc,branch_rate,branch_Disc) values ('"+PmasterInfo.ProductId+"','" + PmasterInfo.UnitNo+ "','" +PmasterInfo.Factor + "','" +PmasterInfo.DiscQty + "','"+PmasterInfo.PurchaseRate+"','"+PmasterInfo.PurchaseDisc+"','"+PmasterInfo.Mrp+"','"+PmasterInfo.MrpDisc+"','"+PmasterInfo.Retail+"','"+PmasterInfo.RetailDisc+"','"+PmasterInfo.SpecialRate+"','"+PmasterInfo.SpecialDisc+"','"+PmasterInfo.WholeSale+"','"+PmasterInfo.WholeSaleDisc+"','"+PmasterInfo.BranchRate+"','"+PmasterInfo.BranchDisc+"')" }
        };
            //mydbtas.ExecuteNonQuery_SP("execute_simple_queries", productMasterStockInserts);
        }
        public void insertProductDiscounts(productMasterInfo PmasterInfo)
        {
            object[,] productMasterStockInserts = new object[1, 2]
            {
                {"@quary_varc","insert into [dbo].[tblProductDiscount](product_Id, purchase_Discount,sales_Discount,special_Discount,agent_Commission) values ('"+PmasterInfo.ProductId+"','" + PmasterInfo.PurchaseDiscount+ "','" +PmasterInfo.SalesDiscount + "','" +PmasterInfo.SpecialDiscount + "','"+PmasterInfo.AgentCommission+"')" },
            };
            //mydbtas.ExecuteNonQuery_SP("execute_simple_queries", productMasterStockInserts);
        }
        public DataSet selectAllProductMasterDetails(productMasterInfo pmasterInfo)
        {
            object[,] postInserts = new object[1, 2]
            {

                { "@quary_varc",pmasterInfo.Query},
                };
            DataSet allDetails = mydbtas.ExecuteQuery_SP("execute_simple_queries", postInserts);
            return allDetails;


        }
        public DataSet selectAllProductMasterData(productMasterInfo pmasterInfo)
        {
            object[,] postInserts = new object[1, 2]
            {
                 { "@product_Id",pmasterInfo.ProductId},
            };
            DataSet allDetails = mydbtas.ExecuteQuery_SP("select_a_product_details", postInserts);
            return allDetails;



        }

        //Nabeel start
        public DataSet selectProductUnitDetails(productMasterInfo pmasterInfo)
        {
            object[,] postInserts = new object[1, 2]
            {
                 { "@product_Id",pmasterInfo.ProductId},
            };
            DataSet allDetails = mydbtas.ExecuteQuery_SP("select_items_alternate_units_by_item_id", postInserts);
            return allDetails;
        }
        //nabeel end
        public DataSet SelectUnitsByProduct(int ProductID)
        {
            object[,] postInserts = new object[1, 2]
            {
                 { "@product_Id",ProductID},
            };
            DataSet Units= mydbtas.ExecuteQuery_SP("select_units_by_product", postInserts);
            return Units;
        }
    }
}
