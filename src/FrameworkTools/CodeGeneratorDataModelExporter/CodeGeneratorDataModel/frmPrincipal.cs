using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using Fwk.DataBase;
using Fwk.DataBase.DataEntities;

namespace CodeGenerator.DataModelExporter
{
    public partial class frmPrincipal : Form
    {

        public delegate void ExportBegin();
        public delegate void ExportEnd();

        #region " Atributes "
        /// <summary>
        /// Extención del archivo a exportar.
        /// </summary>
        private const string SZ_FILEEXTENSION = @"xml";

        #endregion

        #region " Misc. "

        public frmPrincipal()
        {
            InitializeComponent();
        }

        #endregion

        #region " Events "

        /// <summary>
        /// Cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Manejo del evento "Aceptar" del control de conexión a la 
        /// base de datos.
        /// </summary>
        /// <param name="ConnectionOK"></param>
        private void cnnDataBaseForm_AceptEvent(bool ConnectionOK)
        {
            //this.btnExport.Enabled = ConnectionOK;

            lblInfo.Text = "Seleccionar destino...";
            this.cnnDataBaseForm.Enabled = false;

            Application.DoEvents();

            Export();

            this.Cursor = Cursors.Default;
            this.cnnDataBaseForm.Enabled = true;
            lblInfo.Text = string.Empty;

        }


        private void cnnDataBaseForm_CancelEvent()
        {
            this.Close();
        }

        #endregion

        #region " Methods "

        /// <summary>
        /// Exportar
        /// </summary>
        private void Export()
        {

            // 1- Preparar "Save File Dialog"
            SaveFileDialog dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.OverwritePrompt = true;
            dlgSaveFile.AddExtension = true;
            dlgSaveFile.Filter = string.Format("GenCode Data Model File|*.{0}", SZ_FILEEXTENSION);
            dlgSaveFile.FileName = this.cnnDataBaseForm.Connection.InitialCatalog;

            // 2- Seleccinar el archivo de destino.
            if (dlgSaveFile.ShowDialog() != DialogResult.OK)
                return;

            this.Cursor = Cursors.WaitCursor;

            lblInfo.Text = string.Format("Leyendo \"{0}\"...", this.cnnDataBaseForm.Connection.InitialCatalog);
            Application.DoEvents();

            // 3- Actualizar metadata.
            Metadata oMetaData = null;
            try
            {
                oMetaData = GetMetaData();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
                return;
            }

            lblInfo.Text = "Guardando archivo...";
            Application.DoEvents();

            // 4- Serializar objeto.            
            Stream oFile = null;
            try
            {
                oFile = dlgSaveFile.OpenFile();

                XmlSerializer oSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Metadata));

                oSerializer.Serialize(oFile, oMetaData);

                oFile.Close();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                if (oFile != null)
                    oFile.Close();
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Obtiene la metadata de la base de datos seleccionada.
        /// </summary>
        /// <returns>Metadata Object</returns>
        private Metadata GetMetaData()
        {
            Metadata oMetaData = new Metadata();

            //Conectar.
            oMetaData.TestConnection();

            //Leer procedimientos
            oMetaData.LoadStoreProcedures();
            IList<Fwk.DataBase.DataEntities.StoreProcedure> lstStoredProcedures = oMetaData.StoreProcedures;
            int iCounter = 1;
            foreach (StoreProcedure oStoredProcedure in lstStoredProcedures)
            {
                lblInfo.Text = string.Format("Leyendo procedimientos almacenados... {0}/{1}", iCounter++, lstStoredProcedures.Count);
                Application.DoEvents();
                oMetaData.StoreProcedures_FillParameters(oStoredProcedure);
            }

            //Leer tablas
            oMetaData.LoadTables();
            IList<Fwk.DataBase.DataEntities.Table> lstTables = oMetaData.Tables;
            iCounter = 1;
            foreach (Table oTable in lstTables)
            {
                lblInfo.Text = string.Format("Leyendo tablas... {0}/{1}", iCounter++, lstTables.Count);
                Application.DoEvents();
                oMetaData.Table_FillColumns(oTable);
            }

            return oMetaData;
        }

        #endregion



    }


}
