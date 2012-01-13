using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Fwk.UI.Controls.ImportControls
{
    public class TXTColumn : Entity, IDXDataErrorInfo
    {
        #region [Fields]
        private int _index;
        private string _name;
        private int _length;
        #endregion

        #region [Properties]
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
            	_name = value;
            }
        }

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
            	_length = value;
            }
        }
        #endregion

        #region IDXDataErrorInfo Members

        void IDXDataErrorInfo.GetError(ErrorInfo info)
        {
            
        }

        void IDXDataErrorInfo.GetPropertyError(string propertyName, ErrorInfo info)
        {
            switch (propertyName)
            {
                case "Length":
                    if (!IsValidLength())
                    {
                        SetErrorInfo(info, "El largo de la columna debe estar entre 1 y 250", ErrorType.Critical);
                        return;
                    }
                    break;
                case "Name":
                    if (!IsValidName())
                    {
                        SetErrorInfo(info, "El nombre de la columna debe tener al menos 1 caracter", ErrorType.Critical);
                        return;
                    }
                    break;
            }
        }

        #endregion

        private void SetErrorInfo(ErrorInfo info, string errorText, ErrorType errorType)
        {
            info.ErrorText = errorText;
            info.ErrorType = errorType;
        }

        public bool IsValid()
        {
            if (IsValidLength() && IsValidName())
            {
                return true;
            }

            return false;

        }

        public bool IsValidLength()
        {
            if (_length <= 0 || _length > 250)
            {
                return false;
            }
            
            return true;
        }

        public bool IsValidName()
        {
            if (_name == string.Empty || _name == null)
            {
                return false;
            }

            return true;
        }
    }

    public class TXTColumns : Entities<TXTColumn>
    {
    }
}
