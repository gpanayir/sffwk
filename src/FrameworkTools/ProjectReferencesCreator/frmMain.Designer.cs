namespace ProjectReferencesCreator
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnFindFolder = new System.Windows.Forms.Button();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.txtRoot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFindRootFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNewVersion_EnterpriseLibrary = new System.Windows.Forms.MaskedTextBox();
            this.txtNewVersion_AllusLibs = new System.Windows.Forms.MaskedTextBox();
            this.txtNewVersion_Fwk = new System.Windows.Forms.MaskedTextBox();
            this.chlEnterpriseLibrary = new System.Windows.Forms.CheckBox();
            this.chkAllusLibs = new System.Windows.Forms.CheckBox();
            this.chkFramework = new System.Windows.Forms.CheckBox();
            this.btnUpdateVersions = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRootVersion = new System.Windows.Forms.TextBox();
            this.btnFindFolderVersion = new System.Windows.Forms.Button();
            this.indexDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.updateRefVersions1 = new ProjectReferencesCreator.UpdateRefVersions();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.referenceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFindFolder
            // 
            this.btnFindFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindFolder.Location = new System.Drawing.Point(1016, 88);
            this.btnFindFolder.Name = "btnFindFolder";
            this.btnFindFolder.Size = new System.Drawing.Size(35, 23);
            this.btnFindFolder.TabIndex = 0;
            this.btnFindFolder.Text = "...";
            this.btnFindFolder.UseVisualStyleBackColor = true;
            this.btnFindFolder.Click += new System.EventHandler(this.btnFindFolder_Click);
            // 
            // txtReference
            // 
            this.txtReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReference.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtReference.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtReference.Location = new System.Drawing.Point(16, 91);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(989, 20);
            this.txtReference.TabIndex = 2;
            this.txtReference.TextChanged += new System.EventHandler(this.txtReference_TextChanged);
            // 
            // txtRoot
            // 
            this.txtRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoot.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRoot.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtRoot.Location = new System.Drawing.Point(16, 30);
            this.txtRoot.Name = "txtRoot";
            this.txtRoot.Size = new System.Drawing.Size(989, 20);
            this.txtRoot.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "References path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Root folder";
            // 
            // btnFindRootFolder
            // 
            this.btnFindRootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindRootFolder.Location = new System.Drawing.Point(1016, 30);
            this.btnFindRootFolder.Name = "btnFindRootFolder";
            this.btnFindRootFolder.Size = new System.Drawing.Size(35, 23);
            this.btnFindRootFolder.TabIndex = 7;
            this.btnFindRootFolder.Text = "...";
            this.btnFindRootFolder.UseVisualStyleBackColor = true;
            this.btnFindRootFolder.Click += new System.EventHandler(this.btnFindRootFolder_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indexDataGridViewTextBoxColumn,
            this.pathDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.referenceBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(16, 159);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.Size = new System.Drawing.Size(989, 543);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1073, 736);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnDown);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.btnUp);
            this.tabPage1.Controls.Add(this.btnRemove);
            this.tabPage1.Controls.Add(this.btnFindFolder);
            this.tabPage1.Controls.Add(this.txtReference);
            this.tabPage1.Controls.Add(this.txtRoot);
            this.tabPage1.Controls.Add(this.btnUpdate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnAddFolder);
            this.tabPage1.Controls.Add(this.btnFindRootFolder);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1065, 710);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add References";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.Image = global::ProjectReferencesCreator.Properties.Resources.arrow_down_16;
            this.btnDown.Location = new System.Drawing.Point(1016, 269);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(35, 23);
            this.btnDown.TabIndex = 12;
            this.btnDown.Text = "...";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Image = global::ProjectReferencesCreator.Properties.Resources.arrow_up_16;
            this.btnUp.Location = new System.Drawing.Point(1016, 182);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(35, 23);
            this.btnUp.TabIndex = 11;
            this.btnUp.Text = "...";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Image = global::ProjectReferencesCreator.Properties.Resources.close_16;
            this.btnRemove.Location = new System.Drawing.Point(1016, 225);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(35, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "...";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.benRemove_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = global::ProjectReferencesCreator.Properties.Resources.play_16;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(243, 123);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(189, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update all projet in root folder";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddFolder.Enabled = false;
            this.btnAddFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFolder.Image = global::ProjectReferencesCreator.Properties.Resources.Folder__Add_;
            this.btnAddFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddFolder.Location = new System.Drawing.Point(125, 123);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(100, 23);
            this.btnAddFolder.TabIndex = 8;
            this.btnAddFolder.Text = "Add folder";
            this.btnAddFolder.UseVisualStyleBackColor = false;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.updateRefVersions1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtRootVersion);
            this.tabPage2.Controls.Add(this.btnFindFolderVersion);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1065, 710);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Versions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtNewVersion_EnterpriseLibrary);
            this.groupBox1.Controls.Add(this.txtNewVersion_AllusLibs);
            this.groupBox1.Controls.Add(this.txtNewVersion_Fwk);
            this.groupBox1.Controls.Add(this.chlEnterpriseLibrary);
            this.groupBox1.Controls.Add(this.chkAllusLibs);
            this.groupBox1.Controls.Add(this.chkFramework);
            this.groupBox1.Controls.Add(this.btnUpdateVersions);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(26, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(986, 135);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // txtNewVersion_EnterpriseLibrary
            // 
            this.txtNewVersion_EnterpriseLibrary.Culture = new System.Globalization.CultureInfo("en-US");
            this.txtNewVersion_EnterpriseLibrary.Enabled = false;
            this.txtNewVersion_EnterpriseLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewVersion_EnterpriseLibrary.ForeColor = System.Drawing.Color.Maroon;
            this.txtNewVersion_EnterpriseLibrary.Location = new System.Drawing.Point(387, 45);
            this.txtNewVersion_EnterpriseLibrary.Name = "txtNewVersion_EnterpriseLibrary";
            this.txtNewVersion_EnterpriseLibrary.ResetOnPrompt = false;
            this.txtNewVersion_EnterpriseLibrary.ResetOnSpace = false;
            this.txtNewVersion_EnterpriseLibrary.Size = new System.Drawing.Size(153, 26);
            this.txtNewVersion_EnterpriseLibrary.TabIndex = 21;
            // 
            // txtNewVersion_AllusLibs
            // 
            this.txtNewVersion_AllusLibs.Culture = new System.Globalization.CultureInfo("en-US");
            this.txtNewVersion_AllusLibs.Enabled = false;
            this.txtNewVersion_AllusLibs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewVersion_AllusLibs.ForeColor = System.Drawing.Color.Maroon;
            this.txtNewVersion_AllusLibs.Location = new System.Drawing.Point(100, 87);
            this.txtNewVersion_AllusLibs.Mask = "9.9.9.9";
            this.txtNewVersion_AllusLibs.Name = "txtNewVersion_AllusLibs";
            this.txtNewVersion_AllusLibs.ResetOnPrompt = false;
            this.txtNewVersion_AllusLibs.ResetOnSpace = false;
            this.txtNewVersion_AllusLibs.Size = new System.Drawing.Size(72, 26);
            this.txtNewVersion_AllusLibs.TabIndex = 20;
            this.txtNewVersion_AllusLibs.Text = "2343";
            // 
            // txtNewVersion_Fwk
            // 
            this.txtNewVersion_Fwk.Culture = new System.Globalization.CultureInfo("en-US");
            this.txtNewVersion_Fwk.Enabled = false;
            this.txtNewVersion_Fwk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewVersion_Fwk.ForeColor = System.Drawing.Color.Maroon;
            this.txtNewVersion_Fwk.Location = new System.Drawing.Point(100, 48);
            this.txtNewVersion_Fwk.Mask = "9.9.9.9";
            this.txtNewVersion_Fwk.Name = "txtNewVersion_Fwk";
            this.txtNewVersion_Fwk.ResetOnPrompt = false;
            this.txtNewVersion_Fwk.ResetOnSpace = false;
            this.txtNewVersion_Fwk.Size = new System.Drawing.Size(72, 26);
            this.txtNewVersion_Fwk.TabIndex = 19;
            this.txtNewVersion_Fwk.Text = "2343";
            // 
            // chlEnterpriseLibrary
            // 
            this.chlEnterpriseLibrary.AutoSize = true;
            this.chlEnterpriseLibrary.ForeColor = System.Drawing.Color.Blue;
            this.chlEnterpriseLibrary.Location = new System.Drawing.Point(274, 52);
            this.chlEnterpriseLibrary.Name = "chlEnterpriseLibrary";
            this.chlEnterpriseLibrary.Size = new System.Drawing.Size(107, 17);
            this.chlEnterpriseLibrary.TabIndex = 18;
            this.chlEnterpriseLibrary.Text = "Enterprise Library";
            this.chlEnterpriseLibrary.UseVisualStyleBackColor = true;
            this.chlEnterpriseLibrary.CheckedChanged += new System.EventHandler(this.chlEnterpriseLibrary_CheckedChanged);
            // 
            // chkAllusLibs
            // 
            this.chkAllusLibs.AutoSize = true;
            this.chkAllusLibs.ForeColor = System.Drawing.Color.Blue;
            this.chkAllusLibs.Location = new System.Drawing.Point(6, 96);
            this.chkAllusLibs.Name = "chkAllusLibs";
            this.chkAllusLibs.Size = new System.Drawing.Size(66, 17);
            this.chkAllusLibs.TabIndex = 16;
            this.chkAllusLibs.Text = "Pelsoft libs";
            this.chkAllusLibs.UseVisualStyleBackColor = true;
            this.chkAllusLibs.CheckedChanged += new System.EventHandler(this.chkAllusLibs_CheckedChanged);
            // 
            // chkFramework
            // 
            this.chkFramework.AutoSize = true;
            this.chkFramework.ForeColor = System.Drawing.Color.Blue;
            this.chkFramework.Location = new System.Drawing.Point(6, 55);
            this.chkFramework.Name = "chkFramework";
            this.chkFramework.Size = new System.Drawing.Size(78, 17);
            this.chkFramework.TabIndex = 14;
            this.chkFramework.Text = "Framework";
            this.chkFramework.UseVisualStyleBackColor = true;
            this.chkFramework.CheckedChanged += new System.EventHandler(this.chkFramework_CheckedChanged);
            // 
            // btnUpdateVersions
            // 
            this.btnUpdateVersions.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdateVersions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateVersions.Image = global::ProjectReferencesCreator.Properties.Resources.play_16;
            this.btnUpdateVersions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateVersions.Location = new System.Drawing.Point(281, 87);
            this.btnUpdateVersions.Name = "btnUpdateVersions";
            this.btnUpdateVersions.Size = new System.Drawing.Size(178, 26);
            this.btnUpdateVersions.TabIndex = 11;
            this.btnUpdateVersions.Text = "Update ";
            this.btnUpdateVersions.UseVisualStyleBackColor = false;
            this.btnUpdateVersions.Click += new System.EventHandler(this.btnUpdateVersions_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Update to this version:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Root folder";
            // 
            // txtRootVersion
            // 
            this.txtRootVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRootVersion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRootVersion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtRootVersion.Location = new System.Drawing.Point(26, 43);
            this.txtRootVersion.Name = "txtRootVersion";
            this.txtRootVersion.Size = new System.Drawing.Size(986, 20);
            this.txtRootVersion.TabIndex = 8;
            this.txtRootVersion.Text = "c:\\TestProjects\\";
            // 
            // btnFindFolderVersion
            // 
            this.btnFindFolderVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindFolderVersion.Location = new System.Drawing.Point(1018, 40);
            this.btnFindFolderVersion.Name = "btnFindFolderVersion";
            this.btnFindFolderVersion.Size = new System.Drawing.Size(35, 23);
            this.btnFindFolderVersion.TabIndex = 10;
            this.btnFindFolderVersion.Text = "...";
            this.btnFindFolderVersion.UseVisualStyleBackColor = true;
            this.btnFindFolderVersion.Click += new System.EventHandler(this.btnFindFolderVersion_Click);
            // 
            // indexDataGridViewTextBoxColumn
            // 
            this.indexDataGridViewTextBoxColumn.DataPropertyName = "Index";
            this.indexDataGridViewTextBoxColumn.HeaderText = "Order";
            this.indexDataGridViewTextBoxColumn.Name = "indexDataGridViewTextBoxColumn";
            this.indexDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.ReadOnly = true;
            this.pathDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pathDataGridViewTextBoxColumn.Width = 500;
            // 
            // referenceBindingSource
            // 
            this.referenceBindingSource.DataSource = typeof(ProjectReferencesCreator.Reference);
            this.referenceBindingSource.Sort = "";
            // 
            // updateRefVersions1
            // 
            this.updateRefVersions1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.updateRefVersions1.Location = new System.Drawing.Point(18, 210);
            this.updateRefVersions1.Name = "updateRefVersions1";
            this.updateRefVersions1.Size = new System.Drawing.Size(1041, 450);
            this.updateRefVersions1.TabIndex = 15;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1073, 736);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Reference creator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.referenceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFindFolder;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.TextBox txtRoot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFindRootFolder;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.BindingSource referenceBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn indexDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRootVersion;
        private System.Windows.Forms.Button btnFindFolderVersion;
        private System.Windows.Forms.Button btnUpdateVersions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private UpdateRefVersions updateRefVersions1;
        private System.Windows.Forms.CheckBox chkFramework;
        private System.Windows.Forms.CheckBox chkAllusLibs;
        private System.Windows.Forms.CheckBox chlEnterpriseLibrary;
        private System.Windows.Forms.MaskedTextBox txtNewVersion_Fwk;
        private System.Windows.Forms.MaskedTextBox txtNewVersion_EnterpriseLibrary;
        private System.Windows.Forms.MaskedTextBox txtNewVersion_AllusLibs;
    }
}

