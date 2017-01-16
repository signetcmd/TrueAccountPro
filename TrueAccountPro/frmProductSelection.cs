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

namespace TrueAccountPro
{
    public partial class frmProductSelection : Telerik.WinControls.UI.RadForm
    {

        barCodeRegistryInfo myBarCodeRegistryInfo = new barCodeRegistryInfo();
        barCodeRegistryOpr myBarCodeRegistryOpr = new barCodeRegistryOpr();
        productMasterInfo myProductMasterInfo = new productMasterInfo();
        productMasterOpr myProductMasteropr=new productMasterOpr();
        genaralFunctions myGenaralFuctions = new genaralFunctions();

        settingsOpr mySettings = new settingsOpr();


        long myItemID;

        DataTable tempData = new DataTable();
        public  string returnBarcode { get; set; }

        bool loadCmplt = false;
    

        public frmProductSelection(long itemId, string itemCode, string itemName)
        {
            InitializeComponent();


            myItemID = itemId;
            lblItemCode.Text = itemCode;
            lblItemName.Text = itemName;

        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {

            if (msg.WParam.ToInt32() == (int)Keys.Enter)
            {

                int rowIndex = dgvDetails.CurrentCell.RowIndex;

                returnBarcode = dgvDetails.Rows[rowIndex].Cells["clmBarCode"].Value.ToString();
            
                this.Close();
                return true;
            }

          else  if (msg.WParam.ToInt32() == (int)Keys.Right)
            {

                ddlUnits.Focus();
                return true;
            }
            else if (msg.WParam.ToInt32() == (int)Keys.Left)
            {

                dgvDetails.Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    private void frmProductSelection_Load(object sender, EventArgs e)
        {

            DataSet genaralSettings = mySettings.selectAllGenarlSettings();
            myBarCodeRegistryInfo.ourItemId = myItemID;

            DataSet itemDetails = myBarCodeRegistryOpr.selectItemAgainstPurchAndOP(myBarCodeRegistryInfo);

            if(itemDetails.Tables[0].Rows.Count>0)
            {
                for (int i = 0; i < itemDetails.Tables[0].Rows.Count; i++)
                {
                    dgvDetails.Rows.AddNew();
                    dgvDetails.Rows[i].Cells["clmProductId"].Value = itemDetails.Tables[0].Rows[i]["item_id"].ToString();
                    dgvDetails.Rows[i].Cells["clmBarCodeId"].Value = itemDetails.Tables[0].Rows[i]["bar_code_id"].ToString();
                    dgvDetails.Rows[i].Cells["clmBarCode"].Value = itemDetails.Tables[0].Rows[i]["bar_code"].ToString();
                    dgvDetails.Rows[i].Cells["clmIdentity"].Value = itemDetails.Tables[0].Rows[i]["entry_id"].ToString();
                    dgvDetails.Rows[i].Cells["clmEntryNo"].Value = itemDetails.Tables[0].Rows[i]["entry_no"].ToString();
                    dgvDetails.Rows[i].Cells["clmBatch"].Value = itemDetails.Tables[0].Rows[i]["batch"].ToString();
                    dgvDetails.Rows[i].Cells["clmExpDate"].Value = itemDetails.Tables[0].Rows[i]["exp_date"].ToString() == "" ? null : (Convert.ToDateTime(itemDetails.Tables[0].Rows[i]["exp_date"]).ToString(genaralSettings.Tables[0].Rows[0]["date_format"].ToString())).ToString();
                    dgvDetails.Rows[i].Cells["clmStock"].Value = itemDetails.Tables[0].Rows[i]["stock"].ToString();


                }
            }
            myProductMasterInfo.ProductId = Convert.ToInt64(dgvDetails.Rows[0].Cells["clmProductId"].Value.ToString());
            DataSet details = myProductMasteropr.selectProductUnitDetails(myProductMasterInfo);

            ddlUnits.DataSource = details.Tables[0];
            ddlUnits.ValueMember = "unit_Id";
            ddlUnits.DisplayMember = "unit_name";
            dgvDetails.Rows[0].IsCurrent = true;
            loadCmplt = true;
            selectRateDetails();
        }

        private void dgvDetails_CurrentRowChanging(object sender, Telerik.WinControls.UI.CurrentRowChangingEventArgs e)
        {
            
            
        }

        private void dgvDetails_RowsChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {

           

        }

        private void dgvDetails_RowsChanging(object sender, Telerik.WinControls.UI.GridViewCollectionChangingEventArgs e)
        {
         
        }

        private void dgvDetails_SelectionChanged(object sender, EventArgs e)
        {

            selectRateDetails();
        }

        private void ddlUnits_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            selectRateDetails();
        }

        public void selectRateDetails()
        {
            dgvRateDetails.Rows.Clear();
            if (loadCmplt)
            {

                myBarCodeRegistryInfo.ourBarCodeId = Convert.ToInt64(dgvDetails.Rows[dgvDetails.CurrentCell.RowIndex].Cells["clmBarCodeId"].Value.ToString());
                //myBarCodeRegistryInfo.ourUnitId = Convert.ToInt64(ddlUnits.SelectedValue.ToString());
                DataSet details = myBarCodeRegistryOpr.selectRateDetailsByBarcodeAndUnit(myBarCodeRegistryInfo);
                for (int i = 0; i < details.Tables[0].Rows.Count; i++)
                {
                    dgvRateDetails.Rows.AddNew();
                    dgvRateDetails.Rows[i].Cells["clmRateName"].Value = details.Tables[0].Rows[i]["Rate"].ToString();
                    dgvRateDetails.Rows[i].Cells["clmAmount"].Value = myGenaralFuctions.FormatDecimalPlace(details.Tables[0].Rows[i]["Amount"].ToString(), 2);
                }
                dgvRateDetails.ClearSelection();
            }
        }
    }
}
