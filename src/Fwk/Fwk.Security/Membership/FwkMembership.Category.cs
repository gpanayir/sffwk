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
            Int32 id;
            
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                StringBuilder str = new StringBuilder ( FwkMembershipScripts.ApplicationId_s);
               
                str.Append(FwkMembershipScripts.Category_i);
                str.Replace("[ApplicationName]", pApplicationName.ToLower());
                if (pFwkCategory.ParentId == null) pFwkCategory.ParentId = 0;
                str.Replace("[ParentCategoryId]", pFwkCategory.ParentId.ToString());
                str.Replace("[CategoryName]", pFwkCategory.Name.ToLower());
               
                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;

                pFwkCategory.CategoryId = Convert.ToInt32(wDataBase.ExecuteScalar(wCmd));


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
        public static List<FwkCategory> GetRuleCategories(string pApplicationName)
        {
            return GetRuleCategories(pApplicationName, ConnectionStringName);
        }

        public static List<FwkCategory> GetRuleCategories(string pApplicationName, string pConnectionStringName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;
            FwkCategory wCategory;
            List<FwkCategory> wCategoryList = null;
            try
            {
                ///TODO: Ver linq
                //Fwk.Security.Membership.RulesDataContext dc = new Fwk.Security.Membership.RulesDataContext(pConnectionStringName);
                //var xx = from s in dc.aspnet_RulesCategories where 
                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                wCmd = wDataBase.GetStoredProcCommand("[aspnet_Categories_s]");

                /// ApplicationName
                wDataBase.AddInParameter(wCmd, "ApplicationName", System.Data.DbType.String, pApplicationName);
                wCategoryList = new List<FwkCategory>();
                using (IDataReader reader = wDataBase.ExecuteReader(wCmd))
                {
                    while (reader.Read())
                    {
                        wCategory = new FwkCategory();
                        wCategory.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                        if(reader["ParentCategoryId"] != DBNull.Value)
                            wCategory.ParentId = Convert.ToInt32(reader["ParentCategoryId"]);
                        wCategory.Name = Convert.ToString(reader["Name"]);
                        wCategoryList.Add(wCategory);
                    }
                }
                return wCategoryList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void CreateRuleInCategory(FwkCategory pFwkCategory,string pApplicationName,string pConnectionStringName)
        {
            
            Database wDataBase = null;
            DbCommand wCmd = null;
            

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                StringBuilder str = new StringBuilder (FwkMembershipScripts.ApplicationId_s);
                str.Replace("[ApplicationName]", pApplicationName.ToLower());
                foreach (FwkRulesInCategory rule in pFwkCategory.FwkRulesInCategoryList)
                {
                    rule.CategoryId = pFwkCategory.CategoryId;

                    str.Append(FwkMembershipScripts.RuleInCategory_i);
                    str.Replace("[CategoryId]", rule.CategoryId.ToString());
                    str.Replace("[RuleName]", rule.RuleName);
                }
                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;

                wDataBase.ExecuteNonQuery(wCmd);

        

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static Guid GetApplication(string pApplicationName, string pConnectionStringName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;
            Guid wApplicationNameId = new Guid();
           
            try
            {
                ///TODO: Ver linq
                //using (Fwk.Security.Membership.RulesDataContext dc = new Fwk.Security.Membership.RulesDataContext(pConnectionStringName))
                //{

                //    wApplicationNameId = from s in dc.aspnet_Applications where s.ApplicationName.Equals(pApplicationName) select s.ApplicationId;
                //}
                

                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
            

                StringBuilder str = new StringBuilder (FwkMembershipScripts.ApplicationId_s);

                str.Replace("[ApplicationName]", pApplicationName);

                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;


         
                IDataReader reader = wDataBase.ExecuteReader(wCmd);
                
                while (reader.Read())
                {
                   wApplicationNameId = (Guid)reader["ApplicationNameId"];
                }



                return wApplicationNameId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }



    internal static class FwkMembershipScripts
    {
        static string _RuleInCategory_i;

        public static string RuleInCategory_i
        {
            get
            {
                SetRuleInCategory_i();
                return FwkMembershipScripts._RuleInCategory_i;
            }

        }

        static string _ApplicationId_s;

        public static string ApplicationId_s
        {
            get
            {
                SetApplicationId();
                return FwkMembershipScripts._ApplicationId_s;
            }

        }
        static string _Category_i;

        public static string  Category_i
        {
            get
            {
                SetCategory_i();
                return _Category_i;
            }

        }
        static void SetRuleInCategory_i()
        {

            if (string.IsNullOrEmpty(_RuleInCategory_i ))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);

                sb.Append(@"	INSERT INTO aspnet_RulesInCategory");
                sb.Append(@"		(CategoryId");
                sb.Append(@"		,RuleName");
                sb.Append(@"		,ApplicationId)");

                sb.Append(@"	VALUES (");
                sb.Append(@"		[CategoryId],");
                sb.Append(@"		'[RuleName]',");
                sb.Append(@"		@ApplicationId) ");


                _RuleInCategory_i = sb.ToString();
            }


        }
        static void SetCategory_i()
        {

            if (string.IsNullOrEmpty(_Category_i ))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);
     
                sb.Append(@"	INSERT INTO aspnet_RulesCategory");
                sb.Append(@"		(ParentCategoryId");
                sb.Append(@"		,[Name]");
                sb.Append(@"		,ApplicationId)");
        
                sb.Append(@"	VALUES (");
                sb.Append(@"		[ParentCategoryId],");
                sb.Append(@"		'[CategoryName]',");
                sb.Append(@"		@ApplicationId) select @@IDENTITY");


                _Category_i = sb.ToString();
            }


        }

        static void SetApplicationId()
        {
            if (string.IsNullOrEmpty(_ApplicationId_s))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);
                sb.Append(@"DECLARE @ApplicationId uniqueidentifier ");
                sb.Append(@"    SELECT  @ApplicationId = NULL ");
                sb.Append(@"    SELECT  @ApplicationId = ApplicationId  ");
                sb.Append(@"    FROM aspnet_Applications WHERE LOWER('[ApplicationName]') = LoweredApplicationName ");
                //sb.Append(@"    IF (@ApplicationId IS NULL) ");
                //sb.Append(@"        RETURN(0) ");
                _ApplicationId_s = sb.ToString();
            }

        }
    }
}
