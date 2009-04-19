using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using Fwk.Configuration.Common.ConfigurationResponse;

namespace ConfigurationApp
{
    using System;
    using System.Collections;
    using Fwk.Configuration.Common;

   
        /// <summary>
        /// Clase contenedora de archivos de configuracion y sus estados. Esta clase permite cachear en memoria las configuraciones que
        /// son requeridas por las aplicacioenes. 
        /// </summary>
        /// <Author>Marcelo Oviedo</Author>
        public class ConfigurationRepository
        {
            private Hashtable __Files;


            /// <summary>
            /// Constructor por defecto.
            /// </summary>
            public ConfigurationRepository()
            {
                __Files = new Hashtable();
            }

            /// <summary>
            /// Agrega un configuration file al hashtable.
            /// </summary>
            /// <param name="pConfigurationFile">ConfigurationFile configurado.</param>
            public void AddConfigurationFile(ConfigurationFile pConfigurationFile)
            {
                if (pConfigurationFile == null)
                {
                    throw new Exception("No hay datos para configurar.");
                }

                if (__Files.Contains(pConfigurationFile.ConfigResult.FileName))
                {
                    throw new Exception("El archivo ya se encuentra configurado");
                }

                __Files.Add(pConfigurationFile.ConfigResult.FileName, pConfigurationFile);

            }

            /// <summary>
            /// Agrega un configuration file al hashtable.
            /// </summary>
            /// <param name="pConfigurationFile">ConfigurationFile configurado.</param>
            public void RemoveConfigurationFile(ConfigurationFile pConfigurationFile)
            {
                if (pConfigurationFile == null)
                {
                    throw new Exception("ConfigurationFile no puede ser nulo.");
                }

                if (!__Files.Contains(pConfigurationFile.ConfigResult.FileName))
                {
                    throw new Exception("El archivo no existe");
                }

                __Files.Remove(pConfigurationFile.ConfigResult.FileName);
                

            }

            /// <summary>
            /// Obtiene un ConfigurationFile del hashtable.
            /// </summary>
            /// <param name="pFileName">Nombre de archivo.</param>
            /// <returns><see cref="ConfigurationFile"/></returns>
            public ConfigurationFile GetConfigurationFile(string pFileName)
            {
                return (ConfigurationFile)__Files[pFileName];
            }



        }

     

    }


