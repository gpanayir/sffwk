using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.IO;
using CodeGenerator.Back.Common;
using Fwk.DataBase.DataEntities;

namespace CodeGenerator.Back.Services 
{
    /// <summary>
    /// Genera un XSD Schema a partir de un objeto de base de datos.-
    /// </summary>
    public static  class XSDGenerator
    {
        #region private variables
        static string schemRequest;
        static string schemResponse ;
        private static string _InsertServiceName;
        private static string _UpdateServiceName;
        private static string _DeletteServiceName;
        private static string _GetByParamServiceName;
        private static string _GetAllServiceName;
        private static string _BussinessDataCollectionNamePattern;
        private static string _BussinessDataNamePattern;
        private static TemplateSettingObject _TemplateSettingObject;
        private static string _NotSupportTypes_ToInsertStoreProcedure = String.Empty;
        private static string _NotSupportTypes_ToSearchInStoreProcedure = String.Empty;
        public static TemplateSettingObject TemplateSettingObject
        {
          
            set { XSDGenerator._TemplateSettingObject = value; }
        }
        #endregion

         static XSDGenerator()
        {
            schemRequest =
                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.XSDTemplate).Keys.GetKey("schema").
                    TextContent;
            schemResponse = schemRequest;

            _InsertServiceName =
                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.ServiceTemplate).Keys.GetKey("Insert").
                    TextContent;

            _UpdateServiceName =
                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.ServiceTemplate).Keys.GetKey("Update").
                    TextContent;
            
            _DeletteServiceName =
                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.ServiceTemplate).Keys.GetKey("Delette").
                    TextContent;
            
            _GetByParamServiceName =
                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.ServiceTemplate).Keys.GetKey("GetByParam").
                    TextContent;
            
            _GetAllServiceName =
                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.ServiceTemplate).Keys.GetKey("GetAll").
                    TextContent;
            _BussinessDataCollectionNamePattern =
                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.Patterns).Keys.GetKey("BussinessDataCollectionNamePattern").
                    TextContent;
           
            _BussinessDataNamePattern =
                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.Patterns).Keys.GetKey("BussinessDataNamePattern").
                    TextContent;

            _NotSupportTypes_ToInsertStoreProcedure =
          TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.NotSupportTypes).Keys.GetKey(
              "ToInsertStoreProcedure").TextContent;
            _NotSupportTypes_ToSearchInStoreProcedure =
               TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.NotSupportTypes).Keys.GetKey(
                   "ToSearchInStoreProcedure").TextContent;
        }

        #region FromTable

        /// <summary>
        /// Retorna un diccionario con el xml del esquema pertenecioente al Req & Res del Crear-Insertar
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns></returns>
        public static StringDictionary GenCreate(Table pTable, out String pServiceName)
        {
            StringDictionary sdCode = new StringDictionary();
            pServiceName = _InsertServiceName.Replace(CommonConstants.CONST_ENTITY_NAME, pTable.Name);

            #region Request

            sdCode.Add("Request", schemRequest); //Request en indice [0]
            ///Inserto en el envelope del esquema los atributos
           
            sdCode["Request"] = sdCode["Request"].Replace("[sequence]", GenAllSequenceElements(pTable,MethodActionType.Insert,false));
            
            #endregion

            #region Response
            sdCode.Add("Response", schemResponse); //Response en indice [1]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Response"] = sdCode["Response"].Replace("[sequence]", GenIdentitySequenceElements(pTable));
            #endregion

            SetRequestResponse(sdCode, pServiceName, pTable.Name);
            return sdCode;
        }

        /// <summary>
        /// Retorna un diccionario con el xml del esquema pertenecioente al Req & Res del Crear-Insertar
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns></returns>
        public static StringDictionary GenUpdate(Table pTable, out String pServiceName)
        {
            StringDictionary sdCode = new StringDictionary();
            pServiceName = _UpdateServiceName.Replace(CommonConstants.CONST_ENTITY_NAME, pTable.Name);

            #region Request
            sdCode.Add("Request", schemRequest ); //Request en indice [0]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Request"] = sdCode["Request"].Replace("[sequence]", GenAllSequenceElements(pTable,MethodActionType.Update,false));
            #endregion

            #region Response
            sdCode.Add("Response", schemResponse ); //Response en indice [1]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Response"] = sdCode["Response"].Replace("[sequence]", GenDummySequenceElements());
            #endregion


            SetRequestResponse(sdCode, pServiceName, pTable.Name);
            return sdCode;
        }

        /// <summary>
        /// Retorna un diccionario con el xml del esquema pertenecioente al Req & Res del Crear-Insertar
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns></returns>
        public static StringDictionary GenDelete(Table pTable, out String pServiceName)
        {
            StringDictionary sdCode = new StringDictionary();
            pServiceName = _DeletteServiceName.Replace(CommonConstants.CONST_ENTITY_NAME, pTable.Name);

            #region Request
            sdCode.Add("Request", schemRequest); //Request en indice [0]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Request"] =  sdCode["Request"].Replace("[sequence]", GenIdentitySequenceElements(pTable));
            #endregion

            #region Response
            sdCode.Add("Response", schemResponse); //Response en indice [1]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Response"] = sdCode["Response"].Replace("[sequence]", GenDummySequenceElements());
            #endregion

            SetRequestResponse(sdCode, pServiceName, pTable.Name);
            return sdCode;
        }

        /// <summary>
        /// Retorna un diccionario con el xml del esquema pertenecioente al Req & Res del GenGetByParam
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns></returns>
        public static StringDictionary GenGetByParam(Table pTable, out String pServiceName)
        {
            StringDictionary sdCode = new StringDictionary();
            String wSecuence = String.Empty;
            pServiceName = _GetByParamServiceName.Replace(CommonConstants.CONST_ENTITY_NAME, pTable.Name);

            #region Request
            wSecuence = GenAllSequenceElements(pTable, MethodActionType.GetByParam, false);
            if (wSecuence.Length == 0)
            {
                sdCode.Clear();
                return sdCode;
            }

            sdCode.Add("Request", schemRequest); //Request en indice [0]

            ///Inserto en el envelope del esquema los atributos
            sdCode["Request"] = sdCode["Request"].Replace("[sequence]",wSecuence );

            #endregion

            #region Response
            wSecuence = GenAllSequenceElements(pTable, MethodActionType.GetByParam, true);
            if (wSecuence.Length == 0)
            {
                sdCode.Clear();
                return sdCode;
            }
            sdCode.Add("Response", schemResponse); //Response en indice [1]
            
            ///Inserto en el envelope del esquema los atributos
            sdCode["Response"] = sdCode["Response"].Replace("[sequence]", wSecuence);
            #endregion

            SetRequestResponse(sdCode, pServiceName, pTable.Name);
            return sdCode;
        }

        /// <summary>
        /// Retorna un diccionario con el xml del esquema pertenecioente al Req & Res del GenGetByParam
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns></returns>
        public static StringDictionary GenGetAll(Table pTable, out String pServiceName)
        {
            String wSecuence = String.Empty;
            StringDictionary sdCode = new StringDictionary();
            pServiceName = _GetAllServiceName.Replace(CommonConstants.CONST_ENTITY_NAME, pTable.Name);

            
            #region Request
            sdCode.Add("Request", schemRequest); //Request en indice [0]
            
            ///Inserto en el envelope del esquema los atributos
            sdCode["Request"] = sdCode["Request"].Replace("[sequence]", GenDummySequenceElements());
            #endregion

            #region Response
            wSecuence = GenAllSequenceElements(pTable, MethodActionType.GetAll, true);
            if (wSecuence.Length == 0)
            {
                sdCode.Clear();
                return sdCode;
            }

            sdCode.Add("Response", schemResponse); //Response en indice [1]
           
            ///Inserto en el envelope del esquema los atributos
            sdCode["Response"] = sdCode["Response"].Replace("[sequence]", wSecuence);
            #endregion

            SetRequestResponse(sdCode, pServiceName, pTable.Name);
            return sdCode;
        }

        /// <summary>
        /// Obtiene una xs:sequence de un complexType con todos los campos seleccionados de una tabla
        /// </summary>
        /// <param name="pTable"></param>
        private static string GenAllSequenceElements(Table pTable,MethodActionType pMethodActionType,Boolean pResponse)
        {



            StringBuilder wComplexTypeElementColumns = new StringBuilder();
            string pAttributeTypeName = string.Empty;
            foreach (Column wColumn in pTable.Columns)
            {
                if (wColumn.Selected && IsParameterInfoValid(wColumn.Type, pMethodActionType, pResponse))
                {
                    //Arma ej: dateTimeAttribute
                    pAttributeTypeName = ParametersDAC.GetTargetSchemaTypeByName(wColumn.Type) + "Attribute";

                    // Agrega por ej: <xs:element name="Attribute" type="xs:dateTime" minOccurs="0"
                    wComplexTypeElementColumns.AppendLine(
                        TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.XSDTemplate).Keys.GetKey(
                            pAttributeTypeName).
                            TextContent.Replace("Attribute",wColumn.Name.Replace(" ",String.Empty)));

                }
            }

            return wComplexTypeElementColumns.ToString();
        }

        /// <summary>
        /// Obtiene una xs:sequence de un complexType con todos los campos seleccionados de una tabla
        /// </summary>
        /// <param name="pTable"></param>
        private static string GenIdentitySequenceElements(Table pTable)
        {
            bool wAnySelect = false;

            StringBuilder wComplexTypeElementColumns = new StringBuilder();
            string pAttributeTypeName = string.Empty;
            foreach (Column wColumn in pTable.Columns)
            {
                if (wColumn.IsIdentity)
                {
                    wAnySelect = true;
                    //Arma ej: dateTimeAttribute
                    pAttributeTypeName = ParametersDAC.GetTargetSchemaTypeByName(wColumn.Type) + "Attribute";

                    // Agrega por ej: <xs:element name="Attribute" type="xs:dateTime" minOccurs="0"
                    wComplexTypeElementColumns.AppendLine(
                        TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.XSDTemplate).Keys.GetKey(
                            pAttributeTypeName).
                            TextContent.Replace("Attribute", wColumn.Name.Replace(" ",String.Empty)));
                    
                }
            }

            if(wAnySelect == false)
            {
                // Agrega por ej: <xs:element name="Attribute" type="xs:dateTime" minOccurs="0"
                wComplexTypeElementColumns.AppendLine(
                    TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.XSDTemplate).Keys.GetKey(
                        "stringAttribute").
                        TextContent.Replace("Attribute", "Dummy"));
            }

            return wComplexTypeElementColumns.ToString();
        }
        #endregion

        #region FromSP

        /// <summary>
        /// Retorna un diccionario con el xml del esquema pertenecioente al Req & Res del Crear-Insertar
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns></returns>
        public static StringDictionary GenCreate(StoreProcedure pStoreProcedure , out String pServiceName)
        {
            StringDictionary sdCode = new StringDictionary();
            pServiceName = _InsertServiceName.Replace(CommonConstants.CONST_ENTITY_NAME, pStoreProcedure.Name);

            #region Request

            sdCode.Add("Request", schemRequest); //Request en indice [0]
            ///Inserto en el envelope del esquema los atributos

            sdCode["Request"] = sdCode["Request"].Replace("[sequence]", GenAllSequenceElements(pStoreProcedure, MethodActionType.Insert,false));

            #endregion

            #region Response
            sdCode.Add("Response", schemResponse); //Response en indice [1]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Response"] = sdCode["Response"].Replace("[sequence]", GenIdentitySequenceElements(pStoreProcedure));
            #endregion

            SetRequestResponse(sdCode, pServiceName, pStoreProcedure.Name);
            return sdCode;
        }

        /// <summary>
        /// Retorna un diccionario con el xml del esquema pertenecioente al Req & Res del Crear-Insertar
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns></returns>
        public static StringDictionary GenUpdate(StoreProcedure pStoreProcedure, out String pServiceName)
        {
            StringDictionary sdCode = new StringDictionary();
            pServiceName = _UpdateServiceName.Replace(CommonConstants.CONST_ENTITY_NAME, pStoreProcedure.Name);

            #region Request
            sdCode.Add("Request", schemRequest); //Request en indice [0]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Request"] = sdCode["Request"].Replace("[sequence]", GenAllSequenceElements(pStoreProcedure,MethodActionType.Update,false));
            #endregion

            #region Response
            sdCode.Add("Response", schemResponse); //Response en indice [1]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Response"] = sdCode["Response"].Replace("[sequence]", GenDummySequenceElements());
            #endregion


            SetRequestResponse(sdCode, pServiceName, pStoreProcedure.Name);
            return sdCode;
        }

        /// <summary>
        /// Retorna un diccionario con el xml del esquema pertenecioente al Req & Res del Crear-Insertar
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns></returns>
        public static StringDictionary GenDelete(StoreProcedure pStoreProcedure, out String pServiceName)
        {
            StringDictionary sdCode = new StringDictionary();
            pServiceName = _DeletteServiceName.Replace(CommonConstants.CONST_ENTITY_NAME, pStoreProcedure.Name);

            #region Request
            sdCode.Add("Request", schemRequest); //Request en indice [0]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Request"] = sdCode["Request"].Replace("[sequence]", GenIdentitySequenceElements(pStoreProcedure));
            #endregion

            #region Response
            sdCode.Add("Response", schemResponse); //Response en indice [1]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Response"] = sdCode["Response"].Replace("[sequence]", GenDummySequenceElements());
            #endregion

            SetRequestResponse(sdCode, pServiceName, pStoreProcedure.Name);
            return sdCode;
        }

        /// <summary>
        /// Retorna un diccionario con el xml del esquema pertenecioente al Req & Res del GenGetByParam
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns></returns>
        public static StringDictionary GenGetByParam(StoreProcedure pStoreProcedure, out String pServiceName)
        {
            StringDictionary sdCode = new StringDictionary();
            pServiceName = _GetByParamServiceName.Replace(CommonConstants.CONST_ENTITY_NAME, pStoreProcedure.Name);

            #region Request

            sdCode.Add("Request", schemRequest); //Request en indice [0]
            ///Inserto en el envelope del esquema los atributos

            sdCode["Request"] = sdCode["Request"].Replace("[sequence]", GenAllSequenceElements(pStoreProcedure, MethodActionType.GetByParam,false));

            #endregion

            #region Response

            sdCode.Add("Response", schemResponse); //Response en indice [1]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Response"] = sdCode["Response"] = sdCode["Response"].Replace("[sequence]", GenAllSequenceElements(pStoreProcedure, MethodActionType.GetByParam,true));
            #endregion

            SetRequestResponse(sdCode, pServiceName, pStoreProcedure.Name);
            return sdCode;
        }

        /// <summary>
        /// Retorna un diccionario con el xml del esquema pertenecioente al Req & Res del GenGetByParam
        /// </summary>
        /// <param name="pTable"></param>
        /// <returns></returns>
        public static StringDictionary GenGetAll(StoreProcedure pStoreProcedure, out String pServiceName)
        {
            StringDictionary sdCode = new StringDictionary();
            pServiceName = _GetAllServiceName.Replace(CommonConstants.CONST_ENTITY_NAME, pStoreProcedure.Name);


            #region Request
            sdCode.Add("Request", schemRequest); //Request en indice [0]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Request"] = sdCode["Request"].Replace("[sequence]", GenDummySequenceElements());
            #endregion

            #region Response
            sdCode.Add("Response", schemResponse); //Response en indice [1]
            ///Inserto en el envelope del esquema los atributos
            sdCode["Response"] = sdCode["Response"].Replace("[sequence]", GenAllSequenceElements(pStoreProcedure,MethodActionType.GetAll,true));
            #endregion

            SetRequestResponse(sdCode, pServiceName, pStoreProcedure.Name);
            return sdCode;
        }

        /// <summary>
        /// Obtiene una xs:sequence de un complexType con todos los campos seleccionados de una tabla
        /// </summary>
        /// <param name="pTable"></param>
        private static string GenAllSequenceElements(StoreProcedure pStoreProcedure, MethodActionType pMethodActionType, Boolean pResponse)
        {



            StringBuilder wComplexTypeElementColumns = new StringBuilder();
            string pAttributeTypeName = string.Empty;
            foreach (SPParameter wSPParameter in pStoreProcedure.Parameters)
            {
                if (wSPParameter.Selected && IsParameterInfoValid(wSPParameter.Type.ToLower(), pMethodActionType, pResponse))
                {
                    //Arma ej: dateTimeAttribute
                    pAttributeTypeName = ParametersDAC.GetTargetSchemaTypeByName(wSPParameter.Type) + "Attribute";

                    // Agrega por ej: <xs:element name="Attribute" type="xs:dateTime" minOccurs="0"
                    wComplexTypeElementColumns.AppendLine(
                        TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.XSDTemplate).Keys.GetKey(
                            pAttributeTypeName).
                            TextContent.Replace("Attribute", wSPParameter.Name.Replace(" ", String.Empty)));

                }
            }

            return wComplexTypeElementColumns.ToString();
        }

        /// <summary>
        /// Obtiene una xs:sequence de un complexType con todos los campos seleccionados de una tabla
        /// </summary>
        /// <param name="pTable"></param>
        private static string GenIdentitySequenceElements(StoreProcedure pStoreProcedure)
        {

            Boolean wOutputParameterExist = false;

            StringBuilder wComplexTypeElementColumns = new StringBuilder();
            string pAttributeTypeName = string.Empty;
            foreach (SPParameter wSPParameter in pStoreProcedure.Parameters)
            {
                if (wSPParameter.Direction == ParameterDirection.Output)
                {
                    wOutputParameterExist = true;
                    //Arma ej: dateTimeAttribute
                    pAttributeTypeName = ParametersDAC.GetTargetSchemaTypeByName(wSPParameter.Type) + "Attribute";

                    // Agrega por ej: <xs:element name="Attribute" type="xs:dateTime" minOccurs="0"
                    wComplexTypeElementColumns.AppendLine(
                        TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.XSDTemplate).Keys.GetKey(
                            pAttributeTypeName).
                            TextContent.Replace("Attribute", wSPParameter.Name.Replace(" ", String.Empty)));

                }
            }
            //Para el caso de que el SP no tenga un parametro de salida definido
            //se retorna determina un dummy que debera ser reprogramado por el desarrollador
            if (!wOutputParameterExist)
            {
                pAttributeTypeName = ParametersDAC.GetTargetSchemaTypeByName("int") + "Attribute";
                // Agrega por ej: <xs:element name="Attribute" type="xs:dateTime" minOccurs="0"
                wComplexTypeElementColumns.AppendLine(
                    TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.XSDTemplate).Keys.GetKey(
                        pAttributeTypeName).
                        TextContent.Replace("Attribute", "Id" + pStoreProcedure.Name.Replace(" ", String.Empty)));
            }

            return wComplexTypeElementColumns.ToString();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sdCode"></param>
        /// <param name="pServiceName"></param>
        /// <param name="pTableName"></param>
        private static void SetRequestResponse(StringDictionary sdCode, string pServiceName, string pTableName)
        {
            #region Request
            sdCode["Request"] = sdCode["Request"].Replace("[ServiceName]", pServiceName + "REQ");
            sdCode["Request"] =
                sdCode["Request"].Replace("[BussinessDataCollectionNamePattern]", _BussinessDataCollectionNamePattern);
            sdCode["Request"] = sdCode["Request"].Replace("[BussinessDataNamePattern]", _BussinessDataNamePattern);
            //[EntityName] por Table.Name
            sdCode["Request"] = sdCode["Request"].Replace(CommonConstants.CONST_ENTITY_NAME, pTableName);
            sdCode["Request"] = sdCode["Request"].Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,
                                                          _TemplateSettingObject.Entities.EntitySufix);
            sdCode["Request"] = sdCode["Request"].Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION,
                                                          _TemplateSettingObject.Entities.CollectionsSufix);
            #endregion

            #region Response
            sdCode["Response"] = sdCode["Response"].Replace("[ServiceName]", pServiceName + "RES");
            sdCode["Response"] =
                sdCode["Response"].Replace("[BussinessDataCollectionNamePattern]", _BussinessDataCollectionNamePattern);
            sdCode["Response"] = sdCode["Response"].Replace("[BussinessDataNamePattern]", _BussinessDataNamePattern);
            //[EntityName] por Table.Name
            sdCode["Response"] = sdCode["Response"].Replace(CommonConstants.CONST_ENTITY_NAME, pTableName);
            sdCode["Response"] =
                sdCode["Response"].Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,
                                          _TemplateSettingObject.Entities.EntitySufix);
            sdCode["Response"] =
                sdCode["Response"].Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION,
                                          _TemplateSettingObject.Entities.CollectionsSufix);
            #endregion
        }

       


        /// <summary>
        /// Obtiene una xs:sequence de un complexType con solo un Dummy
        /// </summary>
        private static string GenDummySequenceElements()
        {
            StringBuilder wComplexTypeElementColumns = new StringBuilder();
            string pAttributeTypeName = string.Empty;


            //Arma ej: dateTimeAttribute
            pAttributeTypeName = ParametersDAC.GetTargetSchemaTypeByName("nvarchar") + "Attribute";

            // Agrega por ej: <xs:element name="Dummy" type="xs:string" minOccurs="0"
            wComplexTypeElementColumns.AppendLine(
                TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.XSDTemplate).Keys.GetKey(
                    pAttributeTypeName).
                    TextContent.Replace("Attribute", "Dummy"));


            return wComplexTypeElementColumns.ToString();
        }


        /// <summary>
        /// Determina si la columna es de tipo valido para pasar como parametro desde la TDG a un SP busqueda.-
        /// </summary>
        /// <param name="pType">Tipo de parametro</param>
        ///  <param name="pMethodActionType">Tipo de metodo</param>
        /// <returns>bool</returns>
        private static bool IsParameterInfoValid(String pType, MethodActionType pMethodActionType,Boolean pResponse)
        {

            
            if (pResponse)
            {
                if (_NotSupportTypes_ToSearchInStoreProcedure.Contains(pType.ToLower()))
                    return false;
            }

            if (pMethodActionType == MethodActionType.Insert || pMethodActionType == MethodActionType.Update)
            {

                if (_NotSupportTypes_ToInsertStoreProcedure.Contains(pType.ToLower()))
                    return false;
            }
            if (pMethodActionType == MethodActionType.GetByParam)
            {
                if (_NotSupportTypes_ToSearchInStoreProcedure.Contains(pType.ToLower()))
                    return false;

            }
            return true;
        }
   
    }
}
