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
    public partial class frmSales : Telerik.WinControls.UI.RadForm
    {
        ledgerNameInfo myLedgerNameInfo = new ledgerNameInfo();
        ledgerNameOpr myLedgerNameOpr = new ledgerNameOpr();

        xmlConfigInfo myXmlConfigInfo = new xmlConfigInfo();
        xmlConfigOpr myXmlConfigOpr = new xmlConfigOpr();

        settingsOpr mySettingsOpr = new settingsOpr();

        genaralFunctions myGenaralFunctions = new genaralFunctions();

        productMasterInfo myProductMasterInfo = new productMasterInfo();
        productMasterOpr myProductMasterOpr = new productMasterOpr();

        mastersInfo myMasterInfo = new mastersInfo();
        mastersOpr myMasterOpr = new mastersOpr();

        barCodeRegistryInfo myBarCodeRegInfo = new barCodeRegistryInfo();
        barCodeRegistryOpr myBarCodeRegOpr = new barCodeRegistryOpr();

        DataTable myGdwnWiseStock;
        DataTable myPurchWiseProduct;
        DataSet myUnitsDs;
        DataTable myUnitDetailsDt;
        bool isAccLoadCmpt = false;
        decimal myGrandTotal, myAdjustment, myRoundOff, myNetamount, myOldBalance, myClBalance, myAmountPaid = 0, myBalance;
        int myPrdctDcmlPonts = 0;
        int myPrdctQty2 = 0;
        DataSet myGenaralSettings;
        public frmSales()
        {
            InitializeComponent();
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
        private void frmSales_Load(object sender, EventArgs e)
        {
            myGenaralSettings = mySettingsOpr.selectAllGenarlSettings();
            rcbRoundOff.Checked = Convert.ToBoolean(myXmlConfigOpr.getXmlSettings("settings", "iSSalesAutoRoundOff"));
            bindLedgerNameDetailsToDDL();
            bindSalesManDetailsToDDL();
            bindSaleRateLabelsToDDL();
            bindProductDetailsToGrid();
            bindProductUnitsToGrid();
            btnNew_Click(sender, e);
        }
        private void bindSaleRateLabelsToDDL()
        {
            DataSet typeDetails = mySettingsOpr.selectAllSalesRateLabels();
            ddlSalesRate.DataSource = typeDetails.Tables[0];
            ddlSalesRate.DisplayMember = "rate_name";
            ddlSalesRate.ValueMember = "rate_id";
            ddlSalesRate.SelectedIndex = 2;
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {
        }

        private void radPageViewPage6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            sedEntryNo.Value = myGenaralFunctions.getMaxValueOfFiledInTable("entry_no", "tblPurchaseMaster");
            dtpEntryTime.Checked = false;
          //  timerTimeUpdate.Enabled = true;
            dtpEntryTime.Value = DateTime.Now;
            dtpEntryTime.Format = DateTimePickerFormat.Time;
            dtpDueDate.Value = DateTime.Now;
            dtpEntryDate.Value = DateTime.Now;
            txtInvoiceNo.Text = "";
            mccAccount.SelectedIndex = 0;
            txtCustomer .Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtPhoneNo.Text = "";
            txtDescription.Text = "";
            txtTinNo.Text = "";
            txtCstNo.Text = "";
            ddlNtrOfPurcha.SelectedIndex = 0;
            dtpDeliveryDate.Value = DateTime.Now;
            dgvDetails.Rows.Clear();
            dgvAdjustment.Rows.Clear();
            for (int i = 0; i <2; i++)
            {
                dgvDetails.Rows.AddNew();
                for (int j = 5; j < dgvDetails.Columns.Count; j++)
                {
                    dgvDetails.Rows[i].Cells[j].ReadOnly = true;
                }
            }
            dgvDetails.Rows[0].IsPinned = true;
            dgvDetails.Rows[0].PinPosition = PinnedRowPosition.Bottom;

            for (int j = 0; j < dgvDetails.ColumnCount; j++)
            {
                dgvDetails.Rows[0].Cells[j].ReadOnly = true;
            }
            //for (int i = 0; i < 2; i++)
            //{
            //    dgvAdjustment.Rows.AddNew();
            //}
            txtRoundOff.Text = "0.00";
            txtAmountPaid.Text = "0.00";
            //txtGrandTotal.Text = "0.00";
            //txtRoundOff.Text = "0.00";
            //txtAdjustment.Text = "0.00";
            //txtNetAmount .Text =
            btnDelete.Enabled = false;
            btnSave.Text = "&Save";
        }
        private void bindSalesManDetailsToDDL()
        {
            myLedgerNameInfo.GroupIdInt = 39;
            DataSet mySupplierDetailsDts = myLedgerNameOpr.selectCashAccAndLedgerByGroupId(myLedgerNameInfo);
            mccSalesman.DataSource = mySupplierDetailsDts.Tables[0];
            mccSalesman.DisplayMember = "ledger_name";
            mccSalesman.ValueMember = "ledger_id";
            mccSalesman.Columns["ledger_id"].IsVisible = false;
            mccSalesman.Columns["ledger_name"].HeaderText = "Name";
            mccSalesman.Columns["ledger_code"].HeaderText = "Code";
            mccSalesman.Columns["alternate_name"].HeaderText = "Alternate Name";
            FilterDescriptor descriptor = new FilterDescriptor(mccAccount.DisplayMember, FilterOperator.Contains, string.Empty);
            mccAccount.MultiColumnComboBoxElement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            FilterDescriptor filtercustomername = new FilterDescriptor("ledger_code", FilterOperator.Contains, string.Empty);
            CompositeFilterDescriptor compositeFilter = new CompositeFilterDescriptor();
            compositeFilter.FilterDescriptors.Add(descriptor);
            compositeFilter.FilterDescriptors.Add(filtercustomername);
            compositeFilter.LogicalOperator = FilterLogicalOperator.Or;
            mccAccount.EditorControl.FilterDescriptors.Add(compositeFilter);
           // isSplrBindCmplt = true;
        }
        private void bindLedgerNameDetailsToDDL()
        {
            myLedgerNameInfo.GroupIdInt = 46;
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
            isAccLoadCmpt = true;
        }
        private void mccAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isAccLoadCmpt)
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
                    txtCustomer.Text = suprDetails.Tables[0].Rows[0]["ledger_name"].ToString();
                    txtAddress.Text = suprDetails.Tables[0].Rows[0]["address_1"].ToString();
                    txtMobileNo.Text = suprDetails.Tables[0].Rows[0]["mobile_no"].ToString();
                    txtPhoneNo.Text = suprDetails.Tables[0].Rows[0]["phone_no"].ToString();
                    txtOldBalance.Text = myGenaralFunctions.FormatDecimalPlace(suprDetails.Tables[0].Rows[0]["balance"].ToString(), 2);
                    ddlNtrOfPurcha.Text = suprDetails.Tables[0].Rows[0]["nature_of_purchase"].ToString();
                    dtpDueDate.Value = suprDetails.Tables[0].Rows[0]["due_days"].ToString() != "" ? DateTime.Now.AddDays(Convert.ToInt32(suprDetails.Tables[0].Rows[0]["due_days"].ToString())) : DateTime.Now;
                    txtTinNo.Text = suprDetails.Tables[0].Rows[0]["tin_no"].ToString();
                    txtCstNo.Text = suprDetails.Tables[0].Rows[0]["cst_no"].ToString();
                }
                else
                {
                    txtCustomer.Text = "";
                    txtAddress.Text = "";
                    txtPhoneNo.Text = "";
                    txtMobileNo.Text = "";
                    txtOldBalance.Text = "0.00";
                    ddlNtrOfPurcha.Text = "";
                    dtpDueDate.Value = DateTime.Now;
                    txtTinNo.Text = "";
                    txtCstNo.Text = "";
                }
            }
        }
        private void dgvDetails_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
   if (e.Column == dgvDetails.Columns["clmItemCode"])
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
            else if (e.Column == dgvDetails.Columns["clmUnitRate"])
            {
                myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(dgvDetails.Rows[e.RowIndex].Cells["clmBarCodeId"].Value.ToString());
                DataSet rateDerails = myBarCodeRegOpr.selectRateDetailsByBarcodeId(myBarCodeRegInfo);
                BindingSource bs = new BindingSource();
                bs.DataSource = rateDerails.Tables[0];
                ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmUnitRate"]).DataSource = bs;
                ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmUnitRate"]).ValueMember = "rate_id";
                ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmUnitRate"]).DisplayMember = "Amount";
                RadMultiColumnComboBoxElement editColumn3 = (RadMultiColumnComboBoxElement)e.ActiveEditor;
                editColumn3.EditorControl.Columns["rate_id"].IsVisible = false;
                editColumn3.EditorControl.Columns["Rate"].MinWidth = 100;
                editColumn3.EditorControl.Columns["Rate"].HeaderText = "Rate";
                editColumn3.EditorControl.Columns["Amount"].MinWidth = 100;
                editColumn3.EditorControl.Columns["Amount"].HeaderText = "Amount";
                editColumn3.EditorControl.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                editColumn3.EditorControl.ShowRowHeaderColumn = false;
                editColumn3.DropDownMinSize = new Size(300, 200);
                editColumn3.DropDownSizingMode = SizingMode.None;
                editColumn3.DropDownStyle = RadDropDownStyle.DropDown;
                // editColumn2.EditorControl.MasterTemplate.AutoGenerateColumns = false;
                editColumn3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
                editColumn3.AutoSizeDropDownToBestFit = false;
                editColumn3.DropDownAnimationEnabled = false;
                // editColumn2.EditorControl.Columns.Add(new GridViewTextBoxColumn("product_code"));
                //FilterDescriptor filtercustomername = new FilterDescriptor("godown_name", FilterOperator.Contains, string.Empty);
                //editColumn2.EditorControl.FilterDescriptors.Add(filtercustomername);
            }
        }
        private void dgvDetails_CellValidated(object sender, CellValidatedEventArgs e)
        {
            //int rowIndex = Convert.ToInt32(e.RowIndex);
            //switch (dgvDetails.CurrentCell.ColumnInfo.Name.ToString())
            //{
            //    case "clmQty":
            //        {

            //            break;
            //        }
            //}
        }
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

            ((GridViewComboBoxColumn)dgvDetails.Columns["clmBUnit"]).ValueMember = "unit_id";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmBUnit"]).DisplayMember = "unit_name";
            ((GridViewComboBoxColumn)dgvDetails.Columns["clmBUnit"]).DataSource = myUnitDetailsDt;
        }
        private void dgvDetails_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            dgvDetails.Tag = dgvDetails.CurrentCell.Value;
        }

        private void bindPrdctDtlsToRowByBarCode(int rowIndex)
        {
            myBarCodeRegInfo.ourBarCode = dgvDetails.Rows[rowIndex].Cells["clmBarcode"].Value.ToString();
            DataSet productDetails = myBarCodeRegOpr.selectitemDetailsByBarCode(myBarCodeRegInfo);
            int datasetIndex = productDetails.Tables[0].Rows.Count - 1;
            if (productDetails.Tables[0].Rows.Count > 0)
            {
                dgvDetails.Rows[rowIndex].Cells["clmBarCodeId"].Value = productDetails.Tables[0].Rows[datasetIndex]["bar_code_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value = productDetails.Tables[0].Rows[datasetIndex]["item_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value = productDetails.Tables[0].Rows[datasetIndex]["item_id"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmCompany"].Value = productDetails.Tables[0].Rows[datasetIndex]["company_id"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmCategory"].Value = productDetails.Tables[0].Rows[datasetIndex]["category_id"].ToString();
               // dgvDetails.Rows[rowIndex].Cells["clmModel"].Value = productDetails.Tables[0].Rows[datasetIndex]["model_id"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmBrand"].Value = productDetails.Tables[0].Rows[datasetIndex]["brand_id"].ToString();
               // dgvDetails.Rows[rowIndex].Cells["clmColour"].Value = productDetails.Tables[0].Rows[datasetIndex]["colour_id"].ToString();
               // dgvDetails.Rows[rowIndex].Cells["clmSize"].Value = productDetails.Tables[0].Rows[datasetIndex]["size_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmBatch"].Value = productDetails.Tables[0].Rows[datasetIndex]["batch"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmExpDate"].Value = productDetails.Tables[0].Rows[datasetIndex]["exp_date"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmUnit"].Value = productDetails.Tables[0].Rows[datasetIndex]["unit_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmBUnit"].Value = productDetails.Tables[0].Rows[datasetIndex]["unit_id"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmDiscPerc"].Value = productDetails.Tables[0].Rows[datasetIndex]["disc_perc"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmDisc2"].Value = productDetails.Tables[0].Rows[datasetIndex]["disc2"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmExiceDutyPerc"].Value = productDetails.Tables[0].Rows[datasetIndex]["exice_duty_perc"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmGstPerc"].Value = productDetails.Tables[0].Rows[datasetIndex]["gst_perc"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmVatPerc"].Value = productDetails.Tables[0].Rows[datasetIndex]["vat_perc"].ToString();
                dgvDetails.Rows[rowIndex].Cells["clmCessPerc"].Value = productDetails.Tables[0].Rows[datasetIndex]["cess_perc"].ToString();
               myBarCodeRegInfo.ourBarCodeId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmBarCodeId"].Value.ToString());
                DataSet rateDerails = myBarCodeRegOpr.selectRateDetailsByBarcodeId(myBarCodeRegInfo);
                BindingSource bs = new BindingSource();
                 bs.DataSource= rateDerails.Tables[0];
                ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmUnitRate"]).DataSource = bs;
                 ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmUnitRate"]).ValueMember = "rate_id";
                ((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmUnitRate"]).DisplayMember = "Amount";
                dgvDetails.Rows[rowIndex].Cells["clmunitRate"].Value = Convert.ToInt32(ddlSalesRate.SelectedValue);
                //((GridViewMultiComboBoxColumn)dgvDetails.Columns["clmUnitRate"]).`
                //dgvDetails.Rows[rowIndex].Cells["clmAddCost"].Value = productDetails.Tables[0].Rows[datasetIndex]["add_cost"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmCost"].Value = productDetails.Tables[0].Rows[datasetIndex]["cost"].ToString();
                //   dgvDetails.Rows[rowIndex].Cells["clmRetailPro"].Value = productDetails.Tables[0].Rows[datasetIndex]["reatil_rate_pro"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmRetailRate"].Value = productDetails.Tables[0].Rows[datasetIndex]["retail_rate"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmMrpPro"].Value = productDetails.Tables[0].Rows[datasetIndex]["mrp_pro"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmMrp"].Value = productDetails.Tables[0].Rows[datasetIndex]["mrp"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmSpecialratePro"].Value = productDetails.Tables[0].Rows[datasetIndex]["special_rate_pro"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmSpRate"].Value = productDetails.Tables[0].Rows[datasetIndex]["special_rate"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmWhPro"].Value = productDetails.Tables[0].Rows[datasetIndex]["whoe_sale_pro"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmWholeSale"].Value = productDetails.Tables[0].Rows[datasetIndex]["whole_sale"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmBranchPro"].Value = productDetails.Tables[0].Rows[datasetIndex]["branch_rate_pro"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmBranchRate"].Value = productDetails.Tables[0].Rows[datasetIndex]["branch_rate"].ToString();
                //dgvDetails.Rows[rowIndex].Cells["clmItemBarcode"].Value = productDetails.Tables[0].Rows[datasetIndex]["item_bar_code"].ToString();
                //// myPrdctDcmlPonts = productDetails.Tables[0].Rows[0]["unit_decimal"].ToString() != "" ? Convert.ToInt32(productDetails.Tables[0].Rows[0]["unit_decimal"].ToString()) : 3;
                // myPrdctQty2 = productDetails.Tables[0].Rows[0]["qty2"].ToString() == "0" || productDetails.Tables[0].Rows[0]["qty2"].ToString() == "" ? 0 : Convert.ToInt32(productDetails.Tables[0].Rows[0]["qty2"].ToString());
                // calculations(rowIndex);
                // findColumnTotal();
            }
        }

        private void btnRateRefresh_Click(object sender, EventArgs e)
        {
           // dgvDetails.Rows[1].Cells["clmUnitRate"].Value = "10.25";
        }

        private void dgvDetails_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.RowIndex);
            switch (dgvDetails.CurrentCell.ColumnInfo.Name.ToString())
            {
                case "clmBarcode":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmBarcode"].Value != null)
                        {
                            bindPrdctDtlsToRowByBarCode(rowIndex);
                            for (int j = 4; j < dgvDetails.Columns.Count; j++)
                            {
                                dgvDetails.Rows[rowIndex].Cells[j].ReadOnly = false; 
                            }
                        }
                        break;
                    }
                case "clmItemCode":
                    {
                        checkCellValueChanged(rowIndex);
                        if (dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value = dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value;
                            myProductMasterInfo.ProductId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value.ToString());
                            bindPrdctDtlsToRowByItem(rowIndex);

                            for (int j = 5; j < dgvDetails.Columns.Count; j++)
                            {
                                dgvDetails.Rows[rowIndex].Cells[j].ReadOnly = false;
                            }
                            selectProductFromList( rowIndex);
                        }
                        break;
                    }
                case "clmItemName":
                    {
                        checkCellValueChanged(rowIndex);
                        if (dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value = dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value;
                            myProductMasterInfo.ProductId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value.ToString());
                            bindPrdctDtlsToRowByItem(rowIndex);
                            for (int j = 4; j < dgvDetails.Columns.Count; j++)
                            {
                                dgvDetails.Rows[rowIndex].Cells[j].ReadOnly = false; 
                            }
                         selectProductFromList(rowIndex);
                        }
                        break;
                    }
                case "clmUnit":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmUnit"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmFactor"].Value = getFactorOfUnit(rowIndex, Convert.ToInt32(dgvDetails.Rows[rowIndex].Cells["clmUnit"].Value.ToString())).ToString();
                        }
                        break;
                    }
                case "clmQty":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmQty"].Value != null)
                        {
                            frmGodownSelection myGodwonSelection = new frmGodownSelection(Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmBarCodeId"].Value), dgvDetails.Rows[rowIndex].Cells["clmQty"].Value.ToString(), ((GridViewComboBoxColumn)this.dgvDetails.Columns["clmUnit"]).GetLookupValue(dgvDetails.Rows[rowIndex].Cells["clmUnit"].Value).ToString(), Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmFactor"].Value.ToString()), getQtyFromGodowngrid(rowIndex, "clmQty", "Qty"), myPrdctDcmlPonts, getRowQtyFromGodowngrid(rowIndex,"Qty"));
                            myGodwonSelection.ShowDialog();
                            dgvDetails.Rows[rowIndex].Cells["clmQty"].Value = myGodwonSelection.returnSelectedQty;
                            myGdwnWiseStock = myGodwonSelection.returnQtyDetails;
                            setGodownWiseQty(rowIndex, "Qty");
                            calculations(rowIndex);
                            findColumnTotal();
                        }
                        break;
                    }

                case "clmMeasureQty":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmMeasureQty"].Value != null)
                        {
                            frmGodownSelection myGodwonSelection = new frmGodownSelection(Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmBarCodeId"].Value), dgvDetails.Rows[rowIndex].Cells["clmMeasureQty"].Value.ToString(), ((GridViewComboBoxColumn)this.dgvDetails.Columns["clmBUnit"]).GetLookupValue(dgvDetails.Rows[rowIndex].Cells["clmBUnit"].Value).ToString(), 1, getQtyFromGodowngrid(rowIndex, "clmMeasureQty", "MQty"), myPrdctDcmlPonts, getRowQtyFromGodowngrid(rowIndex, "MQty"));
                            myGodwonSelection.ShowDialog();
                            dgvDetails.Rows[rowIndex].Cells["clmMeasureQty"].Value = myGodwonSelection.returnSelectedQty;
                            myGdwnWiseStock = myGodwonSelection.returnQtyDetails;
                            setGodownWiseQty(rowIndex, "MQty");
                            calculations(rowIndex);
                            findColumnTotal();
                        }
                        break;
                    }
                case "clmFreeQtyUnit":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmFreeQtyUnit"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmFreeQtyFactor"].Value = getFactorOfUnit(rowIndex, Convert.ToInt32(dgvDetails.Rows[rowIndex].Cells["clmFreeQtyUnit"].Value.ToString()));
                        }
                        break;
                    }
                case "clmFreeQty":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmFreeQty"].Value != null)
                        {
                            frmGodownSelection myGodwonSelection = new frmGodownSelection(Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmBarCodeId"].Value), dgvDetails.Rows[rowIndex].Cells["clmQty"].Value.ToString(), ((GridViewComboBoxColumn)this.dgvDetails.Columns["clmUnit"]).GetLookupValue(dgvDetails.Rows[rowIndex].Cells["clmUnit"].Value).ToString(), Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmFactor"].Value.ToString()), getQtyFromGodowngrid(rowIndex, "clmFreeQty", "FQty"), myPrdctDcmlPonts, getRowQtyFromGodowngrid(rowIndex, "FQty"));
                            myGodwonSelection.ShowDialog();
                            dgvDetails.Rows[rowIndex].Cells["clmFreeQty"].Value = myGodwonSelection.returnSelectedQty;
                            myGdwnWiseStock = myGodwonSelection.returnQtyDetails;
                            setGodownWiseQty(rowIndex, "FQty");
                            calculations(rowIndex);
                            findColumnTotal();
                        }
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
                        if (dgvDetails.Rows[rowIndex].Cells["clmUnitRate"].Value != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmUnitRate"].Value = dgvDetails.Rows[rowIndex].Cells["clmUnitRate"].Value;
                        }
                        GridViewEditManager editManager = sender as GridViewEditManager;
                        if (editManager != null)
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmUnitRateText"].Value = editManager.GridViewElement.CurrentCell.Text.ToString();
                        }
                        else
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmUnitRateText"].Value = 0;
                        }
                        dgvDetails.Rows[rowIndex].Cells["clmTotaAmount"].Value = 0;
                       // RadMultiColumnComboBoxElement mccbEditor = (RadMultiColumnComboBoxElement)e.ActiveEditor;
                       // GridViewDataRowInfo selectedRow = (GridViewDataRowInfo)mccbEditor.SelectedItem;
                       //string st=   selectedRow.Cells["barcode_id"].Value.ToString();
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
                        checkCellValueChanged(rowIndex);
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmDiscount":
                    {
                        checkCellValueChanged(rowIndex);
                        dgvDetails.Rows[rowIndex].Cells["clmDiscPerc"].Value = null;
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmDisc2":
                    {
                        checkCellValueChanged(rowIndex);
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmExiceDutyPerc":
                    {
                        checkCellValueChanged(rowIndex);
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmExiceDuty":
                    {
                        checkCellValueChanged(rowIndex);
                        dgvDetails.Rows[rowIndex].Cells["clmExiceDutyPerc"].Value = null;
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmGstPerc":
                    {
                        checkCellValueChanged(rowIndex);
                        calculations(rowIndex);
                        findColumnTotal();
                        break;
                    }
                case "clmGstAmount":
                    {
                        checkCellValueChanged(rowIndex);
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
        private DataTable getRowQtyFromGodowngrid(int rowIndex,string type)
        {
            DataTable itemGodownStock = new DataTable();
            itemGodownStock.Columns.Add("godownId", typeof(int));
            itemGodownStock.Columns.Add("qty", typeof(decimal));
            if (dgvDetails.Tag != null && dgvDetails.Tag.ToString() == dgvDetails.Rows[rowIndex].Cells["clmQty"].Value.ToString())
            {
                for (int i = 0; i < dgvGodownDetails.Rows.Count; i++)
                {
                    if (dgvGodownDetails.Rows[i].Cells["clmRowNo"].Value.ToString().Equals(rowIndex.ToString()) && dgvGodownDetails.Rows[i].Cells["clmType"].Value.ToString().Equals(type))
                    {
                        itemGodownStock.Rows.Add(dgvGodownDetails.Rows[i].Cells["clmGodownId"].Value, dgvGodownDetails.Rows[i].Cells["clmQty"].Value);
                    }
                }
            }
            return itemGodownStock;
        }              
        private DataTable getQtyFromGodowngrid(int rowIndex,string columnName,string type)
        {
            DataTable godownStock = new DataTable();
            godownStock.Columns.Add("godownId", typeof(int));
            godownStock.Columns.Add("qty", typeof(decimal));
            int count = dgvGodownDetails.Rows.Count;
            if (count>0)
            {
                for(int i=0;i< count;i++)
                {
                    if (Convert.ToInt32(dgvGodownDetails.Rows[i].Cells["clmRowNo"].Value.ToString()) != rowIndex)
                    {
                        if (Convert.ToInt64(dgvGodownDetails.Rows[i].Cells["clmBarcodeId"].Value.ToString()) == Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmBarcodeId"].Value.ToString()))
                        {
                            godownStock.Rows.Add(dgvGodownDetails.Rows[i].Cells["clmGodownId"].Value.ToString(), dgvGodownDetails.Rows[i].Cells["clmQty"].Value.ToString());
                        }
                    }
                  else  if (Convert.ToInt32(dgvGodownDetails.Rows[i].Cells["clmRowNo"].Value.ToString()) == rowIndex && dgvGodownDetails.Rows[i].Cells["clmType"].Value.ToString() != type)
                    {
                        if (Convert.ToInt64(dgvGodownDetails.Rows[i].Cells["clmBarcodeId"].Value.ToString()) == Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmBarcodeId"].Value.ToString()))
                        {
                            godownStock.Rows.Add(dgvGodownDetails.Rows[i].Cells["clmGodownId"].Value.ToString(), dgvGodownDetails.Rows[i].Cells["clmQty"].Value.ToString());
                        }
                    }
                }
            }
            return godownStock;
        }
        private void setGodownWiseQty(int rowIndex,string type)
        {
            if (myGdwnWiseStock != null)
            {
              int count=  dgvGodownDetails.Rows.Count;
                for (int i = 0; i < myGdwnWiseStock.Rows.Count; i++)
                {
                    dgvGodownDetails.Rows.AddNew();
                    dgvGodownDetails.Rows[count + i].Cells["clmRowNo"].Value = rowIndex;
                    dgvGodownDetails.Rows[count + i].Cells["clmBarcodeId"].Value = dgvDetails.Rows[rowIndex].Cells["clmBarcodeId"].Value.ToString();
                    dgvGodownDetails.Rows[count + i].Cells["clmGodownId"].Value = myGdwnWiseStock.Rows[i]["godownID"].ToString();
                    dgvGodownDetails.Rows[count + i].Cells["clmQty"].Value = myGdwnWiseStock.Rows[i]["qty"].ToString();
                    dgvGodownDetails.Rows[count + i].Cells["clmType"].Value = type;
                }
                myGdwnWiseStock.Rows.Clear();
            }
        }
        private void dgvDetails_CellPaint(object sender, GridViewCellPaintEventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult Result = RadMessageBox.Show("Do You Want To Save", "TrueAccountPro", MessageBoxButtons.YesNo,RadMessageIcon.Question);
            if (Result == DialogResult.Yes)
            {
               
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDivideDiscount_Click(object sender, EventArgs e)
        {

        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnDivideCost_Click(object sender, EventArgs e)
        {
            decimal grandTotal = 0, divideCost = 0, rowGrandTotal = 0, cost = 0;
            for (int i = 1; i < dgvDetails.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvDetails.Rows[i].Cells["clmSelect"].Value) > 0)
                {
                    grandTotal = Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmGrandTotal"].Value.ToString());
                }
                divideCost = Convert.ToDecimal(txtTotalCost.Text.ToString());
            }

            for (int i = 1; i < dgvDetails.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvDetails.Rows[i].Cells["clmSelect"].Value) > 0)
                {

                    rowGrandTotal = Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmGrandTotal"].Value.ToString());

                    cost = divideCost * rowGrandTotal / grandTotal;

                    dgvDetails.Rows[i].Cells["clmAddCost"].Value = 0;

                    dgvDetails.Rows[i].Cells["clmAddCost"].Value = (Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmAddCost"].Value.ToString()) + cost).ToString();

                    calculations(i);
                    findColumnTotal();
                }
            }
        }

        private void btnDivideDiscount_Click_1(object sender, EventArgs e)
        {
            decimal amount = 0, divideDisc = 0, rowTotal = 0, discount = 0;
            string clmName;

            if (rdbTotalAmount.IsChecked)
            {
                clmName = "clmTotaAmount";
            }
            else
            {
                clmName = "clmGrossValue";
            }

            for (int i = 1; i < dgvDetails.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvDetails.Rows[i].Cells["clmSelect"].Value) > 0)
                {
                    amount = Convert.ToDecimal(dgvDetails.Rows[i].Cells[clmName].Value.ToString());
                }
            }
            divideDisc = Convert.ToDecimal(txtTotalDiscount.Text.ToString());
            for (int i = 1; i < dgvDetails.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvDetails.Rows[i].Cells["clmSelect"].Value) > 0)
                {
                    rowTotal = Convert.ToDecimal(dgvDetails.Rows[i].Cells[clmName].Value.ToString());
                    discount = divideDisc * rowTotal / amount;
                    if (ddlApplyColumn.SelectedIndex == 0)
                    {
                        dgvDetails.Rows[i].Cells["clmDiscount"].Value = 0;
                        dgvDetails.Rows[i].Cells["clmDiscount"].Value = (Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmDiscount"].Value.ToString()) + discount).ToString();
                        dgvDetails.Rows[i].Cells["clmDiscPerc"].Value = null;
                        calculations(i);
                        findColumnTotal();
                    }
                    else
                    {
                        dgvDetails.Rows[i].Cells["clmDisc2"].Value = 0;
                        dgvDetails.Rows[i].Cells["clmDisc2"].Value = (Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmDisc2"].Value.ToString()) + discount).ToString();
                        calculations(i);
                        findColumnTotal();
                    }
                }
            }
        }
        private void rcpAddDiscout_Expanded(object sender, EventArgs e)
        {
            if (rcpAddDiscout.IsExpanded)
            {
                rcpAddCost.IsExpanded = false;
            }
        }
        private void rcpAddCost_Expanded(object sender, EventArgs e)
        {
            if (rcpAddCost.IsExpanded)
            {
                rcpAddDiscout.IsExpanded = false;
            }
        }
        private void bindPrdctDtlsToRowByItem(int rowIndex)
        {
            DataSet productDetails = myProductMasterOpr.selectAllProductMasterData(myProductMasterInfo);
            if (productDetails.Tables[0].Rows.Count > 0)
            {
                //dgvDetails.Rows[rowIndex].Cells["clmUnitRate"].Value = productDetails.Tables[0].Rows[0]["purchase_rate"].ToString() != "" ? productDetails.Tables[0].Rows[0]["purchase_rate"].ToString() : "0";
                dgvDetails.Rows[rowIndex].Cells["clmVatPerc"].Value = productDetails.Tables[0].Rows[0]["rate_of_tax_purchase"].ToString() != "" ? productDetails.Tables[0].Rows[0]["rate_of_tax_purchase"].ToString() : "0";
                dgvDetails.Rows[rowIndex].Cells["clmCessPerc"].Value = productDetails.Tables[0].Rows[0]["rate_of_cess"].ToString() != "" ? productDetails.Tables[0].Rows[0]["rate_of_cess"].ToString() : "0";
                dgvDetails.Rows[rowIndex].Cells["clmExiceDutyPerc"].Value = productDetails.Tables[0].Rows[0]["exice_duty"].ToString() != "" ? productDetails.Tables[0].Rows[0]["exice_duty"].ToString() : "0";
                dgvDetails.Rows[rowIndex].Cells["clmGstPerc"].Value = productDetails.Tables[0].Rows[0]["gst"].ToString() != "" ? productDetails.Tables[0].Rows[0]["gst"].ToString() : "0";
                myPrdctDcmlPonts = productDetails.Tables[0].Rows[0]["unit_decimal"].ToString() != "" ? Convert.ToInt32(productDetails.Tables[0].Rows[0]["unit_decimal"].ToString()) : 3;
                myPrdctQty2 = productDetails.Tables[0].Rows[0]["qty2"].ToString() == "0" || productDetails.Tables[0].Rows[0]["qty2"].ToString() == "" ? 0 : Convert.ToInt32(productDetails.Tables[0].Rows[0]["qty2"].ToString());
                calculations(rowIndex);
                findColumnTotal();
            }
        }
        private void selectProductFromList(int rowIndex)
        {
            if (dgvDetails.Rows[rowIndex].Cells["clmBarcode"].Value == null)
            {
                frmProductSelection myProductSelection = new frmProductSelection(Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value), dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value.ToString(), dgvDetails.Rows[rowIndex].Cells["clmItemName"].Value.ToString());
                myProductSelection.ShowDialog();
                dgvDetails.Rows[rowIndex].Cells["clmBarcode"].Value = myProductSelection.returnBarcode;
                if (dgvDetails.Rows[rowIndex].Cells["clmBarcode"].Value != null)
                {
                    bindPrdctDtlsToRowByBarCode(rowIndex);
                    dgvDetails.Rows[rowIndex].Cells["clmFactor"].Value = getFactorOfUnit(rowIndex,Convert.ToInt32( dgvDetails.Rows[rowIndex].Cells["clmUnit"].Value.ToString())).ToString();
                }
            }
        }
        private void calculations(int rowindex)
        {
            decimal qty = 0, measureQty = 0, freeQty = 0, totalQty = 0, unitRate = 0, ratePlusTax = 0, totalAmount = 0, discPec = 0, discount = 0, disc2 = 0, grossValue = 0, exiceDutyPer = 0, exiceDuty = 0, gstPerc = 0, gst = 0, netValue = 0, vatPerc = 0, vatAmount = 0, cessPerc = 0, cessAmount = 0;
            decimal grandTotal = 0;
            if (rowindex > -1)
            {
                if (dgvDetails.Rows[rowindex].Cells["clmQty"].Value != null)
                {
                    qty = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmQty"].Value.ToString().Trim());
                    dgvDetails.Rows[rowindex].Cells["clmQty"].Value = myGenaralFunctions.FormatDecimalPlace(qty.ToString(), myPrdctDcmlPonts);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmMeasureQty"].Value != null)
                {
                    measureQty = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmMeasureQty"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmMeasureQty"].Value = myGenaralFunctions.FormatDecimalPlace(measureQty.ToString().Trim(), myPrdctDcmlPonts);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value != null)
                {
                    freeQty = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value = myGenaralFunctions.FormatDecimalPlace(freeQty.ToString().Trim(), myPrdctDcmlPonts);
                }
                if (dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value != null)
                {
                    unitRate = Convert.ToDecimal(((GridViewMultiComboBoxColumn)this.dgvDetails.Columns["clmUnitRate"]).GetLookupValue(dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value).ToString());
                }
                if (dgvDetails.Rows[rowindex].Cells["clmRatePlusTax"].Value != null)
                {
                    ratePlusTax = Convert.ToDecimal(dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value.ToString());
                    dgvDetails.Rows[rowindex].Cells["clmFreeQty"].Value = myGenaralFunctions.FormatDecimalPlace(ratePlusTax.ToString().Trim(), myPrdctDcmlPonts);
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
                netValue = grossValue + exiceDuty;
                if (gstPerc > 0)
                {
                    gst = (netValue) * gstPerc / 100;
                }
                if (vatPerc > 0)
                {
                    vatAmount = netValue * vatPerc / 100;
                }
                if (cessPerc > 0)
                {
                    cessAmount = vatAmount * cessPerc / 100;
                }

                if(vatPerc>0&&ratePlusTax>0)
                {
                    decimal taxRate = ratePlusTax - discount + disc2;
                    unitRate = taxRate - (taxRate * vatPerc / (100 + vatPerc));
                }
                grandTotal = netValue + vatAmount + cessAmount + gst;
                //dgvDetails.Rows[rowindex].Cells["clmUnitRateText"].Value = myGenaralFunctions.FormatDecimalPlace(unitRate.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value = myGenaralFunctions.FormatDecimalPlace(unitRate.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmUnitRate"].Value = myGenaralFunctions.FormatDecimalPlace(unitRate.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmGrandTotal"].Value = myGenaralFunctions.FormatDecimalPlace(grandTotal.ToString().Trim(), 2);
                dgvDetails.Rows[rowindex].Cells["clmTotalQty"].Value = totalQty != 0 ? myGenaralFunctions.FormatDecimalPlace(totalQty.ToString().Trim(), myPrdctDcmlPonts) : null;
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
            }
        }
        private void findColumnTotal()
        {
            int count = dgvDetails.Rows.Count;
            dgvDetails.Rows[0].Cells["clmQty"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmMeasureQty"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmFreeQty"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmQty2"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmTotalQty"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmDiscount"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmDisc2"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmExiceDuty"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmGstAmount"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmVatAmount"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmCessAmount"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmTotaAmount"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmGrossValue"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmNetValue"].Value = 0.00;
            dgvDetails.Rows[0].Cells["clmGrandTotal"].Value = 0.00;

            for (int i = 1; i < count; i++)
            {
                if (dgvDetails.Rows[i].Cells["clmQty"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmQty"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmQty"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmQty"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmMeasureQty"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmMeasureQty"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmMeasureQty"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmMeasureQty"].Value.ToString());
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
                if (dgvDetails.Rows[i].Cells["clmDiscount"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmDiscount"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmDiscount"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmDiscount"].Value.ToString());
                }
                if (dgvDetails.Rows[i].Cells["clmDisc2"].Value != null)
                {
                    dgvDetails.Rows[0].Cells["clmDisc2"].Value = Convert.ToDecimal(dgvDetails.Rows[0].Cells["clmDisc2"].Value.ToString()) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmDisc2"].Value.ToString());
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
                txtGrandTotal.Text = dgvDetails.Rows[0].Cells["clmGrandTotal"].Value.ToString();
            }
            formTotalCalculations(rcbRoundOff.Checked);
        }
        private void checkCellValueChanged(int rowIndex)
        {
            //if (rowIndex > -1)
            //{
            //    if (dgvDetails.Rows[rowIndex].Cells["clmBarcodeId"].Value != null)
            //    {
            //        if (dgvDetails.Tag.ToString().Trim() != dgvDetails.CurrentCell.Value.ToString().Trim())
            //        {
            //            if (DialogResult.Yes == MessageBox.Show(dgvDetails.CurrentCell.ColumnInfo.HeaderText.ToString() + " value change  ?", "True Account Pro", MessageBoxButtons.YesNo))
            //            {

            //                dgvDetails.Rows[rowIndex].Cells["clmBarcodeId"].Value = null;
            //                dgvDetails.Rows[rowIndex].Cells["clmBarcode"].Value = null;
            //            }
            //            else
            //            {
            //                dgvDetails.CurrentCell.Value = dgvDetails.Tag.ToString().Trim();
            //            }
            //        }

            //    }
            //}
        }
        private string getFactorOfUnit(int rowIndex,int unitId)
        {
            myProductMasterInfo.ProductId = Convert.ToInt64(dgvDetails.Rows[rowIndex].Cells["clmItemCode"].Value);

            DataSet detailsDs = myProductMasterOpr.selectProductUnitDetails(myProductMasterInfo);

            if (detailsDs.Tables[0].Rows.Count > 0)
            {
                DataTable myUnitsDt = detailsDs.Tables[0];

                myUnitsDt.DefaultView.RowFilter = "unit_Id='" + unitId + "'";
                myUnitsDt = myUnitsDt.DefaultView.ToTable();
                return myUnitsDt.Rows[0]["factor"].ToString();
            }
            else
            {
                return "0";
            }
        }
        private void formTotalCalculations(bool isRoundOff)
        {
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
            txtAdjustment.Text = myGenaralFunctions.FormatDecimalPlace(myAdjustment.ToString(), 2);
            //  txtRoundOff.Text = myGenaralFunctions.FormatDecimalPlace(roundOff.ToString(), 2);
            txtRoundOff.Text = myRoundOff.ToString();
            txtNetAmount.Text = myGenaralFunctions.FormatDecimalPlace(myNetamount.ToString(), 2);
            txtClBalance.Text = myGenaralFunctions.FormatDecimalPlace(myClBalance.ToString(), 2);
            txtBalance.Text = myGenaralFunctions.FormatDecimalPlace(myBalance.ToString(), 2);
            if (myBalance > 0)
            {
                dtpDueDate.Enabled = true;
            }
            else
            {
                dtpDueDate.Enabled = false;
            }
        }
       }
}
