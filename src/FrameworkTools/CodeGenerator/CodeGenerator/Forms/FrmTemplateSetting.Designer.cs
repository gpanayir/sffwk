namespace CodeGenerator.Forms
{
    partial class FrmTemplateSetting
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
            CodeGenerator.Back.Common.TemplateSettingObject templateSettingObject1 = new CodeGenerator.Back.Common.TemplateSettingObject();
            CodeGenerator.Back.Common.Entities entities1 = new CodeGenerator.Back.Common.Entities();
            CodeGenerator.Back.Common.Methods methods1 = new CodeGenerator.Back.Common.Methods();
            CodeGenerator.Back.Common.MethodsName methodsName1 = new CodeGenerator.Back.Common.MethodsName();
            CodeGenerator.Back.Common.NamespacesPattern NamespacesPattern1 = new CodeGenerator.Back.Common.NamespacesPattern();
            CodeGenerator.Back.Common.StoreProceduresPattern storeProceduresPattern1 = new CodeGenerator.Back.Common.StoreProceduresPattern();
            this.genTemplateSetting1 = new CodeGenerator.Controls.GenTemplateSetting();
            this.SuspendLayout();
            // 
            // genTemplateSetting1
            // 
            this.genTemplateSetting1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.genTemplateSetting1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.genTemplateSetting1.FullFileName = global::CodeGenerator.Properties.Resources.AppIcon;
            this.genTemplateSetting1.Location = new System.Drawing.Point(0, 0);
            this.genTemplateSetting1.Name = "genTemplateSetting1";
            this.genTemplateSetting1.Size = new System.Drawing.Size(607, 440);
            this.genTemplateSetting1.TabIndex = 0;
            entities1.CollectionsSufix = "List";
            entities1.EntitySufix = "BE";
            templateSettingObject1.Entities = entities1;
            templateSettingObject1.FullFileName = "TemplateSetting.cgt";
            methods1.GenerateBatch = true;
            methods1.IncludeDelete = true;
            methods1.IncludeGetAll = true;
            methods1.IncludeGetByParam = true;
            methods1.IncludeGetPaginated = true;
            methods1.IncludeInsert = true;
            methods1.IncludeUpdate = true;
            templateSettingObject1.Methods = methods1;
            methodsName1.Delete = "Delete";
            methodsName1.GetAll = "GetAll";
            methodsName1.GetAllPaginated = "GetAllPaginated";
            methodsName1.GetByParam = "GetByParam";
            methodsName1.Insert = "Insert";
            methodsName1.Update = "Update";
            templateSettingObject1.MethodsName = methodsName1;
            NamespacesPattern1.BusinessComponents = "BackEnd.BusinessComponents";
            NamespacesPattern1.BusinessEntities = "BackEnd.BusinessEntities";
            NamespacesPattern1.BusinessService = "BackEnd.BusinessService";
            NamespacesPattern1.DataAccessComponent = "BackEnd.DataAccessComponents";
            NamespacesPattern1.InterfaceServices = "InterfaceServices";
            NamespacesPattern1.TableDataGateway = "BackEnd.TableDataGateway";
            templateSettingObject1.Namespaces = NamespacesPattern1;
            storeProceduresPattern1.DeleteSufix = "_d";
            storeProceduresPattern1.GetAllPaginated = "_sp";
            storeProceduresPattern1.GetAllSufix = "_s";
            storeProceduresPattern1.GetByParamSufix = "_g";
            storeProceduresPattern1.InsertSufix = "_i";
            storeProceduresPattern1.UpdateSufix = "_u";
            templateSettingObject1.StoreProcedures = storeProceduresPattern1;
            this.genTemplateSetting1.TemplateSettingObject = templateSettingObject1;
            this.genTemplateSetting1.PropertyChange += new CodeGenerator.Controls.PropertyChangeHandler(this.genTemplateSetting1_PropertyChange);
            // 
            // FrmTemplateSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 440);
            this.Controls.Add(this.genTemplateSetting1);
            this.Name = "FrmTemplateSetting";
            this.TabText = "Template Setting";
            this.Text = "Template Setting";
            this.ResumeLayout(false);

        }

        #endregion

        private CodeGenerator.Controls.GenTemplateSetting genTemplateSetting1;
    }
}