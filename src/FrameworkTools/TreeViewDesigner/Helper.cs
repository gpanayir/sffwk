using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Fwk.HelperFunctions;
using System.Drawing.Imaging;
using Fwk.Bases;

namespace Fwk.Tools
{
    internal class Helper
    {
        
        public static Byte[] LoadImage(Image pImage, string pExtension)
        {
            Byte[] imgByte = null;
            switch (pExtension.ToLower())
            {
                case "":
                case null:
                case ".jpeg":
                case ".jpg":
                    {
                        imgByte = TypeFunctions.ConvertImageToByteArray(pImage, ImageFormat.Jpeg);

                        break;
                    }
                case ".gif":
                    {
                        imgByte = TypeFunctions.ConvertImageToByteArray(pImage, ImageFormat.Gif);

                        break;
                    }

            }


            return imgByte;
        }


       
    }


    /// <summary>
    /// Enumeración que define la accion a realizar por el Pelsoftulario.
    /// </summary>
    /// <date>2007-07-13T00:00:00</date>
    /// <author>moviedo</author>
    public enum Action
    {

        /// <summary>
        /// Indica que se creará una nueva configuración de servicio.
        /// </summary>
        New,
        /// <summary>
        /// Indica que se editará una configuración de servicio existente.
        /// </summary>
        Edit,
        /// <summary>
        /// Modo consulta.
        /// </summary>
        Query
    }


}
