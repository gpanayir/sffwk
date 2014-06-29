namespace CodeGenerator
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.generatosFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToStringBuilderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigurationLibrariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearDataConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel1 = new Fwk.Controls.Win32.DockPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generatosFormsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1183, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generatosFormsToolStripMenuItem
            // 
            this.generatosFormsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backEndToolStripMenuItem,
            this.entitiesToolStripMenuItem,
            this.servicesToolStripMenuItem1});
            this.generatosFormsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.generatosFormsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.generatosFormsToolStripMenuItem.Image = global::CodeGenerator.Properties.Resources.WinXPSetV4_Icon_60;
            this.generatosFormsToolStripMenuItem.Name = "generatosFormsToolStripMenuItem";
            this.generatosFormsToolStripMenuItem.Size = new System.Drawing.Size(111, 21);
            this.generatosFormsToolStripMenuItem.Text = "Generatos ";
            // 
            // backEndToolStripMenuItem
            // 
            this.backEndToolStripMenuItem.Image = global::CodeGenerator.Properties.Resources.SchemaDataSourceOk2;
            this.backEndToolStripMenuItem.Name = "backEndToolStripMenuItem";
            this.backEndToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.backEndToolStripMenuItem.Text = "BackEnd";
            this.backEndToolStripMenuItem.Click += new System.EventHandler(this.backEndToolStripMenuItem_Click);
            // 
            // entitiesToolStripMenuItem
            // 
            this.entitiesToolStripMenuItem.Image = global::CodeGenerator.Properties.Resources.WindowsHS;
            this.entitiesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.entitiesToolStripMenuItem.Name = "entitiesToolStripMenuItem";
            this.entitiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.entitiesToolStripMenuItem.Text = "Entities";
            this.entitiesToolStripMenuItem.Click += new System.EventHandler(this.entitiesToolStripMenuItem_Click);
            // 
            // servicesToolStripMenuItem1
            // 
            this.servicesToolStripMenuItem1.Name = "servicesToolStripMenuItem1";
            this.servicesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.servicesToolStripMenuItem1.Text = "Services";
            this.servicesToolStripMenuItem1.Click += new System.EventHandler(this.servicesToolStripMenuItem1_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToStringBuilderToolStripMenuItem,
            this.ConfigurationLibrariesToolStripMenuItem,
            this.customizeTemplateToolStripMenuItem});
            this.toolsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(57, 21);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // textToStringBuilderToolStripMenuItem
            // 
            this.textToStringBuilderToolStripMenuItem.Image = global::CodeGenerator.Properties.Resources.textdoc;
            this.textToStringBuilderToolStripMenuItem.Name = "textToStringBuilderToolStripMenuItem";
            this.textToStringBuilderToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.textToStringBuilderToolStripMenuItem.Text = "Text to StringBuilder";
            this.textToStringBuilderToolStripMenuItem.Click += new System.EventHandler(this.textToStringBuilderToolStripMenuItem_Click);
            // 
            // ConfigurationLibrariesToolStripMenuItem
            // 
            this.ConfigurationLibrariesToolStripMenuItem.Image = global::CodeGenerator.Properties.Resources.Web_XML;
            this.ConfigurationLibrariesToolStripMenuItem.Name = "ConfigurationLibrariesToolStripMenuItem";
            this.ConfigurationLibrariesToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.ConfigurationLibrariesToolStripMenuItem.Text = " Configuration libraries";
            this.ConfigurationLibrariesToolStripMenuItem.Click += new System.EventHandler(this.ConfigurationLibrariesToolStripMenuItem_Click);
            // 
            // customizeTemplateToolStripMenuItem
            // 
            this.customizeTemplateToolStripMenuItem.Image = global::CodeGenerator.Properties.Resources.SetDef32;
            this.customizeTemplateToolStripMenuItem.Name = "customizeTemplateToolStripMenuItem";
            this.customizeTemplateToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.customizeTemplateToolStripMenuItem.Text = "Customize Template";
            this.customizeTemplateToolStripMenuItem.Click += new System.EventHandler(this.customizeTemplateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearDataConnectionToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.aboutToolStripMenuItem.Image = global::CodeGenerator.Properties.Resources.question;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(67, 21);
            this.aboutToolStripMenuItem.Text = "&Help";
            // 
            // clearDataConnectionToolStripMenuItem
            // 
            this.clearDataConnectionToolStripMenuItem.Image = global::CodeGenerator.Properties.Resources.clear_small;
            this.clearDataConnectionToolStripMenuItem.Name = "clearDataConnectionToolStripMenuItem";
            this.clearDataConnectionToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.clearDataConnectionToolStripMenuItem.Text = "Clear data connection";
            this.clearDataConnectionToolStripMenuItem.Click += new System.EventHandler(this.clearDataConnectionToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(233, 22);
            this.aboutToolStripMenuItem1.Text = "About Code Generator";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.BackColor = System.Drawing.Color.Transparent;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(1183, 706);
            this.dockPanel1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1183, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CodeGenerator.Properties.Resources.SchemaDataSourceOk2;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.ForeColor = System.Drawing.Color.Transparent;
            this.toolStripButton2.Image = global::CodeGenerator.Properties.Resources.WindowsHS;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::CodeGenerator.Properties.Resources.services;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::CodeGenerator.Properties.Resources.clear_small;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1183, 706);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dockPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1187, 738);
            this.Name = "Main";
            this.Text = "Code generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToStringBuilderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigurationLibrariesToolStripMenuItem;
        private Fwk.Controls.Win32.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem customizeTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatosFormsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backEndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearDataConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}