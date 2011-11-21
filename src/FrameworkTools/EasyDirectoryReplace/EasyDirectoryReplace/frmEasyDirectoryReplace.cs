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
         
            if(_Store.ReplacePatternDefault != null)
                replacePatternControl1.Populate(_Store.ReplacePatternDefault);
           
            PopulatePanel();

   
            txtRuta1.Text = _Store.Source;
            txtRuta2.Text = _Store.Destination;
         
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
                //cargo todos los archivos del origen
                String[] wFiles = Directory.GetFiles(txtRuta1.Text, "*", SearchOption.AllDirectories);
                //cargo todos los directorios del origen
                String[] wDirectories = Directory.GetDirectories(txtRuta1.Text, "*", SearchOption.AllDirectories);


                progressBar1.Maximum = wFiles.Length + wDirectories.Length + 1;
                progressBar1.Visible = true;
                FillReplacePaternList(true);
                //Renombro a nivel de archivo y carpetas
                //RenameFilesAndDirectories(txtRuta1.Text, txtRuta2.Text, "*", txtOldText.Text, txtNewText.Text, chkReplaceContentFile.Checked);
                RenameFilesAndDirectories(txtRuta1.Text, txtRuta2.Text, "*",_Store.ReplacePatternList);

                progressBar1.Value = 0;
                progressBar1.Visible = false;

                DirectoryInfo Sourse = new DirectoryInfo(txtRuta1.Text);

                string newDir = ReplaceNameContainsPattern(txtRuta2.Text, _Store.ReplacePatternList);
                //System.Diagnostics.Process.Start("explorer.exe", Path.Combine(txtRuta2.Text, Sourse.Name.Replace(txtOldText.Text, txtNewText.Text)));
                System.Diagnostics.Process.Start("explorer.exe", Path.Combine(txtRuta2.Text, newDir));
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
        /// <param name="source">Ruta de origen</param>
        /// <param name="destination">Ruta destino</param>
        /// <param name="searchPattern"></param>
        /// <param name="list"></param>
        void RenameFilesAndDirectories(string source, string destination, string searchPattern ,ReplacePaternList list)
        {
            #region Declarations
            FileInfo[] wFiles = new DirectoryInfo(source).GetFiles(searchPattern, SearchOption.TopDirectoryOnly);
            DirectoryInfo[] wDirectories = new DirectoryInfo(source).GetDirectories(searchPattern, SearchOption.TopDirectoryOnly);

            string newDirectoryName = ReplaceNameContainsPattern(source, list);

            DirectoryInfo destinationDirectoryInfo = new DirectoryInfo(newDirectoryName);
            #endregion

            Directory.CreateDirectory(Path.Combine(destination, destinationDirectoryInfo.Name));

            foreach (FileInfo file in wFiles)
            {
                progressBar1.Value++;
                StringBuilder strErrors = null;
                ProcessFile(file, list, Path.Combine(destination, destinationDirectoryInfo.Name),  out strErrors);
            }
            //por cada subdirectorio
            foreach (DirectoryInfo directoryInfo in wDirectories)
            {
                RenameFilesAndDirectories(directoryInfo.FullName, Path.Combine(destination, destinationDirectoryInfo.Name), searchPattern,
                                          list);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="oldText"></param>
        /// <param name="newText"></param>
        /// <param name="destination"></param>
        void ProcessFile(FileInfo file, ReplacePaternList list, String destination, out StringBuilder strErrors)
        {
            #region Declarations
            strErrors = new StringBuilder();
            String text, newFileName;
            #endregion

            newFileName = ReplaceNameContainsPattern(file.Name, list);

            try
            {
                if (extencionsListToReplace.Contains(file.Extension))
                {
                    text = FileFunctions.OpenTextFile(file.FullName);
                    text = ReplaceContent(text, list);
                    FileFunctions.SaveTextFile(Path.Combine(destination, newFileName), text, false);
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

        string ReplaceNameContainsPattern(string fileName,ReplacePaternList list )
        {
            foreach (ReplacePattern pattern in list)
            {
               if( fileName.Contains(pattern.TextOld))
                fileName = fileName.Replace(pattern.TextOld, pattern.TextNew);
            }

            return fileName;
        }

        string ReplaceContent(string text, ReplacePaternList list)
        {
            foreach (ReplacePattern pattern in list)
            {
                if(pattern.ReplaceContent)
                    text = text.Replace(pattern.TextOld, pattern.TextNew);
            }

            return text;
        }
        #endregion

       

        private void frmEasyReplace_FormClosing(object sender, FormClosingEventArgs e)
        {

            _Store.Source = txtRuta1.Text;
            _Store.Destination = txtRuta2.Text;

            FillReplacePaternList(false);

            Store.Save(_Store);
        }

        /// <summary>
        /// Llena el store
        /// </summary>
        void FillReplacePaternList(bool addDefaultToList)
        {
            if (_Store.ReplacePatternList == null) return;
            _Store.ReplacePatternList.Clear();    
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                _Store.ReplacePatternList.Add(((ReplacePatternControl)c).ReplacePattern);
            }
            if (addDefaultToList)
                _Store.ReplacePatternList.Add(replacePatternControl1.ReplacePattern);
            else
                _Store.ReplacePatternDefault = replacePatternControl1.ReplacePattern;

        }
        void PopulatePanel()
        {
            if (_Store.ReplacePatternList == null) return;
            foreach (ReplacePattern wReplacePattern in _Store.ReplacePatternList)
            {
                ReplacePatternControl wReplacePatternControl = new ReplacePatternControl();
  
                wReplacePatternControl.Populate(wReplacePattern);
               
                AddtoPanel(wReplacePatternControl, flowLayoutPanel1);
            }
        }



        public  void AddtoPanel(ReplacePatternControl pControlToAdd, Control pContainerControl)
        {

            pControlToAdd.OnRemoveEvent += new EventHandler(replacePatternControl1_OnRemoveEvent);
            pContainerControl.Controls.Add(pControlToAdd);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ReplacePatternControl wReplacePatternControl = new ReplacePatternControl();

            
            AddtoPanel(wReplacePatternControl, flowLayoutPanel1);
        }

      

        private void replacePatternControl1_OnRemoveEvent(object sender, EventArgs e)
        {
            ((ReplacePatternControl)sender).OnRemoveEvent -= new EventHandler(replacePatternControl1_OnRemoveEvent);
            flowLayoutPanel1.Controls.Remove((ReplacePatternControl)sender);

        }
    }
}