using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiLanguageMannager
{
    public class ConfigMannagerGridList : Fwk.Bases.BaseEntities<ConfigMannagerGrid>
    { }
    [Serializable]
    public class ConfigMannagerGrid : Fwk.Bases.BaseEntity
    {
        public string Provider { get; set; }
        public string Group { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

    }
}
