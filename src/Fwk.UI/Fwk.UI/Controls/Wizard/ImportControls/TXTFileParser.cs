using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using FileHelpers;

namespace Fwk.UI.Controls.ImportControls
{
    public class TXTFileParser : IFileParser<TXTFileDescriptor>
    {
        #region [Fields]

        private ProgressMode _ProgressMode;

        #endregion

        #region [Properties]

        public ProgressMode ProgressMode
        {
            get
            {
                return _ProgressMode;
            }
            set
            {
                value = _ProgressMode;
            }
        }

        #endregion

        public event ProgressChangeHandler ProgressChanged;

        public void OnProgressChanged(ProgressEventArgs e)
        {
            if (ProgressChanged != null)
                ProgressChanged(this, e);
        }

        #region [Constructor]
        public TXTFileParser()
        {
            _ProgressMode = ProgressMode.InPercentage;
        }
        #endregion

        #region [Private Methods]
        private void ProgressChange(FileHelpers.ProgressEventArgs e)
        {
            ProgressEventArgs progress = new ProgressEventArgs(e.ProgressCurrent, e.ProgressTotal);
            OnProgressChanged(progress);
        }
        #endregion


        #region IRecordSetFileParser<RecordSetCsvFileDescriptor> Members

        public DataTable ParseStream(TextReader pStream, TXTFileDescriptor pFileDescriptor)
        {
            return ParseStream(pStream, pFileDescriptor, 0);
        }

        public DataTable ParseStream(TextReader pStream, TXTFileDescriptor pFileDescriptor, int pRowsQuantity)
        {
            if (pFileDescriptor == null)
                throw new ArgumentNullException();

            if (pFileDescriptor.Columns.Count == 0)
                throw new ArgumentException("El descriptor del archivo no posee ninguna columna.");

           // FixedRecordOptions wTxtOptions;

            FileHelpers.RunTime.FixedLengthClassBuilder wClassBuilder = new FileHelpers.RunTime.FixedLengthClassBuilder("fileClass", FixedMode.AllowVariableLength);

            for (int x = 0; x < pFileDescriptor.Columns.Count; x++)
            {
                wClassBuilder.AddField(pFileDescriptor.Columns[x].Name, pFileDescriptor.Columns[x].Length, typeof(string).Name);
                wClassBuilder.LastField.TrimMode = TrimMode.Both;
            }

            FixedFileEngine wTxtEngine = new FixedFileEngine(wClassBuilder.CreateRecordClass());

            FileHelpers.ProgressMode wProgressMode = FileHelpers.ProgressMode.NotifyBytes;

            switch (_ProgressMode)
            {
                case ProgressMode.InPercentage:
                    wProgressMode = FileHelpers.ProgressMode.NotifyPercent;
                    break;

                case ProgressMode.InRecordsNumber:
                    wProgressMode = FileHelpers.ProgressMode.NotifyRecords;
                    break;
            }

            wTxtEngine.SetProgressHandler(new FileHelpers.ProgressChangeHandler(ProgressChange), wProgressMode);

            DataTable wDt;

            if (pRowsQuantity == 0)
                wDt = wTxtEngine.ReadStreamAsDT(pStream);
            else
                wDt = wTxtEngine.ReadStreamAsDT(pStream, pRowsQuantity);

            return wDt;
        }

        public DataTable ParseFile(string pFilePath, TXTFileDescriptor pFileDescriptor)
        {
            return ParseFile(pFilePath, pFileDescriptor, 0);
        }

        public DataTable ParseFile(string pFilePath, TXTFileDescriptor pFileDescriptor, int pRowsQuantity)
        {
            FileInfo wFileInfo = new FileInfo(pFilePath);

            if (!wFileInfo.Exists)
                throw new FileNotFoundException("El archivo TXT no existe.");

            using (StreamReader wReader = new StreamReader(pFilePath, true))
            {
                if (pRowsQuantity == 0)
                    return ParseStream(wReader, pFileDescriptor);

                return ParseStream(wReader, pFileDescriptor, pRowsQuantity);
            }
        }

        #endregion
    }

}
