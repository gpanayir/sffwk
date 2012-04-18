using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraWizard;
using Fwk.HelperFunctions;
using Fwk.UI;
using Fwk.UI.Common;
using Fwk.UI.Controls.Wizard.BE;



namespace Fwk.UI.Controls.Wizard
{
    public partial class UC_WizzardMain : UC_UserControlBase
    {
        #region Eventos y delegados
        // Declare the delegate (if using non-generic pattern).
        public delegate void ImportEventHandler(object sender, Fwk.UI.Controls.Wizard.FRM_Wizard.ImportEventArgs e);
        //public delegate void CancelingImportEventHandler(object sender, EventArgs e);

        // Declare the event.
        public event ImportEventHandler ImportComplete;
        public event EventHandler CancelImport;

        #endregion

        #region Members

        private ColumnsMappingBEList _ColumnsToMap;
        private DataOriginTypeEnum _RecordSetFileType;// = DataOriginTypeEnum.DataBase;
        UC_GridPreview _GridPreview = new UC_GridPreview();
        private DataTable _Dt;
        private List<String> _ColumnsSelected = new List<string>();

        #endregion

        #region Properties

        public ColumnsMappingBEList ColumnsToMap
        {
            get
            {
                return _ColumnsToMap;
            }
            set
            {
                _ColumnsToMap = value;
            }
        }

        public DataOriginTypeEnum RecordSetFileType
        {
            get { return _RecordSetFileType; }
            set { _RecordSetFileType = value; }
        }
        #endregion

        #region Constructor

        public UC_WizzardMain()
        {
            InitializeComponent();
          
            _GridPreview.OnPreviewClick += new EventHandler(_GridPreview_OnPreviewClick);
            _GridPreview.Dock = DockStyle.Fill;           
        }

        #endregion


        #region Page Navigation Events & Methods

        private void wizardControl1_PrevClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {

            switch (e.Page.Name)
            {
                //Vuelve desde la página de Origen de Datos al Inicio
                case "WPOrigenDeDatos":
                    wizardControl1.SelectedPage = WPInicio;
                    break;

                // Vuelve desde la pagina de seleccion de Tablas a Autenticacion
                case "WPBDTablas":
                    wizardControl1.SelectedPage = WPBdAuthenticacion;
                    break;

                // Vuelve desde la pagina de Mapeo a Texto Plano, Texto separado por caracter, Excel o Tablas
                case "WPMapeo":
                    switch (uC_MapeoColumnas1.MappingType)
                    {
                        case DataOriginTypeEnum.CharSeparated:
                            wizardControl1.SelectedPage = WPSeparatedText;
                            break;

                        case DataOriginTypeEnum.DataBase:
                            wizardControl1.SelectedPage = WPBDTablas;
                            break;

                        case DataOriginTypeEnum.PlainText:
                            wizardControl1.SelectedPage = WPFlatText;
                            break;

                        case DataOriginTypeEnum.Xls:
                            wizardControl1.SelectedPage = WPExcelFileSelection;
                            break;

                        default:
                            break;
                    }
                    break;

                // Vuelve de la pagina Importar a Mapeo
                case "WPImportar":
                    wizardControl1.SelectedPage = WPMapeo;
                    break;


                // Vuelve desde las paginas de Texto Plano, Texto separado por caracter, Excel o Autenticación a Orígen de Datos
                default:
                    if (e.Page == WPBdAuthenticacion)
                        uC_AuthenticationBD1.StopBackGround();

                    wizardControl1.SelectedPage = WPOrigenDeDatos;
                    break;
            }
            e.Handled = true;
        }

        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            _ColumnsSelected.Clear();

            switch (e.Page.Name)
            {
                case "WPInicio":
                    wizardControl1.SelectedPage = WPOrigenDeDatos;
                    break;

                case "WPOrigenDeDatos":
                    if (uC_OrigenDeDatos1.ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                        wizardControl1.SelectedPage = ShowPageByFileType(e.Page);
                    else
                        wizardControl1.SelectedPage = WPOrigenDeDatos;
                    break;

                case "WPBdAuthenticacion":

                    if (uC_AuthenticationBD1.IsLoadingServerOrDataBase)
                    {
                        wizardControl1.SelectedPage = WPBdAuthenticacion;
                        e.Handled = true;
                        return;
                    }

                    if (uC_AuthenticationBD1.ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible) && !uC_AuthenticationBD1.HasErrors)
                    {
                        wizardControl1.SelectedPage = WPBDTablas;
                        uC_TablasBD1.ColumnasAMapear = _ColumnsToMap;
                        uC_TablasBD1.Populate(uC_AuthenticationBD1.DataBaseSelected, uC_AuthenticationBD1.ServerSelected);
                    }
                    else
                    {
                        wizardControl1.SelectedPage = WPBdAuthenticacion;
                    }
                    break;


                #region Paginas de acuerdo a los orígenes de datos

                case "WPBDTablas":
                    if (uC_TablasBD1.ValidateChildren(ValidationConstraints.Visible | ValidationConstraints.Enabled))
                    {
                        wizardControl1.SelectedPage = WPMapeo;
                        uC_MapeoColumnas1.MappingType = DataOriginTypeEnum.DataBase;
                        _ColumnsSelected = uC_TablasBD1.ColumnsSelected;
                        uC_MapeoColumnas1.Populate(_ColumnsSelected, _ColumnsToMap);                        
                    }
                    else
                    {
                        wizardControl1.SelectedPage = WPBDTablas;
                    }
                    break;

                case "WPExcelFileSelection":
                    if (uC_ExcelWorkSheets1.ValidateChildren(ValidationConstraints.Visible))
                    {
                        wizardControl1.SelectedPage = WPMapeo;

                        if (_Dt == null || _RecordSetFileType != DataOriginTypeEnum.Xls)
                            _Dt = ImportFunctions.ImportFromExcel(uC_ExcelWorkSheets1.SelectedFilePath, uC_ExcelWorkSheets1.SelectedWorkSheet);

                        if (_Dt.Columns.Count > 0)
                        {
                            foreach (DataColumn item in _Dt.Columns)
                            {
                                _ColumnsSelected.Add(item.ColumnName);
                            }

                            uC_MapeoColumnas1.Populate(_ColumnsSelected, _ColumnsToMap);
                            uC_MapeoColumnas1.DataToImport = _Dt;
                        }
                    }
                    else
                    {
                        wizardControl1.SelectedPage = WPExcelFileSelection;
                    }

                    uC_MapeoColumnas1.MappingType = DataOriginTypeEnum.Xls;
                    _RecordSetFileType = DataOriginTypeEnum.Xls;
                    break;

                case "WPFlatText":
                    if (uC_FlatText1.ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                    {
                        if (_Dt == null || _RecordSetFileType != DataOriginTypeEnum.PlainText)
                            _Dt = uC_FlatText1.GetDataTableFromTxt();

                        uC_MapeoColumnas1.DataToImport = _Dt;
                        wizardControl1.SelectedPage = WPMapeo;
                        uC_MapeoColumnas1.Populate(uC_FlatText1.ColumnsSelected, _ColumnsToMap);
                    }
                    else
                    {
                        wizardControl1.SelectedPage = WPFlatText;
                    }

                    _RecordSetFileType = DataOriginTypeEnum.PlainText;
                    uC_MapeoColumnas1.MappingType = DataOriginTypeEnum.PlainText;
                    break;

                case "WPSeparatedText":
                    if (uC_SeparatedText1.ValidateChildren() && !uC_SeparatedText1.ErrorProvider.HasErrors)
                    {
                        if (_Dt == null || _RecordSetFileType != DataOriginTypeEnum.CharSeparated)
                            _Dt = uC_SeparatedText1.GetDataTableFromCharSeparated();

                        if (_Dt == null)
                        {
                            wizardControl1.SelectedPage = WPSeparatedText;
                            e.Handled = true;
                            return;
                        }

                        wizardControl1.SelectedPage = WPMapeo;

                        if (_Dt.Columns.Count > 0)
                        {
                            foreach (DataColumn item in _Dt.Columns)
                            {
                                _ColumnsSelected.Add(item.ColumnName);
                            }
                            uC_MapeoColumnas1.DataToImport = _Dt;
                            uC_MapeoColumnas1.Populate(_ColumnsSelected, _ColumnsToMap);
                        }
                    }
                    else
                    {
                        wizardControl1.SelectedPage = WPSeparatedText;
                    }

                    _RecordSetFileType = DataOriginTypeEnum.CharSeparated;
                    uC_MapeoColumnas1.MappingType = DataOriginTypeEnum.CharSeparated;
                    break;

                #endregion

                case "WPMapeo":
                    wizardControl1.SelectedPage = WPImportar;                    

                    // si es del tipo BD se debe pasar los datos del servidor, base de datos y las columnas mapeadas
                    if (_RecordSetFileType == DataOriginTypeEnum.DataBase)
                    {
                        uC_Importar1.ServerName = uC_TablasBD1.NameServer;
                        uC_Importar1.DataBaseName = uC_TablasBD1.TableSelected.Name;
                        uC_Importar1.DataToImport = uC_TablasBD1.GetFullDataTable();
                        uC_Importar1.MappingType = DataOriginTypeEnum.DataBase;
                    }
                    else
                    {   // se pasa la tabla con los valores a insertar
                        uC_Importar1.DataToImport = uC_MapeoColumnas1.DataToImport;
                    }

                    // se pasa el mapeo de las columnas                    
                    uC_Importar1.DataTableMapper = uC_MapeoColumnas1.DataTableMapped;
                    uC_Importar1.PreImportComplete += new UC_Importar.ImportEventHandler(uC_Importar1_PreImportComplete);

                    break;

                case "WPImportar":
                    wizardControl1.SelectedPage = completionWizardPage1;

                    break;

                default:
                    break;
            }

            e.Handled = true;
        }

        void uC_Importar1_PreImportComplete(object sender, FRM_Wizard.ImportEventArgs e)
        {
            if(ImportComplete != null)
                ImportComplete(sender, e);

        }

        private BaseWizardPage ShowPageByFileType(BaseWizardPage pPage)
        {
            _GridPreview.GridView.Columns.Clear();

            //Se modifica el destino según el tipo de origen de datos
            switch ((DataOriginTypeEnum)((ImageComboBoxItem)uC_OrigenDeDatos1.SelectedItem).Value)
            {
                case DataOriginTypeEnum.CharSeparated:
                    _GridPreview.FileType = DataOriginTypeEnum.CharSeparated;
                    pPage = WPSeparatedText;
                    this.pnlSeparated.Controls.Add(_GridPreview);
                    break;

                case DataOriginTypeEnum.DataBase:
                    _GridPreview.FileType = DataOriginTypeEnum.DataBase;
                    pPage = WPBdAuthenticacion;
                    this.pnlTablasBD.Controls.Clear();
                    this.pnlTablasBD.Controls.Add(_GridPreview);
                    uC_AuthenticationBD1.Populate();
                    break;

                case DataOriginTypeEnum.PlainText:
                    _GridPreview.FileType = DataOriginTypeEnum.PlainText;
                    pPage = WPFlatText;
                    pnlPlainText.Controls.Add(_GridPreview);
                    break;

                case DataOriginTypeEnum.Xls:
                    _GridPreview.FileType = DataOriginTypeEnum.Xls;
                    pPage = WPExcelFileSelection;
                    this.pnlExcel.Controls.Add(_GridPreview);
                    break;

                default:
                    break;
            }
            return pPage;
        }

        #endregion

        private void _GridPreview_OnPreviewClick(object sender, EventArgs e)
        {

            switch (_GridPreview.FileType)
            {
                case DataOriginTypeEnum.CharSeparated:
                    if (uC_SeparatedText1.ValidateChildren() && !uC_SeparatedText1.ErrorProvider.HasErrors)
                        _Dt = uC_SeparatedText1.GetDataTableFromCharSeparated();
                    break;

                case DataOriginTypeEnum.DataBase:
                    _Dt = uC_TablasBD1.GetDataTable();
                    break;

                case DataOriginTypeEnum.PlainText:
                    if (uC_FlatText1.ValidateChildren())
                        _Dt = uC_FlatText1.GetDataTableFromTxt();
                    break;

                case DataOriginTypeEnum.Xls:
                    if (uC_ExcelWorkSheets1.ValidateChildren())
                        _Dt = ImportFunctions.ImportFromExcel(uC_ExcelWorkSheets1.SelectedFilePath, uC_ExcelWorkSheets1.SelectedWorkSheet);
                    break;

                default:
                    break;
            }

            if (_Dt != null)
                _GridPreview.Populate(Fwk.HelperFunctions.DataFunctions.GetTopRows(_Dt, 8));

        }

        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            MessageView wMsg = new MessageView();

            MessageViewer.MessageBoxButtons = MessageBoxButtons.YesNo;
            MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Question;

            if (DialogResult.Yes == MessageViewer.Show("¿Esta seguro que desea cancelar el proceso de importación?"))
            {
                if (CancelImport != null)
                {
                    CancelImport(wizardControl1.SelectedPage, new EventArgs());
                }
            }
        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            if (CancelImport != null)
            {
                CancelImport(null, new EventArgs());
            }
        }

    }
}
