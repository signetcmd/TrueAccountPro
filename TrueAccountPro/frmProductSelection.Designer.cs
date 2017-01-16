namespace TrueAccountPro
{
    partial class frmProductSelection
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewMultiComboBoxColumn gridViewMultiComboBoxColumn1 = new Telerik.WinControls.UI.GridViewMultiComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dgvDetails = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.lblItemName = new Telerik.WinControls.UI.RadLabel();
            this.lblItemCode = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel18 = new Telerik.WinControls.UI.RadLabel();
            this.dgvRateDetails = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.ddlUnits = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateDetails.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetails
            // 
            this.dgvDetails.AutoGenerateHierarchy = true;
            this.dgvDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetails.Location = new System.Drawing.Point(1, 53);
            // 
            // 
            // 
            this.dgvDetails.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.dgvDetails.MasterTemplate.AllowAddNewRow = false;
            this.dgvDetails.MasterTemplate.AllowColumnReorder = false;
            this.dgvDetails.MasterTemplate.AllowColumnResize = false;
            this.dgvDetails.MasterTemplate.AllowDeleteRow = false;
            this.dgvDetails.MasterTemplate.AllowRowResize = false;
            this.dgvDetails.MasterTemplate.AutoExpandGroups = true;
            gridViewTextBoxColumn1.HeaderText = "Product";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "clmProductId";
            gridViewTextBoxColumn2.HeaderText = "Barcode";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "clmBarCode";
            gridViewTextBoxColumn3.HeaderText = "Barcode ID";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "clmBarCodeId";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn4.HeaderText = "Identity";
            gridViewTextBoxColumn4.Name = "clmIdentity";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 100;
            gridViewTextBoxColumn5.HeaderText = "Entry No";
            gridViewTextBoxColumn5.Name = "clmEntryNo";
            gridViewTextBoxColumn5.ReadOnly = true;
            gridViewTextBoxColumn5.Width = 100;
            gridViewMultiComboBoxColumn1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            gridViewMultiComboBoxColumn1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            gridViewMultiComboBoxColumn1.HeaderText = "Batch";
            gridViewMultiComboBoxColumn1.Name = "clmBatch";
            gridViewMultiComboBoxColumn1.ReadOnly = true;
            gridViewMultiComboBoxColumn1.Width = 110;
            gridViewTextBoxColumn6.HeaderText = "EXP Date";
            gridViewTextBoxColumn6.Name = "clmExpDate";
            gridViewTextBoxColumn6.ReadOnly = true;
            gridViewTextBoxColumn6.Width = 110;
            gridViewTextBoxColumn7.DataType = typeof(decimal);
            gridViewTextBoxColumn7.HeaderText = "Stock";
            gridViewTextBoxColumn7.Name = "clmStock";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn7.Width = 100;
            this.dgvDetails.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewMultiComboBoxColumn1,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.dgvDetails.MasterTemplate.EnableGrouping = false;
            this.dgvDetails.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.dgvDetails.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgvDetails.Name = "dgvDetails";
            // 
            // 
            // 
            this.dgvDetails.RootElement.ToolTipText = "Nabe";
            this.dgvDetails.Size = new System.Drawing.Size(557, 206);
            this.dgvDetails.TabIndex = 18;
            this.dgvDetails.CurrentRowChanging += new Telerik.WinControls.UI.CurrentRowChangingEventHandler(this.dgvDetails_CurrentRowChanging);
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.dgvDetails_SelectionChanged);
            this.dgvDetails.RowsChanged += new Telerik.WinControls.UI.GridViewCollectionChangedEventHandler(this.dgvDetails_RowsChanged);
            this.dgvDetails.RowsChanging += new Telerik.WinControls.UI.GridViewCollectionChangingEventHandler(this.dgvDetails_RowsChanging);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.lblItemName);
            this.radGroupBox1.Controls.Add(this.lblItemCode);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.radLabel18);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(1, 2);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(557, 48);
            this.radGroupBox1.TabIndex = 19;
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(472, 12);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(72, 21);
            this.lblItemName.TabIndex = 29;
            this.lblItemName.Text = "Item Code";
            // 
            // lblItemCode
            // 
            this.lblItemCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.Location = new System.Drawing.Point(74, 10);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(72, 21);
            this.lblItemCode.TabIndex = 30;
            this.lblItemCode.Text = "Item Code";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(9, 11);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(64, 18);
            this.radLabel1.TabIndex = 31;
            this.radLabel1.Text = "Item Code :";
            // 
            // radLabel18
            // 
            this.radLabel18.Location = new System.Drawing.Point(406, 13);
            this.radLabel18.Name = "radLabel18";
            this.radLabel18.Size = new System.Drawing.Size(64, 18);
            this.radLabel18.TabIndex = 32;
            this.radLabel18.Text = "Item Name:";
            // 
            // dgvRateDetails
            // 
            this.dgvRateDetails.AutoGenerateHierarchy = true;
            this.dgvRateDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRateDetails.Location = new System.Drawing.Point(561, 53);
            // 
            // 
            // 
            this.dgvRateDetails.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.dgvRateDetails.MasterTemplate.AllowAddNewRow = false;
            this.dgvRateDetails.MasterTemplate.AllowColumnReorder = false;
            this.dgvRateDetails.MasterTemplate.AllowColumnResize = false;
            this.dgvRateDetails.MasterTemplate.AllowDeleteRow = false;
            this.dgvRateDetails.MasterTemplate.AllowRowResize = false;
            this.dgvRateDetails.MasterTemplate.AutoExpandGroups = true;
            gridViewTextBoxColumn8.HeaderText = "Rate Name";
            gridViewTextBoxColumn8.Name = "clmRateName";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 150;
            gridViewTextBoxColumn9.HeaderText = "Amount";
            gridViewTextBoxColumn9.Name = "clmAmount";
            gridViewTextBoxColumn9.ReadOnly = true;
            gridViewTextBoxColumn9.Width = 100;
            this.dgvRateDetails.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9});
            this.dgvRateDetails.MasterTemplate.EnableGrouping = false;
            this.dgvRateDetails.MasterTemplate.ShowRowHeaderColumn = false;
            this.dgvRateDetails.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.dgvRateDetails.Name = "dgvRateDetails";
            // 
            // 
            // 
            this.dgvRateDetails.RootElement.ToolTipText = "Nabe";
            this.dgvRateDetails.Size = new System.Drawing.Size(252, 210);
            this.dgvRateDetails.TabIndex = 20;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.ddlUnits);
            this.radGroupBox2.Controls.Add(this.radLabel2);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(560, 2);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(252, 48);
            this.radGroupBox2.TabIndex = 21;
            // 
            // ddlUnits
            // 
            this.ddlUnits.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlUnits.Location = new System.Drawing.Point(82, 12);
            this.ddlUnits.Name = "ddlUnits";
            this.ddlUnits.Size = new System.Drawing.Size(134, 25);
            this.ddlUnits.TabIndex = 33;
            this.ddlUnits.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlUnits_SelectedIndexChanged);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(44, 16);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(33, 18);
            this.radLabel2.TabIndex = 32;
            this.radLabel2.Text = "Unit :";
            // 
            // frmProductSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 264);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.dgvRateDetails);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.dgvDetails);
            this.Name = "frmProductSelection";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Product Selection";
            this.Load += new System.EventHandler(this.frmProductSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateDetails.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRateDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
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
        private Telerik.WinControls.UI.RadGridView dgvRateDetails;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadDropDownList ddlUnits;
    }
}
