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

namespace TrueAccountPro
{
    public partial class frmGodownMaster : Telerik.WinControls.UI.RadForm
    {

        mastersOpr myMasterOpr = new mastersOpr();
        mastersInfo myMastersInfo = new mastersInfo();
        DataSet myGodownDetlsDts;
        long myGodownIdInt;
        public frmGodownMaster()
        {
            InitializeComponent();
        }

        private void radGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void unLockControlls()
        {
            txtGodownCode.ReadOnly = false;
            txtGodownName.ReadOnly = false;
            txtAddress2.ReadOnly = false;
            txtAddress1.ReadOnly = false;
            txtManager.ReadOnly = false;
            txtMobileNo.ReadOnly = false;
            txtPhoneNo.ReadOnly = false;
            txtDescription.ReadOnly = false;
            chkActive.ReadOnly = false;


        }
        private void lockControlls()
        {
            txtGodownCode.ReadOnly = true;
            txtGodownName.ReadOnly = true;
            txtAddress2.ReadOnly = true;
            txtAddress1.ReadOnly = true;
            txtManager.ReadOnly = true;
            txtMobileNo.ReadOnly = true;
            txtPhoneNo.ReadOnly = true;
            txtDescription.ReadOnly = true;
            chkActive.ReadOnly = true;


        }
     
       
        private bool validateFields(string operation)
        {

            if (txtGodownCode.Text == "")
            {
                MessageBox.Show("Please enter a Godown Code.", "True Account Pro",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGodownCode.Focus();
                return false;
            }
        myMastersInfo.Query = "select * from tblGodown where godown_code='" + txtGodownCode.Text + "'";
        DataSet detailsDts = myMasterOpr.selectAllMasterDetails(myMastersInfo);

            if (detailsDts.Tables[0].Rows.Count > 0)
            {
                if (operation == "Update")
                {
                    if (detailsDts.Tables[0].Rows[0]["godown_id"].ToString() != myGodownIdInt.ToString())
                    {
                        MessageBox.Show("This Ledger Name already exists", "True Account Pro",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtGodownCode.Focus();
                        return false;
                    }
                }


                else
                {
                    MessageBox.Show("This Godown Code already exists", "True Account Pro",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGodownCode.Focus();
                    return false;
                }
            }
                if (txtGodownName.Text == "")
                {
                    MessageBox.Show("Please enter a Godown Name.", "True Account Pro",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGodownName.Focus();
                    return false;
                }
            myMastersInfo.Query = "select * from tblGodown where godown_name='" + txtGodownName.Text + "'";
             detailsDts = myMasterOpr.selectAllMasterDetails(myMastersInfo);

            if (detailsDts.Tables[0].Rows.Count > 0)
            {
                if (operation == "Update")
                {
                    if (detailsDts.Tables[0].Rows[0]["godown_id"].ToString() != myGodownIdInt.ToString())
                    {
                        MessageBox.Show("This Godown Name already exists", "True Account Pro",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtGodownCode.Focus();
                        return false;
                    }
                }


                else
                {
                    MessageBox.Show("This Ledger Name already exists", "True Account Pro",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGodownCode.Focus();
                    return false;
                }
            }

            return true;
            }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "&Edit")
            {
                unLockControlls();
                btnSave.Text = "&Update";
                txtGodownCode.Focus();
            }

            else if (btnSave.Text == "&Save")
            {
                
                if (validateFields("Save"))
                {
                    setValues();
                    myMasterOpr.insertGodownMasterDetails(myMastersInfo );
                    MessageBox.Show("successfully saved", "True Account Pro",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmGodownMaster_Load(sender, e);
                }
             
            }
            else
            {
               
                if (validateFields("Update"))
                {
                    setValues();
                    myMastersInfo.GodownId = myGodownIdInt;
                    myMasterOpr.updateGodownMasterDetails(myMastersInfo);
                    MessageBox.Show("successfully updated", "True Account Pro",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmGodownMaster_Load(sender, e);

                }

            }
       



        }
        private void setValues()
        {
            myMastersInfo.GodownCode = txtGodownCode.Text;
            myMastersInfo.GodownName = txtGodownName.Text;
            myMastersInfo.Address1 = txtAddress1.Text;
            myMastersInfo.Address2 = txtAddress2.Text;
            myMastersInfo.Manager = txtManager.Text;
            myMastersInfo.Mobile = txtMobileNo.Text;
            myMastersInfo.Phone = txtPhoneNo.Text;
            myMastersInfo.Description = txtDescription.Text;
            myMastersInfo.Active = chkActive.Checked == true ? true : false;

        }
        private void frmGodownMaster_Load(object sender, EventArgs e)
        {
            bindGodownDetialsToGrid();
            clearFileds();
        }
        private void bindGodownDetialsToGrid()
        {
            dgvGodownDetails.Rows.Clear();
            myMastersInfo.Query = "select * from tblGodown";
            myGodownDetlsDts = myMasterOpr.selectAllMasterDetails(myMastersInfo);

            for (int i = 0; i < myGodownDetlsDts.Tables[0].Rows.Count; i++)
            {
                dgvGodownDetails.Rows.AddNew();
                dgvGodownDetails.Rows[i].Cells["clmGodownId"].Value = myGodownDetlsDts.Tables[0].Rows[i]["godown_id"].ToString();
                dgvGodownDetails.Rows[i].Cells["clmGodownCode"].Value = myGodownDetlsDts.Tables[0].Rows[i]["godown_code"].ToString();
                dgvGodownDetails.Rows[i].Cells["clmGodownName"].Value = myGodownDetlsDts.Tables[0].Rows[i]["godown_name"].ToString();
                dgvGodownDetails.Rows[i].Cells["clmManager"].Value = myGodownDetlsDts.Tables[0].Rows[i]["manager"].ToString();
                dgvGodownDetails.Rows[i].Cells["clmMobile"].Value = myGodownDetlsDts.Tables[0].Rows[i]["mobile"].ToString();
                dgvGodownDetails.Rows[i].Cells["clmActive"].Value = myGodownDetlsDts.Tables[0].Rows[i]["active"].ToString();
            }


        



        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmGodownMaster_Load(sender,e);
        }
        private void clearFileds()
        {
            txtGodownCode.Text = "";
            txtGodownName.Text = "";
            txtAddress2.Text = "";
            txtAddress1.Text = "";
            txtManager.Text = "";
            txtMobileNo.Text = "";
            txtPhoneNo.Text = "";
            txtDescription.Text = "";
            unLockControlls();
            txtGodownCode.Focus();
            chkActive.Checked = true;
            btnDelete.Enabled = false;
            btnSave.Text = "&Save";

        }

        private void dgvGodownDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int rowIndex;
            if (dgvGodownDetails.CurrentCell != null)
            {
                rowIndex = dgvGodownDetails.CurrentCell.RowIndex;
                myGodownIdInt = Convert.ToInt64(myGodownDetlsDts.Tables[0].Rows[rowIndex]["godown_id"].ToString());
                txtGodownCode.Text = myGodownDetlsDts.Tables[0].Rows[rowIndex]["godown_code"].ToString();
                txtGodownName.Text = myGodownDetlsDts.Tables[0].Rows[rowIndex]["godown_name"].ToString();
                txtAddress1.Text = myGodownDetlsDts.Tables[0].Rows[rowIndex]["addrerss_1"].ToString();
                txtAddress2.Text = myGodownDetlsDts.Tables[0].Rows[rowIndex]["address_2"].ToString();
                txtManager.Text = myGodownDetlsDts.Tables[0].Rows[rowIndex]["manager"].ToString();
                txtMobileNo.Text = myGodownDetlsDts.Tables[0].Rows[rowIndex]["mobile"].ToString();
                txtPhoneNo.Text = myGodownDetlsDts.Tables[0].Rows[rowIndex]["phone"].ToString();
                txtDescription.Text = myGodownDetlsDts.Tables[0].Rows[rowIndex]["description"].ToString();
                chkActive.Checked = Convert.ToBoolean(myGodownDetlsDts.Tables[0].Rows[rowIndex]["active"].ToString());
                lockControlls();
                btnSave.Text = "&Edit";
                btnDelete.Enabled = true;
                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete ?  ", "True Account Pro", MessageBoxButtons.YesNo))
            {

                myMastersInfo.Query = "delete from tblGodown where godown_id='" + myGodownIdInt + "'";
                myMasterOpr.deleteMasterDetails(myMastersInfo);


                MessageBox.Show("successfully deleted.", "True Account Pro",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmGodownMaster_Load(sender,e);

            }
        }
    }
}
