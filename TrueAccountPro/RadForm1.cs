using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrueAccountPro
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void radMenuHeaderItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void ledgerGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLedgerGroup myled = new frmLedgerGroup();
            myled.Show();
        }

        private void ledgerNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLedgerName myled = new frmLedgerName();
            myled.Show();
        }

        private void sundryCreditorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSundryCreditor sundr = new frmSundryCreditor("creditor");
            sundr.Show();
        }

        private void sundryDebitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSundryCreditor sundr = new frmSundryCreditor("debitor");
            sundr.Show();
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {

        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasters master = new frmMasters("Post");
            master.Show();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductMaster prd = new TrueAccountPro.frmProductMaster();
            prd.Show();
        }

        private void openingStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOpeningStock st = new frmOpeningStock();
            st.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchase ps = new frmPurchase();
            ps.Show();
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSettings settings = new TrueAccountPro.frmSettings();
            settings.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSales settings = new TrueAccountPro.frmSales();
            settings.Show();
        }

        private void updateBarCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateBarCode frm = new frmUpdateBarCode();
            frm.MdiParent=this.MdiParent;
            frm.Show();
        }
    }
}
