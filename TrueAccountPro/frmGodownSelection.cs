using BAL;
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrueAccountPro
{
    public partial class frmGodownSelection : Form
    {
        genaralFunctions myGenaralFunctions = new genaralFunctions();
        long myBarCode;
        string myMode;

        stockOpr myStockLedgerOpr = new stockOpr();
        stockInfo myStockInfo = new stockInfo();
        decimal myEnteredQty;
        int myDecimalPoints;
        decimal myFactor;
        DataTable myGodownQty;

        public DataTable returnQtyDetails { get; set; }
        public decimal returnSelectedQty { get; set; }

        DataTable tempData = new DataTable();
        DataTable myGodownWiseQty;
  


        public frmGodownSelection(long barCode,string qty,string selectedUnit, decimal factor,DataTable godownQty, int decimalPoints, DataTable qtyDetails)
        {


            InitializeComponent();
            //lblItemCode.Text = itemCode.ToString();
            //lblItemName.Text = itemName.ToString();
            lblQty.Text = myGenaralFunctions.FormatDecimalPlace(qty, decimalPoints);
            myEnteredQty = Convert.ToDecimal(qty);
            myBarCode = barCode;
         
            myDecimalPoints = decimalPoints;

            myGodownWiseQty = qtyDetails;
            lblSelectUnit.Text = "("+selectedUnit+")";
            myFactor = factor;
            myGodownQty = godownQty;
        }


        private void frmGodownSelection_Shown(object sender, EventArgs e)
        {


        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {

            if (msg.WParam.ToInt32() == (int)Keys.Enter)
            {
                calculateTotalQty();
                if (dgvDetails.CurrentRow.Index == dgvDetails.Rows.Count - 1 || lblQty.Text == lblSelectedQty.Text)
                {

                    tempData.Columns.Add("godownId", typeof(int));
                    tempData.Columns.Add("qty", typeof(decimal));

                    for (int i = 0; i < dgvDetails.RowCount; i++)
                    {
                        if (dgvDetails.Rows[i].Cells["clmQty"].Value != null && Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmQty"].Value.ToString()) != 0)
                        {

                            tempData.Rows.Add(Convert.ToInt32(dgvDetails.Rows[i].Cells["clmGodownId"].Value), Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmQty"].Value));

                        }
                    }

                    returnQtyDetails = tempData;
                    returnSelectedQty = Convert.ToDecimal(lblSelectedQty.Text);

                    this.Close();
                }
                else
                {
                    SendKeys.Send("{Tab}");

                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);


        }
        private void dgvDetails_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            calculateTotalQty();
            int rowIndex = Convert.ToInt32(e.RowIndex);
            int count = dgvDetails.RowCount;

            switch (dgvDetails.CurrentCell.ColumnInfo.Name.ToString())
            {
                case "clmQty":
                    {
                        if (dgvDetails.Rows[rowIndex].Cells["clmQty"].Value != null)
                        {
                            if (Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmQty"].Value) <=( Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmSUnitStock"].Value)- Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmBillQty"].Value)))
                            {
                                if (Convert.ToDecimal(lblSelectedQty.Text) <= Convert.ToDecimal(lblQty.Text))
                                {

                                    dgvDetails.Rows[rowIndex].Cells["clmQty"].Value = myGenaralFunctions.FormatDecimalPlace(dgvDetails.Rows[rowIndex].Cells["clmQty"].Value.ToString(), myDecimalPoints);
                                    //if (rowIndex > count - 1 || Convert.ToDecimal(lblQty.Text) > Convert.ToDecimal(lblQty.Text))
                                    //{
                                    //    dgvDetails.Rows[rowIndex + 1].IsCurrent = true;
                                    //    dgvDetails.Columns[3].IsCurrent = true;

                                    //    dgvDetails.PerformLayout();

                                    //    dgvDetails.BeginEdit();
                                    //    dgvDetails.Rows[rowIndex + 1].Cells["clmQty"].IsSelected = true;
                                    //}
                                    //else
                                    //{
                                    //    this.Close();
                                    //}
                                }

                                else

                                {
                                    MessageBox.Show("selected stock is more  ", "True Account Pro", MessageBoxButtons.YesNo);

                                    dgvDetails.Rows[rowIndex].Cells["clmQty"].Value = myGenaralFunctions.FormatDecimalPlace((Convert.ToDecimal(lblQty.Text) - Convert.ToDecimal(lblSelectedQty.Text)).ToString(), myDecimalPoints);

                                }
                            }

                            else
                            {
                                if (DialogResult.Yes == MessageBox.Show("Out of stock in this Godown,Are you sure you want to countinue with balance stock ?  ", "True Account Pro", MessageBoxButtons.YesNo))
                                {
                                    dgvDetails.Rows[rowIndex].Cells["clmQty"].Value = myGenaralFunctions.FormatDecimalPlace((Convert.ToDecimal( dgvDetails.Rows[rowIndex].Cells["clmUnitStock"].Value.ToString())- Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmBillQty"].Value.ToString())).ToString(), myDecimalPoints);
                                    //    if (rowIndex > count - 1 || Convert.ToDecimal(lblQty.Text) > Convert.ToDecimal(lblQty.Text))
                                    //    {
                                    //        dgvDetails.Rows[rowIndex + 1].IsCurrent = true;
                                    //        dgvDetails.Columns[3].IsCurrent = true;

                                    //        dgvDetails.PerformLayout();

                                    //        dgvDetails.BeginEdit();
                                    //        dgvDetails.Rows[rowIndex + 1].Cells["clmQty"].IsSelected = true;
                                    //    }
                                    //    else
                                    //    {
                                    //        this.Close();
                                    //    }
                                }
                                else
                                {

                                    dgvDetails.Rows[rowIndex].Cells["clmQty"].Value = myGenaralFunctions.FormatDecimalPlace("0", myDecimalPoints);


                                }
                            }

                        }



                        calculateTotalQty();
                        break;
                    }
            }

        }
        private void calculateTotalQty()
        {
            lblSelectedQty.Text = "0";
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                if (dgvDetails.Rows[i].Cells["clmQty"].Value != null)
                {
                    lblSelectedQty.Text = (Convert.ToDecimal(lblSelectedQty.Text) + Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmQty"].Value.ToString())).ToString();
                }
            }
        }

        private void dgvDetails_CellEditorInitialized(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {

        }

        private void dgvDetails_CellValidating(object sender, Telerik.WinControls.UI.CellValidatingEventArgs e)
        {
            //int rowIndex = Convert.ToInt32(e.RowIndex);
            //int count = dgvDetails.RowCount;
            //decimal selectedQty = Convert.ToDecimal(lblSelectedQty.Text);

            //if (e.Column == dgvDetails.Columns["clmQty"])
            //{
            //    if (myEnteredQty != selectedQty)
            //    {
            //        if (Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmStock"].Value.ToString()) >= (myEnteredQty - selectedQty))
            //        {
            //            dgvDetails.Rows[rowIndex].Cells["clmQty"].Value = myEnteredQty - selectedQty;
            //        }
            //        else
            //        {
            //            dgvDetails.Rows[rowIndex].Cells["clmQty"].Value = dgvDetails.Rows[rowIndex].Cells["clmStock"].Value;
            //        }
            //    }
            //}
        }

        private void dgvDetails_CellBeginEdit(object sender, Telerik.WinControls.UI.GridViewCellCancelEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.RowIndex);
            int count = dgvDetails.RowCount;
            decimal selectedQty = Convert.ToDecimal(lblSelectedQty.Text);

            if (e.Column == dgvDetails.Columns["clmQty"])
            {
                if (dgvDetails.Rows[rowIndex].Cells["clmQty"].Value == null || Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmQty"].Value.ToString()) == 0)
                {
                    if (myEnteredQty >= selectedQty)
                    {
                        if ((Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmSUnitStock"].Value.ToString())- Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmBillQty"].Value.ToString())) >= (myEnteredQty - selectedQty))
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmQty"].Value = myEnteredQty - selectedQty;



                        }
                        else
                        {
                            dgvDetails.Rows[rowIndex].Cells["clmQty"].Value = Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmSUnitStock"].Value.ToString()) - Convert.ToDecimal(dgvDetails.Rows[rowIndex].Cells["clmBillQty"].Value.ToString());
                        }


                    }
                    else
                    {

                        dgvDetails.Rows[rowIndex].Cells["clmQty"].Value = myGenaralFunctions.FormatDecimalPlace(dgvDetails.Rows[rowIndex].Cells["clmQty"].Value.ToString(), myDecimalPoints);
                    }
                    dgvDetails.Rows[rowIndex].Cells["clmQty"].IsSelected = true;
                    dgvDetails.Focus();

                }
            }
        }

        private void frmGodownSelection_Load(object sender, EventArgs e)
        {
            decimal selectunitstock;
            decimal balanceBaseStock;
            decimal reminder;
            myStockInfo.ourBarCode = myBarCode;

            DataSet details = myStockLedgerOpr.getStockGodownWise(myStockInfo);
            lblItemCode.Text = details.Tables[0].Rows[0]["product_code"].ToString();
            lblItemName.Text = details.Tables[0].Rows[0]["product_name"].ToString();
            lblBasicUnit.Text = "(" + details.Tables[0].Rows[0]["unit_name"].ToString() + ")";
            if (details.Tables[0].Rows.Count > 0)
            {
                dgvDetails.Rows.Clear();
                for (int i = 0; i < details.Tables[0].Rows.Count; i++)
                {


                    dgvDetails.Rows.AddNew();
                    dgvDetails.Rows[i].Cells["clmGodownId"].Value = details.Tables[0].Rows[i]["godown_id"].ToString();
                    dgvDetails.Rows[i].Cells["clmGodownCode"].Value = details.Tables[0].Rows[i]["godown_code"].ToString();
                    dgvDetails.Rows[i].Cells["clmGodownName"].Value = details.Tables[0].Rows[i]["godown_name"].ToString();
                    balanceBaseStock = Convert.ToDecimal(details.Tables[0].Rows[i]["stock"].ToString()) % myFactor;
                    selectunitstock = (Convert.ToDecimal(details.Tables[0].Rows[i]["stock"].ToString()) - balanceBaseStock) / myFactor;


                    dgvDetails.Rows[i].Cells["clmSUnitStock"].Value = myGenaralFunctions.FormatDecimalPlace(selectunitstock.ToString(), myDecimalPoints);
                    dgvDetails.Rows[i].Cells["clmBUnitStock"].Value = myGenaralFunctions.FormatDecimalPlace(balanceBaseStock.ToString(), myDecimalPoints);
                    dgvDetails.Rows[i].Cells["clmBillQty"].Value = myGenaralFunctions.FormatDecimalPlace("0", myDecimalPoints);
                    if (myGodownQty != null)
                    {
                        for (int j = 0; j < myGodownQty.Rows.Count; j++)
                        {
                            if (dgvDetails.Rows[i].Cells["clmGodownId"].Value.ToString() == myGodownQty.Rows[j]["godownId"].ToString())
                            {
                                dgvDetails.Rows[i].Cells["clmBillQty"].Value = Convert.ToDecimal(dgvDetails.Rows[i].Cells["clmBillQty"].Value.ToString()) + (Convert.ToDecimal(myGodownQty.Rows[j]["qty"].ToString()) / myFactor); ;
                            }
                        }
                    }
                    if (myGodownWiseQty != null && myGodownWiseQty.Rows.Count > 0)
                    {
                        for (int j = 0; j < myGodownWiseQty.Rows.Count; j++)
                        {
                            if (myGodownWiseQty.Rows[j]["godownId"].ToString() == dgvDetails.Rows[i].Cells["clmGodownId"].Value.ToString())
                            {
                                dgvDetails.Rows[i].Cells["clmQty"].Value = myGodownWiseQty.Rows[j]["qty"].ToString();
                            }

                        }
                    }

                }


                dgvDetails.Rows[0].IsCurrent = true;
                dgvDetails.Columns["clmQty"].IsCurrent = true;

                dgvDetails.PerformLayout();

                dgvDetails.BeginEdit();
                dgvDetails.Rows[0].Cells["clmQty"].IsSelected = true;
                dgvDetails.Focus();




            }

            }
        }
    }
