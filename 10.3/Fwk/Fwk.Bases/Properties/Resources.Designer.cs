﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fwk.Bases.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Fwk.Bases.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static System.Drawing.Bitmap cancel {
            get {
                object obj = ResourceManager.GetObject("cancel", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap copy {
            get {
                object obj = ResourceManager.GetObject("copy", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap db5 {
            get {
                object obj = ResourceManager.GetObject("db5", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap mail_16 {
            get {
                object obj = ResourceManager.GetObject("mail_16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap save {
            get {
                object obj = ResourceManager.GetObject("save", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se encuentra el archivo con la clave de encriptacion {0}, Verifique el proveedor {1}.
        /// </summary>
        internal static string security_provider_keyfile_not_found {
            get {
                return ResourceManager.GetString("security_provider_keyfile_not_found", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se encuentra configurado el proveedor de metadatos de servicios {0} en el despachador de servicios.\r\nVerifique en el cliente el atributo [serviceMetadataProviderName] del wrapper.
        /// </summary>
        internal static string ServiceManagement_MetadataProviderNotFound {
            get {
                return ResourceManager.GetString("ServiceManagement_MetadataProviderNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al inicializar la metadata de los servicios.Verifique: en el archivo de de configuracion (.config) la seccion [FwkServiceMetadata] el\r\n atributo [sourceinfo],  que la ruta y archivo de metadata sea correcta.-.
        /// </summary>
        internal static string ServiceManagement_SourceInfo_Error {
            get {
                return ResourceManager.GetString("ServiceManagement_SourceInfo_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se puede cargar el proveedor {0}, verifique si existe la seccion {1} en el archivo de configuracion..
        /// </summary>
        internal static string setting_provider_not_found {
            get {
                return ResourceManager.GetString("setting_provider_not_found", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se puede cargar la seccion {0}, verifique si existe en el archivo de configuracion..
        /// </summary>
        internal static string setting_section_not_found {
            get {
                return ResourceManager.GetString("setting_section_not_found", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error en la configuración del wrapper  {0}, esta definiendo un proveedor de metadatos de servicios 
        ///que no se puede encontrar,  verifique el atributo serviceMetadataProviderName sea igual a un nombre de proveedor 
        ///correcto y existente..
        /// </summary>
        internal static string Wrapper_ServiceMetadataProviderName_NotExist {
            get {
                return ResourceManager.GetString("Wrapper_ServiceMetadataProviderName_NotExist", resourceCulture);
            }
        }
    }
}