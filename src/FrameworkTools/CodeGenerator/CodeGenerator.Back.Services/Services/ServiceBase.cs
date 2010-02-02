//using System;
//using System.IO;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Text;
//using System.Windows.Forms;
//using Fwk.CodeGenerator.Common;


//namespace CodeGenerator.Back.Services
//{

//    public class ServiceHelper
//    {
        
//        internal static Template ServiceTemplate = null;
//        internal static Template CodeGeneratorTemplate = null;
//        internal static Template PatternTemplate = null;
//        internal static Template BETemplate = null;
//        internal static string ObjectPrefix;
//        internal  static EntityGenerationInfo _EntityGenerationInfo;
        
        

//        public  static EntityGenerationInfo EntityGenerationInfo
//        {
//            get { return _EntityGenerationInfo; }
//            set
//            {
//                _EntityGenerationInfo = value;
//                XSDGenerator.TemplateSettingObject = value.TemplateSettingObject;
//            }
//        }
       
        

//        static ServiceHelper()
//        {
            
//            ServiceTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.ServiceTemplate);
//            CodeGeneratorTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.CodeGenerator);
//            PatternTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.Patterns);
//            BETemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.EntityTemplate);
//            ObjectPrefix =
//                PatternTemplate.Keys.GetKey("PrivateMemberPrefixPattern").TextContent.Replace(
//                    CommonConstants.CONST_ENTITY_PREFIX_TYPE,
//                    PatternTemplate.Keys.GetKey("ObjectPrefix").TextContent);
//        }


//        internal static string CreateReqResBody(EntityInfo pEntityInfo)
//        {
//            int wLastElementIndex = pEntityInfo.GlobalElementComplexTypeList.Count - 1;


//            String wszName = pEntityInfo.GlobalElementComplexTypeList[wLastElementIndex].Name;


//            StringBuilder wszRESBody = new StringBuilder();
//            wszRESBody.Append("private " + wszName + ObjectPrefix + wszName + ";");
//            wszRESBody.Append(Environment.NewLine);
//            wszRESBody.Append(BETemplate.Keys.GetKey("ComplexTypePropertyTemplate").TextContent);
//            wszRESBody.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, wszName);
//            wszRESBody.Replace(CommonConstants.CONST_TYPENAME, wszName);

//            return wszRESBody.ToString();
//        }

//        //private static string CreateReqResBody(EntityInfo pEntityInfo)
//        //{
//        //    int wLastElement = pEntityInfo.GlobalElementComplexTypeList.Count - 1;


//        //    String wszName = pEntityInfo.GlobalElementComplexTypeList[wLastElement].Name;


//        //    StringBuilder wszRESBody = new StringBuilder();
//        //    wszRESBody.Append("private " + wszName + ObjectPrefix + wszName + ";");
//        //    wszRESBody.Append(Environment.NewLine);
//        //    wszRESBody.Append(SericeHelper.BETemplate.Keys.GetKey("ComplexTypePropertyTemplate").TextContent);
//        //    wszRESBody.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, wszName);
//        //    wszRESBody.Replace(CommonConstants.CONST_TYPENAME, wszName);

//        //    return wszRESBody.ToString();
//        //}
//    }
//}
