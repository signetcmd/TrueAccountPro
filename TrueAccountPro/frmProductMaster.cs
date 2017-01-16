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
using Telerik.WinControls.UI;
using System.Drawing.Design;
using Telerik.WinControls.UI.Localization;

namespace TrueAccountPro
{
    public partial class frmProductMaster : Telerik.WinControls.UI.RadForm
    {
        public frmEditAttrubutesName fEAname;
        public int id;
        Label lblGroupName;
        Button btnClose;
        string query;
        DataSet ProductMasterDS;
        private int myproductID;
        string textFromParent = string.Empty;
        private System.Windows.Forms.Label label1;
        private bool validateItems = false;
        private RadPageViewStripElement stripElement;
        private StripViewItemLayout itemLayout;
        productMasterOpr myProMasterOpr = new productMasterOpr();
        productMasterInfo myProMasterInfo = new productMasterInfo();
        genaralFunctions myGenaralFunctions = new genaralFunctions();
        string CompUpdate, gUpdate;
        private long myProduct_id;
       
        public frmProductMaster()
        {
                
            InitializeComponent();
            
            pageViewerStyles();
          
        }
      

       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }
        public void ename()
        {

        }

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {

        }
        void item_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (RadPageViewStripItem item in itemLayout.Children)
                {
                    if (item == sender)
                    {
                        item.Font = new Font(item.Font.FontFamily, item.Font.Size, FontStyle.Bold);
                    }
                    else
                    {
                        item.Font = new Font(item.Font.FontFamily, item.Font.Size, FontStyle.Bold);
                    }
                }
            }
        }
        private void pageViewerStyles()
        {
            this.radPageView1.ViewElement.BackColor = Color.FromArgb(59, 61, 60);
            this.radPageView1.ViewElement.ItemSpacing = 12;
            this.radPageView1.ViewElement.ContentArea.BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.OuterInnerBorders;//OuterInnerBorders
            this.radPageView1.ViewElement.ContentArea.BorderColor = Color.FromArgb(59, 61, 60);


            this.pvpAttribute.Item.ForeColor = Color.FromArgb(180, 180, 180);
            this.pvpAttribute.Item.DrawFill = false;
            this.pvpAttribute.Item.DrawBorder = false;
            this.pvpAttribute.Item.Padding = new Padding(5, 10, 5, 10);
       


            this.PvpTaxDetails.Item.ForeColor = Color.FromArgb(180, 180, 180);
            this.PvpTaxDetails.Item.DrawFill = false;
            this.PvpTaxDetails.Item.DrawBorder = false;
            this.PvpTaxDetails.Item.Padding = new Padding(5, 10, 5, 10);

            this.radPageViewPage4.Item.ForeColor = Color.FromArgb(180, 180, 180);
            this.radPageViewPage4.Item.DrawFill = false;
            this.radPageViewPage4.Item.DrawBorder = false;
            this.radPageViewPage4.Item.Padding = new Padding(5, 10, 5, 10);


            this.radPageViewPage5.Item.ForeColor = Color.FromArgb(180, 180, 180);
            this.radPageViewPage5.Item.DrawFill = false;
            this.radPageViewPage5.Item.DrawBorder = false;
            this.radPageViewPage5.Item.Padding = new Padding(5, 10, 5, 10);



            this.pvpAttribute.Item.DrawFill = true;
            this.pvpAttribute.Item.DrawBorder = true;
            this.pvpAttribute.Item.BackColor = Color.FromArgb(80, 80, 80);
            this.pvpAttribute.Item.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.pvpAttribute.Item.BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.SingleBorder;
            this.pvpAttribute.Item.BorderColor = Color.FromArgb(80, 80, 80);
            this.pvpAttribute.Item.BorderGradientStyle = Telerik.WinControls.GradientStyles.Vista;//solid
            this.pvpAttribute.Item.ForeColor = Color.FromArgb(180, 180, 180);
            this.pvpAttribute.Item.Padding = new Padding(5, 10, 5, 10);


            this.PvpTaxDetails.Item.DrawFill = true;
            this.PvpTaxDetails.Item.DrawBorder = true;
            this.PvpTaxDetails.Item.BackColor = Color.FromArgb(80, 80, 80);
            this.PvpTaxDetails.Item.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.PvpTaxDetails.Item.BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.SingleBorder;
            this.PvpTaxDetails.Item.BorderColor = Color.FromArgb(80, 80, 80);
            this.PvpTaxDetails.Item.BorderGradientStyle = Telerik.WinControls.GradientStyles.Vista;
            this.PvpTaxDetails.Item.ForeColor = Color.FromArgb(180, 180, 180);
            this.PvpTaxDetails.Item.Padding = new Padding(5, 10, 5, 10);

            this.radPageViewPage4.Item.DrawFill = true;
            this.radPageViewPage4.Item.DrawBorder = true;
            this.radPageViewPage4.Item.BackColor = Color.FromArgb(80, 80, 80);
            this.radPageViewPage4.Item.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.radPageViewPage4.Item.BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.SingleBorder;
            this.radPageViewPage4.Item.BorderColor = Color.FromArgb(80, 80, 80);
            this.radPageViewPage4.Item.BorderGradientStyle = Telerik.WinControls.GradientStyles.Vista;
            this.radPageViewPage4.Item.ForeColor = Color.FromArgb(180, 180, 180);
            this.radPageViewPage4.Item.Padding = new Padding(5, 10, 5, 10);

            this.radPageViewPage5.Item.DrawFill = true;
            this.radPageViewPage5.Item.DrawBorder = true;
            this.radPageViewPage5.Item.BackColor = Color.FromArgb(80, 80, 80);
            this.radPageViewPage5.Item.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.radPageViewPage5.Item.BorderBoxStyle = Telerik.WinControls.BorderBoxStyle.SingleBorder;
            this.radPageViewPage5.Item.BorderColor = Color.FromArgb(80, 80, 80);
            this.radPageViewPage5.Item.BorderGradientStyle = Telerik.WinControls.GradientStyles.Vista;
            this.radPageViewPage5.Item.ForeColor = Color.FromArgb(180, 180, 180);
            this.radPageViewPage5.Item.Padding = new Padding(5, 10, 5, 10);
        }
        private void bindMasterProductGroup()
        {
            ProductMasterDS = myProMasterOpr.selectMasterSelectedItems_ProductGroup();
            ddlProductGroup.DataSource = ProductMasterDS.Tables[0];
            ddlProductGroup.DisplayMember = "product_group_name";
            ddlProductGroup.ValueMember = "product_group_Id";
        }
        private void bindMasterProductCompany()
        {
            ProductMasterDS = myProMasterOpr.selectMasterSelectedItems_ProductCompany();
            ddlProductCompany.DataSource = ProductMasterDS.Tables[0];
            ddlProductCompany.DisplayMember = "pro_company_name";
            ddlProductCompany.ValueMember = "pro_companyId";
        }
        private void bindMasterProductCategory()
        {

            ProductMasterDS = myProMasterOpr.selectMasterSelectedItems_Category();
            ddlCategory.DataSource = ProductMasterDS.Tables[0];
            ddlCategory.DisplayMember = "product_category_name";
            ddlCategory.ValueMember = "product_category_id";
        }
        private void bindMasterProductModel()
        {
            ProductMasterDS = myProMasterOpr.selectMasterSelectedItems_Model();
            ddlModel.DataSource = ProductMasterDS.Tables[0];
            ddlModel.DisplayMember = "model_name";
            ddlModel.ValueMember = "model_Id";
        }
        private void bindMasterProductBrand()
        {
            ProductMasterDS = myProMasterOpr.selectMasterSelectedItems_Brand();
            ddlBrand.DataSource = ProductMasterDS.Tables[0];
            ddlBrand.DisplayMember = "brand_name";
            ddlBrand.ValueMember = "brand_Id";
        }
        private void bindMasterUnit()
        {
            ProductMasterDS = myProMasterOpr.selectMasterSelectedItems_Unit();
            ddlUnit.DataSource = ProductMasterDS.Tables[0];
            ddlUnit.DisplayMember = "unit_name";
            ddlUnit.ValueMember = "unit_Id";

        }
        private void bindProductMasterUnits()
        {
          
            ProductMasterDS = myProMasterOpr.selectMasterSelectedItems_ProductUnits();
            ddlUnitofmeasure.DataSource = ProductMasterDS.Tables[0];
            ddlUnitofmeasure.DisplayMember = "unit_name";
            ddlUnitofmeasure.ValueMember = "unit_Id";
            lblUnites.Text = ddlUnitofmeasure.SelectedItem.ToString();

        }
        private void loadComboIndgvProductUnits()
        {
            ProductMasterDS = myProMasterOpr.selectMasterSelectedItems_ProductUnit();
            BindingSource unitbs = new BindingSource();
            unitbs.DataSource = ProductMasterDS.Tables[0];
            ((GridViewComboBoxColumn)dgvProductUnit.Columns["clmUnitNo"]).ValueMember = "unit_Id";
            ((GridViewComboBoxColumn)dgvProductUnit.Columns["clmUnitNo"]).DisplayMember = "unit_name";
            ((GridViewComboBoxColumn)dgvProductUnit.Columns["clmUnitNo"]).DataSource = unitbs;
        }
        private void textAlignment()
        {
            txtMinStock.TextAlign = HorizontalAlignment.Left;
            txtMaxStock.TextAlign = HorizontalAlignment.Left;
        }
        private void gridViewSettings()
        {
            dgvProductUnit.Rows.AddNew();
            dgvProductUnit.Rows.AddNew();
            dgvProductUnit.Rows.AddNew();
            dgvProductUnit.Rows.AddNew();
            dgvProductUnit.Rows.AddNew();
            dgvProductUnit.Rows[0].Cells["clmUnits"].Value = "Unit 1";
            dgvProductUnit.Rows[1].Cells["clmUnits"].Value = "Unit 2";
            dgvProductUnit.Rows[2].Cells["clmUnits"].Value = "Unit 3";
            dgvProductUnit.Rows[3].Cells["clmUnits"].Value = "Unit 4";
            dgvProductUnit.Rows[4].Cells["clmUnits"].Value = "Unit 5";
            dgvProductUnit.Rows[0].Height = 30;
            dgvProductUnit.Rows[1].Height = 30;
            dgvProductUnit.Rows[2].Height = 30;
            dgvProductUnit.Rows[3].Height = 30;
            dgvProductUnit.Rows[4].Height = 30;
            dgvProductUnit.Rows[0].Cells["clmEqual"].Value = "=";
            dgvProductUnit.Rows[1].Cells["clmEqual"].Value = "=";
            dgvProductUnit.Rows[2].Cells["clmEqual"].Value = "=";
            dgvProductUnit.Rows[3].Cells["clmEqual"].Value = "=";
            dgvProductUnit.Rows[4].Cells["clmEqual"].Value = "=";
            dgvProductUnit.Rows[0].Cells["clmEqual"].ReadOnly = true;
            dgvProductUnit.Rows[1].Cells["clmEqual"].ReadOnly = true;
            dgvProductUnit.Rows[2].Cells["clmEqual"].ReadOnly = true;
            dgvProductUnit.Rows[3].Cells["clmEqual"].ReadOnly = true;
            dgvProductUnit.Rows[4].Cells["clmEqual"].ReadOnly = true;

            dgvProductUnit.Rows[0].Cells["clmUnit"].ReadOnly = true;
            dgvProductUnit.Rows[1].Cells["clmUnit"].ReadOnly = true;
            dgvProductUnit.Rows[2].Cells["clmUnit"].ReadOnly = true;
            dgvProductUnit.Rows[3].Cells["clmUnit"].ReadOnly = true;
            dgvProductUnit.Rows[4].Cells["clmUnit"].ReadOnly = true;

            dgvProductUnit.Rows[0].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[1].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[2].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[3].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[4].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;

        }
        
        private void frmProductMaster_Load(object sender, EventArgs e)
        {
            setProductMasterDetails();
            loadComboIndgvProductUnits();
            gridViewSettings();
            textAlignment();
            bindProductMasterUnits();
            bindMasterUnit();
            bindMasterProductGroup();
            bindMasterProductCompany();
            bindMasterProductCategory();
            bindMasterProductModel();
            bindMasterProductBrand();
            RefreshfTb();
           

            lblGroup.Text = fEAname.txtGroupUpdate.Text;
        
            lblCompany.Text = fEAname.txtCompanyUpdate.Text;
            lblCategory.Text = fEAname.txtCategoryUpdate.Text;
            lblModel.Text = fEAname.txtModelUpdate.Text;
            lblBrand.Text = fEAname.txtBrandUpdate.Text;
         
            stripElement = (RadPageViewStripElement)this.radPageView1.ViewElement;
            itemLayout = (StripViewItemLayout)stripElement.ItemContainer.ItemLayout;
            foreach (RadPageViewStripItem item in itemLayout.Children)
            {
                if (item.IsSelected)
                {
                    item.Font = new Font(item.Font.FontFamily, item.Font.Size, FontStyle.Bold);
                    pvpAttribute.Item.MinSize = new Size(180, 150);
                    this.pvpAttribute.Item.NumberOfColors = 1;
                    this.pvpAttribute.Item.BackColor = System.Drawing.Color.WhiteSmoke;
                    PvpTaxDetails.Item.MinSize = new Size(165, 50);
                    this.PvpTaxDetails.Item.NumberOfColors = 1;
                    this.PvpTaxDetails.Item.BackColor = System.Drawing.Color.WhiteSmoke;
                    radPageViewPage4.Item.MinSize = new Size(165, 50);
                    this.radPageViewPage4.Item.NumberOfColors = 1;
                    this.radPageViewPage4.Item.BackColor = System.Drawing.Color.WhiteSmoke;
                    radPageViewPage5.Item.MinSize = new Size(165, 50);
                    this.radPageViewPage5.Item.NumberOfColors = 1;
                    this.radPageViewPage5.Item.BackColor = System.Drawing.Color.WhiteSmoke;

                  
                }
                item.MouseDown += item_MouseDown;

            }


        }
        
        private void radPageView1_PageIndexChanging(object sender, RadPageViewIndexChangingEventArgs e)
        {
            radPageView1.ViewElement.ShowItemCloseButton = false;

            e.Page.Item.BackColor = Color.Red;
            e.Page.Item.DrawFill = true;
            e.Page.Item.GradientStyle = GradientStyles.Solid;

            radPageView1.SelectedPage.Item.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
            radPageView1.SelectedPage.Item.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
            radPageView1.SelectedPage.Item.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
        }

        private void radPageView1_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
     
            e.Page.Item.DrawFill = true;
            e.Page.Item.GradientStyle = GradientStyles.Solid;

            radPageView1.SelectedPage.Item.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
            radPageView1.SelectedPage.Item.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
            radPageView1.SelectedPage.Item.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);

        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void RefreshfTb()
        {
            txtItemName.Text = "";
            txtItemCode.Text = "";
            txtAlternateName.Text = "";
            txtAdditionalDescription.Text = "";
            txtBarCode.Text = "";
            ddlProductGroup.SelectedIndex = -1;
            ddlProductCompany.SelectedIndex = -1;
            ddlModel.SelectedIndex = -1;
            ddlCategory.SelectedIndex = -1;
            ddlBrand.SelectedIndex = -1;

            txtRateofTaxSale.Text = "";
            txtRateofTaxPurchase.Text = "";
            txtRateofCess.Text = "";
            txtCommodityCode.Text = "";
            txtExiceDuty.Text = "";
            txtGst.Text = "";

            ddlStockType.SelectedIndex = -1;
            txtMinStock.Text = "";
            txtMaxStock.Text = "";
            txtRecoredLevel.Text = "";

            txtDimension.Text = "";
            txtVolume.Text = "";
            txtWeight.Text = "";
            ddlUnit.SelectedIndex = -1;

            txtPurchaseDiscount.Text = "";
            txtSalesDiscount.Text = "";
            txtSpecialDiscount.Text = "";
            txtAgentCommission.Text = "";

        }
       private bool validateAttribute()
        {
            if ((ddlProductGroup.SelectedIndex == -1) & (ddlProductCompany.SelectedIndex == -1) & (ddlCategory.SelectedIndex == -1) & (ddlModel.SelectedIndex == -1) & (ddlBrand.SelectedIndex == -1))
            {
                return true;
            }
            return false;
        }
        private void AttrubuteInsert()
        {
            myProMasterInfo.ProductId = myProduct_id;
            myProMasterInfo.ProductGroupid = ddlProductGroup.SelectedIndex != -1 ? Convert.ToInt64(ddlProductGroup.SelectedValue.ToString()) : 0;
            myProMasterInfo.ProductCompanyId = ddlProductCompany.SelectedIndex != -1 ? Convert.ToInt64(ddlProductCompany.SelectedValue.ToString()) : 0;
            myProMasterInfo.ProductCategoryId = ddlCategory.SelectedIndex != -1 ? Convert.ToInt64(ddlCategory.SelectedValue.ToString()) : 0;
            myProMasterInfo.ModelId = ddlModel.SelectedIndex != -1 ? Convert.ToInt64(ddlModel.SelectedValue.ToString()) : 0;
            myProMasterInfo.BrandId = ddlBrand.SelectedIndex != -1 ? Convert.ToInt64(ddlBrand.SelectedValue.ToString()) : 0;
          


        }
        private bool validateProductDiscount()
        {
            if((txtPurchaseDiscount.Text.Trim()==string.Empty)&(txtSalesDiscount.Text.Trim()==string.Empty)&(txtSpecialDiscount.Text.Trim()==string.Empty)&(txtAgentCommission.Text.Trim()==string.Empty))
            {
                return true;
            }
            return false;
        }
        private bool validateTaxDetails()
        {
            if ((txtRateofTaxSale.Text.Trim() == string.Empty) & (txtRateofTaxPurchase.Text.Trim() == string.Empty) & (txtRateofCess.Text.Trim() == string.Empty) & (txtCommodityCode.Text.Trim() == string.Empty) &(txtExiceDuty.Text.Trim() == string.Empty)&(txtGst.Text.Trim()==null))
            {
                return true;
               
            }
            
            return false;
        }
        private void setFieldsTaxDetails()
        {

            myProMasterInfo.ProductId = myProduct_id;
            myProMasterInfo.RateofTaxSale = txtRateofTaxSale.Text == "" ? 0 : Convert.ToDecimal(txtRateofTaxSale.Text.Trim().ToString());
            myProMasterInfo.RateofTaxPurchase = txtRateofTaxPurchase.Text == "" ? 0 : Convert.ToDecimal(txtRateofTaxPurchase.Text.Trim().ToString());
            myProMasterInfo.RateofCess = txtRateofCess.Text == "" ? 0 : Convert.ToDecimal(txtRateofCess.Text.Trim().ToString());
            if (txtCommodityCode.Text == "")
            {
                myProMasterInfo.CommodityCode = 0;
            }
            else if (txtCommodityCode.Text != "")
            {
                myProMasterInfo.CommodityCode = Convert.ToInt32(txtCommodityCode.Text);
            }

            myProMasterInfo.ExiceDuty = txtExiceDuty.Text == "" ? 0 : Convert.ToDecimal(txtExiceDuty.Text.Trim().ToString());
            if (txtGst.Text == "")
            {
                myProMasterInfo.GST = 0;
            }
            else if (txtGst.Text != "")
            {
                myProMasterInfo.GST = Convert.ToInt32(txtGst.Text);
            }


        }
        private bool ValidateStockDetails()
        {
            if ((ddlStockType.SelectedIndex == -1)&(txtMinStock.Text.Trim()==string.Empty)&(txtMaxStock.Text.Trim()==string.Empty)&(txtRecoredLevel.Text.Trim()==null))
            {
                return true;
            }
            return false;
        }
        private void setStockDetails()
        {

            myProMasterInfo.ProductId = myProduct_id;
            myProMasterInfo.StockType = ddlStockType.SelectedIndex.ToString();
            
            if (txtMinStock.Text =="")
            {
                myProMasterInfo.MinStock = 0;
            }
            else if(txtMinStock.Text != "")
            {
                myProMasterInfo.MinStock = txtMinStock.Text == "" ? 0 : Convert.ToDecimal(txtMinStock.Text.Trim());
            }
           if(txtMaxStock.Text == "")
            {
                myProMasterInfo.MaxStock = 0;
            }
            else if(txtMaxStock.Text != "")
            {
                myProMasterInfo.MaxStock = txtMaxStock.Text == "" ? 0 : Convert.ToDecimal(txtMaxStock.Text.Trim());
            }
           if(txtRecoredLevel.Text=="")
            {
                myProMasterInfo.ReOrderLevel = 0;
                
            }
            else if(txtRecoredLevel.Text!="")
            {
                myProMasterInfo.ReOrderLevel = txtRecoredLevel.Text == "" ? 0 : Convert.ToInt32(txtRecoredLevel.Text.Trim().ToString());

            }

        }
        private bool validateUnitDetails()
        {
            if((txtDimension.Text.Trim()==string.Empty)&(txtVolume.Text.Trim()==string.Empty)&(txtWeight.Text.Trim()==string.Empty)&(ddlUnit.SelectedIndex==-1))
            {
                return true;
            }
            return false;
        }
        private bool validateGridViewsItems()
        {
            for(int i=0;i<dgvProductUnit.Rows.Count;i++)
            {
                if((dgvProductUnit.Rows[0].Cells[1]==null)||(dgvProductUnit.Rows[0].Cells[3]==null)||(dgvProductUnit.Rows[0].Cells[5]==null)||(dgvProductUnit.Rows[0].Cells[6]==null))
                {
                    return true;
                }
               
            }
            return false;
        }

        private void setProductDiscount()
        {
            myProMasterInfo.ProductId = myProduct_id;
            myProMasterInfo.PurchaseDiscount = txtPurchaseDiscount.Text == "" ? 0 : Convert.ToDecimal(txtPurchaseDiscount.Text.Trim().ToString());
            myProMasterInfo.SalesDiscount = txtSalesDiscount.Text == "" ? 0 : Convert.ToDecimal(txtSalesDiscount.Text.Trim().ToString());
            myProMasterInfo.SpecialDiscount=txtSpecialDiscount.Text==""?0:Convert.ToDecimal(txtSpecialDiscount.Text.Trim().ToString());
            myProMasterInfo.AgentCommission = txtAgentCommission.Text == "" ? 0 : Convert.ToDecimal(txtAgentCommission.Text.Trim().ToString());

        }
        private void setUnitDetails()
        {

            myProMasterInfo.ProductId = myProduct_id;
            myProMasterInfo.Dimension =txtDimension.Text==""?0: Convert.ToDecimal(txtDimension.Text.Trim().ToString());
            myProMasterInfo.Volume =txtVolume.Text==""?0: Convert.ToDecimal(txtVolume.Text.Trim().ToString());
            myProMasterInfo.Weight =txtWeight.Text==""?0: Convert.ToDecimal(txtWeight.Text.Trim().ToString());
            myProMasterInfo.Unit = ddlUnit.SelectedIndex != -1 ? Convert.ToInt64(ddlUnit.SelectedIndex.ToString()):0;
          
        }
        private void setProductUnit()
        {
            myProMasterInfo.ProductId = myProduct_id;
            myProMasterInfo.UnitNo = dgvProductUnit.Rows[0].Cells[1].Value.ToString();
            myProMasterInfo.Factor = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[3].Value.ToString());
            myProMasterInfo.DiscQty = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[5].Value.ToString());
            myProMasterInfo.PurchaseRate = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[6].Value.ToString());
            myProMasterInfo.PurchaseDisc = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[7].Value.ToString());
            myProMasterInfo.Mrp = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[8].Value.ToString());
            myProMasterInfo.MrpDisc = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[9].Value.ToString());
            myProMasterInfo.Retail = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[10].Value.ToString());
            myProMasterInfo.RetailDisc = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[11].Value.ToString());
            myProMasterInfo.SpecialRate = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[12].Value.ToString());
            myProMasterInfo.SpecialDisc = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[13].Value.ToString());
            myProMasterInfo.WholeSale = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[14].Value.ToString());
            myProMasterInfo.WholeSaleDisc = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[15].Value.ToString());
            myProMasterInfo.BranchRate = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[16].Value.ToString());
            myProMasterInfo.BranchDisc = Convert.ToDecimal(dgvProductUnit.Rows[0].Cells[17].Value.ToString());



        }
        private void btnSave_Click(object sender, EventArgs e)
        { 
            try
            {
                if (btnSave.Text == "&Save")
                {

                    myProMasterInfo.ProductName = txtItemName.Text.Trim().ToString();
                    myProMasterInfo.ProductCode = txtItemCode.Text.Trim().ToString();
                    myProMasterInfo.Alternate_name = txtAlternateName.Text.Trim().ToString();
                    myProMasterInfo.Additionaldescription = txtAdditionalDescription.Text.Trim().ToString();
                    myProMasterInfo.BarCode = txtBarCode.Text.Trim().ToString();
                    myProduct_id =Convert.ToInt64(myProMasterOpr.insertProductMasters(myProMasterInfo));


                    if (validateAttribute() == false)
                    {
                        AttrubuteInsert();
                        myProMasterOpr.insertProductMastersAttribute(myProMasterInfo);

                    }

                    if (validateTaxDetails() == false)
                    {
                        setFieldsTaxDetails();
                        myProMasterOpr.insertProductMastersTaxDetails(myProMasterInfo);
                    }
                    if (ValidateStockDetails() == false)
                    {
                        setStockDetails();
                        myProMasterOpr.insertProductMasterStockDetails(myProMasterInfo);

                    }
                    if (validateUnitDetails() == false)
                    {
                        setUnitDetails();
                        myProMasterOpr.insertProductMasterUnitDetails(myProMasterInfo);
                    }
                    if (validateProductDiscount()==false)
                    {
                        setProductDiscount();
                        myProMasterOpr.insertProductDiscounts(myProMasterInfo);
                    }
                    setProductUnit();
                    myProMasterOpr.insertProductUnits(myProMasterInfo);

                    MessageBox.Show("Successfully Saved", "True Account Pro",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshfTb();
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message );
            }
           
        }

        private void txtMinStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
          
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtMaxStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void radPageViewPage5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radGroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void pvpAttribute_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDimension_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtRateofTaxSale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtRateofTaxPurchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtRateofCess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtExiceDuty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCommodityCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void ddlUnitofmeasure_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            dgvProductUnit.Rows[0].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[1].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[2].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[3].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[4].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            lblUnites.Text= ddlUnitofmeasure.SelectedItem.ToString(); 

        }
        private void ddlUnitofmeasure_SelectedIndexChanging(object sender, Telerik.WinControls.UI.Data.PositionChangingCancelEventArgs e)
        {
            dgvProductUnit.Rows[0].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[1].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[2].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[3].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[4].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
        }

        private void ddlUnitofmeasure_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvProductUnit.Rows[0].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[1].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[2].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[3].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
            dgvProductUnit.Rows[4].Cells["clmUnit"].Value = ddlUnitofmeasure.Text;
         
        }

        private void dgvProductUnit_CellValidating(object sender, CellValidatingEventArgs e)
        {


        }
        private void dgvProductUnit_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            
        }
        private void dgvProductUnit_CellFormatting(object sender, CellFormattingEventArgs e)
        {

        }
        private void dgvProductUnit_DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            

        }

        private void dgvProductUnit_CellEndEdit(object sender, GridViewCellEventArgs e)
        {
            int rowIndex =Convert.ToInt32((e.RowIndex));
           
                switch (dgvProductUnit.CurrentCell.ColumnInfo.Name.ToString())
                {
              
                    case "clmPruchaseRate":
                        {
                         if (dgvProductUnit.Rows[rowIndex].Cells["clmPruchaseRate"].Value!=null)
                        {
                            dgvProductUnit.Rows[rowIndex].Cells["clmPruchaseRate"].Value = myGenaralFunctions.FormatDecimalPlace(dgvProductUnit.Rows[rowIndex].Cells["clmPruchaseRate"].Value.ToString(), 2);

                        }
                        break;
                        }


                   case "clmPurchaseDisc":
                    {
                        if (dgvProductUnit.Rows[rowIndex].Cells["clmPurchaseDisc"].Value != null)
                        {
                            dgvProductUnit.Rows[rowIndex].Cells["clmPurchaseDisc"].Value = dgvProductUnit.Rows[rowIndex].Cells["clmPurchaseDisc"].Value;


                        }
                        break;

                    }

                case "clmMrp":
                    {
                        if(dgvProductUnit.Rows[rowIndex].Cells["clmMrp"].Value != null)
                        {
                            dgvProductUnit.Rows[rowIndex].Cells["clmMrp"].Value = myGenaralFunctions.FormatDecimalPlace(dgvProductUnit.Rows[rowIndex].Cells["clmMrp"].Value.ToString(), 2);


                        }
                        break;
                          
                        }
                case "clmMrpDisc":
                    {
                        if (dgvProductUnit.Rows[rowIndex].Cells["clmMrpDisc"].Value != null)
                        {
                            dgvProductUnit.Rows[rowIndex].Cells["clmMrpDisc"].Value =dgvProductUnit.Rows[rowIndex].Cells["clmMrpDisc"].Value;


                        }
                        break;

                    }



                case "clmRetail":
                        {
                        if (dgvProductUnit.Rows[rowIndex].Cells["clmRetail"].Value != null)
                        {
                            dgvProductUnit.Rows[rowIndex].Cells["clmRetail"].Value = myGenaralFunctions.FormatDecimalPlace(dgvProductUnit.Rows[rowIndex].Cells["clmRetail"].Value.ToString(),2);
                           
                        }
                        break;

                    }
                case "clmRetailDisc":
                    {
                        if (dgvProductUnit.Rows[rowIndex].Cells["clmRetailDisc"].Value != null)
                        {
                            dgvProductUnit.Rows[rowIndex].Cells["clmRetailDisc"].Value = dgvProductUnit.Rows[rowIndex].Cells["clmRetailDisc"].Value;
                        }
                        break;//
                    }
                case "clmSpecialRate":
                        {
                        if (dgvProductUnit.Rows[rowIndex].Cells["clmSpecialRate"].Value != null)
                        {

                            dgvProductUnit.Rows[rowIndex].Cells["clmSpecialRate"].Value = myGenaralFunctions.FormatDecimalPlace(dgvProductUnit.Rows[rowIndex].Cells["clmSpecialRate"].Value.ToString(), 2);
                        }
                            
                            break;
                        }
                case "clmSpecialRateDisc":
                    {
                        if (dgvProductUnit.Rows[rowIndex].Cells["clmSpecialRateDisc"].Value != null)
                        {

                            dgvProductUnit.Rows[rowIndex].Cells["clmSpecialRateDisc"].Value = dgvProductUnit.Rows[rowIndex].Cells["clmSpecialRateDisc"].Value;
                        }

                        break;
                    }
                    case "clmWholeSale":
                        {
                        if (dgvProductUnit.Rows[rowIndex].Cells["clmWholeSale"].Value != null)
                        {
                            dgvProductUnit.Rows[rowIndex].Cells["clmWholeSale"].Value = myGenaralFunctions.FormatDecimalPlace(dgvProductUnit.Rows[rowIndex].Cells["clmWholeSale"].Value.ToString(), 2);
                           
                        }
                        break;
                    }
                case "clmWholeSaleDisc":

                    {
                        if (dgvProductUnit.Rows[rowIndex].Cells["clmWholeSaleDisc"].Value != null)
                        {
                            dgvProductUnit.Rows[rowIndex].Cells["clmWholeSaleDisc"].Value = myGenaralFunctions.FormatDecimalPlace(dgvProductUnit.Rows[rowIndex].Cells["clmWholeSaleDisc"].Value.ToString(), 2);
                        }
                        break;
                    }

                case "clmBranchRate":
                        {
                        if(dgvProductUnit.Rows[rowIndex].Cells["clmBranchRate"].Value != null)
                        {
                            dgvProductUnit.Rows[rowIndex].Cells["clmBranchRate"].Value = myGenaralFunctions.FormatDecimalPlace(dgvProductUnit.Rows[rowIndex].Cells["clmBranchRate"].Value.ToString(), 2);
                          
                        }
                        break;
                    }
                   case "clmBranchRateDisc":
                    {
                        if (dgvProductUnit.Rows[rowIndex].Cells["clmBranchRateDisc"].Value != null)
                        {
                            dgvProductUnit.Rows[rowIndex].Cells["clmBranchRateDisc"].Value = dgvProductUnit.Rows[rowIndex].Cells["clmBranchRateDisc"].Value;
                        }
                        break;
                    }
                
               

            }
            
          
           
        }

        private void dgvProductUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEditAttrubutesName fAname = new frmEditAttrubutesName();
            fAname.Show();
            fAname.txtGroupA.Text = lblGroup.Text;
            fAname.txtCompany.Text = lblCompany.Text;
            fAname.txtCategory.Text = lblCategory.Text;
            fAname.txtModel.Text = lblModel.Text;
            fAname.txtBrand.Text = lblBrand.Text;
            this.Hide();
       
        }
        private void setProductMasterDetails()
        {
            dgvMasterDetails.Rows.Clear();
            //  myFormType = btnpost.Text;
            //   radlblstate.Text = btnpost.Text;
            // dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectProductMastersDetails("SELECT product_Id as id, product_name as name, product_code as code from tblProductMaster");
           // btnSave.Text = "&Save";
            btnDelete.Enabled = false;
         //   RefreshTb();
        }

      
        private void dgvMasterDetails_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            int rowIndex;
         
            if (dgvMasterDetails.CurrentCell != null)
            {
               
                rowIndex = dgvMasterDetails.CurrentCell.RowIndex;
                myProduct_id = Convert.ToInt64(dgvMasterDetails.Rows[rowIndex].Cells["clmProductId"].Value);
                myProMasterInfo.ProductId = myProduct_id;
                ProductMasterDS = myProMasterOpr.selectAllProductMasterData(myProMasterInfo);
                for (int i = 0; i < ProductMasterDS.Tables[0].Rows.Count; i++)
                {
                                   txtItemName.Text = ProductMasterDS.Tables[0].Rows[i]["product_name"].ToString();
                    txtItemCode.Text = ProductMasterDS.Tables[0].Rows[i]["product_code"].ToString();
                    txtAlternateName.Text = ProductMasterDS.Tables[0].Rows[i]["alternate_name"].ToString();
                    txtAdditionalDescription.Text = ProductMasterDS.Tables[0].Rows[i]["additional_description"].ToString();
                    txtBarCode.Text = ProductMasterDS.Tables[0].Rows[i]["bar_Code"].ToString();
                }
            }




            
           
         
        }
        
        private void selectProductMastersDetails(string query)
        {
            myProMasterInfo.Query = query;
            ProductMasterDS = myProMasterOpr.selectAllProductMasterDetails(myProMasterInfo);
            for (int i = 0; i < ProductMasterDS.Tables[0].Rows.Count; i++)
            {
                dgvMasterDetails.Rows.AddNew();
                dgvMasterDetails.Rows[i].Cells["clmItemCode"].Value = ProductMasterDS.Tables[0].Rows[i]["code"].ToString();
                dgvMasterDetails.Rows[i].Cells["clmItemName"].Value = ProductMasterDS.Tables[0].Rows[i]["name"].ToString();
                dgvMasterDetails.Rows[i].Cells["clmProductId"].Value = ProductMasterDS.Tables[0].Rows[i]["id"].ToString();
            }

        }

    }
}
