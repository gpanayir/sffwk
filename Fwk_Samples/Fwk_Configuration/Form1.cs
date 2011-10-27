using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk_Configuration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Fwk.Configuration.ConfigurationManager.GetProperty("FuntionalsExceptions", "Excepcion1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Fwk.Configuration.ConfigurationManager.GetProperty("proveedor1", "FuntionalsExceptions", "Excepcion2");
            
            
        }

      

        private void button3_Click(object sender, EventArgs e)
        {


            string color = Fwk.Configuration.ConfigurationManager.GetProperty("proveedor2", "Colores", "Rojo");
            textBox2.BackColor = Color.FromName(color);

        }


    }
}
