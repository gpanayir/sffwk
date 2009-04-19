using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using fwkDataEntities = Fwk.DataBase.DataEntities;
using CodeGenerator.Back;
using CodeGenerator.Back.ObjectModel;
using CodeGenerator.Back.Entities;
using CodeGenerator.Back.StoreProcedures;
using CodeGenerator.Back.DataAccess;
using CodeGenerator.Back.Schema;
using CodeGenerator.Back.Services;
using CodeGenerator.Controls;
using CodeGenerator.Back.Common;

namespace CodeGenerator.Controllers
{
    public class DACGenController : ControllerBase
    {
        #region Private Members

        private EntityGenerationInfo _EntityGenerationInfo = new EntityGenerationInfo();
        private String _SelectedObject = "Tables";
        private fwkDataEntities.Tables _Tables = null;
            private  fwkDataEntities.UserDefinedTypes _UserDefinedTypes;
        private fwkDataEntities.StoreProcedures _StoreProcedures = null;
        private List<GlobalElementComplexType> _GlobalElementComplexTypeList = null;
        private ListViewCodeGenerated _listViewCodeGenerated = null;



        #endregion

        #region Public Properties
        public ListViewCodeGenerated ListViewCodeGenerated
        {
            get { return _listViewCodeGenerated; }
            set { _listViewCodeGenerated = value; }
        }
        public string SelectedObject
        {
            get { return _SelectedObject; }
            set { _SelectedObject = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public fwkDataEntities.Tables Tables
        {
            get { return _Tables; }
            set { _Tables = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public fwkDataEntities.UserDefinedTypes UserDefinedTypes
        {
            get { return _UserDefinedTypes; }
            set
            {
                _UserDefinedTypes = value;
                ParametersDAC.UserDefinedTypes = _UserDefinedTypes;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public fwkDataEntities.StoreProcedures StoreProcedures
        {
            get { return _StoreProcedures; }
            set { _StoreProcedures = value; }
            
        }
        public List<GlobalElementComplexType> GlobalElementComplexTypeList
        {

            set { _GlobalElementComplexTypeList = value; }
        }

       

        #endregion

        /// <summary>
        /// Agrega codigo a :
        /// listViewCodeGenerated.GeneratedStoredProcedureCodeList
        /// listViewCodeGenerated.GeneratedDACCodeList
        /// listViewCodeGenerated.GeneratedTDGCodeList
        /// listViewCodeGenerated.GeneratedBECodeList
        /// </summary>
        public void Generate()
        {
            
            SetEntityGenerationInfo();

            DACGenerator.EntityGenerationInfo = _EntityGenerationInfo;
            TDGGenerator.EntityGenerationInfo = _EntityGenerationInfo;
            DatabaseEntityGenEngine.EntityGenerationInfo = _EntityGenerationInfo;
            DataServiceGenerator.EntityGenerationInfo = _EntityGenerationInfo;

            switch (_SelectedObject)
            {
                case "Tables":
                    {

                        _listViewCodeGenerated.NodeSP = SPFromTableCodeGenerator_GenerateCode();
                        _listViewCodeGenerated.NodeSVC = DataServiceGenerator.GenerateCode();
                        break;
                    }

            }            

            _listViewCodeGenerated.NodeDAC = DACGenerator.GenCode();
            _listViewCodeGenerated.NodeTDG = TDGGenerator.GenCode();
            _listViewCodeGenerated.GeneratedBECodeList = DatabaseEntityGenEngine.GenerateCode();
            _listViewCodeGenerated.LoadTtreeView();
        }


        /// <summary>
        /// Agrega codigo solo a :
        /// listViewCodeGenerated.GeneratedBECodeList
        /// </summary>
        public void GenerateBEOnly()
        {
            SetEntityGenerationInfo();
            DatabaseEntityGenEngine.EntityGenerationInfo = _EntityGenerationInfo;
            _listViewCodeGenerated.GeneratedBECodeList = DatabaseEntityGenEngine.GenerateCode();
            _listViewCodeGenerated.LoadTtreeView();
            _listViewCodeGenerated.ExpandBE();
        }

        public String GenerateBEFromSchema()
        {
            SetEntityGenerationInfo();

            SchemEntityGenEngine.EntityGenerationInfo = _EntityGenerationInfo;
            return SchemEntityGenEngine.GenCode(true);
        }

        /// <summary>
        /// Genera información sobre una entidad de negocio.
        /// </summary>
        /// <returns>información sobre la entidad.</returns>
        /// <date>2007-25-5T00:00:00</date>
        /// <author>moviedo</author>
        private List<EntityInfo> GenerateEntityInfo()
        {
            List<EntityInfo> wEntityInfoList = new List<EntityInfo>();
            EntityInfo wEntityInfo = null;

            switch (_SelectedObject)
            {
                case "Tables":
                    {
                        foreach (fwkDataEntities.Table wTable in _Tables)
                        {
                            wEntityInfo = new EntityInfo(wTable);
                            wEntityInfo.Name = wTable.Name;

                            //GenerateMethodInfo(wEntityInfo, _LvwMethods, _PerformBatch);
                            GenerateMethodInfo(wEntityInfo);
                            wEntityInfoList.Add(wEntityInfo);

                        }
                        break;
                    }
                case "StoreProcedures":
                    {
                        foreach (fwkDataEntities.StoreProcedure wStoreProcedure in _StoreProcedures)
                        {
                            wEntityInfo = new EntityInfo(wStoreProcedure);
                            wEntityInfo.Name = wStoreProcedure.Name;

                            GenerateMethodInfo(wEntityInfo);
                            wEntityInfoList.Add(wEntityInfo);

                        }
                        break;
                    }

                case "Schema":
                    {

                        wEntityInfo = new EntityInfo();

                        wEntityInfo.GlobalElementComplexTypeList = _GlobalElementComplexTypeList;
                        wEntityInfo.Name = string.Empty;

                        wEntityInfoList.Add(wEntityInfo);
                        break;
                    }
            }

            return wEntityInfoList;
        }

        /// <summary>
        /// Genera los script de los SPs.-
        /// </summary>
        /// <param name="pEntityGenerationInfo"></param>
        /// <returns></returns>
        private TreeNode SPFromTableCodeGenerator_GenerateCode()
        {
            SPCodeGenerator wSPFromTableCodeGenerator = null;
            try
            {
                wSPFromTableCodeGenerator = new SPCodeGenerator();
                return wSPFromTableCodeGenerator.GenCode(_EntityGenerationInfo);
            }
            catch (Exception ex)
            { throw ex; }

        }

        /// <summary>
        /// Inicializa un EntityGenerationInfo 
        /// </summary>
        /// <returns></returns>
        private void SetEntityGenerationInfo()
        {

            _EntityGenerationInfo.TemplateSettingObject = base.TemplateSettingObject;
            _EntityGenerationInfo.Entities = GenerateEntityInfo();


        }

        /// <summary>
        /// Genera información de métodos de una entidad.
        /// </summary>
        /// <param name="pEntityInfo"></param>
        /// <date>2007-25-5T00:00:00</date>
        /// <author>moviedo</author>
        private void GenerateMethodInfo(EntityInfo pEntityInfo)
        {

            MethodInfo wMethodInfo = null;

            if (_EntityGenerationInfo.TemplateSettingObject.Methods.IncludeInsert)
            {
                wMethodInfo = GetMethodInfo(pEntityInfo, MethodActionType.Insert,
                              _EntityGenerationInfo.TemplateSettingObject.MethodsName.Insert);

                pEntityInfo.Methods.Add(wMethodInfo);
            }
            if (_EntityGenerationInfo.TemplateSettingObject.Methods.IncludeUpdate)
            {
                wMethodInfo = GetMethodInfo(pEntityInfo, MethodActionType.Update,
                              _EntityGenerationInfo.TemplateSettingObject.MethodsName.Update);

                pEntityInfo.Methods.Add(wMethodInfo);
            }
            if (_EntityGenerationInfo.TemplateSettingObject.Methods.IncludeDelete)
            {
                wMethodInfo = GetMethodInfo(pEntityInfo, MethodActionType.Delete,
                              _EntityGenerationInfo.TemplateSettingObject.MethodsName.Delete);

                pEntityInfo.Methods.Add(wMethodInfo);
            }

            if (_EntityGenerationInfo.TemplateSettingObject.Methods.IncludeGetAll)
            {
                wMethodInfo = GetMethodInfo(pEntityInfo, MethodActionType.GetAll,
                              _EntityGenerationInfo.TemplateSettingObject.MethodsName.GetAll);

                pEntityInfo.Methods.Add(wMethodInfo);
            }

            if (_EntityGenerationInfo.TemplateSettingObject.Methods.IncludeGetByParam)
            {
                wMethodInfo = GetMethodInfo(pEntityInfo, MethodActionType.GetByParam,
                              _EntityGenerationInfo.TemplateSettingObject.MethodsName.GetByParam);

                pEntityInfo.Methods.Add(wMethodInfo);
            }
            if (_EntityGenerationInfo.TemplateSettingObject.Methods.IncludeGetPaginated)
            {
                wMethodInfo = GetMethodInfo(pEntityInfo, MethodActionType.GetAllPaginated,
                              _EntityGenerationInfo.TemplateSettingObject.MethodsName.GetAllPaginated);

                pEntityInfo.Methods.Add(wMethodInfo);
            }





            //if (lvwMethods == null) return;
            //MethodInfo wMethodInfo = null;

            //foreach (ListViewItem wItem in lvwMethods.CheckedItems)
            //{
            //    if (Enum.IsDefined(typeof(MethodActionType), wItem.Text))
            //    {
            //        //string wStr = wItem.Text;

            //        //wMethodInfo = new MethodInfo(pEntityInfo);
            //        //wMethodInfo.Name = wStr;
            //        //wMethodInfo.Action = (MethodActionType)Enum.Parse(typeof(MethodActionType), wStr);



            //    }
            //    else
            //    {
            //        wMethodInfo = (MethodInfo)wItem.Tag;
            //        wMethodInfo.Entity = pEntityInfo;
            //    }


            //}






        }

        MethodInfo GetMethodInfo(EntityInfo pEntityInfo, MethodActionType pMethodActionType, String pMethodName)
        {
            MethodInfo wMethodInfo;
            String wStr = Enum.GetName(typeof(MethodActionType), pMethodActionType);

            wMethodInfo = new MethodInfo(pEntityInfo);
            wMethodInfo.Name = pMethodName;
            wMethodInfo.Action = (MethodActionType)Enum.Parse(typeof(MethodActionType), wStr);

            switch (wMethodInfo.Action)
            {
                case MethodActionType.Insert:
                case MethodActionType.Update:
                    {
                        wMethodInfo.ParameterType = MethodParameterType.BE;
                        wMethodInfo.PerformBatch = _EntityGenerationInfo.TemplateSettingObject.Methods.GenerateBatch;
                        wMethodInfo.ReturnType = MethodReturnType.Void;
                        MethodInfo.GenerateParameters(wMethodInfo);
                        break;
                    }
                case MethodActionType.Delete:
                    {
                        wMethodInfo.ParameterType = MethodParameterType.SimpleValues;
                        wMethodInfo.PerformBatch = false;
                        wMethodInfo.ReturnType = MethodReturnType.Void;
                        MethodInfo.GenerateParameters(wMethodInfo);
                        break;
                    }
                case MethodActionType.Get:
                    {
                        wMethodInfo.ParameterType = MethodParameterType.BE;
                        wMethodInfo.PerformBatch = false;
                        wMethodInfo.ReturnType = MethodReturnType.DataSet;
                        MethodInfo.GenerateParameters(wMethodInfo);
                        break;
                    }
                case MethodActionType.GetByParam:
                    {
                        wMethodInfo.ParameterType = MethodParameterType.BE;
                        wMethodInfo.PerformBatch = false;
                        wMethodInfo.ReturnType = MethodReturnType.DataSet;
                        MethodInfo.GenerateParameters(wMethodInfo);
                        break;
                    }
                case MethodActionType.GetAll:
                    {
                        wMethodInfo.ParameterType = MethodParameterType.SimpleValues;
                        wMethodInfo.PerformBatch = false;
                        wMethodInfo.ReturnType = MethodReturnType.DataSet;
                        break;
                    }
                case MethodActionType.GetAllPaginated:
                    {
                        wMethodInfo.ParameterType = MethodParameterType.SimpleValues;
                        wMethodInfo.PerformBatch = false;
                        wMethodInfo.ReturnType = MethodReturnType.PaginatedDataSet;
                        break;
                    }
            }

            return wMethodInfo;
        }
    }
}
