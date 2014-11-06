using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Configuration;
using System.Data;
using System.Threading;
using Fwk.Exceptions;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Fwk.Blocking
{
    /// <summary>
    /// 
    /// </summary>
    /// <Auhor>moviedo</Auhor>
    public interface IBlockingEngine
    {
        int Create(IBlockingMark pIBlockingMark);
        DataTable GetByParam(IBlockingMark pBlockingMark);
        DataTable GetByParamCustom(IBlockingMark pBlockingMark);
        void Remove(Guid pGuid);
        void Remove(Int32 pBlockingId);
        List<String> ExistsUser(IBlockingMark pBlockingMark);
        Boolean Exists(Guid pGUID, Int32? pBlockingId);

    }
}


