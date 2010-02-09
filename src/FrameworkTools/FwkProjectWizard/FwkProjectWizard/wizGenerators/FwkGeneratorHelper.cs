﻿
using System;
using System.Collections;
using System.ComponentModel;

using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Fwk.Wizard
{

    public static class FwkGeneratorHelper
    {
      
        static string roottemplate;
        static TemplateDocument _TemplateDocument;
        static MappingTypes _MappingTypes;
        internal static TemplateDocument TemplateDocument
        {
            get { return _TemplateDocument; }
        }
        internal static MappingTypes MappingTypes
        {
            get { return _MappingTypes; }
        }
        internal static UserDefinedTypes UserDefinedTypes;
        internal static string NotSupportTypes_ToIncludeInBackEnd;
        internal static string _Entity_Property_tt;
        internal static string _Entity_Member_tt;
        internal static string _Entity_Envelope_tt;
        internal static string _Entity_Property_TemplateBinary_tt;

        static FwkGeneratorHelper()
        {
            roottemplate = Path.Combine(HelperFunctions.ProgramFilesx86(), @"Allus Global BPO\FwkTemplates\tt\");
            
            _TemplateDocument = (TemplateDocument)HelperFunctions.DeserializeFromXml(typeof(TemplateDocument), GetFileTemplate("Templates.xml"));
            _MappingTypes = (MappingTypes)HelperFunctions.DeserializeFromXml(typeof(MappingTypes), GetFileTemplate("MappingType.xml"));

            NotSupportTypes_ToIncludeInBackEnd = "xml,timestamp,sql_variant";
            _Entity_Envelope_tt = FwkGeneratorHelper.GetFileTemplate("Entity.txt");
            _Entity_Property_TemplateBinary_tt = _TemplateDocument.GetTemplate("Property_Binary").Content;
            
            _Entity_Property_tt = _TemplateDocument.GetTemplate("Property").Content;

            _Entity_Member_tt = "           private [TYPENAME][NullToken] _[Property_Name];";
            
            UserDefinedTypes = new UserDefinedTypes();


            


        }

        internal static string GetFileTemplate(string name)
        {

            string file = name;
           
            
          
           if ( System.IO.File.Exists(Path.Combine(roottemplate,name)))
               file = Path.Combine(roottemplate, name);

           if (!System.IO.File.Exists(file))
           {
               throw new Exception("No se pueden encontrar las plantillas de generacion de codigo.-");
           }
           return  HelperFunctions.OpenTextFile(file);

        
        }

        #region Entity gen




        internal static Column GetPrimaryKey(Table pTable)
        {
            foreach (Column c in pTable.Columns)
            {
                if (c.Identity)
                {
                    return c;
                }

            }
            return null;
        }

        internal static string ChekUserDefinedDataType(Column pColumn)
        {
            string wTypeName = pColumn.DataType.Name.ToUpper();
            if (pColumn.DataType.SqlDataType.ToString().Equals("UserDefinedDataType"))
            {
                wTypeName = UserDefinedTypes.GetUserDefinedType(pColumn.DataType.Name).SystemType.ToUpper();
            }
            return wTypeName;
        }

        /// <summary>
        /// Obtiene el seteo de parametro que se envia a un store procedure  para Aplication Block,
        /// en forma de batch.-
        /// 
        /// </summary>
        /// <param name="pTableName">Nombre de tabla</param>
        /// <param name="pColumnName">Nombre de columna</param>
        /// <param name="pType">Tipo de SQL Server</param>
        ///<example>
        /// <code>
        /// 		
        ///   #region [[Property_Name]]
        ///   public [TYPENAME] [Property_Name]
        ///     {
        ///      get { return _[Property_Name]; }
        ///      set { _[Property_Name] = value;  }
        ///     }
        ///   #endregion
        /// 
        /// </code>
        /// </example>
        /// <returns>string</returns>
        internal static string GetCsharpProperty(Column pColumn)
        {
            string wTypeName = pColumn.DataType.Name.ToUpper();
            if (pColumn.DataType.SqlDataType.ToString().Equals("UserDefinedDataType"))
            {
                wTypeName = UserDefinedTypes.GetUserDefinedType(pColumn.DataType.Name).SystemType.ToUpper();
            }

            System.Text.StringBuilder str = new System.Text.StringBuilder(_Entity_Property_tt);

            

            switch (wTypeName)
            {
                case "IMAGE":
                case "VARBINARY":
                case "BINARY":
                
                    str = new System.Text.StringBuilder(_Entity_Property_TemplateBinary_tt);
                    //str.Replace(CommonConstants.CONST_TYPENAME, "Byte[]");
                    break;

            }

           

            str.Replace(CommonConstants.CONST_TYPENAME, FwkGeneratorHelper.GetCSharpType(pColumn));
            str.Replace("[NullToken]", GetNullableToken(pColumn));
            str.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, pColumn.Name);
            str.AppendLine(Environment.NewLine);

            return str.ToString();
        }

         internal static string GetCsharpMember(Column pColumn)
        {
            string wTypeName = pColumn.DataType.Name.ToUpper();
            if (pColumn.DataType.SqlDataType.ToString().Equals("UserDefinedDataType"))
            {
               wTypeName =  UserDefinedTypes.GetUserDefinedType(pColumn.DataType.Name).SystemType.ToUpper();
            }



            System.Text.StringBuilder str;

            if (_MappingTypes.ExistMappingType_sqlname(wTypeName))
            {
                str = new System.Text.StringBuilder(_Entity_Member_tt);
                str.Replace(CommonConstants.CONST_TYPENAME, _MappingTypes.GetMappingType_sqlname(wTypeName).Cshrarptype);
            }
            else
                return String.Empty;
           
            

            str.Replace("[NullToken]", GetNullableToken(pColumn));
            str.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, pColumn.Name);
            str.AppendLine(Environment.NewLine);

            return str.ToString();
        }

         internal static string GetCSharpType(Column pColumn)
         {
             string wTypeName = pColumn.DataType.Name.ToUpper();
             if (pColumn.DataType.SqlDataType.ToString().Equals("UserDefinedDataType"))
             {
                 wTypeName = UserDefinedTypes.GetUserDefinedType(pColumn.DataType.Name).SystemType.ToUpper();
             }
             if (_MappingTypes.ExistMappingType_sqlname(wTypeName))
                 return _MappingTypes.GetMappingType_sqlname(wTypeName).Cshrarptype;
            
            
             return string.Empty;
         }
         internal static string GetNullableToken(Column pColumn)
        {
            if (!pColumn.Nullable)
                return string.Empty;
            string wTypeName = pColumn.DataType.Name.ToUpper();
            if (pColumn.DataType.SqlDataType.ToString().Equals("UserDefinedDataType"))
            {
                wTypeName = UserDefinedTypes.GetUserDefinedType(pColumn.DataType.Name).SystemType.ToUpper();
            }
          

            switch (wTypeName)
            {
                case "UNIQUEIDENTIFIER":
            
                case "BIT":
                case "REAL":
                case "NUMERIC":
                case "BIGINT":
                case "SMALLINT":
                case "INT":
                case "TINYINT":
                case "MONEY":
                case "SMALLMONEY":
                case "DECIMAL":
                case "FLOAT":
                case "SMALLDATETIME":
                case "DATETIME":
                    return "?";

                case "TEXT":
                case "NTEXT":
                case "CHAR":
                case "NCHAR":
                case "VARCHAR":
                case "NVARCHAR":
                    return String.Empty;

                case "IMAGE":
                case "VARBINARY":
                case "BINARY":
                case "TINYUNT":
                    return String.Empty;
                

            }
            return String.Empty;
        }

        
        #endregion

         internal static string GetDBType(Column pColumn)
         {
            
             return _MappingTypes.GetMappingType_sqlname(ChekUserDefinedDataType(pColumn).ToLower()).DBtype;
         }
         internal static bool GeColumnFindeable(Column pColumn)
         {
             string wTypeName = pColumn.DataType.Name.ToUpper();
             if (pColumn.DataType.SqlDataType.ToString().Equals("UserDefinedDataType"))
             {
                 wTypeName = UserDefinedTypes.GetUserDefinedType(pColumn.DataType.Name).SystemType.ToUpper();
             }
             switch (wTypeName)
             {
                 case "UNIQUEIDENTIFIER":
        
                 case "BIT":
            
                    
                 case "REAL":
                 case "NUMERIC":
                 case "BIGINT":
                 case "SMALLINT":
                 case "INT":
                 case "TINYINT":
                 case "SMALLDATETIME":
                 case "DATETIME":
                 case "CHAR":
                 case "NCHAR":
                 case "VARCHAR":
                 case "NVARCHAR":
                    return true;
                 case "MONEY":
                 case "SMALLMONEY":
                 case "DECIMAL":
                 case "FLOAT":
                 case "NTEXT":
                 case "TEXT":
                 case "IMAGE":
                 case "VARBINARY":
                 case "BINARY":
                 case "TINYUNT":
                     return false;

             }
             return false;
         }
    }






}