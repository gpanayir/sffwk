using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.UI.Common;

namespace Fwk.UI.Controls.ImportControls
{
    public class TXTFileDescriptor : BaseFileDescriptor
    {
        #region [Fields]
        private TXTColumns _columns;
        #endregion

        #region [Constructor]
        public TXTFileDescriptor()
        {
            _columns = new TXTColumns();
            FileType = DataOriginTypeEnum.PlainText;
        }
        #endregion

        #region [Properties]
        public TXTColumns Columns
        {
            get { return _columns; }
        }
        #endregion

        #region [RecordSetBaseFileDescriptor Implementation]
        public override string[] GetColumnsNames()
        {
            string[] columns = new string[Columns.Count];
            int x = 0;

            foreach (TXTColumn column in Columns)
            {
                columns[x] = column.Name;
                x++;
            }

            return columns;
        }
        #endregion
    }
}
