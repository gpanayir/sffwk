namespace Fwk.Configuration.Test
{
    partial class frmConfigurationTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigurationTest));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetProvider = new System.Windows.Forms.Button();
            this.txtProviderName = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.canUndoDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grdGroups = new System.Windows.Forms.DataGridView();
            this.btnGetGroupKeys = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.xmlConfitFile = new System.Windows.Forms.TextBox();
            this.txtConfigFileName = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnLoadConfigFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encryptedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canRedoDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.keyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canUndoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.canRedoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroups)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Value From KEY";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(156, 159);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(213, 20);
            this.textBox1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 85);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(957, 413);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(949, 387);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuracion Remota";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(424, 137);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnGetProvider);
            this.tabPage2.Controls.Add(this.txtProviderName);
            this.tabPage2.Controls.Add(this.txtGroupName);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.grdGroups);
            this.tabPage2.Controls.Add(this.btnGetGroupKeys);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(949, 387);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuracion Local";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Provider name";
            // 
            // btnGetProvider
            // 
            this.btnGetProvider.Location = new System.Drawing.Point(6, 36);
            this.btnGetProvider.Name = "btnGetProvider";
            this.btnGetProvider.Size = new System.Drawing.Size(144, 28);
            this.btnGetProvider.TabIndex = 11;
            this.btnGetProvider.Text = "Get Provider groups";
            this.btnGetProvider.UseVisualStyleBackColor = true;
            this.btnGetProvider.Click += new System.EventHandler(this.btnGetProvider_Click);
            // 
            // txtProviderName
            // 
            this.txtProviderName.Location = new System.Drawing.Point(103, 10);
            this.txtProviderName.Name = "txtProviderName";
            this.txtProviderName.Size = new System.Drawing.Size(160, 20);
            this.txtProviderName.TabIndex = 10;
            this.txtProviderName.Text = "P1";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(536, 62);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(213, 20);
            this.txtGroupName.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.encryptedDataGridViewCheckBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.canUndoDataGridViewCheckBoxColumn1,
            this.canRedoDataGridViewCheckBoxColumn1});
            this.dataGridView1.DataSource = this.keyBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(385, 96);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(471, 252);
            this.dataGridView1.TabIndex = 8;
            // 
            // canUndoDataGridViewCheckBoxColumn1
            // 
            this.canUndoDataGridViewCheckBoxColumn1.HeaderText = "CanUndo";
            this.canUndoDataGridViewCheckBoxColumn1.Name = "canUndoDataGridViewCheckBoxColumn1";
            this.canUndoDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.canUndoDataGridViewCheckBoxColumn1.Visible = false;
            // 
            // grdGroups
            // 
            this.grdGroups.AutoGenerateColumns = false;
            this.grdGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.canUndoDataGridViewCheckBoxColumn,
            this.canRedoDataGridViewCheckBoxColumn});
            this.grdGroups.DataSource = this.groupBindingSource;
            this.grdGroups.Location = new System.Drawing.Point(7, 70);
            this.grdGroups.Name = "grdGroups";
            this.grdGroups.Size = new System.Drawing.Size(334, 278);
            this.grdGroups.TabIndex = 7;
            // 
            // btnGetGroupKeys
            // 
            this.btnGetGroupKeys.Location = new System.Drawing.Point(370, 62);
            this.btnGetGroupKeys.Name = "btnGetGroupKeys";
            this.btnGetGroupKeys.Size = new System.Drawing.Size(144, 28);
            this.btnGetGroupKeys.TabIndex = 6;
            this.btnGetGroupKeys.Text = "Get Group Keys";
            this.btnGetGroupKeys.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(370, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "Get propertie";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(536, 10);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(213, 36);
            this.textBox2.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.xmlConfitFile);
            this.tabPage3.Controls.Add(this.txtConfigFileName);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.btnLoadConfigFile);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(949, 387);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Config File";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // xmlConfitFile
            // 
            this.xmlConfitFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xmlConfitFile.Location = new System.Drawing.Point(7, 72);
            this.xmlConfitFile.Multiline = true;
            this.xmlConfitFile.Name = "xmlConfitFile";
            this.xmlConfitFile.Size = new System.Drawing.Size(656, 280);
            this.xmlConfitFile.TabIndex = 9;
            // 
            // txtConfigFileName
            // 
            this.txtConfigFileName.Location = new System.Drawing.Point(351, 29);
            this.txtConfigFileName.Name = "txtConfigFileName";
            this.txtConfigFileName.Size = new System.Drawing.Size(394, 20);
            this.txtConfigFileName.TabIndex = 8;
            this.txtConfigFileName.Text = "ConfigurationManager_O2.xml";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(198, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 31);
            this.button3.TabIndex = 5;
            this.button3.Text = "Load group from file";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnLoadConfigFile
            // 
            this.btnLoadConfigFile.Location = new System.Drawing.Point(7, 9);
            this.btnLoadConfigFile.Name = "btnLoadConfigFile";
            this.btnLoadConfigFile.Size = new System.Drawing.Size(171, 31);
            this.btnLoadConfigFile.TabIndex = 0;
            this.btnLoadConfigFile.Text = "Load Config File from object";
            this.btnLoadConfigFile.UseVisualStyleBackColor = true;
            this.btnLoadConfigFile.Click += new System.EventHandler(this.btnLoadConfigFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.logoPictureBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 83);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.SlateGray;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(355, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fwk configuration";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.logoPictureBox.Location = new System.Drawing.Point(614, 25);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(69, 50);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // encryptedDataGridViewCheckBoxColumn
            // 
            this.encryptedDataGridViewCheckBoxColumn.DataPropertyName = "Encrypted";
            this.encryptedDataGridViewCheckBoxColumn.HeaderText = "Encrypted";
            this.encryptedDataGridViewCheckBoxColumn.Name = "encryptedDataGridViewCheckBoxColumn";
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // canRedoDataGridViewCheckBoxColumn1
            // 
            this.canRedoDataGridViewCheckBoxColumn1.DataPropertyName = "CanRedo";
            this.canRedoDataGridViewCheckBoxColumn1.HeaderText = "CanRedo";
            this.canRedoDataGridViewCheckBoxColumn1.Name = "canRedoDataGridViewCheckBoxColumn1";
            this.canRedoDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.canRedoDataGridViewCheckBoxColumn1.Visible = false;
            // 
            // keyBindingSource
            // 
            this.keyBindingSource.DataSource = typeof(Fwk.Configuration.Common.Key);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // canUndoDataGridViewCheckBoxColumn
            // 
            this.canUndoDataGridViewCheckBoxColumn.DataPropertyName = "CanUndo";
            this.canUndoDataGridViewCheckBoxColumn.HeaderText = "CanUndo";
            this.canUndoDataGridViewCheckBoxColumn.Name = "canUndoDataGridViewCheckBoxColumn";
            this.canUndoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.canUndoDataGridViewCheckBoxColumn.Visible = false;
            // 
            // canRedoDataGridViewCheckBoxColumn
            // 
            this.canRedoDataGridViewCheckBoxColumn.DataPropertyName = "CanRedo";
            this.canRedoDataGridViewCheckBoxColumn.HeaderText = "CanRedo";
            this.canRedoDataGridViewCheckBoxColumn.Name = "canRedoDataGridViewCheckBoxColumn";
            this.canRedoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.canRedoDataGridViewCheckBoxColumn.Visible = false;
            // 
            // groupBindingSource
            // 
            this.groupBindingSource.DataSource = typeof(Fwk.Configuration.Common.Group);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 35);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(171, 31);
            this.button4.TabIndex = 10;
            this.button4.Text = "Load Config File from object";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmConfigurationTest
            // 
            this.ClientSize = new System.Drawing.Size(958, 510);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmConfigurationTest";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroups)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnLoadConfigFile;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtConfigFileName;
        private System.Windows.Forms.TextBox xmlConfitFile;
        private System.Windows.Forms.DataGridView grdGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canUndoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canRedoDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource groupBindingSource;
        private System.Windows.Forms.Button btnGetGroupKeys;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn encryptedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canUndoDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canRedoDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.BindingSource keyBindingSource;
        private System.Windows.Forms.TextBox txtProviderName;
        private System.Windows.Forms.Button btnGetProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
    }
}

