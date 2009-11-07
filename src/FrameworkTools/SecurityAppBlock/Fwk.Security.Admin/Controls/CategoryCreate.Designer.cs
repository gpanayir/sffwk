namespace Fwk.Security.Admin.Controls
{
    partial class CategoryCreate
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
            this.btnCreateNewRol = new System.Windows.Forms.Button();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.rulesInCategory1 = new Fwk.Security.Admin.Controls.RulesInCategory();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateNewRol
            // 
            this.btnCreateNewRol.BackColor = System.Drawing.Color.White;
            this.btnCreateNewRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateNewRol.Image = global::Fwk.Security.Admin.Properties.Resources.save_16;
            this.btnCreateNewRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewRol.Location = new System.Drawing.Point(3, 3);
            this.btnCreateNewRol.Name = "btnCreateNewRol";
            this.btnCreateNewRol.Size = new System.Drawing.Size(64, 26);
            this.btnCreateNewRol.TabIndex = 20;
            this.btnCreateNewRol.Text = "Save ";
            this.btnCreateNewRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNewRol.UseVisualStyleBackColor = false;
            this.btnCreateNewRol.Click += new System.EventHandler(this.btnCreateNewRol_Click);
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", false, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", true, 2)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // rulesInCategory1
            // 
            this.rulesInCategory1.Location = new System.Drawing.Point(3, 69);
            this.rulesInCategory1.Name = "rulesInCategory1";
            this.rulesInCategory1.Size = new System.Drawing.Size(897, 475);
            this.rulesInCategory1.TabIndex = 21;
            // 
            // CategoryCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rulesInCategory1);
            this.Controls.Add(this.btnCreateNewRol);
            this.Name = "CategoryCreate";
            this.Size = new System.Drawing.Size(933, 547);
            this.Load += new System.EventHandler(this.CategoryCreate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateNewRol;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private RulesInCategory rulesInCategory1;
        
    }
}
