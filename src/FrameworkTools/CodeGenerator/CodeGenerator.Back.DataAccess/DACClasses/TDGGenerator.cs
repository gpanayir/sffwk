//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;

//using System.Windows.Forms;
//using Fwk.CodeGenerator.Common;

//namespace CodeGenerator.Back.DataAccess 
//{
//    /// <summary>
//    /// Clase para generar código fuente de table data gateways.
//    /// </summary>
//    /// <remarks>
//    /// Hace uso de templates para efectuar reemplazos en tags. Crea una clase y sus métodos.
//    /// </remarks>
//    /// <date>2006-03-21T00:00:00</date>
//    /// <author>Marcelo Oviedo</author>
//    public class TDGGenerator
//    {
//        static Template _CodeGeneratorTemplate = null;
//        static Template _TDGTemplate = null;
//        static Template _PatternsTemplate = null;
//        static EntityGenerationInfo _EntityGenerationInfo = null;
//        private static string _NotSupportTypes_ToInsertStoreProcedure = String.Empty;
//        private static string _NotSupportTypes_ToSearchInStoreProcedure = String.Empty;
//        public static EntityGenerationInfo EntityGenerationInfo
//        {
//            get { return _EntityGenerationInfo; }
//            set
//            {
//                _EntityGenerationInfo = value;
//                AplicationBlockTDG.TemplateSettingObject = _EntityGenerationInfo.TemplateSettingObject;
//            }
//        }
     
//        static TDGGenerator()
//        {
//            _TDGTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.TDGTemplate);
//            _CodeGeneratorTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.CodeGenerator);
//            _PatternsTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.Patterns);

//             _NotSupportTypes_ToInsertStoreProcedure =
//            TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.NotSupportTypes).Keys.GetKey(
//                "ToInsertStoreProcedure").TextContent;
//             _NotSupportTypes_ToSearchInStoreProcedure =
//                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.NotSupportTypes).Keys.GetKey(
//                    "ToSearchInStoreProcedure").TextContent;
   
//        }
//        #region [Public methods]
//        /// <summary>
//        /// Inicia la generación del código fuente de un table data gateway.
//        /// </summary>
//        /// <param name="pEntityGenerationInfo">información de generación de entidad para creación de la table data gateway.</param>
//        /// <returns>Código fuente.</returns>
//        /// <date>2006-03-21T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        public static TreeNode GenCode()
//        {
//            List<GeneratedCode> wGeneratedCodeResult = new List<GeneratedCode>();
//            foreach (EntityInfo pEntityInfo in _EntityGenerationInfo.Entities)
//            {
//                GenClass(pEntityInfo, wGeneratedCodeResult);
//            }
      
//            return BuildTDGTreeNode(wGeneratedCodeResult);
//        }

//        #endregion

//        #region [Private methods]

//        private static TreeNode BuildTDGTreeNode(List<GeneratedCode> pGeneratedCodeResult)
//        {
//            TreeNode wTreeNodeTDG = new TreeNode("TDG");
//            foreach (GeneratedCode wGeneratedCode in pGeneratedCodeResult)
//            {
//                TreeNode wTreeNode = new TreeNode(wGeneratedCode.Id);
//                wTreeNode.Text = wGeneratedCode.Id;
//                wTreeNode.Tag = wGeneratedCode;

//                wTreeNodeTDG.Nodes.Add(wTreeNode);

//            }
//            return wTreeNodeTDG;
//        }
//        /// <summary>
//        /// Genera código fuente de un table data gateway.
//        /// </summary>
//        /// <param name="pEntityInfo">Entidad principal.</param>
//        /// <param name="pEntityNamespace">Namespace de entidades de negocio.</param>
//        /// <param name="pTDGNamespace">Namespace de componentes de table data gateway.</param>
//        /// <param name="pTDGCode">Código para ejecución de llamadas al repositorio de datos.</param>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        private static void GenClass(EntityInfo pEntityInfo, List<GeneratedCode> pTDGCode)
//        {
//            StringBuilder wBuilder = null;
//            StringBuilder wMethodBuilder = null;
//            GeneratedCode wCode = null;

//            try
//            {
//                wBuilder = new StringBuilder(_CodeGeneratorTemplate.Keys.GetKey("Signature").TextContent);

//                wBuilder.Append(_TDGTemplate.Keys.GetKey("Class").TextContent);
//                wMethodBuilder = new StringBuilder();

//                foreach (MethodInfo wMethodInfo in pEntityInfo.Methods)
//                {

//                    wMethodBuilder.Append(GenMethod(wMethodInfo));
//                    if (wMethodInfo.PerformBatch)
//                    {
//                        if (wMethodInfo.Entity.Table == null)
//                        {
//                            wMethodBuilder.Append(AplicationBlockTDG.GetBatchFromSP(wMethodInfo));
//                        }
//                        else
//                        {
//                            wMethodBuilder.Append(AplicationBlockTDG.GetBatchFromTable(wMethodInfo));
//                        }
//                    }
//                }

//                wBuilder.Replace("[Methods]", wMethodBuilder.ToString());
//                wBuilder.Replace("[TDGName]", _TDGTemplate.Keys.GetKey("Name").TextContent);
//                wBuilder.Replace(CommonConstants.CONST_CREATION_DATETIME, string.Format("{0:s}", DateTime.Now));
//                wBuilder.Replace(CommonConstants.CONST_AUTHOR, System.Environment.UserName);
//                wBuilder.Replace(CommonConstants.CONST_ENTITY_NAME, pEntityInfo.Name);
//                wBuilder.Replace(CommonConstants.CONST_NAMESPACE_BE_DE, EntityGenerationInfo.TemplateSettingObject.Namespaces.BusinessEntities);
//                wBuilder.Replace(CommonConstants.CONST_NAMESPACE_TDG, EntityGenerationInfo.TemplateSettingObject.Namespaces.DataAccessComponent);
//                wBuilder.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX, _EntityGenerationInfo.TemplateSettingObject.Entities.EntitySufix);
//                wBuilder.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION, _EntityGenerationInfo.TemplateSettingObject.Entities.CollectionsSufix);
//                if (_EntityGenerationInfo.TemplateSettingObject.OthersSettings.ConnectionStringKey.Trim().Length != 0)

//                    wBuilder.Replace(CommonConstants.CONST_BACK_CnnStringKey, "\"" + _EntityGenerationInfo.TemplateSettingObject.OthersSettings.ConnectionStringKey +"\"");
//                else
//                    wBuilder.Replace(CommonConstants.CONST_BACK_CnnStringKey, String.Empty);


//                wCode = new GeneratedCode();
//                wCode.Id = pEntityInfo.Name;
//                wCode.Code.Append(wBuilder.ToString());

//                pTDGCode.Add(wCode);

//            }
//            finally
//            {
//                wBuilder = null;
//                wMethodBuilder = null;
//                wCode = null;
//            }
//        }

//        /// <summary>
//        /// Genera código de un método del table data gateway.
//        /// </summary>
//        /// <param name="pMethodInfo">información sobre el método a generar.</param>
//        /// <returns>Código fuente del método.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        private static string GenMethod(MethodInfo pMethodInfo)
//        {
//            StringBuilder wBuilder = null;
//            String wSPName;
//            try
//            {
//                wBuilder = new StringBuilder(_TDGTemplate.Keys.GetKey ("Method").TextContent );

				

//                if (pMethodInfo.ReturnType == MethodReturnType.Void)
//                {
//                    wBuilder.Replace("[RetType]", "void");
//                }
//                else
//                {
//                    wBuilder.Replace("[RetType]", "DataSet");
//                }

//                wBuilder.Replace(CommonConstants.CONST_BACK_END_METHOD_NAME, pMethodInfo.Name);
//                wBuilder.Replace("[ParamArgs]", GenMethodParameters(pMethodInfo, false));
//                wSPName = BaseGenTDG.GetStoredProcedureName(pMethodInfo, _EntityGenerationInfo.TemplateSettingObject); 
                
//                if (pMethodInfo.BuiltIn)
//                {
//                    if (pMethodInfo.Entity.Table == null)
//                    {
//                        wBuilder.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, wSPName.Replace(CommonConstants.CONST_TABLE_NAME, pMethodInfo.Entity.StoredProcedure.Name));
//                        wBuilder.Replace("[Schema]", pMethodInfo.Entity.Table.Schema);
//                    }
//                    else
//                    {
//                        wBuilder.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, wSPName.Replace(CommonConstants.CONST_TABLE_NAME, pMethodInfo.Entity.Table.Name));
//                        wBuilder.Replace("[Schema]", pMethodInfo.Entity.Table.Schema);
//                    }
//                }
//                else
//                {
//                    wBuilder.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, pMethodInfo.ProcedureName);
//                }

//                wBuilder.Replace("[Parameters]", GenProcedureParameters(pMethodInfo));
//                wBuilder.Replace(CommonConstants.CONST_BACK_END_RETURN, GenReturn(pMethodInfo));

//                wBuilder.Replace("[SummaryParams]", GenParametersSummary(pMethodInfo));

                
//                return wBuilder.ToString();

//            }
//            finally
//            {
//                wBuilder = null;
//            }

//        }
        
//        /// <summary>
//        /// Genera código de un método del table data gateway.
//        /// </summary>
//        /// <param name="pMethodInfo">información sobre el método a generar.</param>

//        /// <returns>Código fuente del método.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        private static string GenBatchMethod(MethodInfo pMethodInfo)
//        {

//            return AplicationBlockTDG.GetBatchFromTable(pMethodInfo);
//        }

//        /// <summary>
//        /// Genera comentarios sobre los parámetros de un método.
//        /// </summary>
//        /// <param name="pMethodInfo">información sobre el método a generar.</param>
//        /// <returns>Comentarios sobre los parámetros.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        private static string GenParametersSummary(MethodInfo pMethodInfo)
//        {
//            StringBuilder wBuilder = null;
//            try
//            {
//                wBuilder = new StringBuilder();
//                if (pMethodInfo.ParameterType == MethodParameterType.SimpleValues)
//                {
//                    foreach (ParameterInfo wParameterInfo in pMethodInfo.Parameters)
//                    {
//                        wBuilder.Append(_TDGTemplate.Keys.GetKey ("ParameterSummary").TextContent );
//                        wBuilder.Replace("[MethodParameterName]", _TDGTemplate.Keys.GetKey ("MethodParameterName").TextContent );
//                        wBuilder.Replace("[ParameterName]", wParameterInfo.Name);
//                    }
//                }
//                else
//                {
//                    wBuilder.Append(_TDGTemplate.Keys.GetKey ("ParameterSummary").TextContent );
//                    wBuilder.Replace("[MethodParameterName]", _TDGTemplate.Keys.GetKey ("MethodParameterName").TextContent );
//                    wBuilder.Replace("[ParameterName]", _PatternsTemplate.Keys.GetKey("NamePattern").TextContent.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name));
//                }
//                return wBuilder.ToString();
//            }
//            finally
//            {
//                wBuilder = null;
//            }
//        }


//        /// <summary>
//        /// Genera código relacionado con las instrucciones de retorno de valores de un método.
//        /// </summary>
//        /// <param name="pMethodInfo">información sobre el método a generar.</param>
//        /// <returns>Código de instrucciones de retorno.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        private static string GenReturn(MethodInfo pMethodInfo)
//        {
//            StringBuilder wQueryBuilder = null;
//            StringBuilder wBuilder = null;

//            try
//            {
//                wQueryBuilder = new StringBuilder();
//                wQueryBuilder.Append("Return");
//                wQueryBuilder.Append(Enum.GetName(typeof(MethodReturnType), pMethodInfo.ReturnType));


//                wBuilder = new StringBuilder();
//                wBuilder.Append(_TDGTemplate.Keys.GetKey (wQueryBuilder.ToString()).TextContent );

//                //TODO: Reemplazo de nombre de sp en generación de tdg
//                if (pMethodInfo.BuiltIn)
//                {
//                    if (pMethodInfo.Entity.Table == null)
//                    {
//                        wBuilder.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, TemplateProvider.GetStoredProcedureTemplate(pMethodInfo.Action).Name.Replace(CommonConstants.CONST_TABLE_NAME, pMethodInfo.Entity.StoredProcedure.Name));
//                    }
//                    else
//                    {
//                        wBuilder.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, TemplateProvider.GetStoredProcedureTemplate(pMethodInfo.Action).Name.Replace(CommonConstants.CONST_TABLE_NAME, pMethodInfo.Entity.Table.Name));
//                    }

                    
//                }
//                else
//                {
//                    wBuilder.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, pMethodInfo.ProcedureName);
//                }

//                wBuilder.Replace("[OutParameterMappings]", GenOutParameterMappings(pMethodInfo));
//                wBuilder.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name);

//                return wBuilder.ToString();

//            }
//            finally
//            {
//                wQueryBuilder = null;
//                wBuilder = null;
//            }

			

//        }

//        /// <summary>
//        /// Genera código de parámetros para llamados a procedimientos almancenados.
//        /// </summary>
//        /// <param name="pMethodInfo">información sobre el método a generar.</param>
//        /// <returns>Código parámetros.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        private static string GenProcedureParameters(MethodInfo pMethodInfo)
//        {
//            StringBuilder wQueryBuilder = null;
//            StringBuilder wBuilder = null;

//            try
//            {
//                wQueryBuilder = new StringBuilder();
//                wBuilder = new StringBuilder();

//                foreach (ParameterInfo wParameterInfo in pMethodInfo.Parameters)
//                {
//                    if (wParameterInfo.Selected && IsParameterInfoValid(wParameterInfo.Type, pMethodInfo.Action))
//                    {
//                        wQueryBuilder.Remove(0, wQueryBuilder.Length);
//                        wQueryBuilder.Append("Parameter");
//                        wQueryBuilder.Append(Enum.GetName(typeof(ParameterDirection), wParameterInfo.Direction));
//                        wBuilder.Append(_TDGTemplate.Keys.GetKey(wQueryBuilder.ToString()).TextContent);
//                        wBuilder.Replace("[ParameterName]", wParameterInfo.Name);
//                        wBuilder.Replace("[ParameterType]", ParametersDAC.GetTargetDBType(wParameterInfo.Type));
//                        wBuilder.Replace("[ParameterLength]", wParameterInfo.Length.ToString());
//                        wBuilder.Replace("[ParameterValue]", GetParameterValue(wParameterInfo));
//                    }
					
//                }

//                return wBuilder.ToString();
//            }
//            finally
//            {
//                wBuilder = null;
//            }

//        }
       

//        /// <summary>
//        /// Determina si la columna es de tipo valido para pasar como parametro desde la TDG a un SP busqueda.-
//        /// </summary>
//        /// <param name="pType">Tipo de parametro</param>
//        ///  <param name="pMethodActionType">Tipo de metodo</param>
//        /// <returns>bool</returns>
//        private static bool IsParameterInfoValid(String pType, MethodActionType pMethodActionType)
//        {
        

//            if (pMethodActionType == MethodActionType.Insert || pMethodActionType == MethodActionType.Update)
//            {

//                if (_NotSupportTypes_ToInsertStoreProcedure.Contains(pType.ToLower()))
//                    return false;
//            }
//            if (pMethodActionType == MethodActionType.GetByParam)
//            {
//                if(_NotSupportTypes_ToSearchInStoreProcedure.Contains(pType.ToLower()))
//                    return false;

//            }
//            return true;
//        }

//        /// <summary>
//        /// Genera código de asignación de valores a parámetros de procedimientos almacenados.
//        /// </summary>
//        /// <param name="pParameterInfo">información sobre el parámetro.</param>
//        /// <returns>Código de asignación de parámetros.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        private static string GetParameterValue(ParameterInfo pParameterInfo)
//        {
//            StringBuilder wBuilder = null;

//            try
//            {
//                wBuilder = new StringBuilder();

//                wBuilder.Append(_TDGTemplate.Keys.GetKey ("MethodParameterName").TextContent );
				
//                //TODO: Generacion de parametros para sp que reciben be
//                if (pParameterInfo.Method.ParameterType == MethodParameterType.SimpleValues)
//                {
//                    wBuilder.Replace("[ParameterName]", pParameterInfo.Name);
//                }
//                else
//                {
//                    wBuilder.Replace("[ParameterName]", _PatternsTemplate.Keys.GetKey ("NamePattern").TextContent.Replace(CommonConstants.CONST_ENTITY_NAME, pParameterInfo.Method.Entity.Name));
//                    wBuilder.Append(".");
//                    wBuilder.Append(pParameterInfo.Name);
//                }

//                return wBuilder.ToString();
//            }
//            finally
//            {
//                wBuilder = null;
//            }
//        }

//        /// <summary>
//        /// Genera código de parámetros de llamado a un método.
//        /// </summary>
//        /// <param name="pMethodInfo">información sobre el método a generar.</param>
//        /// <returns>Código que representa los parámetros para ejecutar el método.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        private static string GenMethodParameters(MethodInfo pMethodInfo,bool pPerformBatch)
//        {
//            StringBuilder wBuilder = null;
//            StringBuilder wParamBuilder = null;

//            try
//            {
//                wBuilder = new StringBuilder();

//                if (pMethodInfo.ParameterType == MethodParameterType.SimpleValues)
//                {
//                    foreach (ParameterInfo wParameterInfo in pMethodInfo.Parameters)
//                    {
//                        if (wParameterInfo.Selected)
//                        {
//                            wParamBuilder = new StringBuilder();
//                            wParamBuilder.Append(_TDGTemplate.Keys.GetKey("SimpleValueParameter").TextContent);
//                            wParamBuilder.Append(", ");

//                            wParamBuilder.Replace("[Direction]",
//                                                  (wParameterInfo.Direction == ParameterDirection.Output)
//                                                      ? "out"
//                                                      : string.Empty);
//                            wParamBuilder.Replace("[TypeName]", ParametersDAC.GetTargetType(wParameterInfo.Type));
//                            wParamBuilder.Replace("[MethodParameterName]",
//                                                  _TDGTemplate.Keys.GetKey("MethodParameterName").TextContent);
//                            wParamBuilder.Replace("[ParameterName]", wParameterInfo.Name);

//                            wBuilder.Append(wParamBuilder.ToString());
//                        }
//                    }

//                    if (wBuilder.Length != 0)
//                    {
//                        wBuilder.Remove(wBuilder.Length - 2, 2);
//                    }

					
//                }
//                else
//                {
//                    wParamBuilder = new StringBuilder();

//                     wParamBuilder.Append(_TDGTemplate.Keys.GetKey ("BEParameter").TextContent);
 

//                    wParamBuilder.Replace("[MethodParameterName]", _TDGTemplate.Keys.GetKey ("MethodParameterName").TextContent );

//                    if (pPerformBatch)
//                    {
//                        wParamBuilder.Replace("[ParameterName]", _PatternsTemplate.Keys.GetKey("CollectionNamePattern").TextContent.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name));
//                    }
//                    else 
//                    {
//                        wParamBuilder.Replace("[ParameterName]", _PatternsTemplate.Keys.GetKey("NamePattern").TextContent.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name));
//                    }
//                    wBuilder.Append(wParamBuilder.ToString());
//                }

//                if (pMethodInfo.Action == MethodActionType.GetAllPaginated)
//                {
//                    if (wBuilder.Length != 0)
//                    {
//                        wBuilder.Append(", ");
//                    }

//                    wBuilder.Append(_TDGTemplate.Keys.GetKey ("PaginationParameters").TextContent );
//                }

//                return wBuilder.ToString();
//            }
//            finally
//            {
//                wBuilder = null;
//                wParamBuilder = null;
//            }
		
//        }

     
//        /// <summary>
//        /// Genera código de asignación de valores a parámetros de salida de un método.
//        /// </summary>
//        /// <param name="pMethodInfo">información sobre el método a generar.</param>
//        /// <returns>Código de asignación de valores a parámetros de salida.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        private static string GenOutParameterMappings(MethodInfo pMethodInfo)
//        {
//            StringBuilder wBuilder = null;

//            try
//            {
//                wBuilder = new StringBuilder();

//                foreach (ParameterInfo wParameterInfo in pMethodInfo.Parameters)
//                {
//                    if (wParameterInfo.Direction == ParameterDirection.Output)
//                    {
//                        wBuilder.Append(_TDGTemplate.Keys.GetKey ("OutParameterMapping").TextContent);
//                        wBuilder.Replace("[MethodParameterName]", GetParameterValue(wParameterInfo));
//                        wBuilder.Replace("[Type]", ParametersDAC.GetTargetType(wParameterInfo.Type));
//                        wBuilder.Replace("[ParameterName]", wParameterInfo.Name);
//                    }
//                }

//                return wBuilder.ToString();
//            }
//            finally
//            {
//                wBuilder = null;
//            }
//        }

//        #endregion
//    }
//}