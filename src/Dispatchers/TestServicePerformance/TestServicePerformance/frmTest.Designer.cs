﻿namespace TestServicePerformance
{
    partial class frmTest
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numericCallsNumber = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.numericThread = new System.Windows.Forms.NumericUpDown();
            this.txtSvc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtXmlRequest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtTestResult = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.measuresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_InitConfigFile = new System.Windows.Forms.Button();
            this.btnPing = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObjectUri = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalculatedValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.measureNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStartSimpleTest = new System.Windows.Forms.Button();
            this.txtSimpleResult = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCallsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericThread)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measuresBindingSource)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(921, 462);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.numericCallsNumber);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.numericThread);
            this.tabPage2.Controls.Add(this.txtSvc);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtXmlRequest);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnStartTest);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(913, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Service";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numericCallsNumber
            // 
            this.numericCallsNumber.Location = new System.Drawing.Point(326, 4);
            this.numericCallsNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericCallsNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCallsNumber.Name = "numericCallsNumber";
            this.numericCallsNumber.Size = new System.Drawing.Size(46, 20);
            this.numericCallsNumber.TabIndex = 15;
            this.numericCallsNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCallsNumber.ValueChanged += new System.EventHandler(this.numericCallsNumber_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(213, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Service calls number";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(243, 104);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(664, 10);
            this.progressBar1.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::TestServicePerformance.Properties.Resources.srch_16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(471, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Find dll";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // numericThread
            // 
            this.numericThread.Location = new System.Drawing.Point(117, 6);
            this.numericThread.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericThread.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericThread.Name = "numericThread";
            this.numericThread.Size = new System.Drawing.Size(46, 20);
            this.numericThread.TabIndex = 11;
            this.numericThread.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericThread.ValueChanged += new System.EventHandler(this.numericThread_ValueChanged);
            // 
            // txtSvc
            // 
            this.txtSvc.Location = new System.Drawing.Point(117, 32);
            this.txtSvc.Name = "txtSvc";
            this.txtSvc.Size = new System.Drawing.Size(337, 20);
            this.txtSvc.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Service name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Request xml";
            // 
            // txtXmlRequest
            // 
            this.txtXmlRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXmlRequest.Location = new System.Drawing.Point(6, 129);
            this.txtXmlRequest.Multiline = true;
            this.txtXmlRequest.Name = "txtXmlRequest";
            this.txtXmlRequest.Size = new System.Drawing.Size(901, 301);
            this.txtXmlRequest.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Threads";
            // 
            // btnStartTest
            // 
            this.btnStartTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartTest.Image = global::TestServicePerformance.Properties.Resources.bt_play;
            this.btnStartTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartTest.Location = new System.Drawing.Point(132, 94);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(105, 23);
            this.btnStartTest.TabIndex = 0;
            this.btnStartTest.Text = "Start test";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtTestResult);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(913, 436);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Test result";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtTestResult
            // 
            this.txtTestResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTestResult.Location = new System.Drawing.Point(6, 25);
            this.txtTestResult.Multiline = true;
            this.txtTestResult.Name = "txtTestResult";
            this.txtTestResult.Size = new System.Drawing.Size(889, 409);
            this.txtTestResult.TabIndex = 8;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(3, 146);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(937, 532);
            this.tabControl2.TabIndex = 13;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dataGridView1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(929, 506);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Metadata";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(923, 500);
            this.dataGridView1.TabIndex = 11;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tabControl1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(929, 506);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Multiple";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(back.Common.BE.Measures);
            // 
            // measuresBindingSource
            // 
            this.measuresBindingSource.DataSource = typeof(back.Common.BE.Measures);
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage1);
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(956, 723);
            this.tabControl3.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_InitConfigFile);
            this.tabPage1.Controls.Add(this.btnPing);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(948, 697);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_InitConfigFile
            // 
            this.btn_InitConfigFile.BackColor = System.Drawing.Color.White;
            this.btn_InitConfigFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_InitConfigFile.Image = global::TestServicePerformance.Properties.Resources.Ball__Red_;
            this.btn_InitConfigFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_InitConfigFile.Location = new System.Drawing.Point(7, 16);
            this.btn_InitConfigFile.Name = "btn_InitConfigFile";
            this.btn_InitConfigFile.Size = new System.Drawing.Size(120, 23);
            this.btn_InitConfigFile.TabIndex = 14;
            this.btn_InitConfigFile.Text = "Config File";
            this.btn_InitConfigFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_InitConfigFile.UseVisualStyleBackColor = false;
            this.btn_InitConfigFile.Click += new System.EventHandler(this.btn_InitConfigFile_Click);
            // 
            // btnPing
            // 
            this.btnPing.BackColor = System.Drawing.Color.White;
            this.btnPing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPing.Image = global::TestServicePerformance.Properties.Resources.Ball__Red_;
            this.btnPing.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPing.Location = new System.Drawing.Point(6, 45);
            this.btnPing.Name = "btnPing";
            this.btnPing.Size = new System.Drawing.Size(115, 23);
            this.btnPing.TabIndex = 9;
            this.btnPing.Text = " Activator";
            this.btnPing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPing.UseVisualStyleBackColor = false;
            this.btnPing.Click += new System.EventHandler(this.btnPing_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtURL);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtObjectUri);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(131, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 119);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection setting";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(252, 34);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(194, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "8085";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(28, 34);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(194, 20);
            this.txtServer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "URL: ";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(28, 83);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(366, 20);
            this.txtURL.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // txtObjectUri
            // 
            this.txtObjectUri.Location = new System.Drawing.Point(485, 34);
            this.txtObjectUri.Name = "txtObjectUri";
            this.txtObjectUri.Size = new System.Drawing.Size(194, 20);
            this.txtObjectUri.TabIndex = 5;
            this.txtObjectUri.Text = "TestDispatcher.rem";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(482, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Object URI";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.btnSaveResult);
            this.tabPage7.Controls.Add(this.dataGridView3);
            this.tabPage7.Controls.Add(this.dataGridView2);
            this.tabPage7.Controls.Add(this.btnStartSimpleTest);
            this.tabPage7.Controls.Add(this.txtSimpleResult);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(948, 697);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveResult.Image = global::TestServicePerformance.Properties.Resources.save_as_16;
            this.btnSaveResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveResult.Location = new System.Drawing.Point(183, 21);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(105, 23);
            this.btnSaveResult.TabIndex = 18;
            this.btnSaveResult.Text = "Save result";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.CalculatedValue});
            this.dataGridView3.DataSource = this.bindingSource1;
            this.dataGridView3.Location = new System.Drawing.Point(6, 50);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(384, 147);
            this.dataGridView3.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MeasureName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Object";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn2.HeaderText = "Bytes";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 126;
            // 
            // CalculatedValue
            // 
            this.CalculatedValue.DataPropertyName = "CalculatedValue";
            this.CalculatedValue.HeaderText = "Mbytes";
            this.CalculatedValue.Name = "CalculatedValue";
            this.CalculatedValue.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.measureNameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn3});
            this.dataGridView2.DataSource = this.measuresBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(6, 214);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(384, 459);
            this.dataGridView2.TabIndex = 16;
            // 
            // measureNameDataGridViewTextBoxColumn
            // 
            this.measureNameDataGridViewTextBoxColumn.DataPropertyName = "MeasureName";
            this.measureNameDataGridViewTextBoxColumn.HeaderText = "MeasureName";
            this.measureNameDataGridViewTextBoxColumn.Name = "measureNameDataGridViewTextBoxColumn";
            this.measureNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            this.valueDataGridViewTextBoxColumn.Width = 126;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CalculatedValue";
            this.dataGridViewTextBoxColumn3.HeaderText = "Sec";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // btnStartSimpleTest
            // 
            this.btnStartSimpleTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartSimpleTest.Image = global::TestServicePerformance.Properties.Resources.bt_play;
            this.btnStartSimpleTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartSimpleTest.Location = new System.Drawing.Point(11, 21);
            this.btnStartSimpleTest.Name = "btnStartSimpleTest";
            this.btnStartSimpleTest.Size = new System.Drawing.Size(105, 23);
            this.btnStartSimpleTest.TabIndex = 15;
            this.btnStartSimpleTest.Text = "Start test";
            this.btnStartSimpleTest.UseVisualStyleBackColor = true;
            this.btnStartSimpleTest.Click += new System.EventHandler(this.btnStartSimpleTest_Click_1);
            // 
            // txtSimpleResult
            // 
            this.txtSimpleResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSimpleResult.Location = new System.Drawing.Point(413, 21);
            this.txtSimpleResult.Multiline = true;
            this.txtSimpleResult.Name = "txtSimpleResult";
            this.txtSimpleResult.Size = new System.Drawing.Size(519, 652);
            this.txtSimpleResult.TabIndex = 14;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 723);
            this.Controls.Add(this.tabControl3);
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test disp service";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTest_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCallsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericThread)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measuresBindingSource)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSvc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtXmlRequest;
        private System.Windows.Forms.NumericUpDown numericThread;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtTestResult;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NumericUpDown numericCallsNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource measuresBindingSource;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnPing;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObjectUri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalculatedValue;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn measureNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnStartSimpleTest;
        private System.Windows.Forms.TextBox txtSimpleResult;
        private System.Windows.Forms.Button btn_InitConfigFile;
    }
}

