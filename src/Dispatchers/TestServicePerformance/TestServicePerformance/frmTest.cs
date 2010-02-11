using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BigBang.FrontEnd.Survey.Controller;
using BigBang.BackEnd.Common.BE;
using Fwk.Caching;

namespace TestServicePerformance
{

    public partial class frmTest : Form
    {
        ControllerTest Ctrl;
        RemotingWrapper _RemotingWrapper;
        
        public frmTest()
        {
            InitializeComponent();
            Ctrl = new ControllerTest();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (_RemotingWrapper == null)
            {
                MessageBox.Show("Haga clic en el boton Init");
                return;
            }
            try
            {
                
                _RemotingWrapper.MessageEvent += new CheckEven(_RemotingWrapper_MessageEvent);
                _RemotingWrapper.Start(txtXmlRequest.Text);

                dataGridView1.DataSource = _RemotingWrapper.RemoteObj.GetServicesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void _RemotingWrapper_MessageEvent(string msg, int threadNumber, double average, double totalTime)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ControllerTest.Storage.Load();
             txtObjectUri.Text= ControllerTest.Storage.StorageObject.ObjectUri;
             txtServer.Text = ControllerTest.Storage.StorageObject.Server;
             txtPort.Text =ControllerTest.Storage.StorageObject.Port;
             txtSvc.Text = ControllerTest.Storage.StorageObject.Svc;
             txtXmlRequest.Text = ControllerTest.Storage.StorageObject.XmlRequest;
             txtSvc.Text = ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Name;
             numericThread.Value = Convert.ToDecimal(ControllerTest.Storage.StorageObject.Threads);
            
            txtURL.Text = string.Concat("tcp://", ControllerTest.Storage.StorageObject.Server, ":", ControllerTest.Storage.StorageObject.Port.Trim(), @"/", ControllerTest.Storage.StorageObject.ObjectUri);
        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = string.Concat("tcp://", txtServer.Text, ":", txtPort.Text.Trim(), @"/", txtObjectUri.Text);

        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = string.Concat("tcp://", txtServer.Text, ":", txtPort.Text.Trim(), @"/", txtObjectUri.Text);
        }

        private void txtObjectUri_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = string.Concat("tcp://", txtServer.Text, ":", txtPort.Text.Trim(), @"/", txtObjectUri.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _RemotingWrapper = new RemotingWrapper();
            try
            {
                _RemotingWrapper.Init(txtURL.Text);

                dataGridView1.DataSource = _RemotingWrapper.RemoteObj.GetServicesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControllerTest.Storage.StorageObject.ObjectUri = txtObjectUri.Text;
            ControllerTest.Storage.StorageObject.Server = txtServer.Text;
            ControllerTest.Storage.StorageObject.Port = txtPort.Text;
            ControllerTest.Storage.StorageObject.Svc = txtSvc.Text ;
            ControllerTest.Storage.StorageObject.Threads = (int)numericThread.Value  ;
            ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Name=txtSvc.Text;
            ControllerTest.Storage.Save();
        }


   
        private void button1_Click_1(object sender, EventArgs e)
        {
            using (frmAssemblyExplorer f = new frmAssemblyExplorer())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    txtSvc.Text = f.SelectedServiceConfiguration.Name;
                    ControllerTest.Storage.StorageObject.SelectedServiceConfiguration = f.SelectedServiceConfiguration;
                    ControllerTest.Storage.Save();
                }
            }
        }


    }
}
