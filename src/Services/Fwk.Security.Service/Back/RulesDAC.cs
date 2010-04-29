
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Prominente Code Generator.
//     Runtime Version:1.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Fwk.Bases;
using Fwk.Exceptions;
using Fwk.Security;
using Fwk.Security.BE;



namespace Fwk.Security.DAC
{
    public class RulesDAC : Fwk.Bases.BaseDAC
    {
        #region [Rules]

        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="paspnet_RulesBE">aspnet_RulesBE</param>
        /// <returns>void</returns>
        /// <Date>2009-11-12</Date>
        /// <Author>moviedo(modif de orig)</Author>
        public static void Insert(RulesBE pRulesBE, String pApplicationName)
        {
            try
            {
                // Nuevo objeto rules
                FwkAuthorizationRule wRules = new FwkAuthorizationRule { Name = pRulesBE.Name, Expression = pRulesBE.expression };
                // Se crea una nueva regla
                FwkMembership.CreateRule(wRules, pApplicationName);
            }
            catch (Exception ex)
            {
              throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        ///<param name="paspnet_RulesBE">aspnet_RulesBE</param>
        /// <returns>void</returns>
        /// <Date>2009-11-12</Date>
        /// <Author>moviedo(modif de orig)</Author>
        public static void Update(RulesBE pRulesBE, string pApplicationName)
        {

            try
            {
                Fwk.Security.aspnet_Rule waspnet_Rule = new aspnet_Rule();
                waspnet_Rule.name = pRulesBE.Name;
                waspnet_Rule.expression = pRulesBE.expression;
                FwkMembership.UpdateRule(waspnet_Rule,pApplicationName);
            }
            catch (Exception ex)
            {
              throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }


        /// <summary>
        /// Delete
        /// </summary>
        /// <returns>void</returns>
        /// <Date>2009-07-14T11:36:00</Date>
        /// <Author>AAguirre</Author>
        public static void Delete(RulesBE pRulesBE)
        {

        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns>DataSet</returns>
        /// <Date>2009-07-14T11:36:00</Date>
        /// <Author>AAguirre</Author>
        public static void GetAll()
        {

        }
            

        #endregion

        #region [RulesInCategory]]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pCategoryId"></param>
        /// <param name="pApplicationName"></param>
        internal static void InsertRulesInCategory(string pName, int pCategoryId, String pApplicationName)
        {
           
            FwkCategory wFwkCategory = new FwkCategory();
            wFwkCategory.Name = pName;
            wFwkCategory.CategoryId = pCategoryId;

            try
            {
                FwkMembership.CreateRuleInCategory(wFwkCategory, pApplicationName);

            }
            catch (Exception ex)
            {
              throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        




        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRuleName"></param>
        /// <param name="pCompanyId"></param>
        /// <returns></returns>
        internal static Object ExistRulesInCategory(string pRuleName, string pCompanyId)
        {
            Database database = null;
            DbCommand cmd = null;
            String wQuery = "SELECT CategoryId FROM dbo.aspnet_RulesInCategory WHERE RuleName = @RuleName";
            Object wCategoryId = null;

          

            try
            {
                database = DatabaseFactory.CreateDatabase(pCompanyId);
                cmd = database.GetSqlStringCommand(wQuery);
                //In Parameters
                database.AddInParameter(cmd, "@RuleName", DbType.String, pRuleName);

                wCategoryId = database.ExecuteScalar(cmd);

            }
            catch (Exception ex)
            {
              throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }

            return wCategoryId;
        }
    }
}