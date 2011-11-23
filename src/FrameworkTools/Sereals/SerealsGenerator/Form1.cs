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

                //if (VerifyMd5Hash(md5Hash, source, hash))
                //{
                //    Console.WriteLine("The hashes are the same.");
                //}
                //else
                //{
                //    Console.WriteLine("The hashes are not same.");
                //}

            
        }

        


    }
}
