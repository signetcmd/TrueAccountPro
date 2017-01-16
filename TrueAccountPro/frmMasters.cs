using BEL;
using BLL;
using DAL;
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
    public partial class frmMasters : Telerik.WinControls.UI.RadForm
    {
        mastersOpr myMasterOpr = new mastersOpr();
        mastersInfo myMastersInfo = new mastersInfo();

        private long mypostId;
        private int MyID;
        private int State_Id;
        private long mynewId;
        bool myMasterDetailsIsFixedbool;
        public bool status = false;
        string myFormType;
        int maxNumberOfBlinksCount = 10;
        int totalBlinkCount = 0;

        DataSet myMasterDetailsDts;
        public frmMasters(string formType)
        {
            InitializeComponent();
            myFormType = formType;
        }
   
        private void radbtnsave_Click(object sender, EventArgs e)
        {

            try
            {
                if (btnSave.Text == "&Edit")
                {
                    txtName.ReadOnly = false;
                    txtDescription.ReadOnly = false;
                    btnSave.Text = "&Update";
                    txtName.Focus();
                }
                else
                {
                    DbTask.FinalizeCommitTransaction();
                    if (btnSave.Text == "&Save")
                    {
                        if (txtName.Text == "")
                        {
                            MessageBox.Show("Please Fill All Details");
                            return;
                        }
                        else
                        {
                            try
                            {

                                if (myFormType == "Post")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblPost](post_name, post_description) values ('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnpost_Click(sender, e);

                                }
                                else if (myFormType == "State")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblState] (state_name,state_description) values ('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnstate_Click(sender, e);

                                }
                                else if (myFormType == "Place")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblPlace](place_name,place_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnplace_Click(sender, e);
                                }
                                else if (myFormType == "District")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblDist](dist_name,dist_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btndistrict_Click(sender, e);
                                }
                                else if (myFormType == "Type")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblType] (type_name,type_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnplace_Click(sender, e);
                                }
                                else if (myFormType == "Rep.")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblRep] (rep_name,rep_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnRep_Click(sender, e);
                                }
                                else if (myFormType == "Route")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblRoute](route_name,route_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnRoute_Click(sender, e);
                                }
                                else if (myFormType == "Party Category")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblPartyCategory](party_category_name,party_category_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnPartyCategory_Click(sender, e);
                                }
                                else if (myFormType == "Area")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblArea](area_name,area_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnArea_Click(sender, e);
                                }
                                else if (myFormType == "Product Group")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblProductGroup](product_group_name,product_group_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btngroup_Click(sender, e);
                                }
                                else if (myFormType == "Company")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblProductCompany](pro_company_name,pro_company_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btncompany_Click(sender, e);
                                }
                                else if (myFormType == "Model")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblModel](model_name,model_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnmodel_Click(sender, e);
                                }
                                else if (myFormType == "Unit")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblUnit](unit_name,unit_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnUnitOfWeight_Click(sender, e);
                                }
                                else if (myFormType == "Brand")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblBrand](brand_name,brand_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnbrand_Click(sender, e);
                                }
                                else if (myFormType == "Size")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblSize](size_name,size_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnSize_Click(sender, e);
                                }
                                else if (myFormType == "Colour")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblColour](colour_name,colour_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnColour_Click(sender, e);
                                }
                                else if(myFormType== "Product Category")
                                {
                                    myMastersInfo.Query = "insert into [dbo].[tblProductCategory](product_category_name,product_category_description) values('" + txtName.Text + "','" + txtDescription.Text + "')";
                                    myMasterOpr.insertMastersDetails(myMastersInfo);
                                    DbTask.FinalizeCommitTransaction();
                                    btnProductCategory_Click(sender, e);
                                }
                              

                                MessageBox.Show("Successfully Saved", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshTb();

                            }
                            catch (Exception ex)
                            {
                                DbTask.FinalizeRollBackActivity();
                                throw new Exception(ex.Message);
                            }
                        }
                    }

                    else if (btnSave.Text == "&Update")
                    {
                        try
                        {


                            if (myFormType == "Post")
                            {

                                myMastersInfo.queryUpdateStr = "update tblPost set post_name='" + txtName.Text + "',post_description='" + txtDescription.Text + "' where post_id= '" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Post Is Updated","True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnpost_Click(sender, e);


                            }
                            else if (myFormType == "State")
                            {
                                myMastersInfo.queryUpdateStr = "update tblState set state_name='" + txtName.Text + "',state_description='" + txtDescription.Text + "' where state_Id= '" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("State Is Updated","True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnstate_Click(sender, e);
                            }
                            else if (myFormType == "Place")
                            {
                                myMastersInfo.queryUpdateStr = "update tblPlace set place_name='" + txtName.Text + "',place_description='" + txtDescription.Text + "' where place_Id= '" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Place Is Updated","True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnplace_Click(sender, e);
                            }
                            else if (myFormType == "District")
                            {
                                myMastersInfo.queryUpdateStr = "update tblDist set dist_name='" + txtName.Text + "',dist_description='" + txtDescription.Text + "' where dist_id= '" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("District Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btndistrict_Click(sender, e);
                            }
                            else if (myFormType == "Type")
                            {
                                myMastersInfo.queryUpdateStr = "update tblType set type_name='" + txtName.Text + "',type_description='" + txtDescription.Text + "' where type_id= '" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Type Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnType_Click(sender, e);

                            }
                            else if (myFormType == "Rep.")
                            {
                                myMastersInfo.queryUpdateStr = "update tblRep set rep_name='" + txtName.Text + "',rep_description='" + txtDescription.Text + "' where rep_Id= '" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Rep Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnRep_Click(sender, e);
                            }
                            else if (myFormType == "Route")
                            {
                                myMastersInfo.queryUpdateStr = "update tblRoute set route_name='" + txtName.Text + "',route_description='" + txtDescription.Text + "' where route_Id= '" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Route Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnRoute_Click(sender, e);
                            }
                            else if (myFormType == "Party Category")
                            {
                                myMastersInfo.queryUpdateStr = "update tblPartyCategory set party_category_name='" + txtName.Text + "',party_category_description='" + txtDescription.Text + "' where party_category_Id= '" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Party Category Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnPartyCategory_Click(sender, e);
                            }
                            else if (myFormType == "Area")
                            {
                                myMastersInfo.queryUpdateStr = "update tblArea set area_name='" + txtName.Text + "',area_description='" + txtDescription.Text + "' where area_id= '" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Area Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnArea_Click(sender, e);
                            }
                            else if (myFormType == "Product Group")
                            {
                                myMastersInfo.queryUpdateStr = "update tblProductGroup set product_group_name='" + txtName.Text + "',product_group_description='" + txtDescription.Text + "' where product_group_Id= '" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Product Group Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btngroup_Click(sender, e);
                            }
                            else if (myFormType == "Company")
                            {
                                myMastersInfo.queryUpdateStr = "update tblProductCompany set pro_company_name='" + txtName.Text + "',pro_company_description='" + txtDescription.Text + "' where pro_companyId= '" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Company Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btncompany_Click(sender, e);
                            }
                            else if (myFormType == "Model")
                            {
                                myMastersInfo.queryUpdateStr = "update tblModel set model_name='" + txtName.Text + "',model_description='" + txtDescription.Text + "' where model_Id= '" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Model Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnmodel_Click(sender, e);
                            }
                            else if (myFormType == "Unit")
                            {
                                myMastersInfo.queryUpdateStr = "update tblUnit set unit_name='" + txtName.Text + "',unit_description='" + txtDescription.Text + "' where unit_Id='" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Unit Of Weight Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnUnitOfWeight_Click(sender, e);
                            }
                            else if (myFormType == "Brand")
                            {
                                myMastersInfo.queryUpdateStr = "update tblBrand set brand_name='" + txtName.Text + "',brand_description='" + txtDescription.Text + "' where brand_Id='" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Brand Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnbrand_Click(sender, e);
                            }
                        
                            else if (myFormType == "Size")
                            {
                                myMastersInfo.queryUpdateStr = "update tblSize set size_name='" + txtName.Text + "',size_description='" + txtDescription.Text + "' where size_id='" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Size Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnSize_Click(sender, e);
                            }
                            else if (myFormType == "Colour")
                            {
                                myMastersInfo.queryUpdateStr = "update tblColour set colour_name='" + txtName.Text + "',colour_description='" + txtDescription.Text + "' where colour_id='" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Colour Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnColour_Click(sender, e);
                            }
                            else if (myFormType == "Product Category")
                            {
                                myMastersInfo.queryUpdateStr = "update tblProductCategory set product_category_name='" + txtName.Text + "',product_category_description='" + txtDescription.Text + "' where product_category_id='" + MyID + "'";
                                myMasterOpr.updateMasterDetails(myMastersInfo);
                                DbTask.FinalizeCommitTransaction();
                                MessageBox.Show("Product Category Is Updated", "True Account Pro",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnProductCategory_Click(sender, e);
                            }
                            RefreshTb();
                        }
                        catch (Exception ex)
                        {
                            DbTask.FinalizeRollBackActivity();
                            throw new Exception(ex.Message);
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                DbTask.FinalizeRollBackActivity();
                throw new Exception(ex.Message);
            }
        }
        private void LoadAllDataAta_Time(object sender, EventArgs e)
        {
            btnColour_Click(sender, e);
            btnPartyCategory_Click(sender, e);
            btnpost_Click(sender, e);
            btnstate_Click(sender, e);
            btnplace_Click(sender, e);
            btndistrict_Click(sender, e);
            btnType_Click(sender, e);
            btnRep_Click(sender, e);
            btnRoute_Click(sender, e);
            btnRoute_Click(sender, e);
            btnPartyCategory_Click(sender, e);
        }
        private void RefreshTb()
        {
            txtName.Text = "";
            txtDescription.Text = "";
        }
      
        private void setPostSettings()
        {
            dgvMasterDetails.Rows.Clear();
            myFormType = btnpost.Text;
            radlblstate.Text = btnpost.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT post_id as id, post_name as name, post_description as description from tblPost");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
        private void btnpost_Click(object sender, EventArgs e)
        {
            setPostSettings();

        } 
        private void selectMasterDetails(string query)
        {
            myMastersInfo.Query = query;
            myMasterDetailsDts = myMasterOpr.selectAllMasterDetails(myMastersInfo);
            for (int i = 0; i < myMasterDetailsDts.Tables[0].Rows.Count; i++)
            {
                dgvMasterDetails.Rows.AddNew(); 
                dgvMasterDetails.Rows[i].Cells["clmName"].Value = myMasterDetailsDts.Tables[0].Rows[i]["name"].ToString();
                dgvMasterDetails.Rows[i].Cells["clmDescription"].Value = myMasterDetailsDts.Tables[0].Rows[i]["description"].ToString();
                dgvMasterDetails.Rows[i].Cells["clmmasterId"].Value = myMasterDetailsDts.Tables[0].Rows[i]["id"].ToString();
            }

        }
        
        private void setStateSettings()
        {
            dgvMasterDetails.Rows.Clear();
            myFormType = btnstate.Text;
            radlblstate.Text = myFormType;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT state_Id as id, state_name as name, state_description as description from tblState");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
        private void btnstate_Click(object sender, EventArgs e)
        {
            setStateSettings();
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void setPlaceSettings()
        {

            dgvMasterDetails.Rows.Clear();
            myFormType = btnplace.Text;
            radlblstate.Text = myFormType;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT place_Id as id, place_name as name, place_description as description from tblPlace");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
        private void btnplace_Click(object sender, EventArgs e)
        {
            setPlaceSettings();


        }
        
        private void setDistrictSettings()
        {

            dgvMasterDetails.Rows.Clear();
            myFormType = btndistrict.Text;
            radlblstate.Text = btndistrict.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT  dist_id as id, dist_name as name, dist_description as description from tblDist");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();

        }
        private void btndistrict_Click(object sender, EventArgs e)
        {
            setDistrictSettings();
        }
        
        private void setTypeSetting()
        {
            dgvMasterDetails.Rows.Clear();
            myFormType = btnType.Text;
            radlblstate.Text = btnType.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT type_id as id, type_name as name, type_description as description from tblType");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
        private void btnType_Click(object sender, EventArgs e)
        {
            setTypeSetting();
        }
        
        private void setRepSettings()
        {

            dgvMasterDetails.Rows.Clear();
            myFormType = btnRep.Text;
            radlblstate.Text = btnRep.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT rep_Id as  id, rep_name as name, rep_description as description from tblRep");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
        private void btnRep_Click(object sender, EventArgs e)
        {
            setRepSettings();
        }
        
        private void setRouteSettings()
        {
            dgvMasterDetails.Rows.Clear();
            myFormType = btnRoute.Text;
            radlblstate.Text = btnRoute.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT route_Id as id, route_name as name, route_description as description from tblRoute");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
        private void btnRoute_Click(object sender, EventArgs e)
        {
            setRouteSettings();
        }
       
        private void setPartyCategorySettings()
        {
            dgvMasterDetails.Rows.Clear();
            myFormType = btnPartyCategory.Text;
            radlblstate.Text = btnPartyCategory.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT party_category_Id as id, party_category_name as name, party_category_description as description from tblPartyCategory");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
        private void btnPartyCategory_Click(object sender, EventArgs e)
        {
            setPartyCategorySettings();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void autoScroll()
        {
            panel1.AutoScroll = true;
            panel1.AutoScroll = true;
            panel1.HorizontalScroll.Enabled = true;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;

        }
        private void formSettings()
        {
            if(myFormType=="Post")
            {
                setPostSettings();
            }
            else if(myFormType=="Place")
            {
                setPlaceSettings();
            }
            else if(myFormType=="Area")
            {
               setAreaSettings();
            }
            else if(myFormType=="District")
            {
                setDistrictSettings();
            }
            else if(myFormType=="State")
            {
                setStateSettings();
            }
            else if(myFormType=="Route")
            {
                setRouteSettings();
            }
            else if(myFormType=="Rep.")
            {
                setRepSettings();
            }
            else if(myFormType=="Party Category")
            {
                setPartyCategorySettings();
            }
            else if(myFormType=="Type")
            {
                setTypeSetting();
            }
            else if(myFormType=="Size")
            {
                setSizeSettings();
            }
            else if(myFormType=="Colour")
            {
                setColourSettings();
            }
            else if(myFormType=="Product Category")
            {
                setProductCategorySettings();
            }
         

        }
        private void frmMasters_Load(object sender, EventArgs e)
        {


            formSettings();
            btnDelete.Enabled = false;
            autoScroll();
     
        }
        private void dgvMasterDetails_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int rowIndex;
            if (dgvMasterDetails.CurrentCell != null)
            {
                rowIndex = dgvMasterDetails.CurrentCell.RowIndex;
                txtName.Text = dgvMasterDetails.Rows[rowIndex].Cells["clmName"].Value.ToString();
                txtDescription.Text = dgvMasterDetails.Rows[rowIndex].Cells["clmDescription"].Value.ToString();
                MyID = Convert.ToInt32(dgvMasterDetails.Rows[rowIndex].Cells["clmmasterId"].Value.ToString());
                txtName.ReadOnly = true;
                txtDescription.ReadOnly = true;
                btnSave.Text = "&Edit";
                btnDelete.Enabled = true;
        
            }
        }

        private void dgvMasterDetails_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowIndex;
            if (dgvMasterDetails.CurrentCell != null)
            {
                rowIndex = dgvMasterDetails.CurrentCell.RowIndex;
                txtName.Text = dgvMasterDetails.Rows[rowIndex].Cells["clmName"].Value.ToString();
                txtDescription.Text = dgvMasterDetails.Rows[rowIndex].Cells["clmDescription"].Value.ToString();
                MyID = Convert.ToInt32(dgvMasterDetails.Rows[rowIndex].Cells["clmmasterId"].Value.ToString());
                txtName.ReadOnly = true;
                txtDescription.ReadOnly = true;
                btnSave.Text = "&Edit";
                btnDelete.Enabled = true;
           
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtName.Text=="" && txtDescription.Text=="")
            {
              
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Are You Sure You Want to Delete...?", "True Account Pro", MessageBoxButtons.YesNo))
                {
                    if (myFormType == "Post")
                    {
                        myMastersInfo.Query = "delete from tblPost where post_id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Post has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnpost_Click(sender, e);


                    }
                    else if (myFormType == "State")
                    {
                        myMastersInfo.Query = "delete from tblState where state_Id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("State has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnstate_Click(sender, e);
                    }
                    else if (myFormType == "Place")
                    {
                        myMastersInfo.Query = "delete from tblPlace where place_Id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Place has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnplace_Click(sender, e);
                    }
                    else if (myFormType == "District")
                    {
                        myMastersInfo.Query = "delete from tblDist where dist_id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("District has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btndistrict_Click(sender, e);
                    }
                    else if (myFormType == "Type")
                    {
                        myMastersInfo.Query = "delete from tblType where type_id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Type has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnType_Click(sender, e);
                    }
                    else if (myFormType == "Rep.")
                    {
                        myMastersInfo.Query = "delete from tblRep where rep_Id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Rep has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRep_Click(sender, e);
                    }
                    else if (myFormType == "Route")
                    {
                        myMastersInfo.Query = "delete from tblRoute where route_Id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Route has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRoute_Click(sender, e);
                    }
                    else if (myFormType == "Party Category")
                    {
                        myMastersInfo.Query = "delete from tblPartyCategory where party_category_Id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Party Category has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnPartyCategory_Click(sender, e);
                    }
                    else if (myFormType == "Area")
                    {
                        myMastersInfo.Query = "delete from tblArea where area_id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Area has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnArea_Click(sender, e);
                    }
                    else if (myFormType == "Product Group")
                    {
                        myMastersInfo.Query = "delete from tblProductGroup where product_group_Id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Product Group has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btngroup_Click(sender, e);
                    }
                    else if (myFormType == "Company")
                    {
                        myMastersInfo.Query = "delete from tblProductCompany where pro_companyId='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Company has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btncompany_Click(sender, e);
                    }
                    else if (myFormType == "Model")
                    {
                        myMastersInfo.Query = "delete from tblModel where model_Id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Model has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnmodel_Click(sender, e);
                    }
                    else if (myFormType == "Unit")
                    {
                        myMastersInfo.Query = "delete from tblUnit where unit_Id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Unit Of Weight has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnUnitOfWeight_Click(sender, e);
                    }
                    else if (myFormType == "Brand")
                    {
                        myMastersInfo.Query = "delete from tblBrand where brand_Id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Brand has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnbrand_Click(sender, e);
                    }
                    else if (myFormType == "Size")
                    {
                        myMastersInfo.Query = "delete from tblSize where size_id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Size has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSize_Click(sender, e);
                    }
                    else if(myFormType=="Product Category")
                    {
                        myMastersInfo.Query = "delete from tblProductCategory where product_category_id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Product Category has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnProductCategory_Click(sender, e);
                    }
                    else if(myFormType== "Colour")
                    {
                        myMastersInfo.Query = "delete from tblColour where colour_id='" + MyID + "'";
                        myMasterOpr.deleteMasterDetails(myMastersInfo);
                        MessageBox.Show("Colour has been Successfully deleted.", "True Account Pro",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnColour_Click(sender, e);
                    }
                    

                        RefreshTb(); 

                }
                else
                {
                    txtName.Focus();
                }

            }
            
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            RefreshTb(); 
            btnSave.Text = "&Save";
            txtName.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            var p = sender as Panel;
            var g = e.Graphics;

            g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.White)), p.DisplayRectangle);

            Point[] points = new Point[4];

            points[0] = new Point(0, 0);
            points[1] = new Point(0, p.Height);
            points[2] = new Point(p.Width, p.Height);
            points[3] = new Point(p.Width, 0);
            Brush brush = new SolidBrush(Color.White);

            g.FillPolygon(brush, points);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            status = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            radlblstate.Visible = true;
            lbldescription.Visible = true;
            btnpost.Visible = true;
            btnstate.Visible = true;
            btnplace.Visible = true;
            btndistrict.Visible = true;
            btnRep.Visible = true;
            btnRep.Visible = true;
            btnRoute.Visible = true;
            btnPartyCategory.Visible = true;
            btnType.Visible = true;
            totalBlinkCount++;
           if (totalBlinkCount == maxNumberOfBlinksCount)
            {
                timer1.Stop();
                radlblstate.Visible = false;
                lbldescription.Visible = false;
                btnpost.Visible = false;
                btnstate.Visible = false;
                btnplace.Visible = false;
                btndistrict.Visible = false;
                btnRep.Visible = false;
                btnRep.Visible = false;
                btnRoute.Visible = false;
                btnPartyCategory.Visible = false;
                btnType.Visible = false;
                totalBlinkCount = 0;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        
        }
        private void selectMasterDetails_Area(string query)
        {
            myMastersInfo.queryStr = query;
            myMasterDetailsDts = myMasterOpr.selectAllMasterDetails(myMastersInfo);
            for (int i = 0; i < myMasterDetailsDts.Tables[0].Rows.Count; i++)
            {
                dgvMasterDetails.Rows.AddNew();
                dgvMasterDetails.Rows[i].Cells["clmmasterId"].Value = myMasterDetailsDts.Tables[0].Rows[i]["area_id"].ToString();
                dgvMasterDetails.Rows[i].Cells["clmName"].Value = myMasterDetailsDts.Tables[0].Rows[i]["area_name"].ToString();
                dgvMasterDetails.Rows[i].Cells["clmDescription"].Value = myMasterDetailsDts.Tables[0].Rows[i]["area_description"].ToString();

            }
        }
        private void setAreaSettings()
        {
            dgvMasterDetails.Rows.Clear();
            myFormType = btnArea.Text;
            radlblstate.Text = btnArea.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT area_id as id, area_name as name, area_description as description  from tblArea");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
        private void btnArea_Click(object sender, EventArgs e)
        {
            setAreaSettings();
        }

        private void setModelSettings()
        {
            dgvMasterDetails.Rows.Clear();
            myFormType = btnModel.Text;
            radlblstate.Text = btnModel.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT model_Id as id, model_name as name, model_description as description from tblModel");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
       
        private void btnmodel_Click(object sender, EventArgs e)
        {
            setModelSettings();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void setGroupSettings()
        {
            dgvMasterDetails.Rows.Clear();
            myFormType = btnGroup.Text;
            radlblstate.Text = btnGroup.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT product_group_Id as id , product_group_name as name, product_group_description as description from tblProductGroup");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
       
        private void btngroup_Click(object sender, EventArgs e)
        {
            setGroupSettings();
            
        }
        private void setBrandSettings()
        {
            dgvMasterDetails.Rows.Clear();
            myFormType = btnBrand.Text;
            radlblstate.Text = btnBrand.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT brand_Id as id, brand_name as name, brand_description as description from tblBrand");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
        private void btnbrand_Click(object sender, EventArgs e)
        {
            setBrandSettings();
        }
        
        private void btncompany_Click(object sender, EventArgs e)
        {
            dgvMasterDetails.Rows.Clear();
            myFormType = btncompany.Text;
            radlblstate.Text = btncompany.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT pro_companyId as id, pro_company_name as name, pro_company_description as description from tblProductCompany");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }

        private void setUnitofWeightSettings()
        {

            dgvMasterDetails.Rows.Clear();
            myFormType = btnUnitOfWeight.Text;
            radlblstate.Text = btnUnitOfWeight.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT unit_Id as id, unit_name as name, unit_description as description from tblUnit");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
     
        private void btnUnitOfWeight_Click(object sender, EventArgs e)
        {
            setUnitofWeightSettings();
        }
        private void setSizeSettings()
        {

            dgvMasterDetails.Rows.Clear();
            myFormType = btnSize.Text;
            radlblstate.Text = btnSize.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT size_id as id, size_name as name, size_description as description from tblSize");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
        private void btnSize_Click(object sender, EventArgs e)
        {
            setSizeSettings();
        }
        private void setColourSettings()
        {
            dgvMasterDetails.Rows.Clear();
            myFormType = btnColour.Text;
            radlblstate.Text = btnColour.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;
            selectMasterDetails("SELECT colour_id as id, colour_name as name, colour_description as description from tblColour");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
        private void btnColour_Click(object sender, EventArgs e)
        {
            setColourSettings();
        }
        private void setProductCategorySettings()
        {
            dgvMasterDetails.Rows.Clear();
            myFormType = btnProductCategory.Text;
            radlblstate.Text = btnProductCategory.Text;
            dgvMasterDetails.Columns[0].HeaderText = myFormType;//product_category_id as id, product_category_name as name, product_category_description as description
            selectMasterDetails("SELECT product_category_id as id, product_category_name as name, product_category_description as description from tblProductCategory");
            btnSave.Text = "&Save";
            btnDelete.Enabled = false;
            RefreshTb();
        }
        private void btnProductCategory_Click(object sender, EventArgs e)
        {
            setProductCategorySettings();
        }
       
       
    }
}
