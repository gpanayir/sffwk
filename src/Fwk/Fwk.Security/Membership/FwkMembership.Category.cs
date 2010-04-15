﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Web.Security;


namespace Fwk.Security
{
    public partial class FwkMembership
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFwkCategory"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateCategory(FwkCategory pFwkCategory, string providerName)
        {
            
             CreateCategory(pFwkCategory, providerName, GetSqlMembershipProvider_ConnectionStringName(providerName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFwkCategory"></param>
        /// <param name="pConnectionStringName"></param>
        /// <param name="pApplicationName"></param>
        public static void CreateCategory(FwkCategory pFwkCategory, string pApplicationName, string pConnectionStringName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;
      
            
            try
            {
                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);

                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                StringBuilder str = new StringBuilder(FwkMembershipScripts.Category_i);
               
              
                str.Replace("[ApplicationId]", wApplicationId.ToString());
                if (pFwkCategory.ParentId == null) pFwkCategory.ParentId = 0;
                str.Replace("[ParentCategoryId]", pFwkCategory.ParentId.ToString());
                str.Replace("[CategoryName]", pFwkCategory.Name.ToLower());
               
                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;

                pFwkCategory.CategoryId = Convert.ToInt32(wDataBase.ExecuteScalar(wCmd));

                if (pFwkCategory.FwkRulesInCategoryList!=null)
                    if (pFwkCategory.FwkRulesInCategoryList.Count != 0)
                    CreateRuleInCategory(pFwkCategory, pApplicationName.ToLower(), pConnectionStringName);
                            

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene las Categorias de una determinada aplicacion
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static List<FwkCategory> GetAllCategories(string providerName)
        {
            return GetAllCategories(providerName, GetSqlMembershipProvider_ConnectionStringName(providerName));
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        /// <returns></returns>
        public static List<FwkCategory> GetAllCategories(string pApplicationName, string pConnectionStringName)
        {
           
            FwkCategory wCategory;
            List<FwkCategory> wCategoryList = null;
            try
            {
                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);
                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {
                    var rulesinCat = from s in dc.aspnet_RulesCategories where s.ApplicationId == wApplicationId select s;
                   
                        wCategoryList = new List<FwkCategory>();
                        foreach (aspnet_RulesCategory aspnet_cat in rulesinCat.ToList<aspnet_RulesCategory>())
                        {
                            wCategory = new FwkCategory();
                            wCategory.CategoryId = aspnet_cat.CategoryId;
                            if (aspnet_cat.ParentCategoryId != null)
                                wCategory.ParentId = aspnet_cat.ParentCategoryId;
                            wCategory.Name = aspnet_cat.Name;
                            wCategoryList.Add(wCategory);
                        }
                    
                }
                
                foreach (FwkCategory category in wCategoryList)
                {
                    category.FwkRulesInCategoryList = GetFwkRulesInCategory(category.CategoryId, pConnectionStringName);
                }
                
               
                return wCategoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCategoryId"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static List<FwkAuthorizationRuleAux> GetFwkRulesInCategory(int pCategoryId, string providerName)
        {
            IEnumerable<FwkAuthorizationRuleAux> rulesinCat = null;
            try
            {

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[GetSqlMembershipProvider_ConnectionStringName(providerName)].ConnectionString))
                {
                    rulesinCat = from s in dc.aspnet_Rules
                                 from p in dc.aspnet_RulesInCategories

                                 where
                                 s.name.Equals(p.RuleName)
                                 &&
                                 p.CategoryId == pCategoryId
                                 select new FwkAuthorizationRuleAux { Name = s.name, Expression = s.expression };




                    return rulesinCat.ToList<FwkAuthorizationRuleAux>();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFwkCategory"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateRuleInCategory(FwkCategory pFwkCategory, string providerName)
        {
            CreateRuleInCategory(pFwkCategory, providerName, GetSqlMembershipProvider_ConnectionStringName(providerName));
        }


        /// <summary>
        /// Elimina todas las filas de RuleInCategory y las agrega nuevamente.- 
        /// Las que agrega son las que se mofificaron desde el front end u otro origen.-
        /// </summary>
        /// <param name="pFwkCategory"></param>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        public static void CreateRuleInCategory(FwkCategory pFwkCategory,string pApplicationName,string pConnectionStringName)
        {
            
            Database wDataBase = null;
            DbCommand wCmd = null;
            Guid id = GetApplication(pApplicationName, pConnectionStringName);

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                StringBuilder str = new StringBuilder(FwkMembershipScripts.RulesCategory_d);

                foreach (FwkAuthorizationRuleAux rule in pFwkCategory.FwkRulesInCategoryList)
                {
                    

                    str.Append(FwkMembershipScripts.RuleInCategory_i);

                    str.Replace("[RuleName]", rule.Name);
                }
                str.Replace("[CategoryId]", pFwkCategory.CategoryId.ToString());
                str.Replace("[ApplicationId]", id.ToString());
                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;

                wDataBase.ExecuteNonQuery(wCmd);

        

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Obtiene las subcategorias de una categoria.-
        /// </summary>
        /// <param name="pCategoryId"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        static List<FwkCategory> GetSubCategoriesByCategoryId(int pCategoryId, string providerName)
        {
            IEnumerable<FwkCategory> wCategories = null;
            FwkCategory wFwkCategory= new FwkCategory ();
            try
            {
                Guid wApplicationId = GetApplication(pApplicationName, GetSqlMembershipProvider_ConnectionStringName(providerName));
                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[GetSqlMembershipProvider_ConnectionStringName(providerName)].ConnectionString))
                {
                    wCategories = from s in dc.aspnet_RulesCategories
                                  where (s.ParentCategoryId == pCategoryId
                        && s.ApplicationId == wApplicationId)
                                  select new FwkCategory { CategoryId = s.CategoryId, ParentId = s.ParentCategoryId, Name = s.Name };

                    //var wRulesCategories = from s in dc.aspnet_RulesCategories
                    //                       where (s.ParentCategoryId == pCategoryId
                    //                       && s.ApplicationId == wApplicationId)
                    //                       select s;

                    //foreach(aspnet_RulesCategory rule in wRulesCategories.ToList<aspnet_RulesCategory>())
                    //{
                    //    wFwkCategory = new FwkCategory ();
                    //    wFwkCategory.CategoryId = pCategoryId;
                    //    wFwkCategory.Name = rule.Name;
                    //    wFwkCategory.ParentId = rule.ParentCategoryId;
              
                    //wCategories.Add(wFwkCategory);
                    //}
                    return wCategories.ToList<FwkCategory>();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        ///  Remueve una categoria y sus subcategorias recursivamente
        /// </summary>
        /// <param name="pParentFwkCategory"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void RemoveCategory(FwkCategory pParentFwkCategory, string providerName)
        {
            RemoveCategory(pParentFwkCategory, providerName, GetSqlMembershipProvider_ConnectionStringName(providerName));
        }


        /// <summary>
        /// Remueve una categoria y sus subcategorias recursivamente
        /// </summary>
        /// <param name="pParentFwkCategory"></param>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        public static void RemoveCategory(FwkCategory pParentFwkCategory, string pApplicationName, string pConnectionStringName)
        {
            if (CategoryContainChilds(pParentFwkCategory, pApplicationName))
            {
                List<FwkCategory> subCategories = GetSubCategoriesByCategoryId(pParentFwkCategory.CategoryId, pApplicationName, pConnectionStringName);
                //Remueve recursivamente todos los hijos asta la ultima subcategoria
                foreach (FwkCategory wFwkCategory in subCategories)
                {
                    RemoveCategory(wFwkCategory, pApplicationName, pConnectionStringName);
                }

            }

            DbCommand wCmd = null;
            Database wDataBase = null;

            try
            {

                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                StringBuilder str = new StringBuilder(FwkMembershipScripts.Category_d);



                str.Replace("[CategoryId]", pParentFwkCategory.CategoryId.ToString());

                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;
                wDataBase.ExecuteNonQuery(wCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Verifica la existencia de una determinada categoria
        /// </summary>
        /// <param name="pCategoryName">Nombre de la categoria</param>
        /// <param name="pParentCategoryId">Id de la categora padre</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static bool ExistCategory(string pCategoryName, int pParentCategoryId, string providerName)
        {
            return ExistCategory(pCategoryName, pParentCategoryId, providerName, GetSqlMembershipProvider_ConnectionStringName(providerName));
        }

        /// <summary>
        /// Verifica la existencia de una determinada categoria
        /// </summary>
        /// <param name="pCategoryName">Nombre de la categoria</param>
        /// <param name="pParentCategoryId">Id de la categora padre</param>
        /// <param name="pApplicationName">Nombre de la app</param>
        /// <param name="pConnectionStringName">Nombre de la cadena de conección</param>
        /// <returns></returns>
        public static bool ExistCategory(string pCategoryName, int pParentCategoryId, string pApplicationName, string pConnectionStringName)
        {
            try
            {
                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);
                using (Fwk.Security.RuleProviderDataContext dc =
                    new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {

                    return dc.aspnet_RulesCategories.Any<aspnet_RulesCategory>
                        (p => p.Name.ToLower() == pCategoryName.ToLower()
                        && p.ApplicationId == wApplicationId 
                        && p.ParentCategoryId == pParentCategoryId);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        /// <summary>
        /// Determina si la categoria contiene subcategorias.-
        /// </summary>
        /// <param name="pParentFwkCategory"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static bool CategoryContainChilds(FwkCategory pParentFwkCategory, string providerName)
        {
            return CategoryContainChilds(pParentFwkCategory, providerName, GetSqlMembershipProvider_ConnectionStringName(providerName));
        }


        /// <summary>
        /// Determina si la categoria contiene subcategorias.-
        /// </summary>
        /// <param name="pParentFwkCategory"></param>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        /// <returns></returns>
        public static bool CategoryContainChilds(FwkCategory pParentFwkCategory, string pApplicationName, string pConnectionStringName)
        {
           
            try
            {
               Guid  wApplicationId = GetApplication( pApplicationName, pConnectionStringName);
                using (Fwk.Security.RuleProviderDataContext dc = 
                    new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {

                    return dc.aspnet_RulesCategories.Any<aspnet_RulesCategory>
                        (p => p.ParentCategoryId == pParentFwkCategory.CategoryId 
                        && p.ApplicationId == wApplicationId);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }



}
