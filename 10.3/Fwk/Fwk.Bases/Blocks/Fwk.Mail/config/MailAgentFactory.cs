using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Fwk.ConfigSection
{
    /// <summary>
    /// 
    /// </summary>
    public class MailAgentFactory
    {
        static MailAgentSection _MailAgentSection;

        

        static MailAgentFactory()
        {
            try
            {
            _MailAgentSection = (MailAgentSection)System.Configuration.ConfigurationManager.GetSection("FwkMailAgentProvider") as MailAgentSection;
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te 
                    = new Fwk.Exceptions.TechnicalException("Error al intentar levantar la configuracion de mail MailAgent",ex);
                throw te;
            }
            
        }
        public static MailAgentElement GetProvider()
        {
            MailAgentElement prov = null;
            try
            {
                prov = _MailAgentSection.DefaultProvider;
                return prov;
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te
                    = new Fwk.Exceptions.TechnicalException("Error al intentar levantar la configuracion de mail MailAgent",ex);
                throw te;
            }


        }
        public static MailAgentElement GetProvider(string mailAgentProviderName)
        {
            MailAgentElement prov = null;
            try
            {
                prov = _MailAgentSection.GetProvider(mailAgentProviderName);
                return prov;
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te
                    = new Fwk.Exceptions.TechnicalException("Error al intentar levantar la configuracion de mail MailAgent",ex);
                throw te;
            }
           
        }

        public static MailAgentSection GetMailAgentSection()
        {
            return _MailAgentSection;
        }
    }
}
