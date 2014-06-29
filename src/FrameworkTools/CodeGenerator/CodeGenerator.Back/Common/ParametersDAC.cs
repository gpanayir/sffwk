using System;
using System.Collections.Generic;
using System.Text;
using fwkDataEntities = Fwk.DataBase.DataEntities;
using Fwk.Bases;

namespace CodeGenerator.Back.Common
{
    /// <summary>
    /// Permite construir parametros ADO .Net que se envian a SQL Server.-
    /// </summary>
    public class ParametersDAC
    {
        private static string _ParameterBatchBool;
        private static string _ParameterBatchInteger;
        private static string _ParameterBatchDecimal;
        private static string _ParameterBatchString;
        private static string _ParameterBatchDateTime;
        private static string _ParameterBatchBinary;
        private static fwkDataEntities.UserDefinedTypes _UserDefinedTypes = null;

        public static fwkDataEntities.UserDefinedTypes UserDefinedTypes
        {
            get { return _UserDefinedTypes; }
            set { _UserDefinedTypes = value; }
        }


        static ParametersDAC()
        {




            try
            {
                Template wTDGTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.TDGTemplate);

                _ParameterBatchBool = wTDGTemplate.Keys.GetKey("SPParameterBatchBit").TextContent;
                _ParameterBatchInteger = wTDGTemplate.Keys.GetKey("SPParameterBatchInteger").TextContent;
                _ParameterBatchDecimal = wTDGTemplate.Keys.GetKey("SPParameterBatchDecimal").TextContent;
                _ParameterBatchString = wTDGTemplate.Keys.GetKey("SPParameterBatchString").TextContent;
                _ParameterBatchDateTime = wTDGTemplate.Keys.GetKey("SPParameterBatchDateTime").TextContent;
                _ParameterBatchBinary = wTDGTemplate.Keys.GetKey("SPParameterBatchBinary").TextContent;


                _UserDefinedTypes = new Fwk.DataBase.DataEntities.UserDefinedTypes();


            }
            catch (Exception)
            {
                throw new Exception("No se encuentran en el template algun SPParameterBatch* EJ: SPParameterBatchBit");
            }
        }





        /// <summary>
        /// Obtiene el seteo de parametro que se envia a un store procedure  para Aplication Block,
        /// en forma de batch.-
        /// 
        /// </summary>
        /// <param name="pTableName">Nombre de tabla</param>
        /// <param name="pColumnName">Nombre de columna</param>
        /// <param name="pType">Tipo de SQL Server</param>
        /// <param name="pLastField">indica si es el ultimo parametro</param>
        ///<example>
        /// <code>
        /// 		
        ///   BatchCommandText.Append("@[Property_Name] = ");
        ///   if (w[NamePattern].[Property_Name] != null)
        ///    {
        ///         BatchCommandText.Append(w[NamePattern].[Property_Name]  == true ? "1":"0");
        ///     }
        ///     else { BatchCommandText.Append("NULL"); }
        ///     BatchCommandText.Append( ",");
        /// 
        /// </code>
        /// </example>
        /// <returns>string</returns>
        public static string GetParametersBatchCode(string pTableName, string pFieldName, string pType, bool pLastField)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();

            switch (pType.ToUpper())
            {
                case "BIT":
                    str.Append(_ParameterBatchBool);
                    break;
                case "REAL":
                case "NUMERIC":
                case "BIGINT":
                case "SMALLINT":
                case "INT":
                case "TINYINT":
                    str.Append(_ParameterBatchInteger);
                    break;
                case "MONEY":
                case "SMALLMONEY":
                case "DECIMAL":
                case "FLOAT":
                    str.Append(_ParameterBatchDecimal);
                    break;
                case "SMALLDATETIME":
                case "DATETIME":
                    str.Append(_ParameterBatchDateTime);
                    break;
                case "TEXT":
                case "CHAR":
                case "VARCHAR":
                case "NVARCHAR":
                    str.Append(_ParameterBatchString);
                    break;
                ///TODO:Ver paso de binarios por batch
                //case "IMAGE":
                //case "VARBINARY":
                //case "BINARY":
                //    str.Append(_ParameterBatchBynary);
                //    break;

            }

            str.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, pFieldName);
            if (pLastField)
                str.Replace(" BatchCommandText.Append( \",\");", " BatchCommandText.Append( \";\");");

            return str.ToString();
        }



        /// <summary>
        /// Obtiene el tipo de dato al cual mapear el del campo de la tabla.
        /// </summary>
        ///	<remarks>
        /// Hace uso de componentes de configuración (<see cref="DBTypesMappingSection"/>) que leen la configuración de mapeos del app.config.
        /// </remarks>
        /// <param name="pDatabaseType">Tipo de dato a mapear</param>
        /// <returns>Nombre del tipo de dato destino</returns>
        /// <author>Marcelo Oviedo</author>
        public static string GetTargetType(string pDatabaseType)
        {
            string wResult = string.Empty;
            fwkDataEntities.UserDefinedType wUserDefinedTypes = null;
            if (_UserDefinedTypes != null)
                wUserDefinedTypes = _UserDefinedTypes.GetUserDefinedType(pDatabaseType); //ResolveUserDefinedType(pDatabaseType);
            if (wUserDefinedTypes != null)
            {
                pDatabaseType = wUserDefinedTypes.SystemType;
            }
            foreach (DBTypeElement wDBTypeElement in DBTypesMappingSection.Current.DBTypes)
            {
                if (wDBTypeElement.Name == pDatabaseType)
                {
                    wResult = wDBTypeElement.TargetType;
                    break;
                }
            }

            if (wResult.Length == 0)
            {
                throw new Exception("No hay un mapeo definido para el tipo de dato " + pDatabaseType + ".");
            }

            return wResult;
        }

        /// <summary>
        /// Obtiene el indicador de tipo de dato nullable.
        /// </summary>
        ///	<remarks>
        /// Se requiere para los tipos de datos "por valor". Los tipos de datos "por referencia" no deben tener un especificador.
        /// </remarks>
        /// <param name="pDatabaseType">Tipo de dato a mapear</param>
        /// <returns>Indicador de tipo de dato nullable</returns>
        /// <date>2006-03-28T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        public static string GetNullableToken(string pDatabaseType)
        {
            string wResult = null;
            fwkDataEntities.UserDefinedType wUserDefinedTypes = null;
            if (_UserDefinedTypes != null)
                wUserDefinedTypes = _UserDefinedTypes.GetUserDefinedType(pDatabaseType); //ResolveUserDefinedType(pDatabaseType);
            if (wUserDefinedTypes != null)
            {
                pDatabaseType = wUserDefinedTypes.SystemType;
            }
            foreach (DBTypeElement wDBTypeElement in DBTypesMappingSection.Current.DBTypes)
            {
                if (wDBTypeElement.Name == pDatabaseType)
                {
                    wResult = wDBTypeElement.NullableToken;
                    break;
                }
            }

            if (wResult == null)
            {
                throw new Exception("No hay un mapeo definido para el tipo de dato " + pDatabaseType + ".");
            }

            return wResult;
        }


        /// <summary>
        /// Obtiene el tipo de System.Data.DbType atrvez de un tipo propi de SQL
        /// </summary>
        ///	<remarks>
        /// Hace uso de componentes de configuración (<see cref="DBTypesMappingSection"/>) que leen la configuración de mapeos del app.config.
        /// </remarks>
        /// <param name="pDatabaseType">Tipo de dato a mapear</param>
        /// <returns>Nombre del tipo de dato destino</returns>
        /// <date>2006-03-21T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        public static string GetTargetDBType(string pDatabaseType)
        {

            string wResult = string.Empty;
            fwkDataEntities.UserDefinedType wUserDefinedTypes = null;
            if (_UserDefinedTypes != null)
                wUserDefinedTypes = _UserDefinedTypes.GetUserDefinedType(pDatabaseType); //ResolveUserDefinedType(pDatabaseType);
            if (wUserDefinedTypes != null)
            {
                pDatabaseType = wUserDefinedTypes.SystemType;
            }
            foreach (DBTypeElement wDBTypeElement in DBTypesMappingSection.Current.DBTypes)
            {
                if (wDBTypeElement.Name == pDatabaseType)
                {
                    wResult = wDBTypeElement.TargetDBType;
                    break;
                }
            }

            if (wResult.Length == 0)
            {
                throw new Exception("No hay un mapeo definido para el tipo de dato " + pDatabaseType + ".");
            }

            return wResult;
        }


        /// <summary>
        /// Obtiene el Patrón para armado de parámetros de procedimientos almaceneados a partir del tipo de dato de cada campo de una tabla.
        /// </summary>
        ///	<remarks>
        /// Hace uso de componentes de configuración (<see>DBTypesMappingSection</see>) que leen la configuración de mapeos del app.config. 
        /// Devuelve un Patrón compuesto por tags a reemplazar. Los siguientes tags están disponibles para ser utilizados por el diseñador del Patrón:
        /// <list type="bullet">
        /// <item>Name</item>
        /// <item>Direction (Input / Output / InputOutput)</item>
        /// <item>Type</item>
        /// <item>Length</item>
        /// <item>Precision</item>
        /// <item>Scale</item>
        /// </list>
        /// </remarks>
        /// <param name="pDatabaseType">Tipo de dato para obtener el Patrón.</param>
        /// <returns>Patrón para reemplazo.</returns>
        /// <author>moviedo</author>
        public static string GetParameterPattern(string pDatabaseType)
        {
            string wResult = string.Empty;
            fwkDataEntities.UserDefinedType wUserDefinedTypes = null;
            if (_UserDefinedTypes != null)
                wUserDefinedTypes = _UserDefinedTypes.GetUserDefinedType(pDatabaseType); //ResolveUserDefinedType(pDatabaseType);
            if (wUserDefinedTypes != null)
            {
                pDatabaseType = wUserDefinedTypes.SystemType;
            }
            foreach (DBTypeElement wDBTypeElement in DBTypesMappingSection.Current.DBTypes)
            {
                if (wDBTypeElement.Name == pDatabaseType)
                {
                    wResult = wDBTypeElement.ParameterPattern;
                    break;
                }
            }

            if (wResult.Length == 0)
            {
                throw new Exception("No hay un Patrón definido para el tipo de dato " + pDatabaseType + ".");
            }

            return wResult;
        }

        //static fwkDataEntities.UserDefinedType ResolveUserDefinedType(String pDatabaseType )
        //{ 
        //    //TODO: ver esto
        //    //si el tipo esta definido en la BD como generado por el usuario
        //    fwkDataEntities.UserDefinedType wUserDefinedTypes = _UserDefinedTypes.GetUserDefinedType(pDatabaseType);
        //    if (wUserDefinedTypes != null)
        //        return wUserDefinedTypes;

        //    return null;
        //}
        /// <summary>
        /// Obtiene el Patrón de prefijos para los tipos de variables deacuerdo con el Estrandar de codificacion
        /// 
        /// </summary>
        ///	<remarks>
        /// Hace uso de componentes de configuración (<see>DBTypesMappingSection</see>) que leen la configuración de mapeos del app.config. 
        /// </remarks>
        /// <param name="pDatabaseType">Tipo de dato de SQL para obtener el Patrón.</param>
        /// <returns>Patrón para reemplazo.</returns>
        /// <author>moviedo</author>
        public static string GetPrefixType(string pDatabaseType)
        {
            string wResult = string.Empty;
            fwkDataEntities.UserDefinedType wUserDefinedTypes = null;
            if (_UserDefinedTypes != null)
                wUserDefinedTypes = _UserDefinedTypes.GetUserDefinedType(pDatabaseType); //ResolveUserDefinedType(pDatabaseType);
            if (wUserDefinedTypes != null)
            {
                pDatabaseType = wUserDefinedTypes.SystemType;
            }
            foreach (DBTypeElement wDBTypeElement in DBTypesMappingSection.Current.DBTypes)
            {
                if (wDBTypeElement.Name == pDatabaseType)
                {
                    wResult = wDBTypeElement.PatternPrefixType;
                    break;
                }
            }

            if (wResult.Length == 0)
            {
                throw new Exception("No hay un Patrón definido para el tipo de dato " + pDatabaseType + ".");
            }

            return wResult;
        }

        /// <summary>
        /// Obtiene el Patrón de prefijos para los tipos de variables deacuerdo con el Estrandar de codificacion
        /// </summary>
        ///	<remarks>
        /// Hace uso de componentes de configuración (<see>DBTypesMappingSection</see>) que leen la configuración de mapeos del app.config. 
        /// </remarks>
        /// <param name="TargetType">Tipo de dato ,net para obtener el Patrón.</param>
        /// <returns>Patrón para reemplazo.</returns>
        /// <author>moviedo</author>
        public static string GetPrefixTypeBy(string pTargetType)
        {
            string wResult = string.Empty;

            foreach (DBTypeElement wDBTypeElement in DBTypesMappingSection.Current.DBTypes)
            {
                if (wDBTypeElement.TargetType == pTargetType)
                {

                    wResult = wDBTypeElement.PatternPrefixType;
                    break;
                }
            }

            if (wResult.Length == 0)
            {
                throw new Exception("No hay un Patrón definido para el tipo de dato " + pTargetType + ".");
            }

            return wResult;
        }

        /// <summary>
        /// Obtiene el Patrón tipos para un esquema xsd a partir del nombre del tipo de dato de SQL
        /// Ej: Campo.Type
        /// </summary>
        ///	<remarks>
        /// Hace uso de componentes de configuración (<see>DBTypesMappingSection</see>) que leen la configuración de mapeos del app.config. 
        /// </remarks>
        /// <param name="pDatabaseType">Tipo de dato de SQL Ej: Campo.Type.Name</param>
        /// <returns>Patrón para reemplazo.</returns>
        /// <author>moviedo</author>
        public static string GetTargetSchemaTypeByName(string pDatabaseType)
        {
            string wResult = string.Empty;
            fwkDataEntities.UserDefinedType wUserDefinedTypes = null;
            if (_UserDefinedTypes != null)
                wUserDefinedTypes = _UserDefinedTypes.GetUserDefinedType(pDatabaseType); //ResolveUserDefinedType(pDatabaseType);
            if (wUserDefinedTypes != null)
            {
                pDatabaseType = wUserDefinedTypes.SystemType;
            }
            foreach (DBTypeElement wDBTypeElement in DBTypesMappingSection.Current.DBTypes)
            {
                if (wDBTypeElement.Name == pDatabaseType)
                {

                    wResult = wDBTypeElement.TargetSchemaType;
                    break;
                }
            }

            if (wResult.Length == 0)
            {
                throw new Exception("No hay un Patrón definido para el tipo de dato " + pDatabaseType + ".");
            }

            return wResult;
        }
    }



}
