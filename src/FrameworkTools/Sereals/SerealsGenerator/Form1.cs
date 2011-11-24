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

namespace SerealsGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            
                string hash = Sereal.GetMd5Hash(txtImput.Text);



                txtMD5Value.Text = hash;


            
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            txtKeyValue.Text = Fwk.Security.Cryptography.FwkSymetricAlg.GetNewK(); 
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyValue.Text))
            { MessageBox.Show("Generate encryptation key"); txtKeyValue.Focus(); return; }
            try
            {
                Fwk.Security.Cryptography.FwkSymetricAlg gen = new Fwk.Security.Cryptography.FwkSymetricAlg(txtKeyValue.Text);
                txtEncryptedValue.Text = gen.Encrypt(txtValueToEncrypt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtKeyValue.Focus();
            }
            
        }

        private void btnValidateMD5_Click(object sender, EventArgs e)
        {
            if (Sereal.VerifyMd5Hash(txtImput.Text, txtMD5Value.Text))
            {
                MessageBox.Show("Is valid");
            }
            else
                MessageBox.Show("Is invalid");
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            DateTime f  = dateTimePicker1.Value;

            txtValueToEncrypt.Text = string.Concat(f.Day,"|",f.Month,"|",f.Year);
        }

     
        


    }
}
