﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace Fwk.Security.Cryptography.Test
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void btnKey_Click(object sender, EventArgs e)
        {


            txtKey.Text = SymetricCypherFactory.GenNewKey();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
      
            txtCifrado.Text = SymetricCypherFactory.Cypher().Encrypt(txtNoCifrado.Text);


        }

        private void btnDEncrypt_Click(object sender, EventArgs e)
        {
  
            //Usa el encriptador por defecto configurado
            txtValorOriginal.Text = SymetricCypherFactory.Cypher().Dencrypt(txtCifrado.Text);
        }
    }
}
