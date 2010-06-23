using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;



using Fwk.Security.ISVC;
using Fwk.Security.BE;

using Fwk.Security.ISVC.SearchRulesCategoryByParam;
using Fwk.Security;
using Fwk.Security.SVC;
using Fwk.Bases.Test;
using Fwk.Transaction;
using Fwk.Security.ISVC.AssignRolesToUser;


namespace Fwk.Security.Service.Test
{
    /// <summary>
    /// Summary description for Roles
    /// </summary>
    [TestClass]
    public class Roles : UnitTestBase
    {
        public Roles()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [TestMethod]
        public void AssignRolesToUser_No_Service()
        {

            String strErrorResut = String.Empty;
            base.Tx = new TransactionScopeHandler(TransactionalBehaviour.RequiresNew, IsolationLevel.ReadCommitted, new TimeSpan(0, 0, 15));
            AssignRolesToUserService svc = new AssignRolesToUserService();
            AssignRolesToUserReq req = new AssignRolesToUserReq();



            base.Tx.InitScope();


            try
            {
                AssignRolesToUserRes res = svc.Execute(req);
                base.Tx.Abort();

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);

        }

    }
}
