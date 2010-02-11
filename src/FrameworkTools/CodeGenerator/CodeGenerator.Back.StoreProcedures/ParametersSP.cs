using System;
using System.Text;
using fwkDataEntities = Fwk.DataBase.DataEntities;
using CodeGenerator.Back.Common;
namespace CodeGenerator.Back.StoreProcedures
{
    public class ParametersSP
    {

         
        #region GetPatternSearchParametersSp_ExecuteSql
        /// <summary>
        /// Genera uns string con el Pattern para el campo de los parámetros utilizados como 3er parámetro pasado a sp_executesql.
        /// </summary>
        public static string GetPatternSearchParametersSp_ExecuteSql(fwkDataEntities.Column pColumn)
        {

            StringBuilder sbTipo = new StringBuilder("");
            switch (pColumn.Type.Trim().ToUpper())
            {
                case "SMALLDATETIME":
                case "DATETIME":
                    sbTipo.AppendLine();
                    sbTipo.Append("--@" + pColumn.Name + "Desde, ");
                    sbTipo.AppendLine();
                    sbTipo.Append("--@" + pColumn.Name + "Hasta, ");
                    sbTipo.AppendLine();
                    sbTipo.Append("@" + pColumn.Name + ", ");
                    break;
                default:
                    sbTipo.Append("@" + pColumn.Name + ", ");
                    break;
            }
            return sbTipo.ToString();

        }
        #endregion

        #region GetPatternSearch
        /// <summary>
        /// Levanta el pattern para el tipo de dato del campo desde una archivo físico.
        /// Pisa tags [NOMBRE_CAMPO],[NOMBRE_PARAMETRO_CAMPO],[NOMBRE_PARAMETRO_OPERADOR_CAMPO],
        /// [NOMBRE_PARAMETRO_CAMPO_DESDE],[NOMBRE_PARAMETRO_CAMPO_HASTA],[PARAMETRO_SPEXECUTESQL]
        /// y retorna el string actualizado.
        /// </summary>
        /// <returns>String actualizado.</returns>
        public static string GetPatternSearch(fwkDataEntities.Column pColumn)
        {



            string sbPatternSearch = GetTemplateSearch(pColumn.Type);

            sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_CAMPO>", pColumn.Name.Trim());
            sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_PARAMETRO_CAMPO>", "@" + pColumn.Name.Trim());
            sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_PARAMETRO_OPERADOR_CAMPO>", "@Ope" + pColumn.Name.Trim());
            sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_PARAMETRO_CAMPO_DESDE>", "@" + pColumn.Name.Trim() + "Desde");
            sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_PARAMETRO_CAMPO_HASTA>", "@" + pColumn.Name.Trim() + "Hasta");

            string parametros_spExecuteSql = "@" + pColumn.Name.Trim() + " " + pColumn.Length.ToString() + ",";

            sbPatternSearch.Replace("<PARAMETRO_SPEXECUTESQL>", parametros_spExecuteSql);

            return sbPatternSearch;
        }
        #endregion

        #region Genera el Pattern
        /// <summary>
        /// Retorna el Pattern para el Store Search del Tipo de dato pasado como parámetro.
        /// </summary>
        /// <example ><code>
        /// Ej:
        /// -- <NOMBRE_CAMPO> = TYPE [TYPENAME]
        /// IF (<NOMBRE_PARAMETRO_CAMPO> IS NOT NULL)
        /// BEGIN
        ///       SET @sql = @sql + ' AND <NOMBRE_CAMPO>  LIKE  <NOMBRE_PARAMETRO_CAMPO> '
        /// END
        /// <param name="SQLServerType">Tipo de dato SQL Server.</param>
        /// <param name="NombreCampo">Nombre del campo.</param>
        /// <returns></returns>
        public static string GetTemplateSearch(string SQLServerType)
        {
            string wTemplate = string.Empty;
            Template wStoredProcedureTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.StoredProcedureTemplate);
            switch (SQLServerType.ToUpper().Trim())
            {
                case "VARCHAR":
                case "NVARCHAR":
                case "NVARCHARMAX":
                case "CHAR":
                case "NCHAR":
                    {
                        wTemplate = wStoredProcedureTemplate.Keys.GetKey("Search_TypeVarChar").TemplateAtribute.Body;
                        break;
                    }
                case "REAL":
                case "DECIMAL":
                case "NUMERIC":
                case "MONEY":
                case "SMALLMONEY":
                case "FLOAT":
                case "INT":
                case "BIGINT":
                case "SMALLINT":
                case "TINYINT":
                    {
                        wTemplate = wStoredProcedureTemplate.Keys.GetKey("Search_TypeNumeric").TemplateAtribute.Body;
                        break;
                    }
                case "BIT":
                    {
                        wTemplate = wStoredProcedureTemplate.Keys.GetKey("Search_TypeBit").TemplateAtribute.Body;
                        break;
                    }
                case "DATETIME":
                case "SMALLDATETIME":
                    {
                        wTemplate = wStoredProcedureTemplate.Keys.GetKey("Search_TypeDateTime").TemplateAtribute.Body;
                        break;
                    }


                case "UNIQUEIDENTIFIER":
                    {
                        wTemplate = String.Empty;
                        break;
                    }
                case "TEXT":
                case "NTEXT":
                    {
                        wTemplate = wStoredProcedureTemplate.Keys.GetKey("Search_TypeNText").TemplateAtribute.Body;
                        break;
                    }
                //    ****************** NO SE BUSCA POR ESTOS CAMPOS ************************
                //case "IMAGE":
                //case "VARBINARY":  
                //case "BINARY":
                //   
            }
            return wTemplate.Replace(CommonConstants.CONST_TYPENAME, SQLServerType); ;
        }
        #endregion

    }
}
