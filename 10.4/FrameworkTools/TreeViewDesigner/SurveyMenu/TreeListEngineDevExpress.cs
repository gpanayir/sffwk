using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraTreeList;
using Fwk.Bases;
using System.Windows.Forms;
using Fwk.UI.Controls.Menu.Tree;

namespace Fwk.Tools.TreeView
{
    public class TreeListEngineDevExpress
    {
       // public static MenuItemList MenuItemSurveyList;
        static TreeListEngineDevExpress()
        {
            //Ahora se lee de un archivo de configuración
            //string wFileName = System.IO.Path.Combine(Application.StartupPath, "QuestionSurveyMenu.xml");
            //string wFileName = Fwk.Configuration.ConfigurationManager.GetProperty("ApplicationMenu", "QuestionTreeView").ToString();

            //TreeListEngineDevExpress.LoadMenuFromFile(wFileName);
        }
        public static void LoadFromFile(TreeList pTreeList, String pFullFileName)
        {
            if (!String.IsNullOrEmpty(pFullFileName))
            {
                DataSet wDataSet = new DataSet();
                wDataSet.ReadXml(pFullFileName);
                pTreeList.DataSource = wDataSet.Tables[0].DefaultView;
                pTreeList.ExpandAll();
            }
        }

        public static void SaveMenuToFile(String pFullFileName, IEntity pMenuItemRoot)
        {
            if (String.IsNullOrEmpty(pFullFileName)) 
                return;

            Fwk.HelperFunctions.FileFunctions.SaveTextFile(pFullFileName, pMenuItemRoot.GetXml(), false);
        }
        /// <summary>
        /// Restablece el valor estatico de MenuItemList
        /// </summary>
        /// <param name="pFullFileName"></param>
        /// <returns></returns>
        public static TreeMenu LoadMenuFromFile(String pFullFileName)
        {
            //Application.StartupPath
            if (String.IsNullOrEmpty(pFullFileName)) 
                return null;
            if (!System.IO.File.Exists(pFullFileName)) 
                return null;
            
            String wXml = Fwk.HelperFunctions.FileFunctions.OpenTextFile(pFullFileName);
           return TreeMenu.GetFromXml<TreeMenu>(wXml);
            
        }
    }
}
