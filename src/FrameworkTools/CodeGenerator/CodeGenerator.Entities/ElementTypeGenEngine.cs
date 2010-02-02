using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;
using System.Windows.Forms;
//using CodeGenerator.Back.Schema;
//using CodeGenerator.Back.Common;
using CodeGenerator.Back;
using Fwk.CodeGenerator.Common;

namespace CodeGenerator.Back.Entities
{
    public class ElementTypeGenEngine
    {
        private static string _Entity_Property_Template;
        public static string _Entity_Property_TemplateBinary;
        private static Template _BETemplate = null;
        private static Template _PatternTemplate = null; 
        private static string _ObjectPrefix;
        private static TemplateSettingObject _TemplateSettingObject = null;

        public static TemplateSettingObject TemplateSettingObject
        {
            get { return ElementTypeGenEngine._TemplateSettingObject; }
            set { ElementTypeGenEngine._TemplateSettingObject = value; }
        }
        private static string _BussinessDataNamePattern;
        private static string _BussinessDataCollectionNamePattern;
        private static string _NamePattern;
        private static string _CollectionNamePattern;

        static ElementTypeGenEngine()
        {
            _BETemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.EntityTemplate);
            _PatternTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.Patterns);

            _Entity_Property_Template = _BETemplate.Keys.GetKey ("PropertyTemplate").TextContent;
            _Entity_Property_TemplateBinary = _BETemplate.Keys.GetKey("PropertyTemplateBinary").TextContent;

            _ObjectPrefix = _PatternTemplate.Keys.GetKey("PrivateMemberPrefixPattern").TextContent.Replace(CommonConstants.CONST_ENTITY_PREFIX_TYPE,
                  _PatternTemplate.Keys.GetKey("ObjectPrefix").TextContent);

            _BussinessDataNamePattern = _PatternTemplate.Keys.GetKey("BussinessDataNamePattern").TextContent;
            _BussinessDataCollectionNamePattern = _PatternTemplate.Keys.GetKey("BussinessDataCollectionNamePattern").TextContent;

            _NamePattern = _PatternTemplate.Keys.GetKey("NamePattern").TextContent;
            _CollectionNamePattern = _PatternTemplate.Keys.GetKey("CollectionNamePattern").TextContent;
        }

        #region Generacion de los atributos public y privados

        /// <summary>
        /// Rellena los atributos public y privados de una clase teniendo en cuenta para cada uno sus tipos 
        /// </summary>
        /// <param name="pTag">Nodo del esquema</param>
        /// <param name="pPublic">String de salida con los atributos publicos.-</param>
        /// <param name="pPrivate">String de salida con los miembros privados.-</param>
        public static void GenerateGlobalElementType(object pTag, out string pPublic, out string pPrivate)
        {
            string wType = string.Empty;
            pPublic = string.Empty;
            pPrivate = string.Empty;

            if (pTag.GetType().ToString().Contains("System.Int"))
            {
                GenerateElementInt(pTag, out pPublic, out pPrivate);
                wType = "System.Int32";
            }
            

            if (pTag.GetType().ToString().Contains("System.DateTime"))
            {
                GenerateElementDateTime(pTag, out pPublic, out pPrivate);
                wType = "System.DateTime";
            }
            if (pTag.GetType().ToString().Contains("System.String"))
            {
                GenerateElementString(pTag, out pPublic, out pPrivate);
                wType = "System.String";
            }
            if (pTag.GetType().ToString().Contains("System.Boolean"))
            {
                GenerateElementBoolean(pTag, out pPublic, out pPrivate);
                wType = "System.Boolean";
            }

            if (pTag.GetType().ToString().Contains("System.Double"))
            {
                GenerateElementDouble(pTag, out pPublic, out pPrivate);
                wType = "System.Double";
            }
            if (pTag.GetType().ToString().Contains("System.Decimal"))
            {
                GenerateElementDecimal(pTag, out pPublic, out pPrivate);
                wType = "System.Decimal";
            }
            if (pTag.GetType().ToString().Contains("System.Byte[]"))
            {
                GenerateElementByteArray(pTag, out pPublic, out pPrivate);
                wType = "System.Byte[]";
            }
            
            pPublic = pPublic.Replace(CommonConstants.CONST_ENTITY_PREFIX_TYPE, ParametersDAC.GetPrefixTypeBy(wType));


        }

        #region [Simple types]
        private static void GenerateElementString(object pTag, out string pPublic, out string pPrivate)
        {
            GlobalElementType<string> wStringTag = (GlobalElementType<string>)pTag;
            String strCode = _Entity_Property_Template;

            strCode = strCode.Replace(CommonConstants.CONST_TYPENAME, "String");
            strCode = strCode.Replace(CommonConstants.CONST_SCHEMATYPENAME, "string");
            strCode = strCode.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, wStringTag.Definition.Name);

            pPublic = strCode + Environment.NewLine;
            //pPrivate = "private String m" + ParametersDAC.GetPrefixType("varchar") + "_" + wStringTag.Definition.Name + ";" + Environment.NewLine;
            pPrivate = GetPrivateMember(wStringTag.Definition.Name, "varchar");
        
        }

        private static string GetPrivateMember(string pMemberName ,string pDataBaseType)
        {
            //Ej: PrivateMemberPrefixPattern = m[PrefixType]_
            String wPrefixType =
                _PatternTemplate.Keys.GetKey("PrivateMemberPrefixPattern").TextContent.Replace(
                    CommonConstants.CONST_ENTITY_PREFIX_TYPE, ParametersDAC.GetPrefixType(pDataBaseType));

           
            String wPrivate = "private " + ParametersDAC.GetTargetType(pDataBaseType.ToLower()) +  ParametersDAC.GetNullableToken(pDataBaseType.ToLower())+ " " + wPrefixType + pMemberName + ";" + Environment.NewLine;
            return wPrivate;
        }

        private static void GenerateElementInt(object pTag, out string pPublic, out string pPrivate)
        {
            GlobalElementType<int?> wIntTag = (GlobalElementType<int?>) pTag;

            string strCode = _Entity_Property_Template;

            strCode = strCode.Replace(CommonConstants.CONST_TYPENAME, "int?");
            strCode = strCode.Replace(CommonConstants.CONST_SCHEMATYPENAME, "int");
            strCode = strCode.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, wIntTag.Definition.Name);

            pPublic = strCode + Environment.NewLine;
            //pPrivate = "private int? m" + ParametersDAC.GetPrefixType("int") + "_" + wIntTag.Definition.Name + ";" +
            //           Environment.NewLine;
            pPrivate = GetPrivateMember(wIntTag.Definition.Name, "int");

        }

        private static void GenerateElementDouble(object pTag, out string pPublic, out string pPrivate)
        {

            GlobalElementType<double?> wDoubleTag = (GlobalElementType<double?>)pTag;

            string strCode = _Entity_Property_Template;

            strCode = strCode.Replace(CommonConstants.CONST_TYPENAME, "double?");
            strCode = strCode.Replace(CommonConstants.CONST_SCHEMATYPENAME, "double");
            strCode = strCode.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, wDoubleTag.Definition.Name);

            pPublic = strCode + Environment.NewLine;
            //pPrivate = "private Double? m" + ParametersDAC.GetPrefixType("decimal") + "_" + wDoubleTag.Definition.Name + ";" + Environment.NewLine;
            pPrivate = GetPrivateMember(wDoubleTag.Definition.Name, "double");

        }

        private static void GenerateElementDecimal(object pTag, out string pPublic, out string pPrivate)
        {

            GlobalElementType<decimal?> wDoubleTag = (GlobalElementType<decimal?>)pTag;

            string strCode = _Entity_Property_Template;

            strCode = strCode.Replace(CommonConstants.CONST_TYPENAME, "decimal?");
            strCode = strCode.Replace(CommonConstants.CONST_SCHEMATYPENAME, "decimal");
            strCode = strCode.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, wDoubleTag.Definition.Name);

            pPublic = strCode + Environment.NewLine;
            //pPrivate = "private Double? m" + ParametersDAC.GetPrefixType("decimal") + "_" + wDoubleTag.Definition.Name + ";" + Environment.NewLine;

            pPrivate = GetPrivateMember(wDoubleTag.Definition.Name, "decimal");
        }

        private static void GenerateElementDateTime(object pTag, out string pPublic, out string pPrivate)
        {
            GlobalElementType<DateTime?> wDateTimeTag = (GlobalElementType<DateTime?>)pTag;
            string strCode = _Entity_Property_Template;

            strCode = strCode.Replace(CommonConstants.CONST_TYPENAME, "DateTime?");
            strCode = strCode.Replace(CommonConstants.CONST_SCHEMATYPENAME, "dateTime");
            strCode = strCode.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, wDateTimeTag.Definition.Name);

            pPublic = strCode + Environment.NewLine;
            //pPrivate = "private DateTime? m" + ParametersDAC.GetPrefixType("datetime") + "_" + wDateTimeTag.Definition.Name + ";" + Environment.NewLine;
            pPrivate = GetPrivateMember(wDateTimeTag.Definition.Name, "datetime");
        }

        private static void GenerateElementBoolean(object pTag, out string pPublic, out string pPrivate)
        {
            GlobalElementType<System.Boolean?> wBoolTag = (GlobalElementType<System.Boolean?>)pTag;
            string strCode = _Entity_Property_Template;

            strCode = strCode.Replace(CommonConstants.CONST_TYPENAME, "Boolean?");
            strCode = strCode.Replace(CommonConstants.CONST_SCHEMATYPENAME, "boolean");
            strCode = strCode.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, wBoolTag.Definition.Name);

            pPublic = strCode + Environment.NewLine;
            //pPrivate = "private Boolean? m" + ParametersDAC.GetPrefixType("bit") + "_" + wBoolTag.Definition.Name + ";" + Environment.NewLine;
            pPrivate = GetPrivateMember(wBoolTag.Definition.Name, "bit");
        }

        private static void GenerateElementByteArray(object pTag, out string pPublic, out string pPrivate)
        {

            GlobalElementType<System.Byte[]> wDoubleTag = (GlobalElementType<System.Byte[]>)pTag;

            string strCode = _Entity_Property_TemplateBinary;

            strCode = strCode.Replace(CommonConstants.CONST_TYPENAME, "System.Byte[]");
            strCode = strCode.Replace(CommonConstants.CONST_SCHEMATYPENAME, "base64Binary");
            strCode = strCode.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, wDoubleTag.Definition.Name);

            pPublic = strCode + Environment.NewLine;
            pPrivate = GetPrivateMember(wDoubleTag.Definition.Name, "binary");
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTag"></param>
        /// <param name="pPublic"></param>
        /// <param name="pPrivate"></param>
        /// <param name="pIsToBussinessEntities">Indicador de si se trata codigo ghenerado para entidad de negocio o un servicio</param>
        internal static void GenerateGlobalElementComplexType(object pTag, out string pPublic, out string pPrivate,Boolean pIsToBussinessEntities)
        {
            string wNamePattern = String.Empty;
            string wCollectionClass = String.Empty;

            GlobalElementComplexType wComplexelement = (GlobalElementComplexType)pTag;

            StringBuilder strPublicCode = new StringBuilder();
            strPublicCode.Append(_BETemplate.Keys.GetKey ("ComplexTypePropertyTemplate").TextContent);

            if (wComplexelement.MaxOccurs > 1)
            {

                if (pIsToBussinessEntities)
                {

                    //Ej: wCollectionNamePattern = [EntityName]List
                    wNamePattern =
                        _CollectionNamePattern.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,
                                                          _TemplateSettingObject.Entities.CollectionsSufix);
                }
                else
                {

                    wNamePattern =
                        _BussinessDataCollectionNamePattern.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION,
                                                                    _TemplateSettingObject.Entities.
                                                                        BusinessDataCollectionSufix);
                }

                strPublicCode.Replace(CommonConstants.CONST_TYPENAME, wNamePattern);
                strPublicCode.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, wNamePattern);

                //Incorporo el patron de nombres para colecciones.-
                strPublicCode.Replace(CommonConstants.CONST_ENTITY_NAME, wComplexelement.Name);

                wCollectionClass = wNamePattern.Replace(CommonConstants.CONST_ENTITY_NAME, wComplexelement.Name);


                pPrivate = "private " + wCollectionClass + " " + _ObjectPrefix + wCollectionClass + " = new " + wCollectionClass + "();";


            }
            else
            {
                if (pIsToBussinessEntities)
                    wNamePattern = _NamePattern.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,
                                                        _TemplateSettingObject.Entities.EntitySufix);
                else
                    wNamePattern =
                        _BussinessDataNamePattern.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,
                                                          _TemplateSettingObject.Entities.CollectionsSufix);

                strPublicCode.Replace(CommonConstants.CONST_TYPENAME, wNamePattern);

                strPublicCode.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, wNamePattern);
                strPublicCode.Replace(CommonConstants.CONST_ENTITY_NAME, wComplexelement.Name);


                pPrivate = "private " + wNamePattern + " " + _ObjectPrefix + wNamePattern + " = new " + wNamePattern +"();";
                pPrivate = pPrivate.Replace(CommonConstants.CONST_ENTITY_NAME, wComplexelement.Name);
            }

            pPublic = strPublicCode.ToString();

        }

        #endregion
    }
}
