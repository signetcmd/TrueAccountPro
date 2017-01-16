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
    public partial class frmPurchaseAltUnit : Telerik.WinControls.UI.RadForm
    {
        long myItemId;
        long mySelectUnitId;
        decimal myCost;

        productMasterInfo myProductMansterInfo = new productMasterInfo();
        productMasterOpr myProductMasterOpr = new productMasterOpr();
        genaralFunctions myGenaralFunctions = new genaralFunctions();
        public DataTable returnUnitDetails { get; set; }
        public frmPurchaseAltUnit()
        {
            InitializeComponent();
        }
        public frmPurchaseAltUnit(long itemId, long selectUnitId, decimal cost)
        {
            InitializeComponent();
            myItemId = itemId;
            myCost = cost;
            mySelectUnitId = selectUnitId;
        }
        private void frmPurchaseAltUnit_Load(object sender, EventArgs e)
        {
            myProductMansterInfo.ProductId = myItemId;
            DataSet detailsDs = myProductMasterOpr.selectProductUnitDetails(myProductMansterInfo);
            if (detailsDs.Tables[0].Rows.Count > 0)
            {
                string basicUnit = detailsDs.Tables[0].Rows[0]["unit_name"].ToString();
                lblItemCode.Text = detailsDs.Tables[0].Rows[0]["product_code"].ToString();
                lblItemName.Text = detailsDs.Tables[0].Rows[0]["product_name"].ToString();
                DataTable detailsDt = detailsDs.Tables[0];
                detailsDt.DefaultView.RowFilter = "unit_Id<>'" + mySelectUnitId + "'";
                detailsDt = detailsDt.DefaultView.ToTable();
                for (int i = 0; i < detailsDt.Rows.Count; i++)
                {
                    dgvDetails.Rows.AddNew();
                    dgvDetails.Rows[i].Cells["clmUnitId"].Value = detailsDt.Rows[i]["unit_Id"].ToString();
                    dgvDetails.Rows[i].Cells["clmUnit"].Value = detailsDt.Rows[i]["unit_name"].ToString();
                    dgvDetails.Rows[i].Cells["clmFactor"].Value = detailsDt.Rows[i]["factor"].ToString();
                    dgvDetails.Rows[i].Cells["clmBUnit"].Value = basicUnit;
                    dgvDetails.Rows[i].Cells["clmCost"].Value = myCost * Convert.ToDecimal(detailsDt.Rows[i]["factor"].ToString());     
                }
            }
        }
        private string calculateRate(decimal cost,decimal percentage)
        {
            decimal rate;
            rate = cost + (cost * percentage / 100);
            return myGenaralFunctions.FormatDecimalPlace(rate.ToString(), 2);
        }
        private string calculatePercentage(decimal cost, decimal rate)
        {
            decimal percentage;
            percentage = (rate - cost) * 100 / cost;
            return myGenaralFunctions.FormatDecimalPlace(percentage.ToString(), 2);
        }
        private void dgvDetails_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.RowIndex);
            switch (dgvDetails.CurrentCell.ColumnInfo.Name.ToString())
            {
                case "clmRetailPro":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmRetailPro"].Value != null)
                            dgvDetails.Rows[rowIndex].Cells["clmRetailRate"].Value= calculateRate(Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmRetailPro"].Value.ToString()));
                            break;
                    }
                case "clmRetailRate":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmRetailRate"].Value != null)
                            dgvDetails.Rows[rowIndex].Cells["clmRetailPro"].Value = calculatePercentage(Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmRetailRate"].Value.ToString()));
                        break;
                    }
                case "clmMrpPro":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmMrpPro"].Value != null)
                            dgvDetails.Rows[rowIndex].Cells["clmMrp"].Value = calculateRate(Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmMrpPro"].Value.ToString()));
                        break;
                    }
                case "clmMrp":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmMrp"].Value != null)
                            dgvDetails.Rows[rowIndex].Cells["clmMrpPro"].Value = calculatePercentage(Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmMrp"].Value.ToString()));
                        break;
                    }
                case "clmSpecialratePro":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmSpecialratePro"].Value != null)
                            dgvDetails.Rows[rowIndex].Cells["clmSpRate"].Value = calculateRate(Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmSpecialratePro"].Value.ToString()));
                        break;
                    }
                case "clmSpRate":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmSpRate"].Value != null)
                            dgvDetails.Rows[rowIndex].Cells["clmSpecialratePro"].Value = calculatePercentage(Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmSpRate"].Value.ToString()));
                        break;
                    }
                case "clmWhPro":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmWhPro"].Value != null)
                            dgvDetails.Rows[rowIndex].Cells["clmWholeSale"].Value = calculateRate(Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmWhPro"].Value.ToString()));
                        break;
                    }
                case "clmWholeSale":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmWholeSale"].Value != null)
                            dgvDetails.Rows[rowIndex].Cells["clmWhPro"].Value = calculatePercentage(Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmWholeSale"].Value.ToString()));
                        break;
                    }
                case "clmBranchPro":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmBranchPro"].Value != null)
                            dgvDetails.Rows[rowIndex].Cells["clmBranchRate"].Value = calculateRate(Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmBranchPro"].Value.ToString()));
                        break;
                    }
                case "clmBranchRate":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmBranchRate"].Value != null)
                            dgvDetails.Rows[rowIndex].Cells["clmBranchPro"].Value = calculatePercentage(Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmCost"].Value.ToString()), Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmBranchRate"].Value.ToString()));
                        break;
                    }
            }
        }
        private void radApply_Click(object sender, EventArgs e)
        {
            int rowsCount = dgvDetails.Rows.Count;
            int columnsCount = dgvDetails.Columns.Count;
            DataTable tempData=new DataTable ();
            string unitId, cost, retailRatePro, retailRate, mrp, mrpRate, spRatePro, spRate, whosleSalePro, wholeSaleRate, branchRatePro, branchRate;

            tempData.Columns.Add("unitId", typeof(string));
            tempData.Columns.Add("cost", typeof(string));
            tempData.Columns.Add("retailRatePro", typeof(string));
            tempData.Columns.Add("retailRate", typeof(string));
            tempData.Columns.Add("mrp", typeof(string));
            tempData.Columns.Add("mrpRate", typeof(string));
            tempData.Columns.Add("spRatePro", typeof(string));
            tempData.Columns.Add("spRate", typeof(string));
            tempData.Columns.Add("whosleSalePro", typeof(string));
            tempData.Columns.Add("wholeSaleRate", typeof(string));
            tempData.Columns.Add("branchRatePro", typeof(string));
            tempData.Columns.Add("branchRate", typeof(string));
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 6; j < columnsCount; j++)
                {
                    if (dgvDetails.Rows[i].Cells["clmUnitId"].Value != null)
                    {
                        unitId = dgvDetails.Rows[i].Cells["clmUnitId"].Value.ToString();
                        cost = dgvDetails.Rows[i].Cells["clmCost"].Value != null ? dgvDetails.Rows[i].Cells["clmCost"].Value.ToString() : "0";
                        retailRatePro = dgvDetails.Rows[i].Cells["clmRetailPro"].Value != null ? dgvDetails.Rows[i].Cells["clmRetailPro"].Value.ToString() : "0";
                        retailRate = dgvDetails.Rows[i].Cells["clmRetailRate"].Value != null ? dgvDetails.Rows[i].Cells["clmRetailRate"].Value.ToString() : "0";
                        mrp = dgvDetails.Rows[i].Cells["clmMrpPro"].Value != null ? dgvDetails.Rows[i].Cells["clmMrpPro"].Value.ToString() : "0";
                        mrpRate = dgvDetails.Rows[i].Cells["clmMrp"].Value != null ? dgvDetails.Rows[i].Cells["clmMrp"].Value.ToString() : "0";
                        spRatePro = dgvDetails.Rows[i].Cells["clmSpecialratePro"].Value != null ? dgvDetails.Rows[i].Cells["clmSpecialratePro"].Value.ToString() : "0";
                        spRate = dgvDetails.Rows[i].Cells["clmSpRate"].Value != null ? dgvDetails.Rows[i].Cells["clmSpRate"].Value.ToString() : "0";
                        whosleSalePro = dgvDetails.Rows[i].Cells["clmWhPro"].Value != null ? dgvDetails.Rows[i].Cells["clmWhPro"].Value.ToString() : "0";
                        wholeSaleRate = dgvDetails.Rows[i].Cells["clmWholeSale"].Value != null ? dgvDetails.Rows[i].Cells["clmWholeSale"].Value.ToString() : "0";
                        branchRatePro = dgvDetails.Rows[i].Cells["clmBranchPro"].Value != null ? dgvDetails.Rows[i].Cells["clmBranchPro"].Value.ToString() : "0";
                        branchRate = dgvDetails.Rows[i].Cells["clmBranchRate"].Value != null ? dgvDetails.Rows[i].Cells["clmBranchRate"].Value.ToString() : "0";
                        tempData.Rows.Add(unitId, cost, retailRatePro, retailRate, mrp, mrpRate, spRatePro, spRate, whosleSalePro, wholeSaleRate, branchRatePro, branchRate);
                        break;
                    }
                }
                returnUnitDetails = tempData;
                this.Close();
            }
        }
        private void radButton2_Click(object sender, EventArgs e)
        {
            dgvDetails.Rows.Clear();
            lblItemCode.Text = "";
            lblItemName.Text = "";
        }
        //#region ProcessCmdKey
        //protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        //{
        //        if (msg.WParam.ToInt32() == (int)Keys.Enter)
        //        {
        //            SendKeys.Send("{Tab}");
        //            return true;
        //        }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
        //#endregion ProcessCmdKey
    }
}
