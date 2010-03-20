using System;
using System.IO;
using System.Windows.Forms;
using Fwk.HelperFunctions;
using System.Text;
using System.Collections.Generic;
using Fwk.Bases.FrontEnd.Controls;
namespace EasyDirectoryReplace
{
    public partial class frmEasyReplace : Form
    {
        private Store _Store = new Store();

        private static List<String> extencionsListToReplace = new List<string>();
        public frmEasyReplace()
        {
            InitializeComponent();
            txtNewText.Text = _Store.NewText;
            txtOldText.Text = _Store.OldText;
            txtRuta1.Text = _Store.Source;
            txtRuta2.Text = _Store.Destination;
            chkReplaceContentFile.Checked =_Store.ReplaceContentFile  ;
            extencionsListToReplace.Add(".cs");
            extencionsListToReplace.Add(".vb");
            extencionsListToReplace.Add(".cs");
            extencionsListToReplace.Add(".sln");
            extencionsListToReplace.Add(".xml");
            extencionsListToReplace.Add(".txt");
            extencionsListToReplace.Add(".config");
            extencionsListToReplace.Add(".vspscc");
            extencionsListToReplace.Add(".vbproj");
            extencionsListToReplace.Add(".csproj");
            

        }




        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String[] wFiles = Directory.GetFiles(txtRuta1.Text, "*", SearchOption.AllDirectories);
                String[] wDirectories = Directory.GetDirectories(txtRuta1.Text, "*", SearchOption.AllDirectories);
                progressBar1.Maximum = wFiles.Length + wDirectories.Length + 1;
                progressBar1.Visible = true;
                RenameFilesAndDirectories(txtRuta1.Text, txtRuta2.Text, "*", txtOldText.Text, txtNewText.Text, chkReplaceContentFile.Checked);
                progressBar1.Value = 0;
                progressBar1.Visible = false;

                DirectoryInfo Sourse = new DirectoryInfo(txtRuta1.Text);


                System.Diagnostics.Process.Start("explorer.exe", Path.Combine(txtRuta2.Text, Sourse.Name.Replace(txtOldText.Text, txtNewText.Text)));
            }
            catch (Exception ex)
            {
                FwkMessageView.Show(ex, "Error", MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
            }
        }

        private void btnOpenSource_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtRuta1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnOpenDest_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtRuta2.Text = folderBrowserDialog1.SelectedPath;
        }


        #region Privates
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <param name="searchPattern"></param>
        /// <param name="oldText"></param>
        /// <param name="newText"></param>
        void RenameFilesAndDirectories(string source, string destination, string searchPattern, string oldText, string newText,bool replaceContent)
        {
            #region Declarations
            FileInfo[] wFiles = new DirectoryInfo(source).GetFiles(searchPattern, SearchOption.TopDirectoryOnly);
            DirectoryInfo[] wDirectories = new DirectoryInfo(source).GetDirectories(searchPattern, SearchOption.TopDirectoryOnly);
            DirectoryInfo destinationDirectoryInfo = new DirectoryInfo(source.Replace(oldText, newText));
            #endregion

            Directory.CreateDirectory(Path.Combine(destination, destinationDirectoryInfo.Name));

            foreach (FileInfo file in wFiles)
            {
                progressBar1.Value++;
                StringBuilder strErrors = null ;
                ProcessFile(file, oldText, newText, Path.Combine(destination, destinationDirectoryInfo.Name), replaceContent,out strErrors);
            }
            foreach (DirectoryInfo directoryInfo in wDirectories)
            {
                RenameFilesAndDirectories(directoryInfo.FullName, Path.Combine(destination, destinationDirectoryInfo.Name), searchPattern,
                                          oldText, newText, replaceContent);
            }

        }
        
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="oldText"></param>
        /// <param name="newText"></param>
        /// <param name="destination"></param>
        void ProcessFile(FileInfo file, string oldText, string newText, String destination, Boolean replaceContent,out StringBuilder strErrors)
        {
            #region Declarations
             strErrors = new StringBuilder () ;
            String text, newFileName;
          
        
            
            newFileName = file.Name.Replace(oldText, newText);
            #endregion
            try
            {


                if (replaceContent)
                {
                    if (extencionsListToReplace.Contains(file.Extension))
                    {
                        text = FileFunctions.OpenTextFile(file.FullName).Replace(oldText, newText);
                        FileFunctions.SaveTextFile(Path.Combine(destination, newFileName), text, false);
                    }
                    else
                    {
                        file.CopyTo(Path.Combine(destination, newFileName));
                    }
                }
                else
                {
                    file.CopyTo(Path.Combine(destination, newFileName));
                }
            }
            catch (System.IO.IOException ex)
            {
                strErrors.AppendLine(ex.Message);
            }
        }

        #endregion

       

        private void frmEasyReplace_FormClosing(object sender, FormClosingEventArgs e)
        {

            _Store.Source = txtRuta1.Text;
            _Store.Destination = txtRuta2.Text;
            _Store.OldText = txtOldText.Text;
            _Store.NewText = txtNewText.Text;
            _Store.ReplaceContentFile = chkReplaceContentFile.Checked;
            Store.Save(_Store);
        }
    }
}