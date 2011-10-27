using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace Security
{
    public static class Helper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        internal static string GetNewImageDiv(string id,string pclass)
        {
            return string.Format(WebUserControlsConstants.ImageDiv, id,pclass );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">id del div q la contiene</param>
        /// <param name="applicationPath_ImgUrl"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="display"></param>
        /// <param name="title"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        internal static string GetNewImage(string id, string applicationPath_ImgUrl, string width, string height, string display, string title,string tag)
        {
           return  string.Format(WebUserControlsConstants.UrlImageTemplate,
                   title, applicationPath_ImgUrl.Replace("//", "/"),
                    tag, width,height,id);
        }
      

        /// <summary>
        /// Este código se encargará de longitud / anchura en el cambio de tamaño.
        /// </summary>
        /// <param name="originalFile"></param>
        /// <param name="reducedFile"></param>
        /// <param name="lnWidth"></param>
        /// <param name="lnHeight"></param>
        /// <returns></returns>
        internal static void CreateThumbnail(string originalFile, string reducedFile, int newWidth, int newHeight)
        {
            //System.Drawing.Bitmap bmpOut = null;

            using (Bitmap originalBMP = new Bitmap(originalFile))
            {
                ImageFormat originalFormat = originalBMP.RawFormat;
                //decimal lnRatio;
                int wNewWidth = newWidth;
                int wNewHeight = newHeight;
                if (originalBMP.Width <= newWidth && originalBMP.Height <= newHeight)
                {
                    originalBMP.Save(reducedFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return;
                }

                //if (originalBMP.Width > originalBMP.Height)
                //{
                //    lnRatio = (decimal)newWidth / originalBMP.Width;
                //    lnNewWidth = newWidth;
                //    decimal lnTemp = originalBMP.Height * lnRatio;
                //    lnNewHeight = (int)lnTemp;
                //}
                //else
                //{
                //    lnRatio = (decimal)newHeight / originalBMP.Height;
                //    lnNewHeight = newHeight;
                //    decimal lnTemp = originalBMP.Width * lnRatio;
                //    lnNewWidth = (int)lnTemp;
                //}

                using (Bitmap bmpOut = new Bitmap(wNewWidth, wNewHeight))
                {
                    Graphics g = Graphics.FromImage(bmpOut);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.FillRectangle(Brushes.White, 0, 0, wNewWidth, wNewHeight);
                    g.DrawImage(originalBMP, 0, 0, wNewWidth, wNewHeight);
                    //loBMP.Dispose();



                    bmpOut.Save(reducedFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }


    }
}
