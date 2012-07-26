using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.ConfigSection;
using Fwk.Configuration.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Runtime.Remoting.Messaging;
using Fwk.Exceptions;
using System.Reflection;

namespace MultiLanguageMannager
{
    public delegate void DelegateWithOutAndRefParameters(out Exception ex);
    public partial class frmMain : Fwk.UI.Forms.FormBase
    {
        ConfigMannagerGridList _ConfigMannagerGridList = new ConfigMannagerGridList();
        DataTable _configPivotDts = null;
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            PopulateAsync();
            string product = string.Empty;

                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length != 0)
                    product= ((AssemblyProductAttribute)attributes[0]).Product;

                this.Text = String.Concat(product, " version ", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
        }


        void buildgrid()
        {
      
            ConfigMannagerGrid p;

            StringBuilder providerColumns = new StringBuilder();
            for (int i = 0; i < Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers.Count; i++)
            {
                providerColumns.Append(string.Concat("[",Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers[i].Name,"]"));
                if (i < Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers.Count-1)
                    providerColumns.Append(",");
                //string providerName = Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers[i].Name;
                //ConfigurationFile file = Fwk.Configuration.ConfigurationManager.GetConfigurationFile(providerName);
                //foreach (Group grp in file.Groups)
                //{
                //    foreach (Key k in grp.Keys)
                //    {
                //        p = new ConfigMannagerGrid();
                //        p.Provider = providerName;
                //        p.Group = grp.Name;
                //        p.Key = k.Name;
                //        p.Value = k.Value.Text;
                //        _ConfigMannagerGridList.Add(p);
                //    }
                //}


            }

            _configPivotDts = RetrivePivotedConfigs(providerColumns.ToString()).Tables[0];
           
      
        }




    

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            bool wExist = false;
            fwk_ConfigMannager record;
            string language = e.Column.ToString();
            string key = gridView2.GetDataRow(e.RowHandle)["key"].ToString();
            string group = gridView2.GetDataRow(e.RowHandle)["group"].ToString();

            
            try
            {
                using (ConfigDataContext dc = new ConfigDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["bb"].ConnectionString))
                {
                

                    //Verifico que clave y valor exista
                    wExist = dc.fwk_ConfigMannagers.Any(p => p.ConfigurationFileName.Equals(language)
                    && p.group.Equals(group)
                    && p.key.Equals(key));

                    if (wExist)
                    {
                         record = dc.fwk_ConfigMannagers.Where(p => p.ConfigurationFileName.Equals(language)
                                           && p.group.Equals(group)
                                           && p.key.Equals(key)).FirstOrDefault < fwk_ConfigMannager>();

                        record.value = e.Value.ToString().Trim();
                    }

                    else
                    {
                        record = new fwk_ConfigMannager();
                        record.ConfigurationFileName = language;
                        record.group = group;
                        record.key = key;
                        dc.fwk_ConfigMannagers.InsertOnSubmit(record);
                    }
                    dc.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
         
        }
        

       

        #region PopulateSync

        /// <summary>
        /// Carga de manera asincrona los Dominios relacionados entre si en la grilla.-
        /// </summary>
        public void PopulateAsync()
        {
            Exception ex = null;
            DelegateWithOutAndRefParameters s = new DelegateWithOutAndRefParameters(Populate);

            s.BeginInvoke(out ex, new AsyncCallback(EndPopulate), null);
        }

        /// <summary>
        /// Fin de el metodo populate que fue llamado de forma asincrona
        /// </summary>
        /// <param name="res"></param>
        void EndPopulate(IAsyncResult res)
        {
            Exception ex;

            if (this.InvokeRequired)
            {
                AsyncCallback d = new AsyncCallback(EndPopulate);
                this.Invoke(d, new object[] { res });
            }
            else
            {
                AsyncResult result = (AsyncResult)res;

                DelegateWithOutAndRefParameters del = (DelegateWithOutAndRefParameters)result.AsyncDelegate;
                del.EndInvoke(out ex, res);
                if (ex != null)
                {

                    MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
                    return;
                }
                gridControl2.DataSource = _configPivotDts;
                gridControl2.RefreshDataSource();
                gridView2.RefreshData();

                gridView2.Columns[0].OptionsColumn.AllowEdit = false;
                gridView2.Columns[0].OptionsColumn.ReadOnly = false;
                gridView2.Columns[1].OptionsColumn.AllowEdit = false;
                gridView2.Columns[1].OptionsColumn.ReadOnly = false;

                
                gridView2.Columns[0].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gridView2.Columns[0].AppearanceCell.ForeColor = System.Drawing.Color.SteelBlue;
                gridView2.Columns[0].AppearanceCell.Options.UseBackColor = true;
                gridView2.Columns[0].AppearanceCell.Options.UseFont = true;
                gridView2.Columns[0].AppearanceCell.Options.UseForeColor = true;

                gridView2.Columns[0].GroupIndex =0;
                gridView2.Columns[1].AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gridView2.Columns[1].AppearanceCell.ForeColor = System.Drawing.Color.SteelBlue;
                gridView2.Columns[1].AppearanceCell.Options.UseBackColor = true;
                gridView2.Columns[1].AppearanceCell.Options.UseFont = true;
                gridView2.Columns[1].AppearanceCell.Options.UseForeColor = true;
             

            }
        }

        /// <summary>
        /// Carga Dominios relacionados entre al objeto _RelatedDomains que esta bindiado a la grilla
        /// </summary>
        void Populate(out Exception ex)
        {
            ex = null;

            try
            {
                buildgrid();

            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }
        }

        #endregion


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            buildgrid();


        }
        public DataSet RetrivePivotedConfigs(String columns)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;



            wDataBase = DatabaseFactory.CreateDatabase("bb");
            wCmd = wDataBase.GetStoredProcCommand("fwk_ConfigMannager_PIVOT");
            wDataBase.AddInParameter(wCmd, "columns", System.Data.DbType.String, columns);


            return wDataBase.ExecuteDataSet(wCmd);

        }

      


    }
}
