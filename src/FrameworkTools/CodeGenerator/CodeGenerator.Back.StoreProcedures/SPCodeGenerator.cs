//using System;
//using System.Data;
//using System.Collections.Generic;
//using System.Text;
//using fwkDataEntities = Fwk.DataBase.DataEntities;
//using Fwk.CodeGenerator.Common;
//using System.Diagnostics;

//namespace CodeGenerator.Back.StoreProcedures
//{
//    /// <summary>
//    /// Generador de codigo especializado para generar Store procedures apartir de Objetos Tablas
//    /// </summary>
//    public class SPCodeGenerator : SPCodeGeneratorBase
//    {
        

//        #region [-- generación de código --]

//        protected override void GenCodeGetAll(MethodInfo pMethodInfo,string pActionCode, List<GeneratedCode> pProceduresCode)
//        {
//            StringBuilder wBuilder = null;
//            GeneratedCode wCode = null;
//            try
//            {
//                wBuilder = GenCodeCommon(pMethodInfo, pActionCode);
                
//                wBuilder.Replace("[Parameters]", string.Empty);
//                wBuilder.Replace("[SelectList]", GenCodeGetSelectList(pMethodInfo));
//                wBuilder.Replace(CommonConstants.CONST_DESCRIPTION, GetStoredProcedureDescription(pMethodInfo.Entity.Table.Name,<Template name=));
//                wBuilder.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, GetStoredProcedureName(pMethodInfo.Entity.Table.Name, pMethodInfo.Entity.Table.Schema, <Template name=));

//                wCode = new GeneratedCode();
//                wCode.Id = pMethodInfo.Entity.Name;
//                wCode.Code.Append(wBuilder.ToString());
//                wCode.MethodActionType = <Template name=;
//                pProceduresCode.Add(wCode);
//            }
//            finally
//            {
//                wBuilder = null;
//                wCode = null;
//            }

//        }
//        //protected  override void GenCodeGetByParam(MethodInfo pMethodInfo, string pActionCode, List<GeneratedCode> pProceduresCode)
//        //{
//        //    StringBuilder wBuilder = null;
//        //    GeneratedCode wCode = null;
//        //    String wIntermediateCode = String.Empty;
//        //    try
//        //    {
//        //        wBuilder = GenCodeCommon(pMethodInfo, pActionCode);
//        //        wIntermediateCode = "(" + GenCodeParameters(pMethodInfo) + ")" ;
//        //        wBuilder.Replace("[Parameters]", wIntermediateCode);
//        //        wBuilder.Replace("[SelectList]", GenCodeGetSelectList(pMethodInfo));
//        //        wBuilder.Replace("[WhereClause]", GenCodeWhereClause(pMethodInfo));
//        //        wBuilder.Replace(CommonConstants.CONST_DESCRIPTION, GetStoredProcedureDescription(pMethodInfo.Entity.Table.Name, <Template name=));
//        //        wBuilder.Replace(CommonConstants.CONST_StoredProcedure_NAME, GetStoredProcedureName(pMethodInfo.Entity.Table.Name, <Template name=));

//        //        wCode = new GeneratedCode();
//        //        wCode.Id = pMethodInfo.Entity.Name;
//        //        wCode.Code.Append(wBuilder.ToString());
//        //        wCode.MethodActionType = <Template name=;
//        //        pProceduresCode.Add(wCode);

//        //    }
//        //    finally
//        //    {
//        //        wBuilder = null;
//        //        wCode = null;
//        //    }
//        //}
//        protected override void GenCodeGetByParam(MethodInfo pMethodInfo, string pActionCode, List<GeneratedCode> pProceduresCode)
//        {
//            GeneratedCode wCode = null;

//            try
//            {
//                String wSPCode = GenerateStoreSearchByParam(pMethodInfo.Entity.Table);
                
//                wCode = new GeneratedCode();
//                wCode.Code.Append(wSPCode);
//                wCode.MethodActionType = <Template name=;
//                wCode.Id = pMethodInfo.Entity.Name;
//                pProceduresCode.Add(wCode);
                
//            }
//            finally
//            {
                
//                wCode = null;
//            }
//        }
//        protected override void GenCodeUpdate(MethodInfo pMethodInfo, string pActionCode, List<GeneratedCode> pProceduresCode)
//        {
//            StringBuilder wBuilder = null;
//            GeneratedCode wCode = null;
//            String wIntermediateCode = String.Empty;
//            try
//            {
//                wBuilder  = GenCodeCommon(pMethodInfo, pActionCode);

//                wIntermediateCode = "(" + GenCodeUpdateParameters(pMethodInfo) + ")";
//                wBuilder.Replace("[Parameters]", wIntermediateCode);
//                wBuilder.Replace("[SetStatements]", GenCodeUpdateSetStatements(pMethodInfo));
//                wBuilder.Replace("[WhereClause]", GenCodeWhereClause(pMethodInfo));
//                wBuilder.Replace(CommonConstants.CONST_DESCRIPTION, GetStoredProcedureDescription(pMethodInfo.Entity.Table.Name, <Template name=));
//                wBuilder.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, GetStoredProcedureName(pMethodInfo.Entity.Table.Name,pMethodInfo.Entity.Table.Schema, <Template name=));

//                //wCode = GetEntityGeneratedCode(pMethodInfo.Entity, pProceduresCode);
//                wCode = new GeneratedCode();
//                wCode.Id = pMethodInfo.Entity.Name;
//                wCode.Code.Append(wBuilder.ToString());
//                wCode.MethodActionType = <Template name=;
//                pProceduresCode.Add(wCode);

//            }
//            finally
//            {
//                wBuilder = null;
//                wCode = null;
//            }
//        }
//        protected override void GenCodeDelete(MethodInfo pMethodInfo, string pActionCode, List<GeneratedCode> pProceduresCode)
//        {

//            StringBuilder wBuilder = null;
//            GeneratedCode wCode = null;
//            String wIntermediateCode = String.Empty;
//            try
//            {
//                wBuilder = new StringBuilder();

//                wBuilder = GenCodeCommon(pMethodInfo, pActionCode);
//                wIntermediateCode = "(" + GenCodeDeleteParameters(pMethodInfo) + ")";
//                wBuilder.Replace("[Parameters]", wIntermediateCode);
//                wBuilder.Replace("[WhereClause]", GenCodeWhereClause(pMethodInfo));
//                wBuilder.Replace(CommonConstants.CONST_DESCRIPTION, GetStoredProcedureDescription(pMethodInfo.Entity.Table.Name, <Template name=));
//                wBuilder.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, GetStoredProcedureName(pMethodInfo.Entity.Table.Name,pMethodInfo.Entity.Table.Schema, <Template name=));

//                //wCode = GetEntityGeneratedCode(pMethodInfo.Entity, pProceduresCode);
//                wCode = new GeneratedCode();
//                wCode.Id = pMethodInfo.Entity.Name;
//                wCode.Code.Append(wBuilder.ToString());
//                wCode.MethodActionType = <Template name=;
//                pProceduresCode.Add(wCode);
//            }
//            finally
//            {
//                wBuilder = null;
//                wCode = null;
//            }
//        }
//        protected override void GenCodeInsert(MethodInfo pMethodInfo, string pActionCode, List<GeneratedCode> pProceduresCode)
//        {

//            StringBuilder wBuilder = null;
//            GeneratedCode wCode = null;
//            String wIntermediateCode = String.Empty;
//            try
//            {
//                wBuilder = new StringBuilder();

//                wBuilder = GenCodeCommon(pMethodInfo, pActionCode);
//                wIntermediateCode = "(" + GenCodeInsertParameters(pMethodInfo) + ")";
//                wBuilder.Replace("[Parameters]", wIntermediateCode);
//                wBuilder.Replace("[Fields]", GenCodeInsertFields(pMethodInfo));
//                wBuilder.Replace("[Values]", GenCodeInsertValues(pMethodInfo));
//                wBuilder.Replace("[ReturnAutogenerated]", GenCodeInsertReturnAutogenerated(pMethodInfo));
//                wBuilder.Replace(CommonConstants.CONST_DESCRIPTION, GetStoredProcedureDescription(pMethodInfo.Entity.Table.Name, <Template name=));
//                wBuilder.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, GetStoredProcedureName(pMethodInfo.Entity.Table.Name, pMethodInfo.Entity.Table.Schema, <Template name=));
                
//                //wCode = GetEntityGeneratedCode(pMethodInfo.Entity, pProceduresCode);
//                wCode = new GeneratedCode();

//                wCode.Id = pMethodInfo.Entity.Name;
//                wCode.Code.Append(wBuilder.ToString());
//                wCode.MethodActionType = <Template name=;
//                pProceduresCode.Add(wCode);
//            }
//            finally
//            {
//                wBuilder = null;
//                wCode = null;
//            }
//        }
//        protected override string GenCodeWhereClause(MethodInfo pMethodInfo)
//        {
//            StringBuilder wBuilder = new StringBuilder();

//            if (pMethodInfo.BuiltIn)
//            {
//                foreach (fwkDataEntities.Column wColumn in pMethodInfo.Entity.Table.Columns)
//                {
//                    if (wColumn.Autogenerated || wColumn.KeyField)
//                    {
//                        wBuilder.Append(wColumn.Name);
//                        wBuilder.Append(" = ");
//                        wBuilder.Append(DBTypesMappingSection.Current.ParameterToken);
//                        wBuilder.Append(wColumn.Name);
//                        wBuilder.Append(" AND \r\n");
//                    }
//                }
//            }
//            else
//            {
//                foreach (ParameterInfo wParameterInfo in pMethodInfo.Parameters)
//                {
//                    wBuilder.Append(wParameterInfo.Name);
//                    wBuilder.Append(" = ");
//                    wBuilder.Append(DBTypesMappingSection.Current.ParameterToken);
//                    wBuilder.Append(wParameterInfo.Name);
//                    wBuilder.Append(" AND \r\n");
//                }
//            }



//            base.RemoveChars(wBuilder, 6);

//            return wBuilder.ToString();
//        }
//        #endregion  



//        #region -- auxiliares get --

//        /// <summary>
//        /// Genera código de parámetros de un procedimiento almacenado de Búsqueda por clave primaria.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente generado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected override string GenCodeParameters(MethodInfo pMethodInfo)
//        {

//            StringBuilder wBuilder = new StringBuilder();

//            if (<Template name= == MethodActionType.Get)
//            {
//                foreach (fwkDataEntities.Column wColumn in pMethodInfo.Entity.Table.Columns)
//                {
//                    if (wColumn.KeyField && wColumn.Selected)
//                    {
//                        StringBuilder wParamBuilder = this.BuildParameter(wColumn, <Template name=, false, false);
//                        wBuilder.Append(wParamBuilder.ToString());
//                    }
//                }
//            }
//            else
//            {
//                foreach (ParameterInfo wParameterInfo in pMethodInfo.Parameters)
//                {
                   
//                    StringBuilder wParamBuilder = base.BuildParameter(wParameterInfo);
//                    wBuilder.Append(wParamBuilder.ToString());
//                }
//            }

//            RemoveChars(wBuilder, 3);

//            return wBuilder.ToString();

//        }

//        /// <summary>
//        /// Genera código de campos de retorno de un procedimiento almacenado de Búsqueda.
//        /// Genera los campos del SELECT
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente generado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected override  string GenCodeGetSelectList(MethodInfo pMethodInfo)
//        {
//            StringBuilder wBuilder = new StringBuilder();

//            foreach (fwkDataEntities.Column wColumn in pMethodInfo.Entity.Table.Columns)
//            {
//                if (wColumn.Selected)
//                {
//                    //wBuilder.Append("\t");
//                    wBuilder.AppendLine(wColumn.Name);
//                    wBuilder.Append(",");
//                }
//            }

//            RemoveChars(wBuilder, 2);

//            return wBuilder.ToString();
//        }

  
//        #endregion


//        #region -- auxiliares Insert --

//        protected override string GenCodeInsertParameters(MethodInfo pMethodInfo)
//        {
//            StringBuilder wBuilder = new StringBuilder();

//            foreach (fwkDataEntities.Column wTableFieldInfo in pMethodInfo.Entity.Table.Columns)
//            {
//                if (IsColumnValidToInsert(wTableFieldInfo) && wTableFieldInfo.Selected)
//                {
//                    StringBuilder wParamBuilder = base.BuildParameter(wTableFieldInfo, <Template name=, true, true);
//                    wBuilder.Append(wParamBuilder.ToString());
//                }
//            }
//            RemoveChars(wBuilder, 3);
//            return wBuilder.ToString();
//        }

//        /// <summary>
//        /// Determina si la columna es de tipo valido para pasar como parametro a un SP.-
//        /// </summary>
//        /// <param name="pColumn"></param>
//        /// <returns></returns>
//        private bool IsColumnValidToInsert(fwkDataEntities.Column pColumn)
//        {
//            return !_NotSupportTypesToInsertStoreProcedure.Contains(pColumn.Type.ToLower());
//        }
//        /// <summary>
//        /// Determina si la columna es de tipo valido para pasar como parametro a un SP busqueda.-
//        /// </summary>
//        /// <param name="pColumn">Columna</param>
//        /// <returns>bool</returns>
//        /// <author>Marcelo Oviedo</author>
//        private bool IsColumnValidToSearch(fwkDataEntities.Column pColumn)
//        {
//            return !_NotSupportTypesToSearchInStoreProcedure.Contains(pColumn.Type.ToLower());
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pMethodInfo"></param>
//        /// <returns></returns>
//        /// <author>Marcelo Oviedo</author>
//        protected override string GenCodeInsertFields(MethodInfo pMethodInfo)
//        {
//            StringBuilder wBuilder = new StringBuilder();

//            foreach (fwkDataEntities.Column wColumn in pMethodInfo.Entity.Table.Columns)
//            {
//                if (!wColumn.Autogenerated && wColumn.Selected && IsColumnValidToInsert(wColumn))
//                {
//                    wBuilder.AppendLine (wColumn.Name);
//                    wBuilder.Append(",");
//                }
//            }

//            RemoveChars(wBuilder, 2);

//            return wBuilder.ToString();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pMethodInfo"></param>
//        /// <returns></returns>
//        /// <author>Marcelo Oviedo</author>
//        protected override string GenCodeInsertValues(MethodInfo pMethodInfo)
//        {
//            StringBuilder wBuilder = new StringBuilder();

//            foreach (fwkDataEntities.Column wColumn in pMethodInfo.Entity.Table.Columns)
//            {
//                if (!wColumn.Autogenerated && wColumn.Selected && IsColumnValidToInsert(wColumn))
//                {
//                    wBuilder.Append("\t");
//                    wBuilder.Append(DBTypesMappingSection.Current.ParameterToken);
//                    wBuilder.Append(wColumn.Name);
//                    wBuilder.Append(",\r\n");
//                }
//            }

//            RemoveChars(wBuilder, 3);

//            return wBuilder.ToString();
//        }
//        ///TODO: Ver si se utiliza esto
//        protected override string GenCodeInsertReturnAutogenerated(MethodInfo pMethodInfo)
//        {
//            StringBuilder wBuilder = new StringBuilder();
//            string wText = string.Empty;

//            foreach (fwkDataEntities.Column wColumn in pMethodInfo.Entity.Table.Columns)
//            {
//                if (wColumn.Autogenerated)
//                {
//                    wBuilder.Append(DBTypesMappingSection.Current.ParameterToken);
//                    wBuilder.Append(wColumn.Name);

//                    //wText = Properties.Settings.Default.GetReturnAutogeneratedPattern.Replace("[Name]", wBuilder.ToString());
//                    break;
//                }
//            }

//            string wOutputIdentitySet = _StoredProcedureTemplate.Keys.GetKey("OutputIdentitySet").TemplateAtribute.Body;
//            if (wBuilder.Length == 0)
//                return String.Empty;
//            else
//                return wOutputIdentitySet.Replace("[OutputVariable]", wBuilder.ToString());
//        }

//        #endregion


//        #region -- auxiliares delete --

//        /// <summary>
//        /// Genera código de parámetros de un procedimiento almacenado de borrado.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente generado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected override  string GenCodeDeleteParameters(MethodInfo pMethodInfo)
//        {
//            StringBuilder wBuilder = new StringBuilder();

//            foreach (fwkDataEntities.Column wColumn in pMethodInfo.Entity.Table.Columns)
//            {
//                if (wColumn.KeyField && wColumn.Selected)
//                {
//                    StringBuilder wParamBuilder = BuildParameter(wColumn, <Template name=, false, false);
//                    wBuilder.Append(wParamBuilder.ToString());
//                }
//            }

//            RemoveChars(wBuilder, 3);

//            return wBuilder.ToString();
//        }

//        #endregion


//        #region -- auxiliares update --

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pMethodInfo"></param>
//        /// <returns>string</returns>
//        /// <author>Marcelo Oviedo</author>
//        protected override string GenCodeUpdateParameters(MethodInfo pMethodInfo)
//        {
//            StringBuilder wBuilder = new StringBuilder();

//            foreach (fwkDataEntities.Column wColumn in pMethodInfo.Entity.Table.Columns)
//            {
//                if (wColumn.Selected && IsColumnValidToInsert(wColumn))
//                {
//                    StringBuilder wParamBuilder = BuildParameter(wColumn, <Template name=, false, true);
//                    wBuilder.Append(wParamBuilder.ToString());
//                }
//            }

//            RemoveChars(wBuilder, 3);

//            return wBuilder.ToString();
//        }

//        /// <summary>
//        /// Genera el listado de campos para el update 
//        /// </summary>
//        /// <param name="pMethodInfo"></param>
//        /// <returns>string</returns>
//        /// <author>Marcelo Oviedo</author>
//        protected override string GenCodeUpdateSetStatements(MethodInfo pMethodInfo)
//        {
//            StringBuilder wBuilder = new StringBuilder();

//            foreach (fwkDataEntities.Column wColumn in pMethodInfo.Entity.Table.Columns)
//            {
//                if (!(wColumn.Autogenerated || wColumn.KeyField) && wColumn.Selected)
//               {
//                    wBuilder.Append(wColumn.Name);
//                    wBuilder.Append(" = ");
//                    wBuilder.Append(DBTypesMappingSection.Current.ParameterToken);
//                    wBuilder.Append(wColumn.Name);
//                    wBuilder.Append(",\r\n");
//                }
//            }

//            RemoveChars(wBuilder, 3);

//            return wBuilder.ToString();
//        }

//        #endregion


//        #region Genera el Store Procedure GetAll
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pTable"></param>
//        /// <returns></returns>
//        private static string GenerarStoreGetAll(fwkDataEntities.Table pTable)
//        {

            

//            //----------------------------------------------------------------------
//            //-- Cargo el contenido de la Definicion global para Store GetAll
//            //----------------------------------------------------------------------
//            String wSPPatternWitchExecutesql  = _StoredProcedureTemplate.Keys.GetKey ("Search_DefinicionGlobal").TextContent;
            
//            try
//            {
   
//                wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace(CommonConstants.CONST_AUTHOR, Environment.UserName);
//                wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace(CommonConstants.CONST_CREATION_DATETIME, DateTime.Now.ToString());

//                #region Nombre del SP
//                //Patron de nombres de SP 
//                string wSpNamePattern = _StoredProcedureTemplate.Keys.GetKey ("Get").TemplateAtribute.Name;
//                ///Nombre del Store procedure 
//                wSpNamePattern = wSpNamePattern.Replace(CommonConstants.CONST_TABLE_NAME, pTable.Name);
//                Debugger.Break();
//                wSPPatternWitchExecutesql.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, wSpNamePattern);
//                #endregion

//                //-- Reemplazo en Select * From [TableName]
//                wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace(CommonConstants.CONST_TABLE_NAME, pTable.Name);
               
//                //if (false)
//                //    wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace("<WITH_NO_LOCK>", "WITH (NOLOCK)");
//                //else
//                    wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace("<WITH_NO_LOCK>", String.Empty);

//                return wSPPatternWitchExecutesql;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }

//        }
//        #endregion

//        #region Genera el Store Procedure GetAll By param

//        /// <summary>
//        /// Genera el script del sp para obtener por parametros (GetAll By param)
//        /// </summary>
//        /// <param name="pTable"></param>
//        /// <returns></returns>
//        /// <author>Marcelo Oviedo</author>
//        private  string GenerateStoreSearchByParam(fwkDataEntities.Table pTable)
//        {
             
//            StringBuilder wSPPatternWitchExecutesql = new StringBuilder ();
//            StringBuilder sbNombreCampo = new StringBuilder();
//            StringBuilder sbParametros = new StringBuilder();
//            StringBuilder sbParametrosTipo = new StringBuilder();
//            StringBuilder sbParametrosSolo = new StringBuilder();
//            StringBuilder sbCampos = new StringBuilder();
//            Boolean wAnyParameterToSelec = false;
//            string szParametro = String.Empty;
           
           
//            //----------------------------------------------------------------------
//            //-- Cargo el contenido de la Definicion global para Store Search
//            //----------------------------------------------------------------------
//            wSPPatternWitchExecutesql.Append(_CommonTemplateExecuteSQL);

//            try
//            {
//                 wSPPatternWitchExecutesql.Replace(CommonConstants.CONST_AUTHOR, Environment.UserName);
//                 wSPPatternWitchExecutesql.Replace(CommonConstants.CONST_CREATION_DATETIME, DateTime.Now.ToString());
                
               
//                #region Nombre del SP
//                //Patron de nombres de SP 
//                 string wSpName = SPCodeGeneratorBase.GetStoredProcedureName(pTable.Name,pTable.Schema, MethodActionType.GetByParam);

//                ///Nombre del Store procedure 
//                wSpName = wSpName.Replace(CommonConstants.CONST_TABLE_NAME, pTable.Name);
//                wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, wSpName);
//                #endregion

//                #region -- Recorro la coleccion Campos que se haya SELECCIONADO 
          
               
//                foreach (fwkDataEntities.Column wColumn in pTable.Columns)
//                {
//                    //-- Por el momento no podemos buscar por campos XML, IMAGE, TIMESTAMP

//                    if (wColumn.Selected && IsColumnValidToSearch(wColumn))
//                    {
//                        wAnyParameterToSelec = true;
//                        ///TODO: Ver tema fechas
//                        if (wColumn.Type.ToUpper().Contains("DATETIME"))
//                        {
//                            //Solo  para parametros tipo fechas ya que se atiende de manera especial este tipo de dato.-
//                            szParametro =
//                                base.BuildParameter(wColumn, MethodActionType.GetByParam, true, true).Replace(
//                                    wColumn.Name, wColumn.Name + "Desde").ToString();
//                            szParametro += Environment.NewLine;
//                            szParametro +=
//                                base.BuildParameter(wColumn, MethodActionType.GetByParam, true, true).Replace(
//                                    wColumn.Name, wColumn.Name + "Hasta").ToString();
//                            szParametro =
//                                szParametro.Replace(DBTypesMappingSection.Current.ParameterToken,
//                                                    "--" + DBTypesMappingSection.Current.ParameterToken);

//                            szParametro +=
//                                base.BuildParameter(wColumn, MethodActionType.GetByParam, true, true).ToString();
//                        }
//                        else
//                        {
//                            szParametro =
//                                base.BuildParameter(wColumn, MethodActionType.GetByParam, true, true).ToString();
//                        }

//                        sbParametros.AppendLine(szParametro);

//                        sbParametrosTipo.AppendLine(szParametro);


//                        sbParametrosSolo.Append(ParametersSP.GetPatternSearchParametersSp_ExecuteSql(wColumn));

//                        //-- Levanto el Pattern correspondiente a este tipo de campo
//                        //-------------------------------------------------------------
//                        sbCampos.AppendLine(ParametersSP.GetPatternSearch(wColumn));
//                    }
//                }
//                #endregion

//                if (wAnyParameterToSelec)
//                {
//                    //--------------------------------------------------------
//                    //-- Replazo los parámetros
//                    //--------------------------------------------------------
//                    wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace("<PARAMETROS>", sbParametros.ToString().TrimEnd().Remove(sbParametros.ToString().TrimEnd().Length - 1, 1));
//                    wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace("<PARAMETROS_TIPO>", sbParametrosTipo.ToString().TrimEnd().Remove(sbParametrosTipo.ToString().TrimEnd().Length - 1, 1));
//                    wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace("<PARAMETROS_SOLO>", sbParametrosSolo.ToString().TrimEnd().Remove(sbParametrosSolo.ToString().TrimEnd().Length - 1, 1));

//                    //-- Reemplado en Select * From [TableName]
//                    wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace(CommonConstants.CONST_TABLE_NAME, pTable.Name);

//                    wSPPatternWitchExecutesql = wSPPatternWitchExecutesql.Replace("<CAMPOS>", sbCampos.ToString());

//                    //if (false)
//                    //    wSPPatternWitchExecutesql.Replace("<WITH_NO_LOCK>", "WITH (NOLOCK)");
//                    //else
//                    wSPPatternWitchExecutesql.Replace("<WITH_NO_LOCK>", String.Empty);

//                }
//                else
//                {
//                    wSPPatternWitchExecutesql.Remove(0, wSPPatternWitchExecutesql.Length);
//                    wSPPatternWitchExecutesql.Append("El SP :");
//                    wSPPatternWitchExecutesql.Append(wSpName);
//                    wSPPatternWitchExecutesql.AppendLine(" no se pudo crear debido a que no tiene campos seleccionados");
//                    wSPPatternWitchExecutesql.AppendLine("de la tabla ");
//                    wSPPatternWitchExecutesql.Append(pTable.Name);
//                    wSPPatternWitchExecutesql.AppendLine(" que son validos para efectuar una busqueda");
//                }

//                return wSPPatternWitchExecutesql.ToString();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }

//        }
//        #endregion



     
        
//    }













    

//}
