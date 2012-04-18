

namespace Fwk.UI.Controls
{
    partial class UC_SearchTypeComboBox
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
            this.cmbSearchType = new ComboBoxBase(this.components);
            this.SuspendLayout();
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.ActiveArrowColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbSearchType.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbSearchType.ActiveButtonColor = System.Drawing.SystemColors.ControlDark;
            this.cmbSearchType.AllowEmptyTextValue = false;
            this.cmbSearchType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSearchType.AutoComplete = false;
            this.cmbSearchType.ErrorIconRightToLeft = false;
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.InactiveArrowColor = System.Drawing.SystemColors.ControlDark;
            this.cmbSearchType.InactiveBorderColor = System.Drawing.SystemColors.ControlDark;
            this.cmbSearchType.InactiveButtonColor = System.Drawing.SystemColors.Control;
            this.cmbSearchType.Location = new System.Drawing.Point(3, 1);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.NullTextValue = null;
            this.cmbSearchType.ReadOnly = false;
            this.cmbSearchType.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.cmbSearchType.Required = false;
            this.cmbSearchType.RequiredErrorText = null;
            this.cmbSearchType.Size = new System.Drawing.Size(276, 21);
            this.cmbSearchType.TabIndex = 0;
            // 
            // PelsoftTipoBusquedaCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbSearchType);
            this.Name = "PelsoftTipoBusquedaCombo";
            this.Size = new System.Drawing.Size(284, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBoxBase cmbSearchType;

    }
}
