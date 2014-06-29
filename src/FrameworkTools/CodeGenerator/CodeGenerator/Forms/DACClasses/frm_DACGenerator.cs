using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CodeGenerator.Back;
using CodeGenerator.Bases;
using  Fwk.DataBase.DataEntities ;
using CodeGenerator.Controllers;
using CodeGenerator.Controls;

namespace CodeGenerator.DACClasses
{
    public partial class frm_DACGenerator : CodeGenerator.FrmBase
    {
        #region Private members 
        private string LastParentKey = string.Empty;
        private string LastEntityName = string.Empty;
        private DACGenController _DACGenController;
        #endregion

        public frm_DACGenerator()
        {
            InitializeComponent();
            base.InitializeLastAccessSource();
          
        }

       


        private void btnConnect_Click(object sender, EventArgs e)
        {
            base.ShowConnection();

            if (base.ConnectionOk)
            {
                if (base.CnnStringChange)
                {
                    treeViewTables1.Clear();
                    treeViewStoreProcedures1.Clear();
                }
                RefreshDataObject();
            }
        }

       
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataObject();
        }



        #region CodeGeneratedSelectEvent

        private void listViewCodeGenerated1_StoreProcedureCodeGeneratedSelectEvent(string pTextCode, string pEntityName, string pParentKey)
        {
            textCodeEditor1.Text = pTextCode;
            textCodeEditor1.TitleText = "Store Procedures from: " + pEntityName;
            LastEntityName = pEntityName;
            LastParentKey = pParentKey;
        }

        private void listViewCodeGenerated1_TDGCodeGeneratedSelectEvent(string pTextCode, string pEntityName, string pParentKey)
        {
            textCodeEditor1.Text = pTextCode;
            textCodeEditor1.TitleText = "Table Data Gateway from: " + pEntityName;
            LastEntityName = pEntityName;
            LastParentKey = pParentKey;
        }

        private void listViewCodeGenerated1_DACCodeGeneratedSelectEvent(string pTextCode, string pEntityName, string pParentKey)
        {
            textCodeEditor1.Text = pTextCode;
            textCodeEditor1.TitleText = "Data Access Components from: " + pEntityName;
            LastEntityName = pEntityName;
            LastParentKey = pParentKey;
        }

        private void listViewCodeGenerated1_BECodeGeneratedSelectEvent(string pTextCode, string pEntityName, string pParentKey)
        {
            textCodeEditor1.Text = pTextCode;
            textCodeEditor1.TitleText = "Business Entity from: " + pEntityName;
            LastEntityName = pEntityName;
            LastParentKey = pParentKey;

        }
        private void listViewCodeGenerated1_ServiceCodeGeneratedSelectEvent(string pTextCode, string pClassName)
        {
            textCodeEditor1.Text = pTextCode;
            textCodeEditor1.TitleText = "SVC/ISVC component" + pClassName;
            //LastEntityName = pEntityName;
            //LastParentKey = pParentKey;
        }
        #endregion

       

        private void toolStripButtonGenerate_Click(object sender, EventArgs e)
        {
            

            
            _DACGenController = new DACGenController();
            _DACGenController.UserDefinedTypes = base.Metadata.UserDefinedTypes;
            _DACGenController.TemplateSettingObject = base.TemplateSettingObject;


            _DACGenController.SelectedObject = Enum.GetName(typeof(CodeGeneratorCommon.SelectedObject), _SelectedObject);

            _DACGenController.ListViewCodeGenerated = this.listViewCodeGenerated1;
            switch (_SelectedObject)
            {
                case CodeGeneratorCommon.SelectedObject.Tables:
                    {
                        if (treeViewTables1.SelectedTable == null) return;
                        _DACGenController.Tables = treeViewTables1.GetSelectedTables();

                        break;
                    }


                case CodeGeneratorCommon.SelectedObject.StoreProcedures:
                    {
                        if (treeViewStoreProcedures1.SelectedStoreProcedure == null) return;
                        _DACGenController.StoreProcedures = treeViewStoreProcedures1.GetSelectedStoreProcedures();

                        break;
                    }
            }

            _DACGenController.Generate();

            //if(LastEntityName.Length !=0)
                textCodeEditor1.Text = listViewCodeGenerated1.GetFirstEntityCode("DAC");
            //else
            //{
            //    textCodeEditor1.Text = String.Empty;
            //    textCodeEditor1.TitleText = String.Empty;
            //}
        }

       

       

        #region Private methods

        private void RefreshDataObject()
        {

            try
            {
                base._SelectedObject = (CodeGeneratorCommon.SelectedObject)tabControl1.SelectedIndex;
                base.RefreshMetadata();

                
                

                //Esta seleccionado Tables
                if (_SelectedObject == CodeGeneratorCommon.SelectedObject.Tables)
                {
                    treeViewTables1.Tablas = base.Metadata.Tables;
                    treeViewTables1.LoadTreeView();
                }
                //Esta seleccionado StoreProcedures
                if (_SelectedObject == CodeGeneratorCommon.SelectedObject.StoreProcedures)
                {
                    treeViewStoreProcedures1.StoreProcedures = base.Metadata.StoreProcedures;
                    treeViewStoreProcedures1.LoadTreeView();
                }

                

                this.lblServer.Text = "Server:" + " [" + base.ServerName + "]";
                this.lblDatabase.Text = "Database:" + " [" + base.DataBaseName + "]";
            }
            catch (Exception ex)
            {
                //Common.WriteEntryEventLog("Error al cargar Objetos de base de datos. Puede que no este bien formado el archivo DataBaseConfig.xml", ex, 1001, System.Diagnostics.EventLogEntryType.Error);
                MessageView wMessageView = new MessageView();
                wMessageView.Message = ex.Message;
                wMessageView.ShowDialog();
            }
        }

        #endregion

      

        

        private void treeViewStoreProcedures1_SelectObjectEvent()
        {
            textCodeEditor1.Text = treeViewStoreProcedures1.SelectedStoreProcedure.Text;
        }

      

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {

            _SelectedObject = (CodeGeneratorCommon.SelectedObject)Enum.Parse(typeof(CodeGeneratorCommon.SelectedObject), tabControl1.SelectedTab.Tag.ToString());
        }

       
       
    }
}

