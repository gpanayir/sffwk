using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;


namespace ConfigurationApp.Common
{
    public class WorkSpace
    {
        
        private Dictionary<ConfigurationType, Fwk.Controls.Win32.DockContent> _GeneratorsList = new Dictionary<ConfigurationType, Fwk.Controls.Win32.DockContent>();

        internal void Add(Fwk.Controls.Win32.DockContent frm, ConfigurationType pGeneratorsType)
        {
            if (!_GeneratorsList.ContainsKey(pGeneratorsType))
            {
                _GeneratorsList.Add(pGeneratorsType, frm);

            }
        }
        internal void Remove(ConfigurationType pConfigurationType)
        {
            if (_GeneratorsList.ContainsKey(pConfigurationType))
            {
                _GeneratorsList.Remove(pConfigurationType);
            }
        }

        internal Boolean Contains(ConfigurationType pConfigurationType)
        {
            return _GeneratorsList.ContainsKey(pConfigurationType);
        }

    }
}
