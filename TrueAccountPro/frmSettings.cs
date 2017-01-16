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
    public partial class frmSettings : Telerik.WinControls.UI.RadForm
    {
        public frmSettings()
        {
            InitializeComponent();

        }

        private void radDiagramRibbonBar1_Click(object sender, EventArgs e)
        {

        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            ddlDateFormat.SelectedIndex = 0;
        }
    }
}
