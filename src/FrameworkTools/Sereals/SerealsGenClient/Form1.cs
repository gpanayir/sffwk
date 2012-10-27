using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Sereals;
using System.Management;
using Fwk.Bases;

namespace SerealsGenClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
        }

   

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            txtKeyValue.Text = Fwk.Security.Cryptography.FwkSymetricAlg.GetNewK(); 
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyValue.Text))
            {
                MessageBox.Show("Generate encryptation key");
                txtKeyValue.Focus(); return;
            }
            try
            {
                Fwk.Security.Cryptography.FwkSymetricAlg gen = new Fwk.Security.Cryptography.FwkSymetricAlg(txtKeyValue.Text);

                if (!chkDrivers0.Checked && !chlDateTime.Checked)
                {
                    MessageBox.Show("Seleccione almenos un tipo de entrada");
                    return;
                }
                if (chkDrivers0.Checked && chlDateTime.Checked)
                {
                    txtEncryptedValue.Text = gen.Encrypt(string.Concat(txtNroSerie.Text.Trim(), "$", txtDate.Text.Trim()));
                    return;
                }
                if (chkDrivers0.Checked)
                {
                    txtEncryptedValue.Text = gen.Encrypt(txtNroSerie.Text.Trim());
                    return;
                }
                if (chlDateTime.Checked)
                {
                    txtEncryptedValue.Text = gen.Encrypt(txtDate.Text.Trim());
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtKeyValue.Focus();
            }
            
        }

        


         void init()
        {
            txtNroSerie.Text = Fwk.HelperFunctions.EnvironmentFunctions.GetDriverSerealNumber();
        }

         private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
         {
             DateTime f = dateTimePicker1.Value;

             txtDate.Text = string.Concat(f.Day, "|", f.Month, "|", f.Year);
         }





       

    }

   
}
