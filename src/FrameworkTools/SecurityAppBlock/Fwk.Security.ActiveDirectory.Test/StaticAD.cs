using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Security.ActiveDirectory.Test
{
    internal class StaticAD
    {
        static Fwk.Bases.SingletonFactory<ADHelper> factory = null;

        static ADHelper _ADHelper;

        internal static ADHelper ADHelper
        {
            get
            {
                return _ADHelper;
            }

        }

        internal static void LoadDomain(string pDomainName)
        {

            _ADHelper = new ADHelper( pDomainName );

        }
    }
}
