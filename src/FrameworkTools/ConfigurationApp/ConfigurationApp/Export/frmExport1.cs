using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases.FrontEnd;
using Fwk.ConfigSection;
using System.Collections;

namespace ConfigurationApp
{
    public partial class frmExport1 : FrmBase
    {
        public frmExport1()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
           

     
           IEnumerable<ConfigProviderElement> l=  Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers.OfType<ConfigProviderElement>();

           var lista = from s in l select s.Name;
           source.DataSource = lista.ToList<string>();
           dest.SelectedItem = 0;
           source.Refresh();

           dest.DataSource = lista.ToList<string>();
           dest.SelectedItem = 1;
           dest.Refresh();
        }

        private void source_SelectedIndexChanged(object sender, EventArgs e)
        {
            provider1.Populate(Fwk.Configuration.ConfigurationManager.ConfigProvider.GetProvider(source.Text));
        }

        private void dest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dest.SelectedItem.ToString().Equals(source.SelectedItem.ToString()))
            {
                base.MessageViewer.Show("Seleccione un diferente del origen");
                return;
            }
            
            provider2.Populate(Fwk.Configuration.ConfigurationManager.ConfigProvider.GetProvider(dest.Text));
        }
    }
}
