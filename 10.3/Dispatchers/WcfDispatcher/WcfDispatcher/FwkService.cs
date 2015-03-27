﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;
using Fwk.Bases.Blocks.Fwk.BusinessFacades;
using System.ServiceModel.Channels;
using System.Net;
using Fwk.BusinessFacades;

namespace WcfDispatcher
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class FwkService : IFwkService
    {
        String sessionId = string.Empty;
        Fwk.BusinessFacades.SimpleFacade wSimpleFacade = new Fwk.BusinessFacades.SimpleFacade();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="serviceName"></param>
        /// <param name="jsonRequets"></param>
        /// <returns></returns>
        string IFwkService.ExecuteService(String providerName, String serviceName, String jsonRequets)
        {
            string[] computer_name = null;
            HostContext hostContext = new HostContext();
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            computer_name = Dns.GetHostEntry(endpoint.Address).HostName.Split(new Char[] { '.' });

            hostContext.HostIp = endpoint.Address;
            if (computer_name.Count() > 0)
                hostContext.HostName = computer_name[0].ToString();

            return wSimpleFacade.ExecuteServiceJson(providerName, serviceName, jsonRequets, hostContext);

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public String GetServiceConfiguration(string providerName, string serviceName)
        {
            return wSimpleFacade.GetServiceConfiguration(providerName, serviceName);
        }

        /// <summary>
        ///  Lista los servicios configurados
        /// </summary>
        ///<param name="providerName">Proveedor de metadata. Este parametro lo establece el cliente desde su configuracion de wrapper</param>
        /// <param name="ViewAsXml">Permite ver como xml todos los servicios y sus datos.
        /// Si se espesifuca false solo se vera una simple lista</param>
        /// <returns>Lista de servicios configurados</returns>
        public String GetServicesList(string providerName, bool ViewAsXml)
        {
            return wSimpleFacade.GetServicesList(providerName, ViewAsXml); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Fwk.ConfigSection.DispatcherInfo RetriveDispatcherInfo()
        {
            return wSimpleFacade.RetriveDispatcherInfo();
        }

        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        public List<String> GetAllApplicationsId(string providerName)
        {
            return wSimpleFacade.GetAllApplicationsId(providerName);
        }

        /// <summary>
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public Fwk.ConfigSection.MetadataProvider GetProviderInfo(string providerName)
        {
            return wSimpleFacade.GetProviderInfo(providerName);
        }
    }





}
