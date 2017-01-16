
using BAL;
using BEL;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace TrueAccountPro
{
    public partial class frmOpeningStock : Telerik.WinControls.UI.RadForm
    {
        ledgerNameOpr myLedgerNameOpr = new ledgerNameOpr();
        ledgerNameInfo myLedgerNameInfo = new ledgerNameInfo();

        productMasterInfo myProductMasterInfo = new productMasterInfo();
        productMasterOpr myProductMasterOpr = new productMasterOpr();

        stockInfo myStockInfo = new stockInfo();
        stockOpr myStockOpr = new stockOpr();

        mastersInfo myMasterInfo = new mastersInfo();
        mastersOpr myMastersOpr = new mastersOpr();

        opStockInfo myOpStockInfo = new opStockInfo();
        opStockOpr myOpStockOpr = new opStockOpr();
        genaralFunctions myGenaralFunctions = new genaralFunctions();

        bool loadcmplt = false;




        int myPrdctDcmlPonts=0;
        int myPrdctQty2=0;
        string myBarCodeStr;
     
        public frmOpeningStock()
        {
            InitializeComponent();
            sedEntryNo.Maximum = decimal.MaxValue;
        }

        private void gridSettings()
        {
            dtpEntryDate.Value = DateTime.Now;
            tpkEntryTime .Value = DateTime.Now;
            txtDescription.Text = "";

            dgvDetails.Rows.Clear();

            for (int i = 0; i < 16; i++)
            {
                dgvDetails.Rows.AddNew();
            }


            dgvDetails.Rows[0].IsPinned = true;
            dgvDetails.Rows[0].PinPosition = PinnedRowPosition.Bottom;

            for (int j = 0; j < dgvDetails.ColumnCount; j++)
            {
                dgvDetails.Rows[0].Cells[j].ReadOnly = true;

            }
        }

        private void frmOpeningStock_Load(object sender, EventArgs e)
        {
           dgvDetails.Columns["clmAddDescrip"].Expression = "Value + 2";

            
            sedEntryNo.Value = myGenaralFunctions.getMaxValueOfFiledInTable("entry_no", "tblOpStockMaster");
            gridSettings();
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            unLockControlls();
            bindProductDetailsToGrid();
            bindSundryCreditorsDetailsToGrid();
            bindProductCompanytoGrid();
            bindProductModeltoGrid();
            bindProductBrandtoGrid();
            bindProductCategorytoGrid();
            bindProductColourtoGrid();
            bindProductSizetoGrid();
            bindGodownDetailsToGrid();

        }

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
        private void bindSundryCreditorsDetailsToGrid()
        {
            myLedgerNameInfo.GroupIdInt = 39;
            DataSet mySupplierDetailsDts = myLedgerNameOpr.selectLedgerNameAndIdByGroupId(myLedgerNameInfo);
            BindingSource supplierBS = new BindingSource();

            supplierBS.DataSource = mySupplierDetailsDts.Tables[0];

         
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmSupplier"]).ValueMember = "ledger_id";
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmSupplier"]).DisplayMember = "ledger_name";
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmSupplier"]).DataSource = supplierBS;
            ((RadGridView)((RadMultiColumnComboBoxElement)this.dgvDetails.ActiveEditor).EditorControl).Columns["ledger_name"].Width = 200;
           


               }

        
        private void bindProductCompanytoGrid()
        {

            myMasterInfo.Query = "SELECT pro_companyId as id, pro_company_name as name, pro_company_description as description from tblProductCompany";

            DataSet companyDts = myMastersOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource companyBS = new BindingSource();
            companyBS.DataSource = companyDts.Tables[0];


            ((GridViewComboBoxColumn)dgvDetails.Columns["clmCompany"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmCompany"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmCompany"]).DataSource = companyBS;

        }
        private void bindProductModeltoGrid()
        {

            myMasterInfo.Query = "SELECT model_Id as id, model_name as name, model_description as description from tblModel";

            DataSet modelDts = myMastersOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource modelBS = new BindingSource();
            modelBS.DataSource = modelDts.Tables[0];


            ((GridViewComboBoxColumn)dgvDetails.Columns["clmModel"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmModel"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmModel"]).DataSource = modelBS;

        }
        private void bindProductCategorytoGrid()
        {
            myMasterInfo.Query = "SELECT product_category_id as id, product_category_name as name, product_category_description as description from tblProductCategory";

            DataSet modelDts = myMastersOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];


            ((GridViewComboBoxColumn)dgvDetails.Columns["clmCategory"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmCategory"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmCategory"]).DataSource = brandBs;
        }

        private void bindProductBrandtoGrid()
        {
            myMasterInfo.Query = " SELECT brand_Id as id, brand_name as name, brand_description as description from tblBrand";

            DataSet modelDts = myMastersOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];


            ((GridViewComboBoxColumn)dgvDetails.Columns["clmBrand"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmBrand"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmBrand"]).DataSource = brandBs;
        }

        private void bindProductColourtoGrid()
        {
            myMasterInfo.Query = " SELECT colour_id as id, colour_name as name, colour_description as description from tblColour";

            DataSet modelDts = myMastersOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];


            ((GridViewComboBoxColumn)dgvDetails.Columns["clmColour"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmColour"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmColour"]).DataSource = brandBs;
        }
        private void bindProductSizetoGrid()
        {
            myMasterInfo.Query = " SELECT size_id as id, size_name as name, size_description as description from tblSize";

            DataSet modelDts = myMastersOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmSize"]).ValueMember = "id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmSize"]).DisplayMember = "name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmSize"]).DataSource = brandBs;
        }
        private void bindGodownDetailsToGrid()
        {
            myMasterInfo.Query = "select godown_id,godown_code,godown_name from tblGodown where active=1";

            DataSet modelDts = myMastersOpr.selectAllMasterDetails(myMasterInfo);
            BindingSource brandBs = new BindingSource();
            brandBs.DataSource = modelDts.Tables[0];
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmGodown"]).ValueMember = "godown_id";
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmGodown"]).DisplayMember = "godown_name";
            ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmGodown"]).DataSource = brandBs;
        }
        private void dgvDetails_Click(object sender, EventArgs e)
        {

        }

        private void dgvDetails_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
        {
            //if (this.dgvDetails.CurrentColumn is GridViewMultiComboBoxColumn)
            //{
            //if (e.Column == dgvDetails.Columns["clmSupplier"])
            //{
            //     bindSundryCreditorsDetailsToGrid();
            //    if (loadcmplt)
            //    {
                  
            //        RadMultiColumnComboBoxElement serchengineElement = (RadMultiColumnComboBoxElement)this.dgvDetails.ActiveEditor;

            //        //     serchengineElement.EditorControl.Columns["ledger_name"].MinWidth = 190;
            //        serchengineElement.EditorControl.Columns["ledger_name"].HeaderText = "Supplier Name";

            //        //serchengineElement.DropDownMinSize = new Size(550, 300);
            //        //serchengineElement.DropDownMaxSize = new Size(550, 300);
            //        serchengineElement.EditorControl.MasterTemplate.AutoGenerateColumns = false;
            //        serchengineElement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            //        serchengineElement.AutoSizeDropDownToBestFit = false;
            //        serchengineElement.DropDownAnimationEnabled = false;
            //        serchengineElement.EditorControl.Columns.Add(new GridViewTextBoxColumn("ledger_name"));
            //        FilterDescriptor filtercustomername = new FilterDescriptor("ledger_name", FilterOperator.Contains, string.Empty);
            //        serchengineElement.EditorControl.FilterDescriptors.Add(filtercustomername);

            //    }
            //}
        }
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //switch (dgv.CurrentCell.ColumnIndex)
            //{
            //    case 0: //slno
            //        {
            //            int indexv = dgv.CurrentCell.RowIndex;
            //            bindSundryCreditorsDetailsToGrid(indexv+1);





            //            break;
            //        }
            //}
        }
        private void findColumnTotal()
        {
            int count = dgvDetails.Rows.Count;
            dgvDetails.Rows[0].Cells["clmQty"].Value = 0;
            dgvDetails.Rows[0].Cells["clmFreeQty"].Value = 0;
            dgvDetails.Rows[0].Cells["clmQty2"].Value = 0;
            dgvDetails.Rows[0].Cells["clmTotalQty"].Value = 0;
            dgvDetails.Rows[0].Cells["clmStickerQty"].Value = 0;
            dgvDetails.Rows[0].Cells["clmDiscount"].Value = 0;
            dgvDetails.Rows[0].Cells["clmExiceDuty"].Value = 0;
            dgvDetails.Rows[0].Cells["clmGstAmount"].Value = 0;
            dgvDetails.Rows[0].Cells["clmVatAmount"].Value = 0;
            dgvDetails.Rows[0].Cells["clmCessAmount"].Value = 0;
            dgvDetails.Rows[0].Cells["clmAddCost"].Value = 0;
            dgvDetails.Rows[0].Cells["clmTotaAmount"].Value = 0;
            dgvDetails.Rows[0].Cells["clmGrossValue"].Value = 0;
            dgvDetails.Rows[0].Cells["clmNetValue"].Value = 0;
            dgvDetails.Rows[0].Cells["clmGrandTotal"].Value = 0;

            for (int i = 1; i < count; i++)
            {

                if (dgvDetails.Rows[i].Cells["clmQty"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmQty"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmQty"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmQty"].Value.ToString());
                }

                if (dgvDetails.Rows[i].Cells["clmFreeQty"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmFreeQty"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmFreeQty"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmFreeQty"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmQty2"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmQty2"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmQty2"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmQty2"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmTotalQty"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmTotalQty"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmTotalQty"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmTotalQty"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmStickerQty"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmStickerQty"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmStickerQty"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmStickerQty"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmDiscount"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmDiscount"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmDiscount"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmDiscount"].Value.ToString());
                }

                if (dgvDetails.Rows[i].Cells["clmExiceDuty"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmExiceDuty"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmExiceDuty"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmExiceDuty"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmGstAmount"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmGstAmount"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmGstAmount"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmGstAmount"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmVatAmount"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmVatAmount"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmVatAmount"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmVatAmount"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmCessAmount"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmCessAmount"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmCessAmount"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmCessAmount"].Value.ToString());
                }

                if (dgvDetails.Rows[i].Cells["clmAddCost"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmAddCost"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmAddCost"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmAddCost"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmTotaAmount"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmTotaAmount"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmTotaAmount"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmTotaAmount"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmGrossValue"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmGrossValue"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmGrossValue"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmGrossValue"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmNetValue"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmNetValue"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmNetValue"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmNetValue"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmGrandTotal"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmGrandTotal"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmGrandTotal"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmGrandTotal"].Value.ToString());
                }

            }
        }
        private void calculations(int rowindex)
        {
            decimal qty = 0, freeQty = 0, totalQty = 0, unitRate = 0, totalAmount = 0, discPec = 0, discount = 0, disc2 = 0, grossValue = 0, exiceDutyPer = 0, exiceDuty = 0, gstPerc = 0, gst = 0, netValue = 0, vatPerc = 0, vatAmount = 0, cessPerc = 0, cessAmount = 0;
            decimal grandTotal = 0, addCost = 0, costPerPs = 0, retailPro = 0, retailRate = 0, mrpPro = 0, mrp = 0, specialratePro = 0, spRate = 0, whPro = 0, wholeSale = 0, branchPro = 0, branchRate = 0;
            if (rowindex > -1)
            {


                if (dgvDetails.Rows[rowindex].Cells["clmQty"].Value != null)
                {
                    qty = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmQty"].Value.ToString().Trim());
                    dgvDetails.Rows[rowindex].Cells["clmQty"].Value = myGenaralFunctions.FormatDecimalPlace(qty.ToString(), myPrdctDcmlPonts);


                }
                if (dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value != null)
                {

                    freeQty = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value = myGenaralFunctions.FormatDecimalPlace(freeQty.ToString().Trim(), myPrdctDcmlPonts);


                }
                if (dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value != null)
                {
                    unitRate = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value = myGenaralFunctions.FormatDecimalPlace(unitRate.ToString(), 2);

                }

                if (dgvDetails.Rows[rowindex].Cells["clmTotaAmount"].Value != null)
                {
                    totalAmount = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmTotaAmount"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmTotaAmount"].Value = myGenaralFunctions.FormatDecimalPlace(totalAmount.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmDiscPerc"].Value != null)
                {
                    discPec = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmDiscPerc"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmDiscPerc"].Value = myGenaralFunctions.FormatDecimalPlace(discPec.ToString().Trim(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmDiscount"].Value != null)
                {
                    discount = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmDiscount"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmDiscount"].Value = myGenaralFunctions.FormatDecimalPlace(discount.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmDisc2"].Value != null)
                {
                    disc2 = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmDisc2"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmDisc2"].Value = myGenaralFunctions.FormatDecimalPlace(disc2.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmExiceDutyPerc"].Value != null)
                {
                    exiceDutyPer = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmExiceDutyPerc"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmExiceDutyPerc"].Value = myGenaralFunctions.FormatDecimalPlace(exiceDutyPer.ToString().Trim(), 2);

                }

                if (dgvDetails.Rows[rowindex].Cells["clmGstPerc"].Value != null)
                {
                    gstPerc = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmGstPerc"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmGstPerc"].Value = myGenaralFunctions.FormatDecimalPlace(gstPerc.ToString(), 2);

                }

                if (dgvDetails.Rows[rowindex].Cells["clmVatPerc"].Value != null)
                {
                    vatPerc = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmVatPerc"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmVatPerc"].Value = myGenaralFunctions.FormatDecimalPlace(vatPerc.ToString(), 2);

                }

                if (dgvDetails.Rows[rowindex].Cells["clmCessPerc"].Value != null)
                {
                    cessPerc = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmCessPerc"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmCessPerc"].Value = myGenaralFunctions.FormatDecimalPlace(cessPerc.ToString(), 2);

                }

                if (dgvDetails.Rows[rowindex].Cells["clmAddCost"].Value != null)
                {
                    addCost = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmAddCost"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmAddCost"].Value = myGenaralFunctions.FormatDecimalPlace(addCost.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmCost"].Value != null)
                {
                    costPerPs = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmCost"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmCost"].Value = myGenaralFunctions.FormatDecimalPlace(costPerPs.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmRetailPro"].Value != null)
                {
                    retailPro = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmRetailPro"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmRetailPro"].Value = myGenaralFunctions.FormatDecimalPlace(retailPro.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmRetailRate"].Value != null)
                {
                    retailRate = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmRetailRate"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmRetailRate"].Value = myGenaralFunctions.FormatDecimalPlace(retailRate.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmMrpPro"].Value != null)
                {
                    mrpPro = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmMrpPro"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmMrpPro"].Value = myGenaralFunctions.FormatDecimalPlace(mrpPro.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmMrp"].Value != null)
                {
                    mrp = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmMrp"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmMrp"].Value = myGenaralFunctions.FormatDecimalPlace(mrp.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmSpecialratePro"].Value != null)
                {
                    specialratePro = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmSpecialratePro"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmSpecialratePro"].Value = myGenaralFunctions.FormatDecimalPlace(specialratePro.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmSpRate"].Value != null)
                {
                    spRate = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmSpRate"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmSpRate"].Value = myGenaralFunctions.FormatDecimalPlace(spRate.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmWhPro"].Value != null)
                {
                    whPro = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmWhPro"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmWhPro"].Value = myGenaralFunctions.FormatDecimalPlace(whPro.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmWholeSale"].Value != null)
                {
                    wholeSale = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmWholeSale"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmWholeSale"].Value = myGenaralFunctions.FormatDecimalPlace(wholeSale.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmBranchPro"].Value != null)
                {
                    branchPro = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmBranchPro"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmBranchPro"].Value = myGenaralFunctions.FormatDecimalPlace(branchPro.ToString(), 2);

                }
                if (dgvDetails.Rows[rowindex].Cells["clmBranchRate"].Value != null)
                {
                    branchRate = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmBranchRate"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmBranchRate"].Value = myGenaralFunctions.FormatDecimalPlace(branchRate.ToString(), 2);

                }



                totalQty = qty + freeQty;
                if (totalAmount == 0)
                {

                    totalAmount = unitRate * qty;

                }
                else if (qty > 0)

                {
                    unitRate = totalAmount / qty;
                }

                if (discPec > 0)
                {
                    discount = totalAmount * discPec / 100;
                }
                else if (totalAmount > 0)
                {
                    discPec = (discount * 100) / totalAmount;
                }
                grossValue = totalAmount - discount - disc2;
                if (exiceDutyPer > 0)
                {
                    exiceDuty = grossValue * exiceDutyPer / 100;
                }

                if (gstPerc > 0)
                {
                    gst = (grossValue + exiceDuty) * gstPerc / 100;
                }

                netValue = grossValue + exiceDuty + gst;
                if (vatPerc > 0)
                {
                    vatAmount = netValue * vatPerc / 100;
                }


                if (cessPerc > 0)
                {
                    cessAmount = vatAmount * cessPerc / 100;
                }




                grandTotal = netValue + vatAmount + cessAmount;

                if (qty > 0)
                {
                    costPerPs = ((addCost + grandTotal) / qty);
                }


                retailRate = (costPerPs * retailPro / 100) + costPerPs;

                if (costPerPs > 0 && retailRate > 0)
                {
                    retailPro = (retailRate - costPerPs) * 100 / costPerPs;
                }


                mrp = (costPerPs * mrpPro / 100) + costPerPs;


                if (costPerPs > 0 && mrp > 0)
                {
                    mrpPro = (mrp - costPerPs) * 100 / costPerPs;
                }

                spRate = (costPerPs * specialratePro / 100) + costPerPs;

                if (costPerPs > 0 && spRate > 0)
                {
                    specialratePro = (spRate - costPerPs) * 100 / costPerPs;
                }

                wholeSale = (costPerPs * whPro / 100) + costPerPs;

                if (costPerPs > 0 && whPro > 0)
                {
                    whPro = (wholeSale - costPerPs) * 100 / costPerPs;
                }

                branchRate = (costPerPs * branchPro / 100) + costPerPs;

                if (costPerPs > 0 && branchRate > 0)
                {
                    branchPro = (branchRate - costPerPs) * 100 / costPerPs;
                }


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
        private void bindProductDetailsToRow(int rowIndex)
        {
            DataSet productDetails = myProductMasterOpr.selectAllProductMasterData(myProductMasterInfo);

            if (productDetails.Tables[0].Rows.Count > 0)
            {


                dgvDetails.Rows[rowIndex].Cells["clmCompany"].Value = Convert.ToInt64(productDetails.Tables[0].Rows[0]["pro_company_id"].ToString());
                dgvDetails.Rows[rowIndex].Cells["clmCategory"].Value = Convert.ToInt64(productDetails.Tables[0].Rows[0]["pro_category_id"].ToString());
                dgvDetails.Rows[rowIndex].Cells["clmModel"].Value = Convert.ToInt64(productDetails.Tables[0].Rows[0]["model_id"].ToString());
                dgvDetails.Rows[rowIndex].Cells["clmBrand"].Value = Convert.ToInt64(productDetails.Tables[0].Rows[0]["brand_id"].ToString());
                dgvDetails.Rows[rowIndex].Cells["clmColour"].Value = -1;
                dgvDetails.Rows[rowIndex].Cells["clmSize"].Value = -1;
                dgvDetails.Rows[rowIndex].Cells["clmUnitRate"].Value = productDetails.Tables[0].Rows[0]["purchase_rate"].ToString() != "" ? productDetails.Tables[0].Rows[0]["purchase_rate"].ToString() : "0";
                dgvDetails.Rows[rowIndex].Cells["clmVatPerc"].Value = productDetails.Tables[0].Rows[0]["rate_of_tax_purchase"].ToString() != "" ? productDetails.Tables[0].Rows[0]["rate_of_tax_purchase"].ToString() : "0";
                dgvDetails.Rows[rowIndex].Cells["clmCessPerc"].Value = productDetails.Tables[0].Rows[0]["rate_of_cess"].ToString() != "0" ? productDetails.Tables[0].Rows[0]["rate_of_cess"].ToString() : "0";
                dgvDetails.Rows[rowIndex].Cells["clmExiceDutyPerc"].Value = productDetails.Tables[0].Rows[0]["exice_duty"].ToString() != "" ? productDetails.Tables[0].Rows[0]["exice_duty"].ToString() : "0";
                dgvDetails.Rows[rowIndex].Cells["clmGstPerc"].Value = productDetails.Tables[0].Rows[0]["gst"].ToString() != "" ? productDetails.Tables[0].Rows[0]["gst"].ToString() : "0";


                myPrdctDcmlPonts = Convert.ToInt32(productDetails.Tables[0].Rows[0]["unit_decimal"].ToString());
                myPrdctQty2 = productDetails.Tables[0].Rows[0]["qty2"].ToString() == "0" || productDetails.Tables[0].Rows[0]["qty2"].ToString() == "" ? 0 : Convert.ToInt32(productDetails.Tables[0].Rows[0]["qty2"].ToString());
                calculations(rowIndex);
                findColumnTotal();

            }
        }
        private void dgvDetails_CellEndEdit(object sender, GridViewCellEventArgs e)
        {



            int rowIndex = Convert.ToInt32(e.RowIndex);


            switch (dgvDetails.CurrentCell.ColumnInfo.Name.ToString())
            {
                case "clmItemCode":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value = dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value;
                            myProductMasterInfo.ProductId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value.ToString());
                            bindProductDetailsToRow(rowIndex);

                        }

                        break;
                    }
                case "clmItemName":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value = dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value;
                            myProductMasterInfo.ProductId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value.ToString());
                            bindProductDetailsToRow(rowIndex);

                        }
                        break;
                    }
                case "clmSupplier":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmSupplier"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmSupplier"].Value = dgvDetails.Rows[rowIndex].Cells["clmSupplier"].Value;
             
                        }
                        break;
                    }

                case "clmQty":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmQty2"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmQty2"].Value = myGenaralFunctions.FormatDecimalPlace((Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmQty"].Value.ToString()) * myPrdctQty2).ToString(), myPrdctDcmlPonts);
                        }
                        calculations(rowIndex);
                        findColumnTotal();
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
                        dgvDetails.Rows[rowIndex].Cells["clmRetailPro"].Value = 0;
                        calculations(rowIndex);
                        

                        break;

                    }

                case "clmMrpPro":
                    {
                      
                        calculations(rowIndex);
                   

                        break;

                    }
                case "clmMrp":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmMrpPro"].Value = 0;
                        calculations(rowIndex);
                       
                        break;

                    }

                case "clmSpecialratePro":
                    {
                       
                        calculations(rowIndex);
                  
                        break;

                    }

                case "clmSpRate":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmSpecialratePro"].Value = 0;
                        calculations(rowIndex);
                      
                        break;

                    }

                case "clmWhPro":
                    {
                       
                        calculations(rowIndex);
                  
                        break;

                    }

                case "clmWholeSale":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmWhPro"].Value = 0;
                        calculations(rowIndex);
                   
                        break;

                    }
                case "clmBranchPro":
                    {
                      
                        calculations(rowIndex);
                

                        break;

                    }
                case "clmBranchRate":
                    {
                        dgvDetails.Rows[rowIndex].Cells["clmBranchPro"].Value = 0;
                        calculations(rowIndex);
                        findColumnTotal();

                        break;

                    }

                case "clmGodown":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmGodown"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmGodown"].Value = dgvDetails.Rows[rowIndex].Cells["clmGodown"].Value;
                        
                        }
                        break;
                    }

            }
        }

        private void dgvDetails_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.CellElement is GridRowHeaderCellElement&&e.RowIndex >0 )
            {
                e.CellElement.Text =(Convert.ToInt32 (e.CellElement.RowIndex)).ToString();
           }


        }

         

    private void dgvDetails_CellFormatting(object sender, CellFormattingEventArgs e)
        {
           

        }

        private void dgvDetails_UserAddedRow(object sender, GridViewRowEventArgs e)
        {

            //int rowindex = dgvDetails.Rows.Count - 2;
            //findColumnTotal();
            //dgvDetails.Rows[rowindex].Cells["clmQty"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmQty2"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmTotalQty"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmStickerQty"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmTotaAmount"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmDiscount"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmDiscPerc"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmGrossValue"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmExiceDutyPerc"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmExiceDuty"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmGstPerc"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmGstAmount"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmNetValue"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmVatPerc"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmVatAmount"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmGrandTotal"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmAddCost"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmCost"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmRetailPro"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmRetailRate"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmMrpPro"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmMrp"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmSpecialratePro"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmSpRate"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmWhPro"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmWholeSale"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmBranchPro"].Value = "";
            //dgvDetails.Rows[rowindex].Cells["clmBranchRate"].Value = "";


           
        }

        private void dgvDetails_UserAddingRow(object sender, GridViewRowCancelEventArgs e)
        {
           
        }

        private void dgvDetails_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            if (this.dgvDetails.CurrentColumn is GridViewComboBoxColumn)
            {

                RadDropDownListEditor editor = e.ActiveEditor as RadDropDownListEditor;
                if (editor != null)
                {
                    RadDropDownListEditorElement el = editor.EditorElement as RadDropDownListEditorElement;
                    el.AutoCompleteMode = AutoCompleteMode.Suggest;
                    el.AutoCompleteSuggest.SuggestMode = SuggestMode.Contains;
                }
            }
            else if (this.dgvDetails.CurrentColumn is GridViewMultiComboBoxColumn)
            {
                switch (dgvDetails.CurrentCell.ColumnInfo.Name.ToString())
                {
                    case "clmSupplier":
                        {
                            RadMultiColumnComboBoxElement editColumn = (RadMultiColumnComboBoxElement)e.ActiveEditor;

                            editColumn.EditorControl.Columns["ledger_name"].MinWidth = 190;
                            editColumn.EditorControl.Columns["ledger_name"].HeaderText = "Supplier Name";

                            editColumn.EditorControl.Columns["ledger_code"].MinWidth = 100;
                            editColumn.EditorControl.Columns["alternate_name"].MinWidth = 190;
                            editColumn.EditorControl.Columns["ledger_code"].HeaderText = "Supplier Code";
                            editColumn.EditorControl.Columns["alternate_name"].HeaderText = "Alternate Name";
                            editColumn.EditorControl.Columns["ledger_id"].IsVisible = false;
                            editColumn.EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                            editColumn.EditorControl.ShowRowHeaderColumn = false;
                            editColumn.DropDownMinSize = new Size(500, 100);
                            editColumn.DropDownSizingMode = SizingMode.None;
                            editColumn.DropDownStyle = RadDropDownStyle.DropDown;
                            break;
                        }


                    //        if (e.Column == dgvDetails.Columns["clmSupplier"])
                    //{





                    ////}
                    //else if (e.Column == dgvDetails.Columns["clmItemCode"])
                    //    {
                    case "clmItemCode":
                        {

                            // bindProductDetailsToGrid();
                            RadMultiColumnComboBoxElement editColumn1 = (RadMultiColumnComboBoxElement)e.ActiveEditor;
                            editColumn1.ClearFilter();
                            editColumn1.ClearBehaviors();
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
                            break;
                        }

                    //    editColumn1.EditorControl.MasterTemplate.AutoGenerateColumns = false;
                    //    editColumn1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                    //    editColumn1.AutoSizeDropDownToBestFit = false;
                    //    editColumn1.DropDownAnimationEnabled = false;
                    ////    editColumn1.EditorControl.Columns.Add(new GridViewTextBoxColumn("product_code"));
                    //    FilterDescriptor filtercustomername = new FilterDescriptor("product_code", FilterOperator.Contains, string.Empty);
                    //    editColumn1.EditorControl.FilterDescriptors.Add(filtercustomername);



                    case "clmItemName":
                        {

                            //else if (e.Column == dgvDetails.Columns["clmItemName"])
                            //{
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




                            editColumn.EditorControl.MasterTemplate.AutoGenerateColumns = false;
                            editColumn.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                            editColumn.AutoSizeDropDownToBestFit = false;
                            editColumn.DropDownAnimationEnabled = false;
                            //    editColumn1.EditorControl.Columns.Add(new GridViewTextBoxColumn("product_code"));
                            FilterDescriptor filtercustomername = new FilterDescriptor("product_name", FilterOperator.Contains, string.Empty);
                            editColumn.EditorControl.FilterDescriptors.Add(filtercustomername);

                            break;

                        }
                    //else if (e.Column == dgvDetails.Columns["clmGodown"])
                    //{
                    case "clmGodown":
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


                            break;
                        }
                }
            }
        }
        private void dgvDetails_ValueChanged(object sender, EventArgs e)
        {
           
          
        }

        private void dgvDetails_CellValueChanged(object sender, GridViewCellEventArgs e)
        {

        

        }
        private void setValuesStockLedger(int rowIndex)
        {
            myStockInfo.ourEntryDate = Convert.ToDateTime(dtpEntryDate.Value);
            myStockInfo.ourEntryTime = tpkEntryTime.Value.ToString();
            myStockInfo.ourEntryId = "OP";
            myStockInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
            
        }
        private void setValuesOpStockDetails(int rowIndex)
        {

            myOpStockInfo.EntryNo = Convert.ToInt64(sedEntryNo.Value);
            myOpStockInfo.BarCode = myBarCodeStr;
            myOpStockInfo.ItemId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value);
            myOpStockInfo.CompanyId = dgvDetails.Rows[rowIndex].Cells["clmCompany"].Value != null ? Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmCompany"].Value.ToString()) : 0;
            myOpStockInfo.CategoryId = dgvDetails.Rows[rowIndex].Cells["clmCategory"].Value != null ? Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmCategory"].Value.ToString()) : 0;
            myOpStockInfo.ModelId = dgvDetails.Rows[rowIndex].Cells["clmModel"].Value != null ? Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmModel"].Value.ToString()) : 0;
            myOpStockInfo.BrandId = dgvDetails.Rows[rowIndex].Cells["clmBrand"].Value != null ? Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmBrand"].Value.ToString()) : 0;
            myOpStockInfo.ColourId = dgvDetails.Rows[rowIndex].Cells["clmColour"].Value != null ? Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmColour"].Value.ToString()) : 0;
            myOpStockInfo.SizeId = dgvDetails.Rows[rowIndex].Cells["clmSize"].Value != null ? Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmSize"].Value.ToString()) : 0;
            myOpStockInfo.SupplierId = dgvDetails.Rows[rowIndex].Cells["clmModel"].Value != null ? Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmModel"].Value.ToString()) : 0;
            myOpStockInfo.AddiDescrip = dgvDetails.Rows[rowIndex].Cells["clmAddDescrip"].Value != null ? dgvDetails.Rows[rowIndex].Cells["clmAddDescrip"].Value.ToString() : "";
            myOpStockInfo.Batch = dgvDetails.Rows[rowIndex].Cells["clmBatch"].Value != null ? dgvDetails.Rows[rowIndex].Cells["clmBatch"].Value.ToString() : "";
            if (dgvDetails.Rows[rowIndex].Cells["clmExpDate"].Value != null)
            {
                myOpStockInfo.ExpDate = Convert.ToDateTime(dgvDetails.Rows[rowIndex].Cells["clmExpDate"].Value.ToString());
            }
            else

            {
                myOpStockInfo.ExpDate = null;
            }
            myOpStockInfo.Qty = dgvDetails.Rows[rowIndex].Cells["clmQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmQty"].Value.ToString()) : 0;
            myOpStockInfo.FreeQty = dgvDetails.Rows[rowIndex].Cells["clmFreeQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmFreeQty"].Value.ToString()) : 0;
            myOpStockInfo.Qty2 = dgvDetails.Rows[rowIndex].Cells["clmQty2"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmQty2"].Value.ToString()) : 0;
            myOpStockInfo.TotalQty = dgvDetails.Rows[rowIndex].Cells["clmTotalQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmTotalQty"].Value.ToString()) : 0;
            myOpStockInfo.StickerQty = dgvDetails.Rows[rowIndex].Cells["clmStickerQty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmTotalQty"].Value.ToString()) : 0;
            myOpStockInfo.UnitRate = dgvDetails.Rows[rowIndex].Cells["clmunitRate"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmUnitRate"].Value.ToString()) : 0;
            myOpStockInfo.TotalAmount = dgvDetails.Rows[rowIndex].Cells["clmTotaAmount"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmTotaAmount"].Value.ToString()) : 0;
            myOpStockInfo.DiscPerc = dgvDetails.Rows[rowIndex].Cells["clmDiscPerc"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmDiscPerc"].Value.ToString()) : 0;
            myOpStockInfo.Discount = dgvDetails.Rows[rowIndex].Cells["clmDiscount"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmDiscount"].Value.ToString()) : 0;
            myOpStockInfo.Discount2 = dgvDetails.Rows[rowIndex].Cells["clmDisc2"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmDisc2"].Value.ToString()) : 0;
            myOpStockInfo.GrossValue = dgvDetails.Rows[rowIndex].Cells["clmGrossValue"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmGrossValue"].Value.ToString()) : 0;
            myOpStockInfo.ExiceDutyPerc = dgvDetails.Rows[rowIndex].Cells["clmExiceDutyPerc"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmExiceDutyPerc"].Value.ToString()) : 0;
            myOpStockInfo.ExiceDuty = dgvDetails.Rows[rowIndex].Cells["clmExiceDuty"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmExiceDuty"].Value.ToString()) : 0;
            myOpStockInfo.GstPerc = dgvDetails.Rows[rowIndex].Cells["clmGstPerc"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmGstPerc"].Value.ToString()) : 0;
            myOpStockInfo.GstAmount = dgvDetails.Rows[rowIndex].Cells["clmGstAmount"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmGstAmount"].Value.ToString()) : 0;
            myOpStockInfo.NetValue = dgvDetails.Rows[rowIndex].Cells["clmNetValue"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmNetValue"].Value.ToString()) : 0;
            myOpStockInfo.VatPerc = dgvDetails.Rows[rowIndex].Cells["clmVatPerc"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmVatPerc"].Value.ToString()) : 0;
            myOpStockInfo.VatAmount = dgvDetails.Rows[rowIndex].Cells["clmVatAmount"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmVatAmount"].Value.ToString()) : 0;
            myOpStockInfo.CessPerc = dgvDetails.Rows[rowIndex].Cells["clmCessPerc"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCessPerc"].Value.ToString()) : 0;
            myOpStockInfo.CessAmount = dgvDetails.Rows[rowIndex].Cells["clmCessAmount"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCessAmount"].Value.ToString()) : 0;
            myOpStockInfo.GrandTotal = dgvDetails.Rows[rowIndex].Cells["clmGrandTotal"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmGrandTotal"].Value.ToString()) : 0;
            myOpStockInfo.AddCost = dgvDetails.Rows[rowIndex].Cells["clmAddCost"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmAddCost"].Value.ToString()) : 0;
            myOpStockInfo.Cost = dgvDetails.Rows[rowIndex].Cells["clmCost"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value.ToString()) : 0;
            myOpStockInfo.ReatilRatePro = dgvDetails.Rows[rowIndex].Cells["clmRetailPro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmRetailPro"].Value.ToString()) : 0;
            myOpStockInfo.MrpPro = dgvDetails.Rows[rowIndex].Cells["clmMrpPro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmMrpPro"].Value.ToString()) : 0;
            myOpStockInfo.Mrp = dgvDetails.Rows[rowIndex].Cells["clmMrp"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmMrp"].Value.ToString()) : 0;
            myOpStockInfo.SpecialRatePro = dgvDetails.Rows[rowIndex].Cells["clmSpecialratePro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmSpecialratePro"].Value.ToString()) : 0;
            myOpStockInfo.SpecialRate = dgvDetails.Rows[rowIndex].Cells["clmSpRate"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmSpRate"].Value.ToString()) : 0;
            myOpStockInfo.WhoeSalePro = dgvDetails.Rows[rowIndex].Cells["clmWhPro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmWhPro"].Value.ToString()) : 0;
            myOpStockInfo.WholeSale = dgvDetails.Rows[rowIndex].Cells["clmWholeSale"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmWholeSale"].Value.ToString()) : 0;
            myOpStockInfo.BranchRatePro = dgvDetails.Rows[rowIndex].Cells["clmBranchPro"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmBranchPro"].Value.ToString()) : 0;
            myOpStockInfo.BranchRate = dgvDetails.Rows[rowIndex].Cells["clmBranchRate"].Value != null ? Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmBranchRate"].Value.ToString()) : 0;
            myOpStockInfo.ItemBarCode = dgvDetails.Rows[rowIndex].Cells["clmItemBarcode"].Value != null ? dgvDetails.Rows[rowIndex].Cells["clmItemBarcode"].Value.ToString() : "";
            myOpStockInfo.GodownId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmGodown"].Value) > -1 ? Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmGodown"].Value) : 0;


        }
        private void setValuesOpStockMaster()
        {
            myOpStockInfo.EntryDate = dtpEntryDate.Value;
            myOpStockInfo.EntryTime = tpkEntryTime.Value.ToString();
            myOpStockInfo.UpdateDate = DateTime.Now;
            myOpStockInfo.UpdateTime = DateTime.Now.ToString();
            myOpStockInfo.Description = txtDescription.Text;

        }
        private bool insertOpStockAndStockLedger()
        {
            bool insertdtls = false;

            for (int i = 1; i < dgvDetails.RowCount; i++)
            {


                if (Convert.ToInt64(dgvDetails.Rows[i].Cells["clmItemCode"].Value) > 0)
                {
                    setValuesStockLedger(i);
                  //myStockOpr.insertStockledger(myStockInfo);
                    setValuesOpStockDetails(i);
                    myOpStockOpr.insertOpStockDetails(myOpStockInfo);
                    insertdtls = true;


                }
            }
            return insertdtls;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
          
            if (btnSave.Text == "&Edit")
            {
                lockControlls();
                btnSave.Text = "&Update";
            }


            else if (btnSave.Text == "&Save")
            {


                if (insertOpStockAndStockLedger())
                {
                    setValuesOpStockMaster();
                    myOpStockOpr.insertOpStockMaster(myOpStockInfo);
                    frmOpeningStock_Load(sender, e);
                    MessageBox.Show("Successfully saved", "True Account Pro",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please Fill Grid", "True Account Pro",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {

                deleteOpStockAndStockDetails();
               if(insertOpStockAndStockLedger ())
                {
                    setValuesOpStockMaster();
                    myOpStockOpr.updateOpStockMaster(myOpStockInfo);

                   
                }
                else
                {
                    myOpStockInfo.EntryNo = Convert.ToInt64(sedEntryNo.Value);
                    myOpStockOpr.deleteOpStockMaster (myOpStockInfo);
                }
                frmOpeningStock_Load(sender, e);
                MessageBox.Show("Successfully saved", "True Account Pro",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        private void deleteOpStockAndStockDetails()
        {
            myStockInfo.ourEntryNo = Convert.ToInt64(sedEntryNo.Value);
            myStockInfo.ourEntryId = "OP";
            //myStockOpr.DeleteStockLedger(myStockInfo);
            myOpStockInfo.EntryNo = Convert.ToInt64(sedEntryNo.Value);
            myOpStockOpr.deleteOpStockDetails(myOpStockInfo);
        }
        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvDetails_UserDeletingRow(object sender, GridViewRowCancelEventArgs e)
        {
           if( dgvDetails.Rows.Count<=16)
            {
                dgvDetails.Rows.AddNew();
            }

        }
        private void lockControlls()
        {
            dtpEntryDate.ReadOnly = true;
            tpkEntryTime.ReadOnly = true;
            txtDescription.ReadOnly = true;
            dgvDetails.ReadOnly = true;
        }
        private void unLockControlls()
        {
            dtpEntryDate.ReadOnly = false;
            tpkEntryTime.ReadOnly = false;
            txtDescription.ReadOnly = false;
            dgvDetails.ReadOnly = false;
        }
        private void sedEntryNo_ValueChanged(object sender, EventArgs e)
        {
            myOpStockInfo.EntryNo = Convert.ToInt64(sedEntryNo.Value);
           DataSet details=   myOpStockOpr.selectAOpStockDetails(myOpStockInfo);
            if(details.Tables [0].Rows.Count>0)
            {
                dtpEntryDate.Value = Convert.ToDateTime(details.Tables[0].Rows[0]["entry_date"].ToString());
                tpkEntryTime.Value = Convert.ToDateTime( details.Tables[0].Rows[0]["entry_time"].ToString());
                txtDescription.Text = details.Tables[0].Rows[0]["description"].ToString();
                for (int i = 0; i < details.Tables[0].Rows.Count; i++)
                {
                    dgvDetails.Rows[i + 1].Cells["clmBarCode"].Value = details.Tables[0].Rows[i]["bar_code"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmItemCode"].Value = details.Tables[0].Rows[i]["item_id"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmItemName"].Value = details.Tables[0].Rows[i]["item_id"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmCompany"].Value = details.Tables[0].Rows[i]["company_id"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmCategory"].Value = details.Tables[0].Rows[i]["category_id"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmModel"].Value = details.Tables[0].Rows[i]["model_id"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmBrand"].Value = details.Tables[0].Rows[i]["brand_id"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmColour"].Value = details.Tables[0].Rows[i]["colour_id"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmSize"].Value = details.Tables[0].Rows[i]["size_id"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmModel"].Value = details.Tables[0].Rows[i]["model_id"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmAddDescrip"].Value = details.Tables[0].Rows[i]["addi_descrip"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmBatch"].Value = details.Tables[0].Rows[i]["batch"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmExpDate"].Value = details.Tables[0].Rows[i]["exp_date"].ToString() == "" ? null : details.Tables[0].Rows[i]["exp_date"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmQty"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["qty"].ToString(), myPrdctDcmlPonts);
                    dgvDetails.Rows[i + 1].Cells["clmFreeQty"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["free_qty"].ToString(), myPrdctDcmlPonts);
                    dgvDetails.Rows[i + 1].Cells["clmQty2"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["qty_2"].ToString(), myPrdctDcmlPonts);
                    dgvDetails.Rows[i + 1].Cells["clmTotalQty"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["total_qty"].ToString(), myPrdctDcmlPonts);
                    dgvDetails.Rows[i + 1].Cells["clmStickerQty"].Value = details.Tables[0].Rows[i]["sticker_qty"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmunitRate"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["unit_rate"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmTotaAmount"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["total_amount"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmDiscPerc"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["disc_perc"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmDiscount"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["discount"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmDisc2"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["discount_2"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmGrossValue"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["gross_value"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmExiceDutyPerc"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["exice_duty_perc"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmExiceDuty"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["exice_duty"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmGstPerc"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["gst_perc"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmGstAmount"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["gst_amount"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmNetValue"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["net_value"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmVatPerc"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["vat_perc"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmVatAmount"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["vat_amount"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmCessPerc"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["cess_perc"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmCessAmount"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["cess_amount"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmGrandTotal"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["grand_total"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmAddCost"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["add_cost"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmCost"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["cost"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmRetailPro"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["reatil_rate_pro"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmRetailRate"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["retail_rate"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmMrpPro"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["mrp_pro"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmMrp"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["mrp"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmSpecialratePro"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["special_rate_pro"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmSpRate"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["special_rate"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmWhPro"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["whoe_sale_pro"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmWholeSale"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["whole_sale"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmBranchPro"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["branch_rate_pro"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmBranchRate"].Value = myGenaralFunctions.FormatDecimalPlace(details.Tables[0].Rows[i]["branch_rate"].ToString(), 2);
                    dgvDetails.Rows[i + 1].Cells["clmItemBarcode"].Value = details.Tables[0].Rows[i]["item_bar_code"].ToString();
                    dgvDetails.Rows[i + 1].Cells["clmGodown"].Value = details.Tables[0].Rows[i]["godown_id"].ToString();
                    findColumnTotal();
                    lockControlls();
                    btnSave.Text = "&Edit";
                    btnDelete.Enabled = true;
                }
            }
            else
            {
                gridSettings();
                unLockControlls();
                btnSave.Text = "&Save";
                btnDelete.EnableAnalytics = false;
            }



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteOpStockAndStockDetails();
            myOpStockInfo.EntryNo = Convert.ToInt64(sedEntryNo.Value.ToString());
            myOpStockOpr.deleteOpStockMaster(myOpStockInfo);
            frmOpeningStock_Load(sender, e);
            MessageBox.Show("Successfully saved", "True Account Pro",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dgvDetails_CellValuePushed(object sender, GridViewCellValueEventArgs e)
        {
            
        }

        private void dgvDetails_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("sdasd");
        }
    }
}

    

