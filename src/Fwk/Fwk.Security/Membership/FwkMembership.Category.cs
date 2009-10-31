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


        public static int CreateCategory(FwkCategory pFwkCategory, string pApplicationName)
        {
            return CreateCategory(pFwkCategory, pApplicationName, ConnectionStringName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pFwkCategory"></param>
        /// <param name="pConnectionStringName"></param>
        /// <param name="pApplicationName"></param>
        public static int CreateCategory(FwkCategory pFwkCategory, string pApplicationName, string pConnectionStringName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;
            Int32 id;
            
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                StringBuilder str = FwkMembershipScripts.ApplicationId_s;
               
                str.Append(FwkMembershipScripts.Category_i);
                str.Replace("[ApplicationName]", pApplicationName.ToLower());
                if (pFwkCategory.ParentCategoryId == null) pFwkCategory.ParentCategoryId = 0;
                str.Replace("[ParentCategoryId]", pFwkCategory.ParentCategoryId.ToString());
                str.Replace("[CategoryName]", pFwkCategory.Name.ToLower());
               
                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;

                id= Convert.ToInt32( wDataBase.ExecuteScalar(wCmd));


                foreach (FwkRulesInCategory rule in pFwkCategory.FwkRulesInCategoryList)
                {
                    rule.CategoryId = id;

                    CreateRuleInCategory(rule, pApplicationName.ToLower(),pConnectionStringName);

                }



                return id;
               
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
                            wCategory.ParentCategoryId = Convert.ToInt32(reader["ParentCategoryId"]);
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

        static void CreateRuleInCategory(FwkRulesInCategory prule,string pApplicationName,string pConnectionStringName)
        {
            
            Database wDataBase = null;
            DbCommand wCmd = null;
            

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                StringBuilder str = FwkMembershipScripts.ApplicationId_s;
                str.Append(FwkMembershipScripts.RuleInCategory_i);

                str.Replace("[ApplicationName]", pApplicationName.ToLower());
                str.Replace("[CategoryId]", prule.CategoryId.ToString());
                str.Replace("[RuleName]", prule.RuleName);

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
            

                StringBuilder str = FwkMembershipScripts.ApplicationId_s;

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
        static StringBuilder _RuleInCategory_i;

        public static StringBuilder RuleInCategory_i
        {
            get
            {
                SetRuleInCategory_i();
                return FwkMembershipScripts._RuleInCategory_i;
            }

        }

        static StringBuilder _ApplicationId_s;

        public static StringBuilder ApplicationId_s
        {
            get
            {
                SetApplicationId();
                return FwkMembershipScripts._ApplicationId_s;
            }

        }
        static StringBuilder _Category_i;

        public static StringBuilder  Category_i
        {
            get
            {
                SetCategory_i();
                return _Category_i;
            }

        }
        static void SetRuleInCategory_i()
        {

            if (_RuleInCategory_i  == null)
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


                _RuleInCategory_i = sb;
            }


        }
        static void SetCategory_i()
        {

            if (_Category_i == null)
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


                _Category_i = sb;
            }


        }

        static void SetApplicationId()
        {
            if (_ApplicationId_s ==null)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);
                sb.Append(@"DECLARE @ApplicationId uniqueidentifier ");
                sb.Append(@"    SELECT  @ApplicationId = NULL ");
                sb.Append(@"    SELECT  @ApplicationId = ApplicationId  ");
                sb.Append(@"    FROM aspnet_Applications WHERE LOWER('[ApplicationName]') = LoweredApplicationName ");
                //sb.Append(@"    IF (@ApplicationId IS NULL) ");
                //sb.Append(@"        RETURN(0) ");
                _ApplicationId_s = sb;
            }

        }
    }
}
