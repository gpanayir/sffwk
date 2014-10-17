using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;
using Fwk.Bases.Blocks.Fwk.BusinessFacades;
using System.ServiceModel.Channels;
using System.Net;

namespace WcfDispatcher
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class FwkService : IFwkService
    {
        String sessionId = string.Empty;
        Fwk.BusinessFacades.SimpleFacade fw = new Fwk.BusinessFacades.SimpleFacade();

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

            return fw.ExecuteServiceJson(providerName, serviceName, jsonRequets, hostContext);

        }


    }





}
