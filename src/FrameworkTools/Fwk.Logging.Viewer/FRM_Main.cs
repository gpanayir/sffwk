using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.ProviderBase;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases;
using Fwk.Xml;
using System.Configuration;
using MagicControls = Crownwood.Magic.Controls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Fwk.Logging;

namespace Fwk.Logging.Viewer
{
    public partial class FRM_Main : Form
    {
        public FRM_Main()
        {
            InitializeComponent();
        }

        #region <private event handlers>
        private void FRM_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                HideForm();
            }
            if (e.KeyCode == Keys.F5)
            {
                RefreshTabDocument();
                System.Threading.Thread.Sleep(1000);
            }
        }
        #endregion

        #region <private menu event handlers>
        void refreshToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            RefreshTabDocument();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void mnuMostrar_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void ctlNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }
        
        private void mnuExit_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            string wFileName = GetFileName();
            if (!string.IsNullOrEmpty(wFileName))
            {
                CreateTabDocument(wFileName);
            }
        }
        
        private void mnuOpenFromDB_Click(object sender, EventArgs e)
        {
            
            CreateTabDocumentFromDB();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            if (ctlTabs.SelectedTab != null)
            {
                ctlTabs.TabPages.Remove(ctlTabs.SelectedTab);
            }
            if (ctlTabs.TabPages.Count == 0)
            {
                ctlTabs.Visible = false;
            }
        }
        #endregion

        #region <private methods>
        private void CloseForm()
        {
            this.Close();
        }

        private void HideForm()
        {
            if (this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void ShowForm()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            this.Activate();
        }

        private string GetFileName()
        {
            OpenFileDialog wDialog = new OpenFileDialog();
            wDialog.Filter = "Log files (*.log)|*.log|Xml files (*.xml)|*.xml";
            wDialog.Title = "Open file";

            if (wDialog.ShowDialog() != DialogResult.Cancel)
            {
                return wDialog.FileName;
            }
            return String.Empty;
        }

        private void CreateTabDocumentFromDB()
        {
            FRM_Document wForm = new FRM_Document();
            DataSet wDataSet = null;
            
            // Creación de la base de datos.
            Database wDatabase = DatabaseFactory.CreateDatabase("LogsDB");
            ConnectionStringSettings wSettings = ConfigurationManager.ConnectionStrings["LogsDB"];

            wDataSet = wDatabase.ExecuteDataSet("Logs_s");
            List<Event> wEvents = ParseDB(wDataSet);

            foreach (Event wEvent in wEvents)
            {
                wForm.AddEventLog(wEvent);
            }

            MagicControls.TabPage wTab = new MagicControls.TabPage("DB: LogsDB", wForm);
            if (ctlTabs.TabPages.Count == 0)
            {
                ctlTabs.Visible = true;
            }
            
            ctlTabs.TabPages.Add(wTab);
        }

        private void CreateTabDocument(string pFileName)
        {
            FRM_Document wForm = new FRM_Document();
            FileInfo wFile = new FileInfo(pFileName);
            List<Event> wEvents = ParseFile(wFile);


            wForm.Populate(wEvents);

            MagicControls.TabPage wTab = new MagicControls.TabPage(wFile.Name, wForm);
            if (ctlTabs.TabPages.Count == 0)
            {
                ctlTabs.Visible = true;
            }
            wTab.Tag = pFileName;
            ctlTabs.TabPages.Add(wTab);
        }

        private void RefreshTabDocument()
        {
            if (ctlTabs.SelectedTab == null) return;
            FRM_Document wForm = new FRM_Document();
            FileInfo wFile = new FileInfo(ctlTabs.SelectedTab.Tag.ToString());
            List<Event> wEvents = ParseFile(wFile);
            
            wForm.Populate(wEvents);

            MagicControls.TabPage wTab = new MagicControls.TabPage(wFile.Name, wForm);

            wTab.Tag = wFile.Name;
            ctlTabs.SelectedTab = wTab;
        }

        private List<Event> ParseDB(DataSet pLogs)
        {
            List<Event> wEvents = new List<Event>();
            Event wEvent = null;

            foreach (DataRow wRow in pLogs.Tables[0].Rows)
            {
                wEvent = new Event();
                wEvent.Id = new Guid(wRow["Id"].ToString());
                wEvent.DateAndTime = Convert.ToDateTime(wRow["DateTime"]);
                wEvent.Type = (EventType)System.Enum.Parse(typeof(EventType), wRow["Type"].ToString(), true);
                wEvent.Message = wRow["Message"].ToString();
                wEvent.Source = wRow["Source"].ToString();
                wEvent.User = wRow["User"].ToString();
                wEvent.Machine = wRow["Machine"].ToString();
                wEvents.Add(wEvent);
            }
            return wEvents;
        }

        private List<Event> ParseFile(FileInfo wFile)
        {
            try
            {
                return ParseXmlFile(wFile.FullName);
            }
            catch (Exception ex)
            {
                fwkMessageViewComponent1.Show(ex.Message);
                return null;
            }
         
        }

        private List<Event> ParseLogFile(string pFileName)
        {
            List<Event> wEvents = new List<Event>();
            Event wEvent = null;
            StreamReader wReader = new StreamReader(pFileName);
            string wLineContent = "";
            while (wReader.EndOfStream == false)
            {
                wEvent = new Event();
                wLineContent = wReader.ReadLine();
                string[] wStringSections = wLineContent.Split('|');
                wEvent.Id = new Guid(wStringSections[0].Trim().Replace("Log Id: ", ""));
                wEvent.DateAndTime = Convert.ToDateTime(wStringSections[1].Trim().Replace("Date: ", ""));
                wEvent.Type = (EventType)System.Enum.Parse(typeof(EventType), wStringSections[2].Trim().Replace("Type: ", ""), true);
                wEvent.Message = wStringSections[3].Trim().Replace("Message: ", "");
                wEvent.Source = wStringSections[4].Trim().Replace("Source: ", "");
                wEvent.User = wStringSections[5].Trim().Replace("User : ", "");
                wEvent.Machine = wStringSections[6].Trim().Replace("Machine : ", "");
                wEvents.Add(wEvent);
            }
            return wEvents;
        }

        private List<Event> ParseXmlFile(string pFileName)
        {
            List<Event> wEvents = new List<Event>();
            Event wEvent = null;
            XmlDocument wDoc = new XmlDocument();
            wDoc.Load(pFileName);
            foreach (XmlNode wNode in wDoc.SelectSingleNode("Logs").ChildNodes)
            {
                wEvent = new Event();
                wEvent.Id = new Guid(NodeAttribute.AttributeGet(wNode, "id"));
                wEvent.DateAndTime = Convert.ToDateTime(NodeAttribute.AttributeGet(wNode, "dateTime"));
                wEvent.Type = (EventType)System.Enum.Parse(typeof(EventType), NodeAttribute.AttributeGet(wNode, "type"), true);
                wEvent.Message = wNode.SelectSingleNode("Message").InnerText;
                wEvent.Source = NodeAttribute.AttributeGet(wNode, "source");
                wEvent.User = NodeAttribute.AttributeGet(wNode, "user");
                wEvent.Machine = NodeAttribute.AttributeGet(wNode, "machine");
                wEvents.Add(wEvent);
            }

            return wEvents;
        }
        #endregion

       

       
    }
}

