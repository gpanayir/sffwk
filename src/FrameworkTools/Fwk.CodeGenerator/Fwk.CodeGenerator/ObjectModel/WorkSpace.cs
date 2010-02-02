using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Fwk.DataBase;
using Fwk.CodeGenerator.Common;

namespace Fwk.CodeGenerator
{
    public class WorkSpace
    {
        private Metadata _Metadata;
        private Dictionary<GeneratorsType, CodeGenerator.FrmBase> _GeneratorsList = new Dictionary<GeneratorsType, CodeGenerator.FrmBase>();

        internal void Add(CodeGenerator.FrmBase frm, GeneratorsType pGeneratorsType)
        {
            if (!_GeneratorsList.ContainsKey(pGeneratorsType))
            {
                _GeneratorsList.Add(pGeneratorsType, frm);
                if (_Metadata == null)
                    _Metadata = frm.Metadata;
                else
                    frm.Metadata = _Metadata;
            }
        }
        internal void Remove(GeneratorsType pGeneratorsType)
        {
            if (_GeneratorsList.ContainsKey(pGeneratorsType))
            {
                _GeneratorsList.Remove(pGeneratorsType);
            }
        }

        internal Boolean Contains(GeneratorsType pGeneratorsType)
        {
            return _GeneratorsList.ContainsKey(pGeneratorsType);
        }

    }
}
