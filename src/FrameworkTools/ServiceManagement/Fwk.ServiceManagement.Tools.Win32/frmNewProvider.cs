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

namespace Fwk.ServiceManagement.Tools.Win32
{
    public partial class frmNewProvider : FrmBase
    {
        WrapperProviderElement _SourceProvider;
        WrapperProviderElement _SelectedProvider;
        WrapperProviderSection _ProviderSection;
        public frmNewProvider(WrapperProviderElement sourceProvider)
        {
            _SourceProvider = sourceProvider;
            InitializeComponent(); LoadConfig();
        }
        void LoadConfig()
        {
            System.Configuration.Configuration wConfiguration = null;
            ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();

            configFile.ExeConfigFilename = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

            wConfiguration = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            _ProviderSection = ConfigurationManager.GetSection("FwkWrapper") as WrapperProviderSection;

            lblMetadata_source.Text = _SourceProvider.WrapperProviderType.ToString();
            txtAddres_source.Text = _SourceProvider.SourceInfo;

            ucbServiceGrid1.Services = base.GetAllServices(_SourceProvider.Name);

            foreach (WrapperProviderElement p in _ProviderSection.Providers)
            {
                if (!_SourceProvider.Name.Equals(p.Name))
                    cmb2.Items.Add(p.Name);
            }


            cmb2.SelectedIndex = 0;
            _SelectedProvider = _ProviderSection.GetProvider(cmb2.SelectedItem.ToString());

            cmb2.SelectedValueChanged += new EventHandler(cb_SelectedValueChanged);
        }
        void cb_SelectedValueChanged(object sender, EventArgs e)
        {

            _SelectedProvider = _ProviderSection.GetProvider(cmb2.SelectedItem.ToString());
            lblMetadata.Text = _SelectedProvider.WrapperProviderType.ToString();
            txtAddres.Text = _SelectedProvider.SourceInfo;


            try
            {
                ucbServiceGrid2.Services = base.GetAllServices(_SelectedProvider.Name);
                lblConnectionStatus.Text = "Connected";
            }
            catch (Exception ex)
            {

                base.ExceptionViewer.Show(ex);
                lblConnectionStatus.Text = "Disconnected";
                ucbServiceGrid1.Services = null;

            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            LoadConfig();
        }
    }
}
