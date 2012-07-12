using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;

namespace Fwk.Security.Admin
{
    public class RuleObjetoSource
    {
        private List<AuthorizationRuleData> _RuleList;
        private object _Source;

        public RuleObjetoSource(object pSource, List<AuthorizationRuleData> pRuleList)
        {
            _RuleList = pRuleList;
            _Source = pSource;
        }

        public List<AuthorizationRuleData> RuleList
        {
            get { return _RuleList; }
            set { _RuleList = value; }
        }

        public object Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

    }
}
