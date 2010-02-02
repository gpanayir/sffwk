//using System;
//using System.Text;
//using Fwk.DataBase.DataEntities;
//using Fwk.CodeGenerator.Common;

//namespace CodeGenerator.Back.DataAccess
//{
//    public class AplicationBlockTDG : BaseGenTDG
//    {
//        static Template _TDGTemplate = null;
//        static Template _BETemplate = null;
//        static Template _PatternsTemplate = null;
//        private static TemplateSettingObject _TemplateSettingObject;

//        public static TemplateSettingObject TemplateSettingObject
//        {
//            get { return _TemplateSettingObject; }
//            set { _TemplateSettingObject = value; }
//        }

//        static AplicationBlockTDG()
//        { 
//            _TDGTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.TDGTemplate);
//            _BETemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.EntityTemplate);
//            _PatternsTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.Patterns);
//        }


//        #region --[BATCH]--
//        public static string GetBatchFromTable(MethodInfo pMethodInfo)
//        {
//            StringBuilder strBuilder = new StringBuilder();
//            StringBuilder strBuilderParameters = new StringBuilder();
//            strBuilder.Append(_TDGTemplate.Keys.GetKey ("BatchMethod").TextContent);

//            bool wLastField = false;

//            foreach (Column wCampo in pMethodInfo.Entity.Table.Columns)
//            {
//                if (!wCampo.IsIdentity)
//                {
//                    //En caso de q sea ultmo campo de se establece fin de batch  con ";" .-
//                    if (pMethodInfo.Entity.Table.Columns.IndexOf(wCampo) == pMethodInfo.Entity.Table.Columns.Count - 1)
//                    {
//                        wLastField = true;
//                    }
//                    if (wCampo.Selected)
//                    {
//                        strBuilderParameters.Append(ParametersDAC.GetParametersBatchCode(pMethodInfo.Entity.Table.Name, wCampo.Name, wCampo.Type, wLastField));
//                        strBuilderParameters.Append(Environment.NewLine);
//                        strBuilderParameters.Append(Environment.NewLine);
//                    }
//                }
//            }
         
//            //strBuilderParameters.Replace("[NamePattern]", _PatternsTemplate.Keys.GetKey("NamePattern").TextContent);
//            strBuilder.Replace("[ParametersSet]", strBuilderParameters.ToString());
//            strBuilder.Replace("[NamePattern]", _PatternsTemplate.Keys.GetKey("NamePattern").TextContent);
//            strBuilder.Replace("[CollectionNamePattern]", _PatternsTemplate.Keys.GetKey("CollectionNamePattern").TextContent);

//            strBuilder.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, GetStoredProcedureName(pMethodInfo,_TemplateSettingObject));
//            strBuilder.Replace(CommonConstants.CONST_BACK_END_METHOD_NAME, pMethodInfo.Name + "Batch");

//            strBuilder.Replace("[EntityId]", GetPrimaryKeyFromTable (pMethodInfo.Entity));

//            return strBuilder.ToString();
//        }

       

//        /// <summary>
//        /// Genera el codigo de envio por lotes a un metodo. Este metodo fue previamente seteado a 
//        /// PerformBatch = true
//        /// </summary>
//        /// <param name="pMethodInfo"></param>
//        /// <returns></returns>
//        public static string GetBatchFromSP(MethodInfo pMethodInfo)
//        {
//            StringBuilder strBuilder = new StringBuilder();
//            StringBuilder strBuilderParameters = new StringBuilder();
//            strBuilder.Append(_TDGTemplate.Keys.GetKey ("BatchMethod").TextContent);

//            bool wLastField = false;

//            foreach (SPParameter wSPParameter in pMethodInfo.Entity.StoredProcedure.Parameters)
//            {
//                //En caso de q sea ultmo campo de se establece fin de batch  con ";" .-
//                if (pMethodInfo.Entity.StoredProcedure.Parameters.IndexOf(wSPParameter) == pMethodInfo.Entity.StoredProcedure.Parameters.Count - 1)
//                {
//                    wLastField = true;
//                }
//                if (wSPParameter.Selected)
//                {
//                    strBuilderParameters.Append(
//                        ParametersDAC.GetParametersBatchCode(pMethodInfo.Entity.StoredProcedure.Name, wSPParameter.Name,
//                                                             wSPParameter.Type, wLastField));
//                    strBuilderParameters.AppendLine();
//                    strBuilderParameters.Append(Environment.NewLine);
//                }
//            }
            

//            strBuilder.Replace("[ParametersSet]", strBuilderParameters.ToString());

//            //**
//            //strBuilderParameters.Replace("[NamePattern]", _PatternsTemplate.Keys.GetKey("NamePattern").TextContent);
//            strBuilder.Replace("[NamePattern]", _PatternsTemplate.Keys.GetKey("NamePattern").TextContent);
//            strBuilder.Replace("[CollectionNamePattern]", _PatternsTemplate.Keys.GetKey("CollectionNamePattern").TextContent);
            
//            //strBuilder.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name);
//            //strBuilder.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX,_TemplateSettingObject.Entities.EntitySufix);
//            //strBuilder.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX_COLLECTION, _TemplateSettingObject.Entities.CollectionsSufix);
//            //strBuilder.Replace(CommonConstants.CONST_BACK_CnnStringKey, _TemplateSettingObject.OthersSettings.ConnectionStringKey);


//            //**

//            strBuilder.Replace(CommonConstants.CONST_STOREDPROCEDURE_NAME, GetStoredProcedureName(pMethodInfo, _TemplateSettingObject));
//            strBuilder.Replace(CommonConstants.CONST_BACK_END_METHOD_NAME, pMethodInfo.Name + "Batch");
//            strBuilder.Replace("[EntityId]", pMethodInfo.Entity.Name);

//            return strBuilder.ToString();
//        }


       


      
//        #endregion
        
      
//    }
//}
