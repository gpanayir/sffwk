using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;


namespace Fwk.Security
{
    public partial class FwkMembership
    {


        public static void CreateCategory(FwkCategory pFwkCategory, string pApplicationName)
        {
             CreateCategory(pFwkCategory, pApplicationName, ConnectionStringName);
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
        /// <param name="pConnectionStringName"></param>
        /// <param name="pApplicationName"></param>
        /// <returns></returns>
        public static List<FwkCategory> GetAllCategories(string pApplicationName)
        {
            return GetAllCategories(pApplicationName, ConnectionStringName);
        }

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

        public static List<aspnet_RulesInCategory> GetFwkRulesInCategory(int pCategoryId, string pConnectionStringName)
        {
            IEnumerable<aspnet_RulesInCategory> rulesinCat = null;
            try
            {

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {
                    rulesinCat = from s in dc.aspnet_RulesInCategories where s.CategoryId == pCategoryId select s;
                    return rulesinCat.ToList<aspnet_RulesInCategory>();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CreateRuleInCategory(FwkCategory pFwkCategory, string pApplicationName)
        {
            CreateRuleInCategory(pFwkCategory, pApplicationName, ConnectionStringName);
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
            
                foreach (aspnet_RulesInCategory rule in pFwkCategory.FwkRulesInCategoryList)
                {
                    rule.CategoryId = pFwkCategory.CategoryId;

                    str.Append(FwkMembershipScripts.RuleInCategory_i);

                    str.Replace("[RuleName]", rule.RuleName);
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
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        /// <returns></returns>
        static List<FwkCategory> GetSubCategoriesByCategoryId(int pCategoryId, string pApplicationName, string pConnectionStringName)
        {
            IEnumerable<FwkCategory> wCategories = null;
            try
            {
                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);
                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(pConnectionStringName))
                {
                    wCategories = from s in dc.aspnet_RulesCategories
                                  where (s.ParentCategoryId == pCategoryId
                        && s.ApplicationId == wApplicationId)
                                  select new FwkCategory { CategoryId = s.CategoryId, ParentId = s.ParentCategoryId, Name = s.Name };
                }
                return wCategories.ToList<FwkCategory>();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        static Guid GetApplication(string pApplicationName, string pConnectionStringName)
        {

            Guid wApplicationNameId = new Guid();
            try
            {

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {

                   aspnet_Application app = dc.aspnet_Applications.First<aspnet_Application>(p=> p.LoweredApplicationName.Equals(pApplicationName.ToLower()));

                    if(app != null)
                        wApplicationNameId = app.ApplicationId;
                }
                



                return wApplicationNameId;
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
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        public static void RemoveCategory(FwkCategory pParentFwkCategory, string pApplicationName)
        {
            RemoveCategory(pParentFwkCategory,pApplicationName,ConnectionStringName);
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
            else
            {

                DbCommand wCmd = null;
                Database wDataBase = null;

                try
                {

                    wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                    StringBuilder str = new StringBuilder(FwkMembershipScripts.Category_d);

                    str.Append(FwkMembershipScripts.Category_i);
                  
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
        }

        /// <summary>
        /// Verifica la existencia de una determinada categoria
        /// </summary>
        /// <param name="pCategoryName">Nombre de la categoria</param>
        /// <param name="pParentCategoryId">Id de la categora padre</param>
        /// <param name="pApplicationName">Nombre de la app</param>
        /// <returns></returns>
        public static bool ExistCategory(string pCategoryName, int pParentCategoryId, string pApplicationName)
        {
            return ExistCategory(pCategoryName, pParentCategoryId, pApplicationName, ConnectionStringName);
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
        /// <param name="pApplicationName"></param>
        /// <returns></returns>
        public static bool CategoryContainChilds(FwkCategory pParentFwkCategory, string pApplicationName)
        {
            return CategoryContainChilds(pParentFwkCategory, pApplicationName, ConnectionStringName);
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
