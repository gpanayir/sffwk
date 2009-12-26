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

        public void BeforeOpeningFile(EnvDTE.ProjectItem projectItem)
        {
            throw new NotImplementedException();
        }

        public void ProjectFinishedGenerating(EnvDTE.Project project)
        {
            throw new NotImplementedException();
        }

        public void ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem)
        {
            throw new NotImplementedException();
        }

        public void RunFinished()
        {
            throw new NotImplementedException();
        }

        public void RunStarted(object automationObject,
        Dictionary<string, string> replacementsDictionary,
        WizardRunKind runKind, object[] customParams)
        {

            try
            {


                InitializeWizard(replacementsDictionary);




                if (inputForm.ShowDialog() == DialogResult.Cancel)
                { return; }


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

        private void InitializeWizard(Dictionary<string, string> pReplacementsDictionary)
        {
            inputForm = new FrmBusinessComponents();
            //inputForm.LongModuleName = GetLongModuleName(pReplacementsDictionary);


           
            inputForm.ProjectName = pReplacementsDictionary["$projectname$"].ToString();
            
        }


        public bool ShouldAddProjectItem(string filePath)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
