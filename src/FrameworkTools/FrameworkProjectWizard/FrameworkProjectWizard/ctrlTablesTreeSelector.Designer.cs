namespace Fwk.Wizard
{
    partial class ctrlTablesTreeSelector
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
            this.ctrlTreeViewTables1 = new Fwk.Wizard.ctrlTreeViewTables();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(619, 75);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(819, 456);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(710, 456);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(523, 438);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(418, 438);
            // 
            // ctrlTreeViewTables1
            // 
            this.ctrlTreeViewTables1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctrlTreeViewTables1.Location = new System.Drawing.Point(20, 97);
            this.ctrlTreeViewTables1.Name = "ctrlTreeViewTables1";
            this.ctrlTreeViewTables1.SelectedTable = null;
            this.ctrlTreeViewTables1.Size = new System.Drawing.Size(233, 335);
            this.ctrlTreeViewTables1.TabIndex = 69;
            this.ctrlTreeViewTables1.Tablas = null;
            // 
            // ctrlTablesTreeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlTreeViewTables1);
            this.Name = "ctrlTablesTreeSelector";
            this.Size = new System.Drawing.Size(619, 465);
            this.Controls.SetChildIndex(this.ctrlTreeViewTables1, 0);
            this.Controls.SetChildIndex(this.btnBack, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlTreeViewTables ctrlTreeViewTables1;
    }
}
