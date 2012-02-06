using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Fwk.UI.Controls.Wizard.BE;

namespace Fwk.UI.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textFindContainer1_OnFindClick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StringBuilder wStrr = new StringBuilder();

            for (int i = 1; i <= 26; i++)
            {
                wStrr.AppendLine(" Hola " + i);
            }

            Fwk.UI.Controls.SimpleMessageView.Show(wStrr.ToString(), "Pelsoft", MessageBoxButtons.YesNo, Fwk.UI.Common.MessageBoxIcon.Question);
        }

        private void ButtonBase1_Click(object sender, EventArgs e)
        {
            simpleMessageViewComponent1.Show("¿Desea abrir el archivo ABCDEFGHIJASASLKDJSAASDASDFGHKSDJLAFHKSLADF??");
        }

        private void exportToolBar1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonBase2_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("¿Desea abrir el archivo ABCDEFGHIJASASLKDJSAASDASDFGHKSDJLAFHKSLADF?", "Exportar a...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void textEdit1_Validating(object sender, CancelEventArgs e)
        {

        }



        private void textBox1_Validating_1(object sender, CancelEventArgs e)
        {

        }

        private void ButtonBase3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ColumnsMappingBEList wList = new ColumnsMappingBEList();
            //ColumnsMappingBE wBE = new ColumnsMappingBE();
            //wBE.ColumnTarget = "Test1";
            //wList.Add(wBE);
            //wBE = new ColumnsMappingBE();
            //wBE.ColumnTarget = "Test2";
            //wList.Add(wBE);


            //importDataFromDataOrigin1.ColumnsToMap = wList;
            //importDataFromDataOrigin1.Show();
        }
    }
}
