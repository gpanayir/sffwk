﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Fwk.Bases.Connector
{
    /// <summary>
    ///WCF Wrapper que utiliza WsHttpBinding por defecto
    ///binding.Security.Mode = SecurityMode.Message
    /// </summary>
    public class WCFRrapper_WsHttpBinding : WCFRrapperBase<WSHttpBinding>
    {
        /// <summary>
        /// 
        /// </summary>
        public override  void InitilaizeBinding()
        {
            if (binding == null)
            {
            
                //El tamaño de los mensajes que se pueden recibir durante la conexión a los servicios mediante BasicHttpBinding
                this.binding = new WSHttpBinding();

                //binding.Security.Mode = SecurityMode.Message;
                //binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;


                this.binding.Name = "iis";
                //binding.MaxReceivedMessageSize *= factorSize;

                //Para que no tire error 
                // Error in deserializing body of reply message for operation 'ProcessClientRequest'. 
                // The maximum string content length quota (8192) has been exceeded while reading XML data. 

                binding.MaxReceivedMessageSize *= factorSize;
                binding.MaxBufferPoolSize *= factorSize;
                binding.ReaderQuotas.MaxDepth = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxNameTableCharCount = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxStringContentLength = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;
                binding.ReaderQuotas.MaxBytesPerRead = System.Int32.MaxValue;
                address = new EndpointAddress(this.SourceInfo);
            }
            
        }

    }
}
