using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CodeGenerator.Back;
namespace CodeGenerator
{
    public partial class ConnectionForm : Form
    {
        public Boolean ConnectionOK
        {
            get { return this.cnnDataBaseForm1.ConnectionOK; }
          
        }
        public Boolean CnnStringChange
        {
            get { return this.cnnDataBaseForm1.CnnStringChange; }

        }
        public string ServerName
        {
            get { return this.cnnDataBaseForm1.Connection.DataSource; }
        }
        public string DataBaseName
        {
            get { return this.cnnDataBaseForm1.Connection.InitialCatalog; }
        }

        public string UserName
        {
            get { return this.cnnDataBaseForm1.Connection.User; }
        }
        public ConnectionForm()
        {
            InitializeComponent();
            this.cnnDataBaseForm1.InitialiceControl();
        }

       

        private void cnnDataBaseForm1_CancelEvent()
        {
            this.Close();
        }

        private void cnnDataBaseForm1_AceptEvent(bool ConnectionOK)
        {

            if (ConnectionOK)
                this.Close();

        }

        private void cnnDataBaseForm1_Load(object sender, EventArgs e)
        {

        }
    }
}