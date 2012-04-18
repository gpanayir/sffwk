namespace Fwk.UI.Controls
{
    partial class UC_AssigmentBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_AssigmentBase));
            this.workingAreaControl1 = new Fwk.UI.Controls.Designers.WorkingAreaControl();
            this.workingAreaControl2 = new Fwk.UI.Controls.Designers.WorkingAreaControl();
            this.aceptCancelButtonBar1 = new Fwk.UI.Controls.UC_AceptCancelButtonBar();
            this.textFindPopUp1 = new Fwk.UI.Controls.UC_TextFindPopUp();
            this.textFindPopUp2 = new Fwk.UI.Controls.UC_TextFindPopUp();
            this.SuspendLayout();
            // 
            // workingAreaControl1
            // 
            this.workingAreaControl1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.workingAreaControl1.Location = new System.Drawing.Point(52, 78);
            this.workingAreaControl1.Name = "workingAreaControl1";
            this.workingAreaControl1.Size = new System.Drawing.Size(220, 276);
            this.workingAreaControl1.TabIndex = 0;
            // 
            // workingAreaControl2
            // 
            this.workingAreaControl2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.workingAreaControl2.Location = new System.Drawing.Point(294, 78);
            this.workingAreaControl2.Name = "workingAreaControl2";
            this.workingAreaControl2.Size = new System.Drawing.Size(220, 276);
            this.workingAreaControl2.TabIndex = 1;
            // 
            // aceptCancelButtonBar1
            // 
         
            this.aceptCancelButtonBar1.AceptButtonText = "&Aceptar";
            this.aceptCancelButtonBar1.AceptButtonEnabled = true;
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            
            this.aceptCancelButtonBar1.CancelButtonText = "&Cancelar";
            this.aceptCancelButtonBar1.CancelButtonEnabled = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(52, 409);
            this.aceptCancelButtonBar1.Name = "aceptCancelButtonBar1";
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(462, 23);
            this.aceptCancelButtonBar1.TabIndex = 2;
            // 
            // textFindPopUp1
            // 
            this.textFindPopUp1.Location = new System.Drawing.Point(52, 32);
            this.textFindPopUp1.Name = "textFindPopUp1";
            this.textFindPopUp1.PopupControl = null;
            this.textFindPopUp1.Size = new System.Drawing.Size(220, 30);
            this.textFindPopUp1.TabIndex = 3;
            // 
            // textFindPopUp2
            // 
            this.textFindPopUp2.Location = new System.Drawing.Point(294, 32);
            this.textFindPopUp2.Name = "textFindPopUp2";
            this.textFindPopUp2.PopupControl = null;
            this.textFindPopUp2.Size = new System.Drawing.Size(220, 30);
            this.textFindPopUp2.TabIndex = 4;
            // 
            // UC_AssigmentBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textFindPopUp2);
            this.Controls.Add(this.textFindPopUp1);
            this.Controls.Add(this.aceptCancelButtonBar1);
            this.Controls.Add(this.workingAreaControl2);
            this.Controls.Add(this.workingAreaControl1);
            this.Name = "UC_AssigmentBase";
            this.Size = new System.Drawing.Size(533, 458);
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.UI.Controls.Designers.WorkingAreaControl workingAreaControl1;
        private Fwk.UI.Controls.Designers.WorkingAreaControl workingAreaControl2;
        private Fwk.UI.Controls.UC_AceptCancelButtonBar aceptCancelButtonBar1;
        private UC_TextFindPopUp textFindPopUp1;
        private UC_TextFindPopUp textFindPopUp2;
    }
}
