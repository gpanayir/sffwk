using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Wizard
{
    public enum WizartBotoon
    { 
        Ok =0,
        Cancel =1,
        Next=2,
        Back=3
    }
    internal static class Helper
    {

        /// <summary>
        /// Genera un string con el contenido del InnerException .-
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static String GetAllMessageException(Exception ex)
        {
            
            StringBuilder wMessage = new StringBuilder();
            wMessage.Append(ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                wMessage.AppendLine("Source: ");
                wMessage.AppendLine(ex.Source);
                wMessage.AppendLine();
                wMessage.AppendLine("Message: ");
                wMessage.AppendLine(ex.Message);
            }
            return wMessage.ToString();
        }
    }
}
