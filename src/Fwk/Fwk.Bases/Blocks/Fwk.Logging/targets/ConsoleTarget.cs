using System;
using System.Text;
using System.Collections.Generic;

namespace Fwk.Logging.Targets
{
    /// <summary>
    /// Destino de tipo consola.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class ConsoleTarget : Target
    {
        #region <constructor>
        /// <summary>
        /// Constructor de ConsoleTarget.
        /// </summary>
        public ConsoleTarget()
        {
            this.Type = TargetType.Console;
        }
        #endregion

        #region <public overrides>
        /// <summary>
        /// Implementación de la escritura del log del evento
        /// en consola.
        /// </summary>
        /// <param name="pEvent">Evento a loguear.</param>
        public override void Write(Event pEvent)
        {
            Console.WriteLine(pEvent.ToString());
        }
        #endregion
    }
}
