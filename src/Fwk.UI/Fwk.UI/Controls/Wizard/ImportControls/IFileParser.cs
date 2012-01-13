using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace Fwk.UI.Controls.ImportControls
{
    public interface IFileParser<T> where T : BaseFileDescriptor
    {

        #region Members

        ProgressMode ProgressMode
        {
            get;
            set;
        }
        #endregion

        #region Methods

        DataTable ParseStream(TextReader stream, T fileDescriptor);
        DataTable ParseStream(TextReader stream, T fileDescriptor, int rowsQuantity);
        DataTable ParseFile(string filePath, T fileDescriptor);
        DataTable ParseFile(string filePath, T fileDescriptor, int rowsQuantity);

        #endregion

        #region [Events]
        event ProgressChangeHandler ProgressChanged;
        #endregion

    }
    
}
