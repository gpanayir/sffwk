using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE = BigBang.Common.Survey.BE;
using SurveyISVC = BigBang.Common.Survey.ISVC;
using PredeterminateOptionalISVC = BigBang.Common.Survey.ISVC.CreatePredeterminateValue;
using Fwk.Exceptions;
using BigBang.Common;
using BigBang.Common.Survey.BE;
using Fwk.HelperFunctions;

using Fwk.HelperFunctions.Caching;
using BigBang.Common.Survey.ISVC.ContainsRecordSetAssosiated;
using BigBang.BackEnd.Common.BE;
using Fwk.Caching;
using Fwk.Bases;

namespace TestServicePerformance
{

    public class ControllerTest : Fwk.Bases.ClientServiceBase
    {
        public static FwkSimpleStorageBase<Store> Storage = new FwkSimpleStorageBase<Store>();
        /// <summary>
        /// Busca params de tipo Predeterminate Value
        /// </summary>
        /// <returns></returns>
        public ParamCampaingsList SearchPredeterminateValueTypes()
        {

            //Creo Request
            BigBang.BackEnd.Common.ISVC.SearchParamsByType.req.SearchParamsByTypeRequest req =
                new BigBang.BackEnd.Common.ISVC.SearchParamsByType.req.SearchParamsByTypeRequest();

            //Seteo parametros 
            req.BusinessData.ParamTypeId = (int)BigBang.Common.ParamsEnum.TypesEnum.PredeterminateValueType;

            req.CacheSettings.CacheOnClientSide = false;

            ///Llamo al servicio y obtengo el response
            BigBang.BackEnd.Common.ISVC.SearchParamsByType.res.SearchParamsByTypeResponse res =
                base.ExecuteService<BigBang.BackEnd.Common.ISVC.SearchParamsByType.req.SearchParamsByTypeRequest,
                                    BigBang.BackEnd.Common.ISVC.SearchParamsByType.res.SearchParamsByTypeResponse>
                                    (req);

            //Si veinen errores proceso la excepcion
            if (res.Error != null)
            {
                throw BigBang.Common.Exceptions.ProcessException(res.Error);
            }
            ParamCampaings wParamCampaings;
            ParamCampaingsList wParamCampaingsList = new ParamCampaingsList();
            foreach (BigBang.BackEnd.Common.ISVC.SearchParamsByType.res.Param wParam in res.BusinessData)
            {
                wParamCampaings = new ParamCampaings();

                wParamCampaings.ParamCapaingId = wParam.ParamId;
                wParamCampaings.Name = wParam.Name;
                wParamCampaings.Remarks = wParam.Remarks;

                wParamCampaingsList.Add(wParamCampaings);
            }


            //retorno la entidad solicitada
            return wParamCampaingsList;


        }



      
    }
}
