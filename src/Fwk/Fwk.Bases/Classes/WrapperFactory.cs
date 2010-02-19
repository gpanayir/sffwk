using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.HelperFunctions;
using Fwk.Exceptions;

namespace Fwk.Bases
{
    /// <summary>
    /// Esta clace es utilizada por la clase generica Request la cual permite compartir un wrapper estatico entre 
    /// todos los request.-
    /// Cuando las llamadas a servicios es a travez de la clase request se utiliza esta clase
    /// </summary>
    internal static class WrapperFactory
    {
        /// <summary>
        /// Con un wrapper estatico evitamos la generacion de multiples instancias del wraper en el cliente atravez de las 
        /// multipoles llamadas desde la clase que implementa Request> 
        /// </summary>
        internal static IServiceWrapper Wrapper = null;

        /// <summary>
        /// Intenta levantar por reflection un objeto wrapper determinado por la configuracion en el appsetting de la aplicacion host.-
        /// </summary>
        internal static void TryCreateWrapper()
        {

            Wrapper =
                (IServiceWrapper)
                ReflectionFunctions.CreateInstance(ConfigurationsHelper.WrapperSetting);

        }

    }
}
