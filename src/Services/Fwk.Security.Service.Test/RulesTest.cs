using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Bases;
using Fwk.Security.ISVC.SearchAllRules;
using Fwk.Transaction;
using Fwk.Exceptions;
using Fwk.Security.SVC;
using Fwk.Bases.Test;
using Fwk.Security.ISVC.CreateRules;






namespace Security
{
    /// <summary>
    /// Summary description for RulesTest
    /// </summary>
    [TestClass]
    public class RulesTest : UnitTestBase
    {
     

        


        #region service test
        public void CreateRule_No_Service()
        {

            String strErrorResut = String.Empty;
            base.Tx = new TransactionScopeHandler(TransactionalBehaviour.Suppres, IsolationLevel.ReadCommitted, new TimeSpan(0, 0, 15));
            CreateRuleService svc = new CreateRuleService();
            CreateRuleReq req = new CreateRuleReq();

            req.BusinessData.Name = "rule 1";

            req.BusinessData.Expression = "(R:Admin)";


            base.Tx.InitScope();


            try
            {
                CreateRuleRes res = svc.Execute(req);
                base.Tx.Abort();

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

        }

        [TestMethod]
        public void SearchAllRulesService_No_Service()
        {
            String strErrorResut = String.Empty;

            SearchAllRulesReq req = new SearchAllRulesReq();
            SearchAllRulesRes res = new SearchAllRulesRes();
            SearchAllRulesService svc = new SearchAllRulesService();
            res.ContextInformation.CompanyId = "bigbang";
            req.SecurityProviderName = "tesa";


            try
            {

                res = svc.Execute(req);


            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);


        }
        #endregion

    }
}
