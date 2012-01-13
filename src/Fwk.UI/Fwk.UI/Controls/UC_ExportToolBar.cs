using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraExport;
using DevExpress.XtraGrid.Export;
using Common = Fwk.UI.Common;

namespace Fwk.UI.Controls
{
    [ToolboxItem(true)]
    public partial class UC_ExportToolBar : DevExpress.XtraEditors.XtraUserControl
    {

        #region Members

        private DevExpress.XtraGrid.Views.Grid.GridView _GridViewToExport;
        private DevExpress.XtraGrid.GridControl _GridControl;

        #endregion

        #region Properties

        [Category("Fwk.Libraries")]
        public SimpleButton BtnExcel
        {
            get { return btnExcel; }
            set { btnExcel = value; }
        }

        [Category("Fwk.Libraries")]
        public SimpleButton BtnPDF
        {
            get { return btnPDF; }
            set { btnPDF = value; }
        }

        [Category("Fwk.Libraries")]
        public SimpleButton BtnTXT
        {
            get { return btnTXT; }
            set { btnTXT = value; }
        }

        [Category("Fwk.Libraries")]
        public SimpleButton BtnHTML
        {
            get { return btnHTML; }
            set { btnHTML = value; }
        }

        [Category("Fwk.Libraries")]
        public SimpleButton BtnXML
        {
            get { return btnXML; }
            set { btnXML = value; }
        }

        [Category("Fwk.Libraries")]
        public DevExpress.XtraGrid.Views.Grid.GridView GridViewToExport
        {
            get { return _GridViewToExport; }
            set { _GridViewToExport = value; }
        }

   
        /// <summary>
        /// Esta propiedad se utiliza para exportar a PDF.
        /// </summary>
        [Category("Fwk.Libraries")]
        public DevExpress.XtraGrid.GridControl GridControl
        {
            get { return _GridControl; }
            set { _GridControl = value; }
        }

        #endregion

        #region Constructor

        public UC_ExportToolBar()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos Clicks

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string fileName = ShowSaveFileDialog("documento de planilla de c�lculo", "Documento de planilla de c�lculo (*.xls)|*.xls");

            if (!string.IsNullOrEmpty(fileName))
            {
                ExportTo(new ExportXlsProvider(fileName));
                OpenFile(fileName);
            }
        }

        private void btnHTML_Click(object sender, EventArgs e)
        {
            string fileName = ShowSaveFileDialog("p�gina web", "P�gina web (*.html)|*.html");

            if (!string.IsNullOrEmpty(fileName))
            {
                ExportTo(new ExportHtmlProvider(fileName));
                OpenFile(fileName);
            }
        }

        private void btnTXT_Click(object sender, EventArgs e)
        {
            string fileName = ShowSaveFileDialog("documento de texto", "Documento de texto|*.txt");

            if (!string.IsNullOrEmpty(fileName))
            {
                ExportTo(new ExportTxtProvider(fileName));
                OpenFile(fileName);
            }
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            string fileName = ShowSaveFileDialog("archivo XML", "Archivo XML (*.xml)|*.xml");

            if (!string.IsNullOrEmpty(fileName))
            {
                ExportTo(new ExportXmlProvider(fileName));
                OpenFile(fileName);
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            string wFileName = ShowSaveFileDialog("documento port�til (PDF)", "Archivo PDF (*.pdf)|*.pdf");

            if (!string.IsNullOrEmpty(wFileName))
            {
                ExportToPdfWithLandScape(_GridControl, wFileName);
                //_GridViewToExport.ExportToPdf(fileName);
                OpenFile(wFileName);
            }
        }

        #endregion

        #region Methods

        private string ShowSaveFileDialog(string pTitle, string pFilter)
        {
            SaveFileDialog wDialog = new SaveFileDialog();
            wDialog.Title = "Exportar a " + pTitle;
            wDialog.FileName = string.Empty;
            wDialog.Filter = pFilter;

            if (wDialog.ShowDialog() == DialogResult.OK)
                return wDialog.FileName;

            return string.Empty;
        }

        private void ExportTo(IExportProvider pProvider)
        {
            Cursor wCurrentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            this.FindForm().Refresh();
            BaseExportLink wLink = _GridViewToExport.CreateExportLink(pProvider);
            (wLink as GridViewExportLink).ExpandAll = false;
            //link.Progress += new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);

            wLink.ExportTo(true);
            pProvider.Dispose();
            //link.Progress -= new DevExpress.XtraGrid.Export.ProgressEventHandler(Export_Progress);

            Cursor.Current = wCurrentCursor;
        }

        private void ExportToPdfWithLandScape(DevExpress.XtraGrid.GridControl pGridControl, string pFileName)
        {
            DevExpress.XtraPrinting.PrintingSystem wPrintingSystem = new DevExpress.XtraPrinting.PrintingSystem();
            DevExpress.XtraPrinting.PrintableComponentLink wPrintLink = new DevExpress.XtraPrinting.PrintableComponentLink();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                wPrintLink.Component = pGridControl;
                wPrintLink.CreateDocument(wPrintingSystem);
                wPrintLink.Landscape = true;

                wPrintingSystem.PageSettings.LeftMargin = 0;
                wPrintingSystem.PageSettings.RightMargin = 0;

                wPrintingSystem.PageSettings.Landscape = true;
                wPrintingSystem.ExportToPdf(pFileName);
            }
            catch (Exception ex)
            {
                simpleMessageViewComponent1.Show(string.Format("No se pudo exportar la grilla. Error: {0}", ex.Message.ToString()));
            }
            finally
            {
                this.Cursor = Cursors.Default;
                wPrintingSystem.Dispose();
                wPrintLink.Dispose();
            }

        }

        private void OpenFile(string pFileName)
        {
            if (simpleMessageViewComponent2.Show("�Desea abrir este archivo?") == DialogResult.Yes)
            //if (XtraMessageBox.Show("�Desea abrir este archivo?", "Exportaci�n", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process wProcess = new System.Diagnostics.Process();
                    wProcess.StartInfo.FileName = pFileName;
                    wProcess.StartInfo.Verb = "Open";
                    wProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    wProcess.Start();
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, "No se pudo encontrar una aplicaci�n adecuada en su sistema para abrir el archivo con los datos exportados", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //progressBarControl1.Position = 0;
        }

        #endregion
    }
}