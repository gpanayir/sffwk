using System;
using System.Diagnostics;
using System.Threading;
using System.Web;
using System.Xml;
using System.Text;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Common = Fwk.Configuration.Common;
using ConfigurationResponse = Fwk.Configuration.Common.ConfigurationResponse;


/// <summary>
/// Summary description for ConfigurationService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ConfigurationService : System.Web.Services.WebService
{

	public ConfigurationService()
	{

		//Uncomment the following line if using designed components 
		//InitializeComponent(); 
	}


	[WebMethod]
	public Int32 GetFileVersionStatus(string pFileName, string pClientVersion)
	{
		try
		{

			Common.FileVersionStatus wFileVersionStatus = Common.FileVersionStatus.Ok;

			XmlElement wCatalogEntry = this.GetCatalogEntry(pFileName);
			if (Common.Utils.GetChildNodeText(wCatalogEntry, "CurrentVersion") != pClientVersion)
			{
				if (Convert.ToBoolean(Common.Utils.GetChildNodeText(wCatalogEntry, "ForceUpdate")))
				{
					wFileVersionStatus = Common.FileVersionStatus.RequiredUpdate;
				}
				else
				{
					wFileVersionStatus = Common.FileVersionStatus.OptionalUpdate;
				}
			}

			return (Int32)wFileVersionStatus;
			 
		}
		catch (SoapException soex)
		{
			throw soex;
		}
	}


	[WebMethod]
	public string GetConfig(string pFileName)
	{
		try
		{
			XmlElement wCatalogEntry = this.GetCatalogEntry(pFileName);

            if (!Convert.ToBoolean(Common.Utils.GetChildNodeText(wCatalogEntry, "Available")))
			{
				throw new Exception("El archivo de configuración solicitado no está disponible.");
			}

            return Common.Utils.GetConfig(pFileName, Server.MapPath(@"~/ConfigurationFiles/" + pFileName), wCatalogEntry);

            //System.IO.StreamReader wReader = new System.IO.StreamReader(Server.MapPath(@"~/ConfigurationFiles/" + pFileName));
            //string wFileContent = wReader.ReadToEnd();
            //wReader.Close();

            //if (Convert.ToBoolean(this.GetChildNodeText(wCatalogEntry, "Encrypt")))
            //{
            //    wFileContent = Common.Utils.Encrypt(wFileContent);
            //}

            //ConfigurationResponse.Result wResult = new ConfigurationResponse.Result();
            //wResult.FileName = pFileName;
            //wResult.FileContent = wFileContent;
            //wResult.TTL = Convert.ToInt32(Common.Utils.GetChildNodeText(wCatalogEntry, "TTL"));
            //wResult.Encrypted = Convert.ToBoolean(Common.Utils.GetChildNodeText(wCatalogEntry, "Encrypt"));
            //wResult.ForceUpdate = Convert.ToBoolean(Common.Utils.GetChildNodeText(wCatalogEntry, "ForceUpdate"));
            //wResult.CurrentVersion = this.GetChildNodeText(wCatalogEntry, "CurrentVersion");
            //wResult.BaseConfigFile = Convert.ToBoolean(Common.Utils.GetChildNodeText(wCatalogEntry, "BaseConfigFile"));
            //wResult.Cacheable = Convert.ToBoolean(Common.Utils.GetChildNodeText(wCatalogEntry, "Cacheable"));

            //string wXml = Common.Utils.Serialize(wResult);

            //wReader = null;
            //wResult = null;
            //wCatalogEntry = null;

           

		}
		catch (SoapException soex)
		{
			throw soex;
		}

	}

	private XmlElement GetCatalogEntry(string pFileName)
	{
		XmlDocument wDoc = new XmlDocument();
		wDoc.Load(Server.MapPath("~/ConfigurationFiles/Catalog.xml"));

		StringBuilder sbXPath = new StringBuilder("CatalogEntry[@name='");
		sbXPath.Append(pFileName);
		sbXPath.Append("']");
		XmlElement wNode = (XmlElement)wDoc.DocumentElement.SelectSingleNode(sbXPath.ToString());

		wDoc = null;
		sbXPath = null;

		return wNode;
	}

	
}

