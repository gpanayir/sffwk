using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FileHelpers;
using System.Data;
using System.IO;
using Fwk.Exceptions;

namespace Fwk.UI.Controls.ImportControls
{
    public class CharSeparatedFileParser : IFileParser<CharSeparatedFileDescriptor>
    {
        #region [Fields]

        private ProgressMode _ProgressMode;

        #endregion

        #region IRecordSetFileParser<RecordSetCsvFileDescriptor> Members

        public event ProgressChangeHandler ProgressChanged;

        public void OnProgressChanged(ProgressEventArgs e)
        {
            if (ProgressChanged != null)
                ProgressChanged(this, e);
        }
        #endregion

        #region IRecordSetFileParser<RecordSetCsvFileDescriptor> Members

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

        #region [Constructor]
        public CharSeparatedFileParser()
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

        public DataTable ParseStream(TextReader wStream, CharSeparatedFileDescriptor wFileDescriptor)
        {
            return ParseStream(wStream, wFileDescriptor, 0);
        }

        public DataTable ParseStream(TextReader wStream, CharSeparatedFileDescriptor wFileDescriptor, int wRowsQuantity)
        {
            if (wFileDescriptor == null)
                throw new ArgumentNullException();

            if (wFileDescriptor.Columns.Count == 0)
                throw new ArgumentException("El descriptor del archivo no posee ninguna columna.");
            
            //CsvOptions wCsvOptions;

            FileHelpers.RunTime.CsvClassBuilder wClassBuilder = new FileHelpers.RunTime.CsvClassBuilder("fileClass", ';', wFileDescriptor.Columns.Count);

            for(int x=0; x< wFileDescriptor.Columns.Count;x++)
            {
                wClassBuilder.Fields[x].FieldName = wFileDescriptor.Columns[x].Name;
                wClassBuilder.Fields[x].FieldType = typeof(string).Name;
                wClassBuilder.Fields[x].TrimMode = TrimMode.Both;
            }

            try
            {
                wClassBuilder.CreateRecordClass();
            }

            catch (FileHelpers.RunTime.RunTimeCompilationException)
            {
                throw new FunctionalException(null, "ImportarColumnaInvalida", "ImportFileExceptionMessage", new String[] { });
            }

            CsvEngine wCsvEngine = new CsvEngine("fileClass", wFileDescriptor.Separator, wFileDescriptor.Columns.Count);
            
            FileHelpers.ProgressMode wProgressMode = FileHelpers.ProgressMode.NotifyBytes;
            
            switch(_ProgressMode)
            {
                case ProgressMode.InPercentage:
                    wProgressMode = FileHelpers.ProgressMode.NotifyPercent;
                    break;

                case ProgressMode.InRecordsNumber:
                    wProgressMode = FileHelpers.ProgressMode.NotifyRecords;
                    break;
            }

            wCsvEngine.SetProgressHandler(new FileHelpers.ProgressChangeHandler(ProgressChange), wProgressMode);

            if (wFileDescriptor.HasColumnsNames)
                wCsvEngine.Options.IgnoreFirstLines = 1;
            else
                wCsvEngine.Options.IgnoreFirstLines = 0;

            DataTable wDt;

            if (wRowsQuantity == 0)
                wDt = wCsvEngine.ReadStreamAsDT(wStream);
            else
                wDt = wCsvEngine.ReadStreamAsDT(wStream, wRowsQuantity);

            foreach (CharSeparatedColumn wColumn in wFileDescriptor.Columns)
            {
                wDt.Columns[wColumn.Index].ColumnName = wColumn.Name;
            }

            return wDt;
        }

        public DataTable ParseFile(string pFilePath, CharSeparatedFileDescriptor pFileDescriptor)
        {
            return ParseFile(pFilePath, pFileDescriptor, 0);
        }

        public DataTable ParseFile(string pFilePath, CharSeparatedFileDescriptor pFileDescriptor, int pRowsQuantity)
        {
            FileInfo wFileInfo = new FileInfo(pFilePath);

            if (!wFileInfo.Exists)
                throw new FileNotFoundException("El archivo no existe.");

            using (StreamReader reader = new StreamReader(pFilePath, true))
            {
                if (pRowsQuantity == 0)
                    return ParseStream(reader, pFileDescriptor);
                
                return ParseStream(reader, pFileDescriptor, pRowsQuantity);
            }
        }

        #endregion

    }
}
