namespace TrueAccountPro
{
    partial class frmPurchaseAltUnit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn33 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn34 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn35 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn36 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn37 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn38 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn39 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn40 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn41 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn42 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn43 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn44 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn45 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn46 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn47 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn48 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dgvDetails = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radApply = new Telerik.WinControls.UI.RadButton();
            this.lblItemName = new Telerik.WinControls.UI.RadLabel();
            this.lblItemCode = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel18 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radApply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetails
            // 
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.AutoGenerateHierarchy = true;
            this.dgvDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dgvDetails.ForeColor = System.Drawing.Color.Black;
            this.dgvDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvDetails.Location = new System.Drawing.Point(0, 55);
            // 
            // 
            // 
            this.dgvDetails.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.dgvDetails.MasterTemplate.AllowAddNewRow = false;
            this.dgvDetails.MasterTemplate.AllowColumnReorder = false;
            this.dgvDetails.MasterTemplate.AllowColumnResize = false;
            this.dgvDetails.MasterTemplate.AllowRowResize = false;
            this.dgvDetails.MasterTemplate.AutoExpandGroups = true;
            this.dgvDetails.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn33.EnableExpressionEditor = false;
            gridViewTextBoxColumn33.HeaderText = "Unit ID";
            gridViewTextBoxColumn33.IsVisible = false;
            gridViewTextBoxColumn33.Name = "clmUnitId";
            gridViewTextBoxColumn34.EnableExpressionEditor = false;
            gridViewTextBoxColumn34.HeaderText = "Unit";
            gridViewTextBoxColumn34.Name = "clmUnit";
            gridViewTextBoxColumn34.ReadOnly = true;
            gridViewTextBoxColumn34.Width = 101;
            gridViewTextBoxColumn35.EnableExpressionEditor = false;
            gridViewTextBoxColumn35.HeaderText = "Factor";
            gridViewTextBoxColumn35.Name = "clmFactor";
            gridViewTextBoxColumn35.ReadOnly = true;
            gridViewTextBoxColumn35.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn35.Width = 49;
            gridViewTextBoxColumn36.EnableExpressionEditor = false;
            gridViewTextBoxColumn36.HeaderText = "=";
            gridViewTextBoxColumn36.Name = "clmEqualTo";
            gridViewTextBoxColumn36.ReadOnly = true;
            gridViewTextBoxColumn36.Width = 20;
            gridViewTextBoxColumn37.EnableExpressionEditor = false;
            gridViewTextBoxColumn37.HeaderText = "B.Unit";
            gridViewTextBoxColumn37.Name = "clmBUnit";
            gridViewTextBoxColumn37.ReadOnly = true;
            gridViewTextBoxColumn37.Width = 101;
            gridViewTextBoxColumn38.EnableExpressionEditor = false;
            gridViewTextBoxColumn38.HeaderText = "Cost";
            gridViewTextBoxColumn38.Name = "clmCost";
            gridViewTextBoxColumn38.ReadOnly = true;
            gridViewTextBoxColumn38.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn38.Width = 81;
            gridViewTextBoxColumn39.DataType = typeof(decimal);
            gridViewTextBoxColumn39.EnableExpressionEditor = false;
            gridViewTextBoxColumn39.HeaderText = "Pro%";
            gridViewTextBoxColumn39.Name = "clmRetailPro";
            gridViewTextBoxColumn39.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn39.Width = 49;
            gridViewTextBoxColumn40.DataType = typeof(decimal);
            gridViewTextBoxColumn40.EnableExpressionEditor = false;
            gridViewTextBoxColumn40.HeaderText = "Retail Rate";
            gridViewTextBoxColumn40.Name = "clmRetailRate";
            gridViewTextBoxColumn40.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn40.Width = 81;
            gridViewTextBoxColumn41.DataType = typeof(decimal);
            gridViewTextBoxColumn41.EnableExpressionEditor = false;
            gridViewTextBoxColumn41.HeaderText = "Pro%";
            gridViewTextBoxColumn41.Name = "clmMrpPro";
            gridViewTextBoxColumn41.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn41.Width = 49;
            gridViewTextBoxColumn42.DataType = typeof(decimal);
            gridViewTextBoxColumn42.EnableExpressionEditor = false;
            gridViewTextBoxColumn42.HeaderText = "MRP";
            gridViewTextBoxColumn42.Name = "clmMrp";
            gridViewTextBoxColumn42.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn42.Width = 81;
            gridViewTextBoxColumn43.DataType = typeof(decimal);
            gridViewTextBoxColumn43.EnableExpressionEditor = false;
            gridViewTextBoxColumn43.HeaderText = "Pro%";
            gridViewTextBoxColumn43.Name = "clmSpecialratePro";
            gridViewTextBoxColumn43.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn43.Width = 49;
            gridViewTextBoxColumn44.DataType = typeof(decimal);
            gridViewTextBoxColumn44.EnableExpressionEditor = false;
            gridViewTextBoxColumn44.HeaderText = "Special Rate";
            gridViewTextBoxColumn44.Name = "clmSpRate";
            gridViewTextBoxColumn44.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn44.Width = 81;
            gridViewTextBoxColumn45.DataType = typeof(decimal);
            gridViewTextBoxColumn45.EnableExpressionEditor = false;
            gridViewTextBoxColumn45.HeaderText = "Pro%";
            gridViewTextBoxColumn45.Name = "clmWhPro";
            gridViewTextBoxColumn45.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn45.Width = 49;
            gridViewTextBoxColumn46.DataType = typeof(decimal);
            gridViewTextBoxColumn46.EnableExpressionEditor = false;
            gridViewTextBoxColumn46.HeaderText = "Whole Sale";
            gridViewTextBoxColumn46.Name = "clmWholeSale";
            gridViewTextBoxColumn46.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn46.Width = 81;
            gridViewTextBoxColumn47.DataType = typeof(decimal);
            gridViewTextBoxColumn47.EnableExpressionEditor = false;
            gridViewTextBoxColumn47.HeaderText = "Pro%";
            gridViewTextBoxColumn47.Name = "clmBranchPro";
            gridViewTextBoxColumn47.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn47.Width = 49;
            gridViewTextBoxColumn48.EnableExpressionEditor = false;
            gridViewTextBoxColumn48.HeaderText = "Branch Rate";
            gridViewTextBoxColumn48.Name = "clmBranchRate";
            gridViewTextBoxColumn48.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn48.Width = 82;
            this.dgvDetails.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn33,
            gridViewTextBoxColumn34,
            gridViewTextBoxColumn35,
            gridViewTextBoxColumn36,
            gridViewTextBoxColumn37,
            gridViewTextBoxColumn38,
            gridViewTextBoxColumn39,
            gridViewTextBoxColumn40,
            gridViewTextBoxColumn41,
            gridViewTextBoxColumn42,
            gridViewTextBoxColumn43,
            gridViewTextBoxColumn44,
            gridViewTextBoxColumn45,
            gridViewTextBoxColumn46,
            gridViewTextBoxColumn47,
            gridViewTextBoxColumn48});
            this.dgvDetails.MasterTemplate.EnableGrouping = false;
            this.dgvDetails.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.dgvDetails.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // 
            // 
            this.dgvDetails.RootElement.ToolTipText = "Nabe";
            this.dgvDetails.Size = new System.Drawing.Size(1026, 235);
            this.dgvDetails.TabIndex = 48;
            this.dgvDetails.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgvDetails_CellEndEdit);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radButton2);
            this.radGroupBox1.Controls.Add(this.radApply);
            this.radGroupBox1.Controls.Add(this.lblItemName);
            this.radGroupBox1.Controls.Add(this.lblItemCode);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.radLabel18);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1026, 55);
            this.radGroupBox1.TabIndex = 49;
            // 
            // radButton2
            // 
            this.radButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radButton2.Location = new System.Drawing.Point(914, 11);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(92, 34);
            this.radButton2.TabIndex = 37;
            this.radButton2.Text = "Clear";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radApply
            // 
            this.radApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radApply.Location = new System.Drawing.Point(808, 11);
            this.radApply.Name = "radApply";
            this.radApply.Size = new System.Drawing.Size(92, 34);
            this.radApply.TabIndex = 37;
            this.radApply.Text = "Apply";
            this.radApply.Click += new System.EventHandler(this.radApply_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(71, 28);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(2, 2);
            this.lblItemName.TabIndex = 33;
            // 
            // lblItemCode
            // 
            this.lblItemCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.Location = new System.Drawing.Point(71, 7);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(2, 2);
            this.lblItemCode.TabIndex = 34;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(6, 9);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(64, 18);
            this.radLabel1.TabIndex = 35;
            this.radLabel1.Text = "Item Code :";
            // 
            // radLabel18
            // 
            this.radLabel18.Location = new System.Drawing.Point(5, 29);
            this.radLabel18.Name = "radLabel18";
            this.radLabel18.Size = new System.Drawing.Size(64, 18);
            this.radLabel18.TabIndex = 36;
            this.radLabel18.Text = "Item Name:";
            // 
            // frmPurchaseAltUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1026, 290);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.dgvDetails);
            this.MinimumSize = new System.Drawing.Size(1034, 320);
            this.Name = "frmPurchaseAltUnit";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(0, 0);
            this.Text = "Purchase Alternate Unit";
            this.Load += new System.EventHandler(this.frmPurchaseAltUnit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radApply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dgvDetails;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel lblItemName;
        private Telerik.WinControls.UI.RadLabel lblItemCode;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel18;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radApply;
    }
}
