using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace Fwk.CodeGenerator
{
    public class CodeGeneratorCommon
    {
        

      

        public enum SelectedObject
        {
            Tables = 0,
            StoreProcedures = 1,
            Schema = 2
        }
        public enum TemplateType
        {
            StoreProcedure = 0,
            DataAccesComponent = 1,
            BussinesEntity = 2,
            Namespaces = 3
        }
        public static Boolean ValidateFileByExtencion(string pExtencion, string pFullNemeFile)
        {
            if (!System.IO.File.Exists(pFullNemeFile)) return false;
            if (pFullNemeFile.Length > 3)
            {
                if (pFullNemeFile.Substring(pFullNemeFile.Length - 3, 3).ToLower() != pExtencion.ToLower()) return false;
            }
            else
                return false;

            return true;

        }

      
    }


   
}
