using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

using Fwk.DataBase;
using CodeGenerator.Back.Common;
namespace CodeGenerator
{
    public class WorkSpace
    {
        private Metadata _Metadata;
        private Dictionary<Common.GeneratorsType, CodeGenerator.FrmBase> _GeneratorsList = new Dictionary<Common.GeneratorsType, CodeGenerator.FrmBase>();

        internal void Add(CodeGenerator.FrmBase frm, Common.GeneratorsType pGeneratorsType)
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
        internal void Remove(Common.GeneratorsType pGeneratorsType)
        {
            if (_GeneratorsList.ContainsKey(pGeneratorsType))
            {
                _GeneratorsList.Remove(pGeneratorsType);
            }
        }

        internal Boolean Contains(Common.GeneratorsType pGeneratorsType)
        {
            return _GeneratorsList.ContainsKey(pGeneratorsType);
        }

    }
}
