using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;

using System.Web;
using VivaldiSite.DAC;


[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class wcf_service : Iwcf_service
{

    
    #region Iwcf_service Members
    
    public void SendMessage(string contactName, string message, string email, string phone, string city, string state)
    {
        //Esta funcion se puede usar porque  AspNetCompatibilityRequirementsMode.Allowed

        string ruta = HttpContext.Current.Server.MapPath("..");
        string file = System.IO.Path.Combine(ruta, "Email_contactenos.htm");
        string txt = Fwk.HelperFunctions.FileFunctions.OpenTextFile(file);
        StringBuilder BODY = new StringBuilder(txt);
        BODY.Replace("$contactName$", contactName);
        BODY.Replace("$email$", email);
        BODY.Replace("$phone$", phone);
        BODY.Replace("$city$", city);
        BODY.Replace("$state$", state);
        BODY.Replace("$message$", message);

        //string body= String.Format(txt, contactName, email, phone, city, state, message);
        
        CommonDAC.SendMail_Me(string.Concat("Mensaje de contacto de ", contactName), BODY.ToString(), email);
    }
    public String SendMessage2(string contactName, string message)
    {

        return "listo";

    }
    #endregion
}



    [ServiceContract]
    public interface Iwcf_service
    {
        
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Xml)]
        void SendMessage(string contactName,string message,string email,string phone,string city,string state);

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Xml)]
        String SendMessage2(string contactName, string message);
    }

