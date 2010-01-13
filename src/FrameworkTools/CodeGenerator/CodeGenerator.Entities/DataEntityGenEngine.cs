using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;
using Fwk.DataBase.DataEntities;
using CodeGenerator.Back.Schema;
using CodeGenerator.Back.ObjectModel;
using CodeGenerator.Back.Common;

namespace CodeGenerator.Back.Entities
{
    public class DatabaseEntityGenEngine
    {
        private static EntityGenerationInfo _EntityGenerationInfo;
        private static Template _CodeGeneratorTemplate = null;
        private static EntityGenEngineSP _EntityGenEngineSP;
        private static EntityGenEngineTable _EntityGenEngineTable;
        
        static DatabaseEntityGenEngine()
        {
            _CodeGeneratorTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.CodeGenerator);
            _EntityGenEngineSP = new EntityGenEngineSP();
            _EntityGenEngineTable = new EntityGenEngineTable();
        }

        public static EntityGenerationInfo EntityGenerationInfo
        {
            get { return _EntityGenerationInfo; }
            set { _EntityGenerationInfo = value; }
        }

        public static string GenerateCodeSimpleEntity()
        {
            TreeNode node = GenerateCode().Nodes[0];
            GeneratedCode wGeneratedCode = (GeneratedCode) node.Tag;

            return wGeneratedCode.Code.ToString();
        }

        /// <summary>
        /// Recorre las EntityGenerationInfo.Entities y por cada una le extrae la tabla/SP y genera un objeto GeneratedCode
        /// </summary>
        /// <param name="pEntityGenerationInfo">EntityGenerationInfo que se llena desde la aplicacion FrontEnd.-</param>
        /// <returns>List<GeneratedCode></returns>
        public static TreeNode GenerateCode()
        {
            List<GeneratedCode> wGeneratedCodeList = new List<GeneratedCode>();
            GeneratedCode wGeneratedCode = null;
            StringBuilder  wBECode = new StringBuilder ();
            String wSignature = _CodeGeneratorTemplate.Keys.GetKey ("Signature").TextContent;

            _EntityGenEngineTable.EntityGenerationInfo = _EntityGenerationInfo;
            _EntityGenEngineSP.EntityGenerationInfo = _EntityGenerationInfo;

            foreach (EntityInfo pEntityInfo in _EntityGenerationInfo.Entities)
            {
                wBECode.Append(wSignature);

                wBECode.Append(GetBECode(pEntityInfo));

                wBECode = wBECode.Replace(CommonConstants.CONST_NAMESPACE_BE_DE, _EntityGenerationInfo.TemplateSettingObject.Namespaces.BusinessEntities);

                wGeneratedCode = new GeneratedCode();
                wGeneratedCode.Code.Append(wBECode);
                wGeneratedCode.Id = (pEntityInfo.Table == null) ? pEntityInfo.StoredProcedure.Name : pEntityInfo.Table.Name;
                wGeneratedCodeList.Add(wGeneratedCode);

                wBECode.Remove(0, wBECode.Length);
            }
            return BuildBETreeNode(wGeneratedCodeList);

        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGeneratedCodeResult"></param>
        /// <returns></returns>
        private static TreeNode BuildBETreeNode(List<GeneratedCode> pGeneratedCodeResult)
        {
            TreeNode wTreeNodeBE = new TreeNode("BE");
            foreach (GeneratedCode wGeneratedCode in pGeneratedCodeResult)
            {
                TreeNode wTreeNode = new TreeNode(wGeneratedCode.Id);
                wTreeNode.Text = wGeneratedCode.Id;
                wTreeNode.Tag = wGeneratedCode;
                wTreeNodeBE.Nodes.Add(wTreeNode);
            }
            return wTreeNodeBE;
        }       

        /// <summary>
        /// Obtiene el codigo de la BE teniendo en cta si se la informacion provienen de un SP o una tabla.-
        /// </summary>
        /// <param name="pEntityInfo">EntityGenerationInfo.Entities[index].Entitie</param>
        /// <returns>String con el codigo de la clase Entity/Entities generada</returns>
        private static String GetBECode(EntityInfo pEntityInfo)
        {
            String wBECode;
            if (pEntityInfo.Table == null)
                wBECode = _EntityGenEngineSP.GeneratesDataBaseCode(pEntityInfo.StoredProcedure);
            else
                wBECode = _EntityGenEngineTable.GeneratesDataBaseCode(pEntityInfo.Table);

            return wBECode;
        }

        /// <summary>
        /// Genera una BE mas su coleccion sin el envelope
        /// </summary>
        /// <param name="pEntityInfo"></param>
        /// <returns></returns>
        public static String GenerateBEWhioutEnvelope(EntityInfo pEntityInfo)
        {
            String wBECode;
            if (pEntityInfo.Table == null)
                wBECode = _EntityGenEngineSP.GeneratesDataBaseCode(pEntityInfo.StoredProcedure);
            else
                wBECode = _EntityGenEngineTable.GeneratesDataBaseCodeWhitOutEnvelope(pEntityInfo.Table,true);

            return wBECode;
        }

    }
    /// <summary>
    /// Genera entities a partir de una Table.-
    /// </summary>
    internal class EntityGenEngineTable 
    {
        private  EntityGenerationInfo _EntityGenerationInfo;

        public  EntityGenerationInfo EntityGenerationInfo
        {
            get { return _EntityGenerationInfo; }
            set { _EntityGenerationInfo = value; }
        }

        /// <summary>
        /// Genera por cada Table una Entity y una Entities.-
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns>string </returns>
        public  string GeneratesDataBaseCode(Table pTable)
        {
            StringBuilder wClassContainer = new StringBuilder();
            string wPrivateMembers_BODY = String.Empty;
            string wPublicProperty_BODY = String.Empty;
            

            wClassContainer.Append(GenEngineBase.Entity_Template);

            wClassContainer.Replace(CommonConstants.CONST_ENTITY_NAME, pTable.Name);
            wClassContainer.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX, _EntityGenerationInfo.TemplateSettingObject.Entities.EntitySufix);
            wClassContainer.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION, _EntityGenerationInfo.TemplateSettingObject.Entities.CollectionsSufix);

            GenerateDataBaseProperttyBody(pTable, out  wPublicProperty_BODY, out wPrivateMembers_BODY);
            //Inserta miembros privados
            wClassContainer.Replace(CommonConstants.CONST_ENTITY_PRIVATE_MEMBERS_BODY, 
                                                    wPrivateMembers_BODY);
            //Inserta los atributos publicos
            wClassContainer.Replace(CommonConstants.CONST_ENTITY_PUBLIC_PROPERTY_BODY, 
                                                    wPublicProperty_BODY);


          

            return wClassContainer.ToString();

        }

        public string GeneratesDataBaseCodeWhitOutEnvelope(Table pTable,Boolean pIncludeCollection)
        {
            StringBuilder wBEClass = new StringBuilder();
            string wPrivateMembers_BODY = String.Empty;
            string wPublicProperty_BODY = String.Empty;

            wBEClass.Append(GenEngineBase.Entity_TemplateClassOnly);
            if (pIncludeCollection)
                wBEClass.Append(GenEngineBase.Entity_SchemaCollectionTemplate.Replace(CommonConstants.CONST_BODY,String.Empty));


            wBEClass.Replace(CommonConstants.CONST_ENTITY_NAME, pTable.Name);

            wBEClass.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX, _EntityGenerationInfo.TemplateSettingObject.Entities.EntitySufix);
            wBEClass.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION, _EntityGenerationInfo.TemplateSettingObject.Entities.CollectionsSufix);

            GenerateDataBaseProperttyBody(pTable, out  wPublicProperty_BODY, out wPrivateMembers_BODY);
            //Inserta miembros privados
            wBEClass.Replace(CommonConstants.CONST_ENTITY_PRIVATE_MEMBERS_BODY,
                                                    wPrivateMembers_BODY);
            //Inserta los atributos publicos
            wBEClass.Replace(CommonConstants.CONST_ENTITY_PUBLIC_PROPERTY_BODY,
                                                    wPublicProperty_BODY);


            return wBEClass.ToString();

        }

        /// <summary>
        /// Retorna codigo de miembros privados + los atributos publicos.-
        /// </summary>
        /// <param name="pTable">tabla</param>
        /// <param name="pPublicProperty_Body">atributos publicos</param>
        /// <param name="pPrivateMembers_Body">miembros privados</param>
        private  void GenerateDataBaseProperttyBody(Table pTable, out String pPublicProperty_Body, out String pPrivateMembers_Body)
        {

            StringBuilder wPrivateMembers_BODY = new StringBuilder();
            StringBuilder wPublicProperty_BODY = new StringBuilder();

            foreach (Column wColumn in pTable.Columns)
            {
                //Si es una columna no permitida
                if (!GenEngineBase.NotSupportTypes_ToIncludeInBackEnd.Contains(wColumn.Type.ToLower()))
                {
                    if (wColumn.Selected)
                    {
                        //Privados
                        wPrivateMembers_BODY.Append(GenEngineBase.GeneratePrivateMembers(wColumn.Name, wColumn.Type));
                        //Publicos (con Get y Set)
                        wPublicProperty_BODY.Append(GenEngineBase.GenerateProperties(pTable.Name, wColumn.Name, wColumn.Type));
                    }
                }
            }
            pPrivateMembers_Body = wPrivateMembers_BODY.ToString();
            pPublicProperty_Body = wPublicProperty_BODY.ToString();
            

        }



    }

    /// <summary>
    /// Genera entities a partir de un StoredProcedure.-
    /// </summary>
    internal class EntityGenEngineSP
    {
        private EntityGenerationInfo _EntityGenerationInfo;

        public EntityGenerationInfo EntityGenerationInfo
        {
            get { return _EntityGenerationInfo; }
            set { _EntityGenerationInfo = value; }
        }

        /// <summary>
        /// Genera por cada StoredProcedure una Entity y una Entities.-
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns>string </returns>
        public string GeneratesDataBaseCode(StoreProcedure pStoredProcedure)
        {
            StringBuilder wClassContainer = new StringBuilder();
            string wPrivateMembers_BODY = String.Empty;
            string wPublicProperty_BODY = String.Empty;


            string wEntityEnvelop = GenEngineBase.Entity_Template.Replace(CommonConstants.CONST_ENTITY_NAME, pStoredProcedure.Name);
            wEntityEnvelop = wEntityEnvelop.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX, _EntityGenerationInfo.TemplateSettingObject.Entities.EntitySufix);
            wEntityEnvelop = wEntityEnvelop.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION, _EntityGenerationInfo.TemplateSettingObject.Entities.CollectionsSufix);

            GenerateDataBaseProperttyBody(pStoredProcedure, out  wPublicProperty_BODY, out wPrivateMembers_BODY);

            wEntityEnvelop = wEntityEnvelop.Replace(CommonConstants.CONST_ENTITY_PRIVATE_MEMBERS_BODY, wPrivateMembers_BODY);
            wEntityEnvelop = wEntityEnvelop.Replace(CommonConstants.CONST_ENTITY_PUBLIC_PROPERTY_BODY, wPublicProperty_BODY);

            wClassContainer.Append(wEntityEnvelop);
            return wClassContainer.ToString();
        }

        /// <summary>
        /// Retorna codigo de miembros privados + los atributos publicos.-
        /// </summary>
        /// <param name="pStoredProcedure">StoredProcedure</param>
        /// <param name="pPublicProperty_Body">atributos publicos</param>
        /// <param name="pPrivateMembers_Body">miembros privados</param>
        private void GenerateDataBaseProperttyBody(StoreProcedure pStoredProcedure, out String pPublicProperty_Body, out String pPrivateMembers_Body)
        {
            StringBuilder wPrivateMembers_BODY = new StringBuilder();
            StringBuilder wPublicProperty_BODY = new StringBuilder();


            foreach (SPParameter wSPParameter in pStoredProcedure.Parameters)
            {
                //Si es un tipo parametro no permitido
                if (!GenEngineBase.NotSupportTypes_ToIncludeInBackEnd.Contains(wSPParameter.Type.ToLower()))
                {
                    if (wSPParameter.Selected)
                    {
                        //Privados
                        wPrivateMembers_BODY.Append(
                            GenEngineBase.GeneratePrivateMembers(wSPParameter.Name, wSPParameter.Type));
                        //Publicos (con Get y Set)
                        wPublicProperty_BODY.Append(
                            GenEngineBase.GenerateProperties(wSPParameter.Name, wSPParameter.Name, wSPParameter.Type));
                    }
                }
            }
            pPrivateMembers_Body = wPrivateMembers_BODY.ToString();
            pPublicProperty_Body = wPublicProperty_BODY.ToString();


        }

    }

    /// <summary>
    /// Genera entities a partir de un XSD Schema.-
    /// </summary>
    public class SchemEntityGenEngine
    {
        private static EntityGenerationInfo _EntityGenerationInfo;

        public static EntityGenerationInfo EntityGenerationInfo
        {
            get { return _EntityGenerationInfo; }
            set
            {
                _EntityGenerationInfo = value;
                ElementTypeGenEngine.TemplateSettingObject = value.TemplateSettingObject;
            }
        }

        private static Template _BETemplate = null;

        static SchemEntityGenEngine()
        {
            _BETemplate =  TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.EntityTemplate);
        }

        /// <summary>
        /// Se encarga de generar todo el codigo para un esquema
        /// </summary>
        /// <param name="pEntityGenerationInfo"></param>
        /// <param name="pIsToBussinessEntities"></param>
        /// <returns>Codigo generado apartir de un XSD</returns>
        public static string GenCode(bool  pIsToBussinessEntities)
        {
            StringBuilder wClassContainer = new StringBuilder();
            StringBuilder wPRIVATE_MEMBERS_BODY = null;
            StringBuilder wPUBLIC_PROPERTY_BODY = null;
            string wEntity_Template = String.Empty;
           

            string wColections = GenerateColectionsMaxOccurs(_EntityGenerationInfo.Entities[0].GlobalElementComplexTypeList, pIsToBussinessEntities);

            wClassContainer.Append(wColections);

            foreach (GlobalElementComplexType wClass in _EntityGenerationInfo.Entities[0].GlobalElementComplexTypeList)
            {
                //TODO: Determina si usa patron de nombrado de BE segun si se trata de armar un BE o un Request o Responce
                if (pIsToBussinessEntities)
                {wEntity_Template = GenEngineBase.Entity_TemplateClassOnly;}
                else{wEntity_Template = GenEngineBase.Entity_TemplateClassOnlyService;}

                if (wClass.ChildElements.Count > 0)
                {
                    GenerateSchemaProperttyBody(wClass.ChildElements, out wPUBLIC_PROPERTY_BODY, out wPRIVATE_MEMBERS_BODY, pIsToBussinessEntities);

                    //Privado en [PRIVATE_BODY]
                    wEntity_Template = wEntity_Template.Replace(CommonConstants.CONST_ENTITY_PRIVATE_MEMBERS_BODY, wPRIVATE_MEMBERS_BODY.ToString());

                    //Publico en [PROPERTY_BODY]
                    wEntity_Template = wEntity_Template.Replace(CommonConstants.CONST_ENTITY_PUBLIC_PROPERTY_BODY, wPUBLIC_PROPERTY_BODY.ToString());

                    //Reemplaza [EntityName] por elnombre de la clase
                    wEntity_Template = wEntity_Template.Replace(CommonConstants.CONST_ENTITY_NAME, wClass.Name);

                    wClassContainer.Append(wEntity_Template);
                }
            }

        


            string wBECode = GenEngineBase.Entity_TemplateEnvelopeOnly;
            //Agrego al cuerpo [BODY] el contenido de ClassContainer;
            wBECode = wBECode.Replace(CommonConstants.CONST_BODY, wClassContainer.ToString());

            //agrego namespace,.
            wBECode = wBECode.Replace(CommonConstants.CONST_NAMESPACE_BE_DE, _EntityGenerationInfo.TemplateSettingObject.Namespaces.BusinessEntities);

            //Prefijos o sufijos de colecciones
            if (pIsToBussinessEntities)
            {
                wBECode = wBECode.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,
                                        _EntityGenerationInfo.TemplateSettingObject.Entities.EntitySufix);
                wBECode = wBECode.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION,
                                     _EntityGenerationInfo.TemplateSettingObject.Entities.CollectionsSufix);
            }
            else
            {
                wBECode = wBECode.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,
                                        _EntityGenerationInfo.TemplateSettingObject.Entities.BusinessDataSufix);
                wBECode = wBECode.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION,
                                    _EntityGenerationInfo.TemplateSettingObject.Entities.BusinessDataCollectionSufix);
            }

            wClassContainer = null;
            return wBECode;

        }

        /// <summary>
        /// Genera una las entidades a partir de un XSD transformado a una lista del tipo <see>GlobalElementComplexTypeList</see>
        /// 
        /// </summary>
        /// <param name="pEntityInfo"></param>
        /// <param name="pIsToBussinessEntities">Indica si fue lanzado desde una generacion de Entidades de negocio o 
        /// fue lanzado con la intencion de armar lo un request o responce para un servicio. 
        /// Es decir las BussinessData de estos mismos.</param>
        /// <returns>Codigo generado apartir de un XSD</returns>
        public static string GenCode(EntityInfo pEntityInfo,bool pIsToBussinessEntities)
        {
            StringBuilder wClassContainer = new StringBuilder();
            StringBuilder wPRIVATE_MEMBERS_BODY = null;
            StringBuilder wPUBLIC_PROPERTY_BODY = null;
            string wEntity_Template = String.Empty;


            string wColections = GenerateColectionsMaxOccurs(pEntityInfo.GlobalElementComplexTypeList, pIsToBussinessEntities);

            wClassContainer.Append(wColections);

            foreach (GlobalElementComplexType wClass in pEntityInfo.GlobalElementComplexTypeList)
            {
                //TODO: Determina si usa patron de nombrado de BE segun si se trata de armar un BE o un Request o Responce
                if (pIsToBussinessEntities)
                {wEntity_Template = GenEngineBase.Entity_TemplateClassOnly;}
                else { wEntity_Template = GenEngineBase.Entity_TemplateClassOnlyService; }

                if (wClass.ChildElements != null && wClass.ChildElements.Count > 0)
                {
                    GenerateSchemaProperttyBody(wClass.ChildElements, out wPUBLIC_PROPERTY_BODY, out wPRIVATE_MEMBERS_BODY, pIsToBussinessEntities);

                    //Privado en [PRIVATE_BODY]
                    wEntity_Template = wEntity_Template.Replace(CommonConstants.CONST_ENTITY_PRIVATE_MEMBERS_BODY, wPRIVATE_MEMBERS_BODY.ToString());
                    
                    //Publico en [PROPERTY_BODY]
                    wEntity_Template = wEntity_Template.Replace(CommonConstants.CONST_ENTITY_PUBLIC_PROPERTY_BODY, wPUBLIC_PROPERTY_BODY.ToString());

                    //Reemplaza [EntityName] por elnombre de la clase
                    wEntity_Template = wEntity_Template.Replace(CommonConstants.CONST_ENTITY_NAME, wClass.Name);

                    wClassContainer.Append(wEntity_Template);
                }
            }

            //agrego namespace
            wClassContainer.Replace(CommonConstants.CONST_NAMESPACE_BE_DE, pEntityInfo.Namespace);


            //Prefijos o sufijos de colecciones
            if (pIsToBussinessEntities)
            {
                wClassContainer.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,
                                        _EntityGenerationInfo.TemplateSettingObject.Entities.EntitySufix);
                wClassContainer.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION,
                                     _EntityGenerationInfo.TemplateSettingObject.Entities.CollectionsSufix);
            }
            else
            {
                wClassContainer.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,
                                        _EntityGenerationInfo.TemplateSettingObject.Entities.BusinessDataSufix);
                wClassContainer.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION,
                                    _EntityGenerationInfo.TemplateSettingObject.Entities.BusinessDataCollectionSufix);
            }

            return wClassContainer.ToString(); 

        }

        /// <summary>
        /// Genera las colecciones para todos los nodos marcados cun MaxOccurs > 1 este es el patron para determinar que es un contenedor
        /// </summary>
        /// <param name="pGlobalElementComplexTypeList"></param>
        /// <param name="pIsToBussinessEntities"></param>
        /// <returns>String con las colecciones</returns>
        private static string GenerateColectionsMaxOccurs(List<GlobalElementComplexType> pGlobalElementComplexTypeList, bool pIsToBussinessEntities)
        {
            StringBuilder wCollections = new StringBuilder();

            String wSchemaCollectionTemplate;//= _BETemplate.Keys.GetKey ("SchemaCollectionTemplate").TextContent; 
            if (pIsToBussinessEntities)
            { wSchemaCollectionTemplate = _BETemplate.Keys.GetKey("SchemaCollectionTemplate").TextContent; }
            else { wSchemaCollectionTemplate = _BETemplate.Keys.GetKey("SchemaCollectionTemplateService").TextContent; }


            String wCollectionCode;

            foreach (GlobalElementComplexType wClass in pGlobalElementComplexTypeList)
            {
                if (wClass.MaxOccurs > 1)
                {
                    //Al no tener hijos limpio toda posibilidad de agregar atributos.-
                    wCollectionCode = wSchemaCollectionTemplate.Replace(CommonConstants.CONST_BODY, String.Empty);

                    //Establesco nombre de la entidad -
                    wCollectionCode = wCollectionCode.Replace(CommonConstants.CONST_ENTITY_NAME, wClass.Name);

                    wCollections.Append(wCollectionCode);
                }

            }
            return wCollections.ToString();
        }

        private static void GenerateSchemaProperttyBody(List<TreeNode> pChildElements,
            out StringBuilder pPUBLIC_PROPERTY_BODY, out StringBuilder pPRIVATE_MEMBERS_BODY, bool pIsToBussinessEntities)
        {
            pPUBLIC_PROPERTY_BODY = new StringBuilder();
            pPRIVATE_MEMBERS_BODY = new StringBuilder();
            string wPrivate = string.Empty;
            string wPublic = string.Empty;



            foreach (TreeNode wChildElement in pChildElements)
            {
                //Elementos simples (int string etc)
                if (wChildElement.Tag.GetType().Name.Contains("GlobalElementType"))
                {
                    ElementTypeGenEngine.GenerateGlobalElementType(wChildElement.Tag, out wPublic, out wPrivate);

                }
                //Tipos de datos complejos
                if (wChildElement.Tag.GetType().Name.Contains("GlobalElementComplexType"))
                {
                    ElementTypeGenEngine.GenerateGlobalElementComplexType(wChildElement.Tag, out wPublic, out wPrivate, pIsToBussinessEntities);
                }


                pPUBLIC_PROPERTY_BODY.Append(wPublic);
                pPRIVATE_MEMBERS_BODY.Append(wPrivate);
                pPRIVATE_MEMBERS_BODY.Append(Environment.NewLine);
            }


        }

    }


    internal class GenEngineBase
    {
        public static string NotSupportTypes_ToIncludeInBackEnd;

        public static string Entity_Template;
        public static string Entity_Property_Template;
        public static string Entity_Property_TemplateBinary;
        
        public static string Entity_TemplateClassOnly;
        public static string Entity_TemplateClassOnlyService;
        public static string Entity_TemplateEnvelopeOnly;
        public static string Entity_SchemaCollectionTemplate;
        private static Template _BETemplate = null;
        private static Template _PatternTemplate = null;
        
        static String _PrivateMemberPrefix;
        
        static GenEngineBase()
        {

            _BETemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.EntityTemplate);
            _PatternTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.Patterns);

            Entity_Property_Template =
                _BETemplate.Keys.GetKey("PropertyTemplate").TextContent;

            Entity_Property_TemplateBinary = _BETemplate.Keys.GetKey("PropertyTemplateBinary").TextContent;
            Entity_Template = _BETemplate.Keys.GetKey("Template").TextContent;

            Entity_TemplateClassOnly =
                _BETemplate.Keys.GetKey("TemplateClassOnly").TextContent;

            Entity_TemplateClassOnlyService =
                _BETemplate.Keys.GetKey("TemplateClassOnlyToService").TextContent;

            Entity_TemplateEnvelopeOnly =
                _BETemplate.Keys.GetKey("TemplateEnvelopeOnly").TextContent;

            Entity_SchemaCollectionTemplate = _BETemplate.Keys.GetKey("SchemaCollectionTemplate").TextContent;

             _PrivateMemberPrefix = _PatternTemplate.Keys.GetKey("PrivateMemberPrefixPattern").TextContent;

             NotSupportTypes_ToIncludeInBackEnd = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.NotSupportTypes).Keys.GetKey("ToIncludeInBackEnd").TextContent; ;
        }

        /// <summary>
        /// Declaracion de un miembro privado:
        /// Ej:
        /// private int? mi_IdArticulo;
        /// </summary>
        /// <param name="pItemName"></param>
        /// <param name="pType"></param>
        /// <returns>string</returns>
        public static string GeneratePrivateMembers(string pItemName, string pType)
        {
            StringBuilder strCode = new StringBuilder();

            //"private DateTime? mdt_Fecha;";
            strCode.Append("private ");
            strCode.Append(ParametersDAC.GetTargetType(pType));
            strCode.Append(ParametersDAC.GetNullableToken(pType));
            strCode.Append(" ");
            strCode.Append(_PrivateMemberPrefix.Replace(CommonConstants.CONST_ENTITY_PREFIX_TYPE, ParametersDAC.GetPrefixType(pType)));
            strCode.Append(pItemName);
            strCode.Append(";");
            strCode.Append(Environment.NewLine);

            return strCode.ToString();
        }

        /// <summary>
        /// Obtiene el seteo parametro para Aplication Block
        /// </summary>
        /// <param name="pObjectName">Tabla o Store procedure ver <see cref="String"/></param>
        /// <param name="pItemName">Nombre Columna o parametro</param>
        /// <param name="pType">Tipo de SQL que pertecene a  Columna o Parametro</param>
        public static string GenerateProperties(string pObjectName, string pItemName, string pType)
        {
            String strCode = String.Empty;
            if (pType.ToLower() == "binary" || pType.ToLower() == "varbinary" || pType.ToLower() == "image" || pType.ToLower() == "tinyint")
                strCode = Entity_Property_TemplateBinary;
            else
                strCode = Entity_Property_Template;
            
            strCode = strCode.Replace(CommonConstants.CONST_TYPENAME, ParametersDAC.GetTargetType(pType.ToLower()) + ParametersDAC.GetNullableToken(pType.ToLower()));

            strCode = strCode.Replace(CommonConstants.CONST_SCHEMATYPENAME, ParametersDAC.GetTargetSchemaTypeByName(pType.ToLower()));
           

            strCode = strCode.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, pItemName);
            strCode = strCode.Replace(CommonConstants.CONST_ENTITY_PREFIX_TYPE, ParametersDAC.GetPrefixType(pType));


            return strCode;
        }

        


    }
}
