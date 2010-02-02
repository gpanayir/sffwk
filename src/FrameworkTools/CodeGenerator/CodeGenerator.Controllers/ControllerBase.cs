using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Fwk.CodeGenerator.Common;
namespace CodeGenerator.Controllers
{
    public class ControllerBase
    {
        //private String _ModuleName = String.Empty;
        //private String _CompanyName = String.Empty;
        //private String _ApplicationName = String.Empty;
        private TemplateSettingObject _TemplateSettingObject = null;

        public TemplateSettingObject TemplateSettingObject
        {
            get { return _TemplateSettingObject; }
            set { _TemplateSettingObject = value; }
        }


        

        /// <summary>
        /// inicializa interfaz con datos para generar código.
        /// </summary>
        /// <author>moviedo</author>
        public static void InitializeMethodActionType(ListView lvwMethods)
        {
            try
            {

                lvwMethods.Clear();
                foreach (string wStr in Enum.GetNames(typeof(MethodActionType)))
                {
                    if (((MethodActionType)Enum.Parse(typeof(MethodActionType), wStr)) != MethodActionType.Get &&
                        ((MethodActionType)Enum.Parse(typeof(MethodActionType), wStr)) != MethodActionType.Other)
                    {
                        lvwMethods.Items.Add(wStr);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
