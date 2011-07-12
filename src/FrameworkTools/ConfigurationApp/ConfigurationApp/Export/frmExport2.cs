using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Fwk.ConfigSection;
using Fwk.Bases.FrontEnd;

namespace ConfigurationApp
{
    public partial class frmExport2 : FrmBase
    {
        ConfigProviderElement _SourceProvider;
        ConfigProviderElement _SelectedProvider;

        public frmExport2(ConfigProviderElement sourceProvider)
        {
            _SourceProvider = sourceProvider;
            InitializeComponent(); 
            LoadConfig();
        }
        void LoadConfig()
        {
      

            SetProviderSource();
            SetProviderDest();


            //cargo la grilla izquierda
            ucbServiceGrid1.ConfigurationFile = Fwk.Configuration.ConfigurationManager.GetConfigurationFile(_SourceProvider.Name);

    
            //lleno el combo de posibles proveedores destino
            foreach (ConfigProviderElement p in Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers)
            {
                if (!_SourceProvider.Name.Equals(p.Name))
                    cmb2.Items.Add(p.Name);
            }


            cmb2.SelectedIndex = 0;
            _SelectedProvider = Fwk.Configuration.ConfigurationManager.ConfigProvider.GetProvider(cmb2.SelectedItem.ToString());

            cmb2.SelectedValueChanged += new EventHandler(cb_SelectedValueChanged);


            this.Text = string.Concat("Export data from ", _SourceProvider.Name, " to ", _SourceProvider.Name);
        }

        /// <summary>
        /// CAmbia el proveedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cb_SelectedValueChanged(object sender, EventArgs e)
        {

            _SelectedProvider = Fwk.Configuration.ConfigurationManager.ConfigProvider.GetProvider(cmb2.SelectedItem.ToString());

            SetProviderDest() ;


            try
            {
                
                //cargo la grilla derecha
                ucbServiceGrid2.ConfigurationFile = Fwk.Configuration.ConfigurationManager.GetConfigurationFile(_SelectedProvider.Name);
     

            

                //muestro el titulo
                this.Text = string.Concat("Export data from ", _SelectedProvider.Name, " to ", _SelectedProvider.Name);
            }
            catch (Exception ex)
            {

                base.ExceptionViewer.Show(ex);
               
                ucbServiceGrid1.ConfigurationFile = null;

            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            using (frmExport3 frm = new frmExport3(_SourceProvider,_SelectedProvider,ucbServiceGrid1.ConfigList))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if(frm.HasErrors)
                        this.MessageViewer.Show("Export terminated with warnings or errors!! ");
                    else
                        this.MessageViewer.Show("Export terminated successfully !! ");
                }
            }
        }


        void SetProviderSource()
        {
            provider1.Populate(_SourceProvider);
          
        }

        void SetProviderDest()
        {
            provider2.Populate(_SelectedProvider);
        }
        
    }
}
