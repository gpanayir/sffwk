using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Mail.Pop3;
using Fwk.Mail.Common;

namespace Fwk.Mail
{
     sealed class Pop3Services: ProtocolMailBase
     {
         private Pop3.Pop3 mPop3;
        
         // Singleton       
         public static readonly Pop3Services Instance = new Pop3Services();

         private Pop3Services()
         {
             mPop3 = Pop3.Pop3.Instance;
         }


         public override LoginResponseEnum Connect(string pUserMail, string pUserPassword)
        {
            LoginResponseEnum wResult;
            wResult = mPop3.Connect(Host, pUserMail, pUserPassword);

            switch (wResult)
            {
                case LoginResponseEnum.USER_ALREADY_CONNECT:
                    Status = ConnectionStatusEnum.Connected;
                    break;
                case LoginResponseEnum.LOGIN_SUCCESS:
                    Status = ConnectionStatusEnum.Connected;
                    break;               
                default:
                    Status = ConnectionStatusEnum.Disconected;
                    break;
            }

            return wResult;
        }

         public override LoginResponseEnum Disconnect()
         {
             // Se desconecta al usuario del host
             LoginResponseEnum wResult = LoginResponseEnum.DISCONNECTION_SUCCESS;
             //wResult = mPop3.Disconnect();

             //switch (wResult)
             //{
             //    case LoginResponseEnum.DISCONNECTION_FAIL:
             //        Status = ConnectionStatusEnum.Connected;
             //        break;
             //    case LoginResponseEnum.DISCONNECTION_SUCCESS:
             //        Status = ConnectionStatusEnum.Disconected;
             //        break;
             //    default:
             //        break;
             //}

             return wResult;
         }

         public override Boolean AccountValidation(string pUserMail, string pUserPassword)
         {
             try
             {
                 
                 LoginResponseEnum wResult;

                 wResult = Connect(pUserMail, pUserPassword);
                 

                 if ((wResult == LoginResponseEnum.CONNECTION_SUCCESS) || (wResult == LoginResponseEnum.LOGIN_SUCCESS))                 
                     return true;
                 
                 else
                     return false;

             }
             catch (Exception) //Error Code : 10056    el socket ya esta conectado
             {
                 return false;
             }
         }

        public override List<Message> FetchNewMessage()
        {
            throw new NotImplementedException();
        }


        public override int GetUnseen()
        {
            List<Pop3Message> wListaMsg;
            wListaMsg = mPop3.List();

            return wListaMsg.Count;
        }

       
    }
}
