using BAL;
using BEL;
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace TrueAccountPro
{
    public partial class frmUpdateBarCode : Telerik.WinControls.UI.RadForm
    {
        private DataSet ds;
        private DataTable dt,dt1;
        private long ItemCode,UnitID;
        private decimal Cost;
        public static long Count=-1;
        #region Constructors
        public frmUpdateBarCode()
        {
            InitializeComponent();
        }
        public frmUpdateBarCode(DataSet ds, long itemCode, long unitID, decimal cost)
        {
            InitializeComponent();
            this.ds = ds;
            this.dt = ds.Tables[0];
            this.dt1 = ds.Tables[1];
            this.ItemCode = itemCode;
            this.Cost = cost;
            this.UnitID = unitID;
            bindProductDetailsToGrid();
            bindProductCompanytoGrid();
            bindProductModeltoGrid();
            bindProductBrandtoGrid();
            bindProductCategorytoGrid();
            bindProductColourtoGrid();
            bindProductSizetoGrid();
            //bindProductUnitsToGrid();
            FillBarCodeGrid(dt);
            FillUnitGrid(dt1);
            LoadUnitDetails(ItemCode);
            radGroupBox1.Visible = false;
        }
        #endregion Constructors
        #region Objects And Variables
        mastersInfo myMasterInfo = new mastersInfo();
        mastersOpr myMasterOpr = new mastersOpr();

        barCodeRegistryInfo myBarCodeRegInfo = new barCodeRegistryInfo();
        barCodeRegistryOpr myBarCodeRegOpr = new barCodeRegistryOpr();

        productMasterInfo myProductMasterInfo = new productMasterInfo();
        productMasterOpr myProductMasterOpr = new productMasterOpr();

        genaralFunctions myGenaralFunctions = new genaralFunctions();
        DataSet myUnitsDs;
        DataTable myUnitDetailsDt;
        private static string EntryID;
        private static long EntryNo;
        #endregion Objects And Variables
        #region FillGrid
        public void FillBarCodeGrid(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rdgvBarCode.Rows.AddNew();
                    rdgvBarCode.Rows[i].Cells["clmBarcodeId"].Value = dt.Rows[i]["bar_code_id"];
                    rdgvBarCode.Rows[i].Cells["clmBarcode"].Value = dt.Rows[i]["bar_code"];
                    rdgvBarCode.Rows[i].Cells["clmItemCode"].Value = dt.Rows[i]["item_id"];
                    rdgvBarCode.Rows[i].Cells["clmCompany"].Value = dt.Rows[i]["company_id"];
                    rdgvBarCode.Rows[i].Cells["clmCategory"].Value = dt.Rows[i]["category_id"];
                    rdgvBarCode.Rows[i].Cells["clmModel"].Value = dt.Rows[i]["model_id"];
                    rdgvBarCode.Rows[i].Cells["clmBrand"].Value = dt.Rows[i]["brand_id"];
                    rdgvBarCode.Rows[i].Cells["clmColour"].Value = dt.Rows[i]["colour_id"];
                    rdgvBarCode.Rows[i].Cells["clmSize"].Value = dt.Rows[i]["size_id"];
                    rdgvBarCode.Rows[i].Cells["clmBatch"].Value = dt.Rows[i]["batch"];
                    rdgvBarCode.Rows[i].Cells["clmExpDate"].Value = dt.Rows[i]["exp_date"];
                    rdgvBarCode.Rows[i].Cells["clmAddCost"].Value = dt.Rows[i]["add_cost"];
                    rdgvBarCode.Rows[i].Cells["clmCost"].Value = dt.Rows[i]["cost"];
                    rdgvBarCode.Rows[i].Cells["clmRetailPro"].Value = dt.Rows[i]["reatil_rate_pro"];
                    rdgvBarCode.Rows[i].Cells["clmRetailRate"].Value = dt.Rows[i]["retail_rate"];
                    rdgvBarCode.Rows[i].Cells["clmMrpPro"].Value = dt.Rows[i]["mrp_pro"];
                    rdgvBarCode.Rows[i].Cells["clmMrp"].Value = dt.Rows[i]["mrp"];
                    rdgvBarCode.Rows[i].Cells["clmSpecialratePro"].Value = dt.Rows[i]["special_rate_pro"];
                    rdgvBarCode.Rows[i].Cells["clmSpRate"].Value = dt.Rows[i]["special_rate"];
                    rdgvBarCode.Rows[i].Cells["clmWhPro"].Value = dt.Rows[i]["whoe_sale_pro"];
                    rdgvBarCode.Rows[i].Cells["clmWholeSale"].Value = dt.Rows[i]["whole_sale"];
                    rdgvBarCode.Rows[i].Cells["clmBranchPro"].Value = dt.Rows[i]["branch_rate_pro"];
                    rdgvBarCode.Rows[i].Cells["clmBranchRate"].Value = dt.Rows[i]["branch_rate"];
                    rdgvBarCode.Rows[i].Cells["clmItemBarCode"].Value = dt.Rows[i]["item_bar_code"];
                    rdgvBarCode.Rows[i].Cells["clmEntryID"].Value = dt.Rows[i]["entry_id"];
                    rdgvBarCode.Rows[i].Cells["clmEntryNo"].Value = dt.Rows[i]["entry_no"];
                    EntryID= dt.Rows[i]["entry_id"].ToString();
                    EntryNo = Convert.ToInt64(dt.Rows[i]["entry_no"]);
                }
            }
        }
        #endregion FillGrid
        #region FillUnitGrid
        public void FillUnitGrid(DataTable dt1)
        {
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    rdgvUnitRate.Rows.AddNew();
                    rdgvUnitRate.Rows[i].Cells["clmRowId"].Value = dt1.Rows[i]["row_id"];
                    rdgvUnitRate.Rows[i].Cells["clmBarcodeId"].Value = dt1.Rows[i]["bar_code_id"];
                    rdgvUnitRate.Rows[i].Cells["clmUnitId"].Value = dt1.Rows[i]["unit_id"].ToString();
                    rdgvUnitRate.Rows[i].Cells["clmCost"].Value = dt1.Rows[i]["cost"].ToString();
                    rdgvUnitRate.Rows[i].Cells["clmRetailPro"].Value = dt1.Rows[i]["reatil_rate_pro"].ToString();
                    rdgvUnitRate.Rows[i].Cells["clmRetailRate"].Value = dt1.Rows[i]["retail_rate"].ToString();
                    rdgvUnitRate.Rows[i].Cells["clmMrpPro"].Value = dt1.Rows[i]["mrp_pro"].ToString();
                    rdgvUnitRate.Rows[i].Cells["clmMrp"].Value = dt1.Rows[i]["mrp"].ToString();
                    rdgvUnitRate.Rows[i].Cells["clmSpecialratePro"].Value = dt1.Rows[i]["special_rate_pro"].ToString();
                    rdgvUnitRate.Rows[i].Cells["clmSpRate"].Value = dt1.Rows[i]["special_rate"].ToString();
                    rdgvUnitRate.Rows[i].Cells["clmWhPro"].Value = dt1.Rows[i]["whoe_sale_pro"].ToString();
                    rdgvUnitRate.Rows[i].Cells["clmWholeSale"].Value = dt1.Rows[i]["whole_sale"].ToString();
                    rdgvUnitRate.Rows[i].Cells["clmBranchPro"].Value = dt1.Rows[i]["branch_rate_pro"].ToString();
                    rdgvUnitRate.Rows[i].Cells["clmBranchRate"].Value = dt1.Rows[i]["branch_rate"].ToString();
                }
            }
        }
        #endregion FillUnitGrid
        #region bindProductDetailsToGrid
        private void bindProductDetailsToGrid()
        {
            myProductMasterInfo.Query = "select product_Id,product_code,product_name,alternate_name from tblProductMaster";
            DataSet details = myProductMasterOpr.selectAllProductMasterDetails(myProductMasterInfo);

            BindingSource productBs = new BindingSource();

            productBs.DataSource = details.Tables[0];

            ((GridViewMultiComboBoxColumn)rdgvBarCode.Columns["clmItemCode"]).ValueMember = "product_id";
            ((GridViewMultiComboBoxColumn)rdgvBarCode.Columns["clmItemCode"]).DisplayMember = "product_code";
            ((GridViewMultiComboBoxColumn)rdgvBarCode.Columns["clmItemCode"]).DataSource = productBs;

            ((GridViewMultiComboBoxColumn)rdgvBarCode.Columns["clmItemName"]).ValueMember = "product_id";
            ((GridViewMultiComboBoxColumn)rdgvBarCode.Columns["clmItemName"]).DisplayMember = "product_name";
            ((GridViewMultiComboBoxColumn)rdgvBarCode.Columns["clmItemName"]).DataSource = productBs;
        }
        #endregion bindProductDetailsToGrid
        #region bindProductModeltoGrid
        private void bindProductModeltoGrid()
        {
            myMasterInfo.Query = "SELECT model_Id as id, model_name as name, model_description as description from tblModel";
            DataSet modelDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource modelBS = new BindingSource();
            modelBS.DataSource = modelDts.Tables[0];

            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmModel"]).ValueMember = "id";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmModel"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmModel"]).DataSource = modelBS;

        }
        #endregion bindProductModeltoGrid
        #region bindProductCategorytoGrid
        private void bindProductCategorytoGrid()
        {
            myMasterInfo.Query = "SELECT product_category_id as id, product_category_name as name, product_category_description as description from tblProductCategory";

            DataSet modelDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];


            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmCategory"]).ValueMember = "id";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmCategory"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmCategory"]).DataSource = brandBs;
        }
        #endregion bindProductCategorytoGrid
        #region bindProductBrandtoGrid
        private void bindProductBrandtoGrid()
        {
            myMasterInfo.Query = " SELECT brand_Id as id, brand_name as name, brand_description as description from tblBrand";

            DataSet modelDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];


            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmBrand"]).ValueMember = "id";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmBrand"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmBrand"]).DataSource = brandBs;
        }
        #endregion bindProductBrandtoGrid
        #region bindProductColourtoGrid
        private void bindProductColourtoGrid()
        {
            myMasterInfo.Query = " SELECT colour_id as id, colour_name as name, colour_description as description from tblColour";

            DataSet modelDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];


            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmColour"]).ValueMember = "id";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmColour"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmColour"]).DataSource = brandBs;
        }
        #endregion bindProductColourtoGrid
        #region bindProductSizetoGrid
        private void bindProductSizetoGrid()
        {
            myMasterInfo.Query = " SELECT size_id as id, size_name as name, size_description as description from tblSize";

            DataSet modelDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmSize"]).ValueMember = "id";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmSize"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmSize"]).DataSource = brandBs;
        }
        #endregion bindProductSizetoGrid
        #region bindProductCompanytoGrid
        private void bindProductCompanytoGrid()
        {
            myMasterInfo.Query = "SELECT pro_companyId as id, pro_company_name as name, pro_company_description as description from tblProductCompany";
            DataSet companyDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource companyBS = new BindingSource();
            companyBS.DataSource = companyDts.Tables[0];

            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmCompany"]).ValueMember = "id";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmCompany"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmCompany"]).DataSource = companyBS;
        }
        #endregion bindProductCompanytoGrid
        #region bindProductUnitsToGrid
        private void bindProductUnitsToGrid()
        {
            myMasterInfo.Query = "SELECT * from tblUnit";
            myUnitsDs = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            myUnitDetailsDt = myUnitsDs.Tables[0];

            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmUnit"]).ValueMember = "unit_id";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmUnit"]).DisplayMember = "unit_name";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmUnit"]).DataSource = myUnitDetailsDt;

            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmFreeQtyUnit"]).ValueMember = "unit_id";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmFreeQtyUnit"]).DisplayMember = "unit_name";
            ((GridViewComboBoxColumn)rdgvBarCode.Columns["clmFreeQtyUnit"]).DataSource = myUnitDetailsDt;
        }
        #endregion bindProductUnitsToGrid
        #region Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Close
        #region Update
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCon.OpenSqlCon();
            SqlTransaction myTran = SqlCon._sqlCon.BeginTransaction();
            DialogResult Result = RadMessageBox.Show("Do You Want To Update BarCode", "TrueAccountPro", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (Result == DialogResult.Yes)
            {
                if (UpdateBarCodeRegistry(myTran))
                    if (DeleteUnitRateDetails(myTran))
                        if (InsertUnitRateDetails(myTran))
                            Commit(myTran);
                        else
                            RollBack(myTran);
                    else
                        RollBack(myTran);
                else
                    RollBack(myTran);
            }
            else
                SqlCon._sqlCon.Close();
        }
        #endregion Update
        #region BarCode Update
        public bool UpdateBarCodeRegistry(SqlTransaction myTran)
        {
            bool LineFlag = false;
            for (int i = 0; i < rdgvBarCode.RowCount; i++)
            {
                if (rdgvBarCode.Rows[i].Cells["clmItemCode"].Value != null && rdgvBarCode.Rows[i].Cells["clmItemCode"].Value.ToString().Trim() != "")
                {
                    if (rdgvBarCode.Rows[i].Cells["clmBarcodeId"].Value != null || Convert.ToInt64(rdgvBarCode.Rows[i].Cells["clmBarcodeId"].Value) <= 0)
                    {
                        //if (Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmSelect"].Value)>0)
                        //{
                            myBarCodeRegInfo.ourCount = 1;
                            myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(rdgvBarCode.Rows[i].Cells["clmBarcodeId"].Value.ToString());
                            myBarCodeRegInfo.ourBarCode = rdgvBarCode.Rows[i].Cells["clmBarcode"].Value != null ? rdgvBarCode.Rows[i].Cells["clmBarcode"].Value.ToString() : "";
                            myBarCodeRegInfo.ourItemId = Convert.ToInt64(rdgvBarCode.Rows[i].Cells["clmItemCode"].Value);
                            myBarCodeRegInfo.ourCompanyId = rdgvBarCode.Rows[i].Cells["clmCompany"].Value != null ? Convert.ToInt64(rdgvBarCode.Rows[i].Cells["clmCompany"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourCategoryId = rdgvBarCode.Rows[i].Cells["clmCategory"].Value != null ? Convert.ToInt64(rdgvBarCode.Rows[i].Cells["clmCategory"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourModelId = rdgvBarCode.Rows[i].Cells["clmModel"].Value != null ? Convert.ToInt64(rdgvBarCode.Rows[i].Cells["clmModel"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourBrandId = rdgvBarCode.Rows[i].Cells["clmBrand"].Value != null ? Convert.ToInt64(rdgvBarCode.Rows[i].Cells["clmBrand"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourColourId = rdgvBarCode.Rows[i].Cells["clmColour"].Value != null ? Convert.ToInt64(rdgvBarCode.Rows[i].Cells["clmColour"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourSizeId = rdgvBarCode.Rows[i].Cells["clmSize"].Value != null ? Convert.ToInt64(rdgvBarCode.Rows[i].Cells["clmSize"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourBatch = rdgvBarCode.Rows[i].Cells["clmBatch"].Value != null ? rdgvBarCode.Rows[i].Cells["clmBatch"].Value.ToString() : "";
                            if (rdgvBarCode.Rows[i].Cells["clmExpDate"].Value != null)
                                myBarCodeRegInfo.ourExpDate = Convert.ToDateTime(rdgvBarCode.Rows[i].Cells["clmExpDate"].Value.ToString());
                            else
                                myBarCodeRegInfo.ourExpDate = null;
                            myBarCodeRegInfo.ourAddCost = rdgvBarCode.Rows[i].Cells["clmAddCost"].Value != null ? Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmAddCost"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourCost = rdgvBarCode.Rows[i].Cells["clmCost"].Value != null ? Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmCost"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourReatilRatePro = rdgvBarCode.Rows[i].Cells["clmRetailPro"].Value != null ? Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmRetailPro"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourRetailRate = rdgvBarCode.Rows[i].Cells["clmRetailRate"].Value != null ? Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmRetailRate"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourMrpPro = rdgvBarCode.Rows[i].Cells["clmMrpPro"].Value != null ? Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmMrpPro"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourMrp = rdgvBarCode.Rows[i].Cells["clmMrp"].Value != null ? Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmMrp"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourSpecialRatePro = rdgvBarCode.Rows[i].Cells["clmSpecialratePro"].Value != null ? Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmSpecialratePro"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourSpecialRate = rdgvBarCode.Rows[i].Cells["clmSpRate"].Value != null ? Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmSpRate"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourWhoeSalePro = rdgvBarCode.Rows[i].Cells["clmWhPro"].Value != null ? Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmWhPro"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourWholeSale = rdgvBarCode.Rows[i].Cells["clmWholeSale"].Value != null ? Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmWholeSale"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourBranchRatePro = rdgvBarCode.Rows[i].Cells["clmBranchPro"].Value != null ? Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmBranchPro"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourBranchRate = rdgvBarCode.Rows[i].Cells["clmBranchRate"].Value != null ? Convert.ToDecimal(rdgvBarCode.Rows[i].Cells["clmBranchRate"].Value.ToString()) : 0;
                            myBarCodeRegInfo.ourItemBarCode = rdgvBarCode.Rows[i].Cells["clmItemBarcode"].Value != null ? rdgvBarCode.Rows[i].Cells["clmItemBarcode"].Value.ToString() : "";
                            myBarCodeRegInfo.ourEntryId = rdgvBarCode.Rows[i].Cells["clmEntryID"].Value != null ? rdgvBarCode.Rows[i].Cells["clmEntryID"].Value.ToString() : "";
                            myBarCodeRegInfo.ourEntryNo = rdgvBarCode.Rows[i].Cells["clmEntryNo"].Value != null ? Convert.ToInt64(rdgvBarCode.Rows[i].Cells["clmEntryNo"].Value) : 0;
                            if (myBarCodeRegOpr.InsertBarCodeRegistry(myBarCodeRegInfo, myTran))
                                    LineFlag = true;
                                else
                                    LineFlag = false;
                        //}
                    }
                }
            }
            return LineFlag;
        }
        #endregion BarCode Update
        #region InsertUnitRateDetails
        private bool InsertUnitRateDetails(SqlTransaction myTran)
        {
            bool LineFlag = false;
            if (rdgvUnitRate.Rows.Count > 0)
            {
                for (int i = 0; i < rdgvUnitRate.Rows.Count; i++)
                {
                    myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(rdgvUnitRate.Rows[i].Cells["clmBarcodeId"].Value.ToString());
                    myBarCodeRegInfo.ourUnitId = Convert.ToInt64(rdgvUnitRate.Rows[i].Cells["clmUnitId"].Value.ToString());
                    myBarCodeRegInfo.ourCost = Convert.ToDecimal(rdgvUnitRate.Rows[i].Cells["clmCost"].Value.ToString());
                    myBarCodeRegInfo.ourReatilRatePro = rdgvUnitRate.Rows[i].Cells["clmRetailPro"].Value!=null? Convert.ToDecimal(rdgvUnitRate.Rows[i].Cells["clmRetailPro"].Value.ToString()):0;
                    myBarCodeRegInfo.ourRetailRate = rdgvUnitRate.Rows[i].Cells["clmRetailRate"].Value!=null?Convert.ToDecimal(rdgvUnitRate.Rows[i].Cells["clmRetailRate"].Value.ToString()):0;
                    myBarCodeRegInfo.ourMrpPro = rdgvUnitRate.Rows[i].Cells["clmMrpPro"].Value!=null? Convert.ToDecimal(rdgvUnitRate.Rows[i].Cells["clmMrpPro"].Value.ToString()):0;
                    myBarCodeRegInfo.ourMrp = rdgvUnitRate.Rows[i].Cells["clmMrp"].Value!=null? Convert.ToDecimal(rdgvUnitRate.Rows[i].Cells["clmMrp"].Value.ToString()):0;
                    myBarCodeRegInfo.ourSpecialRatePro = rdgvUnitRate.Rows[i].Cells["clmSpecialratePro"].Value!=null? Convert.ToDecimal(rdgvUnitRate.Rows[i].Cells["clmSpecialratePro"].Value.ToString()):0;
                    myBarCodeRegInfo.ourSpecialRate = rdgvUnitRate.Rows[i].Cells["clmSpRate"].Value!=null? Convert.ToDecimal(rdgvUnitRate.Rows[i].Cells["clmSpRate"].Value.ToString()):0;
                    myBarCodeRegInfo.ourWhoeSalePro = rdgvUnitRate.Rows[i].Cells["clmWhPro"].Value!=null? Convert.ToDecimal(rdgvUnitRate.Rows[i].Cells["clmWhPro"].Value.ToString()):0;
                    myBarCodeRegInfo.ourWholeSale = rdgvUnitRate.Rows[i].Cells["clmWholeSale"].Value!=null?Convert.ToDecimal(rdgvUnitRate.Rows[i].Cells["clmWholeSale"].Value.ToString()):0;
                    myBarCodeRegInfo.ourBranchRatePro = rdgvUnitRate.Rows[i].Cells["clmBranchPro"].Value!=null? Convert.ToDecimal(rdgvUnitRate.Rows[i].Cells["clmBranchPro"].Value.ToString()):0;
                    myBarCodeRegInfo.ourBranchRate = rdgvUnitRate.Rows[i].Cells["clmBranchRate"].Value!=null? Convert.ToDecimal(rdgvUnitRate.Rows[i].Cells["clmBranchRate"].Value.ToString()):0;
                    myBarCodeRegInfo.ourEntryId = EntryID;
                    myBarCodeRegInfo.ourEntryNo = EntryNo;
                    if (myBarCodeRegOpr.InsertUnitRateDetails(myBarCodeRegInfo, myTran))
                        LineFlag = true;
                    else
                    {
                        LineFlag = false;
                        break;
                    }
                }
            }
            else
                LineFlag = true;
            return LineFlag;
        }
        #endregion InsertUnitRateDetails
        #region DeleteUnitRateDetails
        public bool DeleteUnitRateDetails(SqlTransaction myTran)
        {
            bool LineFlag = false;
            if (rdgvUnitRate.Rows.Count > 0)
            {
                //myBarCodeRegInfo.ourEntryId = EntryID;
                //myBarCodeRegInfo.ourEntryNo = EntryNo;
                myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(rdgvBarCode.Rows[0].Cells["clmBarcodeId"].Value);
                if (myBarCodeRegOpr.DeleteUnitRateDetailsFromUpdate(myBarCodeRegInfo, myTran))
                    LineFlag = true;
                else
                    LineFlag = false;
            }
            else
                LineFlag = true;
            return LineFlag;
        }
        #endregion DeleteUnitRateDetails
        #region ProcessCmdKey
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (rdgvBarCode.Focused)
            {
                if (msg.WParam.ToInt32() == (int)Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion ProcessCmdKey
        #region Commit
        public void Commit(SqlTransaction myTran)
        {
            myTran.Commit();
            myTran.Dispose();
            SqlCon._sqlCon.Close();
            this.Close();
            Clear();
            RadMessageBox.Show("BarCode Successfully Updated", "True Account Pro", MessageBoxButtons.OK, RadMessageIcon.Info);
        }
        #region Commit1
        public void Commit1(SqlTransaction myTran)
        {
            myTran.Commit();
            myTran.Dispose();
            SqlCon._sqlCon.Close();
            Clear();
            RadMessageBox.Show("BarCode Successfully Deleted", "True Account Pro", MessageBoxButtons.OK, RadMessageIcon.Info);
        }
        #endregion Commit1
        #endregion Commit
        #region rdgvBarCode_CellEndEdit
        private void rdgvBarCode_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.RowIndex);
            switch (rdgvBarCode.CurrentCell.ColumnInfo.Name.ToString())
            {
                case "clmRetailPro":
                    {
                        if (rdgvBarCode.Rows[rowIndex].Cells["clmRetailPro"].Value != null)
                            rdgvBarCode.Rows[rowIndex].Cells["clmRetailRate"].Value = calculateRate(Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmRetailPro"].Value.ToString()));
                        break;
                    }
                case "clmRetailRate":
                    {
                        if (rdgvBarCode.Rows[rowIndex].Cells["clmRetailRate"].Value != null)
                            rdgvBarCode.Rows[rowIndex].Cells["clmRetailPro"].Value = calculatePercentage(Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmRetailRate"].Value.ToString()));
                        break;
                    }
                case "clmMrpPro":
                    {
                        if (rdgvBarCode.Rows[rowIndex].Cells["clmMrpPro"].Value != null)
                            rdgvBarCode.Rows[rowIndex].Cells["clmMrp"].Value = calculateRate(Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmMrpPro"].Value.ToString()));
                        break;
                    }
                case "clmMrp":
                    {
                        if (rdgvBarCode.Rows[rowIndex].Cells["clmMrp"].Value != null)
                            rdgvBarCode.Rows[rowIndex].Cells["clmMrpPro"].Value = calculatePercentage(Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmMrp"].Value.ToString()));
                        break;
                    }
                case "clmSpecialratePro":
                    {
                        if (rdgvBarCode.Rows[rowIndex].Cells["clmSpecialratePro"].Value != null)
                            rdgvBarCode.Rows[rowIndex].Cells["clmSpRate"].Value = calculateRate(Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmSpecialratePro"].Value.ToString()));
                        break;
                    }
                case "clmSpRate":
                    {
                        if (rdgvBarCode.Rows[rowIndex].Cells["clmSpRate"].Value != null)
                            rdgvBarCode.Rows[rowIndex].Cells["clmSpecialratePro"].Value = calculatePercentage(Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmSpRate"].Value.ToString()));
                        break;
                    }
                case "clmWhPro":
                    {
                        if (rdgvBarCode.Rows[rowIndex].Cells["clmWhPro"].Value != null)
                            rdgvBarCode.Rows[rowIndex].Cells["clmWholeSale"].Value = calculateRate(Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmWhPro"].Value.ToString()));
                        break;
                    }
                case "clmWholeSale":
                    {
                        if (rdgvBarCode.Rows[rowIndex].Cells["clmWholeSale"].Value != null)
                            rdgvBarCode.Rows[rowIndex].Cells["clmWhPro"].Value = calculatePercentage(Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmWholeSale"].Value.ToString()));
                        break;
                    }
                case "clmBranchPro":
                    {
                        if (rdgvBarCode.Rows[rowIndex].Cells["clmBranchPro"].Value != null)
                            rdgvBarCode.Rows[rowIndex].Cells["clmBranchRate"].Value = calculateRate(Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmBranchPro"].Value.ToString()));
                        break;
                    }
                case "clmBranchRate":
                    {
                        if (rdgvBarCode.Rows[rowIndex].Cells["clmBranchRate"].Value != null)
                            rdgvBarCode.Rows[rowIndex].Cells["clmBranchPro"].Value = calculatePercentage(Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvBarCode.Rows[rowIndex].Cells["clmBranchRate"].Value.ToString()));
                        break;
                    }
            }
        }
        #endregion rdgvBarCode_CellEndEdit
        #region rdgvUnitRate_CellEndEdit
        private void rdgvUnitRate_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.RowIndex);
            switch (rdgvUnitRate.CurrentCell.ColumnInfo.Name.ToString())
            {
                case "clmRetailPro":
                    {
                        if (rdgvUnitRate.Rows[rowIndex].Cells["clmRetailPro"].Value != null)
                            rdgvUnitRate.Rows[rowIndex].Cells["clmRetailRate"].Value = calculateRate(Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmRetailPro"].Value.ToString()));
                        break;
                    }
                case "clmRetailRate":
                    {
                        if (rdgvUnitRate.Rows[rowIndex].Cells["clmRetailRate"].Value != null)
                            rdgvUnitRate.Rows[rowIndex].Cells["clmRetailPro"].Value = calculatePercentage(Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmRetailRate"].Value.ToString()));
                        break;
                    }
                case "clmMrpPro":
                    {
                        if (rdgvUnitRate.Rows[rowIndex].Cells["clmMrpPro"].Value != null)
                            rdgvUnitRate.Rows[rowIndex].Cells["clmMrp"].Value = calculateRate(Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmMrpPro"].Value.ToString()));
                        break;
                    }
                case "clmMrp":
                    {
                        if (rdgvUnitRate.Rows[rowIndex].Cells["clmMrp"].Value != null)
                            rdgvUnitRate.Rows[rowIndex].Cells["clmMrpPro"].Value = calculatePercentage(Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmMrp"].Value.ToString()));
                        break;
                    }
                case "clmSpecialratePro":
                    {
                        if (rdgvUnitRate.Rows[rowIndex].Cells["clmSpecialratePro"].Value != null)
                            rdgvUnitRate.Rows[rowIndex].Cells["clmSpRate"].Value = calculateRate(Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmSpecialratePro"].Value.ToString()));
                        break;
                    }
                case "clmSpRate":
                    {
                        if (rdgvUnitRate.Rows[rowIndex].Cells["clmSpRate"].Value != null)
                            rdgvUnitRate.Rows[rowIndex].Cells["clmSpecialratePro"].Value = calculatePercentage(Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmSpRate"].Value.ToString()));
                        break;
                    }
                case "clmWhPro":
                    {
                        if (rdgvUnitRate.Rows[rowIndex].Cells["clmWhPro"].Value != null)
                            rdgvUnitRate.Rows[rowIndex].Cells["clmWholeSale"].Value = calculateRate(Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmWhPro"].Value.ToString()));
                        break;
                    }
                case "clmWholeSale":
                    {
                        if (rdgvUnitRate.Rows[rowIndex].Cells["clmWholeSale"].Value != null)
                            rdgvUnitRate.Rows[rowIndex].Cells["clmWhPro"].Value = calculatePercentage(Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmWholeSale"].Value.ToString()));
                        break;
                    }
                case "clmBranchPro":
                    {
                        if (rdgvUnitRate.Rows[rowIndex].Cells["clmBranchPro"].Value != null)
                            rdgvUnitRate.Rows[rowIndex].Cells["clmBranchRate"].Value = calculateRate(Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmBranchPro"].Value.ToString()));
                        break;
                    }
                case "clmBranchRate":
                    {
                        if (rdgvUnitRate.Rows[rowIndex].Cells["clmBranchRate"].Value != null)
                            rdgvUnitRate.Rows[rowIndex].Cells["clmBranchPro"].Value = calculatePercentage(Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(rdgvUnitRate.Rows[rowIndex].Cells["clmBranchRate"].Value.ToString()));
                        break;
                    }
            }
        }
        #endregion rdgvUnitRate_CellEndEdit
        #region calculateRate
        private string calculateRate(decimal cost, decimal percentage)
        {
            decimal rate;
            rate = cost + (cost * percentage / 100);
            return myGenaralFunctions.FormatDecimalPlace(rate.ToString(), 2);
        }
        #endregion calculateRate
        #region calculatePercentage
        private string calculatePercentage(decimal cost, decimal rate)
        {
            decimal percentage;
            percentage = (rate - cost) * 100 / cost;
            return myGenaralFunctions.FormatDecimalPlace(percentage.ToString(), 2);
        }
        #endregion calculatePercentage
        #region RollBack
        public void RollBack(SqlTransaction myTran)
        {
            myTran.Rollback();
            myTran.Dispose();
            SqlCon._sqlCon.Close();
            RadMessageBox.Show("BarCode Updation Failed", "True Account Pro", MessageBoxButtons.OK, RadMessageIcon.Info);
        }
        #endregion RollBack
        #region RollBack1
        public void RollBack1(SqlTransaction myTran)
        {
            myTran.Rollback();
            myTran.Dispose();
            SqlCon._sqlCon.Close();
            RadMessageBox.Show("BarCode Deletion Failed", "True Account Pro", MessageBoxButtons.OK, RadMessageIcon.Info);
        }
        #endregion RollBack1
        #region Search
        private void txtSearchBarCode_TextChanged(object sender, EventArgs e)
        {
            rdgvBarCode.Rows.Clear();
            rdgvUnitRate.Rows.Clear();
            SearchBarCodeDetails();
        }
        #endregion Search
        #region rdgvBarCode_Click
        private void rdgvBarCode_Click(object sender, EventArgs e)
        {
            if (rdgvBarCode.Rows.Count > 0)
            {
                if (rdgvBarCode.Rows[0].Cells["clmBarcodeId"].Value != null)
                {
                    rdgvUnitRate.Rows.Clear();
                    DataSet ds1 = new DataSet();
                    myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(rdgvBarCode.Rows[rdgvBarCode.CurrentRow.Index].Cells["clmBarcodeId"].Value);
                    ds1= myBarCodeRegOpr.GetUnitRateDetails(myBarCodeRegInfo);
                    FillUnitGrid(ds1.Tables[0]);
                    long ItemCode = Convert.ToInt64(rdgvBarCode.Rows[rdgvBarCode.CurrentRow.Index].Cells["clmItemCode"].Value);
                    LoadUnitDetails(ItemCode);
                }
            }
        }
        #endregion rdgvBarCode_Click
        #region Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCon.OpenSqlCon();
            SqlTransaction myTran = SqlCon._sqlCon.BeginTransaction();
            DialogResult Result = RadMessageBox.Show("Are You Sure,Delete BarCode?", "TrueAccountPro", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (Result == DialogResult.Yes)
            {
                if (DeleteBarCodeRegistry(myTran))
                    Commit1(myTran);
                else
                    RollBack1(myTran);
            }
            else
                SqlCon._sqlCon.Close();
        }
        #endregion Delete
        #region LoadUnitDetails
        public void LoadUnitDetails(long Itemcode)
        {
            myProductMasterInfo.ProductId = Itemcode;
            DataSet detailsDs = myProductMasterOpr.selectProductUnitDetails(myProductMasterInfo);
            if (detailsDs.Tables[0].Rows.Count > 0)
            {
                DataTable detailsDt = detailsDs.Tables[0];
                string basicUnit = detailsDs.Tables[0].Rows[0]["unit_name"].ToString();
                if (UnitID != 0)
                    detailsDt.DefaultView.RowFilter = "unit_Id<>'" + UnitID + "'";
                detailsDt = detailsDt.DefaultView.ToTable();
                for (int i=0;i< rdgvUnitRate.Rows.Count;i++)
                {
                    detailsDt.DefaultView.RowFilter = "unit_Id<>'" + Convert.ToInt64(rdgvUnitRate.Rows[i].Cells["clmUnitId"].Value) + "'";
                }
                detailsDt = detailsDt.DefaultView.ToTable();
                if (detailsDt.Rows.Count > 0)
                {
                    foreach (DataRow dr in detailsDt.Rows)
                    {
                        GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.rdgvUnitRate.MasterView);
                        rdgvUnitRate.Rows.Insert(rdgvUnitRate.Rows.Count, dataRowInfo);
                        int i = rdgvUnitRate.Rows.Count - 1;
                        rdgvUnitRate.Rows[i].Cells["clmRowId"].Value = i + 1;
                        rdgvUnitRate.Rows[i].Cells["clmUnitId"].Value = dr["unit_Id"].ToString();
                        rdgvUnitRate.Rows[i].Cells["clmUnit"].Value = dr["unit_name"].ToString();
                        rdgvUnitRate.Rows[i].Cells["clmFactor"].Value = dr["factor"].ToString();
                        rdgvUnitRate.Rows[i].Cells["clmBarcodeId"].Value = rdgvBarCode.Rows[0].Cells["clmBarcodeId"].Value != null ? rdgvBarCode.Rows[0].Cells["clmBarcodeId"].Value : "";
                        rdgvUnitRate.Rows[i].Cells["clmBUnit"].Value = basicUnit;
                        rdgvUnitRate.Rows[i].Cells["clmCost"].Value = Math.Round(Cost * Convert.ToDecimal(dr["factor"]),2);
                    }
                }
            }
        }
        #endregion LoadUnitDetails
        #region Search BarCode Details
        public void SearchBarCodeDetails()
        {
            DataSet dsSearch = new DataSet();
            myBarCodeRegInfo.ourSearchText = txtSearchBarCode.Text;
            dsSearch = myBarCodeRegOpr.SearchBarCodeDetails(myBarCodeRegInfo);
            FillBarCodeGrid(dsSearch.Tables[0]);
            #region commented
            //if (dsSearch.Tables[0].Rows.Count > 0)
            //{
            //    for (int i = 0; i < dsSearch.Tables[0].Rows.Count; i++)
            //    {
            //        rdgvBarCode.Rows.AddNew();
            //        rdgvBarCode.Rows[i].Cells["clmBarcodeId"].Value = dsSearch.Tables[0].Rows[i]["bar_code_id"];
            //        rdgvBarCode.Rows[i].Cells["clmBarcode"].Value = dsSearch.Tables[0].Rows[i]["bar_code"];
            //        rdgvBarCode.Rows[i].Cells["clmItemCode"].Value = dsSearch.Tables[0].Rows[i]["item_id"];
            //        rdgvBarCode.Rows[i].Cells["clmCompany"].Value = dsSearch.Tables[0].Rows[i]["company_id"];
            //        rdgvBarCode.Rows[i].Cells["clmCategory"].Value = dsSearch.Tables[0].Rows[i]["category_id"];
            //        rdgvBarCode.Rows[i].Cells["clmModel"].Value = dsSearch.Tables[0].Rows[i]["model_id"];
            //        rdgvBarCode.Rows[i].Cells["clmBrand"].Value = dsSearch.Tables[0].Rows[i]["brand_id"];
            //        rdgvBarCode.Rows[i].Cells["clmColour"].Value = dsSearch.Tables[0].Rows[i]["colour_id"];
            //        rdgvBarCode.Rows[i].Cells["clmSize"].Value = dsSearch.Tables[0].Rows[i]["size_id"];
            //        rdgvBarCode.Rows[i].Cells["clmBatch"].Value = dsSearch.Tables[0].Rows[i]["batch"];
            //        rdgvBarCode.Rows[i].Cells["clmExpDate"].Value = dsSearch.Tables[0].Rows[i]["exp_date"];
            //        rdgvBarCode.Rows[i].Cells["clmAddCost"].Value = dsSearch.Tables[0].Rows[i]["add_cost"];
            //        rdgvBarCode.Rows[i].Cells["clmCost"].Value = dsSearch.Tables[0].Rows[i]["cost"];
            //        rdgvBarCode.Rows[i].Cells["clmRetailPro"].Value = dsSearch.Tables[0].Rows[i]["reatil_rate_pro"];
            //        rdgvBarCode.Rows[i].Cells["clmRetailRate"].Value = dsSearch.Tables[0].Rows[i]["retail_rate"];
            //        rdgvBarCode.Rows[i].Cells["clmMrpPro"].Value = dsSearch.Tables[0].Rows[i]["mrp_pro"];
            //        rdgvBarCode.Rows[i].Cells["clmMrp"].Value = dsSearch.Tables[0].Rows[i]["mrp"];
            //        rdgvBarCode.Rows[i].Cells["clmSpecialratePro"].Value = dsSearch.Tables[0].Rows[i]["special_rate_pro"];
            //        rdgvBarCode.Rows[i].Cells["clmSpRate"].Value = dsSearch.Tables[0].Rows[i]["special_rate"];
            //        rdgvBarCode.Rows[i].Cells["clmWhPro"].Value = dsSearch.Tables[0].Rows[i]["whoe_sale_pro"];
            //        rdgvBarCode.Rows[i].Cells["clmWholeSale"].Value = dsSearch.Tables[0].Rows[i]["whole_sale"];
            //        rdgvBarCode.Rows[i].Cells["clmBranchPro"].Value = dsSearch.Tables[0].Rows[i]["branch_rate_pro"];
            //        rdgvBarCode.Rows[i].Cells["clmBranchRate"].Value = dsSearch.Tables[0].Rows[i]["branch_rate"];
            //        rdgvBarCode.Rows[i].Cells["clmItemBarCode"].Value = dsSearch.Tables[0].Rows[i]["item_bar_code"];
            //        rdgvBarCode.Rows[i].Cells["clmEntryID"].Value = dsSearch.Tables[0].Rows[i]["entry_id"];
            //        rdgvBarCode.Rows[i].Cells["clmEntryNo"].Value = dsSearch.Tables[0].Rows[i]["entry_no"];
            //    }
            //}
            #endregion
        }
        #endregion Search BarCode Details
        private void rdgvBarCode_ValueChanged(object sender, EventArgs e)
        {
            if (this.rdgvBarCode.ActiveEditor is RadCheckBoxEditor)
            {
                if (rdgvBarCode.Rows.Count > 0)
                {
                    DataSet ds = new DataSet();
                    RadCheckBoxEditor chEditor = this.rdgvBarCode.ActiveEditor as RadCheckBoxEditor;
                    if (chEditor != null)
                    {
                        this.rdgvBarCode.EndEdit();
                        myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(rdgvBarCode.Rows[rdgvBarCode.CurrentRow.Index].Cells["clmBarcodeId"].Value);
                        ds = myBarCodeRegOpr.CheckBarCodeInSLWithoutTran(myBarCodeRegInfo);
                        Count = Convert.ToInt64(ds.Tables[0].Rows[0]["Count"]);
                        if (Count == 0)
                            rdgvBarCode.Rows[rdgvBarCode.CurrentRow.Index].Cells["clmSelect"].Value = true;
                        else
                            rdgvBarCode.Rows[rdgvBarCode.CurrentRow.Index].Cells["clmSelect"].Value = false;
                    }
                }
            }
        }
        #region DeleteBarCodeRegistry
        public bool DeleteBarCodeRegistry(SqlTransaction myTran)
        {
            bool LineFlag = false;
            foreach (GridViewRowInfo dr in rdgvBarCode.Rows)
            {
                if (Convert.ToBoolean(dr.Cells["clmSelect"].Value) == true)
                {
                    DataSet ds = new DataSet();
                    myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(dr.Cells["clmBarcodeId"].Value);
                    ds = myBarCodeRegOpr.CheckBarCodeInSL(myBarCodeRegInfo, myTran);
                    Count = Convert.ToInt64(ds.Tables[0].Rows[0]["Count"]);
                    if (Count == 0)
                    {
                        if (myBarCodeRegOpr.DeleteBarcodeItem(myBarCodeRegInfo, myTran))
                            if(myBarCodeRegOpr.DeleteUnitRateDetailsFromUpdate(myBarCodeRegInfo, myTran))
                                LineFlag = true;
                            else
                                LineFlag = true;
                        else
                        {
                            LineFlag = false;
                            break;
                        }
                    }
                }
            }
            return LineFlag;
        }
        #endregion DeleteBarCodeRegistry
        #region Clear
        public void Clear()
        {
            rdgvBarCode.Rows.Clear();
            rdgvUnitRate.Rows.Clear();
        }
        #endregion Clear
    }
}
