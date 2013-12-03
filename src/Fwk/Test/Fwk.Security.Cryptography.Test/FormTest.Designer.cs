namespace Fwk.Security.Cryptography.Test
{
    partial class FormTest
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
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKey = new System.Windows.Forms.Button();
            this.txtValorOriginal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtNoCifrado = new System.Windows.Forms.TextBox();
            this.btnDEncrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCifrado = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKey
            // 
            this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtKey.Location = new System.Drawing.Point(30, 45);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(565, 20);
            this.txtKey.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Kye file (genere la clave y almacenela en un archivo )";
            // 
            // btnKey
            // 
            this.btnKey.Location = new System.Drawing.Point(618, 41);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(116, 22);
            this.btnKey.TabIndex = 25;
            this.btnKey.Text = "Create key file";
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // txtValorOriginal
            // 
            this.txtValorOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorOriginal.Location = new System.Drawing.Point(29, 314);
            this.txtValorOriginal.Multiline = true;
            this.txtValorOriginal.Name = "txtValorOriginal";
            this.txtValorOriginal.Size = new System.Drawing.Size(584, 57);
            this.txtValorOriginal.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Valor inicial";
            // 
            // txtNoCifrado
            // 
            this.txtNoCifrado.AcceptsReturn = true;
            this.txtNoCifrado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoCifrado.Location = new System.Drawing.Point(30, 69);
            this.txtNoCifrado.Multiline = true;
            this.txtNoCifrado.Name = "txtNoCifrado";
            this.txtNoCifrado.Size = new System.Drawing.Size(584, 94);
            this.txtNoCifrado.TabIndex = 22;
            this.txtNoCifrado.Text = "Cuando comen los leones";
            // 
            // btnDEncrypt
            // 
            this.btnDEncrypt.Location = new System.Drawing.Point(638, 204);
            this.btnDEncrypt.Name = "btnDEncrypt";
            this.btnDEncrypt.Size = new System.Drawing.Size(81, 38);
            this.btnDEncrypt.TabIndex = 21;
            this.btnDEncrypt.Text = "Desencriptar";
            this.btnDEncrypt.UseVisualStyleBackColor = true;
            this.btnDEncrypt.Click += new System.EventHandler(this.btnDEncrypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Valor encriptado";
            // 
            // txtCifrado
            // 
            this.txtCifrado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCifrado.Location = new System.Drawing.Point(30, 186);
            this.txtCifrado.Multiline = true;
            this.txtCifrado.Name = "txtCifrado";
            this.txtCifrado.Size = new System.Drawing.Size(584, 95);
            this.txtCifrado.TabIndex = 19;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(638, 94);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(81, 38);
            this.btnEncrypt.TabIndex = 18;
            this.btnEncrypt.Text = "Encriptar";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 469);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKey);
            this.Controls.Add(this.txtValorOriginal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoCifrado);
            this.Controls.Add(this.btnDEncrypt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCifrado);
            this.Controls.Add(this.btnEncrypt);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormTest";
            this.Text = "Form_ConArchivo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKey;
        private System.Windows.Forms.TextBox txtValorOriginal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtNoCifrado;
        private System.Windows.Forms.Button btnDEncrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCifrado;
        private System.Windows.Forms.Button btnEncrypt;
    }
}