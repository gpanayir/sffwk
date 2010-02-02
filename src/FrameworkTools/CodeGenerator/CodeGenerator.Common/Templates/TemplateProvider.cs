//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Xml;

//using Fwk.HelperFunctions;
//using Fwk.Xml;

//namespace Fwk.CodeGenerator.Common
//{
//    public enum TemplateProviderEnum
//    {
//        CodeGenerator,
//        TDGTemplate,
//        DACTemplate,
//        BCTemplate,
//        EntityTemplate,
//        StoredProcedureTemplate,
//        ServiceTemplate,
//        NamespaceTemplate,
//        Patterns,
//        XSDTemplate, NotSupportTypes
//    };

//    /// <summary>
//    /// Clase estatica que provee de todos los templates para la generacion configurable de codigo.-
//    /// </summary>
//    public class TemplateProvider
//    {
//        private static string _TemplatePath = System.AppDomain.CurrentDomain.BaseDirectory + @"Templates";
//        private static XmlDocument _XmlTemplates = null;
//        private static Templates _Templates = null;
//        public static Templates Templates
//        {
//            get{return _Templates;}
//        }

//        /// <summary>
//        /// Constructor estático
//        /// </summary>
//        static TemplateProvider()
//        {
//            _XmlTemplates = new XmlDocument();
//            _XmlTemplates.Load(_TemplatePath + @"\Templates.xml");
//            LoadTemplates();
//        }


//        /// <summary>
//        /// Obtiene el patron Namespace de acuerdo la capa pasada por parametro.-
//        /// </summary>
//        /// <param name="pComponentLayer">Capa</param>
//        /// <returns>Patron Namespace</returns>
//        public static string GetNamespaceTemplate(ComponentLayer pComponentLayer)
//        {

//            string str = Enum.GetName(typeof(ComponentLayer), pComponentLayer);

//            Template wTemplate = _Templates.GetTemplate(TemplateProviderEnum.NamespaceTemplate);

//            return wTemplate.Keys.GetKey(str).TextContent;
            
//        }

//        /// <summary>
//        /// Obtiene un template TSQL para armar un SP a partir de la accion determinada
//        /// </summary>
//        /// <param name="pActionType">Tipo de accion (Insert, Update, etc .-) <see cref="MethodActionType"/></param>
//        /// <returns>Key + Atributos</returns>
//        public static Key GetStoredProcedureTemplate(MethodActionType pActionType)
//        {
//            string str = Enum.GetName(typeof(MethodActionType), pActionType);
//            Template wTemplate = _Templates.GetTemplate(TemplateProviderEnum.StoredProcedureTemplate);
//            return wTemplate.Keys.GetKey(str);
//        }

//        /// <summary>
//        /// Iniciualiza algunos templates de las Entities para de acuerdo a los patrones TemplatePatterns.
//        /// Ademas genera algunos templates nuevos
//        /// </summary>
//        private static void LoadBETemplate()
//        {
//            Template wTemplateBE = _Templates.GetTemplate(TemplateProviderEnum.EntityTemplate);
//            Template wPatternsTemplate = _Templates.GetTemplate(TemplateProviderEnum.Patterns);
//            Key wKeyAux = null;
//            String wTextContentAux = string.Empty;

//            String wPrivateMemberPrefixPattern = wPatternsTemplate.Keys.GetKey("PrivateMemberPrefixPattern").TextContent;
//            String wCollectionNamePattern = wPatternsTemplate.Keys.GetKey("CollectionNamePattern").TextContent;
//            String wNamePattern = wPatternsTemplate.Keys.GetKey("NamePattern").TextContent;
//            String wBussinessDataCollectionNamePattern = wPatternsTemplate.Keys.GetKey("BussinessDataCollectionNamePattern").TextContent;
//            String wBussinessDataNamePattern = wPatternsTemplate.Keys.GetKey("BussinessDataNamePattern").TextContent;

//            #region Establesco el patron de nombre de Template.-->TemplateClassOnly
//            wKeyAux = wTemplateBE.Keys.GetKey("TemplateClassOnly");

//            wTextContentAux = wKeyAux.TextContent;

//            wTextContentAux = wTextContentAux.Replace("[NamePattern]", wNamePattern);
//            wTextContentAux = wTextContentAux.Replace("[CollectionNamePattern]", wCollectionNamePattern);

//            wKeyAux.TextContent = wTextContentAux;

//            #endregion

//            wKeyAux = wKeyAux.Clone("TemplateClassOnlyToService");
//            wTemplateBE.Keys.Add(wKeyAux);
//            #region Establesco el patron de nombre de Template.-->TemplateClassOnlyToService

//            wTextContentAux = wKeyAux.TextContent;

//            wTextContentAux = wTextContentAux.Replace("[NamePattern]", wBussinessDataNamePattern);
//            wTextContentAux = wTextContentAux.Replace("[CollectionNamePattern]", wBussinessDataCollectionNamePattern);

//            wKeyAux.TextContent = wTextContentAux;

//            #endregion

//            #region Establesco el patron de nombre de Template.-
//            wKeyAux = wTemplateBE.Keys.GetKey("Template");
//            wTextContentAux = wKeyAux.TextContent;
//            wTextContentAux = wTextContentAux.Replace("[NamePattern]", wNamePattern);
//            wTextContentAux = wTextContentAux.Replace("[CollectionNamePattern]", wCollectionNamePattern);
//            wKeyAux.TextContent = wTextContentAux;


//            #endregion


//            wKeyAux = wTemplateBE.Keys.GetKey("SchemaCollectionTemplate");

//            #region Establesco el patron de nombre de SchemaCollectionTemplate.-
//            wTextContentAux = wKeyAux.TextContent;
//            wTextContentAux = wTextContentAux.Replace("[NamePattern]", wNamePattern);
//            wTextContentAux = wTextContentAux.Replace("[CollectionNamePattern]", wCollectionNamePattern);
//            wKeyAux.TextContent = wTextContentAux;
//            #endregion


//            wKeyAux = wKeyAux.Clone("SchemaCollectionTemplateService");

//            wTemplateBE.Keys.Add(wKeyAux);

//            #region Establesco el patron de nombre de SchemaCollectionTemplate.-
//            wTextContentAux = wKeyAux.TextContent;
//            wTextContentAux = wTextContentAux.Replace("[NamePattern]", wBussinessDataNamePattern);
//            wTextContentAux = wTextContentAux.Replace("[CollectionNamePattern]", wBussinessDataCollectionNamePattern);
//            wKeyAux.TextContent = wTextContentAux;
//            #endregion

//            #region Establesco el patron .-[PrivateMemberPrefixPattern][Property_Name]
//            wKeyAux = wTemplateBE.Keys.GetKey("PropertyTemplate");
//            wTextContentAux = wKeyAux.TextContent;
//            wTextContentAux = wTextContentAux.Replace("[PrivateMemberPrefixPattern]", wPrivateMemberPrefixPattern);
//            wKeyAux.TextContent = wTextContentAux;


//            #endregion
//            #region Establesco el patron .-[PrivateMemberPrefixPattern][Property_Name]
//            wKeyAux = wTemplateBE.Keys.GetKey("PropertyTemplateBinary");
//            wTextContentAux = wKeyAux.TextContent;
//            wTextContentAux = wTextContentAux.Replace("[PrivateMemberPrefixPattern]", wPrivateMemberPrefixPattern);
//            wKeyAux.TextContent = wTextContentAux;
//            #endregion
//            wTextContentAux = null;
//        }



//        /// <summary>
//        /// Carga todos los templates. Lee el archivo Templates.xml
//        /// </summary>
//        private static void LoadTemplates()
//        {
//            //@"/TemplateDocument/CodeGenerator/Templates/Template[@key='[KeyName]']";
//            XmlNode wTemplatesInDoc = _XmlTemplates.SelectSingleNode(@"/TemplateDocument");
//            _Templates = new Templates();
//            Template wTemplate = null;
//            foreach (XmlNode xmlTemplate in wTemplatesInDoc)
//            {
//                wTemplate = new Template();
//                wTemplate.Name = NodeAttribute.AttributeGet(xmlTemplate, "name");

//                if (wTemplate.Name == "StoredProcedureTemplate")
//                    LoadKeysSP(wTemplate, xmlTemplate);
//                else
//                    LoadKeys(wTemplate, xmlTemplate);

//                _Templates.Add(wTemplate);
//            }
//            LoadBETemplate();
//        }

//        private static void LoadKeys(Template pTemplate, XmlNode pXmlTemplate)
//        {

//            Key wKey = null;

//            foreach (XmlNode wXmlKey in pXmlTemplate.ChildNodes)
//            {
//                wKey = new Key();
//                wKey.Name = NodeAttribute.AttributeGet(wXmlKey, "name");

//                wKey.TextContent = wXmlKey.InnerText;

//                pTemplate.Keys.Add(wKey);
//            }
//        }

//        private static void LoadKeysSP(Template pTemplate, XmlNode pXmlTemplate)
//        {

//            Key wKey = null;

//            foreach (XmlNode wXmlKey in pXmlTemplate.ChildNodes)
//            {
//                wKey = new Key();
//                wKey.Name = NodeAttribute.AttributeGet(wXmlKey, "name");


//                wKey.TextContent = String.Empty;
//                wKey.TemplateAtribute = new StoreProcedureTemplate();
//                if (wXmlKey.SelectSingleNode(@"Name") != null)
//                {
//                    wKey.TemplateAtribute.Name = wXmlKey.SelectSingleNode(@"Name").InnerText;
//                }
//                if (wXmlKey.SelectSingleNode(@"Body") != null)
//                {
//                    wKey.TemplateAtribute.Body = wXmlKey.SelectSingleNode(@"Body").InnerText;

//                }
//                if (wXmlKey.SelectSingleNode(@"Description") != null)
//                {
//                    wKey.TemplateAtribute.Description = wXmlKey.SelectSingleNode(@"Description").InnerText;

//                }
//                pTemplate.Keys.Add(wKey);
//            }
//        }

//    }
//}
