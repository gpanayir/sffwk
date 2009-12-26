using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TemplateWizard;
using System.Windows.Forms;

namespace Fwk.Wizard
{
    public class wizEntityItem : IWizard
    {
        frmWizEntity_1 inputForm;
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

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            InitializeWizard(replacementsDictionary);


            if (inputForm.ShowDialog() == DialogResult.Cancel)
            { return; }


            // Add custom parameters.
            replacementsDictionary.Add("$$", inputForm.SolutionName);


            //replacementsDictionary.Add("$Module$", inputForm.Module);


            

        }

        private void InitializeWizard(Dictionary<string, string> replacementsDictionary)
        {
            inputForm = new frmWizEntity_1();
            
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
