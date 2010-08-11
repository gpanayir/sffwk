using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Mail;
using Fwk.Mail.Common;
using System.Diagnostics;
using System.Collections;


namespace Fwk.Mail
{
    sealed class Imaservices : ProtocolMailBase
    {
        // Singleton       
        public static readonly Imaservices Instance = null;

        static Imaservices()
        {
            Instance = new Imaservices();
        }

        public override LoginResponseEnum Connect(string pUserMail, string pUserPassword)
        {

            String wUser = pUserMail;
            String wPass = pUserPassword;
                   

            LoginResponseEnum wResult;
            // Se realiza el login al servidor, en el puerto por defecto
            wResult = Imap.Imap.Instance.Login(base.Host, wUser, wPass, base.SSL);

            if (wResult == LoginResponseEnum.LOGIN_SUCCESS)
                Status = ConnectionStatusEnum.Connected;

            if ((wResult == LoginResponseEnum.CONNECTION_FAIL) || (wResult == LoginResponseEnum.LOGIN_FAIL))
                Status = ConnectionStatusEnum.Disconected;


            return wResult;

        }

        public override LoginResponseEnum Disconnect()
        {
            LoginResponseEnum wResult;
            wResult = Imap.Imap.Instance.LogOut();

            switch (wResult)
            {
                case LoginResponseEnum.DISCONNECTION_FAIL:
                    Status = ConnectionStatusEnum.Connected;
                    break;
                case LoginResponseEnum.DISCONNECTION_SUCCESS:
                    Status = ConnectionStatusEnum.Disconected;
                    break;
                default:
                    break;
            }

            return wResult;
        }

        public override Boolean AccountValidation(string pUserMail, string pUserPassword)
        {
            try
            {
                LoginResponseEnum wResult;

                wResult = Connect(pUserMail, pUserPassword);
                Disconnect();

                if ((wResult == LoginResponseEnum.CONNECTION_SUCCESS) || (wResult == LoginResponseEnum.LOGIN_SUCCESS))
                    return true;
                else
                    return false;

            }
            catch (Exception)
            { return false; }
        }

        /// <summary>
        /// No implementado
        /// </summary>
        /// <returns></returns>
        public override List<Message> FetchNewMessage()
        {
            throw new NotImplementedException(); 
        }

        /// <summary>
        /// Obtiene la cantidad de mensajes sin leer
        /// </summary>
        /// <returns>Valor entero mayor que cero, representa la cantidad de mensajes sin leer</returns>
        public override Int32 GetUnseen()
        {
            List<String> wResponse = new List<String>();
            Int32 wUnseen = 0;

            wResponse = Imap.Imap.Instance.GetStatus();

            try
            {

                if ((wResponse.Count > 0) && Convert.ToString(wResponse[0]).Contains("unseen"))
                    if (wResponse[0].Split('(', ')').Length > 0)
                        wUnseen = Convert.ToInt32(wResponse[0].Split(' ',')')[4]);

                if (wResponse.Count < 0)
                    wUnseen = 0;
                
            }
            catch (Exception)
            {
                wUnseen = 0;
            }
        
            
            return wUnseen;

        }


    }
}
