//using System;
//using System.Data;
//using System.Windows.Forms;
//using System.Collections.Generic;
//using System.Text;
//using Fwk.CodeGenerator.Common;
//using fwkDataEntities = Fwk.DataBase.DataEntities;

//namespace CodeGenerator.Back.StoreProcedures
//{
    

//    /// <summary>
//    /// Clase base para generar SP apartir de distintas entidadesSPCodeGeneratorBase
//    /// </summary>
//    public abstract class SPCodeGeneratorBase 
//    {

//        private static String _CommonTemplate = String.Empty;
//        protected static String _CommonTemplateExecuteSQL = String.Empty;
//        protected static String _StoredProcedureNamePattern = null;
//        protected static Template _StoredProcedureTemplate = null;
//        protected static EntityGenerationInfo _EntityGenerationInfo = null;
//        protected static String _NotSupportTypesToInsertStoreProcedure = null;
//        protected static String _NotSupportTypesToSearchInStoreProcedure = null;

//        public SPCodeGeneratorBase()
//        {
//            _StoredProcedureTemplate =
//                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.StoredProcedureTemplate);
//            _StoredProcedureNamePattern =
//                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.Patterns).Keys.GetKey(
//                    "StoreProcedureNamePattern").TextContent;

//            _NotSupportTypesToInsertStoreProcedure =
//                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.NotSupportTypes).Keys.GetKey(
//                    "ToInsertStoreProcedure").TextContent;
//            _NotSupportTypesToSearchInStoreProcedure = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.NotSupportTypes).Keys.GetKey(
//                    "ToSearchInStoreProcedure").TextContent;
//        }

//        /// <summary>
//        /// Genera el código fuente de un conjunto de procedimientos almacenados.
//        /// </summary>
//        /// <seealso cref="GenStoredProcedures"/>
//        /// <param name="pEntityGenerationInfo">información de generación de entidad para creación de procedimientos almacenados.</param>
//        /// <returns>Código fuente.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        public TreeNode GenCode(EntityGenerationInfo pEntityGenerationInfo)
//        {
//            _EntityGenerationInfo = pEntityGenerationInfo;
//            List<GeneratedCode> wGeneratedCodeResult = new List<GeneratedCode>();


//            _CommonTemplate = _StoredProcedureTemplate.Keys.GetKey ("Common").TemplateAtribute.Body;
//            _CommonTemplateExecuteSQL = _StoredProcedureTemplate.Keys.GetKey("Search_DefinicionGlobal").TemplateAtribute.Body;

//            _CommonTemplate = _CommonTemplate.Replace("<DROP>", GetDROP());
//            _CommonTemplateExecuteSQL = _CommonTemplateExecuteSQL.Replace("<DROP>", GetDROP());

//            foreach (EntityInfo wEntityInfo in pEntityGenerationInfo.Entities)
//            {
//                GenStoredProcedures(wEntityInfo, wGeneratedCodeResult);
//            }
//            return BuildTreeNode(wGeneratedCodeResult);

//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pGeneratedCodeResult"></param>
//        /// <returns></returns>
//        private static TreeNode BuildTreeNode(List<GeneratedCode> pGeneratedCodeResult)
//        {
//            int wiIndex = 0;
//            string wzsAux = String.Empty;
//            TreeNode wNodeSP = new TreeNode("SP");
//            TreeNode wTreeNodeEntitySp = null;
//            TreeNode wTreeNodeSpActions = null;

            

//            //Carga los nodos  con los nombres de las entidades
//            foreach (GeneratedCode wGeneratedCode in pGeneratedCodeResult)
//            {
//                if (wzsAux != wGeneratedCode.Id)
//                {
//                    wzsAux = wGeneratedCode.Id;

//                    wTreeNodeEntitySp = new TreeNode(wGeneratedCode.Id);
//                    wTreeNodeEntitySp.Text = wGeneratedCode.Id;
//                    wTreeNodeEntitySp.Name = wGeneratedCode.Id;
//                    wTreeNodeEntitySp.Tag = "EntitySP";


//                    wNodeSP.Nodes.Add(wTreeNodeEntitySp);
//                }

//            }
//            //Carga los nodos  con los nombres de los metodos por cada entidad
//            foreach (GeneratedCode wGeneratedCode in pGeneratedCodeResult)
//            {
//                if (wzsAux != wGeneratedCode.Id)
//                {
//                    wzsAux = wGeneratedCode.Id;
//                    wiIndex = wNodeSP.Nodes.IndexOfKey(wGeneratedCode.Id);
//                    wTreeNodeEntitySp = wNodeSP.Nodes[wiIndex];
//                }
//                wTreeNodeSpActions = new TreeNode();
//                wTreeNodeSpActions.Name = wGeneratedCode.MethodActionType.ToString();
//                wTreeNodeSpActions.Text = wGeneratedCode.MethodActionType.ToString();
//                wTreeNodeSpActions.Tag = wGeneratedCode;
                

//                wTreeNodeEntitySp.Nodes.Add(wTreeNodeSpActions);
//            }

//            return wNodeSP;
//        }       

//        /// <summary>
//        /// Genera el código fuente de un conjunto de procedimientos almacenados.
//        /// </summary>
//        /// <remarks>
//        /// Este método hace distinción de dos tipos de métodos: métodos <b>built-in</b> y métodos <b>generados por el usuario</b> (<see cref="MethodActionType"/>).
//        /// La generación de los del tipo built-in la determina esta clase, los parámetros son tomados de los campos de la tabla seleccionada para generar la entidad y sus métodos. Para los del otro tipo, se tomarán los parámetros selecionados por el usuario o los propios de un procedimiento almacenado preexistente.
//        /// </remarks>
//        /// <param name="pEntityInfo">Entidad para la que se generarán los procedimientos almacenados.</param>
//        /// <param name="pProceduresCode">Lista de código generado.</param>
//        /// <date>2006-03-20T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected List<GeneratedCode> GenStoredProcedures(EntityInfo pEntityInfo, List<GeneratedCode> pProceduresCode)
//        {

//            string wSPBodyCode;


//            foreach (MethodInfo wMethodInfo in pEntityInfo.Methods)
//            {
//                wSPBodyCode = GetSPBodyByActionType(wMethodInfo.Action);

//                switch (wMethodInfo.Action)
//                {
//                    case MethodActionType.Insert:
//                        {
//                            GenCodeInsert(wMethodInfo, wSPBodyCode, pProceduresCode);
//                            break;
//                        }

//                    case MethodActionType.Update:
//                        {
//                            GenCodeUpdate(wMethodInfo, wSPBodyCode, pProceduresCode);
//                            break;
//                        }

//                    case MethodActionType.Delete:
//                        {
//                            GenCodeDelete(wMethodInfo, wSPBodyCode, pProceduresCode);
//                            break;
//                        }
//                    //case MethodActionType.Get:
//                    //    {
//                    //        GenCodeGet(wMethodInfo, wActionCode, pProceduresCode);
//                    //        break;
//                    //    }
//                    case MethodActionType.GetAll:
//                    case MethodActionType.GetAllPaginated:
//                        {
//                            GenCodeGetAll(wMethodInfo, wSPBodyCode, pProceduresCode);
//                            break;
//                        }
//                    case MethodActionType.GetByParam:
//                        {
//                            GenCodeGetByParam(wMethodInfo, wSPBodyCode, pProceduresCode);
//                            break;
//                        }

//                }


//            }
//            return pProceduresCode;

//        }


//        /// <summary>
//        /// Recupera el nodo de templates de una Acción específica.
//        /// </summary>
//        /// <seealso cref="GenStoredProcedures"/>
//        /// <param name="pActionType">Acción para la que se quiere recuperar el template.</param>
//        /// <returns>Nodo con templates.</returns>
//        /// <author>Marcelo Oviedo</author>
//        private string GetSPBodyByActionType(MethodActionType pActionType)
//        {
//            return TemplateProvider.GetStoredProcedureTemplate(pActionType).TemplateAtribute.Body;
//        }

//        /// <summary>
//        /// Genera código fuente de un parámetro del procedimiento almacenado.
//        /// </summary>
//        /// <param name="pParameterInfo">información sobre el parámetro a generar.</param>
//        /// <returns>Código fuente del parámetro.</returns>
//        /// <date>2006-03-31T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected StringBuilder BuildParameter(ParameterInfo pParameterInfo)
//        {
//            string wDirection = string.Empty;
//            StringBuilder wBuilder = new StringBuilder();
//            wBuilder.Append("\t");
//            wBuilder.Append(ParametersDAC.GetParameterPattern(pParameterInfo.Type));
//            //@Nombre
//            wBuilder.Replace("[Name]", DBTypesMappingSection.Current.ParameterToken + pParameterInfo.Name);
//            if (pParameterInfo.Type.ToLower().Contains("image"))

//                wBuilder.Replace("[Type]", "varbinary");
//            else
//                wBuilder.Replace("[Type]", pParameterInfo.Type);

//            if (pParameterInfo.Length != -1)
//                wBuilder.Replace("[Length]", pParameterInfo.Length.ToString());
//            else
//                wBuilder.Replace("[Length]", "max");

//            wBuilder.Replace("[Precision]", pParameterInfo.Precision.ToString());
//            wBuilder.Replace("[Scale]", pParameterInfo.Scale.ToString());

//            wBuilder.Replace("[Direction]", DBTypesMappingSection.Current.InputParameter);
//            wBuilder.Append(",\r\n");

//            return wBuilder;
//        }

       

//        /// <summary>
//        /// Genera código fuente de un parámetro del procedimiento almacenado a partir de un campo de la tabla.
//        /// </summary>
//        /// <param name="pTableFieldInfo">información sobre el parámetro a generar.</param>
//        /// <param name="pActionType">Tipo de Acción a realizar por el procedimiento almacenado.</param>
//        /// <param name="pSetDirection">Dirección del parámetro.</param>
//        /// <param name="pSetDefaultNull">Indica si se pasa NULL como valor por defecto.</param>
//        /// <returns>Código fuente del parámetro.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected StringBuilder BuildParameter(fwkDataEntities.Column pColumn,
//            MethodActionType pActionType, bool pSetDirection, bool pSetDefaultNull)
//        {
//            string wDirection = string.Empty;
//            StringBuilder wBuilder = new StringBuilder();

//            wBuilder.Append("\t");
//            wBuilder.Append(ParametersDAC.GetParameterPattern(pColumn.Type));
//            //@Nombre
//            wBuilder.Replace("[Name]", DBTypesMappingSection.Current.ParameterToken + pColumn.Name);
//            if (pColumn.Type.ToLower().Contains("image"))

//                wBuilder.Replace("[Type]", "varbinary");
//            else
//                wBuilder.Replace("[Type]", pColumn.Type);

//            if (pColumn.Length != -1 && pColumn.Length != 0 )
//                wBuilder.Replace("[Length]", pColumn.Length.ToString());
//            else
//                wBuilder.Replace("[Length]", "max");

//            wBuilder.Replace("[Precision]", pColumn.Prec.ToString());
//            wBuilder.Replace("[Scale]", pColumn.Scale.ToString());

//            if (pSetDirection)
//            {
//                ParameterDirection wParamDirection = ((pColumn.Autogenerated || pColumn.IsIdentity) && (pActionType == MethodActionType.Insert)) ? ParameterDirection.Output : ParameterDirection.Input;

//                switch (wParamDirection)
//                {
//                    case System.Data.ParameterDirection.Input:
//                        {
//                            wDirection = DBTypesMappingSection.Current.InputParameter;
//                            break;
//                        }
//                    case System.Data.ParameterDirection.Output:
//                        {
//                            wDirection = DBTypesMappingSection.Current.OutputParameter;
//                            break;
//                        }

//                    case System.Data.ParameterDirection.InputOutput:
//                        {
//                            wDirection = DBTypesMappingSection.Current.InputOutputParameter;
//                            break;
//                        }
//                    default:
//                        {
//                            wDirection = string.Empty;
//                            break;
//                        }
//                }
//            }

//            wBuilder.Replace("[Direction]", wDirection);

//            if (pSetDefaultNull && pColumn.Nullable)
//            {
//                wBuilder.Append(DBTypesMappingSection.Current.DefaultNullParameter);
//            }

//            wBuilder.Append(",\r\n");

//            return wBuilder;
//        }

//        #region [-- generación de código --]

//        /// <summary>
//        /// Genera código de procedimientos almacenados de Búsqueda por parámetros.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <param name="pNode">XML con templates para reemplazo.</param>
//        /// <param name="pProceduresCode">Lista de código generado.</param>
//        /// <returns>Código fuente del procedimiento almacenado.</returns>
//        /// <date>2006-03-31T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract void GenCodeGetByParam(MethodInfo pMethodInfo, string pActionCode, List<GeneratedCode> pProceduresCode);

//        /// <summary>
//        /// Genera código de procedimientos almacenados de Búsqueda.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <param name="pNode">XML con templates para reemplazo.</param>
//        /// <param name="pProceduresCode">Lista de código generado.</param>
//        /// <returns>Código fuente del procedimiento almacenado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract void GenCodeGetAll(MethodInfo pMethodInfo, string pActionCode, List<GeneratedCode> pProceduresCode);
       
//        /// <summary>
//        /// Genera código de procedimientos almacenados de Búsqueda por clave primaria.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <param name="pNode">XML con templates para reemplazo.</param>
//        /// <param name="pProceduresCode">Lista de código generado.</param>
//        /// <returns>Código fuente del procedimiento almacenado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        //protected abstract void GenCodeGet(MethodInfo pMethodInfo, string pActionCode, List<GeneratedCode> pProceduresCode);
       
//        /// <summary>
//        /// Genera código de procedimientos almacenados de actualización.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <param name="pNode">XML con templates para reemplazo.</param>
//        /// <param name="pProceduresCode">Lista de código generado.</param>
//        /// <returns>Código fuente del procedimiento almacenado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract void GenCodeUpdate(MethodInfo pMethodInfo, string pActionCode, List<GeneratedCode> pProceduresCode);
       
//        /// <summary>
//        /// Genera código de procedimientos almacenados de borrado.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <param name="pNode">XML con templates para reemplazo.</param>
//        /// <param name="pProceduresCode">Lista de código generado.</param>
//        /// <returns>Código fuente del procedimiento almacenado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract void GenCodeDelete(MethodInfo pMethodInfo, string pActionCode, List<GeneratedCode> pProceduresCode);


//        /// <summary>
//        /// Genera código de procedimientos almacenados de Inserción.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <param name="pNode">XML con templates para reemplazo.</param>
//        /// <param name="pProceduresCode">Lista de código generado.</param>
//        /// <returns>Código fuente del procedimiento almacenado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        /*B-A*/
//        protected abstract void GenCodeInsert(MethodInfo pMethodInfo, string pActionCode, List<GeneratedCode> pProceduresCode);
        
      

//        /// <summary>
//        /// Genera el código de la sentencia relacionado con la cláusula where para Búsquedas por clave primaria.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente referido a la cláusula where de la sentencia.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract string GenCodeWhereClause(MethodInfo pMethodInfo);

//        #endregion

//        /// <summary>
//        /// Genera código común para todas las acciones.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <param name="pBuilder">StringBuilder sobre el cual se realizarán los reemplazos de tags.</param>
//        /// <param name="pNode">XML con templates para reemplazo.</param>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected StringBuilder GenCodeCommon(MethodInfo pMethodInfo,  string pSpBody)
//        {
//           StringBuilder wBuilder = new StringBuilder ();
//            wBuilder.Append(_CommonTemplate);

//            wBuilder.Replace("[ProcedureBody]", pSpBody);
    
//            wBuilder.Replace(CommonConstants.CONST_AUTHOR, Environment.UserName );
//            wBuilder.Replace(CommonConstants.CONST_CREATION_DATETIME, string.Format("{0:s}", DateTime.Now));
//            wBuilder.Replace(CommonConstants.CONST_TABLE_NAME, pMethodInfo.Entity.Table.Name);

//            return wBuilder;
//        }

//        #region [private methods]

//        /// <summary>
//        /// Retorna Nombre del SP segun toipo de accion del SP
//        /// </summary>
//        /// <param name="pTableName">Nombre de tabla</param>
//        /// <param name="pActionType">Puede ser get insert update delente etc</param>
//        /// <returns>StoredProcedureName</returns>
//        protected static String GetStoredProcedureName(String pTableName, String pSchema, MethodActionType pActionType)
//        {

//            String pSpName = String.Empty;

//            //Ej: [EntityName][Sufix]
//            pSpName = _StoredProcedureNamePattern.Replace(CommonConstants.CONST_ENTITY_NAME, pTableName);

//            switch (pActionType)
//            {
//                case MethodActionType.Insert:
//                    {
//                        pSpName = pSpName.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX, _EntityGenerationInfo.TemplateSettingObject.StoreProcedures.InsertSufix);
//                        break;
//                    }

//                case MethodActionType.Update:
//                    {
//                        pSpName = pSpName.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX, _EntityGenerationInfo.TemplateSettingObject.StoreProcedures.UpdateSufix);
//                        break;
//                    }

//                case MethodActionType.Delete:
//                    {
//                        pSpName = pSpName.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX, _EntityGenerationInfo.TemplateSettingObject.StoreProcedures.DeleteSufix);
//                        break;
//                    }
//                case MethodActionType.GetAll:
//                    {
//                        pSpName = pSpName.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX, _EntityGenerationInfo.TemplateSettingObject.StoreProcedures.GetAllSufix);
//                        break;
//                    }


//                case MethodActionType.GetAllPaginated:
//                    {
//                        pSpName = pSpName.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX, _EntityGenerationInfo.TemplateSettingObject.StoreProcedures.GetAllPaginated);
//                        break;
//                    }
//                case MethodActionType.GetByParam:
//                    {
//                        pSpName = pSpName.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX, _EntityGenerationInfo.TemplateSettingObject.StoreProcedures.GetByParamSufix);
//                        break;
//                    }

//            }
//            pSpName = pSpName.Replace("[Schema]", pSchema);
//            return pSpName;

//        }
//        /// <summary>
//        /// Retorna Descripcion del SP segun toipo de accion del SP
//        /// </summary>
//        /// <param name="pTableName">Nombre de tabla</param>
//        /// <param name="pActionType">Puede ser get insert update delente etc</param>
//        /// <returns>Description</returns>
//        protected static String GetStoredProcedureDescription(String pTableName, MethodActionType pActionType)
//        {
//            return TemplateProvider.GetStoredProcedureTemplate(pActionType).TemplateAtribute.Description.Replace(CommonConstants.CONST_TABLE_NAME, pTableName);
//        }
//        private  String GetDROP()
//        {
//            String wStrDrop;

//            //----------------------------------------------------------------------
//            //-- Cargo el pattern segun la version de SQL Server
//            //----------------------------------------------------------------------
//            //if (versionSQLServer == 2005)
//            wStrDrop = _StoredProcedureTemplate.Keys.GetKey ("DropStoreSQL2005").TextContent;
//            //else
//            //    sbPatternDROP = Common.OpenTextFile(@"Templates\SQL\DropStoreSQL2000.txt");


//            return wStrDrop;
//        }
//        /// <summary>
//        /// Remueve la cantidad especificada de caracteres al final de la cadena.
//        /// </summary>
//        /// <param name="pBuilder">StringBuilder para efectuar el recorte de caracteres.</param>
//        /// <param name="pCount">Cantidad de caracteres a remover.</param>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected void RemoveChars(StringBuilder pBuilder, int pCount)
//        {
//            if (pBuilder.Length > 0)
//            {
//                pBuilder.Remove(pBuilder.Length - pCount, pCount).Append("\r\n");
//            }
//        }

//        /// <summary>
//        /// Devuelve el código generado para una entidad.
//        /// </summary>
//        /// <param name="pEntityInfo">Entidad para la que se generarán los procedimientos almacenados.</param>
//        /// <param name="pProceduresCode">Lista de código generado.</param>
//        /// <returns>Código generado para una entidad.</returns>
//        /// <date>2006-03-20T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected GeneratedCode GetEntityGeneratedCode(EntityInfo pEntityInfo, List<GeneratedCode> pProceduresCode)
//        {
//            GeneratedCode wResult = null;

//            foreach (GeneratedCode wCode in pProceduresCode)
//            {
//                if (wCode.Id == pEntityInfo.Name)
//                {
//                    wResult = wCode;
//                    break;
//                }
//            }

//            if (wResult == null)
//            {
//                wResult = new GeneratedCode();
//                wResult.Id = pEntityInfo.Name;
                

//                pProceduresCode.Add(wResult);
//            }

//            return wResult;

//        }
//        #endregion



//        #region -- abstract auxiliares get --

//        /// <summary>
//        /// Genera código de parámetros de un procedimiento almacenado de Búsqueda por clave primaria.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente generado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract string GenCodeParameters(MethodInfo pMethodInfo);
       
//        /// <summary>
//        /// Genera código de campos de retorno de un procedimiento almacenado de Búsqueda.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente generado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract string GenCodeGetSelectList(MethodInfo pMethodInfo);
        
        
//        #endregion

//        #region -- abstract auxiliares Insert --

//        /// <summary>
//        /// Genera código de parámetros de un procedimiento almacenado de Inserción.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente generado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract string GenCodeInsertParameters(MethodInfo pMethodInfo);
//        /// <summary>
//        /// Genera código de campos de un procedimiento almacenado de Inserción.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente generado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract string GenCodeInsertFields(MethodInfo pMethodInfo);

//        /// <summary>
//        /// Genera código de valores de Inserción de un procedimiento almacenado de Inserción.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente generado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract string GenCodeInsertValues(MethodInfo pMethodInfo);

//        /// <summary>
//        /// Genera código de retorno de parámetro con valor autogenerado de un procedimiento almacenado de Inserción.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente generado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract string GenCodeInsertReturnAutogenerated(MethodInfo pMethodInfo);
//        #endregion

//        #region -- abstract auxiliares delete --

//        /// <summary>
//        /// Genera código de parámetros de un procedimiento almacenado de borrado.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente generado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract string GenCodeDeleteParameters(MethodInfo pMethodInfo);
       

//        #endregion


//        #region -- abstract auxiliares update --

//        /// <summary>
//        /// Genera código de parámetros de un procedimiento almacenado de actualización.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente generado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract  string GenCodeUpdateParameters(MethodInfo pMethodInfo);
        

//        /// <summary>
//        /// Genera código de declaraciones de actualización de un procedimiento almacenado de actualización.
//        /// </summary>
//        /// <param name="pMethodInfo">información del método para generar stored procedure.</param>
//        /// <returns>Código fuente generado.</returns>
//        /// <date>2007-5-25T00:00:00</date>
//        /// <author>Marcelo Oviedo</author>
//        protected abstract string GenCodeUpdateSetStatements(MethodInfo pMethodInfo);
        

//        #endregion
//    }


//}
