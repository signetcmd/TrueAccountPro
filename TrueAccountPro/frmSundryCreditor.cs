using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using BEL;
using BAL;
using BLL;
using DAL;
using Telerik.WinControls;

namespace TrueAccountPro
{
    public partial class frmSundryCreditor : Telerik.WinControls.UI.RadForm
    {


        ledgerNameInfo myLedgerNameInfo = new ledgerNameInfo();
        ledgerGroupInfo myLedgerGroupInfo = new ledgerGroupInfo();

        ledgerNameOpr myLedgerNameOpr = new ledgerNameOpr();
        ledgerGroupOpr myLedgerGroupOpr = new ledgerGroupOpr();

        mastersInfo myMastersInfo = new mastersInfo();
        mastersOpr myMastersOpr = new mastersOpr();
        genaralFunctions myGenaralFunctions = new genaralFunctions();


        settingsOpr mySettingsOpr = new settingsOpr();
        DataSet myLedgerNameDts, myLedgerAddressDts, myLedgerRegDts, myLedgerOtherDts;
        DataSet myLedgerTandCDts, myLedgerBankDts, myLedgerImageDts;


        MemoryStream myMemmoryStream;


        TabControl TabContainer1 = new TabControl();

        long myLedgerIdInt;
        bool myLedgerIsFixed;
        bool isLoadCmplt = false;

        string myFormTypeStr;
        int myGroupIdInt;

        bool myFocusReg = false;
        bool myFocusSDOth = false;
        bool myFocusSCOth = false;
        bool myFocusTerms = false;
        bool myFocusBank = false;

        public frmSundryCreditor(string formName)
        {

            myFormTypeStr = formName;


            InitializeComponent();



        }
        private void formSettings()
        {
            if (myFormTypeStr == "creditor")
            {
                this.Text = "Sundrey Creditor";
                myGroupIdInt = 39;

                tabControl1.TabPages.Remove(tabSundryDebitor);
                bindLedgerGroupsToDDl(myGroupIdInt);
                bindSundryCreditorsDetailsToGrid(myGroupIdInt);
                ddlAmountType.SelectedIndex = 0;
            }
            else
            {

                this.Text = "Sundrey Debitor";
                myGroupIdInt = 46;
                tabControl1.TabPages.Remove(tabSundryCreditor);
                bindSettingsSaleRateLabelsToDDl();
                bindMasterTypeToDDl();
                bindLedgerGroupsToDDl(myGroupIdInt);
                bindSundryCreditorsDetailsToGrid(myGroupIdInt);
                ddlAmountType.SelectedIndex = 1;
            }
        }
        protected override void OnShown(EventArgs e)
        {


        }
        private void bindMasterTypeToDDl()
        {
            myMastersInfo.Query = "select * from tblType";
            DataSet typeDetails = myMastersOpr.selectAllMasterDetails(myMastersInfo);

            ddlSDTypeOfCust.DataSource = typeDetails.Tables[0];
            ddlSDTypeOfCust.DisplayMember = "type_name";
            ddlSDTypeOfCust.ValueMember = "type_id";
            ddlSDTypeOfCust.SelectedIndex = -1;


        }
        private void bindSettingsSaleRateLabelsToDDl()
        {


            DataSet typeDetails = mySettingsOpr.selectAllSalesRateLabels();
            ddlSDSalesRate.DataSource = typeDetails.Tables[0];
            ddlSDSalesRate.DisplayMember = "rate_name";
            ddlSDSalesRate.ValueMember = "rate_id";
            ddlSDSalesRate.SelectedIndex = 2;


        }
        private void bindMasterPostToDDl()
        {

            myMastersInfo.Query = "select * from tblPost";
            DataSet typeDetails = myMastersOpr.selectAllMasterDetails(myMastersInfo);
            ddlPost.DataSource = typeDetails.Tables[0];
            ddlPost.DisplayMember = "post_name";
            ddlPost.ValueMember = "post_id";
            ddlPost.SelectedIndex = -1;
        }
        private void bindMasterPlaceToDDl()
        {
            myMastersInfo.Query = "select * from tblPlace";
            DataSet typeDetails = myMastersOpr.selectAllMasterDetails(myMastersInfo);
            ddlPlace.DataSource = typeDetails.Tables[0];
            ddlPlace.DisplayMember = "place_name";
            ddlPlace.ValueMember = "place_Id";
            ddlPlace.SelectedIndex = -1;
        }
        private void bindMasterDistrictToDDl()
        {
            myMastersInfo.Query = "select * from tblDist";
            DataSet typeDetails = myMastersOpr.selectAllMasterDetails(myMastersInfo);
            ddlDistrict.DataSource = typeDetails.Tables[0];
            ddlDistrict.DisplayMember = "dist_name";
            ddlDistrict.ValueMember = "dist_id";
            ddlDistrict.SelectedIndex = -1;
        }
        private void bindMasterStateToDDl()
        {
            myMastersInfo.Query = "select * from tblState";
            DataSet typeDetails = myMastersOpr.selectAllMasterDetails(myMastersInfo);
            ddlState.DataSource = typeDetails.Tables[0];
            ddlState.DisplayMember = "state_name";
            ddlState.ValueMember = "state_Id";
            ddlState.SelectedIndex = -1;
        }
        private void bindMasterAreaToDDl()
        {
            myMastersInfo.Query = "select * from tblArea";
            DataSet typeDetails = myMastersOpr.selectAllMasterDetails(myMastersInfo);
            ddlAera.DataSource = typeDetails.Tables[0];
            ddlAera.DisplayMember = "area_name";
            ddlAera.ValueMember = "area_id";
            ddlAera.SelectedIndex = -1;

        }
        private void bindMasterRouteToDDl()
        {
            myMastersInfo.Query = "select * from tblRoute";
            DataSet typeDetails = myMastersOpr.selectAllMasterDetails(myMastersInfo);

            ddlSCRoute.DataSource = typeDetails.Tables[0];
            ddlSCRoute.DisplayMember = "route_name";
            ddlSCRoute.ValueMember = "route_Id";
            ddlSCRoute.SelectedIndex = -1;

            ddlSDRoute.DataSource = typeDetails.Tables[0];
            ddlSDRoute.DisplayMember = "route_name";
            ddlSDRoute.ValueMember = "route_Id";
            ddlSDRoute.SelectedIndex = -1;
        }

        private void bindMasterCategoryToDDl()
        {


            myMastersInfo.Query = "select * from tblPartyCategory";
            DataSet typeDetails = myMastersOpr.selectAllMasterDetails(myMastersInfo);
            ddlSCCategory.DataSource = typeDetails.Tables[0];
            ddlSCCategory.DisplayMember = "party_category_name";
            ddlSCCategory.ValueMember = "party_category_Id";
            ddlSCCategory.SelectedIndex = -1;

            ddlSDCategory.DataSource = typeDetails.Tables[0];
            ddlSDCategory.DisplayMember = "party_category_name";
            ddlSDCategory.ValueMember = "party_category_Id";

            ddlSDCategory.SelectedIndex = -1;
        }
        private void bindMasterRepToDDl()
        {
            myMastersInfo.Query = "select * from tblRep";
            DataSet typeDetails = myMastersOpr.selectAllMasterDetails(myMastersInfo);
            ddlSCRep.DataSource = typeDetails.Tables[0];
            ddlSCRep.DisplayMember = "rep_name";
            ddlSCRep.ValueMember = "rep_Id";
            ddlSCRep.SelectedIndex = -1;

            ddlSDRep.DataSource = typeDetails.Tables[0];
            ddlSDRep.DisplayMember = "rep_name";
            ddlSDRep.ValueMember = "rep_Id";
            ddlSDRep.SelectedIndex = -1;
        }

        private void unlockControls()
        {
            txtAccountName.ReadOnly = false;
            txtAccountCode.ReadOnly = false;
            txtAlternateName.ReadOnly = false;
            txtDescription.ReadOnly = false;
            ddlGroupName.ReadOnly = false;
            txtOpBalance.ReadOnly = false;
            ddlAmountType.ReadOnly = false;
            ckbActive.ReadOnly = false;

            txtAddress1.ReadOnly = false;
            txtAddress2.ReadOnly = false;
            txtAddress3.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtFax.ReadOnly = false;
            txtMobileNo.ReadOnly = false;
            txtPhoneNo.ReadOnly = false;
            txtPinCode.ReadOnly = false;
            txtWebSite.ReadOnly = false;
            txtTinNo.ReadOnly = false;
            dtpTinDate.ReadOnly = false;
            txtCstNo.ReadOnly = false;
            dtpCstDate.ReadOnly = false;
            txtPan.ReadOnly = false;
            dtpPanDate.ReadOnly = false;
            txtPanRefNo.ReadOnly = false;
            txtTaxDeductionNo.ReadOnly = false;
            dtpTaxDedDate.ReadOnly = false;
            txtServiceTaxReg_No.ReadOnly = false;
            dtpServiceTaxDate.ReadOnly = false;
            txtLuxuryTaxRegNo.ReadOnly = false;
            dtpLuxuryTaxDate.ReadOnly = false;
            txtImportExportCode.ReadOnly = false;
            dtpImportExportDate.ReadOnly = false;

            txtTermsandCondition.ReadOnly = false;


            txtSCDueDays.ReadOnly = false;
            ddlSCNatureOfPurchase.ReadOnly = false;
            ddlSCNatureOfSales.ReadOnly = false;
            txtSCMinBalance.ReadOnly = false;
            ddlSCRoute.ReadOnly = false;
            ddlSCCategory.ReadOnly = false;
            ddlSCRep.ReadOnly = false;

            txtSDDueDays.ReadOnly = false;
            ddlSDNatOfPurchase.ReadOnly = false;
            ddlSDNatOfSale.ReadOnly = false;
            txtSDCreditLimt.ReadOnly = false;
            ddlSDRoute.ReadOnly = false;
            ddlSDCategory.ReadOnly = false;
            ddlSDRep.ReadOnly = false;
            ddlSDTypeOfCust.ReadOnly = false;
            ddlSDSalesRate.ReadOnly = false;
            txtSDSalesDiscount.ReadOnly = false;
            ckbDontPrint.ReadOnly = false;


            txtBankName.ReadOnly = false;
            txtBankAccName.ReadOnly = false;
            txtAccountNo.ReadOnly = false;
            txtBranchName.ReadOnly = false;
            txtIfsc.ReadOnly = false;
            txtSwift.ReadOnly = false;
            txtBsr.ReadOnly = false;
            txtAccountType.ReadOnly = false;
            txtMiscellanoue1.ReadOnly = false;
            txtMiscellanoue2.ReadOnly = false;
            btnSave.Text = "&Update";
            txtAccountName.Focus();
        }
        private bool validateNameFields(string operation)
        {

            if (txtAccountName.Text == "")
            {
                MessageBox.Show("Please enter a Ledger Name.", "True Account Pro",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccountName.Focus();
                return false;
            }

            myLedgerNameInfo.LedgerNameStr = txtAccountName.Text;
            DataSet detailsDts = myLedgerNameOpr.selectALedgerNameDetailsByName(myLedgerNameInfo);
            if (detailsDts.Tables[0].Rows.Count > 0)
            {
                if (operation == "update")
                {
                    if (detailsDts.Tables[0].Rows[0]["ledger_id"].ToString() != myLedgerIdInt.ToString())
                    {
                        MessageBox.Show("This Ledger Name already exists", "True Account Pro",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAccountName.Focus();
                        return false;
                    }
                }


                else
                {
                    MessageBox.Show("This Ledger Name already exists", "True Account Pro",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAccountName.Focus();
                    return false;
                }

            }
            if (txtAccountCode.Text == "")
            {
                MessageBox.Show("Please enter a Ledger Code.", "True Account Pro",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccountCode.Focus();
                return false;
            }
            if (txtAccountName.Text == "")
            {
                MessageBox.Show("Please enter a Name.", "True Account Pro",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAlternateName.Focus();
                return false;
            }
            //myLedgerGroupInfo.GroupName = txtGroupName.Text;
            //DataSet aSubGroupDetails = myLedgerGroupOpr.selectAGroupDetailsByName(myLedgerGroupInfo);
            //if (aSubGroupDetails.Tables[0].Rows.Count > 0)
            //{

            //    MessageBox.Show("This Ledger Name already exists", "True Account Pro",
            //      MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtGroupName.Focus();
            //    return false;

            //}

            if (ddlGroupName.SelectedIndex == -1 || ddlGroupName.Text == "")
            {
                MessageBox.Show("Please select a Ledger Group.", "True Account Pro",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                ddlGroupName.Focus();
                return false;
            }

            return true;
        }
        private bool validateAddressFields()
        {
            int count;

            if (ddlPost.Text != "" && ddlPost.SelectedIndex == -1)
            {
                if (DialogResult.Yes == MessageBox.Show("'" + ddlPost.Text + "'" + " is not available in your Post  Name Masters , You want to add " + "'" + ddlPost.Text + "'" + "to masters ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myMastersInfo.queryStr = "insert into [dbo].[tblPost](post_name) values ('" + ddlPost.Text + "')";
                    myMastersOpr.insertMastersDetails(myMastersInfo);
                    count = ddlPost.Items.Count;
                    bindMasterPostToDDl();
                    ddlPost.SelectedIndex = count;


                }

            }
            if (ddlAera.Text != "" && ddlAera.SelectedIndex == -1)
            {

                if (DialogResult.Yes == MessageBox.Show("'" + ddlAera.Text + "'" + "is not available in your masters registry,You want to add " + "'" + ddlAera.Text + "'" + " ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myMastersInfo.queryStr = "insert into [dbo].[tblArea](area_name) values('" + ddlAera.Text + "')";
                    myMastersOpr.insertMastersDetails(myMastersInfo);
                    count = ddlAera.Items.Count;
                    bindMasterAreaToDDl();
                    ddlAera.SelectedIndex = count;

                }
            }
            if (ddlPlace.Text != "" && ddlPlace.SelectedIndex == -1)
            {

                if (DialogResult.Yes == MessageBox.Show("'" + ddlPlace.Text + "'" + "is not available in your masters registry,You want to add " + "'" + ddlPlace.Text + "'" + " ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myMastersInfo.queryStr = "insert into [dbo].[tblPlace](place_name) values('" + ddlPlace.Text + "')";
                    myMastersOpr.insertMastersDetails(myMastersInfo);
                    count = ddlPlace.Items.Count;
                    bindMasterPlaceToDDl();
                    ddlPlace.SelectedIndex = count;



                }

            }
            if (ddlDistrict.Text != "" && ddlDistrict.SelectedIndex == -1)
            {


                if (DialogResult.Yes == MessageBox.Show("'" + ddlDistrict.Text + "'" + "is not available in your masters registry,You want to add " + "'" + ddlDistrict.Text + "'" + " ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myMastersInfo.queryStr = "insert into [dbo].[tblDist](dist_name) values('" + ddlDistrict.Text + "')";
                    myMastersOpr.insertMastersDetails(myMastersInfo);
                    count = ddlDistrict.Items.Count;
                    bindMasterDistrictToDDl();
                    ddlDistrict.SelectedIndex = count;

                }


            }
            if (ddlState.Text != "" && ddlState.SelectedIndex == -1)
            {
                if (DialogResult.Yes == MessageBox.Show("'" + ddlState.Text + "'" + "is not available in your masters registry,You want to add " + "'" + ddlState.Text + "'" + " ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {
                    myMastersInfo.queryStr = "insert into [dbo].[tblState] (state_name) values ('" + ddlState.Text + "')";
                    myMastersOpr.insertMastersDetails(myMastersInfo);
                    count = ddlState.Items.Count;
                    bindMasterStateToDDl();
                    ddlState.SelectedIndex = count;



                }
            }
            if (ddlAera.SelectedIndex != -1)
            {
                return true;
            }
            else if (ddlPost.SelectedIndex != -1)
            {
                return true;
            }

            else if (ddlPlace.SelectedIndex != -1)
            {
                return true;
            }

            else if (ddlDistrict.SelectedIndex != -1)
            {
                return true;
            }

            else if (ddlState.SelectedIndex != -1)
            {
                return true;
            }
            else if (txtAddress1.Text != "")
            {
                return true;
            }
            else if (txtAddress2.Text != "")
            {
                return true;
            }
            else if (txtAddress3.Text != "")
            {
                return true;
            }

            else if (txtEmail.Text != "")
            {
                return true;
            }
            else if (txtFax.Text != "")
            {
                return true;
            }
            else if (txtMobileNo.Text != "")
            {
                return true;
            }
            else if (txtPhoneNo.Text != "")
            {
                return true;
            }
            else if (txtPinCode.Text != "")
            {
                return true;
            }
            else if (txtWebSite.Text != "")
            {
                return true;
            }



            return false;

        }

        private bool validateRegistrationFields()
        {

            if (txtTinNo.Text != "")
            {
                return true;
            }
            else if (txtCstNo.Text != "")
            {
                return true;
            }
            else if (txtPan.Text != "")
            {
                return true;
            }

            else if (txtPanRefNo.Text != "")
            {
                return true;
            }
            else if (txtTaxDeductionNo.Text != "")
            {
                return true;
            }
            else if (txtServiceTaxReg_No.Text != "")
            {
                return true;
            }
            else if (txtLuxuryTaxRegNo.Text != "")
            {
                return true;
            }
            else if (txtImportExportCode.Text != "")
            {
                return true;
            }
            return false;
        }
        private bool validateTermsAndConditionFields()
        {
            if (txtTermsandCondition.Text != "")
            {

                return true;
            }
            return false;
        }
        private bool validateImageFields()
        {
            if (pcbImage.Image != null)
            {
                return true;
            }
            return false;
        }
        private bool validateBankDetailsFields()
        {
            if (txtBankName.Text != "")
            {
                return true;
            }
            else if (txtBankAccName.Text != "")
            {
                return true;
            }
            else if (txtAccountNo.Text != "")
            {
                return true;
            }
            else if (txtBranchName.Text != "")
            {
                return true;
            }
            else if (txtIfsc.Text != "")
            {
                return true;
            }
            else if (txtSwift.Text != "")
            {
                return true;
            }
            else if (txtBsr.Text != "")
            {
                return true;
            }
            else if (txtAccountType.Text != "")
            {
                return true;
            }
            else if (txtMiscellanoue1.Text != "")
            {
                return true;
            }
            else if (txtMiscellanoue2.Text != "")
            {
                return true;
            }
            return false;
        }
        private bool validateSCOtherDetailsFields()
        {
            int count;
            if (ddlSCRoute.Text != "" && ddlSCRoute.SelectedIndex == -1)
            {
                if (DialogResult.Yes == MessageBox.Show("'" + ddlSCRoute.Text + "'" + " is not available in your Post  Name Masters , You want to add " + "'" + ddlSCRoute.Text + "'" + "to masters ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myMastersInfo.queryStr = "insert into [dbo].[tblRoute](route_name) values('" + ddlSCRoute.Text + "')";
                    myMastersOpr.insertMastersDetails(myMastersInfo);
                    count = ddlSCRoute.Items.Count;
                    bindMasterRouteToDDl();
                    ddlSCRoute.SelectedIndex = count;


                }

            }
            if (ddlSCCategory.Text != "" && ddlSCCategory.SelectedIndex == -1)
            {
                if (DialogResult.Yes == MessageBox.Show("'" + ddlSCCategory.Text + "'" + " is not available in your Post  Name Masters , You want to add " + "'" + ddlSCCategory.Text + "'" + "to masters ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myMastersInfo.queryStr = "insert into [dbo].[tblCategory](category_name) values('" + ddlSCCategory.Text + "')";
                    myMastersOpr.insertMastersDetails(myMastersInfo);
                    count = ddlSCCategory.Items.Count;
                    bindMasterCategoryToDDl();
                    ddlSCCategory.SelectedIndex = count;


                }
            }

            if (ddlSCRep.Text != "" && ddlSCRep.SelectedIndex == -1)
            {
                if (DialogResult.Yes == MessageBox.Show("'" + ddlSCRep.Text + "'" + " is not available in your Post  Name Masters , You want to add " + "'" + ddlSCRep.Text + "'" + "to masters ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myMastersInfo.queryStr = "insert into [dbo].[tblRep] (rep_name) values('" + ddlSCRep.Text + "')";
                    myMastersOpr.insertMastersDetails(myMastersInfo);
                    count = ddlSCRep.Items.Count;
                    bindMasterRepToDDl();
                    ddlSCRep.SelectedIndex = count;




                }
            }
            if (txtSCDueDays.Text != "" && Convert.ToInt64(txtSCDueDays.Text.ToString()) > 0)
            {

                return true;
            }
            else if (ddlSCRoute.SelectedIndex != -1)
            {
                return true;
            }
            else if (ddlSCCategory.SelectedIndex != -1)
            {
                return true;
            }
            else if (ddlSCNatureOfPurchase.SelectedIndex != -1)
            {
                return true;
            }
            else if (ddlSCNatureOfSales.SelectedIndex != -1)
            {
                return true;
            }
            else if (txtSCMinBalance.Text != "" && Convert.ToDecimal(txtSCMinBalance.Text.ToString()) > 0)
            {
                return true;
            }

            else if (ddlSCRep.SelectedIndex != -1)
            {
                return true;
            }

            return false;
        }
        private void validateSDOtherDetailsFields()
        {
            int count;
            if (ddlSDRoute.Text != "" && ddlSDRoute.SelectedIndex == -1)
            {
                if (DialogResult.Yes == MessageBox.Show("'" + ddlSDRoute.Text + "'" + " is not available in your Post  Name Masters , You want to add " + "'" + ddlSDRoute.Text + "'" + "to masters ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myMastersInfo.queryStr = "insert into [dbo].[tblRoute](route_name) values('" + ddlSDRoute.Text + "')";
                    myMastersOpr.insertMastersDetails(myMastersInfo);
                    count = ddlSDRoute.Items.Count;
                    bindMasterRouteToDDl();
                    ddlSDRoute.SelectedIndex = count;


                }

            }
            if (ddlSDCategory.Text != "" && ddlSDCategory.SelectedIndex == -1)
            {
                if (DialogResult.Yes == MessageBox.Show("'" + ddlSDCategory.Text + "'" + " is not available in your Post  Name Masters , You want to add " + "'" + ddlSDCategory.Text + "'" + "to masters ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myMastersInfo.queryStr = "insert into [dbo].[tblCategory](category_name) values('" + ddlSDCategory.Text + "')";
                    myMastersOpr.insertMastersDetails(myMastersInfo);
                    count = ddlSDCategory.Items.Count;
                    bindMasterCategoryToDDl();
                    ddlSDCategory.SelectedIndex = count;


                }
            }

            if (ddlSDRep.Text != "" && ddlSDRep.SelectedIndex == -1)
            {
                if (DialogResult.Yes == MessageBox.Show("'" + ddlSDRep.Text + "'" + " is not available in your Post  Name Masters , You want to add " + "'" + ddlSDRep.Text + "'" + "to masters ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myMastersInfo.queryStr = "insert into [dbo].[tblRep] (rep_name) values('" + ddlSDRep.Text + "')";
                    myMastersOpr.insertMastersDetails(myMastersInfo);
                    count = ddlSDRep.Items.Count;
                    bindMasterRepToDDl();
                    ddlSDRep.SelectedIndex = count;




                }
            }
            if (ddlSDTypeOfCust.Text != "" && ddlSDTypeOfCust.SelectedIndex == -1)
            {
                if (DialogResult.Yes == MessageBox.Show("'" + ddlSDTypeOfCust.Text + "'" + " is not available in your Post  Name Masters , You want to add " + "'" + ddlSDTypeOfCust.Text + "'" + "to masters ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myMastersInfo.queryStr = "insert into tblType (type_name) values('" + ddlSDTypeOfCust.Text + "')";
                    myMastersOpr.insertMastersDetails(myMastersInfo);
                    count = ddlSDTypeOfCust.Items.Count;
                    bindMasterRepToDDl();
                    ddlSDTypeOfCust.SelectedIndex = count;




                }
            }

        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                DbTask.FinalizeCommitTransaction();

                if (btnSave.Text == "&Edit")
                {
                    unlockControls();

                    btnSave.Text = "&Update";

                }
                else
                {
                    
                    setLedgerNameFieldValues();
                    if (btnSave.Text == "&Save")
                    {
                        try
                        {

                            if (validateNameFields("save"))
                            {

                                myLedgerIdInt = myLedgerNameOpr.insertLedgerNameDetails(myLedgerNameInfo);
                                myLedgerNameInfo.LedgerIdInt = myLedgerIdInt;
                                insertLedgerOthers();
                                DbTask.FinalizeCommitTransaction();
                                btnNew_Click(sender, e);
                                RadMessageBox.Show("Successfully saved", "True Account Pro",MessageBoxButtons.OK, RadMessageIcon.Info);
                            }
                        }
                        catch (Exception ex)
                        {
                            DbTask.FinalizeRollBackActivity();
                            throw new Exception(ex.Message);
                        }

                    }
                    else
                    {
                        try
                        {

                            if (validateNameFields("update"))
                            {
                                myLedgerNameInfo.LedgerIdInt = myLedgerIdInt;
                                myLedgerNameOpr.updateLedgerNameDetails(myLedgerNameInfo);
                                myLedgerNameOpr.deleteALedgerAddressDetailsById(myLedgerNameInfo);
                                myLedgerNameOpr.deleteALedgerRegDetailsById(myLedgerNameInfo);
                                myLedgerNameOpr.deleteALedgerOtherDetailsById(myLedgerNameInfo);
                                myLedgerNameOpr.deleteALedgerTermsAndCondById(myLedgerNameInfo);
                                myLedgerNameOpr.deleteALedgerBankDetailsById(myLedgerNameInfo);
                                myLedgerNameOpr.deleteALedgerImageDetailsById(myLedgerNameInfo);

                                insertLedgerOthers();
                                DbTask.FinalizeCommitTransaction();
                                frmSundryCreditor_Load(sender, e);
                                MessageBox.Show("successfully updated", "True Account Pro",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }

                        }
                        catch (Exception ex)
                        {
                            DbTask.FinalizeRollBackActivity();
                            throw new Exception(ex.Message);
                        }

                    }



                }
            }

            catch (Exception ex)
            {
                DbTask.FinalizeRollBackActivity();
               //MessageBox.Show (ex.Message);
            }
        }
        private void insertLedgerOthers()
        {
            if (validateAddressFields())
            {
                setLedgerAddressFieldValues();
                myLedgerNameOpr.insertLedgerAddressDetails(myLedgerNameInfo);
            }
            if (validateRegistrationFields())
            {
                setLedgerRegistFieldValues();
                myLedgerNameOpr.insertLedgerRegistrationDetails(myLedgerNameInfo);
            }
            if (myFormTypeStr == "creditor")
            {
                if (validateSCOtherDetailsFields())
                {
                    setLedgerSCOtherDetailsFieldValues();
                    myLedgerNameOpr.insertLedgerOtherDetails(myLedgerNameInfo);
                }
            }
            else
            {
                validateSDOtherDetailsFields();
                setLedgerSDOtherDetailsFieldValues();
                myLedgerNameOpr.insertLedgerOtherDetails(myLedgerNameInfo);
            }

            if (validateTermsAndConditionFields())
            {

                setLedgerTermsAndConditionFieldValues();
                myLedgerNameOpr.insertTermsAndCondition(myLedgerNameInfo);

            }
            if (validateBankDetailsFields())
            {
                setLedgerBankDetailsFieldValues();
                myLedgerNameOpr.insertLedgerBankDetials(myLedgerNameInfo);
            }


            if (validateImageFields())
            {
                setLedgerImageFieldValues();
                myLedgerNameOpr.insertLedgerImage(myLedgerNameInfo);



            }
        }
        private void setLedgerNameFieldValues()
        {

            myLedgerNameInfo.LedgerNameStr = txtAccountName.Text;
            myLedgerNameInfo.LedgerCodeStr = txtAccountCode.Text;
            myLedgerNameInfo.AlternateNameStr = txtAlternateName.Text;
            myLedgerNameInfo.DescriptionStr = txtDescription.Text;
            myLedgerNameInfo.GroupIdInt = Convert.ToInt64(ddlGroupName.SelectedValue.ToString());
            myLedgerNameInfo.OpeningBalDec = Convert.ToDecimal(txtOpBalance.Text);
            myLedgerNameInfo.OpBalTypeBol = Convert.ToBoolean(ddlAmountType.SelectedIndex);
            myLedgerNameInfo.IsLedgerActive = ckbActive.Checked == true ? true : false;

        }
        private void setLedgerAddressFieldValues()
        {
            myLedgerNameInfo.Address1 = txtAddress1.Text;
            myLedgerNameInfo.Address2 = txtAddress2.Text;
            myLedgerNameInfo.Address3 = txtAddress3.Text;
            myLedgerNameInfo.PinCode = txtPinCode.Text;
            myLedgerNameInfo.PhoneNo = txtPhoneNo.Text;
            myLedgerNameInfo.MobileNo = txtMobileNo.Text;
            myLedgerNameInfo.Fax = txtFax.Text;
            myLedgerNameInfo.Post = ddlPost.SelectedIndex != -1 ? Convert.ToInt64(ddlPost.SelectedValue.ToString()) : 0;
            myLedgerNameInfo.Place = ddlPlace.SelectedIndex != -1 ? Convert.ToInt64(ddlPlace.SelectedValue.ToString()) : 0;
            myLedgerNameInfo.Area = ddlAera.SelectedIndex != -1 ? Convert.ToInt64(ddlAera.SelectedValue.ToString()) : 0;
            myLedgerNameInfo.District = ddlDistrict.SelectedIndex != -1 ? Convert.ToInt64(ddlDistrict.SelectedValue.ToString()) : 0;
            myLedgerNameInfo.State = ddlState.SelectedIndex != -1 ? Convert.ToInt64(ddlState.SelectedValue.ToString()) : 0;
            myLedgerNameInfo.Email = txtEmail.Text;
            myLedgerNameInfo.Web = txtWebSite.Text;
        }
        private void setLedgerRegistFieldValues()
        {

            myLedgerNameInfo.TinNo = txtTinNo.Text;
            myLedgerNameInfo.TinDate = dtpTinDate.Value;
            myLedgerNameInfo.CstNo = txtCstNo.Text;
            myLedgerNameInfo.CstDate = dtpCstDate.Value;
            myLedgerNameInfo.PanNo = txtPan.Text;
            myLedgerNameInfo.PanDate = dtpPanDate.Value;
            myLedgerNameInfo.PanRefNo = txtPanRefNo.Text;
            myLedgerNameInfo.TaxDeductionNo = txtTaxDeductionNo.Text;
            myLedgerNameInfo.TaxDeductionDate = dtpTaxDedDate.Value;
            myLedgerNameInfo.ServiceTaxNo = txtServiceTaxReg_No.Text;
            myLedgerNameInfo.ServiceTaxDate = dtpServiceTaxDate.Value;
            myLedgerNameInfo.LuxuryTaxNo = txtLuxuryTaxRegNo.Text;
            myLedgerNameInfo.LuxuryTaxDate = dtpLuxuryTaxDate.Value;
            myLedgerNameInfo.ImportExportCode = txtImportExportCode.Text;
            myLedgerNameInfo.ImportExportDate = dtpImportExportDate.Value;

        }
        private void setLedgerImageFieldValues()
        {
            myMemmoryStream = new MemoryStream();
            pcbImage.Image.Save(myMemmoryStream, ImageFormat.Jpeg);
            byte[] photo_aray = new byte[myMemmoryStream.Length];
            myMemmoryStream.Position = 0;
            myMemmoryStream.Read(photo_aray, 0, photo_aray.Length);
            myLedgerNameInfo.LedgerImage = photo_aray;
        }
        private void setLedgerBankDetailsFieldValues()
        {
            myLedgerNameInfo.BankName = txtBankName.Text;
            myLedgerNameInfo.BankAccountName = txtBankAccName.Text;
            myLedgerNameInfo.AccountNo = txtAccountNo.Text;
            myLedgerNameInfo.BranchName = txtBranchName.Text;
            myLedgerNameInfo.IfscCode = txtIfsc.Text;
            myLedgerNameInfo.SwiftCode = txtSwift.Text;
            myLedgerNameInfo.BSR = txtBsr.Text;
            myLedgerNameInfo.AccountType = txtAccountType.Text;
            myLedgerNameInfo.Misc1 = txtMiscellanoue1.Text;
            myLedgerNameInfo.Misc2 = txtMiscellanoue2.Text;


        }
        private void setLedgerTermsAndConditionFieldValues()
        {
            myLedgerNameInfo.TermsAndCondition = txtTermsandCondition.Text.ToString();
        }
        private void setLedgerSCOtherDetailsFieldValues()
        {

            myLedgerNameInfo.DueDays = txtSCDueDays.Text != "" ? Convert.ToInt64(txtSCDueDays.Text.ToString()) : 0;
            myLedgerNameInfo.Route = ddlSCRoute.SelectedIndex != -1 ? Convert.ToInt64(ddlSCRoute.SelectedValue.ToString()) : 0;

            myLedgerNameInfo.SalesRate = 0;
            myLedgerNameInfo.Category = ddlSCCategory.SelectedIndex != -1 ? Convert.ToInt64(ddlSCCategory.SelectedValue.ToString()) : 0;

            myLedgerNameInfo.NatureOfPur = ddlSCNatureOfPurchase.Text;
            myLedgerNameInfo.NatureOfSale = ddlSCNatureOfSales.Text;
            myLedgerNameInfo.MinBalance = txtSCMinBalance.Text != "" ? Convert.ToDecimal(txtSCMinBalance.Text.ToString()) : 0;
            myLedgerNameInfo.CreditLimit = 0;
            myLedgerNameInfo.Rep = ddlSCRep.SelectedIndex != -1 ? Convert.ToInt64(ddlSCRep.SelectedValue.ToString()) : 0;
            myLedgerNameInfo.Type = 0;
            myLedgerNameInfo.DisAmount = 0;
            myLedgerNameInfo.IsPrintOB = false;

        }
        private void setLedgerSDOtherDetailsFieldValues()
        {

            myLedgerNameInfo.DueDays = txtSDDueDays.Text != "" ? Convert.ToInt64(txtSDDueDays.Text.ToString()) : 0;
            myLedgerNameInfo.Route = ddlSDRoute.SelectedIndex != -1 ? Convert.ToInt64(ddlSDRoute.SelectedValue.ToString()) : 0;

            myLedgerNameInfo.SalesRate = Convert.ToInt64(ddlSDSalesRate.SelectedValue.ToString());
            myLedgerNameInfo.Category = ddlSDCategory.SelectedIndex != -1 ? Convert.ToInt64(ddlSDCategory.SelectedValue.ToString()) : 0;

            myLedgerNameInfo.NatureOfPur = ddlSDNatOfPurchase.Text;
            myLedgerNameInfo.NatureOfSale = ddlSDNatOfSale.Text;
            myLedgerNameInfo.MinBalance = 0;
            myLedgerNameInfo.CreditLimit = txtSDCreditLimt.Text != "" ? Convert.ToDecimal(txtSDCreditLimt.Text.ToString()) : 0;
            myLedgerNameInfo.Rep = ddlSDRep.SelectedIndex != -1 ? Convert.ToInt64(ddlSDRep.SelectedValue.ToString()) : 0;
            myLedgerNameInfo.Type = ddlSDTypeOfCust.SelectedIndex != -1 ? Convert.ToInt64(ddlSDTypeOfCust.SelectedValue.ToString()) : 0;
            myLedgerNameInfo.DisAmount = txtSDSalesDiscount.Text != "" ? Convert.ToDecimal(txtSDSalesDiscount.Text.ToString()) : 0;
            myLedgerNameInfo.IsPrintOB = ckbDontPrint.Checked == true ? true : false;



        }
        private void clearFields()
        {

            txtAccountName.Text = "";
            txtAccountCode.Text = "";
            txtAlternateName.Text = "";
            txtDescription.Text = "";
            txtOpBalance.Text = "0.00";
            ckbActive.Checked = true;

            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtMobileNo.Text = "";
            txtPhoneNo.Text = "";
            txtPinCode.Text = "";
            txtWebSite.Text = "";
            txtTinNo.Text = "";
            dtpTinDate.Value = DateTime.Now;
            txtCstNo.Text = "";
            dtpCstDate.Value = DateTime.Now;
            txtPan.Text = "";
            dtpPanDate.Value = DateTime.Now;
            txtPanRefNo.Text = "";
            txtTaxDeductionNo.Text = "";
            dtpTaxDedDate.Value = DateTime.Now;
            txtServiceTaxReg_No.Text = "";
            dtpServiceTaxDate.Value = DateTime.Now;
            txtLuxuryTaxRegNo.Text = "";
            dtpLuxuryTaxDate.Value = DateTime.Now;
            txtImportExportCode.Text = "";
            dtpImportExportDate.Value = DateTime.Now;

            txtTermsandCondition.Text = "";
            txtSCDueDays.Text = "";
            ddlSCNatureOfPurchase.SelectedIndex = -1;
            ddlSCNatureOfSales.SelectedIndex = -1;
            txtSCMinBalance.Text = "0.00";

            txtSDDueDays.Text = "";
            ddlSDNatOfPurchase.SelectedIndex = -1;
            ddlSDNatOfSale.SelectedIndex = -1;
            txtSDCreditLimt.Text = "0.00";
            ddlSDRoute.SelectedIndex = -1;
            ddlSDCategory.SelectedIndex = -1;
            ddlSDRep.SelectedIndex = -1;
            ddlSDTypeOfCust.SelectedIndex = -1;
          
            txtSDSalesDiscount.Text = "";
            ckbDontPrint.Checked = false;


            txtTermsandCondition.Text = "";

            txtBankName.Text = "";
            txtBankAccName.Text = "";
            txtAccountNo.Text = "";
            txtBranchName.Text = "";
            txtIfsc.Text = "";
            txtSwift.Text = "";
            txtBsr.Text = "";
            txtAccountType.Text = "";
            txtMiscellanoue1.Text = "";
            txtMiscellanoue2.Text = "";

            pcbImage.Image = null;

            txtAccountName.Focus();
            unlockControls();
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            isLoadCmplt = false;


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        //{
        //    //if (keyData == Keys.Escape)
        //    //{
        //    //    this.Close();
        //    //}

        //    //else 
        //    if (myFocusReg)
        //    {
        //        tabControl1.SelectedTab = tabPage2;
        //        txtTinNo.Focus();

        //    }
        //    else if (myFocusSDOth)
        //    {
        //        tabControl1.SelectedTab = tabSundryDebitor;
        //        txtSDDueDays.Focus();
        //    }
        //    else if (myFocusSCOth)
        //    {
        //        tabControl1.SelectedTab = tabSundryCreditor;
        //        txtSCDueDays.Focus();
        //    }
        //    else if (msg.WParam.ToInt32() == (int)Keys.Enter)
        //    {
        //        SendKeys.Send("{Tab}");
        //        return true;
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);

        //}
        private void frmSundryCreditor_Load(object sender, EventArgs e)
        {


            clearFields();
            formSettings();
            bindMasterAreaToDDl();
            bindMasterCategoryToDDl();
            bindMasterDistrictToDDl();
            bindMasterPlaceToDDl();
            bindMasterPostToDDl();
            bindMasterRepToDDl();
            bindMasterRouteToDDl();
            bindMasterStateToDDl();

            isLoadCmplt = true;
        }

        private void bindSundryCreditorsDetailsToGrid(int groupId)
        {
            dgvSundryDetails.Rows.Clear();
            myLedgerNameInfo.GroupIdInt = groupId;
            DataSet details = myLedgerNameOpr.selectAllLedgerNameByGroupId(myLedgerNameInfo);
            for (int i = 0; i < details.Tables[0].Rows.Count; i++)
            {
                dgvSundryDetails.Rows.AddNew();
                dgvSundryDetails.Rows[i].Cells["clmLedgerId"].Value = details.Tables[0].Rows[i]["ledger_id"].ToString();
                dgvSundryDetails.Rows[i].Cells["clmLedgerCode"].Value = details.Tables[0].Rows[i]["ledger_code"].ToString();
                dgvSundryDetails.Rows[i].Cells["clmLedgerName"].Value = details.Tables[0].Rows[i]["ledger_name"].ToString();

            }

            isLoadCmplt = true;
        }
        private void bindLedgerGroupsToDDl(int selectedValue)
        {
            DataSet ledgerGroupsDts = myLedgerGroupOpr.selectAllParentAndSubGroupDetails();
            ddlGroupName.DataSource = ledgerGroupsDts.Tables[0];
            ddlGroupName.DisplayMember = "group_name";
            ddlGroupName.ValueMember = "group_id";
            ddlGroupName.SelectedValue = selectedValue;
            ddlGroupName.Enabled = false;
        }

        private void btnupload_Click(object sender, EventArgs e)
        {
            // ofdImage as=new OpenFileDialog
            OpenFileDialog ofdImage = new OpenFileDialog();///JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png||
            ofdImage.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" +
                              "All files (*.*)|*.*";
            ofdImage.Title = "Please select an image file";
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {

                pcbImage.Image = Image.FromFile(ofdImage.FileName);


            }




        }

        private void btnremove_Click(object sender, EventArgs e)
        {


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSundryCreditor_Load(sender, e);
        }
        private void lockAllControls()
        {
            txtAccountName.ReadOnly = true;
            txtAccountCode.ReadOnly = true;
            txtAlternateName.ReadOnly = true;
            txtDescription.ReadOnly = true;
            txtOpBalance.ReadOnly = true;
            ddlAmountType.ReadOnly = true;
            ckbActive.ReadOnly = true;

            txtAddress1.ReadOnly = true;
            txtAddress2.ReadOnly = true;
            txtAddress3.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtFax.ReadOnly = true;
            txtMobileNo.ReadOnly = true;
            txtPhoneNo.ReadOnly = true;
            txtPinCode.ReadOnly = true;
            txtWebSite.ReadOnly = true;
            txtTinNo.ReadOnly = true;
            dtpTinDate.ReadOnly = true;
            txtCstNo.ReadOnly = true;
            dtpCstDate.ReadOnly = true;
            txtPan.ReadOnly = true;
            dtpPanDate.ReadOnly = true;
            txtPanRefNo.ReadOnly = true;
            txtTaxDeductionNo.ReadOnly = true;
            dtpTaxDedDate.ReadOnly = true;
            txtServiceTaxReg_No.ReadOnly = true;
            dtpServiceTaxDate.ReadOnly = true;
            txtLuxuryTaxRegNo.ReadOnly = true;
            dtpLuxuryTaxDate.ReadOnly = true;
            txtImportExportCode.ReadOnly = true;
            dtpImportExportDate.ReadOnly = true;

            txtTermsandCondition.ReadOnly = true;

            txtSCDueDays.ReadOnly = true;
            ddlSCNatureOfPurchase.ReadOnly = true;
            ddlSCNatureOfSales.ReadOnly = true;
            txtSCMinBalance.ReadOnly = true;
            ddlSCRoute.ReadOnly = true;
            ddlSCCategory.ReadOnly = true;
            ddlSCRep.ReadOnly = true;

            txtSDDueDays.ReadOnly = true;
            ddlSDNatOfPurchase.ReadOnly = true;
            ddlSDNatOfSale.ReadOnly = true;
            txtSDCreditLimt.ReadOnly = true;
            ddlSDRoute.ReadOnly = true;
            ddlSDCategory.ReadOnly = true;
            ddlSDRep.ReadOnly = true;
            ddlSDTypeOfCust.ReadOnly = true;
            ddlSDSalesRate.ReadOnly = true;
            txtSDSalesDiscount.ReadOnly = true;
            ckbDontPrint.ReadOnly = true;



            txtBankName.ReadOnly = true;
            txtBankAccName.ReadOnly = true;
            txtAccountNo.ReadOnly = true;
            txtBranchName.ReadOnly = true;
            txtIfsc.ReadOnly = true;
            txtSwift.ReadOnly = true;
            txtBsr.ReadOnly = true;
            txtAccountType.ReadOnly = true;
            txtMiscellanoue1.ReadOnly = true;
            txtMiscellanoue2.ReadOnly = true;
        }
        private void ddlSearchAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadCmplt)
            {
                //  selectLegerDetails(Convert.ToInt64(ddlSearchAccount.SelectedValue));

            }

        }
        private void selectLegerDetails(long ledgerID)

        {
            myLedgerNameInfo.LedgerIdInt = ledgerID;
            myLedgerNameDts = myLedgerNameOpr.selectALedgerNameDetailsById(myLedgerNameInfo);
            myLedgerAddressDts = myLedgerNameOpr.selectALedgerAddressDetailsById(myLedgerNameInfo);
            myLedgerRegDts = myLedgerNameOpr.selectALedgerRegDetailsById(myLedgerNameInfo);
            myLedgerOtherDts = myLedgerNameOpr.selectALedgerOtherDetailsById(myLedgerNameInfo);
            myLedgerTandCDts = myLedgerNameOpr.selectALedgerTermsAndCondById(myLedgerNameInfo);
            myLedgerBankDts = myLedgerNameOpr.selectALedgerBankDetailsById(myLedgerNameInfo);
            myLedgerImageDts = myLedgerNameOpr.selectALedgerImageDetailsById(myLedgerNameInfo);
            if (myLedgerNameDts.Tables[0].Rows.Count > 0)
            {
                fillLedgerNameFileds(myLedgerNameDts);
                btnSave.Text = "&Edit";
                btnDelete.Enabled = true;
                lockAllControls();


            }
            if (myLedgerAddressDts.Tables[0].Rows.Count > 0)
            {
                fillLedgerAddressFileds(myLedgerAddressDts);
            }
            if (myLedgerRegDts.Tables[0].Rows.Count > 0)
            {
                fillLedgerRegistrationFileds(myLedgerRegDts);
            }

            if (myLedgerOtherDts.Tables[0].Rows.Count > 0)
            {
                if (myFormTypeStr == "creditor")
                {
                    fillLedgerSCOtherDetailsFileds(myLedgerOtherDts);
                }
                else
                {
                    fillLedgerSDOtherDetailsFileds(myLedgerOtherDts);
                }
            }
            if (myLedgerTandCDts.Tables[0].Rows.Count > 0)
            {
                fillLedgerTermsAndCondiFileds(myLedgerTandCDts);
            }
            if (myLedgerBankDts.Tables[0].Rows.Count > 0)
            {
                fillLedgerBankDetailsFileds(myLedgerBankDts);
            }
            if (myLedgerImageDts.Tables[0].Rows.Count > 0)
            {
                fillLedgerImageFileds(myLedgerImageDts);
            }

        }
        private void fillLedgerNameFileds(DataSet details)
        {
            txtAccountName.Text = details.Tables[0].Rows[0]["ledger_name"].ToString();
            txtAccountCode.Text = details.Tables[0].Rows[0]["ledger_code"].ToString();
            txtAlternateName.Text = details.Tables[0].Rows[0]["alternate_name"].ToString();
            txtDescription.Text = details.Tables[0].Rows[0]["description"].ToString();
            ddlGroupName.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["group_id"].ToString());
            txtOpBalance.Text = details.Tables[0].Rows[0]["op_balance"].ToString();
            ddlAmountType.SelectedIndex = Convert.ToBoolean(details.Tables[0].Rows[0]["balance_type"].ToString()) == true ? 1 : 0;
            ckbActive.Checked = Convert.ToBoolean(details.Tables[0].Rows[0]["is_active"].ToString()) == true ? true : false;
            myLedgerIsFixed = Convert.ToBoolean(details.Tables[0].Rows[0]["fixed"].ToString());

        }
        private void fillLedgerAddressFileds(DataSet details)
        {
            ddlPost.SelectedIndex = -1;
            ddlPlace.SelectedIndex = -1;
            ddlAera.SelectedIndex = -1;
            ddlDistrict.SelectedIndex = -1;
            ddlState.SelectedIndex = -1;

            txtAddress1.Text = details.Tables[0].Rows[0]["address_1"].ToString();
            txtAddress2.Text = details.Tables[0].Rows[0]["address_2"].ToString();
            txtAddress3.Text = details.Tables[0].Rows[0]["address_3"].ToString();
            txtPinCode.Text = details.Tables[0].Rows[0]["pincode"].ToString();
            txtPhoneNo.Text = details.Tables[0].Rows[0]["phone_no"].ToString();
            txtMobileNo.Text = details.Tables[0].Rows[0]["mobile_no"].ToString();
            txtFax.Text = details.Tables[0].Rows[0]["fax"].ToString();
            ddlPost.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["post"].ToString());
            ddlPlace.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["place"].ToString());
            ddlAera.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["area"].ToString());
            ddlDistrict.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["district"].ToString());
            ddlState.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["state"].ToString());
            txtEmail.Text = details.Tables[0].Rows[0]["email"].ToString();
            txtWebSite.Text = details.Tables[0].Rows[0]["website"].ToString();

        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete ?  ", "True Account Pro", MessageBoxButtons.YesNo))
            {
                myLedgerNameOpr.deleteALedgerNameDetailsById(myLedgerNameInfo);
                myLedgerNameOpr.deleteALedgerAddressDetailsById(myLedgerNameInfo);
                myLedgerNameOpr.deleteALedgerRegDetailsById(myLedgerNameInfo);
                myLedgerNameOpr.deleteALedgerOtherDetailsById(myLedgerNameInfo);
                myLedgerNameOpr.deleteALedgerBankDetailsById(myLedgerNameInfo);
                myLedgerNameOpr.deleteALedgerTermsAndCondById(myLedgerNameInfo);
                myLedgerNameOpr.deleteALedgerImageDetailsById(myLedgerNameInfo);


                MessageBox.Show("Successfully deleted.", "True Account Pro",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNew_Click(sender, e);

            }
            else
            {
                txtAccountName.Focus();
            }
        }

        private void dgvSundryDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int rowIndex;
            if (dgvSundryDetails.CurrentCell != null)
            {
                clearFields();
                rowIndex = dgvSundryDetails.CurrentCell.RowIndex;
                myLedgerIdInt = Convert.ToInt64(dgvSundryDetails.Rows[rowIndex].Cells["clmLedgerId"].Value.ToString());
                selectLegerDetails(myLedgerIdInt);
            }
        }

        private void txtOpBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ddlAmountType.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtDescription.Focus();
            }
            else
            {
                NumericValidatorInfo.RestrictDecimal(ref e, txtOpBalance.Text.Trim(), txtOpBalance.SelectionStart, 10, 2);

            }
        }

        private void txtOpBalance_Leave(object sender, EventArgs e)
        {
            txtOpBalance.Text = myGenaralFunctions.FormatDecimalPlace(txtOpBalance.Text.Trim(), 2);

        }

        private void txtOpBalance_TextChanged(object sender, EventArgs e)
        {
            txtOpBalance.Text = myGenaralFunctions.ValidateInput(txtOpBalance.Text);
        }

        private void txtSCMinBalance_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)
            {
                ddlSCRoute.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtSCDueDays.Focus();
            }
            else
            {
                NumericValidatorInfo.RestrictDecimal(ref e, txtSCMinBalance.Text.Trim(), txtSCMinBalance.SelectionStart, 10, 2);
            }
        }

        private void txtSDCreditLimt_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.Enter)
            {
                ddlSDRoute.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtSCDueDays.Focus();
            }
            else
            {
                NumericValidatorInfo.RestrictDecimal(ref e, txtSDCreditLimt.Text.Trim(), txtSDCreditLimt.SelectionStart, 10, 2);

            }
        }

        private void txtSDCreditLimt_Leave(object sender, EventArgs e)
        {
            txtSDCreditLimt.Text = myGenaralFunctions.FormatDecimalPlace(txtSDCreditLimt.Text.Trim(), 2);
        }

        private void txtSCMinBalance_Leave(object sender, EventArgs e)
        {
            txtSCMinBalance.Text = myGenaralFunctions.FormatDecimalPlace(txtSCMinBalance.Text.Trim(), 2);
        }

        private void txtSCMinBalance_TextChanged(object sender, EventArgs e)
        {
            txtSCMinBalance.Text = myGenaralFunctions.ValidateInput(txtSCMinBalance.Text);
        }

        private void txtSDCreditLimt_TextChanged(object sender, EventArgs e)
        {
            txtSDCreditLimt.Text = myGenaralFunctions.ValidateInput(txtSDCreditLimt.Text);
        }

        private void txtSDDueDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSDCreditLimt.Focus();

            }

            else if (e.KeyCode == Keys.Escape)
            {
                tabControl1.SelectedTab = tabPage2;

                dtpLuxuryTaxDate.Focus();
            }
            else
            {
                myGenaralFunctions.RestrictIntegerCharacters(ref e);
            }
        }

        private void txtSCDueDays_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtSCMinBalance.Focus();
            }

            else if (e.KeyCode == Keys.Escape)
            {
                tabControl1.SelectedTab = tabPage2;

                dtpLuxuryTaxDate.Focus();
            }
            else
            {


                myGenaralFunctions.RestrictIntegerCharacters(ref e);
            }
        }

        private void txtWebSite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControl1.SelectedTab = tabPage2;
                txtTinNo.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtEmail.Focus();
            }
        }

        private void txtWebSite_Enter(object sender, EventArgs e)
        {
            // myFocusReg = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //myFocusReg = false;
            //myFocusSCOth = false;
            //myFocusSDOth = false;
        }

        private void dtpImportExportDate_Enter(object sender, EventArgs e)
        {
            //if(myFormTypeStr=="creditor")
            // {
            //     myFocusSCOth = true;
            // }
            //else
            // {
            //     myFocusSDOth = true;
            // }
        }

        private void fillLedgerRegistrationFileds(DataSet details)
        {

            txtTinNo.Text = details.Tables[0].Rows[0]["tin_no"].ToString();
            dtpTinDate.Value = Convert.ToDateTime(details.Tables[0].Rows[0]["tin_date"].ToString());
            txtCstNo.Text = details.Tables[0].Rows[0]["cst_no"].ToString();
            dtpCstDate.Value = Convert.ToDateTime(details.Tables[0].Rows[0]["cst_date"].ToString());
            txtPan.Text = details.Tables[0].Rows[0]["pan_no"].ToString();
            dtpPanDate.Value = Convert.ToDateTime(details.Tables[0].Rows[0]["pan_date"].ToString());
            txtPanRefNo.Text = details.Tables[0].Rows[0]["pan_ref_no"].ToString();
            txtTaxDeductionNo.Text = details.Tables[0].Rows[0]["tax_deduction_no"].ToString();
            dtpTaxDedDate.Value = Convert.ToDateTime(details.Tables[0].Rows[0]["tax_deduction_date"].ToString());
            txtServiceTaxReg_No.Text = details.Tables[0].Rows[0]["service_tax_reg_no"].ToString();
            dtpServiceTaxDate.Value = Convert.ToDateTime(details.Tables[0].Rows[0]["service_tax_reg_date"].ToString());
            txtLuxuryTaxRegNo.Text = details.Tables[0].Rows[0]["luxury_tax_reg_no"].ToString();
            dtpLuxuryTaxDate.Value = Convert.ToDateTime(details.Tables[0].Rows[0]["luxury_tax_reg_date"].ToString());
            txtImportExportCode.Text = details.Tables[0].Rows[0]["import_export_code"].ToString();
            dtpImportExportDate.Value = Convert.ToDateTime(details.Tables[0].Rows[0]["import_export_date"].ToString());
        }

        private void btnAddPost_Click(object sender, EventArgs e)
        {
            openMasterForm("Post");
        }
        private void openMasterForm(string fromType)
        {
            frmMasters masters = new TrueAccountPro.frmMasters(fromType);
            masters.Show();
        }

        private void btnAddPlace_Click(object sender, EventArgs e)
        {
            openMasterForm("Place");
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            openMasterForm("Area");
        }

        private void btnAddDistrict_Click(object sender, EventArgs e)
        {
            openMasterForm("District");
        }

        private void btnAddState_Click(object sender, EventArgs e)
        {
            openMasterForm("State");
        }

        private void btnAddScRoute_Click(object sender, EventArgs e)
        {
            openMasterForm("Route");
        }

        private void btnAddScRep_Click(object sender, EventArgs e)
        {
            openMasterForm("Rep.");
        }

        private void btnAddScCateg_Click(object sender, EventArgs e)
        {
            openMasterForm("Category");
        }

        private void btnAddSDTypeCust_Click(object sender, EventArgs e)
        {
            openMasterForm("Type");
        }

        private void frmSundryCreditor_Enter(object sender, EventArgs e)
        {
            long areaId = Convert.ToInt64(ddlAera.SelectedValue.ToString());
            long scCategoryId = Convert.ToInt64(ddlSCCategory.SelectedValue.ToString());
            long sDCategoryId = Convert.ToInt64(ddlSDCategory.SelectedValue.ToString());
            long distId = Convert.ToInt64(ddlDistrict.SelectedValue.ToString());
            long placeId = Convert.ToInt64(ddlPlace.SelectedValue.ToString());
            long postId = Convert.ToInt64(ddlPost.SelectedValue.ToString());
            long sCRepId = Convert.ToInt64(ddlSCRep.SelectedValue.ToString());
            long sDRepId = Convert.ToInt64(ddlSDRep.SelectedValue.ToString());
            long sCRoute = Convert.ToInt64(ddlSCRoute.SelectedValue.ToString());
            long sdRoute = Convert.ToInt64(ddlSDRoute.SelectedValue.ToString());
            long state = Convert.ToInt64(ddlState.SelectedValue.ToString());
            long type = Convert.ToInt64(ddlSDTypeOfCust.SelectedValue.ToString());

            bindMasterAreaToDDl();
            bindMasterCategoryToDDl();
            bindMasterDistrictToDDl();
            bindMasterPlaceToDDl();
            bindMasterPostToDDl();
            bindMasterRepToDDl();
            bindMasterRouteToDDl();
            bindMasterStateToDDl();
            bindMasterTypeToDDl();

            ddlAera.SelectedValue = areaId;
            ddlSCCategory.SelectedValue = scCategoryId;
            ddlSDCategory.SelectedValue = sDCategoryId;
            ddlDistrict.SelectedValue = distId;
            ddlPlace.SelectedValue = placeId;
            ddlPost.SelectedValue = postId;
            ddlSCRep.SelectedValue = sCRepId;
            ddlSDRep.SelectedValue = sDRepId;
            ddlSCRoute.SelectedValue = sCRoute;
            ddlSDRoute.SelectedValue = sdRoute;
            ddlState.SelectedValue = state;
            ddlSDTypeOfCust.SelectedValue = type;

        }




        public void focusPrevousNextControls(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                SendKeys.Send("+{TAB}");
            }

        }







        private void txtAccountCode_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void ddlAmountType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress1.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtOpBalance.Focus();
            }
        }

        private void txtAccountName_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }



        private void txtAlternateName_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void ddlGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtAddress1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress2.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                ddlAmountType.Focus();
            }
        }

        private void txtAddress2_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtAddress3_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtPinCode_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }


        private void txtFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ddlPost.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtMobileNo.Focus();
            }
        }

        private void ddlPost_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void ddlPlace_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void ddlAera_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void ddlDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }



        private void ddlState_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtTinNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                dtpTinDate.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                tabControl1.SelectedTab = tabPage1;
                txtWebSite.Focus();
            }
        }

        private void dtpTinDate_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtCstNo_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void dtpCstDate_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtPan_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void dtpPanDate_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtPanRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtTaxDeductionNo_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void dtpTaxDedDate_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtServiceTaxReg_No_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void dtpServiceTaxDate_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtLuxuryTaxRegNo_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void dtpLuxuryTaxDate_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void txtImportExportCode_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void dtpImportExportDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && myFormTypeStr == "creditor")
            {
                tabControl1.SelectedTab = tabSundryCreditor;
                txtSCDueDays.Focus();
            }
            else if (e.KeyCode == Keys.Enter && myFormTypeStr == "debitor")
            {
                tabControl1.SelectedTab = tabSundryDebitor;
                txtSDDueDays.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                dtpLuxuryTaxDate.Focus();
            }


        }

        private void ddlSCRoute_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void ddlSCRep_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void ddlSCCategory_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void ddlSCNatureOfPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);
        }

        private void ddlSCNatureOfSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControl1.SelectedTab = tabPage4;
                txtTermsandCondition.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                ddlSCNatureOfPurchase.Focus();
            }
        }

        private void ddlSDRoute_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);

        }

        private void ddlSDRep_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);

        }

        private void ddlSDSalesRate_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);

        }

        private void ddlSDTypeOfCust_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);

        }

        private void ddlSDCategory_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);

        }

        private void txtSDSalesDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);

        }

        private void ddlSDNatOfSale_KeyDown(object sender, KeyEventArgs e)
        {
            focusPrevousNextControls(e);

        }

        private void ddlSDNatOfPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControl1.SelectedTab = tabPage4;
                txtTermsandCondition.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                ddlSDNatOfSale.Focus();
            }

        }

        private void txtTermsandCondition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tabControl1.SelectedTab = tabPage5;
                txtBankName.Focus();
            }
            else if (e.KeyCode == Keys.Escape && myFormTypeStr == "debitor")
            {
                tabControl1.SelectedTab = tabSundryDebitor;
                ddlSDNatOfPurchase.Focus();
            }
            else if (e.KeyCode == Keys.Escape && myFormTypeStr == "creditor")
            {
                dtpLuxuryTaxDate.Focus();
                ddlSCNatureOfSales.Focus();
            }
        }

        private void txtBankName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtBankAccName.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                tabControl1.SelectedTab = tabPage4;
                txtTermsandCondition.Focus();
            }

        }

        private void txtBankAccName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtIfsc_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSwift_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtBsr_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtAccountType_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtMiscellanoue1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtMiscellanoue2_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void fillLedgerSDOtherDetailsFileds(DataSet details)
        {
            ddlSDRoute.SelectedIndex = -1;
            //ddlSDSalesRate.SelectedIndex = -1;
            ddlSDCategory.SelectedIndex = -1;
            ddlSDRep.SelectedIndex = -1;


            txtSDDueDays.Text = Convert.ToDecimal(details.Tables[0].Rows[0]["due_days"].ToString()) == 0 ? "" : details.Tables[0].Rows[0]["due_days"].ToString();
            ddlSDRoute.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["route"].ToString());
            ddlSDSalesRate.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["sales_rate"].ToString());
            ddlSDCategory.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["category"].ToString());
            ddlSDNatOfPurchase.Text = details.Tables[0].Rows[0]["nature_of_purchase"].ToString();
            ddlSDNatOfSale.Text = details.Tables[0].Rows[0]["nature_of_sale"].ToString();
            txtSDCreditLimt.Text = Convert.ToDecimal(details.Tables[0].Rows[0]["credit_limit"].ToString()) == 0 ? "" : details.Tables[0].Rows[0]["credit_limit"].ToString();
            ddlSDRep.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["represantative"].ToString());
            ddlSDTypeOfCust.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["type_of_customer"].ToString());
            txtSDSalesDiscount.Text = Convert.ToDecimal(details.Tables[0].Rows[0]["sales_discount"].ToString()) == 0 ? "" : details.Tables[0].Rows[0]["sales_discount"].ToString();
            ckbDontPrint.Checked = Convert.ToBoolean(details.Tables[0].Rows[0]["is_print_ob"].ToString()) == true ? true : false;
             
        }
        private void fillLedgerSCOtherDetailsFileds(DataSet details)
        {
            ddlSCRoute.SelectedIndex = -1;

            ddlSCCategory.SelectedIndex = -1;
            ddlSCRep.SelectedIndex = -1;

            ddlSCRoute.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["route"].ToString());
            ddlSCCategory.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["category"].ToString());

            ddlSCRep.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["represantative"].ToString());

            txtSCDueDays.Text = Convert.ToDecimal(details.Tables[0].Rows[0]["due_days"].ToString()) == 0 ? "" : details.Tables[0].Rows[0]["due_days"].ToString();
            ddlSCRoute.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["route"].ToString());
            ddlSCCategory.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["category"].ToString());

            ddlSCNatureOfPurchase.Text = details.Tables[0].Rows[0]["nature_of_purchase"].ToString();
            ddlSCNatureOfSales.Text = details.Tables[0].Rows[0]["nature_of_sale"].ToString();
            txtSCMinBalance.Text = Convert.ToDecimal(details.Tables[0].Rows[0]["minimum_balance"].ToString()) == 0 ? "" : details.Tables[0].Rows[0]["minimum_balance"].ToString();
            ddlSCRep.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["represantative"].ToString());
        }
        private void fillLedgerTermsAndCondiFileds(DataSet details)
        {
            txtTermsandCondition.Text = details.Tables[0].Rows[0]["terms_and_conditions"].ToString();
        }
        private void fillLedgerBankDetailsFileds(DataSet details)
        {

            txtBankName.Text = details.Tables[0].Rows[0]["bank_name"].ToString();
            txtBankAccName.Text = details.Tables[0].Rows[0]["account_name"].ToString();
            txtAccountNo.Text = details.Tables[0].Rows[0]["account_no"].ToString();
            txtBranchName.Text = details.Tables[0].Rows[0]["branch_name"].ToString();
            txtIfsc.Text = details.Tables[0].Rows[0]["ifsc"].ToString();
            txtSwift.Text = details.Tables[0].Rows[0]["swift"].ToString();
            txtBsr.Text = details.Tables[0].Rows[0]["bsr"].ToString();
            txtAccountType.Text = details.Tables[0].Rows[0]["account_type"].ToString();
            txtMiscellanoue1.Text = details.Tables[0].Rows[0]["misc1"].ToString();
            txtMiscellanoue2.Text = details.Tables[0].Rows[0]["misc2"].ToString();
        }
        private void fillLedgerImageFileds(DataSet details)
        {

            if (details.Tables[0].Rows.Count > 0)

            {



                Byte[] data = new Byte[10000];
                data = (Byte[])(details.Tables[0].Rows[0]["ledger_image"]);
                MemoryStream mem = new MemoryStream(data);
                pcbImage.Image = Image.FromStream(mem);
                pcbImage.Image.Save("FormTwo.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }

        }
    }
}
