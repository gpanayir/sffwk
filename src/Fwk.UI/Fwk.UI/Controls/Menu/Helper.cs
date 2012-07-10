using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.HelperFunctions;

namespace Fwk.UI.Controls.Menu
{
    public class Helper
    {

        /// <summary>
        /// Muestra un dialogo para abrir un archivo del tipo especificado en el filtro.
        /// </summary>
        /// <param name="pFilter">Tipo de archivos que se podrán seleccionar en el dialogo.</param>
        /// <returns>String con el nombre del archivo.</returns>
        public static String OpenFile(string pFilter)
        {
            using (OpenFileDialog wDialog = new OpenFileDialog())
            {
                wDialog.CheckFileExists = true;
                wDialog.Filter = String.Format("Files {0}|All Files (*.*)|*.*", pFilter);
                
                if (wDialog.ShowDialog() == DialogResult.OK)
                {
                    return wDialog.FileName;
                }

                return String.Empty;
            }

        }

        public static String SaveFile(string pDefaultFileName)
        {
            using (SaveFileDialog wDialog = new SaveFileDialog())
            {
                wDialog.ValidateNames = true;
                wDialog.OverwritePrompt = true;
                wDialog.Filter = Fwk.HelperFunctions.FileFunctions.OpenFilterEnums.OpenXmlFilter; //"Files (*.xml)|*.xml|All Files (*.*)|*.*";
                wDialog.FileName = pDefaultFileName;

                if (wDialog.ShowDialog() != DialogResult.OK)
                {
                    return string.Empty;
                }

                return wDialog.FileName;
            }
        }

        public static void SaveMenuToFile(MenuNavBar pMenu, string pFile)
        {
            if (string.IsNullOrEmpty(pFile))
            {
                return;
            }

            if (pMenu == null)
            {
                return;
            }

            FileFunctions.SaveTextFile(pFile, pMenu.GetXml(), false);
        }

        public static void SaveToolBarToFile(ToolBar pButtons, string pFile)
        {
            if (string.IsNullOrEmpty(pFile))
            {
                return;
            }

            if (pButtons == null)
            {
                return;
            }

            FileFunctions.SaveTextFile(pFile, pButtons.GetXml(), false);
        }


    }
}
