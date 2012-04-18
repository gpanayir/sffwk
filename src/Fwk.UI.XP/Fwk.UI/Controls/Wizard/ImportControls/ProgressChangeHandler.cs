using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.UI.Controls.ImportControls
{
    public delegate void ProgressChangeHandler(object source, ProgressEventArgs e);

    public class ProgressEventArgs
    {
        public int ProgressCurrent { get; private set;}
        public int ProgressTotal { get; private set;}

        public ProgressEventArgs(int currentProgress, int totalProgress)
        {
            ProgressCurrent = currentProgress;
            ProgressTotal = totalProgress;
        }

    }

    public enum ProgressMode
    {
        InPercentage,
        InRecordsNumber
    }

}
