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

        private void button1_Click(object sender, EventArgs e)
        {
            ParamCampaingsList wParamCampaingsList = Ctrl.SearchPredeterminateValueTypes();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             txtURL.Text = string.Concat("tcp://", txtServer.Text, ":", txtPort.Text.Trim(), @"/", txtObjectUri.Text);
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
            _RemotingWrapper.Init(txtURL.Text);

            dataGridView1.DataSource = _RemotingWrapper.RemoteObj.GetServicesList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
