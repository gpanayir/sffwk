using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Fwk.UI.Common;

namespace Fwk.UI.Controls.ImportControls
{
    public class CharSeparatedFileDescriptor : BaseFileDescriptor
    {

        #region [Fields]

        private CharSeparatedColumns _Columns;
        private bool _HasColumnsNames;
        private char _Separator;

        #endregion

        #region [Properties]

        /// <summary>
        /// Columnas del archivo CSV
        /// </summary>
        public CharSeparatedColumns Columns
        {
            get
            {
                return _Columns;
            }
        }
        
        public bool HasColumnsNames
        {
            get
            {
                return _HasColumnsNames;
            }
            set
            {
                _HasColumnsNames = value;
            }
        }

        public char Separator
        {
            get
            {
                return _Separator;
            }
            set
            {
                _Separator = value;
            }
        }
                
        #endregion

        #region [Constructors]

        public CharSeparatedFileDescriptor()
        {
            _Columns = new CharSeparatedColumns();
            FileType = DataOriginTypeEnum.CharSeparated;
            _Separator = (char)32;
        }
        #endregion

        #region [Static Methods]

        /// <summary>
        /// Obtiene una clase RecordSetCsvFileDrescriptor, que describe el archivo
        /// CSV pasado como parámetros, el método tiene en cuenta que la primera fila
        /// contiene los nombres de las columnas del Archivo.
        /// </summary>
        /// <param name="filePath">Ruta al archivo CSV</param>
        /// <returns>RecordSetCsvFileDrescriptor que describe el archivo</returns>
        public static CharSeparatedFileDescriptor GetDescriptorFromFile(string pFilePath, char pSeparator)
        {
            return GetDescriptorFromFile(pFilePath, true, pSeparator);
        }

        /// <summary>
        /// Obtiene una clase RecordSetCsvFileDrescriptor, que el Stream
        /// pasado como parámetros, si el parametro hasColumnsNames es true, los nombres
        /// de las columnas se toman de la primera fila del archivo CSV, sino se generán automáticamente
        /// de la siguiente forma "Columna" + NroColumna. Ej: "Columna1", "Columna2", etc.
        /// </summary>
        /// <param name="filePath">Ruta para el archivo CSV</param>
        /// <param name="hasColumnsNames">Indica si el archivo tiene las columnas en la primera fila.</param>
        /// <returns>RecordSetCsvFileDrescriptor que describe el archivo</returns>
        public static CharSeparatedFileDescriptor GetDescriptorFromFile(string pFilePath, bool pHasColumnsNames, char pSeparator)
        {
            if (pFilePath == null)
                throw new ArgumentNullException();

            FileInfo wFileInfo = new FileInfo(pFilePath);

            if (!wFileInfo.Exists)
                throw new FileNotFoundException("El archivo no existe.");
            
            Stream wFileStream = new FileStream(pFilePath, FileMode.Open, FileAccess.Read);

            return GetDescriptorFromStream(wFileStream, pHasColumnsNames, pSeparator);
        }

        /// <summary>
        /// Obtiene una clase RecordSetCsvFileDrescriptor, que el Stream
        /// pasado como parámetros, el método tiene en cuenta que la primera fila
        /// contiene los nombres de las columnas del Archivo.
        /// </summary>
        /// <param name="filePath">Ruta para el archivo CSV</param>
        /// <returns>RecordSetCsvFileDrescriptor que describe el archivo</returns>
        public static CharSeparatedFileDescriptor GetDescriptorFromStream(Stream pFileStream, char pSeparator)
        {
            return GetDescriptorFromStream(pFileStream, false, pSeparator);
        }


        /// <summary>
        /// Obtiene una clase RecordSetCsvFileDrescriptor, que el Stream
        /// pasado como parámetros, si el parametro hasColumnsNames es true, los nombres
        /// de las columnas se toman de la primera fila del archivo CSV, sino se generán automáticamente
        /// de la siguiente forma "Columna" + NroColumna. Ej: "Columna1", "Columna2", etc.
        /// </summary>
        /// <param name="filePath">Ruta para el archivo CSV</param>
        /// <param name="hasColumnsNames">Indica si el archivo tiene las columnas en la primera fila.</param>
        /// <returns>RecordSetCsvFileDrescriptor que describe el archivo</returns>
        public static CharSeparatedFileDescriptor GetDescriptorFromStream(Stream pFileStream, bool pHasColumnsNames, char pSeparator)
        {
            string wLineBuffer = "";
            string[] wColumns;
            CharSeparatedFileDescriptor wFileDescriptor;
            int wIdx = 0;

            if (pFileStream == null)
                throw new ArgumentNullException();

            if (pFileStream.Length == 0)
                throw new ArgumentException("El archivo no puede estar vacio.");
            
            StreamReader wReader = new StreamReader(pFileStream, true);
            
            wLineBuffer = wReader.ReadLine();

            if(!wLineBuffer.Contains(pSeparator))
                throw new Exceptions.InvalidCharSeparatedFileException();

            wFileDescriptor = new CharSeparatedFileDescriptor();

            wColumns = wLineBuffer.Split(pSeparator);

            foreach (string wColumn in wColumns)
            {
                CharSeparatedColumn wCol = new CharSeparatedColumn();
                wFileDescriptor.Columns.Add(wCol);
                wCol.Index = wIdx;
                
                if (pHasColumnsNames)
                    wCol.Name = wColumn;
                else
                    wCol.Name = String.Format("Columna{0}", wIdx);

                wIdx++;
            }

            wFileDescriptor.FileType = DataOriginTypeEnum.CharSeparated;
            wFileDescriptor.HasColumnsNames = pHasColumnsNames;
            wFileDescriptor.Separator = pSeparator;

            return wFileDescriptor;
        }
        #endregion

        public override string[] GetColumnsNames()
        {
            string[] wColumns = new string[Columns.Count];
            
            int x=0;
            
            foreach (CharSeparatedColumn wColumn in Columns)
            {
                wColumns[x] = wColumn.Name;
                x++;
            }

            return wColumns;
        }

    }
}