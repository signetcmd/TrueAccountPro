namespace TrueAccountPro
{
    partial class frmMasters
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasters));
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgvMasterDetails = new Telerik.WinControls.UI.RadGridView();
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.radButton4 = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnProductCategory = new System.Windows.Forms.Button();
            this.btnSize = new System.Windows.Forms.Button();
            this.btnColour = new System.Windows.Forms.Button();
            this.btnUnitOfWeight = new System.Windows.Forms.Button();
            this.btnBrand = new System.Windows.Forms.Button();
            this.btnModel = new System.Windows.Forms.Button();
            this.btncompany = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.btnArea = new System.Windows.Forms.Button();
            this.btnPartyCategory = new System.Windows.Forms.Button();
            this.btnRoute = new System.Windows.Forms.Button();
            this.btnRep = new System.Windows.Forms.Button();
            this.btnType = new System.Windows.Forms.Button();
            this.btndistrict = new System.Windows.Forms.Button();
            this.btnplace = new System.Windows.Forms.Button();
            this.btnstate = new System.Windows.Forms.Button();
            this.btnpost = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtDescription = new Telerik.WinControls.UI.RadTextBox();
            this.txtName = new Telerik.WinControls.UI.RadTextBox();
            this.lbldescription = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radlblstate = new Telerik.WinControls.UI.RadLabel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterDetails.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbldescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radlblstate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 3;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgvMasterDetails
            // 
            this.dgvMasterDetails.Location = new System.Drawing.Point(264, 131);
            // 
            // 
            // 
            this.dgvMasterDetails.MasterTemplate.AllowAddNewRow = false;
            this.dgvMasterDetails.MasterTemplate.AllowColumnReorder = false;
            this.dgvMasterDetails.MasterTemplate.AllowColumnResize = false;
            this.dgvMasterDetails.MasterTemplate.AllowDeleteRow = false;
            this.dgvMasterDetails.MasterTemplate.AllowDragToGroup = false;
            this.dgvMasterDetails.MasterTemplate.AllowEditRow = false;
            this.dgvMasterDetails.MasterTemplate.AllowRowResize = false;
            this.dgvMasterDetails.MasterTemplate.AllowSearchRow = true;
            gridViewTextBoxColumn5.HeaderText = "Group Name";
            gridViewTextBoxColumn5.HeaderTextAlignment = System.Drawing.ContentAlignment.TopCenter;
            gridViewTextBoxColumn5.MaxLength = 32770;
            gridViewTextBoxColumn5.Name = "clmName";
            gridViewTextBoxColumn5.Width = 195;
            gridViewTextBoxColumn6.HeaderText = "Description";
            gridViewTextBoxColumn6.HeaderTextAlignment = System.Drawing.ContentAlignment.TopCenter;
            gridViewTextBoxColumn6.Name = "clmDescription";
            gridViewTextBoxColumn6.Width = 245;
            gridViewTextBoxColumn7.HeaderText = "MasterId";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "clmmasterId";
            gridViewTextBoxColumn8.HeaderText = "Fixed";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "clmfixedMaster";
            this.dgvMasterDetails.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.dgvMasterDetails.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.dgvMasterDetails.Name = "dgvMasterDetails";
            this.dgvMasterDetails.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.dgvMasterDetails.ShowGroupPanel = false;
            this.dgvMasterDetails.Size = new System.Drawing.Size(470, 279);
            this.dgvMasterDetails.TabIndex = 16;
            this.dgvMasterDetails.Text = "0";
            this.dgvMasterDetails.ThemeName = "Office2010Blue";
            this.dgvMasterDetails.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.dgvMasterDetails_CellDoubleClick);
            this.dgvMasterDetails.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvMasterDetails_MouseDoubleClick);
            // 
            // radTitleBar1
            // 
            this.radTitleBar1.BackColor = System.Drawing.Color.Gray;
            this.radTitleBar1.Location = new System.Drawing.Point(665, -1);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.Size = new System.Drawing.Size(78, 29);
            this.radTitleBar1.TabIndex = 13;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "frmMasters";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.radButton4);
            this.radGroupBox3.Controls.Add(this.btnSave);
            this.radGroupBox3.Controls.Add(this.btnDelete);
            this.radGroupBox3.Controls.Add(this.radButton1);
            this.radGroupBox3.HeaderText = "";
            this.radGroupBox3.Location = new System.Drawing.Point(264, 413);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(470, 66);
            this.radGroupBox3.TabIndex = 12;
            // 
            // radButton4
            // 
            this.radButton4.Image = ((System.Drawing.Image)(resources.GetObject("radButton4.Image")));
            this.radButton4.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton4.Location = new System.Drawing.Point(16, 14);
            this.radButton4.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.radButton4.Name = "radButton4";
            this.radButton4.Size = new System.Drawing.Size(98, 36);
            this.radButton4.TabIndex = 12;
            this.radButton4.Text = "&New";
            this.radButton4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton4.ThemeName = "TelerikMetroTouch";
            this.radButton4.Click += new System.EventHandler(this.radButton4_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.Location = new System.Drawing.Point(135, 14);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 36);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "&Save";
            this.btnSave.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.ThemeName = "TelerikMetroTouch";
            this.btnSave.Click += new System.EventHandler(this.radbtnsave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDelete.Location = new System.Drawing.Point(251, 14);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 36);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.ThemeName = "TelerikMetroTouch";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // radButton1
            // 
            this.radButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radButton1.BackgroundImage")));
            this.radButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radButton1.Image = ((System.Drawing.Image)(resources.GetObject("radButton1.Image")));
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radButton1.Location = new System.Drawing.Point(363, 14);
            this.radButton1.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(99, 36);
            this.radButton1.TabIndex = 9;
            this.radButton1.Text = "Close";
            this.radButton1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radButton1.ThemeName = "TelerikMetroTouch";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = "   ";
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnProductCategory);
            this.panel1.Controls.Add(this.btnSize);
            this.panel1.Controls.Add(this.btnColour);
            this.panel1.Controls.Add(this.btnUnitOfWeight);
            this.panel1.Controls.Add(this.btnBrand);
            this.panel1.Controls.Add(this.btnModel);
            this.panel1.Controls.Add(this.btncompany);
            this.panel1.Controls.Add(this.btnGroup);
            this.panel1.Controls.Add(this.btnArea);
            this.panel1.Controls.Add(this.btnPartyCategory);
            this.panel1.Controls.Add(this.btnRoute);
            this.panel1.Controls.Add(this.btnRep);
            this.panel1.Controls.Add(this.btnType);
            this.panel1.Controls.Add(this.btndistrict);
            this.panel1.Controls.Add(this.btnplace);
            this.panel1.Controls.Add(this.btnstate);
            this.panel1.Controls.Add(this.btnpost);
            this.panel1.Location = new System.Drawing.Point(16, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 717);
            this.panel1.TabIndex = 15;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnProductCategory
            // 
            this.btnProductCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.btnProductCategory.FlatAppearance.BorderSize = 0;
            this.btnProductCategory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnProductCategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnProductCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductCategory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductCategory.Location = new System.Drawing.Point(9, 469);
            this.btnProductCategory.Name = "btnProductCategory";
            this.btnProductCategory.Size = new System.Drawing.Size(211, 36);
            this.btnProductCategory.TabIndex = 26;
            this.btnProductCategory.Text = "Product Category";
            this.btnProductCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductCategory.UseVisualStyleBackColor = false;
            this.btnProductCategory.Click += new System.EventHandler(this.btnProductCategory_Click);
            // 
            // btnSize
            // 
            this.btnSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.btnSize.FlatAppearance.BorderSize = 0;
            this.btnSize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnSize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSize.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSize.Location = new System.Drawing.Point(8, 637);
            this.btnSize.Name = "btnSize";
            this.btnSize.Size = new System.Drawing.Size(211, 36);
            this.btnSize.TabIndex = 25;
            this.btnSize.Text = "Size";
            this.btnSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSize.UseVisualStyleBackColor = false;
            this.btnSize.Click += new System.EventHandler(this.btnSize_Click);
            // 
            // btnColour
            // 
            this.btnColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(250)))));
            this.btnColour.FlatAppearance.BorderSize = 0;
            this.btnColour.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnColour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnColour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColour.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColour.Location = new System.Drawing.Point(8, 678);
            this.btnColour.Name = "btnColour";
            this.btnColour.Size = new System.Drawing.Size(211, 36);
            this.btnColour.TabIndex = 24;
            this.btnColour.Text = "Colour";
            this.btnColour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnColour.UseVisualStyleBackColor = false;
            this.btnColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // btnUnitOfWeight
            // 
            this.btnUnitOfWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(248)))));
            this.btnUnitOfWeight.FlatAppearance.BorderSize = 0;
            this.btnUnitOfWeight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnUnitOfWeight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnUnitOfWeight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnitOfWeight.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnitOfWeight.Location = new System.Drawing.Point(8, 554);
            this.btnUnitOfWeight.Name = "btnUnitOfWeight";
            this.btnUnitOfWeight.Size = new System.Drawing.Size(211, 36);
            this.btnUnitOfWeight.TabIndex = 23;
            this.btnUnitOfWeight.Text = "Unit";
            this.btnUnitOfWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUnitOfWeight.UseVisualStyleBackColor = false;
            this.btnUnitOfWeight.Click += new System.EventHandler(this.btnUnitOfWeight_Click);
            // 
            // btnBrand
            // 
            this.btnBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(250)))));
            this.btnBrand.FlatAppearance.BorderSize = 0;
            this.btnBrand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnBrand.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrand.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrand.Location = new System.Drawing.Point(8, 595);
            this.btnBrand.Name = "btnBrand";
            this.btnBrand.Size = new System.Drawing.Size(211, 36);
            this.btnBrand.TabIndex = 21;
            this.btnBrand.Text = "Brand";
            this.btnBrand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrand.UseVisualStyleBackColor = false;
            this.btnBrand.Click += new System.EventHandler(this.btnbrand_Click);
            // 
            // btnModel
            // 
            this.btnModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(246)))));
            this.btnModel.FlatAppearance.BorderSize = 0;
            this.btnModel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnModel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModel.Location = new System.Drawing.Point(8, 512);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(211, 36);
            this.btnModel.TabIndex = 20;
            this.btnModel.Text = "Model";
            this.btnModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModel.UseVisualStyleBackColor = false;
            this.btnModel.Click += new System.EventHandler(this.btnmodel_Click);
            // 
            // btncompany
            // 
            this.btncompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.btncompany.FlatAppearance.BorderSize = 0;
            this.btncompany.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btncompany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btncompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncompany.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncompany.Location = new System.Drawing.Point(8, 426);
            this.btncompany.Name = "btncompany";
            this.btncompany.Size = new System.Drawing.Size(211, 36);
            this.btncompany.TabIndex = 18;
            this.btncompany.Text = "Company";
            this.btncompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncompany.UseVisualStyleBackColor = false;
            this.btncompany.Click += new System.EventHandler(this.btncompany_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(242)))));
            this.btnGroup.FlatAppearance.BorderSize = 0;
            this.btnGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroup.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroup.Location = new System.Drawing.Point(8, 384);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(211, 36);
            this.btnGroup.TabIndex = 17;
            this.btnGroup.Text = "Product Group";
            this.btnGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGroup.UseVisualStyleBackColor = false;
            this.btnGroup.Click += new System.EventHandler(this.btngroup_Click);
            // 
            // btnArea
            // 
            this.btnArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.btnArea.FlatAppearance.BorderSize = 0;
            this.btnArea.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnArea.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArea.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArea.Location = new System.Drawing.Point(8, 90);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(211, 36);
            this.btnArea.TabIndex = 16;
            this.btnArea.Text = "Area";
            this.btnArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArea.UseVisualStyleBackColor = false;
            this.btnArea.Click += new System.EventHandler(this.btnArea_Click);
            // 
            // btnPartyCategory
            // 
            this.btnPartyCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(238)))));
            this.btnPartyCategory.FlatAppearance.BorderSize = 0;
            this.btnPartyCategory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnPartyCategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnPartyCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPartyCategory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartyCategory.Location = new System.Drawing.Point(8, 300);
            this.btnPartyCategory.Name = "btnPartyCategory";
            this.btnPartyCategory.Size = new System.Drawing.Size(211, 36);
            this.btnPartyCategory.TabIndex = 11;
            this.btnPartyCategory.Text = "Party Category";
            this.btnPartyCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPartyCategory.UseVisualStyleBackColor = false;
            this.btnPartyCategory.Click += new System.EventHandler(this.btnPartyCategory_Click);
            // 
            // btnRoute
            // 
            this.btnRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(234)))));
            this.btnRoute.FlatAppearance.BorderSize = 0;
            this.btnRoute.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnRoute.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoute.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoute.Location = new System.Drawing.Point(8, 216);
            this.btnRoute.Name = "btnRoute";
            this.btnRoute.Size = new System.Drawing.Size(211, 36);
            this.btnRoute.TabIndex = 10;
            this.btnRoute.Text = "Route";
            this.btnRoute.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRoute.UseVisualStyleBackColor = false;
            this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
            // 
            // btnRep
            // 
            this.btnRep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(236)))));
            this.btnRep.FlatAppearance.BorderSize = 0;
            this.btnRep.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnRep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRep.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRep.Location = new System.Drawing.Point(8, 258);
            this.btnRep.Name = "btnRep";
            this.btnRep.Size = new System.Drawing.Size(211, 36);
            this.btnRep.TabIndex = 9;
            this.btnRep.Text = "Rep.";
            this.btnRep.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRep.UseVisualStyleBackColor = false;
            this.btnRep.Click += new System.EventHandler(this.btnRep_Click);
            // 
            // btnType
            // 
            this.btnType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(240)))));
            this.btnType.FlatAppearance.BorderSize = 0;
            this.btnType.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnType.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnType.Location = new System.Drawing.Point(8, 342);
            this.btnType.Name = "btnType";
            this.btnType.Size = new System.Drawing.Size(211, 36);
            this.btnType.TabIndex = 8;
            this.btnType.Text = "Type";
            this.btnType.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnType.UseVisualStyleBackColor = false;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // btndistrict
            // 
            this.btndistrict.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.btndistrict.FlatAppearance.BorderSize = 0;
            this.btndistrict.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btndistrict.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btndistrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndistrict.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndistrict.Location = new System.Drawing.Point(8, 132);
            this.btndistrict.Name = "btndistrict";
            this.btndistrict.Size = new System.Drawing.Size(211, 36);
            this.btndistrict.TabIndex = 7;
            this.btndistrict.Text = "District";
            this.btndistrict.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndistrict.UseVisualStyleBackColor = false;
            this.btndistrict.Click += new System.EventHandler(this.btndistrict_Click);
            // 
            // btnplace
            // 
            this.btnplace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(226)))));
            this.btnplace.FlatAppearance.BorderSize = 0;
            this.btnplace.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnplace.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnplace.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnplace.Location = new System.Drawing.Point(8, 48);
            this.btnplace.Name = "btnplace";
            this.btnplace.Size = new System.Drawing.Size(211, 36);
            this.btnplace.TabIndex = 6;
            this.btnplace.Text = "Place";
            this.btnplace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnplace.UseVisualStyleBackColor = false;
            this.btnplace.Click += new System.EventHandler(this.btnplace_Click);
            // 
            // btnstate
            // 
            this.btnstate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(232)))));
            this.btnstate.FlatAppearance.BorderSize = 0;
            this.btnstate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnstate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnstate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstate.Location = new System.Drawing.Point(8, 174);
            this.btnstate.Name = "btnstate";
            this.btnstate.Size = new System.Drawing.Size(211, 36);
            this.btnstate.TabIndex = 5;
            this.btnstate.Text = "State";
            this.btnstate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnstate.UseVisualStyleBackColor = false;
            this.btnstate.Click += new System.EventHandler(this.btnstate_Click);
            // 
            // btnpost
            // 
            this.btnpost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnpost.FlatAppearance.BorderSize = 0;
            this.btnpost.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnpost.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.btnpost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpost.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpost.Location = new System.Drawing.Point(8, 6);
            this.btnpost.Name = "btnpost";
            this.btnpost.Size = new System.Drawing.Size(211, 36);
            this.btnpost.TabIndex = 0;
            this.btnpost.Text = "Post";
            this.btnpost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpost.UseVisualStyleBackColor = false;
            this.btnpost.Click += new System.EventHandler(this.btnpost_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(1, 0);
            this.radLabel1.Name = "radLabel1";
            // 
            // 
            // 
            this.radLabel1.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.radLabel1.Size = new System.Drawing.Size(73, 27);
            this.radLabel1.TabIndex = 14;
            this.radLabel1.Text = "Masters";
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = false;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(144, 37);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(295, 25);
            this.txtDescription.TabIndex = 5;
            this.txtDescription.ThemeName = "Office2007Silver";
            // 
            // txtName
            // 
            this.txtName.AutoSize = false;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(144, 10);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(295, 25);
            this.txtName.TabIndex = 2;
            this.txtName.ThemeName = "Office2007Silver";
            // 
            // lbldescription
            // 
            this.lbldescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescription.Location = new System.Drawing.Point(41, 39);
            this.lbldescription.Name = "lbldescription";
            this.lbldescription.Size = new System.Drawing.Size(69, 19);
            this.lbldescription.TabIndex = 1;
            this.lbldescription.Text = "Description";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.txtDescription);
            this.radGroupBox2.Controls.Add(this.txtName);
            this.radGroupBox2.Controls.Add(this.lbldescription);
            this.radGroupBox2.Controls.Add(this.radlblstate);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(263, 54);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(471, 73);
            this.radGroupBox2.TabIndex = 11;
            // 
            // radlblstate
            // 
            this.radlblstate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radlblstate.Location = new System.Drawing.Point(42, 14);
            this.radlblstate.Name = "radlblstate";
            this.radlblstate.Size = new System.Drawing.Size(30, 19);
            this.radlblstate.TabIndex = 0;
            this.radlblstate.Text = "Post";
            // 
            // timer3
            // 
            this.timer3.Interval = 2;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // frmMasters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(743, 498);
            this.Controls.Add(this.dgvMasterDetails);
            this.Controls.Add(this.radTitleBar1);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radGroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(5000, 800);
            this.Name = "frmMasters";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(5000, 800);
            this.Text = "frmMasters";
            this.Load += new System.EventHandler(this.frmMasters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterDetails.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTitleBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbldescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radlblstate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private Telerik.WinControls.UI.RadGridView dgvMasterDetails;
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadButton radButton4;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnDelete;
        private Telerik.WinControls.UI.RadButton radButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPartyCategory;
        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.Button btnRep;
        private System.Windows.Forms.Button btnType;
        private System.Windows.Forms.Button btndistrict;
        private System.Windows.Forms.Button btnplace;
        private System.Windows.Forms.Button btnstate;
        private System.Windows.Forms.Button btnpost;
              private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadTextBox txtDescription;
        private Telerik.WinControls.UI.RadTextBox txtName;
        private Telerik.WinControls.UI.RadLabel lbldescription;
        private Telerik.WinControls.UI.RadLabel radlblstate;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
              private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button btnArea;
        private System.Windows.Forms.Button btnBrand;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.Button btncompany;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Button btnUnitOfWeight;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSize;
        private System.Windows.Forms.Button btnColour;
        private System.Windows.Forms.Button btnProductCategory;
    }
}
