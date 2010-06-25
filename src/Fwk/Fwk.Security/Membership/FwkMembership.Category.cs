﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Web.Security;
using Fwk.Exceptions;


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
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            CreateCategory(pFwkCategory, wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFwkCategory"></param>
        /// <param name="connectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        public static void CreateCategory(FwkCategory pFwkCategory, string applicationName, string connectionStringName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;


            try
            {
                Guid wApplicationId = GetApplication(applicationName, connectionStringName);

                wDataBase = DatabaseFactory.CreateDatabase(connectionStringName);
                StringBuilder str = new StringBuilder(FwkMembershipScripts.Category_i);


                str.Replace("[ApplicationId]", wApplicationId.ToString());
                if (pFwkCategory.ParentId == null) pFwkCategory.ParentId = 0;
                str.Replace("[ParentCategoryId]", pFwkCategory.ParentId.ToString());
                str.Replace("[CategoryName]", pFwkCategory.Name.ToLower());

                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;

                pFwkCategory.CategoryId = Convert.ToInt32(wDataBase.ExecuteScalar(wCmd));

                if (pFwkCategory.FwkRulesInCategoryList != null)
                    if (pFwkCategory.FwkRulesInCategoryList.Count != 0)
                        CreateRuleInCategory(pFwkCategory, applicationName.ToLower(), connectionStringName);



            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Obtiene las Categorias de una determinada aplicacion
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static FwkCategoryList GetAllCategories(string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return GetAllCategories(wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }


        /// <summary>
        /// Obtiene las Categorias de una determinada aplicacion. Recibe el Nombre de cadena de coneccion del archivo de configuracion.-
        /// </summary>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="connectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        /// <returns></returns>
        public static FwkCategoryList GetAllCategories(string applicationName, string connectionStringName)
        {

            FwkCategory wCategory;
            FwkCategoryList wCategoryList = null;
            try
            {
                Guid wApplicationId = GetApplication(applicationName, connectionStringName);
                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                {
                    var rulesinCat = from s in dc.aspnet_RulesCategories where s.ApplicationId == wApplicationId select s;

                    wCategoryList = new FwkCategoryList();
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
                    category.FwkRulesInCategoryList = GetFwkRules_By_Category(category.CategoryId, connectionStringName);
                }


                return wCategoryList;
            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Busca las reglas agrupadas en una determinada categoria.-
        /// </summary>
        /// <param name="pCategoryId">Identificador de categoria</param>
        /// <param name="connectionStringName">Cadena de coanexion</param>
        /// <returns></returns>
        public static FwkAuthorizationRuleList GetFwkRules_By_Category(int pCategoryId, string connectionStringName)
        {
            IEnumerable<FwkAuthorizationRule> rulesinCat = null;
            FwkAuthorizationRuleList list = null;
            try
            {

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                {
                    rulesinCat = from s in dc.aspnet_Rules
                                 from p in dc.aspnet_RulesInCategories

                                 where
                                 s.name.Equals(p.RuleName)
                                 &&
                                 p.CategoryId == pCategoryId
                                 select new FwkAuthorizationRule { Name = s.name, Expression = s.expression };



                    list = new FwkAuthorizationRuleList();
                    list.AddRange(rulesinCat);
                    return list;

                }

            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Crea una categoria nueva
        /// </summary>
        /// <param name="pFwkCategory"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateRuleInCategory(FwkCategory pFwkCategory, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            CreateRuleInCategory(pFwkCategory, wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }


        /// <summary>
        /// Elimina todas las filas de RuleInCategory y las agrega nuevamente.- 
        /// Las que agrega son las que se mofificaron desde el front end u otro origen.-
        /// </summary>
        /// <param name="pFwkCategory"></param>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="connectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        static void CreateRuleInCategory(FwkCategory pFwkCategory, string applicationName, string connectionStringName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;
            Guid id = GetApplication(applicationName, connectionStringName);

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(connectionStringName);
                StringBuilder str = new StringBuilder(FwkMembershipScripts.RulesInCategory_d);

                foreach (FwkAuthorizationRule rule in pFwkCategory.FwkRulesInCategoryList)
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
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Busca las subcategorias de una categoria padre.-
        /// </summary>
        /// <param name="pCategoryId">Id de la categoria padre.-</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        static List<FwkCategory> GetSubCategoriesByCategoryId(int pCategoryId, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return GetSubCategoriesByCategoryId(pCategoryId, wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }

        /// <summary>
        /// Obtiene las subcategorias de una categoria.-
        /// </summary>
        /// <param name="pCategoryId"></param>
        /// <param name="applicationName">Nombre de la aplicacion de membership</param>
        /// <param name="connectionStringName">Nombre de cadena de coneccion</param>
        /// <returns></returns>
        static List<FwkCategory> GetSubCategoriesByCategoryId(int pCategoryId, string applicationName, string connectionStringName)
        {

            IEnumerable<FwkCategory> wCategories = null;
            FwkCategory wFwkCategory = new FwkCategory();
            try
            {
                Guid wApplicationId = GetApplication(applicationName, connectionStringName);
                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
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

                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }

        }

        /// <summary>
        ///  Remueve una categoria y sus subcategorias recursivamente
        /// </summary>
        /// <param name="parentFwkCategoryId"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void RemoveCategory(int parentFwkCategoryId, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            RemoveCategory(parentFwkCategoryId, wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }


        /// <summary>
        /// Remueve una categoria y sus subcategorias recursivamente
        /// </summary>
        /// <param name="parentFwkCategoryId"></param>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="connectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        public static void RemoveCategory(Int32 parentFwkCategoryId,string applicationName, string connectionStringName)
        {
            if (CategoryContainChilds(parentFwkCategoryId,applicationName, connectionStringName))
            {
                List<FwkCategory> subCategories = GetSubCategoriesByCategoryId(parentFwkCategoryId, applicationName, connectionStringName);
                //Remueve recursivamente todos los hijos asta la ultima subcategoria
                foreach (FwkCategory wFwkCategory in subCategories)
                {
                    RemoveCategory(wFwkCategory.CategoryId, applicationName, connectionStringName);
                }
            }

            DbCommand wCmd = null;
            Database wDataBase = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(connectionStringName);
                //Elimina Rules in categoria (tabla nav entre categoria y reglas)
                StringBuilder str = new StringBuilder(FwkMembershipScripts.RulesInCategory_d);
                //Elimina la categoria en si
                str.AppendLine(FwkMembershipScripts.Category_d);

                str.Replace("[CategoryId]", parentFwkCategoryId.ToString());

                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;
                wDataBase.ExecuteNonQuery(wCmd);
            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
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
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return ExistCategory(pCategoryName, pParentCategoryId, wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }

        /// <summary>
        /// Verifica la existencia de una determinada categoria
        /// </summary>
        /// <param name="pCategoryName">Nombre de la categoria</param>
        /// <param name="pParentCategoryId">Id de la categora padre</param>
        /// <param name="applicationName">Nombre de la app</param>
        /// <param name="connectionStringName">Nombre de la cadena de conección</param>
        /// <returns></returns>
        public static bool ExistCategory(string pCategoryName, int pParentCategoryId, string applicationName, string connectionStringName)
        {
            try
            {
                Guid wApplicationId = GetApplication(applicationName, connectionStringName);
                using (Fwk.Security.RuleProviderDataContext dc =
                    new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                {

                    return dc.aspnet_RulesCategories.Any<aspnet_RulesCategory>
                        (p => p.Name.ToLower() == pCategoryName.ToLower()
                        && p.ApplicationId == wApplicationId
                        && p.ParentCategoryId == pParentCategoryId);

                }

            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Determina si la categoria contiene subcategorias.-
        /// </summary>
        /// <param name="parentFwkCategoryId">id de categoria</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static bool CategoryContainChilds(int parentFwkCategoryId, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return CategoryContainChilds(parentFwkCategoryId, wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }


        /// <summary>
        /// Determina si la categoria contiene subcategorias.-
        /// </summary>
        /// <param name="parentFwkCategoryId">id de categoria</param>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="connectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        /// <returns></returns>
        public static bool CategoryContainChilds(int parentFwkCategoryId, string applicationName, string connectionStringName)
        {

            try
            {
                Guid wApplicationId = GetApplication(applicationName, connectionStringName);
                using (Fwk.Security.RuleProviderDataContext dc =
                    new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                {

                    bool contain = dc.aspnet_RulesCategories.Any<aspnet_RulesCategory>(p => p.ParentCategoryId == parentFwkCategoryId && p.ApplicationId == wApplicationId);
                    //if (contain == false)
                    //    contain = dc.aspnet_RulesInCategories.Any<aspnet_RulesInCategory>(p => p.CategoryId == parentFwkCategoryId && p.ApplicationId == wApplicationId);

                    return contain;

                }

            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }
    }



}
