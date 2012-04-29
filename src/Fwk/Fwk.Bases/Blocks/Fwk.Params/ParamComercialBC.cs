using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Params.Back
{
    public class ParametroBC : Fwk.Bases.BaseBC
    {

        public ParametroBC(string companyId)
            : base(companyId)
        {
 
        }
        static string used = "{0} no se puede eliminar por que esta siendo utilizado";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIdParametro"></param>
        /// <param name="name"></param>
        public void Delete(int pIdParametro , string name)
        {

            if (ParametroDAC.IsUsed(pIdParametro))
                throw new Fwk.Exceptions.FunctionalException(string.Format(used,name));

            ParametroDAC.Delete(pIdParametro);

        }
    }
}
