using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CodeGenerator.Back;
using CodeGenerator.Back.Common;
using CodeGenerator.Back.ObjectModel;
using System.Windows.Forms; 

namespace CodeGenerator.Back.DataAccess 

    {

        /// <summary>
        /// Clase para generar código fuente de table data gateways.
        /// </summary>
        /// <remarks>
        /// Hace uso de templates para efectuar reemplazos en tags. Crea una clase y sus métodos.
        /// </remarks>
        /// <author>Marcelo Oviedo</author>
        public class DACGenerator
        {
            private static Template _CodeGeneratorTemplate = null;
            private static Template _DACTemplate = null;
            private static Template _TDGTemplate = null;
            private static Template _PatternsTemplate = null;
            static EntityGenerationInfo _EntityGenerationInfo = null;

            public static EntityGenerationInfo EntityGenerationInfo
            {
                get { return _EntityGenerationInfo; }
                set { _EntityGenerationInfo = value; }
            } 

            static DACGenerator()
            {
                _CodeGeneratorTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.CodeGenerator);
                _DACTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.DACTemplate);
                _TDGTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.TDGTemplate);
                _PatternsTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.Patterns);
            }
            #region [Public methods]

            /// <summary>
            /// Inicia la generación de código fuente de un componente de acceso a datos
            /// </summary>
            /// <param name="pEntityGenerationInfo">información de generación de entidad para creación del componente de acceso a datos.</param>
            /// <returns>Código fuente.</returns>
            /// <date>2006-03-29T00:00:00</date>
            /// <author>Marcelo Oviedo</author>
            public static TreeNode GenCode()
            {
                List<GeneratedCode> wGeneratedCodeResult = new List<GeneratedCode>();

                foreach (EntityInfo wEntityInfo in _EntityGenerationInfo.Entities)
                {
                    GenClass(wEntityInfo,wGeneratedCodeResult);
                }


                return BuildTDGTreeNode(wGeneratedCodeResult);
            }

        

            #endregion

            #region [Private methods

            private static TreeNode BuildTDGTreeNode(List<GeneratedCode> pGeneratedCodeResult)
            {
                TreeNode wTreeNodeTDG = new TreeNode("TDG");
                foreach (GeneratedCode wGeneratedCode in pGeneratedCodeResult)
                {
                    TreeNode wTreeNode = new TreeNode(wGeneratedCode.Id);
                    wTreeNode.Text = wGeneratedCode.Id;
                    wTreeNode.Tag = wGeneratedCode;

                    wTreeNodeTDG.Nodes.Add(wTreeNode);

                }
                return wTreeNodeTDG;
            }       

            /// <summary>
            /// Genera código fuente de un componente de acceso a datos.
            /// </summary>
            /// <param name="pEntityInfo">Entidad principal.</param>
            /// <param name="pEntityNamespace">Namespace de entidades de negocio.</param>
            /// <param name="pDACNamespace">Namespace de componentes de acceso a datos.</param>
            /// <param name="pDACCode">Código para ejecución de componente de acceso a datos.</param>
            /// <author>Marcelo Oviedo</author>
            private static void GenClass(EntityInfo pEntityInfo, List<GeneratedCode> pDACCode)
            {
                StringBuilder wBuilder = null;
                StringBuilder wMethodBuilder = null;
                GeneratedCode wCode = null;

                try
                {
                    wBuilder = new StringBuilder(_CodeGeneratorTemplate.Keys.GetKey("Signature").TextContent);
                    wBuilder.Append(_DACTemplate.Keys.GetKey ("Class").TextContent);
                    wMethodBuilder = new StringBuilder();

                    foreach (MethodInfo wMethodInfo in pEntityInfo.Methods)
                    {
                        wMethodBuilder.Append(GenMethod(wMethodInfo));

                        if (wMethodInfo.PerformBatch)
                        {
                             wMethodBuilder.Append(GenBatchMethod(wMethodInfo));
                           
                        }
                       
                    }

                    wBuilder.Replace("[Methods]", wMethodBuilder.ToString());

                    wBuilder.Replace("[DACName]", _DACTemplate.Keys.GetKey ("Name").TextContent);
                    wBuilder.Replace(CommonConstants.CONST_CREATION_DATETIME, string.Format("{0:s}", DateTime.Now));
                    wBuilder.Replace(CommonConstants.CONST_AUTHOR, Environment.UserName);
                    wBuilder.Replace(CommonConstants.CONST_ENTITY_NAME, pEntityInfo.Name);
                    wBuilder.Replace(CommonConstants.CONST_NAMESPACE_BE_DE, _EntityGenerationInfo.TemplateSettingObject.Namespaces.BusinessEntities);
                    wBuilder.Replace(CommonConstants.CONST_NAMESPACE_DAC, _EntityGenerationInfo.TemplateSettingObject.Namespaces.DataAccessComponent);
                    wBuilder.Replace(CommonConstants.CONST_CHILDS_ITERATION, String.Empty);

                    wBuilder.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX, _EntityGenerationInfo.TemplateSettingObject.Entities.EntitySufix);
                    wBuilder.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION, _EntityGenerationInfo.TemplateSettingObject.Entities.CollectionsSufix);
                    wCode = new GeneratedCode();
                    wCode.Id = pEntityInfo.Name;
                    wCode.Code.Append(wBuilder.ToString());

                    pDACCode.Add(wCode);

                }
                finally
                {
                    wBuilder = null;
                    wMethodBuilder = null;
                    wCode = null;
                }
            }

            private static string GenBatchMethod(MethodInfo pMethodInfo)
            {
                StringBuilder wBuilder = null;
                StringBuilder wTDGBuilder = null;

                try
                {
                    wBuilder = new StringBuilder(_DACTemplate.Keys.GetKey ("Method").TextContent);


                    wBuilder.Replace(CommonConstants.CONST_BACK_END_METHOD_NAME, pMethodInfo.Name + "Batch");

                    if (pMethodInfo.ReturnType == MethodReturnType.Void)
                    {
                        wBuilder.Replace("[RetType]", "void");
                    }
                    else
                    {
                        wBuilder.Replace("[RetType]", "DataSet");
                    }

                    wBuilder.Replace(CommonConstants.CONST_BACK_END_METHOD_NAME, pMethodInfo.Name);
                    wBuilder.Replace("[ParamArgs]", GenMethodParameters(pMethodInfo,true));


                    wTDGBuilder = new StringBuilder();
                    GenTDGDeclaration(pMethodInfo.Entity, pMethodInfo.Action, wTDGBuilder);
                    wBuilder.Replace("[TDGDeclaration]", wTDGBuilder.ToString());

                    wTDGBuilder = new StringBuilder();
                    GenTDGInitialization(pMethodInfo.Entity, pMethodInfo.Action, wTDGBuilder);
                    wBuilder.Replace("[TDGInitialization]", wTDGBuilder.ToString());


                    wTDGBuilder = new StringBuilder();
                    GenTDGDereference(pMethodInfo.Entity, pMethodInfo.Action, wTDGBuilder);
                    wBuilder.Replace("[TDGDereference]", wTDGBuilder.ToString());


                    wBuilder.Replace(CommonConstants.CONST_BACK_END_RETURN, GenReturn(pMethodInfo,true));

                    wBuilder.Replace("[SummaryParams]", GenParametersSummary(pMethodInfo));

                    return wBuilder.ToString();

                }
                finally
                {
                    wBuilder = null;
                }
            }

            /// <summary>
            /// Genera código de un método del componente de acceso a datos.
            /// </summary>
            /// <param name="pMethodInfo">información sobre el método a generar.</param>
            /// <param name="pTemplates">XML con templates para generar código.</param>
            /// <returns>Código fuente del método.</returns>
            /// <author>Marcelo Oviedo</author>
            private static string GenMethod(MethodInfo pMethodInfo)
            {
                StringBuilder wBuilder = null;
                StringBuilder wTDGBuilder = null;

                try
                {
                    wBuilder = new StringBuilder(_DACTemplate.Keys.GetKey ("Method").TextContent);


                    wBuilder.Replace(CommonConstants.CONST_BACK_END_METHOD_NAME, pMethodInfo.Name);

                    if (pMethodInfo.ReturnType == MethodReturnType.Void)
                    {
                        wBuilder.Replace("[RetType]", "void");
                    }
                    else
                    {
                        wBuilder.Replace("[RetType]", "DataSet");
                    }

                    wBuilder.Replace(CommonConstants.CONST_BACK_END_METHOD_NAME, pMethodInfo.Name);
                    wBuilder.Replace("[ParamArgs]", GenMethodParameters(pMethodInfo,false));


                    wTDGBuilder = new StringBuilder();
                    GenTDGDeclaration(pMethodInfo.Entity, pMethodInfo.Action, wTDGBuilder);
                    wBuilder.Replace("[TDGDeclaration]", wTDGBuilder.ToString());

                    wTDGBuilder = new StringBuilder();
                    GenTDGInitialization(pMethodInfo.Entity, pMethodInfo.Action, wTDGBuilder);
                    wBuilder.Replace("[TDGInitialization]", wTDGBuilder.ToString());


                    wTDGBuilder = new StringBuilder();
                    GenTDGDereference(pMethodInfo.Entity, pMethodInfo.Action, wTDGBuilder);
                    wBuilder.Replace("[TDGDereference]", wTDGBuilder.ToString());


                    wBuilder.Replace(CommonConstants.CONST_BACK_END_RETURN, GenReturn(pMethodInfo,false));

                    wBuilder.Replace("[SummaryParams]", GenParametersSummary(pMethodInfo));

                    return wBuilder.ToString();

                }
                finally
                {
                    wBuilder = null;
                }

            }

            /// <summary>
            /// Genera código de declaración de table data gateway.
            /// </summary>
            /// <param name="pEntityInfo">información sobre la entidad a generar.</param>
            /// <param name="pAction">Acción del método.</param>
            /// <param name="pTemplates">XML con templates para generar código.</param>
            /// <param name="wTDGBuilder">Acumulador de código fuente de llamado a table data gateways.</param>
            /// <author>Marcelo Oviedo</author>
            private static void GenTDGDeclaration(EntityInfo pEntityInfo, MethodActionType pAction, StringBuilder wTDGBuilder)
            {
                wTDGBuilder.Append(_DACTemplate.Keys.GetKey ("TDGDeclaration").TextContent );
                wTDGBuilder.Replace("[TDGDereference]", _DACTemplate.Keys.GetKey ("TDGDereference").TextContent);
                wTDGBuilder.Replace("[TDGEntityName]", _TDGTemplate.Keys.GetKey ("Name").TextContent);
                wTDGBuilder.Replace(CommonConstants.CONST_ENTITY_NAME, pEntityInfo.Name);

                if (pAction == MethodActionType.Insert || pAction == MethodActionType.Update)
                {
                    
                }
            }

            /// <summary>
            /// Genera código de incialización de table data gateway.
            /// </summary>
            /// <param name="pEntityInfo">información sobre la entidad a generar.</param>
            /// <param name="pAction">Acción del método.</param>
            /// <param name="pTemplates">XML con templates para generar código.</param>
            /// <param name="wTDGBuilder">Acumulador de código fuente de llamado a table data gateways.</param>
            /// <author>Marcelo Oviedo</author>
            private static void GenTDGInitialization(EntityInfo pEntityInfo, MethodActionType pAction, StringBuilder wTDGBuilder)
            {
                wTDGBuilder.Append(_DACTemplate.Keys.GetKey ("TDGInitialization").TextContent);
                wTDGBuilder.Replace("[TDGEntityName]", _TDGTemplate.Keys.GetKey ("Name").TextContent);
                wTDGBuilder.Replace(CommonConstants.CONST_ENTITY_NAME, pEntityInfo.Name);

                //if (pAction == MethodActionType.Insert)
                //{
                //    foreach (EntityInfo wEntity in pEntityInfo.ChildEntities)
                //    {
                //        GenTDGInitialization(wEntity, pAction,  wTDGBuilder);
                //    }
                //}
            }

            /// <summary>
            /// Genera código de liberación de recursos utilizado por table data gateways.
            /// </summary>
            /// <param name="pEntityInfo">información sobre la entidad a generar.</param>
            /// <param name="pAction">Acción del método.</param>
            /// <param name="pTemplates">XML con templates para generar código.</param>
            /// <param name="wTDGBuilder">Acumulador de código fuente de llamado a table data gateway.</param>
            
            /// <author>Marcelo Oviedo</author>
            private static void GenTDGDereference(EntityInfo pEntityInfo, MethodActionType pAction, StringBuilder wTDGBuilder)
            {
                wTDGBuilder.Append(_DACTemplate.Keys.GetKey ("TDGDereference").TextContent);
                wTDGBuilder.Replace("[TDGEntityName]", _TDGTemplate.Keys.GetKey ("Name").TextContent);
                wTDGBuilder.Replace(CommonConstants.CONST_ENTITY_NAME, pEntityInfo.Name);

                //if (pAction == MethodActionType.Insert)
                //{
                //    foreach (EntityInfo wEntity in pEntityInfo.ChildEntities)
                //    {
                //        GenTDGDereference(wEntity, pAction, wTDGBuilder);
                //    }
                //}
            }

            /// <summary>
            /// Genera comentarios sobre los parámetros de un método.
            /// </summary>
            /// <param name="pMethodInfo">información sobre el método a generar.</param>
            /// <returns>Comentarios sobre los parámetros.</returns>
            
            /// <author>Marcelo Oviedo</author>
            private static string GenParametersSummary(MethodInfo pMethodInfo)
            {
                StringBuilder wBuilder = null;

                try
                {
                    wBuilder = new StringBuilder();

                    if (pMethodInfo.ParameterType == MethodParameterType.SimpleValues)
                    {
                        foreach (ParameterInfo wParameterInfo in pMethodInfo.Parameters)
                        {
                            wBuilder.Append(_DACTemplate.Keys.GetKey ("ParameterSummary").TextContent);
                            wBuilder.Replace("[MethodParameterName]", _DACTemplate.Keys.GetKey ("MethodParameterName").TextContent);
                            wBuilder.Replace("[ParameterName]", wParameterInfo.Name);
                        }
                    }
                    else
                    {
                        wBuilder.Append(_DACTemplate.Keys.GetKey ("ParameterSummary").TextContent );
                        wBuilder.Replace("[MethodParameterName]", _DACTemplate.Keys.GetKey ("MethodParameterName").TextContent );
                        wBuilder.Replace("[ParameterName]", _PatternsTemplate.Keys.GetKey("NamePattern").TextContent.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name));
                    }

                    return wBuilder.ToString();

                }
                finally
                {
                    wBuilder = null;
                }
            }


            /// <summary>
            /// Genera código relacionado con las instrucciones de retorno de valores de un método.
            /// </summary>
            /// <param name="pMethodInfo">información sobre el método a generar.</param>
            /// <returns>Código de instrucciones de retorno.</returns>
            /// <author>Marcelo Oviedo</author>
            private static string GenReturn(MethodInfo pMethodInfo, bool pPerformBatch)
            {
                StringBuilder wQueryBuilder = null;
                StringBuilder wBuilder = null;
             
                try
                {
                    wQueryBuilder = new StringBuilder();
                    wQueryBuilder.Append("Return");
                    wQueryBuilder.Append(Enum.GetName(typeof(MethodReturnType), pMethodInfo.ReturnType));

                    wBuilder = new StringBuilder();
                    wBuilder.Append(_DACTemplate.Keys.GetKey (wQueryBuilder.ToString()).TextContent);


                    if (pPerformBatch)
                    {
                        GenMethodCallsBatch(pMethodInfo, wBuilder);
                    }
                    else
                    {
                        GenMethodCalls(pMethodInfo, wBuilder);
                    }
             

                    return wBuilder.ToString();

                }
                finally
                {
                    wQueryBuilder = null;
                    wBuilder = null;
                    
                }
            }

            /// <summary>
            /// Genera código de ejecucion de métodos de table data gateways.
            /// </summary>
            /// <param name="pMethodInfo">información sobre el método a generar.</param>
            /// <param name="pBuilder">Acumulador de código ejecución de métodos de table data gateways.</param>
            /// <param name="pTemplates">XML con templates para generar código.</param>
            
            /// <author>Marcelo Oviedo</author>
            private static void GenMethodCalls(MethodInfo pMethodInfo, StringBuilder pBuilder)
            {
                pBuilder.Replace("[TDGCall]", _DACTemplate.Keys.GetKey ("TDGCall").TextContent);

                pBuilder.Replace("[TDGEntityName]", _TDGTemplate.Keys.GetKey ("Name").TextContent);
                pBuilder.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name);

               pBuilder.Replace(CommonConstants.CONST_BACK_END_METHOD_NAME, pMethodInfo.Name);
                   
              
                pBuilder.Replace("[MethodCallParameters]", GenMethodCallParameters(pMethodInfo,false));

                if (pMethodInfo.Action == MethodActionType.Insert)
                {

                    pBuilder.Replace("[ChildsIteration]", string.Empty);
                }

               
            }

            private static void GenMethodCallsBatch(MethodInfo pMethodInfo, StringBuilder pBuilder)
            {
                pBuilder.Replace("[TDGCall]", _DACTemplate.Keys.GetKey ("TDGCall").TextContent);

                pBuilder.Replace("[TDGEntityName]", _TDGTemplate.Keys.GetKey ("Name").TextContent);
                pBuilder.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name);
                pBuilder.Replace(CommonConstants.CONST_BACK_END_METHOD_NAME , pMethodInfo.Name + "Batch");
               
                pBuilder.Replace("[MethodCallParameters]", GenMethodCallParameters(pMethodInfo,true));
                if (pMethodInfo.Action == MethodActionType.Insert)
                {

                    pBuilder.Replace("[ChildsIteration]", string.Empty);
                }
            }
            /// <summary>
            /// Genera código de parámetros de llamado de métodos de table data gateways.
            /// </summary>
            /// <param name="pMethodInfo">información sobre el método a generar.</param>
            /// <param name="pTemplates">XML con templates para generar código.</param>
            /// <returns>Código que representa los parámetros para ejecutar el método de un table data gateway.</returns>
            
            /// <author>Marcelo Oviedo</author>
            private static string GenMethodCallParameters(MethodInfo pMethodInfo, bool pPerformBatch)
            {
                StringBuilder wBuilder = null;
                StringBuilder wParamBuilder = null;

                try
                {
                    wBuilder = new StringBuilder();

                    if (pMethodInfo.ParameterType == MethodParameterType.SimpleValues)
                    {
                        foreach (ParameterInfo wParameterInfo in pMethodInfo.Parameters)
                        {
                            wParamBuilder = new StringBuilder();
                            wParamBuilder.Append(_DACTemplate.Keys.GetKey ("MethodCallParameterName").TextContent );
                            wParamBuilder.Append(", ");

                            wParamBuilder.Replace("[Direction]", (wParameterInfo.Direction == ParameterDirection.Output) ? "out" : string.Empty);
                            wParamBuilder.Replace("[MethodParameterName]", _DACTemplate.Keys.GetKey ("MethodParameterName").TextContent );
                            wParamBuilder.Replace("[ParameterName]", wParameterInfo.Name);

                            wBuilder.Append(wParamBuilder.ToString());
                        }

                        if (wBuilder.Length != 0)
                        {
                            wBuilder.Remove(wBuilder.Length - 2, 2);
                        }

                    }
                    else
                    {
                        wParamBuilder = new StringBuilder();
                        wParamBuilder.Append(_DACTemplate.Keys.GetKey ("MethodCallParameterName").TextContent);
                        wParamBuilder.Replace("[Direction]", string.Empty);
                        wParamBuilder.Replace("[MethodParameterName]", _DACTemplate.Keys.GetKey ("MethodParameterName").TextContent);
                        if (pPerformBatch)
                        {
                            wParamBuilder.Replace("[ParameterName]", _PatternsTemplate.Keys.GetKey("CollectionNamePattern").TextContent.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name));
                        }
                        else
                        {
                            wParamBuilder.Replace("[ParameterName]", _PatternsTemplate.Keys.GetKey("NamePattern").TextContent.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name));
                        }
                        
                        
                        wBuilder.Append(wParamBuilder.ToString());
                    }

                    if (pMethodInfo.Action == MethodActionType.GetAllPaginated)
                    {
                        if (wBuilder.Length != 0)
                        {
                            wBuilder.Append(", ");
                        }

                        wBuilder.Append(_DACTemplate.Keys.GetKey ("PaginationMethodCallParameters").TextContent );
                    }

                    return wBuilder.ToString();
                }
                finally
                {
                    wBuilder = null;
                    wParamBuilder = null;
                }


            }

                /// <summary>
                /// Genera código de parámetros de llamado a un método.
                /// </summary>
                /// <param name="pMethodInfo">información sobre el método a generar.</param>
                /// <param name="pTemplates">XML con templates para generar código.</param>
                /// <returns>Código que representa los parámetros para ejecutar el método.</returns>
                /// <author>Marcelo Oviedo</author>
                private static string GenMethodParameters(MethodInfo pMethodInfo, bool pPerformBatch)
                {
                    StringBuilder wBuilder = null;
                    StringBuilder wParamBuilder = null;

                    try
                    {
                        wBuilder = new StringBuilder();

                        if (pMethodInfo.ParameterType == MethodParameterType.SimpleValues)
                        {
                            foreach (ParameterInfo wParameterInfo in pMethodInfo.Parameters)

                            {
                                if (wParameterInfo.Selected)
                                {
                                    wParamBuilder = new StringBuilder();
                                    wParamBuilder.Append(_DACTemplate.Keys.GetKey("SimpleValueParameter").TextContent);
                                    wParamBuilder.Append(", ");

                                    wParamBuilder.Replace("[Direction]",(wParameterInfo.Direction == ParameterDirection.Output) ? "out": string.Empty);
                                    wParamBuilder.Replace("[TypeName]", ParametersDAC.GetTargetType(wParameterInfo.Type));
                                    wParamBuilder.Replace("[MethodParameterName]",
                                                          _DACTemplate.Keys.GetKey("MethodParameterName").TextContent);
                                    wParamBuilder.Replace("[ParameterName]", wParameterInfo.Name);

                                    wBuilder.Append(wParamBuilder.ToString());
                                }
                            }

                            if (wBuilder.Length != 0)
                            {
                                wBuilder.Remove(wBuilder.Length - 2, 2);
                            }


                        }
                        else
                        {
                            wParamBuilder = new StringBuilder();
                            if (pPerformBatch)
                            {
                               
                                wParamBuilder.Append(_DACTemplate.Keys.GetKey ("SBEParameter").TextContent);
                                wParamBuilder.Replace("[MethodParameterName]", _DACTemplate.Keys.GetKey ("MethodParameterName").TextContent);
                                wParamBuilder.Replace("[ParameterName]", _PatternsTemplate.Keys.GetKey("CollectionNamePattern").TextContent.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name));
                               
                            }
                            else
                            {
                                wParamBuilder.Append(_DACTemplate.Keys.GetKey ("BEParameter").TextContent);
                                wParamBuilder.Replace("[MethodParameterName]", _DACTemplate.Keys.GetKey ("MethodParameterName").TextContent);
                                wParamBuilder.Replace("[ParameterName]", _PatternsTemplate.Keys.GetKey("NamePattern").TextContent.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name));
                                
                            }
                            wBuilder.Append(wParamBuilder.ToString());
                        }

                        if (pMethodInfo.Action == MethodActionType.GetAllPaginated)
                        {
                            if (wBuilder.Length != 0)
                            {
                                wBuilder.Append(", ");
                            }

                            wBuilder.Append(_DACTemplate.Keys.GetKey ("PaginationParameters").TextContent);
                        }

                        return wBuilder.ToString();
                    }
                    finally
                    {
                        wBuilder = null;
                        wParamBuilder = null;
                    }

                }

            #endregion

        }
    }
