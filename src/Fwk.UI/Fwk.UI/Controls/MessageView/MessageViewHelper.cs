using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Fwk.AssemblyExplorer;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;
using Fwk.UI.Common;


namespace Fwk.UI.Controls
{
    public static class MessageViewHelper
    {
      
        /// <summary>
        /// Obtiene la imagen de un icono para un messagebox
        /// a partir de su tipo y tama�o
        /// </summary>
        /// <param name="_MessageBoxIcon">Tipo del MessageBoxIcon</param>
        /// <param name="pIconSize">Tama�o del icono</param>
        /// <returns>Imagen resultante.</returns>
        public static Image GetMessageBoxIcon(Fwk.UI.Common.MessageBoxIcon _MessageBoxIcon, IconSize pIconSize)
        {

            Image imgIcon = null;

            switch (_MessageBoxIcon)
            {
                case Fwk.UI.Common.MessageBoxIcon.Exclamation:
                    {
                        imgIcon =
                            (Image)
                            Fwk.UI.Properties.Resources.ResourceManager.GetObject(
                                string.Concat("exclamation_", (int)pIconSize));

                        break;
                    }
                case Fwk.UI.Common.MessageBoxIcon.Warning:
                    {

                        imgIcon =
                            (Image)
                            Fwk.UI.Properties.Resources.ResourceManager.GetObject(
                                string.Concat("warning_", (int)pIconSize));
                        break;
                    }
                case Fwk.UI.Common.MessageBoxIcon.Question:
                    {

                        imgIcon =
                            (Image)
                            Fwk.UI.Properties.Resources.ResourceManager.GetObject(
                                string.Concat("question_", (int)pIconSize));
                        break;
                    }
                case Fwk.UI.Common.MessageBoxIcon.Error:
                    {

                        imgIcon =
                            (Image)
                            Fwk.UI.Properties.Resources.ResourceManager.GetObject(
                                string.Concat("error_", (int)pIconSize));
                        break;
                    }
                case Fwk.UI.Common.MessageBoxIcon.Information:
                    {

                        imgIcon =
                            (Image)
                            Fwk.UI.Properties.Resources.ResourceManager.GetObject(
                                string.Concat("information_", (int)pIconSize));

                        break;

                    }
            }

            return imgIcon;
        }

   

    }


}
    
    
  

