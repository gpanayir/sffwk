using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;

namespace Fwk.Wizard
{
    public class wizProjects : IWizard
    {
        FrmBusinessComponents inputForm; 
      

        #region IWizard Members

        void IWizard.BeforeOpeningFile(EnvDTE.ProjectItem projectItem)
        {
            
        }

        void IWizard.ProjectFinishedGenerating(EnvDTE.Project project)
        {
           
        }

        void IWizard.ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem)
        {
            
        }

        void IWizard.RunFinished()
        {
            
        }

        void IWizard.RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {

            try
            {


                InitializeWizard(replacementsDictionary);


               

                if (inputForm.ShowDialog() == DialogResult.Cancel)
                { return; }
           
                replacementsDictionary["$projectname$"] = inputForm.ProjectName;
              
                MessageBox.Show(replacementsDictionary["$projectname$"].ToString());
    

                // Add custom parameters.
                //replacementsDictionary.Add("$Company$", inputForm.Company);
                //replacementsDictionary.Add("$App$", inputForm.App);
                //replacementsDictionary.Add("$Module$", inputForm.Module);

                //Reemplazo valores de parametros
                //if (replacementsDictionary.ContainsKey("$BackendNamespace$"))
                //    replacementsDictionary["$BackendNamespace$"] = inputForm.BackendNamespaceTemplate;

                ////Ej ElMercurio.SCA.Common.Entorno.Cobertura.InterfaceServices
                //if (replacementsDictionary.ContainsKey("$CommonNamespace$"))
                //    replacementsDictionary["$CommonNamespace$"] = inputForm.CommonNamespaceTemplate;




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
            inputForm = new FrmBusinessComponents();
        



            inputForm.ProjectName = pReplacementsDictionary["$projectname$"].ToString();

        }
    }
}
