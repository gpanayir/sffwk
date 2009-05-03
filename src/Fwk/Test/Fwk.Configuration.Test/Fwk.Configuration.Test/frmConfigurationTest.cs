using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.Configuration.Common;
using System.IO;

namespace Fwk.Configuration.Test
{
    public partial class frmConfigurationTest : Form
    {
        public frmConfigurationTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = ConfigurationManager.GetProperty("RemoteProvider","ValidationExceptionMessage", "NullOrEmptyField");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            try
            {
                str.AppendLine("Provider 01 ");
                str.AppendLine(ConfigurationManager.GetProperty("ExceptionMessages", "fecha_desde_igual_hasta_error"));
                str.AppendLine("Provider 02");
                str.AppendLine(ConfigurationManager.GetProperty("P2", "ClientMessages", "nohayproductos_error"));

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

      

        }

        private void btnLoadConfigFile_Click(object sender, EventArgs e)
        {
            Fwk.Configuration.Common.Key wKey;
            Fwk.Configuration.Common.Groups wGroups;
            Fwk.Configuration.Common.Group wGroup;
            wGroups = new Fwk.Configuration.Common.Groups();

            wGroup = new Fwk.Configuration.Common.Group();
            wGroup.Name = "G1";
            wKey = new Fwk.Configuration.Common.Key();
            wKey.Name = "K1";
            wKey.Value.Text = "aaaaaaaaaaaaaaaaa";

            wGroup.Keys.Add(wKey);

            wKey = new Fwk.Configuration.Common.Key();
            wKey.Name = "K2";
            wKey.Value.Text = "cccccccccccccccccccccccccccccccccc";
            wGroup.Keys.Add(wKey);


            wGroups.Add(wGroup);



           

            wGroup = new Fwk.Configuration.Common.Group();
            wGroup.Name = "G2";
            wKey = new Fwk.Configuration.Common.Key();
            wKey.Name = "K1";
            wKey.Value.Text = "aaaaaaaaaaaaaaaaa";

            wGroup.Keys.Add(wKey);

            wKey = new Fwk.Configuration.Common.Key();
            wKey.Name = "K2";
            wKey.Value.Text = "cccccccccccccccccccccccccccccccccc";
            wGroup.Keys.Add(wKey);


            wGroups.Add(wGroup);


            xmlConfitFile.Text = wGroups.GetXml();
            xmlConfitFile.ForeColor = Color.Green;
        }

        private void btnGetProvider_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string xml = HelperFunctions.FileFunctions.OpenTextFile(Path.Combine( Application.StartupPath , txtConfigFileName.Text));

            //Groups wGroups = Fwk.Configuration.Common.Groups.GetFromXml<Groups>(xml);
            Groups wGroups = Fwk.Configuration.Common.Groups.GetFromXml(xml);
            xmlConfitFile.ForeColor = Color.Red;

            xmlConfitFile.Text = wGroups.GetXml();
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            //Groups wGroups = Fwk.Configuration.Common.Groups.GetFromXml<Groups>(xmlConfitFile.Text);
            Groups wGroups = (Groups)HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(Groups), xmlConfitFile.Text);
            xmlConfitFile.ForeColor = Color.Blue;
            xmlConfitFile.Text = wGroups.GetXml();

        }
    }
}