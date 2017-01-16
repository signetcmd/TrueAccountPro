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
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace TrueAccountPro
{
    public partial class frmPurchase : Telerik.WinControls.UI.RadForm
    {
        #region Objects
        productMasterInfo myProductMasterInfo = new productMasterInfo();
        productMasterOpr myProductMasterOpr = new productMasterOpr();

        mastersInfo myMasterInfo = new mastersInfo();
        mastersOpr myMasterOpr = new mastersOpr();

        ledgerNameInfo myLedgerNameInfo = new ledgerNameInfo();
        ledgerNameOpr myLedgerNameOpr = new ledgerNameOpr();

        cashLedgerInfo myCashLedgerInfo = new cashLedgerInfo();
        cashLedgerOpr myCashLedgerOpr = new cashLedgerOpr();

        purchaseInfo myPurchaseInfo = new purchaseInfo();
        purchaseOpr mypurchaseOpr = new purchaseOpr();

        adjustmentInfo myAdjustmentInfo = new adjustmentInfo();
        adjustmentOpr myAdjustmentOpr = new adjustmentOpr();

        barCodeRegistryInfo myBarCodeRegInfo = new barCodeRegistryInfo();
        barCodeRegistryOpr myBarCodeRegOpr = new barCodeRegistryOpr();

        genaralFunctions myGenaralFunctions = new genaralFunctions();

        xmlConfigInfo myXmlConfigInfo = new xmlConfigInfo();
        xmlConfigOpr myXmlConfigOpr = new xmlConfigOpr();

        stockInfo myStockInfo = new stockInfo();
        stockOpr myStockOpr = new stockOpr();
        #endregion Objects
        #region Declarations
        bool loadcmplt = false;

        int myPrdctDcmlPonts = 0;
        decimal myPrdctQty2 = 0;

        bool myPurchaseGridEdit = false;
        bool myAdjustmentGridEdit = false;
        bool isSplrBindCmplt;
        public static long Count;
        public static int RowIndex;
        DataSet myMasterDtls;
        DataSet myDetailsDtls;
        DataSet myAdjustmentDtls;

        DataSet myUnitsDs;
        string myFormId = "PV";

        long myUserId = 0;

        DataTable dataTable = new DataTable();

        DataTable myUnitDetailsDt;
        decimal myGrandTotal, myAdjustment, myRoundOff, myNetamount, myOldBalance, myClBalance, myAmountPaid = 0, myBalance;
        DataTable myItemUnitRateDtls;
        #endregion Declarations
        #region Constructors
        public frmPurchase()
        {
            InitializeComponent();
            ddlApplyColumn.SelectedIndex = 0;
            sedEntryNo.Maximum = decimal.MaxValue;
        }
        #endregion Constructors
        #region bindProductDetailsToGrid
        private void bindProductDetailsToGrid()
        {
            myProductMasterInfo.Query = "select product_Id,product_code,product_name,alternate_name from tblProductMaster";
            DataSet details = myProductMasterOpr.selectAllProductMasterDetails(myProductMasterInfo);

            BindingSource productBs = new BindingSource();

            productBs.DataSource = details.Tables[0];

            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmItemCode"]).ValueMember = "product_id";
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmItemCode"]).DisplayMember = "product_code";
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmItemCode"]).DataSource = productBs;

            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmItemName"]).ValueMember = "product_id";
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmItemName"]).DisplayMember = "product_name";
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmItemName"]).DataSource = productBs;
        }
        #endregion bindProductDetailsToGrid
        #region bindProductModeltoGrid
        private void bindProductModeltoGrid()
        {
            myMasterInfo.Query = "SELECT model_Id as id, model_name as name, model_description as description from tblModel";
            DataSet modelDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource modelBS = new BindingSource();
            modelBS.DataSource = modelDts.Tables[0];

            ((GridViewComboBoxColumn)dgvDetails.Columns["clmModel"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmModel"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmModel"]).DataSource = modelBS;

        }
        #endregion bindProductModeltoGrid
        #region bindProductCategorytoGrid
        private void bindProductCategorytoGrid()
        {
            myMasterInfo.Query = "SELECT product_category_id as id, product_category_name as name, product_category_description as description from tblProductCategory";

            DataSet modelDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];


            ((GridViewComboBoxColumn)dgvDetails.Columns["clmCategory"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmCategory"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmCategory"]).DataSource = brandBs;
        }
        #endregion bindProductCategorytoGrid
        #region bindProductBrandtoGrid
        private void bindProductBrandtoGrid()
        {
            myMasterInfo.Query = " SELECT brand_Id as id, brand_name as name, brand_description as description from tblBrand";

            DataSet modelDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];


            ((GridViewComboBoxColumn)dgvDetails.Columns["clmBrand"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmBrand"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmBrand"]).DataSource = brandBs;
        }
        #endregion bindProductBrandtoGrid
        #region bindProductColourtoGrid
        private void bindProductColourtoGrid()
        {
            myMasterInfo.Query = " SELECT colour_id as id, colour_name as name, colour_description as description from tblColour";

            DataSet modelDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];


            ((GridViewComboBoxColumn)dgvDetails.Columns["clmColour"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmColour"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmColour"]).DataSource = brandBs;
        }
        #endregion bindProductColourtoGrid
        #region bindProductSizetoGrid
        private void bindProductSizetoGrid()
        {
            myMasterInfo.Query = " SELECT size_id as id, size_name as name, size_description as description from tblSize";

            DataSet modelDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmSize"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmSize"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmSize"]).DataSource = brandBs;
        }
        #endregion bindProductSizetoGrid
        #region bindProductCompanytoGrid
        private void bindProductCompanytoGrid()
        {
            myMasterInfo.Query = "SELECT pro_companyId as id, pro_company_name as name, pro_company_description as description from tblProductCompany";
            DataSet companyDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource companyBS = new BindingSource();
            companyBS.DataSource = companyDts.Tables[0];

            ((GridViewComboBoxColumn)dgvDetails.Columns["clmCompany"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmCompany"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmCompany"]).DataSource = companyBS;
        }
        #endregion bindProductCompanytoGrid
        #region bindProductUnitsToGrid
        private void bindProductUnitsToGrid()
        {
            myMasterInfo.Query = "SELECT * from tblUnit";
            myUnitsDs = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            myUnitDetailsDt = myUnitsDs.Tables[0];

            ((GridViewComboBoxColumn)dgvDetails.Columns["clmUnit"]).ValueMember = "unit_id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmUnit"]).DisplayMember = "unit_name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmUnit"]).DataSource = myUnitDetailsDt;

            ((GridViewComboBoxColumn)dgvDetails.Columns["clmFreeQtyUnit"]).ValueMember = "unit_id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmFreeQtyUnit"]).DisplayMember = "unit_name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmFreeQtyUnit"]).DataSource = myUnitDetailsDt;
        }
        #endregion bindProductUnitsToGrid
        #region formTotalCalculations
        private void formTotalCalculations(bool isRoundOff)
        {
            //if (btnSave.Text != "&Edit")
            //{
            myGrandTotal = txtGrandTotal.Text != "" ? Convert.ToDecimal(txtGrandTotal.Text.ToString()) : 0;
            myAdjustment = txtAdjustment.Text != "" ? Convert.ToDecimal(txtAdjustment.Text.ToString()) : 0;
            if (isRoundOff)
            {
                // roundOff = txtRoundOff.Text != "" ? Convert.ToDecimal(txtRoundOff.Text.ToString()) : 0;
                myNetamount = Math.Round(myGrandTotal + myAdjustment);
                myRoundOff = myGrandTotal + myAdjustment - myNetamount;
            }
            else
            {
                myRoundOff = txtRoundOff.Text != "" ? Convert.ToDecimal(txtRoundOff.Text.ToString()) : 0;
                myNetamount = myGrandTotal + myAdjustment + myRoundOff;
            }
            myOldBalance = txtOldBalance.Text != "" ? Convert.ToDecimal(txtOldBalance.Text.ToString()) : 0;
            // myAmountPaid = txtAmountPaid.Text != "" ? Convert.ToDecimal(txtAmountPaid.Text.ToString()) : 0;
            myBalance = myNetamount - myAmountPaid;
            myClBalance = myBalance + myOldBalance;
            txtGrandTotal.Text = myGenaralFunctions.FormatDecimalPlace(myGrandTotal.ToString(), 2);
            //txtGrandTotal.Text = dgvDetails.Rows[0].Cells["clmGrandTotal"].Value != null ? dgvDetails.Rows[0].Cells["clmGrandTotal"].Value.ToString() : "0.00";
            txtAdjustment.Text = myGenaralFunctions.FormatDecimalPlace(myAdjustment.ToString(), 2);
            //  txtRoundOff.Text = myGenaralFunctions.FormatDecimalPlace(roundOff.ToString(), 2);
            txtRoundOff.Text = myRoundOff.ToString();
            txtNetAmount.Text = myGenaralFunctions.FormatDecimalPlace(myNetamount.ToString(), 2);
            txtClBalance.Text = myGenaralFunctions.FormatDecimalPlace(myClBalance.ToString(), 2);
            txtBalance.Text = myGenaralFunctions.FormatDecimalPlace(myBalance.ToString(), 2);
            if (myBalance > 0)
                dtpDueDate.Enabled = true;
            else
                dtpDueDate.Enabled = false;
            //}
        }
        #endregion 
        #region PinnedRowTotal
        private void findColumnTotal()
        {
            int count = dgvDetails.Rows.Count;
            dgvDetails.Rows[0].Cells["clmQty"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmFreeQty"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmQty2"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmTotalQty"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmStickerQty"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmDiscount"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmDisc2"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmExiceDuty"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmGstAmount"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmVatAmount"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmCessAmount"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmAddCost"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmTotaAmount"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmGrossValue"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmNetValue"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmGrandTotal"].Value = 0.00;
            for (int i = 1; i < count; i++)
            {
                if (dgvDetails.Rows[i].Cells["clmQty"].Value != null)
                    dgvDetails.Rows[0].Cells["clmQty"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmQty"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmQty"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmFreeQty"].Value != null)
                    dgvDetails.Rows[0].Cells["clmFreeQty"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmFreeQty"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmFreeQty"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmQty2"].Value != null)
                    dgvDetails.Rows[0].Cells["clmQty2"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmQty2"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmQty2"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmTotalQty"].Value != null)
                    dgvDetails.Rows[0].Cells["clmTotalQty"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmTotalQty"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmTotalQty"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmStickerQty"].Value != null)
                    dgvDetails.Rows[0].Cells["clmStickerQty"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmStickerQty"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmStickerQty"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmDiscount"].Value != null)
                    dgvDetails.Rows[0].Cells["clmDiscount"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmDiscount"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmDiscount"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmDisc2"].Value != null)
                    dgvDetails.Rows[0].Cells["clmDisc2"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmDisc2"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmDisc2"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmExiceDuty"].Value != null)
                    dgvDetails.Rows[0].Cells["clmExiceDuty"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmExiceDuty"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmExiceDuty"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmGstAmount"].Value != null)
                    dgvDetails.Rows[0].Cells["clmGstAmount"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmGstAmount"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmGstAmount"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmVatAmount"].Value != null)
                    dgvDetails.Rows[0].Cells["clmVatAmount"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmVatAmount"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmVatAmount"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmCessAmount"].Value != null)
                    dgvDetails.Rows[0].Cells["clmCessAmount"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmCessAmount"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmCessAmount"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmAddCost"].Value != null)
                    dgvDetails.Rows[0].Cells["clmAddCost"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmAddCost"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmAddCost"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmTotaAmount"].Value != null)
                    dgvDetails.Rows[0].Cells["clmTotaAmount"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmTotaAmount"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmTotaAmount"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmGrossValue"].Value != null)
                    dgvDetails.Rows[0].Cells["clmGrossValue"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmGrossValue"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmGrossValue"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmNetValue"].Value != null)
                    dgvDetails.Rows[0].Cells["clmNetValue"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmNetValue"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmNetValue"].Value.ToString());
                if (dgvDetails.Rows[i].Cells["clmGrandTotal"].Value != null)
                    dgvDetails.Rows[0].Cells["clmGrandTotal"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmGrandTotal"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmGrandTotal"].Value.ToString());
                //if(btnSave.Text!="&Edit")
                txtGrandTotal.Text = dgvDetails.Rows[0].Cells["clmGrandTotal"].Value.ToString();
            }
            formTotalCalculations(rcbRoundOff.Checked);
        }
        #endregion PinnedRowTotal
        #region calculations
        private void calculations(int rowindex)
        {
            decimal qty = 0, freeQty = 0, totalQty = 0, unitRate = 0, totalAmount = 0, discPec = 0, discount = 0, disc2 = 0, grossValue = 0, exiceDutyPer = 0, exiceDuty = 0, gstPerc = 0, gst = 0, netValue = 0, vatPerc = 0, vatAmount = 0, cessPerc = 0, cessAmount = 0;
            decimal grandTotal = 0, addCost = 0, costPerPs = 0, retailPro = 0, retailRate = 0, mrpPro = 0, mrp = 0, specialratePro = 0, spRate = 0, whPro = 0, wholeSale = 0, branchPro = 0, branchRate = 0;
            if (rowindex > -1)
            {
                if (dgvDetails.Rows[rowindex].Cells["clmQty"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmQty"].Value.ToString().Trim() !="")
                {
                    qty = Math.Round(Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmQty"].Value),2);
                    dgvDetails.Rows[rowindex].Cells["clmQty"].Value = myGenaralFunctions.FormatDecimalPlace(qty.ToString(), myPrdctDcmlPonts);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value.ToString().Trim() !="")
                {
                    freeQty = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value = myGenaralFunctions.FormatDecimalPlace(freeQty.ToString().Trim(), myPrdctDcmlPonts);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value.ToString().Trim()!="")
                {
                    unitRate = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value = myGenaralFunctions.FormatDecimalPlace(unitRate.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmTotaAmount"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmTotaAmount"].Value.ToString().Trim()!="")
                {
                    totalAmount = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmTotaAmount"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmTotaAmount"].Value = myGenaralFunctions.FormatDecimalPlace(totalAmount.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmDiscPerc"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmDiscPerc"].Value.ToString().Trim()!="")
                {
                    discPec = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmDiscPerc"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmDiscPerc"].Value = myGenaralFunctions.FormatDecimalPlace(discPec.ToString().Trim(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmDiscount"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmDiscount"].Value.ToString().Trim()!="")
                {
                    discount = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmDiscount"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmDiscount"].Value = myGenaralFunctions.FormatDecimalPlace(discount.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmDisc2"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmDisc2"].Value.ToString().Trim()!="")
                {
                    disc2 = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmDisc2"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmDisc2"].Value = myGenaralFunctions.FormatDecimalPlace(disc2.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmExiceDutyPerc"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmExiceDutyPerc"].Value.ToString().Trim()!="")
                {
                    exiceDutyPer = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmExiceDutyPerc"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmExiceDutyPerc"].Value = myGenaralFunctions.FormatDecimalPlace(exiceDutyPer.ToString().Trim(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmGstPerc"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmGstPerc"].Value.ToString().Trim()!="")
                {
                    gstPerc = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmGstPerc"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmGstPerc"].Value = myGenaralFunctions.FormatDecimalPlace(gstPerc.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmVatPerc"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmVatPerc"].Value.ToString().Trim()!="")
                {
                    vatPerc = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmVatPerc"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmVatPerc"].Value = myGenaralFunctions.FormatDecimalPlace(vatPerc.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmCessPerc"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmCessPerc"].Value.ToString().Trim()!="")
                {
                    cessPerc = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmCessPerc"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmCessPerc"].Value = myGenaralFunctions.FormatDecimalPlace(cessPerc.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmAddCost"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmAddCost"].Value.ToString().Trim()!="")
                {
                    addCost = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmAddCost"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmAddCost"].Value = myGenaralFunctions.FormatDecimalPlace(addCost.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmCost"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmCost"].Value.ToString().Trim()!="")
                {
                    costPerPs = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmCost"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmCost"].Value = myGenaralFunctions.FormatDecimalPlace(costPerPs.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmRetailPro"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmRetailPro"].Value.ToString().Trim()!="")
                {
                    retailPro = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmRetailPro"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmRetailPro"].Value = myGenaralFunctions.FormatDecimalPlace(retailPro.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmRetailRate"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmRetailRate"].Value.ToString().Trim()!="")
                {
                    retailRate = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmRetailRate"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmRetailRate"].Value = myGenaralFunctions.FormatDecimalPlace(retailRate.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmMrpPro"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmMrpPro"].Value.ToString().Trim()!="")
                {
                    mrpPro = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmMrpPro"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmMrpPro"].Value = myGenaralFunctions.FormatDecimalPlace(mrpPro.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmMrp"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmMrp"].Value.ToString().Trim()!="")
                {
                    mrp = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmMrp"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmMrp"].Value = myGenaralFunctions.FormatDecimalPlace(mrp.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmSpecialratePro"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmSpecialratePro"].Value.ToString().Trim()!="")
                {
                    specialratePro = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmSpecialratePro"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmSpecialratePro"].Value = myGenaralFunctions.FormatDecimalPlace(specialratePro.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmSpRate"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmSpRate"].Value.ToString().Trim()!="")
                {
                    spRate = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmSpRate"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmSpRate"].Value = myGenaralFunctions.FormatDecimalPlace(spRate.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmWhPro"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmWhPro"].Value.ToString().Trim()!="")
                {
                    whPro = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmWhPro"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmWhPro"].Value = myGenaralFunctions.FormatDecimalPlace(whPro.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmWholeSale"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmWholeSale"].Value.ToString().Trim()!="")
                {
                    wholeSale = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmWholeSale"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmWholeSale"].Value = myGenaralFunctions.FormatDecimalPlace(wholeSale.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmBranchPro"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmBranchPro"].Value.ToString().Trim()!="")
                {
                    branchPro = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmBranchPro"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmBranchPro"].Value = myGenaralFunctions.FormatDecimalPlace(branchPro.ToString(), 2);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmBranchRate"].Value != null&& dgvDetails.Rows[rowindex].Cells["clmBranchRate"].Value.ToString().Trim()!="")
                {
                    branchRate = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmBranchRate"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmBranchRate"].Value = myGenaralFunctions.FormatDecimalPlace(branchRate.ToString(), 2);
                }
                totalQty = qty + freeQty;
                if (totalAmount == 0)
                    totalAmount = unitRate * qty;
                //else if (qty > 0)
                //    unitRate = totalAmount / qty;
                if (discPec > 0)
                    discount = totalAmount * discPec / 100;
                else if (totalAmount > 0)
                    discPec = (discount * 100) / totalAmount;
                grossValue = totalAmount - discount - disc2;
                if (exiceDutyPer > 0)
                    exiceDuty = grossValue * exiceDutyPer / 100;
                netValue = grossValue + exiceDuty;
                if (gstPerc > 0)
                    gst = (netValue) * gstPerc / 100;
                if (vatPerc > 0)
                    vatAmount = netValue * vatPerc / 100;
                if (cessPerc > 0)
                    cessAmount = vatAmount * cessPerc / 100;
                grandTotal = netValue + vatAmount + cessAmount + gst;
                if (qty > 0)
                    costPerPs = ((addCost + grandTotal) / qty);
                retailRate = (costPerPs * retailPro / 100) + costPerPs;
                if (costPerPs > 0 && retailRate > 0)
                    retailPro = (retailRate - costPerPs) * 100 / costPerPs;
                mrp = (costPerPs * mrpPro / 100) + costPerPs;
                if (costPerPs > 0 && mrp > 0)
                    mrpPro = (mrp - costPerPs) * 100 / costPerPs;
                spRate = (costPerPs * specialratePro / 100) + costPerPs;
                if (costPerPs > 0 && spRate > 0)
                    specialratePro = (spRate - costPerPs) * 100 / costPerPs;
                wholeSale = (costPerPs * whPro / 100) + costPerPs;
                if (costPerPs > 0 && whPro > 0)
                    whPro = (wholeSale - costPerPs) * 100 / costPerPs;
                branchRate = (costPerPs * branchPro / 100) + costPerPs;
                if (costPerPs > 0 && branchRate > 0)
                    branchPro = (branchRate - costPerPs) * 100 / costPerPs;
                dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value = myGenaralFunctions.FormatDecimalPlace(unitRate.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmTotalQty"].Value = totalQty != 0 ? myGenaralFunctions.FormatDecimalPlace(totalQty.ToString().Trim(), myPrdctDcmlPonts) : null;
                dgvDetails.Rows[rowindex].Cells["clmStickerQty"].Value = totalQty != 0 ? myGenaralFunctions.FormatDecimalPlace(totalQty.ToString().Trim(), 0) : null;
                dgvDetails.Rows[rowindex].Cells["clmTotaAmount"].Value = myGenaralFunctions.FormatDecimalPlace(totalAmount.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmDiscount"].Value = discount != 0 ? myGenaralFunctions.FormatDecimalPlace(discount.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmDiscPerc"].Value = discPec != 0 ? myGenaralFunctions.FormatDecimalPlace(discPec.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmGrossValue"].Value = myGenaralFunctions.FormatDecimalPlace(grossValue.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmExiceDutyPerc"].Value = exiceDutyPer != 0 ? myGenaralFunctions.FormatDecimalPlace(exiceDutyPer.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmExiceDuty"].Value = exiceDuty != 0 ? myGenaralFunctions.FormatDecimalPlace(exiceDuty.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmGstPerc"].Value = gstPerc != 0 ? myGenaralFunctions.FormatDecimalPlace(gstPerc.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmGstAmount"].Value = gst != 0 ? myGenaralFunctions.FormatDecimalPlace(gst.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmNetValue"].Value = myGenaralFunctions.FormatDecimalPlace(netValue.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmVatPerc"].Value = vatPerc != 0 ? myGenaralFunctions.FormatDecimalPlace(vatPerc.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmVatAmount"].Value = vatAmount != 0 ? myGenaralFunctions.FormatDecimalPlace(vatAmount.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmCessPerc"].Value = cessPerc != 0 ? myGenaralFunctions.FormatDecimalPlace(cessPerc.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmCessAmount"].Value = cessAmount != 0 ? myGenaralFunctions.FormatDecimalPlace(cessAmount.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmGrandTotal"].Value = myGenaralFunctions.FormatDecimalPlace(grandTotal.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmAddCost"].Value = addCost != 0 ? myGenaralFunctions.FormatDecimalPlace(addCost.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmCost"].Value = myGenaralFunctions.FormatDecimalPlace(costPerPs.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmRetailPro"].Value = retailPro != 0 ? myGenaralFunctions.FormatDecimalPlace(retailPro.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmRetailRate"].Value = myGenaralFunctions.FormatDecimalPlace(retailRate.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmMrpPro"].Value = mrpPro != 0 ? myGenaralFunctions.FormatDecimalPlace(mrpPro.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmMrp"].Value = myGenaralFunctions.FormatDecimalPlace(mrp.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmSpecialratePro"].Value = specialratePro != 0 ? myGenaralFunctions.FormatDecimalPlace(specialratePro.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmSpRate"].Value = myGenaralFunctions.FormatDecimalPlace(spRate.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmWhPro"].Value = whPro != 0 ? myGenaralFunctions.FormatDecimalPlace(whPro.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmWholeSale"].Value = myGenaralFunctions.FormatDecimalPlace(wholeSale.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmBranchPro"].Value = branchPro != 0 ? myGenaralFunctions.FormatDecimalPlace(branchPro.ToString().Trim(), 2) : null;
                dgvDetails.Rows[rowindex].Cells["clmBranchRate"].Value = myGenaralFunctions.FormatDecimalPlace(branchRate.ToString().Trim(), 2);
            }
        }
        #endregion calculations
        #region bindPrdctDtlsToRowByItem
        private void bindPrdctDtlsToRowByItem(int rowIndex)
        {
            DataSet productDetails = myProductMasterOpr.selectAllProductMasterData(myProductMasterInfo);
            if (productDetails.Tables[0].Rows.Count > 0)
            {
                dgvDetails.Rows[rowIndex].Cells["clmCompany"].Value = productDetails.Tables[0].Rows[0]["pro_company_id"].ToString() != "" ? Convert.ToInt64(productDetails.Tables[0].Rows[0]["pro_company_id"].ToString()) : -1;
                dgvDetails.Rows[rowIndex].Cells["clmCategory"].Value = productDetails.Tables[0].Rows[0]["pro_category_id"].ToString() != "" ? Convert.ToInt64(productDetails.Tables[0].Rows[0]["pro_category_id"].ToString()) : -1;
                dgvDetails.Rows[rowIndex].Cells["clmModel"].Value = productDetails.Tables[0].Rows[0]["model_id"].ToString() != "" ? Convert.ToInt64(productDetails.Tables[0].Rows[0]["model_id"].ToString()) : -1;
                dgvDetails.Rows[rowIndex].Cells["clmBrand"].Value = productDetails.Tables[0].Rows[0]["brand_id"].ToString() != "" ? Convert.ToInt64(productDetails.Tables[0].Rows[0]["brand_id"].ToString()) : -1;
                dgvDetails.Rows[rowIndex].Cells["clmColour"].Value = -1;
                dgvDetails.Rows[rowIndex].Cells["clmSize"].Value = -1;
                dgvDetails.Rows[rowIndex].Cells["clmUnitRate"].Value = productDetails.Tables[0].Rows[0]["purchase_rate"].ToString() != "" ? productDetails.Tables[0].Rows[0]["purchase_rate"].ToString() : "0";
                dgvDetails.Rows[rowIndex].Cells["clmVatPerc"].Value = productDetails.Tables[0].Rows[0]["rate_of_tax_purchase"].ToString() != "" ? productDetails.Tables[0].Rows[0]["rate_of_tax_purchase"].ToString() : "0";
                dgvDetails.Rows[rowIndex].Cells["clmCessPerc"].Value = productDetails.Tables[0].Rows[0]["rate_of_cess"].ToString() != "" ? productDetails.Tables[0].Rows[0]["rate_of_cess"].ToString() : "0";
                dgvDetails.Rows[rowIndex].Cells["clmExiceDutyPerc"].Value = productDetails.Tables[0].Rows[0]["exice_duty"].ToString() != "" ? productDetails.Tables[0].Rows[0]["exice_duty"].ToString() : "0";
                dgvDetails.Rows[rowIndex].Cells["clmGstPerc"].Value = productDetails.Tables[0].Rows[0]["gst"].ToString() != "" ? productDetails.Tables[0].Rows[0]["gst"].ToString() : "0";
                //     bindUnitsToGrid(Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value));
                myPrdctDcmlPonts = productDetails.Tables[0].Rows[0]["unit_decimal"].ToString() != "" ? Convert.ToInt32(productDetails.Tables[0].Rows[0]["unit_decimal"].ToString()) : 3;
                myPrdctQty2 = productDetails.Tables[0].Rows[0]["qty2"].ToString() == "0" || productDetails.Tables[0].Rows[0]["qty2"].ToString() == "" ? 0 : Convert.ToDecimal(productDetails.Tables[0].Rows[0]["qty2"].ToString());
                calculations(rowIndex);
                findColumnTotal();
            }
        }
        #endregion bindPrdctDtlsToRowByItem
        #region bindPrdctDtlsToRowByBarCode
        private void bindPrdctDtlsToRowByBarCode(int rowIndex)
        {
            DataSet productDetails = myBarCodeRegOpr.selectitemDetailsByBarCode(myBarCodeRegInfo);
            int datasetIndex = productDetails.Tables[0].Rows.Count - 1;
            if (productDetails.Tables[0].Rows.Count > 0)
            {
                dgvDetails.Rows[rowIndex].Cells["clmBarCodeId"].Value = productDetails.Tables[0].Rows[datasetIndex]["bar_code_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmEntryNo"].Value = productDetails.Tables[0].Rows[datasetIndex]["entry_no"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value = productDetails.Tables[0].Rows[datasetIndex]["item_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value = productDetails.Tables[0].Rows[datasetIndex]["item_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmCompany"].Value = productDetails.Tables[0].Rows[datasetIndex]["company_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmCategory"].Value = productDetails.Tables[0].Rows[datasetIndex]["category_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmModel"].Value = productDetails.Tables[0].Rows[datasetIndex]["model_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmBrand"].Value = productDetails.Tables[0].Rows[datasetIndex]["brand_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmColour"].Value = productDetails.Tables[0].Rows[datasetIndex]["colour_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmSize"].Value = productDetails.Tables[0].Rows[datasetIndex]["size_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmBatch"].Value = productDetails.Tables[0].Rows[datasetIndex]["batch"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmExpDate"].Value = productDetails.Tables[0].Rows[datasetIndex]["exp_date"].ToString().Trim()!=""?productDetails.Tables[0].Rows[datasetIndex]["exp_date"].ToString():null;
                // dgvDetails.Rows[rowIndex].Cells["clmunitRate"].Value = productDetails.Tables[0].Rows[datasetIndex]["unit_rate"].ToString();
                // dgvDetails.Rows[rowIndex].Cells["clmDiscPerc"].Value = productDetails.Tables[0].Rows[datasetIndex]["disc_perc"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmDisc2"].Value = productDetails.Tables[0].Rows[datasetIndex]["disc2"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmExiceDutyPerc"].Value = productDetails.Tables[0].Rows[datasetIndex]["exice_duty_perc"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmGstPerc"].Value = productDetails.Tables[0].Rows[datasetIndex]["gst_perc"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmVatPerc"].Value = productDetails.Tables[0].Rows[datasetIndex]["vat_perc"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmCessPerc"].Value = productDetails.Tables[0].Rows[datasetIndex]["cess_perc"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmAddCost"].Value = productDetails.Tables[0].Rows[datasetIndex]["add_cost"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmCost"].Value = productDetails.Tables[0].Rows[datasetIndex]["cost"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmRetailPro"].Value = productDetails.Tables[0].Rows[datasetIndex]["reatil_rate_pro"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmRetailRate"].Value = productDetails.Tables[0].Rows[datasetIndex]["retail_rate"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmMrpPro"].Value = productDetails.Tables[0].Rows[datasetIndex]["mrp_pro"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmMrp"].Value = productDetails.Tables[0].Rows[datasetIndex]["mrp"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmSpecialratePro"].Value = productDetails.Tables[0].Rows[datasetIndex]["special_rate_pro"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmSpRate"].Value = productDetails.Tables[0].Rows[datasetIndex]["special_rate"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmWhPro"].Value = productDetails.Tables[0].Rows[datasetIndex]["whoe_sale_pro"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmWholeSale"].Value = productDetails.Tables[0].Rows[datasetIndex]["whole_sale"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmBranchPro"].Value = productDetails.Tables[0].Rows[datasetIndex]["branch_rate_pro"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmBranchRate"].Value = productDetails.Tables[0].Rows[datasetIndex]["branch_rate"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmItemBarcode"].Value = productDetails.Tables[0].Rows[datasetIndex]["item_bar_code"].ToString();
                //// myPrdctDcmlPonts = productDetails.Tables[0].Rows[0]["unit_decimal"].ToString() != "" ? Convert.ToInt32(productDetails.Tables[0].Rows[0]["unit_decimal"].ToString()) : 3;
                // myPrdctQty2 = productDetails.Tables[0].Rows[0]["qty2"].ToString() == "0" || productDetails.Tables[0].Rows[0]["qty2"].ToString() == "" ? 0 : Convert.ToInt32(productDetails.Tables[0].Rows[0]["qty2"].ToString());
                // calculations(rowIndex);
                // findColumnTotal();
            }
        }
        #endregion bindPrdctDtlsToRowByBarCode
        DataSet ds = new DataSet();
        #region ProcessCmdKey
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (myPurchaseGridEdit)
            {
                decimal Cost = 0;
                Int32 rowIndex = dgvDetails.CurrentCell.RowIndex;
                long ItemCode = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value);
                long UnitID = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmUnit"].Value);
                if (dgvDetails.Rows[rowIndex].Cells["clmFactor"].Value != null && dgvDetails.Rows[rowIndex].Cells["clmFactor"].Value.ToString().Trim() != "")
                    Cost = Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value) / Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmFactor"].Value);
                if (msg.WParam.ToInt32() == (int)Keys.F6)
                {
                    frmPurchaseAltUnit myFrmPurchasseAlt = new frmPurchaseAltUnit(ItemCode, UnitID, Cost);
                    myFrmPurchasseAlt.MdiParent = this.MdiParent;
                    myFrmPurchasseAlt.ShowDialog();
                    myItemUnitRateDtls = myFrmPurchasseAlt.returnUnitDetails;
                    if (myItemUnitRateDtls != null)
                    {
                        foreach (DataRow dr in myItemUnitRateDtls.Rows)
                        {
                            GridViewDataRowInfo dataRowInfo = new GridViewDataRowInfo(this.dgvUnitRateDetails.MasterView);
                            dgvUnitRateDetails.Rows.Insert(dgvUnitRateDetails.Rows.Count, dataRowInfo);
                            int i = dgvUnitRateDetails.Rows.Count - 1;
                            dgvUnitRateDetails.Rows[i].Cells["clmRowId"].Value = rowIndex;
                            dgvUnitRateDetails.Rows[i].Cells["clmUnitId"].Value = dr["unitId"].ToString();
                            dgvUnitRateDetails.Rows[i].Cells["clmCost"].Value = dr["cost"].ToString();
                            dgvUnitRateDetails.Rows[i].Cells["clmRetailPro"].Value = dr["retailRatePro"].ToString();
                            dgvUnitRateDetails.Rows[i].Cells["clmRetailRate"].Value = dr["retailRate"].ToString();
                            dgvUnitRateDetails.Rows[i].Cells["clmMrpPro"].Value = dr["mrp"].ToString();
                            dgvUnitRateDetails.Rows[i].Cells["clmMrp"].Value = dr["mrpRate"].ToString();
                            dgvUnitRateDetails.Rows[i].Cells["clmSpecialratePro"].Value = dr["spRatePro"].ToString();
                            dgvUnitRateDetails.Rows[i].Cells["clmSpRate"].Value = dr["spRate"].ToString();
                            dgvUnitRateDetails.Rows[i].Cells["clmWhPro"].Value = dr["whosleSalePro"].ToString();
                            dgvUnitRateDetails.Rows[i].Cells["clmWholeSale"].Value = dr["wholeSaleRate"].ToString();
                            dgvUnitRateDetails.Rows[i].Cells["clmBranchPro"].Value = dr["branchRatePro"].ToString();
                            dgvUnitRateDetails.Rows[i].Cells["clmBranchRate"].Value = dr["branchRate"].ToString();
                        }
                    }
                }
                else if (msg.WParam.ToInt32() == (int)Keys.F2)
                {
                    if (dgvDetails.Rows[rowIndex].Cells["clmBarcodeId"].Value != null && dgvDetails.Rows[rowIndex].Cells["clmBarcodeId"].Value.ToString().Trim() != "")
                    {
                        if (Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmEntryNo"].Value) != Convert.ToInt64(sedEntryNo.Value))
                        {
                            ds = SelectBarCodeUnitDetails(rowIndex);
                            frmUpdateBarCode fr = new frmUpdateBarCode(ds, ItemCode, UnitID, Cost);
                            fr.MdiParent = this.MdiParent;
                            fr.Show();
                        }
                    }
                }
                else if (msg.WParam.ToInt32() == (int)Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                    return true;
                }
            }
            else if (myAdjustmentGridEdit)
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
        #region Load
        private void frmPurchase_Load(object sender, EventArgs e)
        {
            try
            {
                rcbRoundOff.Checked = Convert.ToBoolean(myXmlConfigOpr.getXmlSettings("settings", "iSPurchAutoRoundOff"));
                bindProductDetailsToGrid();
                bindGodownDetailsToGrid();
                bindProductCompanytoGrid();
                bindProductModeltoGrid();
                bindProductBrandtoGrid();
                bindProductCategorytoGrid();
                bindProductColourtoGrid();
                bindProductSizetoGrid();
                //bindProductUnitsToGrid();
                bindLedgerNameDetailsToDDL();
                bindAccountDetailsToGrid();
                bindMinusAndAddToAdjustGrid();
                //BindingParticulars();
                btnNew_Click(sender, e);
                loadcmplt = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion Load
        #region bindLedgerNameDetailsToDDL
        private void bindLedgerNameDetailsToDDL()
        {
            myLedgerNameInfo.GroupIdInt = 39;
            DataSet mySupplierDetailsDts = myLedgerNameOpr.selectCashAccAndLedgerByGroupId(myLedgerNameInfo);
            mccAccount.DataSource = mySupplierDetailsDts.Tables[0];
            mccAccount.DisplayMember = "ledger_name";
            mccAccount.ValueMember = "ledger_id";
            mccAccount.Columns["ledger_id"].IsVisible = false;
            mccAccount.Columns["ledger_name"].HeaderText = "Name";
            mccAccount.Columns["ledger_code"].HeaderText = "Code";
            mccAccount.Columns["alternate_name"].HeaderText = "Alternate Name";
            FilterDescriptor descriptor = new FilterDescriptor(mccAccount.DisplayMember, FilterOperator.Contains, string.Empty);
            mccAccount.MultiColumnComboBoxElement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            FilterDescriptor filtercustomername = new FilterDescriptor("ledger_code", FilterOperator.Contains, string.Empty);
            CompositeFilterDescriptor compositeFilter = new CompositeFilterDescriptor();
            compositeFilter.FilterDescriptors.Add(descriptor);
            compositeFilter.FilterDescriptors.Add(filtercustomername);
            compositeFilter.LogicalOperator = FilterLogicalOperator.Or;
            this.mccAccount.EditorControl.FilterDescriptors.Add(compositeFilter);
            isSplrBindCmplt = true;
        }
        #endregion bindLedgerNameDetailsToDDL
        #region bindMinusAndAddToAdjustGrid
        private void bindMinusAndAddToAdjustGrid()
        {
            DataTable data = new DataTable();
            data.Columns.Add("id", typeof(int));
            data.Columns.Add("name", typeof(string));
            data.Rows.Add(1, "Add");
            data.Rows.Add(2, "Minus");
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            ((GridViewComboBoxColumn)dgvAdjustment.Columns["clmAddOrMinus"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvAdjustment.Columns["clmAddOrMinus"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvAdjustment.Columns["clmAddOrMinus"]).DataSource = bs;
        }
        #endregion bindMinusAndAddToAdjustGrid
        #region bindGodownDetailsToGrid
        private void bindGodownDetailsToGrid()
        {
            myMasterInfo.Query = "select godown_id,godown_code,godown_name from tblGodown where active=1";

            DataSet modelDts = myMasterOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmGodown"]).ValueMember = "godown_id";
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmGodown"]).DisplayMember = "godown_name";
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmGodown"]).DataSource = brandBs;
        }
        #endregion bindGodownDetailsToGrid
        #region bindAccountDetailsToGrid
        private void bindAccountDetailsToGrid()
        {
            // myMasterInfo.Query = "select godown_id,godown_code,godown_name from tblGodown where active=1";

            DataSet accountDts = myLedgerNameOpr.selectAllLedgerNameDetails();
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = accountDts.Tables[0];
            ((GridViewMultiComboBoxColumn)dgvAdjustment.Columns["clmAccount"]).ValueMember = "ledger_id";
            ((GridViewMultiComboBoxColumn)dgvAdjustment.Columns["clmAccount"]).DisplayMember = "ledger_name";
            ((GridViewMultiComboBoxColumn)dgvAdjustment.Columns["clmAccount"]).DataSource = brandBs;
        }
        #endregion bindAccountDetailsToGrid
        private void dgvAdjustment_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridRowHeaderCellElement && e.RowIndex > -1)
                e.CellElement.Text = (Convert.ToInt32(e.CellElement.RowIndex) + 1).ToString();
        }
        //public void NumericColumn_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var enteredText = ((RadTextBoxEditorElement)sender).Text;
        //        if (dgvDetails.Rows[RowIndex].Cells["clmQty"].Value != null && enteredText.ToString().Trim() != "")
        //        {
        //            dgvDetails.Rows[RowIndex].Cells["clmQty"].Value = Convert.ToDecimal(enteredText);
        //            calculations(RowIndex);
        //            findColumnTotal();
        //        }
        //    }
        //    catch { }
        //}
        #region dgvDetails_CellEditorInitialized
        private void dgvDetails_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            if (dgvDetails.Focused)
            {
                if (e.Column == dgvDetails.Columns["ClmQty"])
                {
                    RowIndex = e.RowIndex;
                    RadTextBoxEditor tbEditor = this.dgvDetails.ActiveEditor as RadTextBoxEditor;
                    if (tbEditor != null)
                    {
                        //RadTextBoxEditorElement tbElement = (RadTextBoxEditorElement)tbEditor.EditorElement;
                        //tbElement.TextChanged += new EventHandler(NumericColumn_TextChanged);
                    }
                }
                if (dgvDetails.CurrentRow.Cells["clmItemCode"].Value != null && dgvDetails.CurrentRow.Cells["clmItemCode"].Value.ToString().Trim() != "")
                {
                    #region commented
                    //  DataSet det = myProductMasterOpr.SelectUnitsByProduct(Convert.ToInt32(dgvDetails.CurrentRow.Cells["clmItemCode"].Value));
                    //GridViewRowInfo Row = dgvDetails.CurrentRow;
                    //foreach (Telerik.WinControls.UI.GridViewRowInfo row in dgvDetails.Rows)
                    //{
                    //    //foreach (Telerik.WinControls.UI.GridViewCellInfo cell in row.Cells)
                    //    //{
                    //        //DataSet det = myProductMasterOpr.SelectUnitsByProduct(Convert.ToInt32(row.Cells["clmItemCode"].Value));
                    //    // GridViewComboBoxColumn clmUnit = ((GridViewComboBoxColumn)dgvDetails.Columns["clmUnit"]);
                    //    //row.Cells["clmUnit"].Value = "unit_id";
                    //    //clmUnit.ValueMember = "unit_id";
                    //    //row.Cells["clmUnit"] = "unit_name";
                    //    //row.Cells["clmUnit"].DataSource = det;
                    //    //}
                    //}

                    //DataSet det = myProductMasterOpr.SelectUnitsByProduct(Convert.ToInt32(dgvDetails.CurrentRow.Cells["clmItemCode"].Value));
                    //GridViewComboBoxCell clmUnit = dgvDetails.Rows[0].Cells["clmUnit"] as GridViewComboBoxCell;
                    //clmUnit.ValueMember = "unit_id";
                    //clmUnit.DisplayMember = "unit_name";
                    //clmUnit.DataSource = det;
                    //var editManager = sender as GridViewEditManager;
                    //var editor = editManager.ActiveEditor as RadDropDownListEditor;

                    //if (editor == null) return;

                    //var editorElement = ((RadDropDownListEditor)editor).EditorElement;
                    //switch (e.ColumnIndex)
                    //{
                    //    case 0:
                    //        //var tcArray = _db.TCs.Where(t => t.TC_GROUP_MEMBERs.Any(tcg => tcg.TC_GROUP.LAND_IDX == Startup.CurrentConsultant.CountryId)).ToList();
                    //        //tcArray.Insert(0, null);

                    //        ((RadDropDownListEditorElement)editorElement).DataSource = det;
                    //        ((RadDropDownListEditorElement)editorElement).DisplayMember = "unit_id";
                    //        ((RadDropDownListEditorElement)editorElement).ValueMember = "unit_name"; ;


                    //        //if (this.dgvDetails.CurrentRow.Cells[0].Value == null)
                    //        //    ((RadDropDownListEditorElement)editorElement).SelectedIndex = 0;
                    //        //else
                    //        //    ((RadDropDownListEditorElement)editorElement).SelectedIndex = det.IndexOf(_db.TCs.SingleOrDefault(t => t != null && t.TC1 == this.TextCodeGridView.CurrentRow.Cells[0].Value));
                    //        break;
                    //    case 1:
                    //        //var tclistArray = _db.TC_LISTs.Where(t => t != null && t.TC == this.TextCodeGridView.CurrentRow.Cells[0].Value).ToList();
                    //        //tclistArray.Insert(0, null);

                    //        ((RadDropDownListEditorElement)editorElement).DataSource = det;
                    //        ((RadDropDownListEditorElement)editorElement).DisplayMember = "unit_id";
                    //        ((RadDropDownListEditorElement)editorElement).ValueMember = "unit_name"; ;

                    //        //((RadDropDownListEditorElement)editorElement).SelectedIndex = det.IndexOf(tclistArray.SingleOrDefault(t => t != null && t.ISDEFAULT));
                    //        //this.dgvDetails.CurrentRow.Cells[1].Value = tclistArray.SingleOrDefault(t => t != null && t.ISDEFAULT).TEXT;

                    //        break;
                    //}
                    //Row.Columns["clmUnit"].va
                    //((GridViewComboBoxColumn)dgvDetails.Rows[e.RowIndex].Cells["clmUnit"]).ValueMember = "unit_id";
                    //((GridViewComboBoxColumn)dgvDetails.Columns["clmUnit"]).DisplayMember = "unit_name";
                    //((GridViewComboBoxColumn)dgvDetails.Columns["clmUnit"]).DataSource = det;

                    //RadDropDownListEditor editor = e.ActiveEditor as RadDropDownListEditor;
                    //    RadDropDownListEditorElement element = editor.EditorElement as RadDropDownListEditorElement;
                    //    element.DataSource = det;
                    //element.ValueMember = "unit_id";
                    //element.DisplayMember = "unit_name";

                    //GridViewRowInfo row = dgvDetails.CurrentRow;
                    //GridDataCellElement cell = row.Cells["ClmUnit"];
                    //DataGridViewComboBoxColumn cboContacts = (DataGridViewComboBoxColumn)
                    //                                                 (row.Cells["ClmUnit"]);
                    //((GridViewComboBoxColumn)dgvDetails.Columns["ClmUnit"]).DataSource = det;
                    ////((GridViewComboBoxColumn)dgvDetails.Columns["ClmUnit"]).
                    //((GridViewComboBoxColumn)dgvDetails.Columns["ClmUnit"]).ValueMember = "unit_id";
                    //((GridViewComboBoxColumn)dgvDetails.Columns["ClmUnit"]).DataSource = det;
                    //ClmUnit.DataSource = det;
                    //ClmUnit.ValueMember = "unit_id";
                    //ClmUnit.DisplayMember = "unit_name";

                    //foreach (DataGridViewRow row in dgvDetails.Rows)
                    //{
                    //    DataGridViewComboBoxCell cboContacts = (DataGridViewComboBoxCell)
                    //                                                 (row.Cells["Contacts"]);
                    //    cboContacts.DataSource = //Get the contact details of a person,
                    //                             //using his Name or Id field (row.Cells["Name"]);
                    //    cboContacts.DisplayMember = "Name"; //Name column of contact datasource
                    //    cboContacts.ValueMember = "Id";//Value column of contact datasource
                    //}
                    //var editManager = sender as GridViewEditManager;
                    //var editor = editManager.ActiveEditor as RadDropDownListEditor;

                    //if (editor == null) return;

                    //RadDropDownListEditorElement editorElement = (RadDropDownListEditorElement)((RadDropDownListEditor)editor).EditorElement;

                    //editorElement.DropDownStyle = RadDropDownStyle.DropDown;
                    //editorElement.DataSource = det;
                    //editorElement.DisplayMember = "Name";
                    //editorElement.ValueMember = "Name";
                    #endregion commented
                }
                if (e.Column == dgvDetails.Columns["clmUnit"])
                {
                    //bindUnitsToGrid(Convert.ToInt64(dgvDetails.Rows[e.RowIndex].Cells["clmItemCode"].Value));
                }
                else if (e.Column == dgvDetails.Columns["clmCompany"] || e.Column == dgvDetails.Columns["clmCategory"] || e.Column == dgvDetails.Columns["clmModel"] || e.Column == dgvDetails.Columns["clmBrand"] || e.Column == dgvDetails.Columns["clmSize"] || e.Column == dgvDetails.Columns["clmColour"] || e.Column == dgvDetails.Columns["clmUnit"])
                {
                    RadDropDownListEditor editor = e.ActiveEditor as RadDropDownListEditor;
                    if (editor != null)
                    {
                        RadDropDownListEditorElement el = editor.EditorElement as RadDropDownListEditorElement;
                        el.AutoCompleteMode = AutoCompleteMode.Suggest;
                        el.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
                        // ((RadDropDownListEditorElement)((RadDropDownListEditor)this.dgvDetails.ActiveEditor).EditorElement).RightToLeft = true;
                    }
                }
                //}
                //else if (this.dgvDetails.CurrentColumn is GridViewMultiComboBoxColumn)
                //{
                else if (e.Column == dgvDetails.Columns["clmItemCode"])
                {
                    RadMultiColumnComboBoxElement editColumn1 = (RadMultiColumnComboBoxElement)e.ActiveEditor;
                    editColumn1.EditorControl.Columns["product_name"].Width = 200;
                    editColumn1.EditorControl.Columns["product_name"].HeaderText = "Product Name";
                    editColumn1.EditorControl.Columns["product_code"].MinWidth = 100;
                    editColumn1.EditorControl.Columns["alternate_name"].MinWidth = 200;
                    editColumn1.EditorControl.Columns["product_code"].HeaderText = "Item Code";
                    editColumn1.EditorControl.Columns["alternate_name"].HeaderText = "Alternate Name";
                    editColumn1.EditorControl.Columns["product_id"].IsVisible = false;
                    editColumn1.EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                    editColumn1.EditorControl.ShowRowHeaderColumn = false;
                    editColumn1.DropDownMinSize = new Size(500, 100);
                    editColumn1.DropDownSizingMode = SizingMode.None;
                    editColumn1.DropDownStyle = RadDropDownStyle.DropDown;
                    //  editColumn1.EditorControl.MasterTemplate.AutoGenerateColumns = false;
                    editColumn1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                    editColumn1.AutoSizeDropDownToBestFit = false;
                    editColumn1.DropDownAnimationEnabled = false;
                    //    editColumn1.EditorControl.Columns.Add(new GridViewTextBoxColumn("product_code"));
                    FilterDescriptor filtercustomername = new FilterDescriptor("product_code", FilterOperator.Contains, string.Empty);
                    editColumn1.EditorControl.FilterDescriptors.Add(filtercustomername);
                }
                else if (e.Column == dgvDetails.Columns["clmItemName"])
                {
                    RadMultiColumnComboBoxElement editColumn = (RadMultiColumnComboBoxElement)e.ActiveEditor;
                    editColumn.EditorControl.Columns["product_name"].MinWidth = 190;
                    editColumn.EditorControl.Columns["product_name"].HeaderText = "Item Name";
                    editColumn.EditorControl.Columns["product_code"].MinWidth = 100;
                    editColumn.EditorControl.Columns["alternate_name"].MinWidth = 190;
                    editColumn.EditorControl.Columns["product_code"].HeaderText = "Item Code";
                    editColumn.EditorControl.Columns["alternate_name"].HeaderText = "Alternate Name";
                    editColumn.EditorControl.Columns["product_id"].IsVisible = false;
                    editColumn.EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                    editColumn.EditorControl.ShowRowHeaderColumn = false;
                    editColumn.DropDownMinSize = new Size(500, 100);
                    editColumn.DropDownSizingMode = SizingMode.None;
                    editColumn.DropDownStyle = RadDropDownStyle.DropDown;
                    //  editColumn.EditorControl.MasterTemplate.AutoGenerateColumns = false;
                    editColumn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                    editColumn.AutoSizeDropDownToBestFit = false;
                    editColumn.DropDownAnimationEnabled = false;
                    //    editColumn1.EditorControl.Columns.Add(new GridViewTextBoxColumn("product_code"));
                    FilterDescriptor filtercustomername = new FilterDescriptor("product_name", FilterOperator.Contains, string.Empty);
                    editColumn.EditorControl.FilterDescriptors.Add(filtercustomername);
                }
                else if (e.Column == dgvDetails.Columns["clmGodown"])
                {
                    RadMultiColumnComboBoxElement editColumn2 = (RadMultiColumnComboBoxElement)e.ActiveEditor;
                    editColumn2.EditorControl.Columns["godown_id"].MinWidth = 200;
                    editColumn2.EditorControl.Columns["godown_name"].HeaderText = "Godown Name";
                    editColumn2.EditorControl.Columns["godown_code"].MinWidth = 80;
                    editColumn2.EditorControl.Columns["godown_code"].HeaderText = "Godown Code";
                    editColumn2.EditorControl.Columns["godown_id"].IsVisible = false;
                    editColumn2.EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                    editColumn2.EditorControl.ShowRowHeaderColumn = false;
                    editColumn2.DropDownMinSize = new Size(300, 200);
                    editColumn2.DropDownSizingMode = SizingMode.None;
                    editColumn2.DropDownStyle = RadDropDownStyle.DropDown;
                    // editColumn2.EditorControl.MasterTemplate.AutoGenerateColumns = false;
                    editColumn2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                    editColumn2.AutoSizeDropDownToBestFit = false;
                    editColumn2.DropDownAnimationEnabled = false;
                    // editColumn2.EditorControl.Columns.Add(new GridViewTextBoxColumn("product_code"));
                    FilterDescriptor filtercustomername = new FilterDescriptor("godown_name", FilterOperator.Contains, string.Empty);
                    editColumn2.EditorControl.FilterDescriptors.Add(filtercustomername);
                    //}
                }
            }
        }
        #endregion dgvDetails_CellEditorInitialized
        #region dgvDetails_CellBeginEdit
        private void dgvDetails_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (dgvDetails.Focused)
            {
                if (e.Column == dgvDetails.Columns["clmUnit"])
                {
                    string condition = "";
                    myProductMasterInfo.ProductId = Convert.ToInt64(dgvDetails.Rows[e.RowIndex].Cells["clmItemCode"].Value);
                    DataSet det = myProductMasterOpr.selectProductUnitDetails(myProductMasterInfo);

                    if (det.Tables[0].Rows.Count > 0)
                    {
                        myUnitDetailsDt = det.Tables[0];
                        for (int i = 0; i < det.Tables[0].Rows.Count; i++)
                        {
                            if (i > 0)
                            {
                                condition = condition + ", ";
                            }
                            condition = condition + det.Tables[0].Rows[i]["unit_id"].ToString();
                        }
                        myUnitDetailsDt.DefaultView.RowFilter = "unit_Id IN (" + condition + ")";

                        myUnitDetailsDt = myUnitDetailsDt.DefaultView.ToTable();

                        ((GridViewComboBoxColumn)dgvDetails.Columns["clmUnit"]).ValueMember = "unit_id";
                        ((GridViewComboBoxColumn)dgvDetails.Columns["clmUnit"]).DisplayMember = "unit_name";
                        ((GridViewComboBoxColumn)dgvDetails.Columns["clmUnit"]).DataSource = myUnitDetailsDt;

                        ((GridViewComboBoxColumn)dgvDetails.Columns["clmFreeQtyUnit"]).ValueMember = "unit_id";
                        ((GridViewComboBoxColumn)dgvDetails.Columns["clmFreeQtyUnit"]).DisplayMember = "unit_name";
                        ((GridViewComboBoxColumn)dgvDetails.Columns["clmFreeQtyUnit"]).DataSource = myUnitDetailsDt;
                    }
                }
                dgvDetails.Tag = dgvDetails.CurrentCell.Value;
            }
        }
        #endregion dgvDetails_CellBeginEdit
        //#region checkCellValueChanged
        //private void checkCellValueChanged(int rowIndex)
        //{
        //    if (rowIndex > -1)
        //    {
        //        if (dgvDetails.Rows[rowIndex].Cells["clmBarcodeId"].Value != null)
        //        {
        //            if (dgvDetails.Tag.ToString().Trim() != dgvDetails.CurrentCell.Value.ToString().Trim())
        //            {
        //                //if (DialogResult.Yes == MessageBox.Show(dgvDetails.CurrentCell.ColumnInfo.HeaderText.ToString() + " value change  ?", "True Account Pro", MessageBoxButtons.YesNo))
        //                //{
        //                //    dgvDetails.Rows[rowIndex].Cells["clmBarcodeId"].Value = null;
        //                //    dgvDetails.Rows[rowIndex].Cells["clmBarcode"].Value = null;
        //                //}
        //                //else
        //                //{
        //                //    dgvDetails.CurrentCell.Value = dgvDetails.Tag.ToString().Trim();
        //                //}
        //            }
        //        }
        //    }
        //}
        //#endregion checkCellValueChanged
        #region dgvDetails_CellEndEdit
        private void dgvDetails_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dgvDetails.Rows.Count - 1 == rowIndex)
            {
                if (dgvDetails.CurrentCell.Value != null)
                {
                    dgvDetails.Rows.AddNew();
                }
            }
            switch (dgvDetails.CurrentCell.ColumnInfo.Name.ToString())
            {
                case "clmBarcode":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmBarcode"].Value != null)
                        {
                            myBarCodeRegInfo.ourBarCode = dgvDetails.Rows[rowIndex].Cells["clmBarcode"].Value.ToString();
                            bindPrdctDtlsToRowByBarCode(rowIndex);
                            //bindProductDetailsToRow(rowIndex);
                            //for (int j = 4; j < dgvDetails.Columns.Count; j++)
                            //{
                            //    dgvDetails.Rows[rowIndex].Cells[j].ReadOnly = false; ;
                            //}
                        }
                        break;
                    }
                case "clmItemCode":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value = dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value;
                            myProductMasterInfo.ProductId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value.ToString());
                            bindPrdctDtlsToRowByItem(rowIndex);
                            for (int j = 5; j < dgvDetails.Columns.Count; j++)
                            {
                                dgvDetails.Rows[rowIndex].Cells[j].ReadOnly = false; ;
                            }
                        }
                        break;
                    }
                case "clmItemName":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value = dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value;
                            myProductMasterInfo.ProductId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value.ToString());
                            bindPrdctDtlsToRowByItem(rowIndex);
                            for (int j = 4; j < dgvDetails.Columns.Count; j++)
                            {
                                dgvDetails.Rows[rowIndex].Cells[j].ReadOnly = false; ;
                            }
                        }
                        break;
                    }
                case "clmCompany":
                    {
                        //checkCellValueChanged(rowIndex);
                        break;
                    }
                case "clmCategory":
                    {
                        //checkCellValueChanged(rowIndex);
                        break;
                    }
                case "clmModel":
                    {
                        //checkCellValueChanged(rowIndex);
                        break;
                    }
                case "clmBrand":
                    {
                       // checkCellValueChanged(rowIndex);
                        break;
                    }
                case "clmColour":
                    {
                       // checkCellValueChanged(rowIndex);
                        break;
                    }
                case "clmSize":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmQty2"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmQty2"].Value = myGenaralFunctions.FormatDecimalPlace((Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmQty"].Value.ToString()) * myPrdctQty2).ToString(), myPrdctDcmlPonts);
                        }
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmUnit":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmUnit"].Value != null)
                        {
                            myProductMasterInfo.ProductId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value.ToString());
                            DataSet detailsDs = myProductMasterOpr.selectProductUnitDetails(myProductMasterInfo);
                            if (detailsDs.Tables[0].Rows.Count > 0)
                            {
                                DataTable myUnitsDt = detailsDs.Tables[0];
                                myUnitsDt.DefaultView.RowFilter = "unit_Id='" + dgvDetails.Rows[rowIndex].Cells["clmUnit"].Value + "'";
                                myUnitsDt = myUnitsDt.DefaultView.ToTable();
                                dgvDetails.Rows[rowIndex].Cells["clmFactor"].Value = myUnitsDt.Rows[0]["factor"].ToString();
                            }
                            // bindUnitsToGrid(Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value));
                        }
                        break;
                    }
                case "clmQty":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmTotaAmount"].Value = ((Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmUnitRate"].Value)) *( Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmQty"].Value)));
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmFreeQtyUnit":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmFreeQtyUnit"].Value != null)
                        {
                            myProductMasterInfo.ProductId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value.ToString());
                            DataSet detailsDs = myProductMasterOpr.selectProductUnitDetails(myProductMasterInfo);
                            if (detailsDs.Tables[0].Rows.Count > 0)
                            {
                                DataTable myUnitsDt = detailsDs.Tables[0];
                                myUnitsDt.DefaultView.RowFilter = "unit_Id='" + dgvDetails.Rows[rowIndex].Cells["clmFreeQtyUnit"].Value + "'";
                                myUnitsDt = myUnitsDt.DefaultView.ToTable();
                                dgvDetails.Rows[rowIndex].Cells["clmFreeQtyFactor"].Value = myUnitsDt.Rows[0]["factor"].ToString();
                            }
                            // bindUnitsToGrid(Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value));
                        }
                        break;
                    }
                case "clmFreeQty":
                    {
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmQty2":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmQty2"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmQty2"].Value = (myGenaralFunctions.FormatDecimalPlace(dgvDetails.Rows[rowIndex].Cells["clmQty2"].Value.ToString().Trim(), myPrdctDcmlPonts));
                            findColumnTotal();
                        }
                        break;
                    }
                case "clmUnitRate":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmTotaAmount"].Value = 0;
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmTotaAmount":
                    {
                        if(dgvDetails.Rows[rowIndex].Cells["clmQty"].Value!=null&& dgvDetails.Rows[rowIndex].Cells["clmQty"].Value.ToString().Trim()!="")
                            dgvDetails.Rows[rowIndex].Cells["clmUnitRate"].Value = (Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmTotaAmount"].Value)) / Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmQty"].Value);
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmDiscPerc":
                    {
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmDiscount":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmDiscPerc"].Value = null;
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmDisc2":
                    {
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmExiceDutyPerc":
                    {
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmExiceDuty":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmExiceDutyPerc"].Value = null;
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmGstPerc":
                    {
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmGstAmount":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmGstPerc"].Value = 0;
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmVatPerc":
                    {
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmVatAmount":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmVatPerc"].Value = 0;
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmCessPerc":
                    { 
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmCessAmount":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmCessPerc"].Value = 0;
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmAddCost":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmCost"].Value = 0;
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmCost":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmAddCost"].Value = 0;
                        calculations(rowIndex);
                        break;
                    }
                case "clmRetailPro":
                    {
                        calculations(rowIndex);
                        break;
                    }
                case "clmRetailRate":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmRetailRate"].Value != null && dgvDetails.Rows[rowIndex].Cells["clmCost"].Value!=null)
                        {
                            decimal Price = Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmRetailRate"].Value);
                            decimal CostPerPc = Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value);
                            decimal Perc = ((Price - CostPerPc) * 100) / CostPerPc;
                            dgvDetails.Rows[rowIndex].Cells["clmRetailPro"].Value = Math.Round(Perc, 2);
                            calculations(rowIndex);
                        }
                        break;
                    }
                case "clmMrpPro":
                    {
                        calculations(rowIndex);
                        break;
                    }
                case "clmMrp":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmMrp"].Value != null &&  dgvDetails.Rows[rowIndex].Cells["clmCost"].Value != null)
                        {
                            decimal Price = Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmMrp"].Value);
                            decimal CostPerPc = Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value);
                            decimal Perc = ((Price - CostPerPc) * 100) / CostPerPc;
                            dgvDetails.Rows[rowIndex].Cells["clmMrpPro"].Value = Math.Round(Perc, 2);
                            calculations(rowIndex);
                        }
                        break;
                    }
                case "clmSpecialratePro":
                    {
                        calculations(rowIndex);
                        break;
                    }
                case "clmSpRate":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmSpRate"].Value != null && dgvDetails.Rows[rowIndex].Cells["clmCost"].Value != null)
                        {
                            decimal Price = Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmSpRate"].Value);
                            decimal CostPerPc = Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value);
                            decimal Perc = ((Price - CostPerPc) * 100) / CostPerPc;
                            dgvDetails.Rows[rowIndex].Cells["clmSpecialratePro"].Value = Math.Round(Perc, 2);
                            calculations(rowIndex);
                        }
                        break;
                    }
                case "clmWhPro":
                    {
                        calculations(rowIndex);
                        break;
                    }
                case "clmWholeSale":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmWholeSale"].Value != null && dgvDetails.Rows[rowIndex].Cells["clmCost"].Value != null)
                        {
                            decimal Price = Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmWholeSale"].Value);
                            decimal CostPerPc = Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value);
                            decimal Perc = ((Price - CostPerPc) * 100) / CostPerPc;
                            dgvDetails.Rows[rowIndex].Cells["clmWhPro"].Value = Math.Round(Perc, 2);
                            calculations(rowIndex);
                        }
                        break;
                    }
                case "clmBranchPro":
                    {
                        calculations(rowIndex);
                        break;
                    }
                case "clmBranchRate":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmBranchRate"].Value != null && dgvDetails.Rows[rowIndex].Cells["clmCost"].Value != null)
                        {
                            decimal Price = Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmBranchRate"].Value);
                            decimal CostPerPc = Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value);
                            decimal Perc = ((Price - CostPerPc) * 100) / CostPerPc;
                            dgvDetails.Rows[rowIndex].Cells["clmBranchPro"].Value = Math.Round(Perc, 2);
                            calculations(rowIndex);
                            findColumnTotal();
                        }
                        break;
                    }
                case "clmGodown":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmGodown"].Value != null)
                            dgvDetails.Rows[rowIndex].Cells["clmGodown"].Value = dgvDetails.Rows[rowIndex].Cells["clmGodown"].Value;
                        break;
                    }
            }
        }
        #endregion dgvDetails_CellEndEdit
        private void dgvDetails_Enter(object sender, EventArgs e)
        {
            myPurchaseGridEdit = true;
        }

        private void dgvDetails_Leave(object sender, EventArgs e)
        {
            myPurchaseGridEdit = false;
        }
        #region mccSupplier_SelectedIndexChanged
        private void mccSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSplrBindCmplt)
            {
                if (mccAccount.SelectedIndex != 0)
                {
                    if (btnSave.Text == "&Save")
                    {
                        myLedgerNameInfo.LedgerIdInt = Convert.ToInt64(mccAccount.SelectedValue.ToString());
                        myLedgerNameInfo.ToDate = null;
                        myLedgerNameInfo.ToTime = null;
                    }
                    else
                    {
                        myLedgerNameInfo.LedgerIdInt = Convert.ToInt64(mccAccount.SelectedValue.ToString());
                        myLedgerNameInfo.ToDate = dtpEntryDate.Value;
                        myLedgerNameInfo.ToTime = dtpEntryTime.Value.ToString();
                    }
                    DataSet suprDetails = myLedgerNameOpr.selectBasicDetailsOfALedgerById(myLedgerNameInfo);
                    if (suprDetails.Tables[0].Rows.Count > 0)
                    {
                        txtSupplier.Text = suprDetails.Tables[0].Rows[0]["ledger_name"].ToString();
                        txtAddress.Text = suprDetails.Tables[0].Rows[0]["address_1"].ToString();
                        txtMobile.Text = suprDetails.Tables[0].Rows[0]["mobile_no"].ToString();
                        txtOldBalance.Text = myGenaralFunctions.FormatDecimalPlace(suprDetails.Tables[0].Rows[0]["balance"].ToString(), 2);
                        ddlNtrOfPurcha.Text = suprDetails.Tables[0].Rows[0]["nature_of_purchase"].ToString();
                        dtpDueDate.Value = suprDetails.Tables[0].Rows[0]["due_days"].ToString() != "" ? DateTime.Now.AddDays(Convert.ToInt32(suprDetails.Tables[0].Rows[0]["due_days"].ToString())) : DateTime.Now;
                        txtTinNo.Text = suprDetails.Tables[0].Rows[0]["tin_no"].ToString();
                        txtCstNo.Text = suprDetails.Tables[0].Rows[0]["cst_no"].ToString();
                    }
                }
                else
                {
                    txtSupplier.Text = "";
                    txtAddress.Text = "";
                    txtMobile.Text = "";
                    txtOldBalance.Text = "0.00";
                    ddlNtrOfPurcha.Text = "";
                    dtpDueDate.Value = DateTime.Now;
                    txtTinNo.Text = "";
                    txtCstNo.Text = "";
                }
            }
        }
        #endregion mccSupplier_SelectedIndexChanged
        #region InsertAccount
        public bool InsertAccount(long accountId1, long accountId2, decimal amount1, decimal amount2, SqlTransaction myTran)
        {
            bool LineFlag1 = false;
            bool LineFlag2 = false;
            myCashLedgerInfo.ourEntryIdentity = myFormId;
            myCashLedgerInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
            myCashLedgerInfo.ourVoucherNo = txtInvoiceNo.Text != null ? txtInvoiceNo.Text : "";
            myCashLedgerInfo.ourEntryDate = Convert.ToDateTime(dtpEntryDate.Value);
            myCashLedgerInfo.ourEntryTime = dtpEntryTime.Value.ToString();
            myCashLedgerInfo.ourAccountId = accountId1;
            myCashLedgerInfo.ourDebit = amount1;
            myCashLedgerInfo.ourCredit = amount2;
            if (myCashLedgerOpr.InsertCashLedger(myCashLedgerInfo, myTran))
                LineFlag1 = true;
            else
                LineFlag1 = false;

            myCashLedgerInfo.ourAccountId = accountId2;
            myCashLedgerInfo.ourDebit = amount2;
            myCashLedgerInfo.ourCredit = amount1;
            if (myCashLedgerOpr.InsertCashLedger(myCashLedgerInfo, myTran))
                LineFlag2 = true;
            else
                LineFlag2 = false;
            if (LineFlag1 == true && LineFlag2 == true)
                return true;
            else
                return false;
        }
        #endregion InsertAccount
        #region InsertCashLedger
        private bool InsertCashLedger(SqlTransaction myTran)
        {
            //bool LineFlag = false;
            int RowCount = 0, RowAffect = 0;
            if (mccAccount.SelectedValue != null)
            {
                if (Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmTotaAmount"].Value.ToString()) > 0)
                {
                    //insert purchase amount cash ledger
                    RowCount++;
                    if (InsertAccount(30, Convert.ToInt32(mccAccount.SelectedValue.ToString()), Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmTotaAmount"].Value.ToString()), 0, myTran))
                        RowAffect++;
                }
                if (Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmDiscount"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmDisc2"].Value.ToString()) > 0)
                {
                    //insert discount amount cash ledger
                    RowCount++;
                    if (InsertAccount(1, Convert.ToInt32(mccAccount.SelectedValue.ToString()), 0, Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmDiscount"].Value.ToString()), myTran))
                        RowAffect++;
                }
                if (Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmExiceDuty"].Value.ToString()) > 0)
                {
                    //insert Exice Duty amount cash ledger
                    RowCount++;
                    if (InsertAccount(55, Convert.ToInt32(mccAccount.SelectedValue.ToString()), Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmExiceDuty"].Value.ToString()), 0, myTran))
                        RowAffect++;
                }
                if (Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmGstAmount"].Value.ToString()) > 0)
                {
                    //insert gst amount cash ledger
                    RowCount++;
                    if (InsertAccount(54, Convert.ToInt32(mccAccount.SelectedValue.ToString()), Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmGstAmount"].Value.ToString()), 0, myTran))
                        RowAffect++;
                }
                if (Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmVatAmount"].Value.ToString()) > 0)
                {
                    //insert vat amount cash ledger
                    RowCount++;
                    if (InsertAccount(40, Convert.ToInt32(mccAccount.SelectedValue.ToString()), Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmVatAmount"].Value.ToString()), 0, myTran))
                        RowAffect++;
                }
                if (Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmCessAmount"].Value.ToString()) > 0)
                {
                    //insert cess to cash ledger
                    RowCount++;
                    if (InsertAccount(41, Convert.ToInt32(mccAccount.SelectedValue.ToString()), Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmCessAmount"].Value.ToString()), 0, myTran))
                        RowAffect++;
                }
                if (Convert.ToDecimal(txtRoundOff.Text) != 0)
                {
                    //insert round off to cash ledger
                    if (Convert.ToDecimal(txtRoundOff.Text) > 0)
                    {
                        RowCount++;
                        if (InsertAccount(14, Convert.ToInt32(mccAccount.SelectedValue.ToString()), Convert.ToDecimal(txtRoundOff.Text), 0, myTran))
                            RowAffect++;
                    }
                    else
                    {
                        RowCount++;
                        if (InsertAccount(14, Convert.ToInt32(mccAccount.SelectedValue.ToString()), 0, Convert.ToDecimal(txtRoundOff.Text), myTran))
                            RowAffect++;
                    }
                }
            }
            if ((RowCount != 0 && RowAffect != 0) && (RowCount == RowAffect))
                return true;
            else
                return false;
        }
        #endregion InsertCashLedger
        #region InsertUnitRateDetails
        private bool InsertUnitRateDetails(SqlTransaction myTran)
        {
            bool LineFlag = false;
            if (dgvUnitRateDetails.Rows.Count > 0)
            {
                for (int i = 0; i < dgvUnitRateDetails.Rows.Count; i++)
                {
                    int RowID = Convert.ToInt32(dgvUnitRateDetails.Rows[i].Cells["clmRowId"].Value);
                    if (btnSave.Text == "&Save")
                    {
                        myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(dgvDetails.Rows[RowID].Cells["clmBarcodeId"].Value.ToString());
                        dgvUnitRateDetails.Rows[i].Cells["clmBarcodeId"].Value = myBarCodeRegInfo.ourBarCodeId;
                    }
                    else
                        myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(dgvUnitRateDetails.Rows[i].Cells["clmBarcodeId"].Value.ToString());
                    myBarCodeRegInfo.ourUnitId = Convert.ToInt64(dgvUnitRateDetails.Rows[i].Cells["clmUnitId"].Value.ToString());
                    myBarCodeRegInfo.ourCost = Convert.ToDecimal(dgvUnitRateDetails.Rows[i].Cells["clmCost"].Value.ToString());
                    myBarCodeRegInfo.ourReatilRatePro = Convert.ToDecimal(dgvUnitRateDetails.Rows[i].Cells["clmRetailPro"].Value.ToString());
                    myBarCodeRegInfo.ourRetailRate = Convert.ToDecimal(dgvUnitRateDetails.Rows[i].Cells["clmRetailRate"].Value.ToString());
                    myBarCodeRegInfo.ourMrpPro = Convert.ToDecimal(dgvUnitRateDetails.Rows[i].Cells["clmMrpPro"].Value.ToString());
                    myBarCodeRegInfo.ourMrp = Convert.ToDecimal(dgvUnitRateDetails.Rows[i].Cells["clmMrp"].Value.ToString());
                    myBarCodeRegInfo.ourSpecialRatePro = Convert.ToDecimal(dgvUnitRateDetails.Rows[i].Cells["clmSpecialratePro"].Value.ToString());
                    myBarCodeRegInfo.ourSpecialRate = Convert.ToDecimal(dgvUnitRateDetails.Rows[i].Cells["clmSpRate"].Value.ToString());
                    myBarCodeRegInfo.ourWhoeSalePro = Convert.ToDecimal(dgvUnitRateDetails.Rows[i].Cells["clmWhPro"].Value.ToString());
                    myBarCodeRegInfo.ourWholeSale = Convert.ToDecimal(dgvUnitRateDetails.Rows[i].Cells["clmWholeSale"].Value.ToString());
                    myBarCodeRegInfo.ourBranchRatePro = Convert.ToDecimal(dgvUnitRateDetails.Rows[i].Cells["clmBranchPro"].Value.ToString());
                    myBarCodeRegInfo.ourBranchRate = Convert.ToDecimal(dgvUnitRateDetails.Rows[i].Cells["clmBranchRate"].Value.ToString());
                    myBarCodeRegInfo.ourEntryId = myFormId;
                    myBarCodeRegInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
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
        #region setBarCodeIdToRateDetails
        private void setBarCodeIdToRateDetails(int i)
        {
            int countRate = dgvUnitRateDetails.Rows.Count;
            for (int j = 0; j < countRate; j++)
            {
                if (dgvUnitRateDetails.Rows[j].Cells["clmBarcodeId"].Value == null)
                {
                    if (i == Convert.ToInt32(dgvUnitRateDetails.Rows[j].Cells["clmRowId"].Value.ToString()))
                    {
                        dgvUnitRateDetails.Rows[j].Cells["clmBarcodeId"].Value = dgvDetails.Rows[i].Cells["clmBarcodeId"].Value;
                    }
                }
            }
        }
        #endregion setBarCodeIdToRateDetails
        #region setValuesOpStockDetails
        private void setValuesOpStockDetails(int rowIndex)
        {
            myPurchaseInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
            myPurchaseInfo.ourBarCodeId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmBarCodeId"].Value);
            myPurchaseInfo.ourItemId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value);
            myPurchaseInfo.ourAddiDescrip = dgvDetails.Rows[rowIndex].Cells["clmAddDescrip"].Value != null ? dgvDetails.Rows[rowIndex].Cells["clmAddDescrip"].Value.ToString() : "";
            myPurchaseInfo.ourUnit = dgvDetails.Rows[rowIndex].Cells["clmUnit"].Value != null ? Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmUnit"].Value.ToString()) : -1;
            myPurchaseInfo.ourQty = dgvDetails.Rows[rowIndex].Cells["clmQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmQty"].Value.ToString()) : 0;
            myPurchaseInfo.ourFreeQtyUnit = dgvDetails.Rows[rowIndex].Cells["clmFreeQtyUnit"].Value != null ? Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmFreeQtyUnit"].Value.ToString()) : -1;
            myPurchaseInfo.ourFreeQty = dgvDetails.Rows[rowIndex].Cells["clmFreeQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmFreeQty"].Value.ToString()) : 0;
            myPurchaseInfo.ourQty2 = dgvDetails.Rows[rowIndex].Cells["clmQty2"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmQty2"].Value.ToString()) : 0;
            myPurchaseInfo.ourTotalQty = dgvDetails.Rows[rowIndex].Cells["clmTotalQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmTotalQty"].Value.ToString()) : 0;
            myPurchaseInfo.ourStickerQty = dgvDetails.Rows[rowIndex].Cells["clmStickerQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmStickerQty"].Value.ToString()) : 0;
            myPurchaseInfo.ourReturnQty = dgvDetails.Rows[rowIndex].Cells["clmReturnQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmReturnQty"].Value.ToString()) : 0;
            myPurchaseInfo.ourGodownId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmGodown"].Value) > -1 ? Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmGodown"].Value) : 0;
        }
        #endregion setValuesOpStockDetails
        #region InsertAdjustmentLedger
        private bool InsertAdjustmentLedger(SqlTransaction myTran)
        {
            bool LineFlag = false;
            if (dgvAdjustment.Rows.Count > 0)
            {
                for (int i = 0; i < dgvAdjustment.Rows.Count; i++)
                {
                    //insert adjustment to cash ledger
                    if (dgvAdjustment.Rows[i].Cells["clmAccount"].Value != null && Convert.ToInt32(dgvAdjustment.Rows[i].Cells["clmAccount"].Value) > 0)
                    {
                        if (dgvAdjustment.Rows[i].Cells["clmAddOrMinus"].Value.ToString() == "1")
                        {
                            if (InsertAccount(Convert.ToInt64(dgvAdjustment.Rows[i].Cells["clmAccount"].Value.ToString()), Convert.ToInt32(mccAccount.SelectedValue.ToString()), Convert.ToDecimal(dgvAdjustment.Rows[i].Cells["clmAmount"].Value.ToString()), 0, myTran))
                                LineFlag = true;
                            else
                                LineFlag = false;
                        }
                        else if (dgvAdjustment.Rows[i].Cells["clmAddOrMinus"].Value.ToString() == "2")
                        {
                            if (InsertAccount(Convert.ToInt64(dgvAdjustment.Rows[i].Cells["clmAccount"].Value.ToString()), Convert.ToInt32(mccAccount.SelectedValue.ToString()), 0, Convert.ToDecimal(dgvAdjustment.Rows[i].Cells["clmAmount"].Value.ToString()), myTran))
                                LineFlag = true;
                            else
                                LineFlag = false;
                        }
                    }
                    else
                        return true;
                }
            }
            else
                LineFlag = true;
            return LineFlag;
        }
        #endregion InsertAdjustmentLedger
        #region ValidateFields
        private bool ValidateFields()
        {
            int rowCount = Convert.ToInt32(dgvDetails.Rows.Count.ToString());
            int entryRowCount = 0;
            for (int i = 1; i < rowCount; i++)
            {
                if (dgvDetails.Rows[i].Cells["clmItemCode"].Value != null)
                {
                    entryRowCount += 1;
                }
            }
            if (entryRowCount == 0)
            {
                MessageBox.Show("Please Enter Product Details.", "True Account Pro",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvDetails.Focus();
                return false;
            }
            return true;
        }
        #endregion ValidateFields
        #region Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "&Edit")
            {
                dgvDetails.Rows.AddNew();
                dgvAdjustment.Rows.AddNew();
                unLockControls();
                btnSave.Text = "&Update";
            }
            else
            {
                if (ValidateFields())
                {
                    SqlCon.OpenSqlCon();
                    SqlTransaction myTran = SqlCon._sqlCon.BeginTransaction();
                    if (btnSave.Text == "&Save")
                    {
                        DialogResult Result = RadMessageBox.Show("Do You Want To Save", "TrueAccountPro", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (Result == DialogResult.Yes)
                        {
                            loadcmplt = false;
                            sedEntryNo.Value = myGenaralFunctions.getMaxValueFromTable("entry_no", "tblPurchaseMaster",myTran);
                            if (InsertPurchaseMaster(myTran))
                                if (InsertBarCodeRegistry(myTran))
                                    if (InsertPurchaseDetails(myTran))
                                        if (InsertStockLedger(myTran))
                                            if (InsertCashLedger(myTran))
                                                if (InsertAdjustmentDetails(myTran))
                                                    if (InsertAdjustmentLedger(myTran))
                                                        if (InsertUnitRateDetails(myTran))
                                                        {
                                                            myTran.Commit();
                                                            myTran.Dispose();
                                                            SqlCon._sqlCon.Close();
                                                            btnSave.Text = "&OK";
                                                            loadcmplt = true;
                                                            RadMessageBox.Show("Successfully Saved", "True Account Pro", MessageBoxButtons.OK, RadMessageIcon.Info);
                                                            if (rtsPrintBarCode.Value)
                                                            {
                                                                DialogResult PrintBarCode = RadMessageBox.Show("Do You Want To Print BarCode?", "TrueAccountPro", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                                                                if (PrintBarCode == DialogResult.Yes)
                                                                {
                                                                    Clear();
                                                                    frmPurchase_Load(sender, e);
                                                                }
                                                                else
                                                                {
                                                                    Clear();
                                                                    frmPurchase_Load(sender, e);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Clear();
                                                                frmPurchase_Load(sender, e);
                                                            }
                                                        }
                                                        else
                                                            RollBack(myTran);
                                                    else
                                                        RollBack(myTran);
                                                else
                                                    RollBack(myTran);
                                            else
                                                RollBack(myTran);
                                        else
                                            RollBack(myTran);
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
                    else if (btnSave.Text == "&Update")
                    {
                        DialogResult Result = RadMessageBox.Show("Do You Want To Update", "TrueAccountPro", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (Result == DialogResult.Yes)
                        {
                            if (InsertPurchaseMaster(myTran))
                                if ((UpdateBarCodeItem(myTran))&& (DeleteUnitRateDetails(myTran)))
                                    if ((DeleteStockLedger(myTran)) && (DeleteCashLedger(myTran)))
                                        if ((DeletePurchaseDetails(myTran)) && (DeleteAdjustment(myTran)))
                                            if (InsertPurchaseDetails(myTran))
                                                if (InsertStockLedger(myTran))
                                                    if (InsertCashLedger(myTran))
                                                        if (InsertAdjustmentDetails(myTran))
                                                            if (InsertAdjustmentLedger(myTran))
                                                                if (InsertUnitRateDetails(myTran))
                                                                {
                                                                    myTran.Commit();
                                                                    myTran.Dispose();
                                                                    SqlCon._sqlCon.Close();
                                                                    btnSave.Text = "&OK";
                                                                    RadMessageBox.Show("Successfully Updated", "True Account Pro", MessageBoxButtons.OK, RadMessageIcon.Info);
                                                                }
                                                                else
                                                                    RollBack1(myTran);
                                                            else
                                                                RollBack1(myTran);
                                                        else
                                                            RollBack1(myTran);
                                                    else
                                                        RollBack1(myTran);
                                                else
                                                    RollBack1(myTran);
                                            else
                                                RollBack1(myTran);
                                        else
                                            RollBack1(myTran);
                                    else
                                        RollBack1(myTran);
                                else
                                    RollBack1(myTran);
                        }
                    }
                }
            }
        }
        #endregion Save
        #region dgvAdjustment_CellEditorInitialized
        private void dgvAdjustment_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            if (e.Column == dgvAdjustment.Columns["clmAccount"])
            {
                RadMultiColumnComboBoxElement editColumn1 = (RadMultiColumnComboBoxElement)e.ActiveEditor;
                editColumn1.EditorControl.Columns["ledger_name"].Width = 200;
                editColumn1.EditorControl.Columns["ledger_name"].HeaderText = "Product Name";
                editColumn1.EditorControl.Columns["ledger_code"].MinWidth = 100;
                editColumn1.EditorControl.Columns["alternate_name"].MinWidth = 200;
                editColumn1.EditorControl.Columns["ledger_code"].HeaderText = "Item Code";
                editColumn1.EditorControl.Columns["alternate_name"].HeaderText = "Alternate Name";
                editColumn1.EditorControl.Columns["ledger_id"].IsVisible = false;
                editColumn1.EditorControl.Columns["op_balance"].IsVisible = false;
                editColumn1.EditorControl.Columns["fixed"].IsVisible = false;
                editColumn1.EditorControl.Columns["balance_type"].IsVisible = false;
                editColumn1.EditorControl.Columns["description"].IsVisible = false;
                editColumn1.EditorControl.Columns["is_active"].IsVisible = false;
                editColumn1.EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                editColumn1.EditorControl.ShowRowHeaderColumn = false;
                editColumn1.DropDownMinSize = new Size(500, 100);
                editColumn1.DropDownSizingMode = SizingMode.None;
                editColumn1.DropDownStyle = RadDropDownStyle.DropDown;
                FilterDescriptor descriptor = new FilterDescriptor(editColumn1.DisplayMember, FilterOperator.Contains, string.Empty);
                //  editColumn1.EditorControl.MasterTemplate.AutoGenerateColumns = false;
                editColumn1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                editColumn1.AutoSizeDropDownToBestFit = false;
                editColumn1.DropDownAnimationEnabled = false;
                //    editColumn1.EditorControl.Columns.Add(new GridViewTextBoxColumn("product_code"));
                FilterDescriptor filtercustomername = new FilterDescriptor("ledger_code", FilterOperator.Contains, string.Empty);
                CompositeFilterDescriptor compositeFilter = new CompositeFilterDescriptor();
                compositeFilter.FilterDescriptors.Add(descriptor);
                compositeFilter.FilterDescriptors.Add(filtercustomername);
                compositeFilter.LogicalOperator = FilterLogicalOperator.Or;
                editColumn1.EditorControl.FilterDescriptors.Add(compositeFilter);
            }
            if (e.Column == dgvAdjustment.Columns["clmParticular"])
            {
                RadDropDownListEditor editor = this.dgvAdjustment.ActiveEditor as RadDropDownListEditor;
                if (editor != null)
                {
                    //RadDropDownList combo = (RadDropDownList)e.ActiveEditor;
                    //editor.DropDownStyle = RadDropDownList;
                    //editor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    //editor.AutoCompleteDataSource = AutoCompleteSource.ListItems;
                    //((RadDropDownListEditorElement)((RadDropDownListEditor)this.dgvAdjustment.ActiveEditor).EditorElement).RightToLeft = true;

                    //    RadDropDownListEditor cmb = dgvAdjustment.ActiveEditor as RadDropDownListEditor;
                    //if (cmb != null)
                    //{
                    //    DataSet modelDts = myAdjustmentOpr.BindingParticulars();
                    //    BindingSource modelBS = new BindingSource();
                    //    modelBS.DataSource = modelDts.Tables[0];
                    //    ((RadDropDownListEditorElement)(cmb).EditorElement).DisplayMember = "particular";
                    //    ((RadDropDownListEditorElement)(cmb).EditorElement).ValueMember = "particular";
                    //    ((RadDropDownListEditorElement)(cmb).EditorElement).DataSource = modelDts.Tables[0];
                    //    ((RadDropDownListEditorElement)(cmb).EditorElement).SelectedIndex = -1;
                    //    ((RadDropDownListEditorElement)(cmb).EditorElement).ShowPopup();
                    //}
                    //}
                }
            }
        }
        #endregion dgvAdjustment_CellEditorInitialized
        #region dgvAdjustment_CellEndEdit
        private void dgvAdjustment_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dgvAdjustment.Rows.Count - 1 == rowIndex)
            {
                if (dgvAdjustment.CurrentCell.Value != null)
                {
                    dgvAdjustment.Rows.AddNew();
                }
            }
            switch (dgvAdjustment.CurrentCell.ColumnInfo.Name.ToString())
            {
                case "clmPercentage":
                    {
                        if (dgvAdjustment.Rows[rowIndex].Cells["clmPercentage"].Value != null)
                        {
                            dgvAdjustment.Rows[rowIndex].Cells["clmAmount"].Value = (Convert.ToDecimal(txtGrandTotal.Text.ToString()) * Convert.ToDecimal(dgvAdjustment.Rows[rowIndex].Cells["clmPercentage"].Value.ToString()) / 100);
                            dgvAdjustment.Rows[rowIndex].Cells["clmAmount"].Value = myGenaralFunctions.FormatDecimalPlace(dgvAdjustment.Rows[rowIndex].Cells["clmAmount"].Value.ToString(), 2);
                            calcAdjstMinusAndAdd();
                        }
                        break;
                    }
                case "clmAddOrMinus":
                    {
                        calcAdjstMinusAndAdd();
                        break;
                    }
                case "clmAmount":
                    {
                        if (dgvAdjustment.Rows[rowIndex].Cells["clmAmount"].Value != null)
                        {
                            dgvAdjustment.Rows[rowIndex].Cells["clmAmount"].Value = myGenaralFunctions.FormatDecimalPlace(dgvAdjustment.Rows[rowIndex].Cells["clmAmount"].Value.ToString(), 2);
                            calcAdjstMinusAndAdd();
                        }
                        break;
                    }
            }
        }
        #endregion dgvAdjustment_CellEndEdit
        #region calcAdjstMinusAndAdd
        private void calcAdjstMinusAndAdd()
        {
            decimal addTotal = 0, minusTotal = 0;
            for (int i = 0; i < dgvAdjustment.Rows.Count; i++)
            {
                if (dgvAdjustment.Rows[i].Cells["clmAmount"].Value != null && dgvAdjustment.Rows[i].Cells["clmAddOrMinus"].Value != null)
                {
                    if (dgvAdjustment.Rows[i].Cells["clmAddOrMinus"].Value.ToString() == "1")
                        addTotal = Convert.ToDecimal(dgvAdjustment.Rows[i].Cells["clmAmount"].Value.ToString()) + addTotal;
                    else
                        minusTotal = Convert.ToDecimal(dgvAdjustment.Rows[i].Cells["clmAmount"].Value.ToString()) + minusTotal;
                }
            }
            txtAdjstAddTotal.Text = myGenaralFunctions.FormatDecimalPlace(addTotal.ToString(), 2);
            txtAdjstMinusTotal.Text = myGenaralFunctions.FormatDecimalPlace(minusTotal.ToString(), 2);
            txtAdjstTotal.Text = myGenaralFunctions.FormatDecimalPlace((addTotal - minusTotal).ToString(), 2);
            txtAdjustment.Text = txtAdjstTotal.Text;
        }
        #endregion calcAdjstMinusAndAdd
        #region txtGrandTotal_TextChanged
        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {
            formTotalCalculations(rcbRoundOff.Checked);
        }
        #endregion txtGrandTotal_TextChanged
        private void txtRoundOff_TextChanged(object sender, EventArgs e)
        {
            formTotalCalculations(rcbRoundOff.Checked);
            txtRoundOff.Text = myGenaralFunctions.ValidateInput(txtRoundOff.Text);
        }

        private void txtAdjustment_TextChanged(object sender, EventArgs e)
        {
            formTotalCalculations(rcbRoundOff.Checked);
        }
        private void txtOldBalance_TextChanged(object sender, EventArgs e)
        {
            formTotalCalculations(rcbRoundOff.Checked);
        }

        private void txtNetAmount_TextChanged(object sender, EventArgs e)
        {
            formTotalCalculations(rcbRoundOff.Checked);
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var v = dataTable.Compute(txtAmountPaid.Text, "");
                myAmountPaid = Convert.ToDecimal(v);
                formTotalCalculations(rcbRoundOff.Checked);
            }
            catch
            {
            }
        }
        private void txtAmountPaid_Leave(object sender, EventArgs e)
        {
            try
            {
                var v = dataTable.Compute(txtAmountPaid.Text, "");
                txtAmountPaid.Text = txtAmountPaid.Text = myGenaralFunctions.FormatDecimalPlace(v.ToString().Trim(), 2);
            }
            catch
            {
                RadMessageBox.Show("Incorrect Formula");
            }
        }
        private void timerTimeUpdate_Tick(object sender, EventArgs e)
        {
            dtpEntryTime.Value = DateTime.Now;
        }

        private void dgvAdjustment_Enter(object sender, EventArgs e)
        {
            myAdjustmentGridEdit = true;
        }

        private void dgvAdjustment_Leave(object sender, EventArgs e)
        {
            myAdjustmentGridEdit = false;
        }
        private void rcbRoundOff_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            myXmlConfigOpr.updateXmlSettings("settings", "iSPurchAutoRoundOff", rcbRoundOff.Checked.ToString());
            formTotalCalculations(rcbRoundOff.Checked);
            if (!rcbRoundOff.Checked)
                txtRoundOff.Text = "0.00";
        }
        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTotalDiscount.Text = (Convert.ToDecimal(txtDiscount.Text) + Convert.ToDecimal(txtTotalDiscount.Text)).ToString();
                txtDiscount.Text = "0.00";
            }
            else if (e.KeyChar == 27)
                txtDiscount.Text = "0.00";
        }
        #region DivideDiscount
        private void btnDivideDiscount_Click(object sender, EventArgs e)
        {
            decimal Total = 0, divideDisc = 0, rowTotal = 0, discount = 0,columnTotal=0;
            string clmName;
            if (rdbTotalAmount.IsChecked)
                clmName = "clmTotaAmount";
            else
                clmName = "clmGrossValue";
            for (int i = 1; i < dgvDetails.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvDetails.Rows[i].Cells["clmSelect"].Value)>0)
                    Total += Convert.ToDecimal(dgvDetails.Rows[i].Cells[clmName].Value);
            }
            divideDisc = Convert.ToDecimal(txtTotalDiscount.Text);
            for (int i = 1; i < dgvDetails.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvDetails.Rows[i].Cells["clmSelect"].Value) > 0)
                {
                    rowTotal = Convert.ToDecimal(dgvDetails.Rows[i].Cells[clmName].Value)/Total;
                    //rowTotal = Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmDiscount"].Value);
                    //    discount = (divideDisc * rowTotal) / amount;
                    if (ddlApplyColumn.SelectedIndex == 0)
                    {
                        columnTotal = Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmDiscount"].Value);
                        discount = (rowTotal * divideDisc);
                        dgvDetails.Rows[i].Cells["clmDiscount"].Value = Math.Round(columnTotal + discount,2);
                    }
                    else
                    {
                        columnTotal = Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmDisc2"].Value);
                        discount = (rowTotal * divideDisc);
                        dgvDetails.Rows[i].Cells["clmDisc2"].Value = Math.Round(columnTotal + discount,2);
                    }
                    calculations(i);
                    findColumnTotal();
                }
            }
        }
        #endregion DivideDiscount
        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtTotalCost.Text = (Convert.ToDecimal(txtCost.Text) + Convert.ToDecimal(txtTotalCost.Text)).ToString();
                txtCost.Text = "0.00";
            }
            else if (e.KeyChar == 27)
                txtCost.Text = "0.00";
        }
        #region DivideCost
        private void btnDivideCost_Click(object sender, EventArgs e)
        {
            decimal grandTotal = 0, divideCost = 0, rowGrandTotal = 0, AddCost = 0,PreAddCost=0;
            for (int i = 1; i < dgvDetails.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvDetails.Rows[i].Cells["clmSelect"].Value) > 0)
                    grandTotal += Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmGrandTotal"].Value);
            }
            for (int i = 1; i < dgvDetails.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvDetails.Rows[i].Cells["clmSelect"].Value) > 0)
                {
                    divideCost = Convert.ToDecimal(txtTotalCost.Text);
                    rowGrandTotal = Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmGrandTotal"].Value);
                    AddCost = (divideCost * rowGrandTotal)/ grandTotal;
                    PreAddCost = Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmAddCost"].Value);
                    dgvDetails.Rows[i].Cells["clmAddCost"].Value = Math.Round(PreAddCost + AddCost,2);
                    calculations(i);
                    findColumnTotal();
                }
            }
        }
        #endregion DivideCost
        #region Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCon.OpenSqlCon();
            SqlTransaction myTran = SqlCon._sqlCon.BeginTransaction();
            if (DialogResult.Yes == RadMessageBox.Show("Are You Sure!?Do You Want To Delete ?  ", "True Account Pro", MessageBoxButtons.YesNo, RadMessageIcon.Question))
            {
                if ((DeletePurchaseMaster(myTran)) && (DeleteStockLedger(myTran)))
                    if ((DeletePurchaseDetails(myTran)) && (DeleteCashLedger(myTran)))
                        if((DeleteAdjustment(myTran))&& (DeleteUnitRateDetails(myTran)))
                        {
                            myTran.Commit();
                            myTran.Dispose();
                            SqlCon._sqlCon.Close();
                            frmPurchase_Load(sender, e);
                            RadMessageBox.Show("Successfully Deleted", "True Account Pro", MessageBoxButtons.OK, RadMessageIcon.Info);
                        }
                        else
                            RollBack2(myTran);
                    else
                        RollBack2(myTran);
                else
                    RollBack2(myTran);
            }
            else
                SqlCon._sqlCon.Close();
        }
        #endregion Delete
        private void rcpAddcost_Expanded(object sender, EventArgs e)
        {
            if (rcpAddcost.IsExpanded)
                rcpAddDiscount.IsExpanded = false;
        }
        private void rcpAddDiscount_Expanded(object sender, EventArgs e)
        {
            if (rcpAddDiscount.IsExpanded)
                rcpAddcost.IsExpanded = false;
        }
        private void txtAmountPaid_KeyDown(object sender, KeyEventArgs e)
        {
            NumericValidatorInfo.RestrictDecimal(ref e, txtAmountPaid.Text.Trim());
        }
        private void txtRoundOff_KeyDown(object sender, KeyEventArgs e)
        {
            NumericValidatorInfo.RestrictDecimal(ref e, txtRoundOff.Text.Trim(), txtRoundOff.SelectionStart, 10, 2);
        }
        private void txtRoundOff_Leave(object sender, EventArgs e)
        {
            txtRoundOff.Text = myGenaralFunctions.FormatDecimalPlace(txtRoundOff.Text.Trim(), 2);
        }
        private void dgvUnitRateDetails_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            //int rowIndex = Convert.ToInt32(e.RowIndex);
            //if (dgvUnitRateDetails.Rows.Count - 1 == rowIndex)
            //{
            //    //if (dgvUnitRateDetails.CurrentCell.Value != null)
            //        //dgvUnitRateDetails.Rows.AddNew();
            //}
        }
        #region sedEntryNo_ValueChanged
        private void sedEntryNo_ValueChanged(object sender, EventArgs e)
        {
            if (loadcmplt)
            {
                Clear();
                dgvDetails.Rows.AddNew();
                dgvDetails.Rows[0].IsPinned = true;
                dgvDetails.Rows[0].PinPosition = PinnedRowPosition.Bottom;
                for (int j = 0; j < dgvDetails.ColumnCount; j++)
                {
                    dgvDetails.Rows[0].Cells[j].ReadOnly = true;
                }
                myPurchaseInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
                myMasterDtls = mypurchaseOpr.selectAPurchaseMasterDetailByEntryNo(myPurchaseInfo);
                if (myMasterDtls.Tables[0].Rows.Count > 0)
                {
                    btnSave.Text = "&Edit";
                    dtpEntryDate.Value = Convert.ToDateTime(myMasterDtls.Tables[0].Rows[0]["entry_date"].ToString());
                    dtpEntryTime.Checked = true;
                    timerTimeUpdate.Enabled = false;
                    dtpEntryTime.Value = Convert.ToDateTime(myMasterDtls.Tables[0].Rows[0]["entry_time"].ToString());
                    txtInvoiceNo.Text = myMasterDtls.Tables[0].Rows[0]["invoice_no"].ToString();
                    dtpInvoiceDate.Value = Convert.ToDateTime(myMasterDtls.Tables[0].Rows[0]["invoice_date"].ToString());
                    mccAccount.SelectedValue = Convert.ToInt32(myMasterDtls.Tables[0].Rows[0]["account_id"].ToString());
                    txtSupplier.Text = myMasterDtls.Tables[0].Rows[0]["suppiler_name"].ToString();
                    txtAddress.Text = myMasterDtls.Tables[0].Rows[0]["suppler_address"].ToString();
                    txtMobile.Text = myMasterDtls.Tables[0].Rows[0]["supplier_mobile"].ToString();
                    txtDescription.Text = myMasterDtls.Tables[0].Rows[0]["description"].ToString();
                    txtTinNo.Text = myMasterDtls.Tables[0].Rows[0]["tin_no"].ToString();
                    txtCstNo.Text = myMasterDtls.Tables[0].Rows[0]["cst_no"].ToString();
                    ddlNtrOfPurcha.SelectedIndex = Convert.ToInt32(myMasterDtls.Tables[0].Rows[0]["natr_of_purch"].ToString());
                    txtCFormNo.Text = myMasterDtls.Tables[0].Rows[0]["c_form"].ToString();
                    dtpCFromDate.Value = Convert.ToDateTime(myMasterDtls.Tables[0].Rows[0]["c_form_date"].ToString());
                    dtpDeliveryDate.Value = Convert.ToDateTime(myMasterDtls.Tables[0].Rows[0]["delivery_date"].ToString());
                    ddlFormType.SelectedIndex = Convert.ToInt32(myMasterDtls.Tables[0].Rows[0]["form_type"].ToString());
                    txtRoundOff.Text = myMasterDtls.Tables[0].Rows[0]["round_off"].ToString();
                    txtGrandTotal.Text = myMasterDtls.Tables[0].Rows[0]["grand_total"].ToString();
                    txtNetAmount.Text = myMasterDtls.Tables[0].Rows[0]["net_amount"].ToString();
                    txtAmountPaid.Text = myMasterDtls.Tables[0].Rows[0]["amount_paid"].ToString();
                    txtBalance.Text = myMasterDtls.Tables[0].Rows[0]["balance"].ToString();
                    txtOldBalance.Text = myMasterDtls.Tables[0].Rows[0]["old_balance"].ToString();
                    txtClBalance.Text = myMasterDtls.Tables[0].Rows[0]["closing_balance"].ToString();
                    txtAdjustment.Text = myMasterDtls.Tables[0].Rows[0]["adjustment"].ToString();
                    if (myMasterDtls.Tables[0].Rows[0]["due_date"].ToString() == "")
                        dtpDueDate.Checked = false;
                    else
                    {
                        dtpDueDate.Checked = true;
                        dtpDueDate.Value = Convert.ToDateTime(myMasterDtls.Tables[0].Rows[0]["due_date"].ToString());
                    }
                    myDetailsDtls = mypurchaseOpr.selectAPurchaseDetailsByEntryNo(myPurchaseInfo);
                    for (int i = 0; i < myDetailsDtls.Tables[0].Rows.Count; i++)
                    {
                        dgvDetails.Rows.AddNew();
                        dgvDetails.Rows[i + 1].Cells["clmBarcodeId"].Value = myDetailsDtls.Tables[0].Rows[i]["bar_code_id"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmEntryNo"].Value = myDetailsDtls.Tables[0].Rows[i]["entry_no"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmBarcode"].Value = myDetailsDtls.Tables[0].Rows[i]["bar_code"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmItemCode"].Value = myDetailsDtls.Tables[0].Rows[i]["item_id"].ToString();
                        //dgvDetails.Rows[i + 1].Cells["clmItemName"].Value = myDetailsDtls.Tables[0].Rows[i]["product_name"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmCompany"].Value = myDetailsDtls.Tables[0].Rows[i]["company_id"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmCategory"].Value = myDetailsDtls.Tables[0].Rows[i]["category_id"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmModel"].Value = myDetailsDtls.Tables[0].Rows[i]["model_id"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmBrand"].Value = myDetailsDtls.Tables[0].Rows[i]["brand_id"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmColour"].Value = myDetailsDtls.Tables[0].Rows[i]["colour_id"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmSize"].Value = myDetailsDtls.Tables[0].Rows[i]["size_id"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmAddDescrip"].Value = myDetailsDtls.Tables[0].Rows[i]["add_descrip"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmBatch"].Value = myDetailsDtls.Tables[0].Rows[i]["batch"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmExpDate"].Value = myDetailsDtls.Tables[0].Rows[i]["exp_date"].ToString() == "" ? null : myDetailsDtls.Tables[0].Rows[i]["exp_date"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmUnit"].Value = Convert.ToInt64(myDetailsDtls.Tables[0].Rows[i]["unit"]) != -1 ? myDetailsDtls.Tables[0].Rows[i]["unit"].ToString() :"";
                        dgvDetails.Rows[i + 1].Cells["clmFreeQtyUnit"].Value = Convert.ToInt64(myDetailsDtls.Tables[0].Rows[i]["free_qty_unit"]) != -1 ? myDetailsDtls.Tables[0].Rows[i]["free_qty_unit"].ToString() : "";
                        dgvDetails.Rows[i + 1].Cells["clmQty"].Value = myDetailsDtls.Tables[0].Rows[i]["qty"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmFreeQty"].Value = myDetailsDtls.Tables[0].Rows[i]["free_qty"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmQty2"].Value = myDetailsDtls.Tables[0].Rows[i]["qty_2"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmTotalQty"].Value = myDetailsDtls.Tables[0].Rows[i]["total_qty"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmStickerQty"].Value = myDetailsDtls.Tables[0].Rows[i]["sticker_qty"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmReturnQty"].Value = myDetailsDtls.Tables[0].Rows[i]["return_qty"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmunitRate"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["unit_rate"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmTotaAmount"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["total_amount"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmDiscPerc"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["disc_perc"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmDiscount"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["discount"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmDisc2"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["disc2"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmGrossValue"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["gross_value"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmExiceDutyPerc"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["exice_duty_perc"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmExiceDuty"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["exice_duty"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmGstPerc"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["gst_perc"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmGstAmount"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["gst_amount"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmNetValue"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["net_value"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmVatPerc"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["vat_perc"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmVatAmount"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["vat_amount"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmCessPerc"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["cess_perc"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmCessAmount"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["cess_amount"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmGrandTotal"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["grand_total"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmAddCost"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["add_cost"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmCost"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["cost"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmRetailPro"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["reatil_rate_pro"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmRetailRate"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["retail_rate"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmMrpPro"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["mrp_pro"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmMrp"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["mrp"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmSpecialratePro"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["special_rate_pro"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmSpRate"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["special_rate"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmWhPro"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["whoe_sale_pro"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmWholeSale"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["whole_sale"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmBranchPro"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["branch_rate_pro"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmBranchRate"].Value = myGenaralFunctions.FormatDecimalPlace(myDetailsDtls.Tables[0].Rows[i]["branch_rate"].ToString(), 2);
                        dgvDetails.Rows[i + 1].Cells["clmItemBarcode"].Value = myDetailsDtls.Tables[0].Rows[i]["item_bar_code"].ToString();
                        dgvDetails.Rows[i + 1].Cells["clmGodown"].Value = myDetailsDtls.Tables[0].Rows[i]["godown_id"].ToString();
                        //calculations(i + 1);
                    }
                    SelectUnitRateDetails();
                    findColumnTotal();
                    myAdjustmentInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
                    myAdjustmentInfo.ourEntryId = myFormId;
                    myAdjustmentDtls = myAdjustmentOpr.selectAAdjustmentByEntryNO(myAdjustmentInfo);
                    for (int i = 0; i < myAdjustmentDtls.Tables[0].Rows.Count; i++)
                    {
                        dgvAdjustment.Rows.AddNew();
                        dgvAdjustment.Rows[i].Cells["clmAccount"].Value = myAdjustmentDtls.Tables[0].Rows[i]["account"].ToString();
                        dgvAdjustment.Rows[i].Cells["clmParticular"].Value = myAdjustmentDtls.Tables[0].Rows[i]["particular"].ToString();
                        dgvAdjustment.Rows[i].Cells["clmAddOrMinus"].Value = myAdjustmentDtls.Tables[0].Rows[i]["add_minus"].ToString();
                        dgvAdjustment.Rows[i].Cells["clmPercentage"].Value = myAdjustmentDtls.Tables[0].Rows[i]["percentage"].ToString();
                        dgvAdjustment.Rows[i].Cells["clmAmount"].Value = Math.Round(Convert.ToDecimal(myAdjustmentDtls.Tables[0].Rows[i]["amount"]), 2);
                    }
                    calcAdjstMinusAndAdd();
                    lockControls();
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnSave.Text = "&Save";
                }
            }
        }
        #endregion sedEntryNo_ValueChanged
        #region lockControls
        private void lockControls()
        {
            dtpEntryTime.ReadOnly = true;
            dtpDueDate.ReadOnly = true;
            dtpEntryDate.ReadOnly = true;
            txtInvoiceNo.ReadOnly = true;
            dtpInvoiceDate.ReadOnly = true;
            // mccAccount.ReadOnly = true;
            txtSupplier.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtMobile.ReadOnly = true;
            txtDescription.ReadOnly = true;
            txtTinNo.ReadOnly = true;
            txtCstNo.ReadOnly = true;
            txtCFormNo.ReadOnly = true;
            dtpCFromDate.ReadOnly = true;
            ddlNtrOfPurcha.ReadOnly = true;
            dtpDeliveryDate.ReadOnly = true;
            ddlFormType.ReadOnly = true;
            dgvDetails.ReadOnly = true;
            dgvAdjustment.ReadOnly = true;
            txtRoundOff.ReadOnly = true;
            txtAmountPaid.ReadOnly = true;
        }
        #endregion lockControls
        #region unLockControls
        private void unLockControls()
        {
            dtpEntryTime.ReadOnly = false;
            dtpDueDate.ReadOnly = false;
            dtpEntryDate.ReadOnly = false;
            txtInvoiceNo.ReadOnly = false;
            dtpInvoiceDate.ReadOnly = false;
            // mccAccount.ReadOnly = true;
            txtSupplier.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtMobile.ReadOnly = false;
            txtDescription.ReadOnly = false;
            txtTinNo.ReadOnly = false;
            txtCstNo.ReadOnly = false;
            txtCFormNo.ReadOnly = false;
            dtpCFromDate.ReadOnly = false;
            ddlNtrOfPurcha.ReadOnly = false;
            dtpDeliveryDate.ReadOnly = false;
            ddlFormType.ReadOnly = false;
            dgvDetails.ReadOnly = false;
            dgvAdjustment.ReadOnly = false;
            txtRoundOff.ReadOnly = false;
            txtAmountPaid.ReadOnly = false;
        }
        #endregion unLockControls
        #region New
        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            unLockControls();
            DataSet ds= myGenaralFunctions.IsPrintBarCodeLoad();
            rtsPrintBarCode.Value = Convert.ToBoolean(ds.Tables[0].Rows[0]["BarCode_Print"]);
            loadcmplt = false;
            sedEntryNo.Value = myGenaralFunctions.getMaxValueOfFiledInTable("entry_no", "tblPurchaseMaster");
            rtsSpecificEntry.Value = false;
            for (int i = 0; i < 2; i++)
            {
                dgvDetails.Rows.AddNew();
                for (int j = 4; j < dgvDetails.Columns.Count; j++)
                {
                    dgvDetails.Rows[i].Cells[j].ReadOnly = false;
                }
            }
            dgvDetails.Rows[0].IsPinned = true;
            dgvDetails.Rows[0].PinPosition = PinnedRowPosition.Bottom;
            for (int j = 0; j < dgvDetails.ColumnCount; j++)
            {
                dgvDetails.Rows[0].Cells[j].ReadOnly = true;
            }
            dgvAdjustment.Rows.AddNew();
            txtRoundOff.Text = "0.00";
            txtAmountPaid.Text = "0.00";
            btnDelete.Enabled = false;
            btnSave.Text = "&Save";
            loadcmplt = true;
        }
        #endregion New
        #region InsertPurchaseMaster
        public bool InsertPurchaseMaster(SqlTransaction myTran)
        {
            bool LineFlag = false;
            if (rtsSpecificEntry.Value)
                myPurchaseInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
            else if(rtsSpecificEntry.Value == false && btnSave.Text != "&Update")
                myPurchaseInfo.ourEntryNo = 0;
            myPurchaseInfo.ourEntryDate = dtpEntryDate.Value;
            myPurchaseInfo.ourEntryTime = dtpEntryTime.Value.ToString();
            myPurchaseInfo.ourUpdateDate = DateTime.Now;
            myPurchaseInfo.ourUpdateTime = DateTime.Now.ToString();
            myPurchaseInfo.ourInvoiceNo = txtInvoiceNo.Text;
            myPurchaseInfo.ourInvoiceDate = dtpInvoiceDate.Value;
            myPurchaseInfo.ourAccountId = Convert.ToInt64(mccAccount.SelectedValue);
            myPurchaseInfo.ourSupplierName = txtSupplier.Text;
            myPurchaseInfo.ourAddress = txtAddress.Text;
            myPurchaseInfo.ourMobile = txtMobile.Text;
            myPurchaseInfo.ourDescription = txtDescription.Text;
            myPurchaseInfo.ourTinNo = txtTinNo.Text;
            myPurchaseInfo.ourCstNo = txtCstNo.Text;
            myPurchaseInfo.ourCFormNo = txtCFormNo.Text;
            myPurchaseInfo.ourCFromDate = dtpCFromDate.Value;
            myPurchaseInfo.ourNtrOfPurch = ddlNtrOfPurcha.SelectedIndex;
            myPurchaseInfo.ourDeliveryDate = dtpDeliveryDate.Value;
            myPurchaseInfo.ourFromType = ddlFormType.SelectedIndex == -1 ? 0 : ddlFormType.SelectedIndex;
            myPurchaseInfo.ourRoundOff = Convert.ToDecimal(txtRoundOff.Text.ToString());
            myPurchaseInfo.ourRoundOffCheck = rcbRoundOff.Checked == true ? true : false;
            myPurchaseInfo.ourGrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
            myPurchaseInfo.ourNetTotal = Convert.ToDecimal(txtNetAmount.Text);
            myPurchaseInfo.ourAmountPaid = Convert.ToDecimal(txtAmountPaid.Text.ToString());
            myPurchaseInfo.ourBalance = Convert.ToDecimal(txtBalance.Text);
            myPurchaseInfo.ourOldBalance = Convert.ToDecimal(txtOldBalance.Text);
            myPurchaseInfo.ourClosingBalance = Convert.ToDecimal(txtClBalance.Text);
            myPurchaseInfo.ourAdjustment = Convert.ToDecimal(txtAdjustment.Text);
            if (dtpDueDate.Checked)
                myPurchaseInfo.ourDueDate = dtpDueDate.Value;
            else
                myPurchaseInfo.ourDueDate = null;
            myPurchaseInfo.ourUserId = myUserId;
            if (mypurchaseOpr.InsertPurchaseMaster(myPurchaseInfo, myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
        #endregion InsertPurchaseMaster
        #region Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Close
        #region InsertPurchaseDetails
        public bool InsertPurchaseDetails(SqlTransaction myTran)
        {
            bool LineFlag = false;
            for (int i = 1; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.Rows[i].Cells["clmItemCode"].Value != null && dgvDetails.Rows[i].Cells["clmItemCode"].Value.ToString().Trim() != "")
                {
                    myPurchaseInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
                    myPurchaseInfo.ourBarCodeId = Convert.ToInt64(dgvDetails.Rows[i].Cells["clmBarCodeId"].Value);
                    myPurchaseInfo.ourItemId = Convert.ToInt64(dgvDetails.Rows[i].Cells["clmItemCode"].Value);
                    myPurchaseInfo.ourAddiDescrip = dgvDetails.Rows[i].Cells["clmAddDescrip"].Value != null ? dgvDetails.Rows[i].Cells["clmAddDescrip"].Value.ToString() : "";
                    myPurchaseInfo.ourUnit = dgvDetails.Rows[i].Cells["clmUnit"].Value != null&& dgvDetails.Rows[i].Cells["clmUnit"].Value.ToString().Trim()!="" ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmUnit"].Value.ToString()) :-1;
                    myPurchaseInfo.ourQty = dgvDetails.Rows[i].Cells["clmQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmQty"].Value.ToString()) : 0;
                    myPurchaseInfo.ourFreeQtyUnit = dgvDetails.Rows[i].Cells["clmFreeQtyUnit"].Value != null && dgvDetails.Rows[i].Cells["clmFreeQtyUnit"].Value.ToString().Trim()!=""? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmFreeQtyUnit"].Value.ToString()) :-1;
                    myPurchaseInfo.ourFreeQty = dgvDetails.Rows[i].Cells["clmFreeQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmFreeQty"].Value.ToString()) : 0;
                    myPurchaseInfo.ourQty2 = dgvDetails.Rows[i].Cells["clmQty2"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmQty2"].Value.ToString()) : 0;
                    myPurchaseInfo.ourTotalQty = dgvDetails.Rows[i].Cells["clmTotalQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmTotalQty"].Value.ToString()) : 0;
                    myPurchaseInfo.ourStickerQty = dgvDetails.Rows[i].Cells["clmStickerQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmStickerQty"].Value.ToString()) : 0;
                    myPurchaseInfo.ourReturnQty = dgvDetails.Rows[i].Cells["clmReturnQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmReturnQty"].Value.ToString()) : 0;
                    myPurchaseInfo.ourGodownId = Convert.ToInt64(dgvDetails.Rows[i].Cells["clmGodown"].Value) > -1 ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmGodown"].Value) : 0;
                    myPurchaseInfo.ourUnitId = dgvDetails.Rows[i].Cells["clmUnit"].Value != null && dgvDetails.Rows[i].Cells["clmUnit"].Value.ToString().Trim() != "" ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmUnit"].Value.ToString()) : -1;
                    myPurchaseInfo.ourUnitRate = dgvDetails.Rows[i].Cells["clmunitRate"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmUnitRate"].Value.ToString()) : 0;
                    myPurchaseInfo.ourDiscPerc = dgvDetails.Rows[i].Cells["clmDiscPerc"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmDiscPerc"].Value.ToString()) : 0;
                    myPurchaseInfo.ourDisc2 = dgvDetails.Rows[i].Cells["clmDisc2"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmDisc2"].Value.ToString()) : 0;
                    myPurchaseInfo.ourExiceDutyPerc = dgvDetails.Rows[i].Cells["clmExiceDutyPerc"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmExiceDutyPerc"].Value.ToString()) : 0;
                    myPurchaseInfo.ourGstPerc = dgvDetails.Rows[i].Cells["clmGstPerc"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmGstPerc"].Value.ToString()) : 0;
                    myPurchaseInfo.ourNetValue = dgvDetails.Rows[i].Cells["clmNetValue"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmNetValue"].Value.ToString()) : 0;
                    myPurchaseInfo.ourVatPerc = dgvDetails.Rows[i].Cells["clmVatPerc"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmVatPerc"].Value.ToString()) : 0;
                    myPurchaseInfo.ourCessPerc = dgvDetails.Rows[i].Cells["clmCessPerc"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmCessPerc"].Value.ToString()) : 0;
                    myPurchaseInfo.ourGrndTotal = dgvDetails.Rows[i].Cells["clmGrandTotal"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmGrandTotal"].Value.ToString()) : 0;
                    if (mypurchaseOpr.InsertPurchaseDetails(myPurchaseInfo, myTran))
                        LineFlag = true;
                    else
                    {
                        LineFlag = false;
                        break;
                    }
                }
            }
            return LineFlag;
        }
        #endregion InsertPurchaseDetails
        #region InsertStockLedger
        public bool InsertStockLedger(SqlTransaction myTran)
        {
            bool LineFlag = false;
            for (int i = 1; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.Rows[i].Cells["clmItemCode"].Value != null && dgvDetails.Rows[i].Cells["clmItemCode"].Value.ToString().Trim() != "")
                {
                    myStockInfo.ourEntryDate = Convert.ToDateTime(dtpEntryDate.Value);
                    myStockInfo.ourEntryTime = dtpEntryTime.Value.ToString();
                    myStockInfo.ourEntryId = myFormId;
                    myStockInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
                    myStockInfo.ourBarCode = Convert.ToInt64(dgvDetails.Rows[i].Cells["clmBarCodeId"].Value);
                    myStockInfo.ourItemId = Convert.ToInt64(dgvDetails.Rows[i].Cells["clmItemCode"].Value);
                    myStockInfo.ourGodownId = Convert.ToInt64(dgvDetails.Rows[i].Cells["clmGodown"].Value) > -1 ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmGodown"].Value) : 0;
                    myStockInfo.ourInwardQty = Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmQty"].Value) * Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmFactor"].Value) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmFreeQty"].Value) * Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmFreeQtyFactor"].Value);
                    myStockInfo.ourInwardQty2 = dgvDetails.Rows[i].Cells["clmQty2"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmQty2"].Value.ToString()) : 0;
                    myStockInfo.ourOutwardQty = 0;
                    myStockInfo.ourOutwardQty2 = 0;
                    myStockInfo.ourInwardNetValue = dgvDetails.Rows[i].Cells["clmNetValue"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmNetValue"].Value.ToString()) : 0;
                    myStockInfo.ourOutwardNetValue = 0;
                    myStockInfo.ourOutwardNetValue = 0;
                    myStockInfo.ourAddDescrip = dgvDetails.Rows[i].Cells["clmAddDescrip"].Value != null ? dgvDetails.Rows[i].Cells["clmAddDescrip"].Value.ToString() : "";
                    if (myStockOpr.InsertStockLedger(myStockInfo, myTran))
                        LineFlag = true;
                    else
                    {
                        LineFlag = false;
                        break;
                    }
                }
            }
            return LineFlag;
        }
        #endregion InsertStockLedger
        #region InsertBarCodeRegistry
        public bool InsertBarCodeRegistry(SqlTransaction myTran)
        {
            bool LineFlag = false;
            for (int i = 1; i < dgvDetails.RowCount; i++)
            {
                if (dgvDetails.Rows[i].Cells["clmItemCode"].Value != null && dgvDetails.Rows[i].Cells["clmItemCode"].Value.ToString().Trim() != "")
                {
                    if (dgvDetails.Rows[i].Cells["clmBarcodeId"].Value == null || Convert.ToInt64(dgvDetails.Rows[i].Cells["clmBarcodeId"].Value) <= 0)
                    {
                        myBarCodeRegInfo.ourCount = 0;
                        myBarCodeRegInfo.ourBarCodeId = 0;
                        myBarCodeRegInfo.ourItemId = Convert.ToInt64(dgvDetails.Rows[i].Cells["clmItemCode"].Value);
                        myBarCodeRegInfo.ourCompanyId = dgvDetails.Rows[i].Cells["clmCompany"].Value != null ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmCompany"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourCategoryId = dgvDetails.Rows[i].Cells["clmCategory"].Value != null ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmCategory"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourModelId = dgvDetails.Rows[i].Cells["clmModel"].Value != null ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmModel"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourBrandId = dgvDetails.Rows[i].Cells["clmBrand"].Value != null ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmBrand"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourColourId = dgvDetails.Rows[i].Cells["clmColour"].Value != null ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmColour"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourSizeId = dgvDetails.Rows[i].Cells["clmSize"].Value != null ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmSize"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourBatch = dgvDetails.Rows[i].Cells["clmBatch"].Value != null ? dgvDetails.Rows[i].Cells["clmBatch"].Value.ToString() : "";
                        if (dgvDetails.Rows[i].Cells["clmExpDate"].Value != null)
                            myBarCodeRegInfo.ourExpDate = Convert.ToDateTime(dgvDetails.Rows[i].Cells["clmExpDate"].Value.ToString());
                        else
                            myBarCodeRegInfo.ourExpDate = null;
                        myBarCodeRegInfo.ourAddCost = dgvDetails.Rows[i].Cells["clmAddCost"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmAddCost"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourCost = dgvDetails.Rows[i].Cells["clmCost"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmCost"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourReatilRatePro = dgvDetails.Rows[i].Cells["clmRetailPro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmRetailPro"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourRetailRate = dgvDetails.Rows[i].Cells["clmRetailRate"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmRetailRate"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourMrpPro = dgvDetails.Rows[i].Cells["clmMrpPro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmMrpPro"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourMrp = dgvDetails.Rows[i].Cells["clmMrp"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmMrp"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourSpecialRatePro = dgvDetails.Rows[i].Cells["clmSpecialratePro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmSpecialratePro"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourSpecialRate = dgvDetails.Rows[i].Cells["clmSpRate"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmSpRate"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourWhoeSalePro = dgvDetails.Rows[i].Cells["clmWhPro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmWhPro"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourWholeSale = dgvDetails.Rows[i].Cells["clmWholeSale"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmWholeSale"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourBranchRatePro = dgvDetails.Rows[i].Cells["clmBranchPro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmBranchPro"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourBranchRate = dgvDetails.Rows[i].Cells["clmBranchRate"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmBranchRate"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourItemBarCode = dgvDetails.Rows[i].Cells["clmItemBarcode"].Value != null ? dgvDetails.Rows[i].Cells["clmItemBarcode"].Value.ToString() : "";
                        myBarCodeRegInfo.ourEntryId = myFormId;
                        myBarCodeRegInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
                        if (myBarCodeRegOpr.InsertBarCodeRegistry(myBarCodeRegInfo, myTran))
                        {
                            DataSet dtt = myBarCodeRegOpr.SelectLastInsertedBarCode(myTran);
                            if (dtt.Tables[0].Rows.Count > 0)
                            {
                                dgvDetails.Rows[i].Cells["clmBarcodeId"].Value = dtt.Tables[0].Rows[0]["bar_code_id"];
                                dgvDetails.Rows[i].Cells["clmBarcode"].Value = dtt.Tables[0].Rows[0]["bar_code"];
                                LineFlag = true;
                            }
                            else
                                LineFlag = false;
                        }
                        else
                        {
                            LineFlag = false;
                            break;
                        }
                    }
                    else if(btnSave.Text!="&Save")
                    {
                        myBarCodeRegInfo.ourCount = Count;
                        myBarCodeRegInfo.ourBarCodeId= Convert.ToInt64(dgvDetails.Rows[i].Cells["clmBarcodeId"].Value.ToString());
                        myBarCodeRegInfo.ourBarCode= dgvDetails.Rows[i].Cells["clmBarcode"].Value!=null? dgvDetails.Rows[i].Cells["clmBarcode"].Value.ToString():"";
                        myBarCodeRegInfo.ourItemId = Convert.ToInt64(dgvDetails.Rows[i].Cells["clmItemCode"].Value);
                        myBarCodeRegInfo.ourCompanyId = dgvDetails.Rows[i].Cells["clmCompany"].Value != null ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmCompany"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourCategoryId = dgvDetails.Rows[i].Cells["clmCategory"].Value != null ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmCategory"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourModelId = dgvDetails.Rows[i].Cells["clmModel"].Value != null ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmModel"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourBrandId = dgvDetails.Rows[i].Cells["clmBrand"].Value != null ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmBrand"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourColourId = dgvDetails.Rows[i].Cells["clmColour"].Value != null ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmColour"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourSizeId = dgvDetails.Rows[i].Cells["clmSize"].Value != null ? Convert.ToInt64(dgvDetails.Rows[i].Cells["clmSize"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourBatch = dgvDetails.Rows[i].Cells["clmBatch"].Value != null ? dgvDetails.Rows[i].Cells["clmBatch"].Value.ToString() : "";
                        if (dgvDetails.Rows[i].Cells["clmExpDate"].Value != null)
                            myBarCodeRegInfo.ourExpDate = Convert.ToDateTime(dgvDetails.Rows[i].Cells["clmExpDate"].Value.ToString());
                        else
                            myBarCodeRegInfo.ourExpDate = null;
                        myBarCodeRegInfo.ourAddCost = dgvDetails.Rows[i].Cells["clmAddCost"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmAddCost"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourCost = dgvDetails.Rows[i].Cells["clmCost"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmCost"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourReatilRatePro = dgvDetails.Rows[i].Cells["clmRetailPro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmRetailPro"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourRetailRate = dgvDetails.Rows[i].Cells["clmRetailRate"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmRetailRate"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourMrpPro = dgvDetails.Rows[i].Cells["clmMrpPro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmMrpPro"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourMrp = dgvDetails.Rows[i].Cells["clmMrp"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmMrp"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourSpecialRatePro = dgvDetails.Rows[i].Cells["clmSpecialratePro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmSpecialratePro"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourSpecialRate = dgvDetails.Rows[i].Cells["clmSpRate"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmSpRate"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourWhoeSalePro = dgvDetails.Rows[i].Cells["clmWhPro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmWhPro"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourWholeSale = dgvDetails.Rows[i].Cells["clmWholeSale"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmWholeSale"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourBranchRatePro = dgvDetails.Rows[i].Cells["clmBranchPro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmBranchPro"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourBranchRate = dgvDetails.Rows[i].Cells["clmBranchRate"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmBranchRate"].Value.ToString()) : 0;
                        myBarCodeRegInfo.ourItemBarCode = dgvDetails.Rows[i].Cells["clmItemBarcode"].Value != null ? dgvDetails.Rows[i].Cells["clmItemBarcode"].Value.ToString() : "";
                        myBarCodeRegInfo.ourEntryId = myFormId;
                        myBarCodeRegInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
                        if (myBarCodeRegOpr.InsertBarCodeRegistry(myBarCodeRegInfo, myTran))
                        {
                            if (myBarCodeRegInfo.ourCount > 1)
                            {
                                DataSet dtt = myBarCodeRegOpr.SelectLastInsertedBarCode(myTran);
                                if (dtt.Tables[0].Rows.Count > 0)
                                {
                                    dgvDetails.Rows[i].Cells["clmBarcodeId"].Value = dtt.Tables[0].Rows[0]["bar_code_id"];
                                    dgvDetails.Rows[i].Cells["clmBarcode"].Value = dtt.Tables[0].Rows[0]["bar_code"];
                                    LineFlag = true;
                                }
                                else
                                    LineFlag = false;
                            }
                            else
                                LineFlag = true;
                        }
                        else
                        {
                            LineFlag = false;
                            break;
                        }
                    }
                    else
                        LineFlag = true;
                }
            }
            return LineFlag;
        }
        #endregion InsertBarCodeRegistry
        #region InsertAdjustmentDetails
        public bool InsertAdjustmentDetails(SqlTransaction myTran)
        {
            bool LineFlag = false;
            if (dgvAdjustment.Rows.Count > 0)
            {
                for (int i = 0; i < dgvAdjustment.Rows.Count; i++)
                {
                    if (dgvAdjustment.Rows[i].Cells["clmAccount"].Value != null && Convert.ToInt32(dgvAdjustment.Rows[i].Cells["clmAccount"].Value) > 0)
                    {
                        //    GridViewComboBoxColumn comboBoxColumn = this.dgvAdjustment.Columns["clmParticular"] as GridViewComboBoxColumn;
                        //    object value = this.dgvAdjustment.Rows[i].Cells["clmParticular"].Value;
                        //    string text = (string)comboBoxColumn.GetLookupValue(value);
                        //    myAdjustmentInfo.ourParticular=comboBoxColumn.DisplayMember;
                        myAdjustmentInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
                        myAdjustmentInfo.ourEntryId = myFormId;
                        myAdjustmentInfo.ourAccountId = Convert.ToInt64(dgvAdjustment.Rows[i].Cells["clmAccount"].Value.ToString());
                        myAdjustmentInfo.ourParticular = dgvAdjustment.Rows[i].Cells["clmParticular"].Value.ToString();
                        //myAdjustmentInfo.ourParticular = text;
                        myAdjustmentInfo.ourAddOrMinus = Convert.ToInt16(dgvAdjustment.Rows[i].Cells["clmAddOrMinus"].Value.ToString());
                        myAdjustmentInfo.ourPercentage = Convert.ToInt16(dgvAdjustment.Rows[i].Cells["clmPercentage"].Value.ToString());
                        myAdjustmentInfo.ourAmount = Convert.ToDecimal(dgvAdjustment.Rows[i].Cells["clmAmount"].Value.ToString());
                        if (myAdjustmentOpr.InsertAdjustment(myAdjustmentInfo, myTran))
                            LineFlag = true;
                        else
                        {
                            LineFlag = false;
                            break;
                        }
                    }
                    else
                        LineFlag = true;
                }
            }
            else
                LineFlag = true;
            return LineFlag;
        }
        #endregion InsertAdjustmentDetails
        #region Clear
        public void Clear()
        {
            dtpEntryTime.Checked = false;
            // timerTimeUpdate.Enabled = true;
            dtpEntryTime.Value = DateTime.Now;
            dtpEntryTime.Format = DateTimePickerFormat.Time;
            dtpDueDate.Value = DateTime.Now;
            dtpEntryDate.Value = DateTime.Now;
            txtInvoiceNo.Text = "";
            dtpInvoiceDate.Value = DateTime.Now;
            mccAccount.SelectedIndex = 0;
            txtSupplier.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            txtDescription.Text = "";
            txtTinNo.Text = "";
            txtCstNo.Text = "";
            txtCFormNo.Text = "";
            dtpCFromDate.Value = DateTime.Now;
            ddlNtrOfPurcha.SelectedIndex = 0;
            dtpDeliveryDate.Value = DateTime.Now;
            ddlFormType.SelectedIndex = 0;
            txtGrandTotal.Text = "0.00";
            txtNetAmount.Text = "0.00";
            txtOldBalance.Text="0.00";
            txtAmountPaid.Text = "0.00";
            txtClBalance.Text = "0.00";
            txtBalance.Text = "0.00";
            txtAdjstAddTotal.Text = "0.00";
            txtAdjstMinusTotal.Text = "0.00";
            txtAdjustment.Text = "0.00";
            txtAdjstTotal.Text = "0.00";
            dgvDetails.Rows.Clear();
            dgvAdjustment.Rows.Clear();
            dgvUnitRateDetails.Rows.Clear();
        }
        #endregion Clear
        private void radLabel19_Click(object sender, EventArgs e)
        {
            if (txtDiscount.Text != null&& txtDiscount.Text.Trim() !="")
            {
                decimal TotDisc = Convert.ToDecimal(txtTotalDiscount.Text);
                TotDisc += Convert.ToDecimal(txtDiscount.Text);
                txtDiscount.Text = "";
                txtTotalDiscount.Text = TotDisc.ToString();
            }
        }

        private void btnClearDiscount_Click(object sender, EventArgs e)
        {
            txtDiscount.Text = "";
            txtTotalDiscount.Text = "0.00";
        }

        private void radLabel32_Click(object sender, EventArgs e)
        {
            if (txtCost.Text != null && txtCost.Text.Trim() != "")
            {
                decimal TotDisc = Convert.ToDecimal(txtTotalCost.Text);
                TotDisc += Convert.ToDecimal(txtCost.Text);
                txtCost.Text = "";
                txtTotalCost.Text = TotDisc.ToString();
            }
        }

        private void btnClearCost_Click(object sender, EventArgs e)
        {
            txtCost.Text = "";
            txtTotalCost.Text = "0.00";
        }
        #region RollBack
        public void RollBack(SqlTransaction myTran)
        {
            myTran.Rollback();
            myTran.Dispose();
            SqlCon._sqlCon.Close();
            RadMessageBox.Show("Insertion Failed", "True Account Pro", MessageBoxButtons.OK, RadMessageIcon.Info);
        }
        #endregion RollBack
        #region DeleteCashLedger
        public bool DeleteCashLedger(SqlTransaction myTran)
        {
            bool LineFlag = false;
            myCashLedgerInfo.ourEntryIdentity = myFormId;
            myCashLedgerInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
            if (myCashLedgerOpr.DeleteCashLedger(myCashLedgerInfo, myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
        #endregion DeleteCashLedger
        #region DeleteAdjustment
        public bool DeleteAdjustment(SqlTransaction myTran)
        {
            bool LineFlag = false;
            if (dgvAdjustment.Rows.Count > 0)
            {
                if (dgvAdjustment.Rows[0].Cells["clmAccount"].Value != null && Convert.ToInt32(dgvAdjustment.Rows[0].Cells["clmAccount"].Value) > 0)
                {
                    myAdjustmentInfo.ourEntryId = myFormId;
                    myAdjustmentInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
                    if (myAdjustmentOpr.DeleteAdjustment(myAdjustmentInfo, myTran))
                        LineFlag = true;
                    else
                        LineFlag = false;
                }
                else
                    LineFlag = true;
            }
            else
                LineFlag = true;
            return LineFlag;
        }
        #endregion DeleteAdjustment
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            frmSundryCreditor frm = new frmSundryCreditor("debitor");
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        #region DeleteStockLedger
        public bool DeleteStockLedger(SqlTransaction myTran)
        {
            bool LineFlag = false;
            myStockInfo.ourEntryId = myFormId;
            myStockInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
            if (myStockOpr.DeleteStockLedger(myStockInfo, myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
        #endregion DeleteStockLedger
        #region DeletePurchaseDetails
        public bool DeletePurchaseDetails(SqlTransaction myTran)
        {
            bool LineFlag = false;
            myPurchaseInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
            if (mypurchaseOpr.DeletePurchaseDetails(myPurchaseInfo,myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
        #endregion DeletePurchaseDetails
        #region UpdateBarCodeItem
        public bool UpdateBarCodeItem(SqlTransaction myTran)
        {
            bool LineFlage = false;
            for (int i = 1; i < dgvDetails.Rows.Count; i++)
            {
                if (dgvDetails.Rows[i].Cells["clmBarcodeId"].Value != null)
                {
                    myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(dgvDetails.Rows[i].Cells["clmBarcodeId"].Value.ToString());
                    DataSet ds = new DataSet();
                    myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(dgvDetails.Rows[i].Cells["clmBarcodeId"].Value.ToString());
                    ds = myBarCodeRegOpr.CheckBarCodeInSL(myBarCodeRegInfo, myTran);
                    Count = Convert.ToInt64(ds.Tables[0].Rows[0]["Count"]);
                    if (Count > 1)
                    {
                        DialogResult Result = RadMessageBox.Show("This BarCode Already In Use.Do You Want To Generate New BarCode", "TrueAccountPro", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                        if (Result == DialogResult.Yes)
                        {
                            if (InsertBarCodeRegistry(myTran))
                                LineFlage = true;
                            else
                                LineFlage = false;
                        }
                    }
                    else
                    {
                        if (InsertBarCodeRegistry(myTran))
                            LineFlage = true;
                        else
                            LineFlage = false;
                    }
                }
            }
            return LineFlage;
        }
        #endregion UpdateBarCodeItem
        #region RollBack1
        public void RollBack1(SqlTransaction myTran)
        {
            myTran.Rollback();
            myTran.Dispose();
            SqlCon._sqlCon.Close();
            RadMessageBox.Show("Updation Failed", "True Account Pro", MessageBoxButtons.OK, RadMessageIcon.Info);
        }
        #endregion RollBack1
        private void txtAmountPaid_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAmountPaid.Text))
            {
                txtAmountPaid.SelectionStart = 0;
                txtAmountPaid.SelectionLength = txtAmountPaid.Text.Length;
                txtAmountPaid.SelectAll();
            }
            //txtAmountPaid.Clear();
        }
        #region PrintBarCode Updation
        private void rtsPrintBarCode_ValueChanged(object sender, EventArgs e)
        {
            bool Check = rtsPrintBarCode.Value;
            myGenaralFunctions.IsPrintBarCodeUpdate(Check);
        }
        #endregion PrintBarCode Updation
        #region RollBack2
        public void RollBack2(SqlTransaction myTran)
        {
            myTran.Rollback();
            myTran.Dispose();
            SqlCon._sqlCon.Close();
            RadMessageBox.Show("Deletion Failed", "True Account Pro", MessageBoxButtons.OK, RadMessageIcon.Info);
        }
        #endregion RollBack2
        #region DeleteBarCodeItem
        public bool DeleteBarCodeItem(SqlTransaction myTran)
        {
            bool LineFlag = false;
            myBarCodeRegInfo.ourEntryId = myFormId;
            myBarCodeRegInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
            if (myBarCodeRegOpr.DeleteBarcodeItem(myBarCodeRegInfo, myTran))
                LineFlag = true;
            else
                LineFlag = false;
            return LineFlag;
        }
        #endregion DeleteBarCodeItem
        #region DeletePurchaseMaster
        public bool DeletePurchaseMaster(SqlTransaction myTran)
        {
            myPurchaseInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
            if (mypurchaseOpr.DeletePurchaseMaster(myPurchaseInfo, myTran))
                return true;
            else
                return false;
        }
        #endregion DeletePurchaseMaster
        #region DeleteUnitRateDetails
        public bool DeleteUnitRateDetails(SqlTransaction myTran)
        {
            bool LineFlag = false;
            if (dgvUnitRateDetails.Rows.Count > 0)
            {
                myBarCodeRegInfo.ourEntryId = myFormId;
                myBarCodeRegInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
                if (myBarCodeRegOpr.DeleteUnitRateDetails(myBarCodeRegInfo, myTran))
                    LineFlag = true;
                else
                    LineFlag = false;
            }
            else
                LineFlag = true;
            return LineFlag;
        }
        #endregion DeleteUnitRateDetails
        #region SelectUnitRateDetails
        public void SelectUnitRateDetails()
        {
            DataSet ds = new DataSet();
            myBarCodeRegInfo.ourEntryId = myFormId;
            myBarCodeRegInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
            ds=myBarCodeRegOpr.SelectUnitRateDetails(myBarCodeRegInfo);
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                dgvUnitRateDetails.Rows.AddNew();
                dgvUnitRateDetails.Rows[i].Cells["clmRowId"].Value = ds.Tables[0].Rows[i]["row_id"];
                dgvUnitRateDetails.Rows[i].Cells["clmBarcodeId"].Value = ds.Tables[0].Rows[i]["bar_code_id"];
                dgvUnitRateDetails.Rows[i].Cells["clmUnitId"].Value = ds.Tables[0].Rows[i]["unit_id"].ToString();
                dgvUnitRateDetails.Rows[i].Cells["clmCost"].Value = ds.Tables[0].Rows[i]["cost"].ToString();
                dgvUnitRateDetails.Rows[i].Cells["clmRetailPro"].Value = ds.Tables[0].Rows[i]["reatil_rate_pro"].ToString();
                dgvUnitRateDetails.Rows[i].Cells["clmRetailRate"].Value = ds.Tables[0].Rows[i]["retail_rate"].ToString();
                dgvUnitRateDetails.Rows[i].Cells["clmMrpPro"].Value = ds.Tables[0].Rows[i]["mrp_pro"].ToString();
                dgvUnitRateDetails.Rows[i].Cells["clmMrp"].Value = ds.Tables[0].Rows[i]["mrp"].ToString();
                dgvUnitRateDetails.Rows[i].Cells["clmSpecialratePro"].Value = ds.Tables[0].Rows[i]["special_rate_pro"].ToString();
                dgvUnitRateDetails.Rows[i].Cells["clmSpRate"].Value = ds.Tables[0].Rows[i]["special_rate"].ToString();
                dgvUnitRateDetails.Rows[i].Cells["clmWhPro"].Value = ds.Tables[0].Rows[i]["whoe_sale_pro"].ToString();
                dgvUnitRateDetails.Rows[i].Cells["clmWholeSale"].Value = ds.Tables[0].Rows[i]["whole_sale"].ToString();
                dgvUnitRateDetails.Rows[i].Cells["clmBranchPro"].Value = ds.Tables[0].Rows[i]["branch_rate_pro"].ToString();
                dgvUnitRateDetails.Rows[i].Cells["clmBranchRate"].Value = ds.Tables[0].Rows[i]["branch_rate"].ToString();
            }
        }
        #endregion SelectUnitRateDetails
        #region SelectBarCodeUnitDetails
        public DataSet SelectBarCodeUnitDetails(int RowIndex)
        {
            DataSet ds = new DataSet();
            myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(dgvDetails.Rows[RowIndex].Cells["clmBarcodeId"].Value);
            ds =myBarCodeRegOpr.SelectBarCodeUnitDetails(myBarCodeRegInfo);
            return ds;
        }
        #endregion SelectBarCodeUnitDetails
        #region Binding Particulars
        public void BindingParticulars()
        {
            DataSet modelDts = myAdjustmentOpr.BindingParticulars();
            BindingSource modelBS = new BindingSource();
            modelBS.DataSource = modelDts.Tables[0];
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmParticular"]).ValueMember = "particular";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmParticular"]).DisplayMember = "particular";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmParticular"]).DataSource = modelBS;
        }
        #endregion Binding Particulars
    }
}