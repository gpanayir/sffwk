using System;
using System.Collections.Generic;
using System.Text;
using Fwk.DataBase.DataEntities;
using CodeGenerator.Back.Common;
using CodeGenerator.Back.ObjectModel;

namespace CodeGenerator.Back.DataAccess
{
    public class BaseGenTDG
    {
        private static Template _PatternsTemplate = null;
        /// <summary>
        /// retorna ej:
        /// w[PrefixType]
        /// </summary>
        private static String _PrefixPattern;
        private static String _NamePattern;
        
        static BaseGenTDG()
        {
            _PatternsTemplate = TemplateProvider.Templates.GetTemplate(TemplateProviderEnum.Patterns);
            _PrefixPattern = _PatternsTemplate.Keys.GetKey("LocalVariablePrefixPattern").TextContent;
            _PrefixPattern = _PrefixPattern.Replace(CommonConstants.CONST_ENTITY_PREFIX_TYPE, _PatternsTemplate.Keys.GetKey("ObjectPrefix").TextContent);
            _NamePattern = _PatternsTemplate.Keys.GetKey("NamePattern").TextContent;

        }
        /// <summary>
        /// Obtiene el nombre del SP para ser llamado desde la TDG
        /// </summary>
        /// <param name="pMethodInfo"></param>
        /// <param name="pTableName"></param>
        /// <returns></returns>
        public static string GetStoredProcedureName(MethodInfo pMethodInfo, TemplateSettingObject _TemplateSettingObject)
        {
            
            String wSufix = String.Empty;
            String wSpname;
            switch (pMethodInfo.Action)
            {
                case MethodActionType.Insert:
                    {
                        wSufix =  _TemplateSettingObject.StoreProcedures.InsertSufix;
                        break;
                    }
                case MethodActionType.Update:
                    {
                        wSufix = _TemplateSettingObject.StoreProcedures.UpdateSufix;
                        break;
                    }
                case MethodActionType.Delete:
                    {
                        wSufix = _TemplateSettingObject.StoreProcedures.DeleteSufix;
                        break;
                    }
                case MethodActionType.GetAll:
                    {
                        wSufix = _TemplateSettingObject.StoreProcedures.GetAllSufix;
                        break;
                    }
                case MethodActionType.GetByParam:
                    {
                        wSufix = _TemplateSettingObject.StoreProcedures.GetByParamSufix;
                        break;
                    }
                case MethodActionType.GetAllPaginated:
                    {
                        wSufix = _TemplateSettingObject.StoreProcedures.GetAllPaginated;
                        break;
                    }
            }
            wSpname = _PatternsTemplate.Keys.GetKey("StoreProcedureNamePattern").TextContent;
            wSpname = wSpname.Replace(CommonConstants.CONST_ENTITY_NAME, pMethodInfo.Entity.Name);
            wSpname = wSpname.Replace(CommonConstants.CONST_ENTITY_PREFIXSUFIX, wSufix);

            wSpname = wSpname.Replace("[Schema]", pMethodInfo.Entity.Table.Schema);

            return wSpname;



        }


        /// <summary>
        /// Retorna w[NombreEntidad].[NombreClave]
        /// </summary>
        /// <param name="pEntity">EntityInfo</param>
        /// <returns>[NombreEntidad].[NombreClave]</returns>
        public static string GetPrimaryKeyFromTable(EntityInfo pEntity)
        {
            
            String str = String.Empty;
            foreach (Column wColumn in pEntity.Table.Columns)
            {
                if (wColumn.IsIdentity)
                {

                    str = _PrefixPattern + _NamePattern + "." + wColumn.Name;
                    return str.Replace(CommonConstants.CONST_ENTITY_NAME ,pEntity.Name);
                }
            }
            return String.Empty;
        }
    }
}
