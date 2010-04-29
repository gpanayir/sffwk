using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;

using Fwk.Security.ISVC.CreateUsersBatch;
using Fwk.Security.BC;

namespace Fwk.Security.SVC
{
    public class CreateUsersBatchService : BusinessService<CreateUsersBatchRequest, CreateUsersBatchResponse>
    {
        public override CreateUsersBatchResponse Execute(CreateUsersBatchRequest pServiceRequest)
        {
            DataTable wImportedErrorsTable;
            DataTable wImportedRepeatedTable;

            Int32 wTotalSuccefull; //cantidad de usuarios importados
            Int32 wTotalErrors; //cantidad de usuarios fallidos
            Int32 wTotalRepeated; //usuarios que se encontraban repetidos
            

            CreateUsersBatchResponse wRes = new CreateUsersBatchResponse();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);

            

            wUserBC.Create(pServiceRequest.BusinessData.DataToImport,
                pServiceRequest.BusinessData.ServerName,
                pServiceRequest.BusinessData.DataBaseName,
                pServiceRequest.BusinessData.MappingList,
                pServiceRequest.BusinessData.ImportFromDB,
                out wImportedErrorsTable,
                out wImportedRepeatedTable,
                out wTotalSuccefull,
                out wTotalErrors,
                out wTotalRepeated);


             wRes.BusinessData.ImportedErrors = wTotalErrors;
             wRes.BusinessData.ImportedRepeated = wTotalRepeated;
             wRes.BusinessData.ImportedErrorsTable = wImportedErrorsTable;


            return wRes;
        }
    }
}
