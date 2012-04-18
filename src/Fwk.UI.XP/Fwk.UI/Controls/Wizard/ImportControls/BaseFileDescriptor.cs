using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases.Connector.Singleservice;
using Fwk.Bases;
using Fwk.UI.Common;

namespace Fwk.UI.Controls.ImportControls
{

    public abstract class BaseFileDescriptor: Entity
    {
        #region [Fields]
        private DataOriginTypeEnum _fileType;
        #endregion

        #region [Properties]
        public DataOriginTypeEnum FileType
        {
            get
            {
                return _fileType;
            }
            set
            {
                _fileType = value;
            }
        }
        #endregion

        #region [Asbtract Methods]
        public abstract string[] GetColumnsNames();
        #endregion

    }

}
