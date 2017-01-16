using BAL;
using BEL;
using BEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;

namespace TrueAccountPro
{
    public partial class frmLedgerName : Telerik.WinControls.UI.RadForm
    {
        ledgerNameInfo myLedgerNameInfo = new ledgerNameInfo();
        ledgerGroupInfo myLedgerGroupInfo = new ledgerGroupInfo();

        ledgerNameOpr myLedgerNameOpr = new ledgerNameOpr();
        ledgerGroupOpr myLedgerGroupOpr = new ledgerGroupOpr();

        
        TreeNode myParentNode;

        long myLedgerId;
        bool myLedgerIsFixed;
        bool isLoadCmplt = false;

        public frmLedgerName()
        {
            InitializeComponent();
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            frmLedgerGroup ledgerGroup = new TrueAccountPro.frmLedgerGroup();

            ledgerGroup.Show();
        }

        private void frmLedgerName_Load(object sender, EventArgs e)
        {
            clearFields();
            bindLedgerGroupsToDDl();
            bindLedgerNameDetailsToDDL();
          
        }
        private void bindLedgerNameDetailsToDDL()
        {
          DataSet details=  myLedgerNameOpr.selectAllLedgerNameDetails();
            ddlSearchAccount.DataSource = details.Tables[0];
            ddlSearchAccount.DisplayMember = "ledger_name";
            ddlSearchAccount.ValueMember = "ledger_id";
            ddlSearchAccount.Columns["ledger_id"].IsVisible = false;
            ddlSearchAccount.Columns["op_balance"].IsVisible = false;
            ddlSearchAccount.Columns["fixed"].IsVisible = false;
            ddlSearchAccount.Columns["balance_type"].IsVisible = false;
            ddlSearchAccount.Columns["description"].IsVisible = false;
            ddlSearchAccount.Columns["is_active"].IsVisible = false;
            ddlSearchAccount.Columns["alternate_name"].IsVisible = false;
            ddlSearchAccount.Columns["ledger_name"].HeaderText = "Name";
            ddlSearchAccount.Columns["ledger_code"].HeaderText = "Code";


            
            FilterDescriptor descriptor = new FilterDescriptor(ddlSearchAccount.DisplayMember, FilterOperator.StartsWith, string.Empty);
            this.ddlSearchAccount.EditorControl.FilterDescriptors.Add(descriptor);
            //set the AutoCompleteMode property to one of modes Append, None, Suggest, SuggestAppend
            ddlSearchAccount.MultiColumnComboBoxElement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;

            //this.ddlSearchAccount.AutoFilter = true;
            //CompositeFilterDescriptor compositeFilter = new CompositeFilterDescriptor();
            //FilterDescriptor prodName = new FilterDescriptor("ledger_name", FilterOperator.Contains, "");
            //FilterDescriptor prodQuantity = new FilterDescriptor("ledger_code", FilterOperator.Contains, "");
            //compositeFilter.FilterDescriptors.Add(prodName);
            //compositeFilter.FilterDescriptors.Add(prodQuantity);
            //compositeFilter.LogicalOperator = FilterLogicalOperator.Or;
            //this.ddlSearchAccount.EditorControl.FilterDescriptors.Add(compositeFilter);
            ddlSearchAccount.SelectedIndex = -1;
            isLoadCmplt = true;
         

        }
        private bool validateFields()
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

                MessageBox.Show("This Ledger Name already exists", "True Account Pro",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccountName.Focus();
                return false;

            }
            if (txtAccountCode .Text == "")
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
        private void controlsUnlock()
        {
            txtAccountName.ReadOnly = false;
            txtAccountCode.ReadOnly = false;
            txtAlternateName.ReadOnly = false;
            txtDescription.ReadOnly = false;
            ddlGroupName.ReadOnly = false;
            txtOpBalance.ReadOnly = false;
            ddlAmountType.ReadOnly = false;
            ckbActive.ReadOnly = false;
            btnSave.Text = "&Update";
            txtAccountName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "&Edit")
            {
                controlsUnlock();
                    
                btnSave.Text = "&Update";
           
            }
            else
            {
                if (validateFields())
                {
                    setFieldValues();
                    if (btnSave.Text == "&Save")
                    {

                        myLedgerNameOpr.insertLedgerNameDetails(myLedgerNameInfo);



                    }

                    else

                    {
                        myLedgerNameInfo.LedgerIdInt = myLedgerId;
                        myLedgerNameOpr.updateLedgerNameDetails(myLedgerNameInfo);

                    }
                }
                btnNew_Click(sender, e);
            }

        }
        private void bindLedgerGroupsToDDl()
        {
            DataSet ledgerGroupsDts = myLedgerGroupOpr.selectAllParentAndSubGroupDetails();
            ddlGroupName.DataSource = ledgerGroupsDts.Tables[0];
            ddlGroupName.DisplayMember = "group_name";
            ddlGroupName.ValueMember = "group_id";
            ddlGroupName.SelectedIndex = -1;

        }
        private void setFieldValues()
        {

            myLedgerNameInfo.LedgerNameStr = txtAccountName.Text;
            myLedgerNameInfo.LedgerCodeStr = txtAccountCode.Text;
            myLedgerNameInfo.AlternateNameStr = txtAlternateName.Text;
            myLedgerNameInfo.DescriptionStr = txtDescription.Text;
            myLedgerNameInfo.GroupIdInt = Convert.ToInt64(ddlGroupName.SelectedValue.ToString());
            myLedgerNameInfo.OpeningBalDec = Convert.ToDecimal(txtOpBalance.Text);
            myLedgerNameInfo.OpBalTypeBol = Convert.ToBoolean(ddlAmountType.SelectedIndex);
            myLedgerNameInfo.IsLedgerActive= ckbActive.Checked == true ? true : false;

        }
        private void clearFields()
        {

            txtAccountName.Text = "";
            txtAccountCode.Text = "";
            txtAlternateName.Text = "";
            txtDescription.Text = "";
            
            txtOpBalance.Text = "";
            ddlAmountType.SelectedIndex = 0;
            ckbActive.Checked = true;
            txtAccountName.Focus();
            controlsUnlock();
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            isLoadCmplt = false;
            

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmLedgerName_Load(sender, e);
           

        }

        private void ddlGroupType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            trvDetails.Nodes.Clear();
            myLedgerGroupInfo.GroupType = 1+Convert.ToInt32(ddlGroupType.SelectedIndex.ToString());
            DataSet groupsDts = myLedgerGroupOpr.selectAllParentGroupDetailsByGroupType(myLedgerGroupInfo);
            foreach (DataRow rowsDetails in groupsDts.Tables[0].Rows)
            {

                myParentNode = trvDetails.Nodes.Add(rowsDetails["group_name"].ToString());


                bindSubGroupsToTreeView(Convert.ToInt64(rowsDetails["group_id"].ToString()), myParentNode);
                bindLedgerNamesToTreeView(Convert.ToInt64(rowsDetails["group_id"].ToString()), myParentNode);
            }


        }
        private void bindSubGroupsToTreeView( long parentId,TreeNode parentNode )
        {
            myLedgerGroupInfo.ParentGroupId = parentId;
            DataSet groupsDts = myLedgerGroupOpr.selectASubGroupDetailsByParentId(myLedgerGroupInfo);
            foreach (DataRow rowsDetails in groupsDts.Tables[0].Rows)
            {

                TreeNode subParentNode = parentNode.Nodes.Add(rowsDetails["group_name"].ToString());
                bindLedgerNamesToTreeView(Convert.ToInt32(rowsDetails["group_id"].ToString()), subParentNode);
            }


        }


        private void bindLedgerNamesToTreeView(long subGroupId, TreeNode parentNode)
        {
            myLedgerNameInfo.GroupIdInt = subGroupId;
            DataSet groupsDts = myLedgerNameOpr.selectAllLedgerNameByGroupId(myLedgerNameInfo);
            foreach (DataRow rowsDetails in groupsDts.Tables[0].Rows)
            {
                parentNode.Nodes.Add(rowsDetails["ledger_name"].ToString());

            }


        }

        private void ddlSearchAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadCmplt)
            {
                myLedgerNameInfo.LedgerIdInt = Convert.ToInt64(ddlSearchAccount.SelectedValue.ToString());
                DataSet details = myLedgerNameOpr.selectALedgerNameDetailsById(myLedgerNameInfo);
                fillFiledData(details);


            }
        }
        private void fillFiledData(DataSet details)
        {
            myLedgerId = Convert.ToInt64(details.Tables[0].Rows[0]["ledger_id"].ToString());
            txtAccountName.Text = details.Tables[0].Rows[0]["ledger_name"].ToString();
            txtAccountCode.Text = details.Tables[0].Rows[0]["ledger_code"].ToString();
            txtAlternateName.Text = details.Tables[0].Rows[0]["alternate_name"].ToString();
            txtDescription.Text = details.Tables[0].Rows[0]["description"].ToString();
            ddlGroupName.SelectedValue = Convert.ToInt32(details.Tables[0].Rows[0]["group_id"].ToString());
            txtOpBalance.Text = details.Tables[0].Rows[0]["op_balance"].ToString();
            ddlAmountType.SelectedIndex = Convert.ToBoolean(details.Tables[0].Rows[0]["balance_type"].ToString()) == true ? 1 : 0;
            ckbActive.Checked = Convert.ToBoolean(details.Tables[0].Rows[0]["is_active"].ToString()) == true ? true : false;
            myLedgerIsFixed = Convert.ToBoolean(details.Tables[0].Rows[0]["fixed"].ToString());
            txtAccountName.ReadOnly = true;
            txtAccountCode.ReadOnly = true;
            txtAlternateName.ReadOnly = true;
            txtDescription.ReadOnly = true;
            ddlGroupName.ReadOnly = true;
            txtOpBalance.ReadOnly = true;
            ddlAmountType.ReadOnly = true;
            ckbActive.ReadOnly = true;
            btnSave.Text = "&Edit";
            btnDelete.Enabled = true;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (myLedgerIsFixed)
            {
                MessageBox.Show("This Ledger Name  cannot be deleted because it is  Fixed", "True Account Pro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myLedgerNameInfo.LedgerIdInt = myLedgerId;
                    myLedgerNameOpr.deleteLedgerNameDetails(myLedgerNameInfo);
                    btnNew_Click(sender, e);
                    MessageBox.Show("Ledger Group has been successfully deleted.", "True Account Pro",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                 

                }
                else
                {
                    controlsUnlock();
                }
            }
        }

        private void trvDetails_DoubleClick(object sender, EventArgs e)
        {

            TreeNode node = trvDetails.SelectedNode;
            // MessageBox.Show(n.Level.ToString());
            //DigInNodes(node);
           if(getNumberOfNodeLevelCount(node)== node.Level)
            {
                myLedgerNameInfo.LedgerNameStr = node.Text.ToString();
                DataSet details = myLedgerNameOpr.selectALedgerNameDetailsByName(myLedgerNameInfo);
                fillFiledData(details);
            }


        }
        private int getNumberOfNodeLevelCount(TreeNode node)
        {
            int level = node.Level;
            foreach (System.Windows.Forms.TreeNode subnode in node.Nodes)
            {
                int deep = getNumberOfNodeLevelCount(subnode);
                if (deep > level)
                    level = deep;
            }
            return level;
        }
    }
}
