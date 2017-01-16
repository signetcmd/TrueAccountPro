namespace TrueAccountPro
{
    partial class frmSettings
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem9 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem10 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem11 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem12 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem13 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem14 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem15 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem16 = new Telerik.WinControls.UI.RadListDataItem();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.sedEntryNo = new Telerik.WinControls.UI.RadSpinEditor();
            this.txtInvoiceNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.ddlDateFormat = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sedEntryNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDateFormat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Controls.Add(this.radPageViewPage2);
            this.radPageView1.Controls.Add(this.radPageViewPage3);
            this.radPageView1.ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
            this.radPageView1.Location = new System.Drawing.Point(1, 2);
            this.radPageView1.Name = "radPageView1";
            // 
            // 
            // 
            this.radPageView1.RootElement.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentContent;
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(726, 325);
            this.radPageView1.TabIndex = 0;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripScrollingAnimation = Telerik.WinControls.RadEasingType.OutElastic;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemAlignment = Telerik.WinControls.UI.StripViewItemAlignment.Near;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemFitMode = ((Telerik.WinControls.UI.StripViewItemFitMode)((Telerik.WinControls.UI.StripViewItemFitMode.Shrink | Telerik.WinControls.UI.StripViewItemFitMode.Fill)));
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ItemSizeMode = Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth;
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radPageViewPage1.Controls.Add(this.ddlDateFormat);
            this.radPageViewPage1.Controls.Add(this.radLabel3);
            this.radPageViewPage1.Controls.Add(this.radGroupBox1);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(237F, 28F);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(705, 277);
            this.radPageViewPage1.Text = "Genaral ";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.sedEntryNo);
            this.radGroupBox1.Controls.Add(this.txtInvoiceNo);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.HeaderText = "Barcode";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 50);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(167, 78);
            this.radGroupBox1.TabIndex = 13;
            this.radGroupBox1.Text = "Barcode";
            // 
            // sedEntryNo
            // 
            this.sedEntryNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sedEntryNo.Location = new System.Drawing.Point(57, 19);
            this.sedEntryNo.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sedEntryNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sedEntryNo.Name = "sedEntryNo";
            this.sedEntryNo.Size = new System.Drawing.Size(68, 25);
            this.sedEntryNo.TabIndex = 11;
            this.sedEntryNo.TabStop = false;
            this.sedEntryNo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.sedEntryNo.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(57, 46);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(68, 25);
            this.txtInvoiceNo.TabIndex = 12;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(9, 24);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(44, 19);
            this.radLabel2.TabIndex = 10;
            this.radLabel2.Text = "Length";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(9, 48);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(37, 19);
            this.radLabel1.TabIndex = 10;
            this.radLabel1.Text = "Prefix";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.ItemSize = new System.Drawing.SizeF(237F, 28F);
            this.radPageViewPage2.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(705, 289);
            this.radPageViewPage2.Text = "Purchase";
            // 
            // radPageViewPage3
            // 
            this.radPageViewPage3.ItemSize = new System.Drawing.SizeF(237F, 28F);
            this.radPageViewPage3.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage3.Name = "radPageViewPage3";
            this.radPageViewPage3.Size = new System.Drawing.Size(705, 289);
            this.radPageViewPage3.Text = "Sale";
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(-2, 1);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(74, 19);
            this.radLabel3.TabIndex = 15;
            this.radLabel3.Text = "Date Format";
            // 
            // ddlDateFormat
            // 
            this.ddlDateFormat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem9.Text = "dd/mm/yy";
            radListDataItem10.Text = "m/d/yyyy";
            radListDataItem11.Text = "m/d/yy";
            radListDataItem12.Text = "mm/dd/yy";
            radListDataItem13.Text = "mm/dd/yyyy";
            radListDataItem14.Text = "yy/mm/dd";
            radListDataItem15.Text = "yyyy/mm/dd";
            radListDataItem16.Text = "dd/MMM/yy";
            this.ddlDateFormat.Items.Add(radListDataItem9);
            this.ddlDateFormat.Items.Add(radListDataItem10);
            this.ddlDateFormat.Items.Add(radListDataItem11);
            this.ddlDateFormat.Items.Add(radListDataItem12);
            this.ddlDateFormat.Items.Add(radListDataItem13);
            this.ddlDateFormat.Items.Add(radListDataItem14);
            this.ddlDateFormat.Items.Add(radListDataItem15);
            this.ddlDateFormat.Items.Add(radListDataItem16);
            this.ddlDateFormat.Location = new System.Drawing.Point(1, 21);
            this.ddlDateFormat.Name = "ddlDateFormat";
            this.ddlDateFormat.Size = new System.Drawing.Size(169, 25);
            this.ddlDateFormat.TabIndex = 16;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(727, 339);
            this.Controls.Add(this.radPageView1);
            this.Name = "frmSettings";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sedEntryNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDateFormat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadSpinEditor sedEntryNo;
        private Telerik.WinControls.UI.RadTextBox txtInvoiceNo;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadDropDownList ddlDateFormat;
    }
}
