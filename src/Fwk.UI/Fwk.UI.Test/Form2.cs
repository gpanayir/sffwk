using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Controls;

namespace Fwk.UI.Test
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!textBox1.ValidateValue())
            {
                dxErrorProvider1.SetError(textBox1, textBox1.ErrorText);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (!textBox3.ValidateValue())
            {
                dxErrorProvider1.SetError(textBox3, textBox3.ErrorText);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fwk.UI.Controls.Wizard.BE.ColumnsMappingBEList wList = new Fwk.UI.Controls.Wizard.BE.ColumnsMappingBEList();
            Fwk.UI.Controls.Wizard.BE.ColumnsMappingBE wBE = new Fwk.UI.Controls.Wizard.BE.ColumnsMappingBE();
            wBE.ColumnTarget = "Test1";
            wList.Add(wBE);
            wBE = new Fwk.UI.Controls.Wizard.BE.ColumnsMappingBE();
            wBE.ColumnTarget = "Test2";
            wList.Add(wBE);


            importDataFromDataOrigin1.ColumnsToMap = wList;
            importDataFromDataOrigin1.WizardComplete += new Fwk.UI.Controls.Wizard.ImportDataFromDataOrigin.ImportDataFromDataOriginEventHandler(importDataFromDataOrigin1_WizardComplete);
            importDataFromDataOrigin1.Show();
            
        }

        void importDataFromDataOrigin1_WizardComplete(object sender, Fwk.UI.Controls.Wizard.FRM_Wizard.ImportEventArgs e)
        {
            if (e.DataToImport != null)
            {
                importDataFromDataOrigin1.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            string Message = "importDataFromDataOrigin1.WizardComplete += new Fwk.UI.Controls.Wizard.ImportDataFromDataOrigin.ImportDataFromDataOriginEventHandler(importDataFromDataOrigin1_WizardComplete); importDataFromDataOrigin1.WizardComplete += new Fwk.UI.Controls.Wizard.ImportDataFromDataOrigin.ImportDataFromDataOriginEventHandler(importDataFromDataOrigin1_WizardComplete);";
          

            Fwk.UI.Controls.MessageView.Show(Message, "Error de conexión", MessageBoxButtons.OK, Fwk.UI.Common.MessageBoxIcon.Error);
        }
    }
}
