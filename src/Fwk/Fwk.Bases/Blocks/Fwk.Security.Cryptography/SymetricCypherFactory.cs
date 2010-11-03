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
    /// Fabrica de SymetriCypher <![CDATA[SymetriCypher<T>]]>
    /// </summary>
    public static class SymetricCypherFactory
    {
        static Dictionary<string, ISymetriCypher> list;

        /// <summary>
        /// Crea el diccionario de ISymetriCypher
        /// </summary>
        static SymetricCypherFactory()
        {
            list = new Dictionary<string, ISymetriCypher>();
        }

        /// <summary>
        /// Busca un criptographer determinado por medio de su nombre de archivo de encriptacion y tipo de algoritmo simetrico
        /// </summary>
        /// <typeparam name="T">Tipo de algoritmo simetrico</typeparam>
        /// <param name="keyFileName">nombre de archivo de encriptacion </param>
        /// <returns>Argoritmo <see cref="SymetriCypher"/></returns>
        public static SymetriCypher<T> Get<T>(string keyFileName) where T : SymmetricAlgorithm
        {
            if (string.IsNullOrEmpty(keyFileName))
            {

                TechnicalException te = new TechnicalException("La clave de encriptacion no puede ser nula");
                ExceptionHelper.SetTechnicalException<SymetriCypher<T>>(te);
                te.ErrorId = "4401";
                throw te;
            }

            SymetriCypher<T> symetriCypher = null;

            if (list.ContainsKey(string.Concat(keyFileName, typeof(T).FullName)))
                symetriCypher = (SymetriCypher<T>)list[string.Concat(keyFileName, typeof(T).FullName)];
            else
            {
                symetriCypher = new SymetriCypher<T>();
                symetriCypher.KeyFileName = keyFileName;
                list.Add(string.Concat(keyFileName, typeof(T).FullName), symetriCypher);
            }

            return symetriCypher;
        }

        /// <summary>
        /// Crea un algoritmo sin nombre de archivo de encriptacion. Este constructor es util cando se trata de un encriptador para crear archivos .key
        /// </summary>
        /// <typeparam name="T">Tipo de algoritmo simetrico</typeparam>
        /// <returns>Argoritmo <see cref="SymetriCypher"/></returns>
        public static SymetriCypher<T> Get<T>() where T : SymmetricAlgorithm
        {
               return  new SymetriCypher<T>();
        }

    }
}
