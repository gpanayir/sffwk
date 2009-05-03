

using System;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.ComponentModel;

namespace Fwk.Configuration.Common.ConfigurationResponse
{

	public struct Declarations
	{
		public const string SchemaVersion = "http://tempuri.org/ConfigurationResponse.xsd";
	}

	[XmlRoot(ElementName="Result",Namespace=Declarations.SchemaVersion,IsNullable=false),Serializable]
	public class Result
	{

		[XmlElement(ElementName="FileName",IsNullable=true,Form=XmlSchemaForm.Unqualified,DataType="string",Namespace=Declarations.SchemaVersion)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public string __FileName;
		
		[XmlIgnore]
		public string FileName
		{ 
			get { return __FileName; }
			set { __FileName = value; }
		}

		[XmlElement(ElementName="FileContent",IsNullable=true,Form=XmlSchemaForm.Unqualified,DataType="string",Namespace=Declarations.SchemaVersion)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public string __FileContent;
		
		[XmlIgnore]
		public string FileContent
		{ 
			get { return __FileContent; }
			set { __FileContent = value; }
		}

		[XmlElement(ElementName="TTL",IsNullable=false,Form=XmlSchemaForm.Unqualified,DataType="int",Namespace=Declarations.SchemaVersion)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public int __TTL;
		
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool __TTLSpecified;
		
		[XmlIgnore]
		public int TTL
		{ 
			get { return __TTL; }
			set { __TTL = value; __TTLSpecified = true; }
		}

		[XmlElement(ElementName="Encrypted",IsNullable=false,Form=XmlSchemaForm.Unqualified,DataType="boolean",Namespace=Declarations.SchemaVersion)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool __Encrypted;
		
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool __EncryptedSpecified;
		
		[XmlIgnore]
		public bool Encrypted
		{ 
			get { return __Encrypted; }
			set { __Encrypted = value; __EncryptedSpecified = true; }
		}

		[XmlElement(ElementName="CurrentVersion",IsNullable=false,Form=XmlSchemaForm.Unqualified,DataType="string",Namespace=Declarations.SchemaVersion)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public string __CurrentVersion;
		
		[XmlIgnore]
		public string CurrentVersion
		{ 
			get { return __CurrentVersion; }
			set { __CurrentVersion = value; }
		}

		[XmlElement(ElementName="ForceUpdate",IsNullable=false,Form=XmlSchemaForm.Unqualified,DataType="boolean",Namespace=Declarations.SchemaVersion)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool __ForceUpdate;
		
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool __ForceUpdateSpecified;
		
		[XmlIgnore]
		public bool ForceUpdate
		{ 
			get { return __ForceUpdate; }
			set { __ForceUpdate = value; __ForceUpdateSpecified = true; }
		}

		[XmlElement(ElementName="BaseConfigFile",IsNullable=false,Form=XmlSchemaForm.Unqualified,DataType="boolean",Namespace=Declarations.SchemaVersion)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool __BaseConfigFile;
		
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool __BaseConfigFileSpecified;
		
		[XmlIgnore]
		public bool BaseConfigFile
		{ 
			get { return __BaseConfigFile; }
			set { __BaseConfigFile = value; __BaseConfigFileSpecified = true; }
		}

		[XmlElement(ElementName="Cacheable",IsNullable=false,Form=XmlSchemaForm.Unqualified,DataType="boolean",Namespace=Declarations.SchemaVersion)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool __Cacheable;
		
		[XmlIgnore]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool __CacheableSpecified;
		
		[XmlIgnore]
		public bool Cacheable
		{ 
			get { return __Cacheable; }
			set { __Cacheable = value; __CacheableSpecified = true; }
		}

		public Result()
		{
			FileName = string.Empty;
			FileContent = string.Empty;
			__TTLSpecified = true;
			__EncryptedSpecified = true;
			CurrentVersion = string.Empty;
			__ForceUpdateSpecified = true;
			__BaseConfigFileSpecified = true;
			__CacheableSpecified = true;
		}
	}
}
