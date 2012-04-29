using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Params.Isvc.SearchParams;
using Fwk.Params.Isvc.DeleteParam;
using Fwk.Params.BE;
using Fwk.Params.Isvc.CreateParam;

namespace Fwk.Params
{

    /// <summary>
    /// 
    /// </summary>
    public class ParamsController
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramTypeId"></param>
        /// <param name="parentId"></param>
        /// <param name="providerId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public static ParamList SearchParams(int? paramTypeId, int? parentId, string providerId, string companyId)
        {
            SearchParamsReq req = new SearchParamsReq();
            req.BusinessData.ParamTypeId = paramTypeId;
            req.BusinessData.ParentId = parentId;
            req.BusinessData.Enabled = true;

#if (DEBUG ==false)
            req.ContextInformation.UserId = providerId;
#endif
            req.ContextInformation.CompanyId = companyId;

            SearchParamsRes res = req.ExecuteService<SearchParamsReq, SearchParamsRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramId"></param>
        /// <param name="name"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        public static void DeleteParam(int? paramId,int? parentId, string userId, string companyId)
        {
            DeleteParamReq req = new DeleteParamReq();
            req.BusinessData.ParamId = paramId;
            req.BusinessData.ParentId = parentId;
            req.ContextInformation.UserId = userId;
            req.ContextInformation.CompanyId = companyId;

            DeleteParamRes res = req.ExecuteService<DeleteParamReq, DeleteParamRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pParam"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        internal static void CreateParam(ParamBE pParam, string userId, string companyId)
        {
            CreateParamReq req = new CreateParamReq();
            req.BusinessData = pParam;
            req.ContextInformation.UserId = userId;
            req.ContextInformation.CompanyId = companyId;

            CreateParamRes res = req.ExecuteService<CreateParamReq, CreateParamRes>(req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
        }
    }
}
