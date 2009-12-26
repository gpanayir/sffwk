
using System;
using System.Collections;
using System.ComponentModel;

using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using System.Text;

namespace Fwk.Wizard
{

    public static class FwkGeneratorHelper
    {
        public static string NotSupportTypes_ToIncludeInBackEnd;
        private static string _Entity_Property_tt;
        private static string _Entity_Member_tt;
        private static string _Entity_Envelope_tt;
        private static string _Entity_Property_TemplateBinary_tt;

        static FwkGeneratorHelper()
        {
            NotSupportTypes_ToIncludeInBackEnd = "xml,timestamp,sql_variant";
            _Entity_Property_TemplateBinary_tt = HelperFunctions.OpenTextFile(@"TemplateFiles\Property_Binary.txt");
            _Entity_Envelope_tt = HelperFunctions.OpenTextFile(@"TemplateFiles\Entity.txt");
            _Entity_Property_tt = HelperFunctions.OpenTextFile(@"TemplateFiles\Property.txt");
            _Entity_Member_tt = "private [TYPENAME][NullToken] _[Property_Name];";
        }

        #region Entity gen

        internal static string Gen_Entity(Table pTable)
        {
            StringBuilder wClassContainer = new StringBuilder();
            string wPrivateMembers_BODY = String.Empty;
            string wPublicProperty_BODY = String.Empty;


            wClassContainer.Append(_Entity_Envelope_tt);
            wClassContainer.Replace(CommonConstants.CONST_ENTITY_NAME, pTable.Name);
            
            

            GenerateDataBaseProperttyBody(pTable, out  wPublicProperty_BODY, out wPrivateMembers_BODY);
            //Inserta miembros privados
            wClassContainer.Replace(CommonConstants.CONST_ENTITY_PRIVATE_MEMBERS_BODY, wPrivateMembers_BODY);
            //Inserta los atributos publicos
            wClassContainer.Replace(CommonConstants.CONST_ENTITY_PUBLIC_PROPERTY_BODY,
                                                    wPublicProperty_BODY);




            return wClassContainer.ToString();
        }

        /// <summary>
        /// Retorna codigo de miembros privados + los atributos publicos.-
        /// </summary>
        /// <param name="pTable">tabla</param>
        /// <param name="pPublicProperty_Body">atributos publicos</param>
        /// <param name="pPrivateMembers_Body">miembros privados</param>
         static void GenerateDataBaseProperttyBody(Table pTable, out String pPublicProperty_Body, out String pPrivateMembers_Body)
        {

            StringBuilder wPrivateMembers_BODY = new StringBuilder();
            StringBuilder wPublicProperty_BODY = new StringBuilder();

            foreach (Column wColumn in pTable.Columns)
            {
                //Si es una columna no permitida
                if (!NotSupportTypes_ToIncludeInBackEnd.Contains(wColumn.DataType.Name.ToLower()))
                {
                    //if (wColumn.Selected)
                    //{
                        //Privados
                        wPrivateMembers_BODY.Append(GetCsharpMember(wColumn));
                        //Publicos (con Get y Set)
                        wPublicProperty_BODY.Append(GetCsharpProperty(wColumn));
                    //}
                }
            }
            pPrivateMembers_Body = wPrivateMembers_BODY.ToString();
            pPublicProperty_Body = wPublicProperty_BODY.ToString();


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
         static string GetCsharpProperty(Column pColumn)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder(_Entity_Property_tt);

            switch (pColumn.DataType.Name.ToUpper())
            {
                case "BIT":
                    str = new System.Text.StringBuilder(_Entity_Property_tt);
                    str.Replace(CommonConstants.CONST_TYPENAME, "bool");
                    break;
                case "REAL":
                case "NUMERIC":
                case "BIGINT":
                case "SMALLINT":
                case "INT":
                case "TINYINT":
                    str = new System.Text.StringBuilder(_Entity_Property_tt);
                    str.Replace(CommonConstants.CONST_TYPENAME, "int");
                    break;
                case "MONEY":
                case "SMALLMONEY":
                case "DECIMAL":
                case "FLOAT":
                    str = new System.Text.StringBuilder(_Entity_Property_tt);
                    str.Replace(CommonConstants.CONST_TYPENAME, "decimal");
                    break;
                case "SMALLDATETIME":
                case "DATETIME":
                    str.Replace(CommonConstants.CONST_TYPENAME, "datetime");
                    break;
                case "TEXT":
                case "CHAR":
                case "VARCHAR":
                case "NVARCHAR":
                    str = new System.Text.StringBuilder(_Entity_Property_tt);
                    str.Replace(CommonConstants.CONST_TYPENAME, "string");
                    break;
                case "IMAGE":
                case "VARBINARY":
                case "BINARY":
                case "TINYUNT":
                    str = new System.Text.StringBuilder(_Entity_Property_TemplateBinary_tt);
                    
               
                    break;

            }
            str.Replace("[NullToken]", GetNullableToken(pColumn));
            str.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, pColumn.Name);
            str.AppendLine(Environment.NewLine);

            return str.ToString();
        }

         static string GetCsharpMember( Column pColumn)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder(_Entity_Member_tt);

            switch (pColumn.DataType.Name.ToUpper())
            {
                case "BIT":

                    str.Replace(CommonConstants.CONST_TYPENAME, "bool");
                    break;
                case "REAL":
                case "NUMERIC":
                case "BIGINT":
                case "SMALLINT":
                case "INT":
                case "TINYINT":
                    str.Replace(CommonConstants.CONST_TYPENAME, "int");
                    break;
                case "MONEY":
                case "SMALLMONEY":
                case "DECIMAL":
                case "FLOAT":
                    str.Replace(CommonConstants.CONST_TYPENAME, "decimal");
                    break;
                case "SMALLDATETIME":
                case "DATETIME":
                    str.Replace(CommonConstants.CONST_TYPENAME, "datetime");
                    break;
                case "TEXT":
                case "CHAR":
                case "VARCHAR":
                case "NVARCHAR":
                    str.Replace(CommonConstants.CONST_TYPENAME, "String");
                    break;
                case "IMAGE":
                case "VARBINARY":
                case "BINARY":
                case "TINYUNT":
                    str.Replace(CommonConstants.CONST_TYPENAME, "Byte[]");
                    break;
            }

            str.Replace("[NullToken]", GetNullableToken(pColumn));
            str.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, pColumn.Name);

            str.AppendLine(Environment.NewLine);
            return str.ToString();
        }

         static string GetNullableToken(Column pColumn)
        {
            if (!pColumn.Nullable)
                return string.Empty;

            switch (pColumn.DataType.Name.ToUpper())
            {
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
                case "CHAR":
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
    }






}
