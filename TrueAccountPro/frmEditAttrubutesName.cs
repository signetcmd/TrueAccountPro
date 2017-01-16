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
    public partial class frmEditAttrubutesName : Telerik.WinControls.UI.RadForm
    {
        frmProductMaster fmaster = new frmProductMaster();
        public string value;
        public frmEditAttrubutesName()
        {
           
            InitializeComponent();
           // txtGroupUpdate.Text = value1;
        }

        private void frmEditAttrubutesName_Load(object sender, EventArgs e)
        {
           
            fmaster.lblGroup.Text = txtGroupA.Text;
             value = fmaster.lblGroup.Text;

        
        }

        private void txtGroupA_TextChanged(object sender, EventArgs e)
        {

        }

        private void radLabel2_Click(object sender, EventArgs e)
        {

        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtGroupUpdate.Text == string.Empty)
            {
                fmaster.lblGroup.Text = txtGroupA.Text;

            }
            else if (txtGroupUpdate.Text != string.Empty)
            {
                fmaster.lblGroup.Text = txtGroupUpdate.Text;

            }
            if (txtCompanyUpdate.Text == string.Empty)
            {
                fmaster.lblCompany.Text = txtCompany.Text;

            }
            else if(txtCompanyUpdate.Text != string.Empty)
            {
                fmaster.lblCompany.Text = txtCompanyUpdate.Text;

            }
            if (txtCategoryUpdate.Text == string.Empty)
            {
                fmaster.lblCategory.Text = txtCategory.Text;
            }
            else if(txtCategoryUpdate.Text != string.Empty)
            {
                fmaster.lblCategory.Text = txtCategoryUpdate.Text;
            }
            if (txtModelUpdate.Text == string.Empty)
            {
                fmaster.lblModel.Text = txtModel.Text;
            }
            else if (txtModelUpdate.Text != string.Empty)
            {
                fmaster.lblModel.Text = txtModelUpdate.Text;
            }
            if (txtBrandUpdate.Text == string.Empty)
            {
                fmaster.lblBrand.Text = txtBrand.Text;
            }
            else if (txtBrandUpdate.Text != string.Empty)
            {
                fmaster.lblBrand.Text = txtBrandUpdate.Text;
            }
            this.Hide();
            fmaster.Show();
            MessageBox.Show("Your Attributes Names Is Updated", "True Account Pro",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

             
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProductMaster fPMaster = new frmProductMaster();
            fPMaster.Show();
        }

        private void radGroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
