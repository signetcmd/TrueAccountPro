namespace TrueAccountPro
{
    partial class frmGodownSelection
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
            Telerik.WinControls.UI.GridViewMultiComboBoxColumn gridViewMultiComboBoxColumn1 = new Telerik.WinControls.UI.GridViewMultiComboBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.dgvDetails = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.lblBasicUnit = new Telerik.WinControls.UI.RadLabel();
            this.lblSelectUnit = new Telerik.WinControls.UI.RadLabel();
            this.lblSelectedQty = new Telerik.WinControls.UI.RadLabel();
            this.lblQty = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.lblItemName = new Telerik.WinControls.UI.RadLabel();
            this.lblItemCode = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel18 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBasicUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectedQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDetails
            // 
            this.dgvDetails.AutoGenerateHierarchy = true;
            this.dgvDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetails.Location = new System.Drawing.Point(3, 61);
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
            gridViewTextBoxColumn1.HeaderText = "Godown ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "clmGodownId";
            gridViewTextBoxColumn2.HeaderText = "Code";
            gridViewTextBoxColumn2.Name = "clmGodownCode";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 100;
            gridViewMultiComboBoxColumn1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            gridViewMultiComboBoxColumn1.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDown;
            gridViewMultiComboBoxColumn1.HeaderText = "Godown Name";
            gridViewMultiComboBoxColumn1.Name = "clmGodownName";
            gridViewMultiComboBoxColumn1.ReadOnly = true;
            gridViewMultiComboBoxColumn1.Width = 250;
            gridViewTextBoxColumn3.HeaderText = "Select Unit Stock";
            gridViewTextBoxColumn3.Name = "clmSUnitStock";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 110;
            gridViewTextBoxColumn4.HeaderText = "Basic Unit Stock";
            gridViewTextBoxColumn4.Name = "clmBUnitStock";
            gridViewTextBoxColumn4.Width = 110;
            gridViewTextBoxColumn5.HeaderText = "Bill Qty";
            gridViewTextBoxColumn5.Name = "clmBillQty";
            gridViewTextBoxColumn5.Width = 110;
            gridViewTextBoxColumn6.DataType = typeof(decimal);
            gridViewTextBoxColumn6.HeaderText = "Qty";
            gridViewTextBoxColumn6.Name = "clmQty";
            gridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            gridViewTextBoxColumn6.Width = 110;
            this.dgvDetails.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewMultiComboBoxColumn1,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.dgvDetails.MasterTemplate.EnableGrouping = false;
            this.dgvDetails.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
            this.dgvDetails.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.dgvDetails.Name = "dgvDetails";
            // 
            // 
            // 
            this.dgvDetails.RootElement.ToolTipText = "Nabe";
            this.dgvDetails.Size = new System.Drawing.Size(824, 184);
            this.dgvDetails.TabIndex = 17;
            this.dgvDetails.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.dgvDetails_CellBeginEdit);
            this.dgvDetails.CellEditorInitialized += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgvDetails_CellEditorInitialized);
            this.dgvDetails.CellEndEdit += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgvDetails_CellEndEdit);
            this.dgvDetails.CellValidating += new Telerik.WinControls.UI.CellValidatingEventHandler(this.dgvDetails_CellValidating);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.lblBasicUnit);
            this.radGroupBox1.Controls.Add(this.lblSelectUnit);
            this.radGroupBox1.Controls.Add(this.lblSelectedQty);
            this.radGroupBox1.Controls.Add(this.lblQty);
            this.radGroupBox1.Controls.Add(this.radLabel6);
            this.radGroupBox1.Controls.Add(this.radLabel7);
            this.radGroupBox1.Controls.Add(this.lblItemName);
            this.radGroupBox1.Controls.Add(this.lblItemCode);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.radLabel18);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 5);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(824, 51);
            this.radGroupBox1.TabIndex = 18;
            // 
            // lblBasicUnit
            // 
            this.lblBasicUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblBasicUnit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBasicUnit.Location = new System.Drawing.Point(511, 31);
            this.lblBasicUnit.Name = "lblBasicUnit";
            this.lblBasicUnit.Size = new System.Drawing.Size(30, 21);
            this.lblBasicUnit.TabIndex = 35;
            this.lblBasicUnit.Text = "unit";
            this.lblBasicUnit.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelectUnit
            // 
            this.lblSelectUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectUnit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectUnit.Location = new System.Drawing.Point(404, 31);
            this.lblSelectUnit.Name = "lblSelectUnit";
            this.lblSelectUnit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSelectUnit.Size = new System.Drawing.Size(30, 21);
            this.lblSelectUnit.TabIndex = 33;
            this.lblSelectUnit.Text = "unit";
            this.lblSelectUnit.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSelectedQty
            // 
            this.lblSelectedQty.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedQty.Location = new System.Drawing.Point(772, 28);
            this.lblSelectedQty.Name = "lblSelectedQty";
            this.lblSelectedQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSelectedQty.Size = new System.Drawing.Size(34, 21);
            this.lblSelectedQty.TabIndex = 29;
            this.lblSelectedQty.Text = "0.00";
            this.lblSelectedQty.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblQty
            // 
            this.lblQty.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(771, 9);
            this.lblQty.Name = "lblQty";
            this.lblQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblQty.Size = new System.Drawing.Size(34, 21);
            this.lblQty.TabIndex = 30;
            this.lblQty.Text = "0.00";
            this.lblQty.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(677, 9);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(77, 18);
            this.radLabel6.TabIndex = 31;
            this.radLabel6.Text = "Sales Qty       :";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(677, 28);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(75, 18);
            this.radLabel7.TabIndex = 32;
            this.radLabel7.Text = "Selected Qty :";
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(72, 25);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(72, 21);
            this.lblItemName.TabIndex = 25;
            this.lblItemName.Text = "Item Code";
            this.lblItemName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblItemCode
            // 
            this.lblItemCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.Location = new System.Drawing.Point(71, 5);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(72, 21);
            this.lblItemCode.TabIndex = 26;
            this.lblItemCode.Text = "Item Code";
            this.lblItemCode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(6, 6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(67, 18);
            this.radLabel1.TabIndex = 27;
            this.radLabel1.Text = "Item Code  :";
            // 
            // radLabel18
            // 
            this.radLabel18.Location = new System.Drawing.Point(6, 26);
            this.radLabel18.Name = "radLabel18";
            this.radLabel18.Size = new System.Drawing.Size(67, 18);
            this.radLabel18.TabIndex = 28;
            this.radLabel18.Text = "Item Name :";
            // 
            // frmGodownSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 249);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.dgvDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGodownSelection";
            this.Text = "Godown Wise Qty";
            this.Load += new System.EventHandler(this.frmGodownSelection_Load);
            this.Shown += new System.EventHandler(this.frmGodownSelection_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBasicUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectedQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblItemCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel18)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView dgvDetails;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel lblSelectedQty;
        private Telerik.WinControls.UI.RadLabel lblQty;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel lblItemName;
        private Telerik.WinControls.UI.RadLabel lblItemCode;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel18;
        private Telerik.WinControls.UI.RadLabel lblBasicUnit;
        private Telerik.WinControls.UI.RadLabel lblSelectUnit;
    }
}