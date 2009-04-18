using System;

namespace Fwk.Bases
{
	/// <summary>
    /// Esta clace almacena el valor y nombre de una propiedad
	/// </summary>
	[Serializable]
	public class PropertyValue
	{
		private string PropName;
		private object PropVal;

		public PropertyValue(string propName, object propVal)
		{
			PropName = propName;
			PropVal = propVal;
		}
		public string PropertyName
		{
			get
			{
				return PropName;
			}
			set
			{
				PropName = value;
			}
		}
		public object Value
		{
			get
			{
				return PropVal;
			}
			set
			{
				PropVal = value;
			}
		}
	}
}
