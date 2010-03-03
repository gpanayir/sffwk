using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Logging;
using Fwk.Configuration;
using Fwk.ConfigSection;
using Fwk.Logging.Targets;
namespace Fwk.Logging.Test
{
    public partial class frmLoggingTest : Form
    {
        Logger _loger = new Logger();
        LoggingSection _LoggingSection;
        public frmLoggingTest()
        {
            InitializeComponent();
            txtFilePrefix.Text = string.Concat(DateTime.Now.Hour, "_", DateTime.Now.Minute, "_");
             _LoggingSection = System.Configuration.ConfigurationManager.GetSection("FwkLogging") as LoggingSection;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            _loger.Warning("Fwk Loggin test", "Mensage de prueba para Fwk Loggin");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _loger.Audit("Fwk Loggin test", "Mensage de prueba para Fwk Loggin",Environment.UserName,Environment.MachineName);
            
        }


        
        private void button2_Click(object sender, EventArgs e)
        {

            Events _Logs = Fwk.Logging.Events.GetFromXml<Events>(Fwk.HelperFunctions.FileFunctions.OpenTextFile(_LoggingSection.GetRuleByEventType(EventType.Error).FileName));
         
            loadingResultsTextBox.Text = _Logs.GetXml();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _loger.Error("Test Login", "pppppppppppppppppppppppp");
        }

       
        private void button4_Click_1(object sender, EventArgs e)
        {
            Fwk.Logging.StaticLogger.ClearXmlTargetEvents();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Events _Logs = Fwk.Logging.Events.GetFromXml<Events>(Fwk.HelperFunctions.FileFunctions.OpenTextFile(_LoggingSection.GetRuleByEventType(EventType.Error).FileName));

            textBox1.Text = _Logs.GetXml();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Events _Logs = Fwk.Logging.Events.GetFromXml<Events>
                (Fwk.HelperFunctions.FileFunctions.OpenTextFile
                (_LoggingSection.GetRuleByEventType(EventType.Audit).FileName));

            textBox1.Text = _Logs.GetXml();
        }
        private void button3_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 100; i++)
            {

                Fwk.Logging.StaticLogger.Log(EventType.Warning, "test login" + i.ToString(), "aaaaaaaaaaaaaaaa", AppDomain.CurrentDomain.BaseDirectory, txtFilePrefix.Text);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                ITarget target = GetTarget(EventType.Warning);
                //string filename = string.Concat(txtFilePrefix.Text, _LoggingSection.GetRuleByEventType(EventType.Warning).FileName);
                //filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
                //Events _Logs = Fwk.Logging.Events.GetFromXml<Events>(Fwk.HelperFunctions.FileFunctions.OpenTextFile(filename));
                Event ee = new Event();

                Events _Logs = target.SearchByParam(ee);
                textBox2.Text = _Logs.GetXml();
            }
            catch(Exception ex)
            {
             MessageBox.Show(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex));
            
            }
            
        }
        ITarget GetTarget(EventType type)
        {
            ITarget target = null ;
            RuleElement rule = _LoggingSection.GetRuleByEventType(type);
            switch (rule.Target)
            {
                case TargetType.Database:
                    {
                        target = new DatabaseTarget();
                        ((DatabaseTarget)target).CnnStringName = rule.CnnStringName;
                     
                        break;
                    }
                case TargetType.Xml:
                    {
                        target = new XmlTarget();
                        ((XmlTarget)target).FileName = rule.FileName;
                        break;
                    }
            }
            return target;
        }

    }
}
