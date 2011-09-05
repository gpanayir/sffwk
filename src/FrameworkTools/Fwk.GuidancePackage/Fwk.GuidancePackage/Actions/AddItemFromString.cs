#region Using Directives

using System;
using Microsoft.Practices.ComponentModel;
using Microsoft.Practices.RecipeFramework;


using EnvDTE;
using System.IO;
using System.Text;

#endregion

namespace Fwk.GuidPk.Actions
{


    [ServiceDependency(typeof(DTE))]
    public class AddItemFromStringAction : Microsoft.Practices.RecipeFramework.Action
    {
        #region Properties

        private string content;
        /// <summary>
        /// The string with the content of the item. In most cases it is a class
        /// generated using the T3 engine.
        /// </summary>
        [Input(Required = true)]
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string targetFileName;
        /// <summary>
        /// Name of the file where the item is to be stored.
        /// </summary>
        [Input(Required = true)]
        public string TargetFileName
        {
            get { return targetFileName; }
            set { targetFileName = value; }
        }

        private Project project;
        /// <summary>
        /// Project where the item it to be inserted.
        /// </summary>
        [Input(Required = true)]
        public Project Project
        {
            get { return project; }
            set { project = value; }
        }

        private bool open = true;
        /// <summary>
        /// A flag to indicate if the newly created item should be shown
        /// in a window.
        /// </summary>
        [Input]
        public bool Open
        {
            get { return open; }
            set { open = value; }
        }

        private string itemName;
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        [Input(Required = false)]
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        private EnvDTE.ProjectItem projectItem;
        /// <summary>
        /// A property that can be used to pass the creted item to
        /// a following action.
        /// </summary>
        [Output]
        public EnvDTE.ProjectItem ProjectItem
        {
            get { return projectItem; }
            set { projectItem = value; }
        }
        private string subfolder;
        [Input(Required = true)]
        public string Subfolder
        {
            get { return subfolder; }
            set { subfolder = value; }
        }
        #endregion

        #region Protected Implementation
        /// <summary>
        /// Called when [execute].
        /// </summary>
        public override void Execute()
        {
            string tempfile = Path.GetTempFileName();

            try
            {

                //string foldert = System.IO.Path.GetDirectoryName(Project.FullName);
                string fileFullName = string.Empty;
                //DirectoryInfo dInfo = new DirectoryInfo(foldert);
                ProjectItem folderItem = VSIPHelper.FindItemByName(Project.ProjectItems, Subfolder, true);
                if (folderItem==null)
                    try
                    {
                        project.ProjectItems.AddFolder(Subfolder);
                        folderItem = VSIPHelper.FindItemByName(Project.ProjectItems, Subfolder, true);
                    }
                    catch
                    { }
           
                using (StreamWriter sw = new StreamWriter(tempfile, false, new UTF8Encoding(true, true)))
                {
                    sw.WriteLine(content);
                }

                // Check it the targetFileName already exists and delete it so it can be added.
                ProjectItem targetItem = VSIPHelper.FindItemByName(Project.ProjectItems, targetFileName, true);
                if (targetItem != null)
                {
                    targetItem.Delete();
                }

                if (!String.IsNullOrEmpty(itemName))
                {
                    ProjectItem item = VSIPHelper.FindItemByName(Project.ProjectItems, itemName, true);

                    if (item != null)
                    {
                        projectItem = item.ProjectItems.AddFromTemplate(tempfile, targetFileName);
                    }
                }
                else
                {
                    //projectItem = project.ProjectItems.AddFromTemplate(tempfile, targetFileName);
                    projectItem = folderItem.ProjectItems.AddFromTemplate(tempfile, targetFileName);
                }

                if (open && projectItem != null)
                {
                    Window wnd = projectItem.Open(EnvDTE.Constants.vsViewKindPrimary);
                    wnd.Visible = true;
                    wnd.Activate();
                }
            }
            finally
            {
                File.Delete(tempfile);
            }
        }

        /// <summary>
        /// Called when [undo].
        /// </summary>
        public override void Undo()
        {
            if (projectItem != null)
            {
                projectItem.Delete();
            }
        }
        #endregion
    }
}
