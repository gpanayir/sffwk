namespace Fwk.Tools.TreeView
{
    partial class UC_MenuItemEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_MenuItemEditor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btn_SelectedImageIndex = new System.Windows.Forms.Button();
            this.btn_ImageIndex = new System.Windows.Forms.Button();
            this.pictureBoxImageSelected = new System.Windows.Forms.PictureBox();
            this.btnSelImageType = new System.Windows.Forms.Button();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBoxTypeImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtToolTipInfo = new System.Windows.Forms.TextBox();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAssembly = new System.Windows.Forms.TextBox();
            this.btnAssemblyinfo = new System.Windows.Forms.Button();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.fwkMessageView_Error = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTypeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtCategory);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.groupControl1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtToolTipInfo);
            this.groupBox1.Controls.Add(this.checkBoxEnabled);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAssembly);
            this.groupBox1.Controls.Add(this.btnAssemblyinfo);
            this.groupBox1.Controls.Add(this.txtDisplayName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(761, 582);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu item info";
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtCategory.Location = new System.Drawing.Point(136, 37);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(4);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(601, 22);
            this.txtCategory.TabIndex = 60;
            this.txtCategory.Validated += new System.EventHandler(this.txtCategory_Validated);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(35, 41);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 17);
            this.lblCategory.TabIndex = 61;
            this.lblCategory.Text = "Category";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btn_SelectedImageIndex);
            this.groupControl1.Controls.Add(this.btn_ImageIndex);
            this.groupControl1.Controls.Add(this.pictureBoxImageSelected);
            this.groupControl1.Controls.Add(this.btnSelImageType);
            this.groupControl1.Controls.Add(this.pictureBoxImage);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.pictureBoxTypeImage);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Location = new System.Drawing.Point(37, 155);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(713, 164);
            this.groupControl1.TabIndex = 59;
            this.groupControl1.Text = "Images";
            // 
            // btn_SelectedImageIndex
            // 
            this.btn_SelectedImageIndex.Location = new System.Drawing.Point(255, 79);
            this.btn_SelectedImageIndex.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SelectedImageIndex.Name = "btn_SelectedImageIndex";
            this.btn_SelectedImageIndex.Size = new System.Drawing.Size(40, 26);
            this.btn_SelectedImageIndex.TabIndex = 67;
            this.btn_SelectedImageIndex.Text = "...";
            this.btn_SelectedImageIndex.UseVisualStyleBackColor = true;
            this.btn_SelectedImageIndex.Click += new System.EventHandler(this.btnSelectedImage_Click);
            // 
            // btn_ImageIndex
            // 
            this.btn_ImageIndex.Location = new System.Drawing.Point(255, 36);
            this.btn_ImageIndex.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ImageIndex.Name = "btn_ImageIndex";
            this.btn_ImageIndex.Size = new System.Drawing.Size(40, 26);
            this.btn_ImageIndex.TabIndex = 66;
            this.btn_ImageIndex.Text = "...";
            this.btn_ImageIndex.UseVisualStyleBackColor = true;
            this.btn_ImageIndex.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // pictureBoxImageSelected
            // 
            this.pictureBoxImageSelected.BackColor = System.Drawing.Color.White;
            this.pictureBoxImageSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxImageSelected.Location = new System.Drawing.Point(188, 81);
            this.pictureBoxImageSelected.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxImageSelected.Name = "pictureBoxImageSelected";
            this.pictureBoxImageSelected.Size = new System.Drawing.Size(42, 25);
            this.pictureBoxImageSelected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImageSelected.TabIndex = 10;
            this.pictureBoxImageSelected.TabStop = false;
            // 
            // btnSelImageType
            // 
            this.btnSelImageType.Location = new System.Drawing.Point(660, 57);
            this.btnSelImageType.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelImageType.Name = "btnSelImageType";
            this.btnSelImageType.Size = new System.Drawing.Size(40, 26);
            this.btnSelImageType.TabIndex = 58;
            this.btnSelImageType.Text = "...";
            this.btnSelImageType.UseVisualStyleBackColor = true;
            this.btnSelImageType.Click += new System.EventHandler(this.btnSelImageType_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.White;
            this.pictureBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxImage.Location = new System.Drawing.Point(188, 36);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(42, 25);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 7;
            this.pictureBoxImage.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(433, 36);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 17);
            this.label7.TabIndex = 57;
            this.label7.Text = "Column Node image";
            // 
            // pictureBoxTypeImage
            // 
            this.pictureBoxTypeImage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBoxTypeImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxTypeImage.Location = new System.Drawing.Point(436, 57);
            this.pictureBoxTypeImage.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxTypeImage.Name = "pictureBoxTypeImage";
            this.pictureBoxTypeImage.Size = new System.Drawing.Size(215, 82);
            this.pictureBoxTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTypeImage.TabIndex = 56;
            this.pictureBoxTypeImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Selected image";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 458);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 55;
            this.label6.Text = "Tool tip";
            // 
            // txtToolTipInfo
            // 
            this.txtToolTipInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToolTipInfo.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtToolTipInfo.Location = new System.Drawing.Point(136, 454);
            this.txtToolTipInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtToolTipInfo.Name = "txtToolTipInfo";
            this.txtToolTipInfo.Size = new System.Drawing.Size(553, 22);
            this.txtToolTipInfo.TabIndex = 54;
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxEnabled.Checked = true;
            this.checkBoxEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnabled.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxEnabled.Location = new System.Drawing.Point(39, 127);
            this.checkBoxEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(82, 21);
            this.checkBoxEnabled.TabIndex = 16;
            this.checkBoxEnabled.Text = "Enabled";
            this.checkBoxEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 358);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Assembly";
            // 
            // txtAssembly
            // 
            this.txtAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssembly.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtAssembly.Location = new System.Drawing.Point(136, 354);
            this.txtAssembly.Margin = new System.Windows.Forms.Padding(4);
            this.txtAssembly.Multiline = true;
            this.txtAssembly.Name = "txtAssembly";
            this.txtAssembly.Size = new System.Drawing.Size(553, 61);
            this.txtAssembly.TabIndex = 14;
            // 
            // btnAssemblyinfo
            // 
            this.btnAssemblyinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssemblyinfo.Location = new System.Drawing.Point(711, 357);
            this.btnAssemblyinfo.Margin = new System.Windows.Forms.Padding(4);
            this.btnAssemblyinfo.Name = "btnAssemblyinfo";
            this.btnAssemblyinfo.Size = new System.Drawing.Size(40, 62);
            this.btnAssemblyinfo.TabIndex = 13;
            this.btnAssemblyinfo.Text = "...";
            this.btnAssemblyinfo.UseVisualStyleBackColor = true;
            this.btnAssemblyinfo.Click += new System.EventHandler(this.btnAssemblyinfo_Click);
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDisplayName.ForeColor = System.Drawing.Color.SteelBlue;
            this.txtDisplayName.Location = new System.Drawing.Point(136, 86);
            this.txtDisplayName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(601, 22);
            this.txtDisplayName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Display text";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // fwkMessageView_Error
            // 
            this.fwkMessageView_Error.BackColor = System.Drawing.SystemColors.Control;
            this.fwkMessageView_Error.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageView_Error.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageView_Error.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error;
            this.fwkMessageView_Error.TextMessageColor = System.Drawing.Color.White;
            this.fwkMessageView_Error.TextMessageForeColor = System.Drawing.Color.Maroon;
            this.fwkMessageView_Error.Title = "Message";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // UC_MenuItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_MenuItemEditor";
            this.Size = new System.Drawing.Size(769, 590);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTypeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtToolTipInfo;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAssembly;
        private System.Windows.Forms.Button btnAssemblyinfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxImageSelected;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button btnSelImageType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBoxTypeImage;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageView_Error;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_ImageIndex;
        private System.Windows.Forms.Button btn_SelectedImageIndex;
    }
}
