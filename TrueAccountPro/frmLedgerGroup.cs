using BEL;
using BEL;
using System;
using System.Data;
using System.Windows.Forms;
using TrueAccountPro;

namespace TrueAccountPro
{
    public partial class frmLedgerGroup : Telerik.WinControls.UI.RadForm
    {
        //class


        ledgerGroupOpr myLedgerGroupOpr = new ledgerGroupOpr();
        ledgerGroupInfo myLedgerGroupInfo = new ledgerGroupInfo();


        DataSet myLedgerGroupsDts;
        DataSet mySubGroupDetailsDts;

        long myGroupIdLng;

        bool myGroupIsFixedBool;


        public frmLedgerGroup()
        {
            InitializeComponent();
        }


        private void frmLedgerGroup_Load(object sender, EventArgs e)
        {


            bindLedgerGroupsToDDl();
            bindLedgerSubGroupsToGrid();
            clearFileds();
        }
        private void bindLedgerGroupsToDDl()
        {
            myLedgerGroupsDts = myLedgerGroupOpr.selectAllParentGroupDetails();
            ddlParentGroup.DataSource = myLedgerGroupsDts.Tables[0];
            ddlParentGroup.DisplayMember = "group_name";
            ddlParentGroup.ValueMember = "group_id";

        }
        private void bindLedgerSubGroupsToGrid()
        {
            dgvSubGroup.Rows.Clear();
            mySubGroupDetailsDts = myLedgerGroupOpr.selectAllSubGroupDetails();

            for (int i = 0; i < mySubGroupDetailsDts.Tables[0].Rows.Count; i++)
            {
                dgvSubGroup.Rows.AddNew();
                dgvSubGroup.Rows[i].Cells["clmGroupId"].Value = mySubGroupDetailsDts.Tables[0].Rows[i]["group_id"].ToString();
                dgvSubGroup.Rows[i].Cells["clmGroupName"].Value = mySubGroupDetailsDts.Tables[0].Rows[i]["group_name"].ToString();
                dgvSubGroup.Rows[i].Cells["clmParentGroup"].Value = mySubGroupDetailsDts.Tables[0].Rows[i]["parent_group_name"].ToString();
                dgvSubGroup.Rows[i].Cells["clmParentId"].Value = mySubGroupDetailsDts.Tables[0].Rows[i]["parent_group_id"].ToString();
                dgvSubGroup.Rows[i].Cells["clmDescription"].Value = mySubGroupDetailsDts.Tables[0].Rows[i]["group_description"].ToString();
                dgvSubGroup.Rows[i].Cells["clmFixed"].Value = mySubGroupDetailsDts.Tables[0].Rows[i]["fixed"].ToString();
            }






        }
        private void ddlParentGroup_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "&Edit")
            {
                txtGroupName.ReadOnly = false;
                ddlParentGroup.ReadOnly = false;
                txtDescription.ReadOnly = false;
                btnSave.Text = "&Update";
                txtGroupName.Focus();
            } 

            else
            {
                if (validateFields())
                {

                    setValues();
                    if (btnSave.Text == "&Save")
                    {
                        myLedgerGroupOpr.insertLedgerGroup(myLedgerGroupInfo);


                        MessageBox.Show("Ledger Group has been successfully saved", "True Account Pro",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        myLedgerGroupInfo.GroupId = myGroupIdLng;
                        myLedgerGroupOpr.updateLedgerGroup(myLedgerGroupInfo);
                        MessageBox.Show("Ledger Group has been successfully updated", "True Account Pro",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    frmLedgerGroup_Load(sender, e);
                }
            }

        }

        private void setValues()
        {
            myLedgerGroupInfo.GroupName = txtGroupName.Text;
            myLedgerGroupInfo.ParentGroupId = Convert.ToInt64(ddlParentGroup.SelectedValue.ToString());
            myLedgerGroupInfo.Description = txtDescription.Text;
        }
        private void clearFileds()
        {
            txtGroupName.Text = "";
            ddlParentGroup.SelectedIndex = -1;
            txtDescription.Text = "";
            btnDelete.Enabled = false;
            txtGroupName.Focus();
            txtGroupName.ReadOnly = false;
            ddlParentGroup.ReadOnly = false;
            txtDescription.ReadOnly = false;
            btnSave.Text = "&Save";
           
        }


        private bool validateFields()
        {
            
            if (txtGroupName.Text == "")
            {
                MessageBox.Show("Please enter a Ledger Group Name.", "True Account Pro",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGroupName.Focus();
                return false;
            }

            myLedgerGroupInfo.GroupName = txtGroupName.Text;
            DataSet aSubGroupDetails = myLedgerGroupOpr.selectAGroupDetailsByName(myLedgerGroupInfo);
            if (aSubGroupDetails.Tables[0].Rows.Count > 0)
            {
                
                    MessageBox.Show("This Ledger Name already exists", "True Account Pro",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGroupName.Focus();
                    return false;
                
            }
            if (ddlParentGroup.SelectedIndex == -1 || ddlParentGroup.Text == "")
            {
                MessageBox.Show("Please select a Parent Group.", "True Account Pro",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                ddlParentGroup.Focus();
                return false;
            }
            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            frmLedgerGroup_Load(sender, e);
        }

        private void dgvSubGroup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int rowIndex;
            if (dgvSubGroup.CurrentCell != null)
            {
                rowIndex = dgvSubGroup.CurrentCell.RowIndex;
                myGroupIdLng = Convert.ToInt64(dgvSubGroup.Rows[rowIndex].Cells["clmGroupId"].Value.ToString());
                txtGroupName.Text = dgvSubGroup.Rows[rowIndex].Cells["clmGroupName"].Value.ToString();
                ddlParentGroup.SelectedValue = Convert.ToInt32(dgvSubGroup.Rows[rowIndex].Cells["clmParentId"].Value.ToString());
                txtDescription.Text = dgvSubGroup.Rows[rowIndex].Cells["clmDescription"].Value.ToString();
                myGroupIsFixedBool = Convert.ToBoolean(dgvSubGroup.Rows[rowIndex].Cells["clmFixed"].Value.ToString());
                txtGroupName.ReadOnly = true;
                ddlParentGroup.ReadOnly = true;
                txtDescription.ReadOnly = true;
                btnSave.Text = "&Edit";
                btnDelete.Enabled = true;

            }
        }

        private void dgvSubGroup_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (myGroupIsFixedBool)
            {
                MessageBox.Show("This Ledger Group  cannot be deleted because it is  Fixed", "True Account Pro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                {

                    myLedgerGroupInfo.Query = "delete from tblLedgerGroup where group_id='" + myGroupIdLng + "'";
                    myLedgerGroupOpr.deleteLedgerGroup(myLedgerGroupInfo);


                    MessageBox.Show("Ledger Group has been successfully deleted.", "True Account Pro",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindLedgerSubGroupsToGrid();
                    clearFileds();

                }
                else
                {
                    txtGroupName.Focus();
                }
            }



        }
    }
}
