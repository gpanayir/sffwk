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
        FwkSimpleStorageBase<Store> _Storage = new FwkSimpleStorageBase<Store>();
        public frmTest()
        {
            InitializeComponent();
            Ctrl = new ControllerTest();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParamCampaingsList wParamCampaingsList = Ctrl.SearchPredeterminateValueTypes();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            _Storage.Load();
             txtObjectUri.Text= _Storage.StorageObject.ObjectUri;
             txtServer.Text = _Storage.StorageObject.Server;
             txtPort.Text =_Storage.StorageObject.Port;

            txtURL.Text = string.Concat("tcp://", _Storage.StorageObject.Server, ":", _Storage.StorageObject.Port.Trim(), @"/", _Storage.StorageObject.ObjectUri);
        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = string.Concat("tcp://", txtServer.Text, ":", txtPort.Text.Trim(), @"/", txtObjectUri.Text);

        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = string.Concat("tcp://", txtServer.Text, ":", txtPort.Text.Trim(), @"/,", txtObjectUri.Text);
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
            _Storage.StorageObject.ObjectUri = txtObjectUri.Text;
            _Storage.StorageObject.Server = txtServer.Text;
            _Storage.StorageObject.Port = txtPort.Text;

            _Storage.Save();
        }
    }
}
