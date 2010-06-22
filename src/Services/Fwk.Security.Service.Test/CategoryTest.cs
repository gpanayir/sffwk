using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fwk.Security.ISVC.CreateRulesCategory;

using  Fwk.Security.ISVC.SearchAllRulesCategory;
using Fwk.Security.ISVC;
using Fwk.Security.BE;

using Fwk.Security.ISVC.SearchRulesCategoryByParam;
using Fwk.Security;
using Fwk.Security.SVC;
using Fwk.Bases.Test;
using Fwk.Transaction;
using Fwk.Security.ISVC.UpdateRulesCategory;
using Fwk.Security.ISVC.DeleteRulesCategory;

namespace Security
{
    /// <summary>
    /// Summary description for GroupsTest
    /// </summary>
    [TestClass]
    public class CategoryTest : UnitTestBase
    {
        public CategoryTest()
        {
           
        }

        [TestMethod]
        public void RulesCategory_Test_CRUD_No_Service()
        {
            base.Tx = new TransactionScopeHandler(TransactionalBehaviour.Suppres, IsolationLevel.ReadCommitted, new TimeSpan(0, 0, 15));

            base.Tx.InitScope();
            int? id = CreateRulesCategory_No_Service();
            if (id != null)
                UpdateRulesCategory_No_Service(id.Value);
            if (id != null)
                DeleteRulesCategory_No_Service(id.Value);
            base.Tx.Abort();

        }

        //[TestMethod]
        public int? CreateRulesCategory_No_Service()
        {
           
            String strErrorResut = String.Empty;
            CreateRulesCategoryService svc = new CreateRulesCategoryService();
            CreateRulesCategoryReq req = new CreateRulesCategoryReq();
            CreateRulesCategoryRes res = new Fwk.Security.ISVC.CreateRulesCategory.CreateRulesCategoryRes();


            req.BusinessData.Name = "Categorytest_1";
            req.BusinessData.ParentId = 0;
            req.BusinessData.FwkRulesInCategoryList = new FwkAuthorizationRuleList();
            req.BusinessData.FwkRulesInCategoryList.Add(new FwkAuthorizationRule ("Rule_1",""));
            req.BusinessData.FwkRulesInCategoryList.Add(new FwkAuthorizationRule("Rule_2", ""));
            req.BusinessData.FwkRulesInCategoryList.Add(new FwkAuthorizationRule("Rule_3", ""));
            


            try
            {
                res = svc.Execute(req);
                return res.BusinessData.Id;
                //base.Tx.Abort();

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
                return null;
            }




        }

        //[TestMethod]
        public void UpdateRulesCategory_No_Service(int id)
        {
            //base.Tx = new TransactionScopeHandler(TransactionalBehaviour.Suppres, IsolationLevel.ReadCommitted, new TimeSpan(0, 0, 15));
        
            String strErrorResut = String.Empty;
            UpdateRulesCategoryService svc = new UpdateRulesCategoryService();
            UpdateRulesCategoryReq req = new UpdateRulesCategoryReq();
            UpdateRulesCategoryRes res = new UpdateRulesCategoryRes();

            req.BusinessData.CategoryId = id;
            req.BusinessData.Name = "Categorytest_1";
            req.BusinessData.ParentId = 0;
            req.BusinessData.FwkRulesInCategoryList = new FwkAuthorizationRuleList();
            req.BusinessData.FwkRulesInCategoryList.Add(new FwkAuthorizationRule("Rule_1", ""));
            req.BusinessData.FwkRulesInCategoryList.Add(new FwkAuthorizationRule("Rule_3", ""));
            req.BusinessData.FwkRulesInCategoryList.Add(new FwkAuthorizationRule("Rule_4", ""));

            //base.Tx.InitScope();

            // se llama al servicio
            res = svc.Execute(req);

            try
            {
                res = svc.Execute(req);
                //base.Tx.Abort();

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);


        }


        //[TestMethod]
        public void DeleteRulesCategory_No_Service(int id)
        {
            //base.Tx = new TransactionScopeHandler(TransactionalBehaviour.Suppres, IsolationLevel.ReadCommitted, new TimeSpan(0, 0, 15));
           
            String strErrorResut = String.Empty;
            DeleteRulesCategoryService svc = new DeleteRulesCategoryService();
            DeleteRulesCategoryReq req = new DeleteRulesCategoryReq();
            DeleteRulesCategoryRes res = new DeleteRulesCategoryRes();

            req.BusinessData.CategoryId = id;
            //base.Tx.InitScope();

            try
            {
                res = svc.Execute(req);
                base.Tx.Abort();
            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);


        }

        [TestMethod]
        public void SearchAllRulesCategory_No_Service()
        {
            String strErrorResut = String.Empty;

            SearchAllRulesCategoryReq wReq = new SearchAllRulesCategoryReq();
            SearchAllRulesCategoryRes wRes;
            SearchAllRulesCategoryService svc = new SearchAllRulesCategoryService();


            try
            {

                wRes = wReq.ExecuteService<SearchAllRulesCategoryReq, SearchAllRulesCategoryRes>(wReq);

            }
            catch (Exception ex)
            {
                strErrorResut = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


            Assert.AreEqual<String>(strErrorResut, string.Empty, strErrorResut);



        }

        [TestMethod]
        public void SearchRulesCategoryByParam_No_Service()
        {
            
            String strErrorResut = String.Empty;
        
            //SearchRulesCategoryByParamReq wReq = new SearchRulesCategoryByParamReq();
            //SearchRulesCategoryByParamRes wRes = new SearchRulesCategoryByParamRes();


            //wReq.BusinessData.CategoryId = 3;

            //// se llama al servicio
            //wRes = wReq.ExecuteService<Fwk.Security.ISVC.SearchRulesCategoryByParam.SearchRulesCategoryByParamReq, Fwk.Security.ISVC.SearchRulesCategoryByParam.SearchRulesCategoryByParamRes>(wReq);


            //if (wRes.Error != null)
            //{
            //    if (typeof(Fwk.Exceptions.FunctionalException).Name.CompareTo(wRes.Error.Type) != 0)
            //    {
            //        strErrorResut =Fwk.Exceptions.ExceptionHelper.ProcessException(wRes.Error).Message;
            //    }
            //    else
            //    {
            //        wRes.Error = null;
            //    }
            //}

            Assert.AreEqual<Fwk.Exceptions.ServiceError>(null, null, strErrorResut);

        }
           
   
       
    }
}
