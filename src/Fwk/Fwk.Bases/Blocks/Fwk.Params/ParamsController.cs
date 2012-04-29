using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Params.Isvc.CreateParam;
using Fwk.Params.Isvc.SearchParams;
using Fwk.Params.Isvc.DeleteParam;
using Fwk.Params.BE;


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
        /// <param name="wrapperProviderName">Proveedor que espesifica el despachador de servicios</param>
        /// <param name="paramTypeId"></param>
        /// <param name="parentId"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns>Lista de registros de la tabla param</returns>
        public static ParamList SearchParams(string wrapperProviderName,int? paramTypeId, int? parentId, string userId, string companyId)
        {
            SearchParamsReq req = new SearchParamsReq();
            req.BusinessData.ParamTypeId = paramTypeId;
            req.BusinessData.ParentId = parentId;
            req.BusinessData.Enabled = true;
            req.ContextInformation.UserId = userId;
            req.ContextInformation.CompanyId = companyId;

            SearchParamsRes res = req.ExecuteService<SearchParamsReq, SearchParamsRes>(wrapperProviderName,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
            return res.BusinessData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrapperProviderName">Proveedor que espesifica el despachador de servicios</param>
        /// <param name="paramId"></param>
        /// <param name="parentId"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        public static void DeleteParam(string wrapperProviderName,int? paramId,int? parentId, string userId, string companyId)
        {
            DeleteParamReq req = new DeleteParamReq();
            req.BusinessData.ParamId = paramId;
            req.BusinessData.ParentId = parentId;
            req.ContextInformation.UserId = userId;
            req.ContextInformation.CompanyId = companyId;

            DeleteParamRes res = req.ExecuteService<DeleteParamReq, DeleteParamRes>(wrapperProviderName,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wrapperProviderName">Proveedor que espesifica el despachador de servicios</param>
        /// <param name="pParam"></param>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        internal static void CreateParam(string wrapperProviderName,ParamBE pParam, string companyId)
        {
            CreateParamReq req = new CreateParamReq();
            req.BusinessData = pParam;
            req.ContextInformation.UserId = pParam.UserId.ToString();
            req.ContextInformation.CompanyId = companyId;

            CreateParamRes res = req.ExecuteService<CreateParamReq, CreateParamRes>(wrapperProviderName,req);

            if (res.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);
        }
    }
}
