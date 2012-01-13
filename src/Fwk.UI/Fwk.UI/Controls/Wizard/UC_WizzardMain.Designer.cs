using Fwk.UI.Common;

namespace Fwk.UI.Controls.Wizard
{
    partial class UC_WizzardMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_WizzardMain));
            this.wizardControl1 = new DevExpress.XtraWizard.WizardControl();
            this.WPInicio = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.WPOrigenDeDatos = new DevExpress.XtraWizard.WizardPage();
            this.uC_OrigenDeDatos1 = new Fwk.UI.Controls.Wizard.UC_OrigenDeDatos();
            this.WPBdAuthenticacion = new DevExpress.XtraWizard.WizardPage();
            this.uC_AuthenticationBD1 = new Fwk.UI.Controls.Wizard.UC_AuthenticationBD();
            this.WPBDTablas = new DevExpress.XtraWizard.WizardPage();
            this.pnlTablasBD = new DevExpress.XtraEditors.PanelControl();
            this.uC_TablasBD1 = new Fwk.UI.Controls.Wizard.UC_TablasBD();
            this.WPMapeo = new DevExpress.XtraWizard.WizardPage();
            this.uC_MapeoColumnas1 = new Fwk.UI.Controls.Wizard.UC_MapeoColumnas();
            this.WPExcelFileSelection = new DevExpress.XtraWizard.WizardPage();
            this.uC_ExcelWorkSheets1 = new Fwk.UI.Controls.Wizard.UC_ExcelWorkSheets();
            this.pnlExcel = new DevExpress.XtraEditors.PanelControl();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.WPImportar = new DevExpress.XtraWizard.WizardPage();
            this.uC_Importar1 = new Fwk.UI.Controls.Wizard.UC_Importar();
            this.WPFlatText = new DevExpress.XtraWizard.WizardPage();
            this.pnlPlainText = new DevExpress.XtraEditors.PanelControl();
            this.uC_FlatText1 = new Fwk.UI.Controls.Wizard.UC_FlatText();
            this.WPSeparatedText = new DevExpress.XtraWizard.WizardPage();
            this.pnlSeparated = new DevExpress.XtraEditors.PanelControl();
            this.uC_SeparatedText1 = new Fwk.UI.Controls.Wizard.UC_SeparatedText();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.wizardControl1.SuspendLayout();
            this.WPOrigenDeDatos.SuspendLayout();
            this.WPBdAuthenticacion.SuspendLayout();
            this.WPBDTablas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTablasBD)).BeginInit();
            this.WPMapeo.SuspendLayout();
            this.WPExcelFileSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlExcel)).BeginInit();
            this.WPImportar.SuspendLayout();
            this.WPFlatText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPlainText)).BeginInit();
            this.WPSeparatedText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSeparated)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.CancelText = "Cancelar";
            this.wizardControl1.Controls.Add(this.WPInicio);
            this.wizardControl1.Controls.Add(this.WPOrigenDeDatos);
            this.wizardControl1.Controls.Add(this.WPBdAuthenticacion);
            this.wizardControl1.Controls.Add(this.WPBDTablas);
            this.wizardControl1.Controls.Add(this.WPMapeo);
            this.wizardControl1.Controls.Add(this.WPExcelFileSelection);
            this.wizardControl1.Controls.Add(this.completionWizardPage1);
            this.wizardControl1.Controls.Add(this.WPImportar);
            this.wizardControl1.Controls.Add(this.WPFlatText);
            this.wizardControl1.Controls.Add(this.WPSeparatedText);
            this.wizardControl1.FinishText = "Finalizar";
            this.wizardControl1.HelpText = "&Ayuda";
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.NextText = "&Siguiente >";
            this.wizardControl1.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.WPInicio,
            this.WPOrigenDeDatos,
            this.WPExcelFileSelection,
            this.WPBdAuthenticacion,
            this.WPBDTablas,
            this.WPMapeo,
            this.WPImportar,
            this.WPFlatText,
            this.WPSeparatedText,
            this.completionWizardPage1});
            this.wizardControl1.PreviousText = "< &Atras";
            this.wizardControl1.Text = "Importador de Datos";
            this.wizardControl1.PrevClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_PrevClick);
            this.wizardControl1.FinishClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_FinishClick);
            this.wizardControl1.NextClick += new DevExpress.XtraWizard.WizardCommandButtonClickEventHandler(this.wizardControl1_NextClick);
            this.wizardControl1.CancelClick += new System.ComponentModel.CancelEventHandler(this.wizardControl1_CancelClick);
            // 
            // WPInicio
            // 
            this.WPInicio.IntroductionText = resources.GetString("WPInicio.IntroductionText");
            this.WPInicio.Name = "WPInicio";
            this.WPInicio.ProceedText = "Presione Siguiente para continuar.";
            this.WPInicio.Size = new System.Drawing.Size(353, 343);
            this.WPInicio.Text = "Importador de Datos";
            // 
            // WPOrigenDeDatos
            // 
            this.WPOrigenDeDatos.Controls.Add(this.uC_OrigenDeDatos1);
            this.WPOrigenDeDatos.DescriptionText = "Seleccione el origen desde donde usted desea obtener los datos";
            this.WPOrigenDeDatos.Name = "WPOrigenDeDatos";
            this.WPOrigenDeDatos.Size = new System.Drawing.Size(538, 331);
            this.WPOrigenDeDatos.Text = "Origen de Datos";
            // 
            // uC_OrigenDeDatos1
            // 
            this.uC_OrigenDeDatos1.AcceptButton = null;
            this.uC_OrigenDeDatos1.CancelButton = null;
            this.uC_OrigenDeDatos1.Location = new System.Drawing.Point(107, 54);
            this.uC_OrigenDeDatos1.Name = "uC_OrigenDeDatos1";
            this.uC_OrigenDeDatos1.Size = new System.Drawing.Size(301, 70);
            this.uC_OrigenDeDatos1.TabIndex = 0;
            // 
            // WPBdAuthenticacion
            // 
            this.WPBdAuthenticacion.Controls.Add(this.uC_AuthenticationBD1);
            this.WPBdAuthenticacion.DescriptionText = "A continuación debe validar sus credenciales  y seleccionar la Base de Datos desd" +
                "e donde desea obtener los datos.";
            this.WPBdAuthenticacion.Name = "WPBdAuthenticacion";
            this.WPBdAuthenticacion.Size = new System.Drawing.Size(538, 331);
            this.WPBdAuthenticacion.Text = "Validación de credenciales";
            // 
            // uC_AuthenticationBD1
            // 
            this.uC_AuthenticationBD1.AcceptButton = null;
            this.uC_AuthenticationBD1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.uC_AuthenticationBD1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.uC_AuthenticationBD1.CancelButton = null;
            this.uC_AuthenticationBD1.DataBaseSelected = null;
            this.uC_AuthenticationBD1.Location = new System.Drawing.Point(132, 3);
            this.uC_AuthenticationBD1.Name = "uC_AuthenticationBD1";
            this.uC_AuthenticationBD1.NameServer = "";
            this.uC_AuthenticationBD1.ServerSelected = null;
            this.uC_AuthenticationBD1.Size = new System.Drawing.Size(301, 18981);
            this.uC_AuthenticationBD1.TabIndex = 1;
            // 
            // WPBDTablas
            // 
            this.WPBDTablas.Controls.Add(this.pnlTablasBD);
            this.WPBDTablas.Controls.Add(this.uC_TablasBD1);
            this.WPBDTablas.DescriptionText = "Usted ahora debera seleccionar la tabla y las columnas que desea importar. A cont" +
                "inuación presione Siguiente.";
            this.WPBDTablas.Name = "WPBDTablas";
            this.WPBDTablas.Size = new System.Drawing.Size(538, 331);
            this.WPBDTablas.Text = "Seleccion de tablas";
            // 
            // pnlTablasBD
            // 
            this.pnlTablasBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTablasBD.Location = new System.Drawing.Point(0, 193);
            this.pnlTablasBD.Name = "pnlTablasBD";
            this.pnlTablasBD.Size = new System.Drawing.Size(538, 138);
            this.pnlTablasBD.TabIndex = 1;
            // 
            // uC_TablasBD1
            // 
            this.uC_TablasBD1.AcceptButton = null;
            this.uC_TablasBD1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.uC_TablasBD1.CancelButton = null;
            this.uC_TablasBD1.ColumnasAMapear = null;
            this.uC_TablasBD1.DataBaseSelected = null;
            this.uC_TablasBD1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uC_TablasBD1.Location = new System.Drawing.Point(0, 0);
            this.uC_TablasBD1.MaximumSize = new System.Drawing.Size(552, 196);
            this.uC_TablasBD1.Name = "uC_TablasBD1";
            this.uC_TablasBD1.NameServer = "";
            this.uC_TablasBD1.ServerSelected = null;
            this.uC_TablasBD1.Size = new System.Drawing.Size(538, 193);
            this.uC_TablasBD1.TabIndex = 0;
            this.uC_TablasBD1.TableSelected = null;
            // 
            // WPMapeo
            // 
            this.WPMapeo.Controls.Add(this.uC_MapeoColumnas1);
            this.WPMapeo.DescriptionText = "Asocie las columnas seleccionadas con las columnas correspondientes, y presione s" +
                "iguiente para continuar con la importación";
            this.WPMapeo.Name = "WPMapeo";
            this.WPMapeo.Size = new System.Drawing.Size(538, 331);
            this.WPMapeo.Text = "Asociación de columnas";
            // 
            // uC_MapeoColumnas1
            // 
            this.uC_MapeoColumnas1.AcceptButton = null;
            this.uC_MapeoColumnas1.CancelButton = null;
            this.uC_MapeoColumnas1.ColumnsSource = null;
            this.uC_MapeoColumnas1.ColumnsTarget = null;
            this.uC_MapeoColumnas1.DataToImport = null;
            this.uC_MapeoColumnas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_MapeoColumnas1.Location = new System.Drawing.Point(0, 0);
            this.uC_MapeoColumnas1.MappingType = Fwk.UI.Common.DataOriginTypeEnum.DataBase;
            this.uC_MapeoColumnas1.Name = "uC_MapeoColumnas1";
            this.uC_MapeoColumnas1.Size = new System.Drawing.Size(538, 331);
            this.uC_MapeoColumnas1.TabIndex = 0;
            // 
            // WPExcelFileSelection
            // 
            this.WPExcelFileSelection.Controls.Add(this.uC_ExcelWorkSheets1);
            this.WPExcelFileSelection.Controls.Add(this.pnlExcel);
            this.WPExcelFileSelection.DescriptionText = "Seleccione la planilla de calculo de la cual desea importar sus datos, para conti" +
                "nuar presione siguiente.";
            this.WPExcelFileSelection.Name = "WPExcelFileSelection";
            this.WPExcelFileSelection.Size = new System.Drawing.Size(538, 331);
            this.WPExcelFileSelection.Text = "Selección de Planilla de Cálculo";
            // 
            // uC_ExcelWorkSheets1
            // 
            this.uC_ExcelWorkSheets1.AcceptButton = null;
            this.uC_ExcelWorkSheets1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.uC_ExcelWorkSheets1.CancelButton = null;
            this.uC_ExcelWorkSheets1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uC_ExcelWorkSheets1.Location = new System.Drawing.Point(0, 0);
            this.uC_ExcelWorkSheets1.Name = "uC_ExcelWorkSheets1";
            this.uC_ExcelWorkSheets1.SelectedFilePath = null;
            this.uC_ExcelWorkSheets1.Size = new System.Drawing.Size(538, 85);
            this.uC_ExcelWorkSheets1.TabIndex = 0;
            // 
            // pnlExcel
            // 
            this.pnlExcel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlExcel.Location = new System.Drawing.Point(0, 62);
            this.pnlExcel.Name = "pnlExcel";
            this.pnlExcel.Size = new System.Drawing.Size(538, 269);
            this.pnlExcel.TabIndex = 3;
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.FinishText = "Usted ha completado exitósamente la importación de datos.";
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "Para cerrar el asistente, presione Finalizar";
            this.completionWizardPage1.Size = new System.Drawing.Size(353, 343);
            this.completionWizardPage1.Text = "Finalizando el asistente";
            // 
            // WPImportar
            // 
            this.WPImportar.Controls.Add(this.uC_Importar1);
            this.WPImportar.DescriptionText = "A Continuación debe proceder a importar los datos";
            this.WPImportar.Name = "WPImportar";
            this.WPImportar.Size = new System.Drawing.Size(538, 331);
            this.WPImportar.Text = "Importar Datos";
            // 
            // uC_Importar1
            // 
            this.uC_Importar1.AcceptButton = null;
            this.uC_Importar1.CancelButton = null;
            this.uC_Importar1.DataBaseName = null;
            this.uC_Importar1.DataTableMapper = null;
            this.uC_Importar1.DataToImport = null;
            this.uC_Importar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Importar1.Location = new System.Drawing.Point(0, 0);
            this.uC_Importar1.MappingType = Fwk.UI.Common.DataOriginTypeEnum.None;
            this.uC_Importar1.Name = "uC_Importar1";
            this.uC_Importar1.ServerName = null;
            this.uC_Importar1.Size = new System.Drawing.Size(538, 331);
            this.uC_Importar1.TabIndex = 0;
            // 
            // WPFlatText
            // 
            this.WPFlatText.Controls.Add(this.pnlPlainText);
            this.WPFlatText.Controls.Add(this.uC_FlatText1);
            this.WPFlatText.DescriptionText = "Importa datos de un archivo de texto plano";
            this.WPFlatText.Name = "WPFlatText";
            this.WPFlatText.Size = new System.Drawing.Size(538, 331);
            this.WPFlatText.Text = "Importar Texto Plano";
            // 
            // pnlPlainText
            // 
            this.pnlPlainText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlainText.Location = new System.Drawing.Point(0, 183);
            this.pnlPlainText.Name = "pnlPlainText";
            this.pnlPlainText.Size = new System.Drawing.Size(538, 148);
            this.pnlPlainText.TabIndex = 1;
            // 
            // uC_FlatText1
            // 
            this.uC_FlatText1.AcceptButton = null;
            this.uC_FlatText1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.uC_FlatText1.CancelButton = null;
            this.uC_FlatText1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uC_FlatText1.Location = new System.Drawing.Point(0, 0);
            this.uC_FlatText1.Name = "uC_FlatText1";
            this.uC_FlatText1.Size = new System.Drawing.Size(538, 183);
            this.uC_FlatText1.TabIndex = 0;
            // 
            // WPSeparatedText
            // 
            this.WPSeparatedText.Controls.Add(this.pnlSeparated);
            this.WPSeparatedText.Controls.Add(this.uC_SeparatedText1);
            this.WPSeparatedText.DescriptionText = "Importar texto separado por caracteres";
            this.WPSeparatedText.Name = "WPSeparatedText";
            this.WPSeparatedText.Size = new System.Drawing.Size(538, 331);
            this.WPSeparatedText.Text = "Texto separado por caracter";
            // 
            // pnlSeparated
            // 
            this.pnlSeparated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSeparated.Location = new System.Drawing.Point(0, 104);
            this.pnlSeparated.Name = "pnlSeparated";
            this.pnlSeparated.Size = new System.Drawing.Size(538, 227);
            this.pnlSeparated.TabIndex = 4;
            // 
            // uC_SeparatedText1
            // 
            this.uC_SeparatedText1.AcceptButton = null;
            this.uC_SeparatedText1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.uC_SeparatedText1.CancelButton = null;
            this.uC_SeparatedText1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uC_SeparatedText1.Location = new System.Drawing.Point(0, 0);
            this.uC_SeparatedText1.Name = "uC_SeparatedText1";
            this.uC_SeparatedText1.Size = new System.Drawing.Size(538, 104);
            this.uC_SeparatedText1.TabIndex = 0;
            // 
            // UC_WizzardMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wizardControl1);
            this.Name = "UC_WizzardMain";
            this.Size = new System.Drawing.Size(570, 476);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            this.WPOrigenDeDatos.ResumeLayout(false);
            this.WPBdAuthenticacion.ResumeLayout(false);
            this.WPBDTablas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTablasBD)).EndInit();
            this.WPMapeo.ResumeLayout(false);
            this.WPExcelFileSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlExcel)).EndInit();
            this.WPImportar.ResumeLayout(false);
            this.WPFlatText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPlainText)).EndInit();
            this.WPSeparatedText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSeparated)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardControl1;
        private DevExpress.XtraWizard.WelcomeWizardPage WPInicio;
        private DevExpress.XtraWizard.WizardPage WPOrigenDeDatos;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private UC_OrigenDeDatos uC_OrigenDeDatos1;
        private DevExpress.XtraWizard.WizardPage WPBdAuthenticacion;
        private UC_AuthenticationBD uC_AuthenticationBD1;
        private DevExpress.XtraWizard.WizardPage WPBDTablas;
        private UC_TablasBD uC_TablasBD1;
        private DevExpress.XtraWizard.WizardPage WPMapeo;
        private UC_MapeoColumnas uC_MapeoColumnas1;
        private DevExpress.XtraWizard.WizardPage WPExcelFileSelection;
        private UC_ExcelWorkSheets uC_ExcelWorkSheets1;
        private DevExpress.XtraEditors.PanelControl pnlTablasBD;
        private DevExpress.XtraWizard.WizardPage WPImportar;
        private UC_Importar uC_Importar1;
        private DevExpress.XtraWizard.WizardPage WPFlatText;
        private DevExpress.XtraWizard.WizardPage WPSeparatedText;
        private UC_SeparatedText uC_SeparatedText1;
        private DevExpress.XtraEditors.PanelControl pnlSeparated;
        private UC_FlatText uC_FlatText1;
        private DevExpress.XtraEditors.PanelControl pnlPlainText;
        private DevExpress.XtraEditors.PanelControl pnlExcel;
    }
}
