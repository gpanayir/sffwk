using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Configuration;

namespace InstanceServiceSetting
{
    public partial class Form1 : Form
    {
        System.Configuration.Configuration configuration = null;
        string _AssemblyPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            open(string.Empty);
          

        }

        
        private void txtFileName_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(System.IO.Path.GetFileName(txtFullFileName.Text)))
            {
                open(txtFullFileName.Text);
            }
        }
        void open(string wInitialDirectory )
        {
            OpenFileDialog wSchemaDialog = new OpenFileDialog();
            wSchemaDialog.DefaultExt = "exe";
            wSchemaDialog.CheckFileExists = true;

            wSchemaDialog.Filter = "DLL Files (*.exe)|*.exe|All Files (*.*)|*.*";
            wSchemaDialog.ShowReadOnly = true;
            if (!string.IsNullOrEmpty(wInitialDirectory))
            {
                if (Directory.Exists(wInitialDirectory))
                    wSchemaDialog.InitialDirectory = wInitialDirectory;
            }
            if (wSchemaDialog.ShowDialog() == DialogResult.OK)
            {
                _AssemblyPath = wSchemaDialog.FileName;

           
                LoadAssembly();
            }
        }
        void LoadAssembly()
        {

            try
            {
                
                txtFileName.Text = System.IO.Path.GetFileName(_AssemblyPath);
                //txtFullFileName.Text = _AssemblyPath;
                Assembly wAssembly = Assembly.LoadFrom(_AssemblyPath);
               
                bool contain = false;
                bool containConfig = false;
                bool containConfigAppSetting = false;
                foreach (Type wAssemblyClass in wAssembly.GetTypes())
                {
                    if (wAssemblyClass.BaseType != null)
                    {
                        if (wAssemblyClass.BaseType.Name.Contains("ServiceBase"))
                        {
                            contain = true;
                            break;
                        }
                    }
                }


                if (File.Exists(string.Concat(_AssemblyPath + ".config")))
                {
                    containConfig = true;
                    ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                    map.ExeConfigFilename = string.Concat(_AssemblyPath + ".config");
                    configuration = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                    foreach (KeyValueConfigurationElement o in configuration.AppSettings.Settings)
                    {
                        if (o.Key.Equals("ServiceName"))
                        {
                            txtServiceName.Text = o.Value;
                            containConfigAppSetting = true;
                        }
                    }
                }
                else
                {
                    lblError.Text = "The *.exe.config file was not found";
                }

                if (containConfig && !containConfigAppSetting)
                {
                    KeyValueConfigurationElement newK = new KeyValueConfigurationElement("ServiceName", "Generated svc name");
                    configuration.AppSettings.Settings.Add(newK);
                    txtServiceName.Text = newK.Value;
                    configuration.Save(ConfigurationSaveMode.Modified);
                }
                lblError.Visible = contain == false || containConfig == false;
                txtServiceName.Enabled = btnOk.Enabled = contain;
            }
            catch (System.Reflection.ReflectionTypeLoadException rx)
            {
                MessageBox.Show(rx.Message);

            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServiceName.Text))
            {
                
                MessageBox.Show("Service name empty");
                txtServiceName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(_AssemblyPath))
            {
                
                MessageBox.Show("Please select an service .exe file");
                btnOpenFile.Focus();
                return;
            }
            string path = System.IO.Path.GetDirectoryName(_AssemblyPath);
            string exeFile = System.IO.Path.GetFileName(_AssemblyPath);
            try
            {
                SaveTextFile(System.IO.Path.Combine(path, "install.bat"), String.Format("installutil {0} \r\npause", exeFile));
                SaveTextFile(System.IO.Path.Combine(path, "UNinstall.bat"), String.Format("installutil {0} -u\r\npause", exeFile));

                SaveTextFile(System.IO.Path.Combine(path, "StartService.bat"), String.Format("net start {0} \r\npause", txtServiceName.Text.Trim()));
                SaveTextFile(System.IO.Path.Combine(path, "StopService.bat"), String.Format("net stop {0} -u\r\npause", txtServiceName.Text.Trim()));

                foreach (KeyValueConfigurationElement o in configuration.AppSettings.Settings)
                {
                    if (o.Key.Equals("ServiceName"))
                    {
                        o.Value = txtServiceName.Text;
                    }
                }
                configuration.Save(ConfigurationSaveMode.Modified);
                MessageBox.Show("The service name was configured successfully ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void SaveTextFile(string pFileName, string pContent)
        {
            using (StreamWriter sw = new StreamWriter(pFileName, false))
            {
                sw.Write(pContent);
                sw.Close();
            }
        }
        /// <summary>
        /// Abre un archivo de texto
        /// </summary>
        /// <param name="pFileName">Nombre completo del archivo</param>
        /// <returns></returns>
        string OpenTextFile(string pFileName)
        {
            using (StreamReader sr = File.OpenText(pFileName))
            {
                string retString = sr.ReadToEnd();
                sr.Close();

                return retString;
            }

        }

      
       
    }
}
