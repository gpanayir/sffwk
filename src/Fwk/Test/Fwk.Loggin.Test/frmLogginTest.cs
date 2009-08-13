using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Logging;
namespace Fwk.Logging.Test
{
    public partial class frmLoggingTest : Form
    {
        Logger _loger = new Logger();
        public frmLoggingTest()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _loger.Warning("Fwk Loggin test", "Mensage de prueba para Fwk Loggin");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _loger.Audit("Fwk Loggin test", "Mensage de prueba para Fwk Loggin",Environment.UserName,Environment.MachineName);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Events _Logs = Fwk.Logging.Events.GetFromXml<Events>(Fwk.HelperFunctions.FileFunctions.OpenTextFile("Logs.xml"));
            loadingResultsTextBox.Text = _Logs.GetXml();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _loger.Error("Test Login", "pppppppppppppppppppppppp");
        }

        private void button3_Click(object sender, EventArgs e)
        {


            string prefixLogFile = string.Concat(DateTime.Now.Hour, "_", DateTime.Now.Minute, "_");
            for (int i = 0; i < 100; i++)
            {

                Fwk.Logging.StaticLogger.Warning("test login" + i.ToString(), "aaaaaaaaaaaaaaaa", @"C:\xx", prefixLogFile);
            }
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Fwk.Logging.StaticLogger.ClearXmlTargetEvents();
        }
    }
}
