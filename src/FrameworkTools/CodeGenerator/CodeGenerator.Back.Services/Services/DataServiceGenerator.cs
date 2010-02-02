//using System;
//using System.IO;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Windows.Forms;

//using CodeGenerator.Back.Entities;
//using Fwk.CodeGenerator.Common;
//using Fwk.DataBase.DataEntities;


//namespace CodeGenerator.Back.Services
//{
     

//    /// <summary>
//    /// Clase para generar Servicios a partir de tablas de base de datos. 
//    /// Genera un servicio por cada metodo seleccionado.
//    /// </summary>
//    public class DataServiceGenerator
//    {
//        public static EntityGenerationInfo EntityGenerationInfo
//        {
//            get { return ServiceHelper.EntityGenerationInfo; }
//            set
//            {
//                ServiceHelper.EntityGenerationInfo = value;
//                SchemEntityGenEngine.EntityGenerationInfo = value;
//                ElementTypeGenEngine.TemplateSettingObject = value.TemplateSettingObject;
//            }
//        }

//        private static XSDTreeView _XSDTreeView = null;

//        static  DataServiceGenerator()
//        {
//            _XSDTreeView = new XSDTreeView();    
//        }
        

//        /// <summary>
//        /// Genera codigo :
//        /// Service, Req, Res agrupado por tablas y por cada metodo.-
//        /// </summary>
//        /// <param name="_EntityGenerationInfo"></param>
//        /// <returns></returns>
//        public static TreeNode GenerateCode()
//        {
//            TreeNode wNodeTable = null;
            
//            TreeNode treeNodeService = new TreeNode("SVC");
//            treeNodeService.Name = "StandarSVC";

//            foreach (EntityInfo wEntityInfo in ServiceHelper.EntityGenerationInfo.Entities)
//            {
//                wNodeTable = new TreeNode(wEntityInfo.Name);

                
//                BuildMethods(wNodeTable, wEntityInfo);

//                wNodeTable.Name = "ServiceTable";

//                treeNodeService.Nodes.Add(wNodeTable);
//            }

//            return treeNodeService;
//        }

//        #region Private Methods

//        /// <summary>
//        /// Por cada metodo crear:
//        /// XSD Files (REQ & Resp)
//        /// Update
//        /// </summary>
//        /// <param name="pEntityInfo"></param>
//        static void BuildMethods(TreeNode pNodeTable, EntityInfo pEntityInfo)
//        {
//            TreeNode wNodeMethod = null;
//            string wError = String.Empty;
//            string wServiceName = string.Empty;
//            bool _Continue;
//            foreach (MethodInfo pMethodInfo in pEntityInfo.Methods)
//            {
//                wNodeMethod = new TreeNode(pMethodInfo.Name);
//                wNodeMethod.Name = "ServiceTableMethod";
                
//                //Agrego los esquemas de los archivos XSD al wNodeMethod como nodos hijos
//                if (pEntityInfo.Table != null)
//                    _Continue = BuildXSDFile(pEntityInfo.Table, pMethodInfo, wNodeMethod, out wServiceName, out wError);
//                else
//                    _Continue = BuildXSDFile(pEntityInfo.StoredProcedure, pMethodInfo, wNodeMethod, out wServiceName, out wError);

//               if (_Continue)
//               {
//                   //Agrego codigo .net del req y response (ISVC) al treenode
//                   BuildDotNetISVCCode(pEntityInfo, wNodeMethod, wServiceName);

//                   //Agrego el Servicio
//                   BuildDotNetSVCCode(pEntityInfo, wNodeMethod, wServiceName);
//                   pNodeTable.Nodes.Add(wNodeMethod);
//               }
//            }
            
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pTable"></param>
//        /// <param name="pMethodInfo"></param>
//        /// <param name="pTreeNodeParent"></param>
//        /// <param name="pServiceName"></param>
//        static bool BuildXSDFile(Table pTable, MethodInfo pMethodInfo, TreeNode pTreeNodeParent, out string pServiceName, out string pError)
//        {
//            Boolean wContinue = false;
//            GeneratedCode wGeneratedCode = null;
//            StringDictionary sdCode = null;
//            pServiceName = String.Empty;
//            pError = "No se puede generar el {} debido a la falta de campos validos seleccionados"; ;
//            switch (pMethodInfo.Action)
//            {
//                case MethodActionType.Insert:
//                    {
//                        sdCode = XSDGenerator.GenCreate(pTable, out pServiceName);
//                        break;
//                    }
//                case MethodActionType.Update:
//                    {
//                        sdCode = XSDGenerator.GenUpdate(pTable, out pServiceName);
//                        break;
//                    }
//                case MethodActionType.Delete:
//                    {
//                        sdCode = XSDGenerator.GenDelete(pTable, out pServiceName);
//                        break;
//                    }
//                case MethodActionType.GetAllPaginated:
//                    {
//                        return false;
                       
//                    }
//                case MethodActionType.GetAll:
//                    {
//                        sdCode = XSDGenerator.GenGetAll(pTable, out pServiceName);
//                        break;
//                    }
//                case MethodActionType.Get:
//                    {
//                        return false;
                        
//                    }
//                case MethodActionType.GetByParam:
//                    {
//                        sdCode = XSDGenerator.GenGetByParam(pTable, out pServiceName);
//                        break;
//                    }
//            }
//            TreeNode wTreeNodeXsdFile = new TreeNode(pServiceName + "REQ.xsd");
//            wGeneratedCode = new GeneratedCode();
//            wGeneratedCode.Id = wTreeNodeXsdFile.Text;
//            if (sdCode.Count == 0)
//            {
//                wGeneratedCode.Code.Append(pError.Replace( "{}","Request"));
//                wContinue = false;
//            }
//            else
//            {
//                wGeneratedCode.Code.Append(sdCode["Request"].ToString());
//                wContinue = true;
//            }
//            wTreeNodeXsdFile.Tag = wGeneratedCode;
//            pTreeNodeParent.Nodes.Add(wTreeNodeXsdFile);

//            wTreeNodeXsdFile = new TreeNode(pServiceName + "RES.xsd");
//            wGeneratedCode = new GeneratedCode();
//            wGeneratedCode.Id = wTreeNodeXsdFile.Text;
//            if (sdCode.Count == 0)
//            {
//                wGeneratedCode.Code.Append(pError);
//                wGeneratedCode.Code.Replace("{}", "Response");
//            }
//            else
//            {
//                wGeneratedCode.Code.Append(sdCode["Response"].ToString());
//            }
//            wTreeNodeXsdFile.Tag = wGeneratedCode;


//            pTreeNodeParent.Nodes.Add(wTreeNodeXsdFile);

//            return wContinue;
//        }
//        static bool BuildXSDFile(StoreProcedure pStoreProcedure, MethodInfo pMethodInfo, TreeNode pTreeNodeParent, out string pServiceName, out string pError)
//        {
//            Boolean wContinue = false;
//            GeneratedCode wGeneratedCode = null;
//            StringDictionary sdCode = null;
//            pServiceName = String.Empty;
//            pError = "No se puede generar el {} debido a la falta de campos validos seleccionados"; ;

//            switch (pMethodInfo.Action)
//            {
//                case MethodActionType.Insert:
//                    {
//                        sdCode = XSDGenerator.GenCreate(pStoreProcedure, out pServiceName);
//                        break;
//                    }
//                case MethodActionType.Update:
//                    {
//                        sdCode = XSDGenerator.GenUpdate(pStoreProcedure, out pServiceName);
//                        break;
//                    }
//                case MethodActionType.Delete:
//                    {
//                        sdCode = XSDGenerator.GenDelete(pStoreProcedure, out pServiceName);
//                        break;
//                    }
//                case MethodActionType.GetAllPaginated:
//                    {
//                        return false;

//                    }
//                case MethodActionType.GetAll:
//                    {
//                        sdCode = XSDGenerator.GenGetAll(pStoreProcedure, out pServiceName);
//                        break;
//                    }
//                case MethodActionType.Get:
//                    {
//                        return false;
                        
//                    }
//                case MethodActionType.GetByParam:
//                    {
//                        sdCode = XSDGenerator.GenGetByParam(pStoreProcedure, out pServiceName);
//                        break;
//                    }
//            }
            
//            TreeNode wTreeNodeXsdFile = new TreeNode(pServiceName + "REQ.xsd");
//            wGeneratedCode = new GeneratedCode();
//            wGeneratedCode.Id = wTreeNodeXsdFile.Text;
//            if (sdCode.Count == 0)
//            {
//                wGeneratedCode.Code.Append(pError.Replace("{}", "Request"));
//                wContinue = false;
//            }
//            else
//            {
//                wGeneratedCode.Code.Append(sdCode["Request"].ToString());
//                wContinue = true;
//            }
//            wTreeNodeXsdFile.Tag = wGeneratedCode;
//            pTreeNodeParent.Nodes.Add(wTreeNodeXsdFile);

//            wTreeNodeXsdFile = new TreeNode(pServiceName + "RES.xsd");
//            wGeneratedCode = new GeneratedCode();
//            wGeneratedCode.Id = wTreeNodeXsdFile.Text;
//            wGeneratedCode.Code.Append(sdCode["Response"].ToString());
//            wTreeNodeXsdFile.Tag = wGeneratedCode;


//            pTreeNodeParent.Nodes.Add(wTreeNodeXsdFile);

//            return wContinue;
//        }

//        /// <summary>
//        /// Genera el codigo .Net del req o res
//        /// </summary>
//        /// <param name="pEntityInfo"></param>
//        /// <param name="pNodeMethod"></param>
//        /// <param name="pServiceName"></param>
//        static void BuildDotNetISVCCode(EntityInfo pEntityInfo, TreeNode pNodeMethod, string pServiceName)
//        {

//            TreeNode wTreeNodeDotNetISVC = null;
//            List<GeneratedCode> wDotNetCodeList = new List<GeneratedCode>();
//            GeneratedCode wGeneratedXSDCode = null;
//            GeneratedCode wGeneratedDotNetCode = null;

//            #region codigo .net Request
//            wGeneratedXSDCode = (GeneratedCode)pNodeMethod.Nodes[0].Tag;
//            pEntityInfo.GlobalElementComplexTypeList = GetGlobalElementComplexTypeList(wGeneratedXSDCode.Code.ToString());
//            wGeneratedDotNetCode = GenerateRequestCode(pEntityInfo, pServiceName);
//            wDotNetCodeList.Add(wGeneratedDotNetCode);

//            wTreeNodeDotNetISVC = new TreeNode(pServiceName + "Request.cs");
//            wTreeNodeDotNetISVC.Tag = wGeneratedDotNetCode;
//            wGeneratedDotNetCode.Id = wTreeNodeDotNetISVC.Text;
//            pNodeMethod.Nodes.Add(wTreeNodeDotNetISVC);
//            #endregion

//            #region codigo .net Response
//            wGeneratedXSDCode = (GeneratedCode)pNodeMethod.Nodes[1].Tag;
//            pEntityInfo.GlobalElementComplexTypeList = GetGlobalElementComplexTypeList(wGeneratedXSDCode.Code.ToString());
//            //TODO: ServiceGenerator
//            wGeneratedDotNetCode = GenerateResponseCode(pEntityInfo, pServiceName);
//            wDotNetCodeList.Add(wGeneratedDotNetCode);

//            wTreeNodeDotNetISVC = new TreeNode(pServiceName + "Response.cs");
//            wTreeNodeDotNetISVC.Tag = wGeneratedDotNetCode;
//            wGeneratedDotNetCode.Id = wTreeNodeDotNetISVC.Text;
//            pNodeMethod.Nodes.Add(wTreeNodeDotNetISVC);
//            #endregion
//        }

//        /// <summary>
//        /// Genera el codigo .Net del req o res
//        /// </summary>
//        /// <param name="pEntityInfo"></param>
//        /// <param name="pNodeMethod"></param>
//        /// <param name="pServiceName"></param>
//        static void BuildDotNetSVCCode(EntityInfo pEntityInfo, TreeNode pNodeMethod, string pServiceName)
//        {
//            TreeNode wTreeNodeDotNetSVC = null;
//            List<GeneratedCode> wDotNetCodeList = new List<GeneratedCode>();
           
//            GeneratedCode wGeneratedDotNetCode = null;

//            #region codigo .net servicio
//            wGeneratedDotNetCode = GenerateServiceCode( pEntityInfo, pServiceName);
//            wDotNetCodeList.Add(wGeneratedDotNetCode);

//            wTreeNodeDotNetSVC = new TreeNode(wGeneratedDotNetCode.Id);
//            wTreeNodeDotNetSVC.Tag = wGeneratedDotNetCode;
//            pNodeMethod.Nodes.Add(wTreeNodeDotNetSVC);
//            #endregion

            
//        }

//        /// <summary>
//        /// Genera una lista de GlobalElementComplexType: Este List<GlobalElementComplexType> reprecenta un esquema XSD
//        /// </summary>
//        /// <param name="pCode">String con el XSD</param>
//        /// <returns>Lista de <see cref="GlobalElementComplexType"/> </returns>
//        static List<GlobalElementComplexType> GetGlobalElementComplexTypeList(string pCode)
//        {
//            string fileName = "temp.xsd";
//            Fwk.HelperFunctions.FileFunctions.SaveTextFile(fileName, pCode,false);
//            FileInfo f = new FileInfo(fileName);
//            f.Refresh();
//            _XSDTreeView.LoadSchemaByName(fileName);


//            return _XSDTreeView.GetComplexTypes();
//        }

//        #endregion

//        public static GeneratedCode GenerateServiceCode(EntityInfo pEntityInfoRequest, string pServiceName)
//        {

//            String wSignature = ServiceHelper.CodeGeneratorTemplate.Keys.GetKey("Signature").TextContent;

//            GeneratedCode wGeneratedCode = null;


//            #region [ServiceClass]
//            wGeneratedCode = new GeneratedCode();

//            wGeneratedCode.Id = pServiceName + "Service.cs";
//            wGeneratedCode.Code.Append(wSignature);
//            wGeneratedCode.Code.Append(ServiceHelper.ServiceTemplate.Keys.GetKey("ServiceClass").TextContent);
//            wGeneratedCode.Tag = pEntityInfoRequest.Name;

//            //Namespase
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_NAMESPACE_SVC,
//                           ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Namespaces.BusinessService);
//            //Namespase
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_NAMESPACE_BC,
//                           ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Namespaces.BusinessComponents);
//            //Namespase
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_NAMESPACE_BE_DE,
//                           ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Namespaces.BusinessEntities);
//            //Namespase
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_NAMESPACE_ISVC,
//                           ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Namespaces.InterfaceServices + "." + pServiceName);

//            //ServiceName
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_SERVICE_NAME, pServiceName);



//            #endregion

//            return wGeneratedCode;
//        }

//        /// <summary>
//        /// Genera un request para una entidad tabla o store procedure standar (simple)
//        /// </summary>
//        /// <param name="pEntityInfoRequest"></param>
//        /// <param name="pServiceName"></param>
//        /// <returns></returns>
//        public static GeneratedCode GenerateRequestCode(EntityInfo pEntityInfoRequest, string pServiceName)
//        {
//            String wFirstEntityName = String.Empty;
//            String wSignature = ServiceHelper.CodeGeneratorTemplate.Keys.GetKey("Signature").TextContent;

//            GeneratedCode wGeneratedCode = null;
//            String wBody = String.Empty;

//            #region [REQClass]
//            wGeneratedCode = new GeneratedCode();

//            wGeneratedCode.Id = "Request";
//            wGeneratedCode.Code.Append(wSignature);
//            wGeneratedCode.Code.Append(ServiceHelper.ServiceTemplate.Keys.GetKey("REQClass").TextContent);
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_SERVICE_REQUEST_CLASS, ServiceHelper.ServiceTemplate.Keys.GetKey("RequestClass").TextContent);



//            //Agrega la entidad
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_ENTITY_EntitiesClass, SchemEntityGenEngine.GenCode(pEntityInfoRequest, false));
//            //wGeneratedCode.Code.Replace(CommonConstants.CONST_ENTITY_EntitiesClass, DatabaseEntityGenEngine.GenerateBEWhioutEnvelope(pEntityInfoRequest));

//            wGeneratedCode.Code.Replace(CommonConstants.CONST_BODY, ServiceHelper.CreateReqResBody(pEntityInfoRequest));

//            //Obtencion del primer elemento del esquema para ser agredado como Request<IEntity>
//            //wFirstEntityName = GetBussinesData(pEntityInfoRequest);
//            wFirstEntityName = ServiceHelper.PatternTemplate.Keys.GetKey("BussinessDataCollectionNamePattern").TextContent.Replace(CommonConstants.CONST_ENTITY_NAME, pEntityInfoRequest.Name);
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_SERVICE_BussinessData, wFirstEntityName);


//            //Namespase
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_NAMESPACE_ISVC, ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Namespaces.InterfaceServices + "." + pServiceName);
//            //ServiceName
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_SERVICE_NAME, pServiceName);




//            //Prefijo - Sufijo de colecciones
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION,
//                                        ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Entities.BusinessDataCollectionSufix);
//            //Prefijo - Sufijo de entidades
//            //wGeneratedCode.Code.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,
//            //                            _EntityGenerationInfo.TemplateSettingObject.Entities.BusinessDataSufix);

//            #endregion

//            return wGeneratedCode;
//        }

//        /// <summary>
//        /// Genera un Response para una entidad tabla o store procedure standar (simple)
//        /// </summary>
//        /// <param name="pEntityGenerationInfo"></param>
//        /// <param name="pEntityInfoResponse"></param>
//        /// <param name="pServiceName"></param>
//        /// <returns></returns>
//        public static GeneratedCode GenerateResponseCode(EntityInfo pEntityInfoResponse, string pServiceName)
//        {
//            String wFirstEntityName = String.Empty;
//            String wSignature = ServiceHelper.CodeGeneratorTemplate.Keys.GetKey("Signature").TextContent;

//            GeneratedCode wGeneratedCode = null;
//            String wBody = String.Empty;

//            #region [RESClass]

//            wGeneratedCode = new GeneratedCode();

//            wGeneratedCode.Id = "Response";
//            wGeneratedCode.Code.Append(wSignature);
//            wGeneratedCode.Code.Append( ServiceHelper.ServiceTemplate.Keys.GetKey("RESClass").TextContent);

//            wGeneratedCode.Code.Replace(CommonConstants.CONST_SERVICE_RESPONSE_CLASS,
//                                         ServiceHelper.ServiceTemplate.Keys.GetKey("ResponseClass").TextContent);

//            pEntityInfoResponse.Namespace = ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Namespaces.BusinessEntities;

//            wGeneratedCode.Code.Replace(CommonConstants.CONST_ENTITY_EntitiesClass, SchemEntityGenEngine.GenCode(pEntityInfoResponse, false));
//            //wGeneratedCode.Code.Replace(CommonConstants.CONST_ENTITY_EntitiesClass, DatabaseEntityGenEngine.GenerateBEWhioutEnvelope(pEntityInfoResponse));

//            wGeneratedCode.Code.Replace(CommonConstants.CONST_BODY, ServiceHelper.CreateReqResBody(pEntityInfoResponse));

//            //Obtencion del primer elemento del esquema para ser agredado como Response<IEntity>
//            //wFirstEntityName = GetBussinesData(pEntityInfoResponse);
//            wFirstEntityName =  ServiceHelper.PatternTemplate.Keys.GetKey("BussinessDataCollectionNamePattern").TextContent.Replace(CommonConstants.CONST_ENTITY_NAME, pEntityInfoResponse.Name);
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_SERVICE_BussinessData, wFirstEntityName);

//            //Namespase
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_NAMESPACE_ISVC,
//                                        ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Namespaces.InterfaceServices + "." + pServiceName);
//            //ServiceName
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_SERVICE_NAME, pServiceName);

//            //Prefijo - Sufijo de colecciones
//            wGeneratedCode.Code.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION,
//                                        ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Entities.BusinessDataCollectionSufix);
//            //Prefijo - Sufijo de entidades
//            //wGeneratedCode.Code.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,
//            //                            pEntityGenerationInfo.TemplateSettingObject.Entities.BusinessDataSufix);
//            #endregion


//            return wGeneratedCode;
//        }

       
//    }
//}
