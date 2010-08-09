using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Fwk.BusinessFacades;
using Fwk.Bases;


/// <summary>
/// Provee acceso a los services de negocio.
/// </summary>
/// <remarks>
/// Esta intefaz de servicio es capaz de ejecutar todos los servicios de negocio. No se requiere la instanciacion de otras interfaces de servicio.
/// </remarks>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class SingleService : System.Web.Services.WebService
{

	public SingleService()
	{

		//Uncomment the following line if using designed components 
		//InitializeComponent(); 
	}

	/// <summary>
	/// Ejecuta un service de negocio.
	/// </summary>
	/// <param name="pServiceName">Nombre del service.</param>
	/// <param name="pData">XML con datos de entrada para la ejecución del servicio.</param>
    /// <returns>XML con datos de salida del servicio.</returns>
	[WebMethod]
	public string ExecuteService(string pServiceName, string pData)
	{
        
		SimpleFacade wSimpleFacade = new SimpleFacade();
        string wResult = wSimpleFacade.ExecuteService(pServiceName, pData);
		return wResult;
	}
    [SoapDocumentMethod(OneWay = true)]
    [WebMethod]
    public void ExecuteService_OneWay(string pServiceName, string pData)
    {

        SimpleFacade wSimpleFacade = new SimpleFacade();
        wSimpleFacade.ExecuteService(pServiceName, pData);

    }
    /// <summary>
    /// Ejecuta un service de negocio.
    /// </summary>
    /// <param name="ServiceName">Nombre del service.</param>
    /// <returns>Detalle informativo del servicio.</returns>
    [WebMethod]
    public string GetServiceConfiguration(string ServiceName)
    {
        SimpleFacade wSimpleFacade = new SimpleFacade();
        return wSimpleFacade.GetServiceConfiguration(ServiceName);
    }

    /// <summary>
    ///  Lista los servicios configurados
    /// </summary>
    /// <param name="ViewAsXml">Permite ver como xml todos los servicios y sus datos.
    /// Si se espesifuca false solo se vera una simple lista</param>
    /// <returns>Lista de servicios configurados</returns>
    [WebMethod]
    public string GetServicesList(Boolean ViewAsXml)
    {

        SimpleFacade wSimpleFacade = new SimpleFacade();
        return wSimpleFacade.GetServicesList(ViewAsXml);

    }
   
    /// <summary>
    /// Actualiza la configuración de un servicio de negocio.
    /// </summary>
    /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
    /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
    /// <date>2006-02-10T00:00:00</date>
    /// <author>moviedo</author>
    [WebMethod]
    public void SetServiceConfiguration(String pServiceName, ServiceConfiguration pServiceConfiguration)
    {
        SimpleFacade wSimpleFacade = new SimpleFacade();
        wSimpleFacade.SetServiceConfiguration(pServiceName,pServiceConfiguration);
        wSimpleFacade = null;
    }

    /// <summary>
    /// Almacena la configuración de un nuevo servicio de negocio.
    /// </summary>
    /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
    /// <date>2006-02-13T00:00:00</date>
    /// <author>moviedo</author>
    [WebMethod]
    public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
    {
        SimpleFacade wSimpleFacade = new SimpleFacade();
        wSimpleFacade.AddServiceConfiguration(pServiceConfiguration);
        wSimpleFacade = null;
    }

    /// <summary>
    /// Elimina la configuración de un servicio de negocio.
    /// </summary>
    /// <param name="pServiceName">Nombre del servicio.</param>
    /// <date>2006-02-13T00:00:00</date>
    /// <author>moviedo</author>
    [WebMethod]
    public void DeleteServiceConfiguration(string pServiceName)
    {
        SimpleFacade wSimpleFacade = new SimpleFacade();
        wSimpleFacade.DeleteServiceConfiguration(pServiceName);
        wSimpleFacade = null;
    }
}

