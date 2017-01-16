namespace TrueAccountPro
{
    partial class RadForm1
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
            this.components = new System.ComponentModel.Container();
            this.radContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.radContextMenuManager1 = new Telerik.WinControls.UI.RadContextMenuManager();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountMastersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledgerGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ledgerNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sundryCreditorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sundryDebitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openingStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateBarCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountMastersToolStripMenuItem,
            this.productToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(536, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountMastersToolStripMenuItem
            // 
            this.accountMastersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ledgerGroupToolStripMenuItem,
            this.ledgerNameToolStripMenuItem,
            this.sundryCreditorsToolStripMenuItem,
            this.sundryDebitorToolStripMenuItem,
            this.masterToolStripMenuItem});
            this.accountMastersToolStripMenuItem.Name = "accountMastersToolStripMenuItem";
            this.accountMastersToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.accountMastersToolStripMenuItem.Text = "Account Masters";
            // 
            // ledgerGroupToolStripMenuItem
            // 
            this.ledgerGroupToolStripMenuItem.Name = "ledgerGroupToolStripMenuItem";
            this.ledgerGroupToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ledgerGroupToolStripMenuItem.Text = "Ledger Group";
            this.ledgerGroupToolStripMenuItem.Click += new System.EventHandler(this.ledgerGroupToolStripMenuItem_Click);
            // 
            // ledgerNameToolStripMenuItem
            // 
            this.ledgerNameToolStripMenuItem.Name = "ledgerNameToolStripMenuItem";
            this.ledgerNameToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ledgerNameToolStripMenuItem.Text = "Ledger Name";
            this.ledgerNameToolStripMenuItem.Click += new System.EventHandler(this.ledgerNameToolStripMenuItem_Click);
            // 
            // sundryCreditorsToolStripMenuItem
            // 
            this.sundryCreditorsToolStripMenuItem.Name = "sundryCreditorsToolStripMenuItem";
            this.sundryCreditorsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.sundryCreditorsToolStripMenuItem.Text = "Sundry Creditors";
            this.sundryCreditorsToolStripMenuItem.Click += new System.EventHandler(this.sundryCreditorsToolStripMenuItem_Click);
            // 
            // sundryDebitorToolStripMenuItem
            // 
            this.sundryDebitorToolStripMenuItem.Name = "sundryDebitorToolStripMenuItem";
            this.sundryDebitorToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.sundryDebitorToolStripMenuItem.Text = "Sundry Debitor";
            this.sundryDebitorToolStripMenuItem.Click += new System.EventHandler(this.sundryDebitorToolStripMenuItem_Click);
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.masterToolStripMenuItem.Text = "Master";
            this.masterToolStripMenuItem.Click += new System.EventHandler(this.masterToolStripMenuItem_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem1,
            this.openingStockToolStripMenuItem,
            this.purchaseToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.updateBarCodeToolStripMenuItem});
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.productToolStripMenuItem.Text = "Product";
            // 
            // productToolStripMenuItem1
            // 
            this.productToolStripMenuItem1.Name = "productToolStripMenuItem1";
            this.productToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.productToolStripMenuItem1.Text = "Product";
            this.productToolStripMenuItem1.Click += new System.EventHandler(this.productToolStripMenuItem1_Click);
            // 
            // openingStockToolStripMenuItem
            // 
            this.openingStockToolStripMenuItem.Name = "openingStockToolStripMenuItem";
            this.openingStockToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openingStockToolStripMenuItem.Text = "Opening Stock";
            this.openingStockToolStripMenuItem.Click += new System.EventHandler(this.openingStockToolStripMenuItem_Click);
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.purchaseToolStripMenuItem.Text = "Purchase";
            this.purchaseToolStripMenuItem.Click += new System.EventHandler(this.purchaseToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.salesToolStripMenuItem.Text = "Sales";
            this.salesToolStripMenuItem.Click += new System.EventHandler(this.salesToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem1});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // updateBarCodeToolStripMenuItem
            // 
            this.updateBarCodeToolStripMenuItem.Name = "updateBarCodeToolStripMenuItem";
            this.updateBarCodeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.updateBarCodeToolStripMenuItem.Text = "Update BarCode";
            this.updateBarCodeToolStripMenuItem.Click += new System.EventHandler(this.updateBarCodeToolStripMenuItem_Click);
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 290);
            this.Controls.Add(this.menuStrip1);
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RadForm1";
            this.Load += new System.EventHandler(this.RadForm1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadContextMenu radContextMenu1;
        private Telerik.WinControls.UI.RadContextMenuManager radContextMenuManager1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountMastersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledgerGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ledgerNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sundryCreditorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sundryDebitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openingStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateBarCodeToolStripMenuItem;
    }
}