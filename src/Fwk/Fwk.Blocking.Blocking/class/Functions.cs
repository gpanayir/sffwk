using System.Diagnostics;
using System.Data;
using System.Text;
using System;
using Fwk.Exceptions;

namespace Fwk.Blocking
{
	public class BlockingHelper
	{
		public static void WriteLog(string pLog, EventLogEntryType pType)
		{
            EventLog.WriteEntry("Fwk.Blocking", pLog, pType);
		}

      

        public static void CheckAndReleaseBlocking(BlockingEngineBase pBlockingEngineBase, Guid pGUID)
        {
            if (!pBlockingEngineBase.Exists(pGUID, null))
            {
                throw new BlockingFunctionalException("BlockingExpiro");
            }

            pBlockingEngineBase.Remove(pGUID);
        }
	} 
}
