using System;
using System.Web.Services.Protocols;

namespace Fwk.Exceptions
{
/// <summary>
/// Attribute applied to a WebMethod to indicate any 
/// exceptions should be serialized within the detail 
/// node using the <see cref="SerializedExceptionExtension"/> class.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class SerializedExceptionExtensionAttribute : SoapExtensionAttribute
{

    /// <summary>
    /// 
    /// </summary>
    public override Type ExtensionType
	{
		get
		{
			return typeof(SerializedExceptionExtension);
		}
	}

    /// <summary>
    /// 
    /// </summary>
	public override int Priority
	{
		get { return 0; }
		set {   }
	}
}
}
