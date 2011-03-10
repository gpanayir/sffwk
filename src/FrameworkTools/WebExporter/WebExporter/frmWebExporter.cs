using System;
using System.IO;
using System.Windows.Forms;
using Fwk.HelperFunctions;
using System.Text;
using System.Collections.Generic;
using Fwk.Bases.FrontEnd.Controls;
using System.Linq;
namespace WebExporter
{
    public partial class frmWebExporter : Form
    {
        private Store _Store = new Store();
       
        private static List<String> extencionsListToExport = new List<string>();
        public frmWebExporter()
        {
            InitializeComponent();
         
 
           
     

   
            txtRuta1.Text = _Store.Source;
            txtRuta2.Text = _Store.Destination;

            extencionsListToExport.Add(".html");
            extencionsListToExport.Add(".ascx");
            extencionsListToExport.Add(".aspx");
            extencionsListToExport.Add(".html");
            extencionsListToExport.Add(".css");
            extencionsListToExport.Add(".js");
            extencionsListToExport.Add(".jpg");
            extencionsListToExport.Add(".jpeg");
            extencionsListToExport.Add(".JPG");
            extencionsListToExport.Add(".JPEG");
            extencionsListToExport.Add(".png");
            extencionsListToExport.Add(".gif");

            extencionsListToExport.Add(".config");
            extencionsListToExport.Add(".xml");
            extencionsListToExport.Add(".master");

            extencionsListToExport.Add(".htc");
            extencionsListToExport.Add(".dll");
      
         
        }




        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder strErrors = null;
            try
            {
                //cargo todos los archivos del origen
                String[] wFiles = Directory.GetFiles(txtRuta1.Text, "*", SearchOption.AllDirectories);
                //cargo todos los directorios del origen
                String[] wDirectories = Directory.GetDirectories(txtRuta1.Text, "*", SearchOption.AllDirectories);
              

                progressBar1.Maximum = wFiles.Length + wDirectories.Length + 1;
                progressBar1.Visible = true;

                Export(txtRuta1.Text, txtRuta2.Text, "*", out strErrors);
           
                progressBar1.Value = 0;
                progressBar1.Visible = false;




                System.Diagnostics.Process.Start("explorer.exe", txtRuta2.Text);
            }
            catch (Exception ex)
            {
                FwkMessageView.Show(ex, "Error", MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
            }
        }

        private void btnOpenSource_Click(object sender, EventArgs e)
        {

           folderBrowserDialog1.SelectedPath = txtRuta1.Text;
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtRuta1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnOpenDest_Click(object sender, EventArgs e)
        {

            folderBrowserDialog1.SelectedPath = txtRuta2.Text;
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtRuta2.Text = folderBrowserDialog1.SelectedPath;
            }
        }


        #region Privates

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source">Ruta de origen</param>
        /// <param name="destination">Ruta destino</param>
        /// <param name= "searchPatter">ej "*"</param>
        void Export(string source, string destination,string searchPattern,out StringBuilder strErrors)
        {
            strErrors = new StringBuilder();
            //Validaciones sobre el directorio
            if (destination.EndsWith(".svn"))
                return ;
         
            #region Declarations
          
            DirectoryInfo[] sourceDirectories = new DirectoryInfo(source).GetDirectories(searchPattern, SearchOption.TopDirectoryOnly);
       
            #endregion
            //Crear directorio en destino si no existe
            if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);
             FileInfo[] wFiles= new DirectoryInfo(source).GetFiles(searchPattern, SearchOption.TopDirectoryOnly);
             var filesFiltereds = from f in wFiles where extencionsListToExport.Contains(f.Extension) select f;

             //wFiles.Where<FileInfo>(p=> extencionsListToExport.Contains(p.Extension));

             foreach (FileInfo file in filesFiltereds)
             {
                 //if (extencionsListToExport.Contains(file.Extension))
                 //{
                     try
                     {
                         file.CopyTo(Path.Combine(destination, file.Name),true);
                         progressBar1.Value++;
                     }

                     catch (System.IO.IOException ex)
                     {
                         strErrors.AppendLine(ex.Message);
                     }

                 //}
             }
          


           
            //Llamr recursivamente los subdirectorios
            foreach (DirectoryInfo subDir in sourceDirectories)
            {
                Export(subDir.FullName, Path.Combine(destination, subDir.Name), "*", out strErrors);
            }

           

           
        }


        void ClearDest( string destination)
        {
            DirectoryInfo[] destDirectories = new DirectoryInfo(destination).GetDirectories("*", SearchOption.TopDirectoryOnly);

        }
        #endregion

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEasyReplace_FormClosing(object sender, FormClosingEventArgs e)
        {

            _Store.Source = txtRuta1.Text;
            _Store.Destination = txtRuta2.Text;

       
            Store.Save(_Store);
        }

        private void txtRuta1_TextChanged(object sender, EventArgs e)
        {
            _Store.Source = txtRuta1.Text;
         


            Store.Save(_Store);
        }

        private void txtRuta2_TextChanged(object sender, EventArgs e)
        {
            _Store.Destination = txtRuta2.Text;



            Store.Save(_Store);
        }

        private void txtErrors_TextChanged(object sender, EventArgs e)
        {

        }

      



      
     
    }
}