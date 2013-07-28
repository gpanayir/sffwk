using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Fwk.UI.Common
{
    public delegate void ClickOkCancelHandler(object sender, DialogResult result);
    public delegate void OnActionClickHandler(ActionTypes pActionTypes);

    /// <summary>
    /// Tipos de acciones posibles en un formulario
    /// </summary>
    public enum ActionTypes
    {
        Create = 1,
        Edit = 2,
        Read = 3,
        Remove = 4
    }

    public enum ValidationStyle
    {
        NumericInt, NumericDouble, Email, Date
    }
   
    public class ControlChars
    {
        public const string CrLf = "\r\n";
        public const string NewLine = "\r\n";
        public const char Cr = (char)13;
        public const char Lf = (char)10;
        public const char Back = (char)8;
        public const char FormFeed = (char)12;
        public const char Tab = (char)9;
        public const char VerticalTab = (char)11;
        public const char NullChar = (char)0;
        public const char Quote = (char)34;
    }

    public enum GridStyleEnum
    {
        MaroonFlat = 0,
        GreenFlat = 1,
        LightBlueFlat = 2, Custom = 3
    }
    
    /// <summary>
    /// Enumeración con los
    /// tamaños posibles para un icono.
    /// </summary>
    public enum IconSize
    {

        /// <summary>
        /// 16x16 pixeles
        /// </summary>
        Small = 16,

        /// <summary>
        ///   24x24 pixeles
        /// </summary>
        Medium = 24,


        /// <summary>
        /// 32x32 pixeles
        /// </summary>
        Large = 32,


        /// <summary>
        /// 48x48 pixeles
        /// </summary>
        XtraLarge = 48


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
       
    /// <summary>
    /// Tipo de datos que alojara el text box
    /// </summary>
    public enum TextBoxTypeEnum
    {
        Nothing = 0,
        AlphaNumericNotAllowSimbols = 1,
        Numeric = 2,
        NumericDecimal = 3,
        NumericDecimalWhitchPoint = 4,
        Email = 5,
        DateTime = 9
    }

    ///// <summary>
    ///// Estado de la pregunta si es en tiempo de diseño o de ejecucion de la Survey
    ///// </summary>
    //public enum DevStatusEnum
    //{
    //    Desing = 0,
    //    Run = 1
    //}
    public enum TypesEnum
    {
        /// <summary>
        /// Tipos de Autenticación
        /// </summary>
        [Description("Fwk.Bases.AuthenticationModeEnum")]
        AuthenticationModeEnum = 100,
        [Description("Fwk.UI.DataOriginTypeEnum")]
        DataOriginTypeEnum = 200,
        [Description("Fwk.UI.FloorTypesEnum")]
        FloorTypesEnum = 300,
        [Description("Fwk.UI.TerminalIdentification")]
        TerminalIdentification = 400

    }

    /// <summary>
    /// Data origin type
    /// </summary>
    public enum DataOriginTypeEnum
    {
        /// <summary>
        /// Tipos de Origenes de Datos
        /// </summary>
        [Description("Ningun Tipo")]
        None = 0,
        [Description("Archivo de texto separado por un caracter")]
        CharSeparated = 16,
        [Description("Archivo Xls")]
        Xls = 32,
        [Description("Archivo de texto plano sin separador de columnas")]
        PlainText = 48,
        [Description("Datos almacenados en una base de datos")]
        DataBase = 64
    }  

    /// <summary>
    /// Tipos de pisos
    /// </summary>
    public enum FloorTypesEnum
    {
        [Description("Piso")]
        P = 0,
        [Description("Entre Piso")]
        ENTREPISO = 16,
        [Description("Subsuelo")]
        SS = 32,
        [Description("Planta Baja")]
        PB = 48
    }

    public enum TerminalIdentification
    {
        [Description("Box")]        // Identificacion de un puesto por medio del nùmero de box en el que se ubica
        Box = 0,
        [Description("Lider")]      // Identificacion de un puesto por medio del lider que lo ocupa
        Lider = 16,
        [Description("Usuario")]    // Identificacion de un puesto por medio del usuario de windows
        Usuario = 32,
        [Description("Terminal")]   // Identificacion de un puesto por medio de un número de Terminal
        Terminal = 48,
        [Description("Otros")]      // Identificacion de un puesto por medio de otro identificador.
        Otros = 64
    }

}
