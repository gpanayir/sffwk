using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;
using System.IO;
using Fwk.CodeGenerator;

namespace Fwk.Wizard
{
    public class wizProjects : IWizard
    {
        frmBackeçEndProjects inputForm;
        static string fwkprojectname = string.Empty;
        static string destinationdirectory = string.Empty;
        static bool  useStatics = true;
        #region IWizard Members

        void IWizard.BeforeOpeningFile(EnvDTE.ProjectItem projectItem)
        {
            
        }

        void IWizard.ProjectFinishedGenerating(EnvDTE.Project project)
        {

            //if (project == null)
            //{
            //  DirectoryInfo dd = new System.IO.DirectoryInfo(destinationdirectory);
             
            
            //}

        }

        void IWizard.ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem)
        {
            
        }

        void IWizard.RunFinished()
        {
         
                if (useStatics)
                {
                    string libs = string.Concat(destinationdirectory, @"..\..\..\", @"StaticLibs");
                    string statics  = string.Concat(destinationdirectory, @"..\..\..\", @"builds");

                    if (!System.IO.Directory.Exists(statics))
                        System.IO.Directory.CreateDirectory(statics);
                    if (!System.IO.Directory.Exists(libs))
                        System.IO.Directory.CreateDirectory(libs);
                }
            
        }
        bool _Cancel = true;
        void IWizard.RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {

            try
            {


                InitializeWizard(replacementsDictionary);

                if (runKind == WizardRunKind.AsMultiProject)
                {
                    if (inputForm.ShowDialog() == DialogResult.Cancel)
                    { return; }
                    _Cancel = false;
                    fwkprojectname = inputForm.ProjectName;
                    useStatics = inputForm.UseStatics;
                    destinationdirectory = replacementsDictionary["$destinationdirectory$"];
                }



                //Reemplazo valores de parametros

                if (!replacementsDictionary.ContainsKey(CommonConstants.CONST_FwkProject_NAME))
                    replacementsDictionary.Add(CommonConstants.CONST_FwkProject_NAME, fwkprojectname);
                else

                    replacementsDictionary[CommonConstants.CONST_FwkProject_NAME] = fwkprojectname;

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        bool IWizard.ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        #endregion

        private void InitializeWizard(Dictionary<string, string> pReplacementsDictionary)
        {
            inputForm = new frmBackeçEndProjects();
        



            inputForm.ProjectName = pReplacementsDictionary["$projectname$"].ToString();

        }
    }
}
