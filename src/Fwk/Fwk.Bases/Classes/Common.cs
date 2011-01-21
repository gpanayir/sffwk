using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Fwk.Bases
{
    /// <summary>
    /// 
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// 
        /// </summary>
        public static class RegExpConstants
        {
            /// <summary>
            /// 
            /// </summary>
            public static string AlphaNumericNotAllowSimbols = "[^<>#$%*+/=?^`]*";
            /// <summary>
            /// 
            /// </summary>
            public static string Numeric = "";
            /// <summary>
            /// 
            /// </summary>
            public static string NumericDecimal = "";
            /// <summary>
            /// 
            /// </summary>
            public static string NumericDecimalWhitchPoint = "";
            /// <summary>
            /// 
            /// </summary>
            public static string Email = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
        }
    }

    /// <summary>
    /// Enumeraciones utilizadas por el framework
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pSearchType"></param>
        /// <returns></returns>
        public static string GetSearchTypeValue(string pValue, SearchtypeEnum pSearchType)
        {

            switch (pSearchType)
            {
                case SearchtypeEnum.Start:
                    {
                        return string.Concat(new string[] { pValue, "%" });

                    }
                case SearchtypeEnum.Contain:
                    {
                        return string.Concat(new string[] { "%", pValue, "%" });

                    }
                case SearchtypeEnum.Finalize:
                    {
                        return string.Concat(new string[] { "%", pValue });


                    }
            }
            return pValue;
        }
    }
    /// <summary>
    /// Tipo Busqueda
    /// </summary>
    public enum SearchtypeEnum
    {
        /// <summary>
        /// Que Comience
        /// </summary>
        Start = 1,
        /// <summary>
        ///  Que contenga
        /// </summary>
        Contain = 2,
        /// <summary>
        /// Que finalice
        /// </summary>
        Finalize = 3,
        /// <summary>
        /// Igual
        /// </summary>
        Equal = 4
    }

    /// <summary>
    /// Enumeracion de Estados de una entidad
    /// util tambien  para determinar el modo en que que se visualiza el control (Edicion, creacion o eliminacion)
    /// </summary>
    public enum EntityUpdateEnum
    {
        /// <summary>
        /// 
        /// </summary>
        NEW = 0,
        /// <summary>
        /// 
        /// </summary>
        REMOVED = 1,
        /// <summary>
        /// 
        /// </summary>
        UPDATED = 2,
        /// <summary>
        /// 
        /// </summary>
        NONE = 3

    }


    /// <summary>
    /// List of possible state for an entity.
    /// </summary>
    public enum EntityState
    {
        /// <summary>
        /// Entity is unchanged
        /// </summary>
        Unchanged = 0,

        /// <summary>
        /// Entity is new
        /// </summary>
        Added = 1,

        /// <summary>
        /// Entity has been modified
        /// </summary>
        Changed = 2,

        /// <summary>
        /// Entity has been deleted
        /// </summary>
        Deleted = 3
    }

    /// <summary>
    /// Operador de compraracion 
    /// </summary>
    public enum OperatorEnum
    {
        /// <summary>
        /// 
        /// </summary>
        Equal = 0,
        /// <summary>
        /// 
        /// </summary>
        Distinct = 1,
        /// <summary>
        /// 
        /// </summary>
        Mayor = 2,
        /// <summary>
        /// 
        /// </summary>
        Minor = 3,
    }

    /// <summary>
    /// Enumeración con los iconos posibles
    /// para un MessageBox
    /// </summary>
    public enum MessageBoxIcon
    {
        None = 0,
        Error = 16,
        Question = 32,
        Exclamation = 48,
        Warning = 49,
        Information = 64

    }


    public enum AuthenticationModeEnum
    {
        [Description("Autenticación Integrada")]
        WindowsIntegrated = 0,

        [Description("Autenticación Mixta")]
        Mixed = 1,

        [Description("Huella Digital")]
        FingerPrint = 2,

        [Description("Autenticación de Windows")]
        LDAP = 3,
    }
}
