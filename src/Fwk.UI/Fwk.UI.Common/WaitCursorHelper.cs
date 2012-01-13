using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fwk.UI.Common
{
    public sealed class WaitCursorHelper : IDisposable
    {
        private Control _owner;
        private Cursor _previousCursor;

        public WaitCursorHelper(Control pOwner)
        {
            _owner = pOwner;
            _previousCursor = pOwner.Cursor;
            _owner.Cursor = Cursors.WaitCursor;
        }

        void IDisposable.Dispose()
        {
            _owner.Cursor = _previousCursor;
        }
    }

   

}
