using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using System.IO;
using System.Security.Cryptography;
using Fwk.Exceptions;

namespace Fwk.Security.Cryptography
{


    /// <summary>
    /// Clase generica de encriptacion
    /// <![CDATA[SymetriCypher<T>]]>
    /// </summary>
    /// <typeparam name="T"><see cref="SymmetricAlgorithm"/></typeparam>
    public class SymetriCypher_EntLibs<T> : ISymetriCypher where T : SymmetricAlgorithm
    {
        private string keyFileName;

        public string KeyFileName
        {
            get { return keyFileName; }
            set { keyFileName = value; }
        }

        SymmetricAlgorithmProvider _SymmetricAlgorithmProvider;

        public SymmetricAlgorithmProvider AlgorithmProvider
        {
            get { return _SymmetricAlgorithmProvider; }
            set { _SymmetricAlgorithmProvider = value; }
        }


        /// <summary>
        /// Encripta una cadena de caracteres.-
        /// </summary>
        /// <param name="val">Cadena a encriptar</param>
        /// <returns>Cadena encriptada</returns>
        public string Encrypt(string val)
        {
            CreateSymmetricAlgorithmProvider();
            byte[] decryptedBin = Encoding.UTF8.GetBytes(val);
            try
            {
                return Convert.ToBase64String(_SymmetricAlgorithmProvider.Encrypt(decryptedBin));
            }

            catch (CryptographicException e)
            {
                TechnicalException te = new TechnicalException("Clave de encriptacion no es la correcta ");
                ExceptionHelper.SetTechnicalException<SymetriCypher_EntLibs<T>>(te);
                te.ErrorId = "4402";
                throw te;
            }
        }

        /// <summary>
        /// Desencripta una cadena de caracteres.-
        /// </summary>
        /// <param name="val">Cadena encriptada</param>
        /// <returns>Cadena desencriptada</returns>
        public string Dencrypt(string val)
        {
            CreateSymmetricAlgorithmProvider();
            byte[] cryptedBin = Convert.FromBase64String(val);
            try
            {
                return Encoding.UTF8.GetString(_SymmetricAlgorithmProvider.Decrypt(cryptedBin));
            }
            catch (CryptographicException)
            {
                TechnicalException te = new TechnicalException("Clave de encriptacion no es la correcta ");
                ExceptionHelper.SetTechnicalException<SymetriCypher_EntLibs<T>>(te);
                te.ErrorId = "4402";
                throw te;
            }
            catch (Exception e)
            {

                TechnicalException te = new TechnicalException("Error al intentar desencriptar", e);
                ExceptionHelper.SetTechnicalException<SymetriCypher_EntLibs<T>>(te);
                te.ErrorId = "4402";
                throw te;
            }

        }


        /// <summary>
        /// Crea una archivo que contiene la semilla de encriptacion.- En base a este archivo el proveedor de encriptacion 
        /// realizara la criptografia.
        /// Esta sobrecarga abre un dialog box de creacion de archivo.-
        /// </summary>
        public string CreateKeyFile()
        {

            keyFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_New(keyFileName, "Key Files(*.key)|*.key", false);

            return CreateKeyFile(keyFileName);


        }

        /// <summary>
        /// Crea una archivo que contiene la semilla de encriptacion.- En base a este archivo el proveedor de encriptacion 
        /// realizara la criptografia.
        /// </summary>
        /// <param name="pkeyFileName">Nombre del archivo que contrendra la semilla.-</param>
        public string CreateKeyFile(string pkeyFileName)
        {
            keyFileName = pkeyFileName;
            if (!string.IsNullOrEmpty(keyFileName))
            {

                ProtectedKey symmetricKey = KeyManager.GenerateSymmetricKey(typeof(T), DataProtectionScope.LocalMachine);
                using (FileStream keyStream = new FileStream(keyFileName, FileMode.Create))
                {
                    KeyManager.Write(keyStream, symmetricKey);
                }
            }
            return keyFileName;
        }


        void CreateSymmetricAlgorithmProvider()
        {
            if (_SymmetricAlgorithmProvider != null) return;
            TechnicalException te;
            if (string.IsNullOrEmpty(keyFileName))
            {
                keyFileName = System.Configuration.ConfigurationSettings.AppSettings["CrypKeyFile"];
            }
            if (string.IsNullOrEmpty(keyFileName))
            {
                te = new TechnicalException("La clave de encriptacion no puede ser nula");
                ExceptionHelper.SetTechnicalException<SymetriCypher_EntLibs<T>>(te);
                te.ErrorId = "4401";
                throw te;
            }

            if (!File.Exists(keyFileName))
            {
                throw new Fwk.Exceptions.TechnicalException();

                te = new TechnicalException(string.Concat("La clave de encriptacion ", keyFileName, " no existe"));
                ExceptionHelper.SetTechnicalException<SymetriCypher_EntLibs<T>>(te);
                te.ErrorId = "4401";
                throw te;

            }
            try
            {
                if (_SymmetricAlgorithmProvider == null)
                    _SymmetricAlgorithmProvider = new SymmetricAlgorithmProvider(typeof(T), keyFileName, DataProtectionScope.LocalMachine);
            }
            catch (Exception e)
            {
                te = new TechnicalException("Error al intentar crear SymmetricAlgorithmProvider ", e);
                ExceptionHelper.SetTechnicalException<SymetriCypher_EntLibs<T>>(te);
                te.ErrorId = "4400";
                throw te;
            }

        }
    }
}
