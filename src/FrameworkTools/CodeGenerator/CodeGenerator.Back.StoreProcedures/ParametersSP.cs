//using System;
//using System.Text;
//using fwkDataEntities = Fwk.DataBase.DataEntities;
//using Fwk.CodeGenerator.Common;
//namespace CodeGenerator.Back.StoreProcedures
//{
//    public class ParametersSP
//    {

         
//        #region GetPatternSearchParametersSp_ExecuteSql
//        /// <summary>
//        /// Genera uns string con el Pattern para el campo de los parámetros utilizados como 3er parámetro pasado a sp_executesql.
//        /// </summary>
//        public static string GetPatternSearchParametersSp_ExecuteSql(fwkDataEntities.Column pColumn)
//        {

//            StringBuilder sbTipo = new StringBuilder("");
//            switch (pColumn.Type.Trim().ToUpper())
//            {
//                case "SMALLDATETIME":
//                case "DATETIME":
//                    sbTipo.AppendLine();
//                    sbTipo.Append("--@" + pColumn.Name + "Desde, ");
//                    sbTipo.AppendLine();
//                    sbTipo.Append("--@" + pColumn.Name + "Hasta, ");
//                    sbTipo.AppendLine();
//                    sbTipo.Append("@" + pColumn.Name + ", ");
//                    break;
//                default:
//                    sbTipo.Append("@" + pColumn.Name + ", ");
//                    break;
//            }
//            return sbTipo.ToString();

//        }
//        #endregion

//        #region GetPatternSearch
//        /// <summary>
//        /// Levanta el pattern para el tipo de dato del campo desde una archivo físico.
//        /// Pisa tags [NOMBRE_CAMPO],[NOMBRE_PARAMETRO_CAMPO],[NOMBRE_PARAMETRO_OPERADOR_CAMPO],
//        /// [NOMBRE_PARAMETRO_CAMPO_DESDE],[NOMBRE_PARAMETRO_CAMPO_HASTA],[PARAMETRO_SPEXECUTESQL]
//        /// y retorna el string actualizado.
//        /// </summary>
//        /// <returns>String actualizado.</returns>
//        public static string GetPatternSearch(Column pColumn)
//        {



//            string sbPatternSearch = GetTemplateSearch(pColumn);

//            sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_CAMPO>", pColumn.Name.Trim());
//            sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_PARAMETRO_CAMPO>", "@" + pColumn.Name.Trim());
//            sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_PARAMETRO_OPERADOR_CAMPO>", "@Ope" + pColumn.Name.Trim());
//            sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_PARAMETRO_CAMPO_DESDE>", "@" + pColumn.Name.Trim() + "Desde");
//            sbPatternSearch = sbPatternSearch.Replace("<NOMBRE_PARAMETRO_CAMPO_HASTA>", "@" + pColumn.Name.Trim() + "Hasta");

//            string parametros_spExecuteSql = "@" + pColumn.Name.Trim() + " " + pColumn.Length.ToString() + ",";

//            sbPatternSearch.Replace("<PARAMETRO_SPEXECUTESQL>", parametros_spExecuteSql);

//            return sbPatternSearch;
//        }
//        #endregion

//        #region Genera el Pattern
  
//        #endregion

//    }
//}
