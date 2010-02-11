using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using CodeGenerator.Back.ObjectModel;
using CodeGenerator.Back.Entities;
using CodeGenerator.Back.Common;

namespace CodeGenerator.Back.Services
{
    /// <summary>
    /// Clase que genera Request, Response y servicios a partir de esquemas XSD
    /// </summary>
    public class ServiceGenerator
    {
      
        public static EntityGenerationInfo EntityGenerationInfo
        {
          get { return ServiceHelper.EntityGenerationInfo; }
            set
            {
                ServiceHelper.EntityGenerationInfo = value;
                SchemEntityGenEngine.EntityGenerationInfo = value;
            }
        }

        public static TreeNode GenerateCode(string pServiceName)
        {
            String wFirstEntityName = String.Empty;
            String wSignature = ServiceHelper.CodeGeneratorTemplate.Keys.GetKey ("Signature").TextContent;
            List<GeneratedCode> wGeneratedCodeList = new List<GeneratedCode>();
            GeneratedCode wGeneratedCode = null; 
            String wBody = String.Empty;
           

            #region [ServiceClass]
            wGeneratedCode = new GeneratedCode();
           
            wGeneratedCode.Id = pServiceName + "Service.cs";
            wGeneratedCode.Code.Append(wSignature);
            wGeneratedCode.Code.Append(ServiceHelper.ServiceTemplate.Keys.GetKey("ServiceClass").TextContent);
            wGeneratedCode.Tag = ServiceHelper.EntityGenerationInfo.Entities[0].Name;
            wGeneratedCodeList.Add(wGeneratedCode);
            #endregion


            #region [RESClass]

            wGeneratedCode = new GeneratedCode();
           
            wGeneratedCode.Id = pServiceName + "Response.cs";
            wGeneratedCode.Code.Append(wSignature);
            wGeneratedCode.Code.Append( ServiceHelper.ServiceTemplate.Keys.GetKey ("RESClass").TextContent);

            wGeneratedCode.Code.Replace(CommonConstants.CONST_SERVICE_RESPONSE_CLASS,  ServiceHelper.ServiceTemplate.Keys.GetKey ("ResponseClass").TextContent);

            ServiceHelper.EntityGenerationInfo.Entities[0].Namespace = ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Namespaces.BusinessEntities;

            wGeneratedCode.Code.Replace(CommonConstants.CONST_ENTITY_EntitiesClass, SchemEntityGenEngine.GenCode(ServiceHelper.EntityGenerationInfo.Entities [0],false));

            wGeneratedCode.Code.Replace(CommonConstants.CONST_BODY,ServiceHelper.CreateReqResBody(ServiceHelper.EntityGenerationInfo.Entities[0]));
            wFirstEntityName = GetBussinesData(ServiceHelper.EntityGenerationInfo.Entities[0]); 
            wGeneratedCode.Code.Replace(CommonConstants.CONST_SERVICE_BussinessData, wFirstEntityName);
            wGeneratedCodeList.Add(wGeneratedCode);


            #endregion


            #region [REQClass]
            wGeneratedCode = new GeneratedCode();

            wGeneratedCode.Id = pServiceName + "Request.cs";
            wGeneratedCode.Code.Append(wSignature);
            wGeneratedCode.Code.Append( ServiceHelper.ServiceTemplate.Keys.GetKey ("REQClass").TextContent);
            wGeneratedCode.Code.Replace(CommonConstants.CONST_SERVICE_REQUEST_CLASS,  ServiceHelper.ServiceTemplate.Keys.GetKey ("RequestClass").TextContent);
            //Agrega la entidad
            wGeneratedCode.Code.Replace(CommonConstants.CONST_ENTITY_EntitiesClass  ,SchemEntityGenEngine.GenCode(ServiceHelper.EntityGenerationInfo.Entities[1],false));

            wGeneratedCode.Code.Replace(CommonConstants.CONST_BODY, ServiceHelper.CreateReqResBody(ServiceHelper.EntityGenerationInfo.Entities[1]));

            wFirstEntityName =  GetBussinesData(ServiceHelper.EntityGenerationInfo.Entities[1]);

            wGeneratedCode.Code.Replace(CommonConstants.CONST_SERVICE_BussinessData, wFirstEntityName);

            wGeneratedCodeList.Add(wGeneratedCode);
            #endregion



            foreach (GeneratedCode c in wGeneratedCodeList)
            {
                //Namespase ISVC
                c.Code.Replace(CommonConstants.CONST_NAMESPACE_ISVC, ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Namespaces.InterfaceServices + "." + pServiceName);
                //ServiceName
                c.Code.Replace(CommonConstants.CONST_SERVICE_NAME, pServiceName);

                //Prefijo - Sufijo de colecciones
                c.Code.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION,
                                            ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Entities.BusinessDataCollectionSufix);
                //Prefijo - Sufijo de entidades
                c.Code.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,
                                            ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Entities.BusinessDataSufix);
                if (c.Id == pServiceName + "Service.cs")
                {
                    //Namespase
                    c.Code.Replace(CommonConstants.CONST_NAMESPACE_SVC,
                                   ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Namespaces.BusinessService );
                    //Namespase
                    c.Code.Replace(CommonConstants.CONST_NAMESPACE_BC,
                                   ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Namespaces.BusinessComponents );
                    //Namespase
                    c.Code.Replace(CommonConstants.CONST_NAMESPACE_BE_DE,
                                   ServiceHelper.EntityGenerationInfo.TemplateSettingObject.Namespaces.BusinessEntities);

                }
            }

            return BuildTreeNode(wGeneratedCodeList);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGeneratedCodeResult"></param>
        /// <returns></returns>
        private static TreeNode BuildTreeNode(List<GeneratedCode> pGeneratedCodeResult)
        {
            TreeNode wTreeNodeSVC = new TreeNode("SVC");
            wTreeNodeSVC.Name = "CustomSVC";
            foreach (GeneratedCode wGeneratedCode in pGeneratedCodeResult)
            {
                TreeNode wTreeNode = new TreeNode(wGeneratedCode.Id);
                //wTreeNode.Text = wGeneratedCode.Id;
                wTreeNode.Tag = wGeneratedCode;
                wTreeNodeSVC.Nodes.Add(wTreeNode);
            }
            return wTreeNodeSVC;
        }  

        /// <summary>
        /// Arma la BussinesData de un Request o Response apartir del primer elemento del esquema.-
        /// </summary>
        /// <param name="pEntityInfo"></param>
        /// <returns></returns>
        private static string GetBussinesData(EntityInfo pEntityInfo)
        {
            String wNamePattern;
            int wLastElement = pEntityInfo.GlobalElementComplexTypeList.Count - 1;

            String wszName = pEntityInfo.GlobalElementComplexTypeList[wLastElement].Name;

            wNamePattern = ServiceHelper.PatternTemplate.Keys.GetKey("BussinessDataNamePattern").TextContent;
    
            StringBuilder wszRESBody = new StringBuilder();
            //Primero inserto el patron Ej: [Entidad][Patron de nombrado]
            wszRESBody.Append(wNamePattern);

            wszRESBody.Replace(CommonConstants.CONST_ENTITY_NAME, wszName);
            return wszRESBody.ToString();
        }
    }


    
}
