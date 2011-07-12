using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.ConfigSection;
using Fwk.Bases;
using Fwk.Bases.Blocks.Fwk.Configuration.config;
using Fwk.Configuration.Common;

namespace ConfigurationApp
{
    public partial class frmExport3 : Form
    {
        StringBuilder log;
        bool _HasErrors = false;

        public bool HasErrors
        {
            get { return _HasErrors; }
        
        }
        public StringBuilder Logs
        {
            get { return log; }
         
        } 
        ConfigProviderElement _SourceProvider;
        ConfigProviderElement _SelectedProvider;
        List<Fwk.Bases.Blocks.Fwk.Configuration.config.fwk_ConfigMannager> _ConfigLsit;

        public frmExport3(ConfigProviderElement from, ConfigProviderElement to, List<Fwk.Bases.Blocks.Fwk.Configuration.config.fwk_ConfigMannager> configLsit)
        {
            InitializeComponent();
            _SourceProvider = from;
            _SelectedProvider = to;
            _ConfigLsit = configLsit;

         
        }

        void Expòrt()
        {
            log = new StringBuilder();
            ConfigurationFile sourceConfigFile = Fwk.Configuration.ConfigurationManager.GetConfigurationFile(_SelectedProvider.Name);
            foreach (Group g in sourceConfigFile.Groups)
            {
                try
                {
                 
                      Fwk.Configuration.ConfigurationManager_CRUD.AddGroup(_SelectedProvider.Name, g);
                      log.AppendLine(string.Concat("grupo : ", g.Name, " OK"));
                   
                }
                catch (Fwk.Exceptions.TechnicalException te)
                {
                    if (te.ErrorId.Equals("7002"))
                        log.AppendLine(string.Concat("grupo : ", g.Name, " already exist"));
                    else
                        log.AppendLine(string.Concat("grupo : ", g.Name, Fwk.Exceptions.ExceptionHelper.GetAllMessageException(te)));
                    _HasErrors = true;
                }

            }
            textBox1.Text = log.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Expòrt();
            btnOk.Enabled = false;
            btnCancel.Text = "Exit";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnOk.Enabled)
                this.DialogResult = DialogResult.Cancel;
            else
                this.DialogResult = DialogResult.OK;
        }

    }
}
