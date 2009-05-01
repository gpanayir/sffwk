namespace Fwk.Blocking
{
	/// <summary>
	/// Marca de bloqueo para un registro de una tabla.-
	/// </summary>
    public class FwkBlockingEngine : BlockingEngineBase
	{
		
      
        public FwkBlockingEngine(): base("BlockingMarks") { }







        protected override System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> GetCustomParametersToInsert(IBlockingMark pBlockingMark)
        {
            return null;
        }

        protected override System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> GetCustomParametersToGetByParams(IBlockingMark pBlockingMark)
        {
            return null;
        }

        protected override System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> GetCustomParametersUserExist(IBlockingMark pBlockingMark)
        {
            return null;
        }
    }
}