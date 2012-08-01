﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace MultiLanguageMannager
{
    internal class MultilanguageDAC
    {
        static string cnnStringNAme = "bb";
        internal static void CreateORUpdateKey(string language, string group, string key, string value)
        {
            using (ConfigDataContext dc = new ConfigDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["bb"].ConnectionString))
            {
                bool wExist = false;
                fwk_ConfigMannager record;

                //Verifico que clave y valor exista
                wExist = dc.fwk_ConfigMannagers.Any(p => p.ConfigurationFileName.Equals(language)
                && p.group.Equals(group)
                && p.key.Equals(key));

                if (wExist)
                {
                    record = dc.fwk_ConfigMannagers.Where(p => p.ConfigurationFileName.Equals(language)
                                      && p.group.Equals(group)
                                      && p.key.Equals(key)).FirstOrDefault<fwk_ConfigMannager>();

                    record.value = value;// e.Value.ToString().Trim();
                }

                else
                {
                    record = new fwk_ConfigMannager();
                    record.ConfigurationFileName = language;
                    record.group = group;
                    record.key = key;
                    record.value = value;
                    dc.fwk_ConfigMannagers.InsertOnSubmit(record);
                }
                dc.SubmitChanges();
            }
        }
        internal static void CreateNewKey(string group, string key, out string errorMsg)
        {
            string language;
            errorMsg = string.Empty;
            fwk_ConfigMannager record = null;
            Boolean wExist = false;
            using (ConfigDataContext dc = new ConfigDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringNAme].ConnectionString))
            {
                for (int i = 0; i < Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers.Count; i++)
                {
                    language = Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers[i].Name;
                    //Verifico que clave y valor exista
                    wExist = dc.fwk_ConfigMannagers.Any(p => p.ConfigurationFileName.Equals(language)
                    && p.group.Equals(group)
                    && p.key.Equals(key));

                    if (wExist)
                    {

                        errorMsg = String.Format("Ya existe la clave {0} en el grupo {1} para alguno de los lenguajes", key, group);
                        continue;
                    }
                    else
                    {
                        record = new fwk_ConfigMannager();
                        record.ConfigurationFileName = language;
                        record.group = group;
                        record.key = key;
                        dc.fwk_ConfigMannagers.InsertOnSubmit(record);
                    }
                    dc.SubmitChanges();
                }
            }
        }

        internal static void Remove(string group, string key)
        {
            using (ConfigDataContext dc = new ConfigDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringNAme].ConnectionString))
            {
                var records = dc.fwk_ConfigMannagers.Where(p =>
                                            p.group.Equals(group)
                                       && p.key.Equals(key));

                foreach (fwk_ConfigMannager config in records)
                {
                    dc.fwk_ConfigMannagers.DeleteOnSubmit(config);
                }
                dc.SubmitChanges();
            }
        }

        internal static DataSet RetrivePivotedConfigs(String columns)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            wDataBase = DatabaseFactory.CreateDatabase(cnnStringNAme);
            wCmd = wDataBase.GetStoredProcCommand("fwk_ConfigMannager_PIVOT");
            wDataBase.AddInParameter(wCmd, "columns", System.Data.DbType.String, columns);

            return wDataBase.ExecuteDataSet(wCmd);
        }


        internal static DataSet RetrivePivotedParams(String columns)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            wDataBase = DatabaseFactory.CreateDatabase(cnnStringNAme);
            wCmd = wDataBase.GetStoredProcCommand("ParamCampings_PIVOT");
            wDataBase.AddInParameter(wCmd, "columns", System.Data.DbType.String, columns);

            return wDataBase.ExecuteDataSet(wCmd);
        }

        internal static void CreateORUpdate_Param(string language, int paramCampaingIdRelated, int codigo, string name)
        {
            using (ConfigDataContext dc = new ConfigDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["bb"].ConnectionString))
            {
                bool wExist = false;
                ParamCampaing record;

                //Verifico que clave y valor exista
                wExist = dc.ParamCampaings.Any(p => p.Language.Equals(language)
                && p.ParamCapaingId.Equals(codigo));

                if (wExist)
                {
                    record = dc.ParamCampaings.Where(p => p.Language.Equals(language)
                                      && p.ParamCampaingIdRelated.Equals(paramCampaingIdRelated)
                                      && p.ParamCapaingId.Equals(codigo)).FirstOrDefault<ParamCampaing>();

                    record.Name = name;// e.Value.ToString().Trim();
                }

                else
                {
                    record = new ParamCampaing();
                    record.Language = language;
                    record.ParamCapaingId = codigo;
                    record.ParamCampaingIdRelated = paramCampaingIdRelated;
                    //record.Remarks = "";
                    record.Name = name;
                    dc.ParamCampaings.InsertOnSubmit(record);
                }
                dc.SubmitChanges();
            }
        }

        internal static void Remove_Param(int paramCampaingId)
        {
            using (ConfigDataContext dc = new ConfigDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringNAme].ConnectionString))
            {
                var records = dc.ParamCampaings.Where(p =>
                                            p.ParamCapaingId.Equals(paramCampaingId)
                                       );

                foreach (ParamCampaing param in records)
                {
                    dc.ParamCampaings.DeleteOnSubmit(param);
                }
                dc.SubmitChanges();
            }
        }

        internal static void CreateNewParam(ParamCampaing param ,string relatedName, out string errMsg)
        {

            string language;
            errMsg = string.Empty;
            ParamCampaing record = null;
            Boolean wExist = false;
            using (ConfigDataContext dc = new ConfigDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringNAme].ConnectionString))
            {
                for (int i = 0; i < Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers.Count; i++)
                {
                    language = Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers[i].Name;
                    //Verifico que clave y valor exista
                    wExist = dc.ParamCampaings.Any(p => p.Language.Equals(language)
                    && p.ParamCampaingIdRelated.Equals(param.ParamCampaingIdRelated)
                    && p.ParamCapaingId.Equals(param.ParamCapaingId));

                    if (wExist)
                    {

                        errMsg = String.Format("Ya existe la param {0} codig:{1} en el grupo {2} para alguno de los lenguajes", param.Name,param.ParamCapaingId, relatedName);
                        return;
                    }
                    else
                    {
                        record = new ParamCampaing();
                        record.Language = language;
                        record.ParamCampaingIdRelated = param.ParamCampaingIdRelated;
                        record.ParamCapaingId = param.ParamCapaingId;
                        record.Name = param.Name;
                        record.Remarks = param.Remarks;
                        dc.ParamCampaings.InsertOnSubmit(record);
                    }
                    dc.SubmitChanges();
                }
            }

        }
    }
}

