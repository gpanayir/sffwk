﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.ConfigSection;
using Fwk.Bases;

namespace Fwk.ServiceManagement.Tools.Win32
{
    public partial class frmExport : Form
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
        ServiceProviderElement _SourceProvider;
        ServiceProviderElement _SelectedProvider;
        ServiceConfigurationCollection _Services;
        public frmExport(ServiceProviderElement from, ServiceProviderElement to, ServiceConfigurationCollection services)
        {
            InitializeComponent();
            _SourceProvider = from;
            _SelectedProvider = to;
            _Services = services;
        }

        void Expòrt()
        {
            log = new StringBuilder();
            foreach (Fwk.Bases.ServiceConfiguration s in _Services)
            {
                try
                {
                    Fwk.Bases.ServiceConfiguration sclon = s.Clone();
                    sclon.ApplicationId = txtAppId.Text;
                        
                    ServiceMetadata.AddServiceConfiguration(_SelectedProvider.Name, s);
                    log.AppendLine(string.Concat(s.Name, " OK"));
                }
                catch (Fwk.Exceptions.TechnicalException te)
                {
                    if (te.ErrorId.Equals("7002"))
                        log.AppendLine(string.Concat(s.Name, " already exist"));
                    else
                        log.AppendLine(string.Concat(s.Name, te.Message));
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
