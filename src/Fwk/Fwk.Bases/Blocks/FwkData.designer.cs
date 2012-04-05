﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5448
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fwk.ConfigData
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="Mails")]
	public partial class FwkDatacontext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertfwk_ConfigMannager(fwk_ConfigMannager instance);
    partial void Updatefwk_ConfigMannager(fwk_ConfigMannager instance);
    partial void Deletefwk_ConfigMannager(fwk_ConfigMannager instance);
    partial void Insertfwk_Log(fwk_Log instance);
    partial void Updatefwk_Log(fwk_Log instance);
    partial void Deletefwk_Log(fwk_Log instance);
    #endregion
		
		public FwkDatacontext() : 
				base(global::Fwk.Bases.Properties.Settings.Default.fwktestConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public FwkDatacontext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FwkDatacontext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FwkDatacontext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FwkDatacontext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<fwk_ConfigMannager> fwk_ConfigMannagers
		{
			get
			{
				return this.GetTable<fwk_ConfigMannager>();
			}
		}
		
		public System.Data.Linq.Table<fwk_Log> fwk_Logs
		{
			get
			{
				return this.GetTable<fwk_Log>();
			}
		}
	}
	
	[Table(Name="dbo.fwk_ConfigMannager")]
	public partial class fwk_ConfigMannager : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ConfigurationFileName;
		
		private string _group;
		
		private string _key;
		
		private bool _encrypted;
		
		private string _value;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnConfigurationFileNameChanging(string value);
    partial void OnConfigurationFileNameChanged();
    partial void OngroupChanging(string value);
    partial void OngroupChanged();
    partial void OnkeyChanging(string value);
    partial void OnkeyChanged();
    partial void OnencryptedChanging(bool value);
    partial void OnencryptedChanged();
    partial void OnvalueChanging(string value);
    partial void OnvalueChanged();
    #endregion
		
		public fwk_ConfigMannager()
		{
			OnCreated();
		}
		
		[Column(Storage="_ConfigurationFileName", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ConfigurationFileName
		{
			get
			{
				return this._ConfigurationFileName;
			}
			set
			{
				if ((this._ConfigurationFileName != value))
				{
					this.OnConfigurationFileNameChanging(value);
					this.SendPropertyChanging();
					this._ConfigurationFileName = value;
					this.SendPropertyChanged("ConfigurationFileName");
					this.OnConfigurationFileNameChanged();
				}
			}
		}
		
		[Column(Name="[group]", Storage="_group", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string group
		{
			get
			{
				return this._group;
			}
			set
			{
				if ((this._group != value))
				{
					this.OngroupChanging(value);
					this.SendPropertyChanging();
					this._group = value;
					this.SendPropertyChanged("group");
					this.OngroupChanged();
				}
			}
		}
		
		[Column(Name="[key]", Storage="_key", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string key
		{
			get
			{
				return this._key;
			}
			set
			{
				if ((this._key != value))
				{
					this.OnkeyChanging(value);
					this.SendPropertyChanging();
					this._key = value;
					this.SendPropertyChanged("key");
					this.OnkeyChanged();
				}
			}
		}
		
		[Column(Storage="_encrypted", DbType="Bit NOT NULL")]
		public bool encrypted
		{
			get
			{
				return this._encrypted;
			}
			set
			{
				if ((this._encrypted != value))
				{
					this.OnencryptedChanging(value);
					this.SendPropertyChanging();
					this._encrypted = value;
					this.SendPropertyChanged("encrypted");
					this.OnencryptedChanged();
				}
			}
		}
		
		[Column(Storage="_value", DbType="NVarChar(1000)")]
		public string value
		{
			get
			{
				return this._value;
			}
			set
			{
				if ((this._value != value))
				{
					this.OnvalueChanging(value);
					this.SendPropertyChanging();
					this._value = value;
					this.SendPropertyChanged("value");
					this.OnvalueChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.fwk_Logs")]
	public partial class fwk_Log : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Data.Linq.Binary _Message;
		
		private string _Source;
		
		private string _LogType;
		
		private string _Machine;
		
		private System.DateTime _LogDate;
		
		private string _UserLoginName;
		
		private string _AppId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnMessageChanging(System.Data.Linq.Binary value);
    partial void OnMessageChanged();
    partial void OnSourceChanging(string value);
    partial void OnSourceChanged();
    partial void OnLogTypeChanging(string value);
    partial void OnLogTypeChanged();
    partial void OnMachineChanging(string value);
    partial void OnMachineChanged();
    partial void OnLogDateChanging(System.DateTime value);
    partial void OnLogDateChanged();
    partial void OnUserLoginNameChanging(string value);
    partial void OnUserLoginNameChanged();
    partial void OnAppIdChanging(string value);
    partial void OnAppIdChanged();
    #endregion
		
		public fwk_Log()
		{
			OnCreated();
		}
		
		[Column(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_Message", DbType="VarBinary(2000) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this.OnMessageChanging(value);
					this.SendPropertyChanging();
					this._Message = value;
					this.SendPropertyChanged("Message");
					this.OnMessageChanged();
				}
			}
		}
		
		[Column(Storage="_Source", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Source
		{
			get
			{
				return this._Source;
			}
			set
			{
				if ((this._Source != value))
				{
					this.OnSourceChanging(value);
					this.SendPropertyChanging();
					this._Source = value;
					this.SendPropertyChanged("Source");
					this.OnSourceChanged();
				}
			}
		}
		
		[Column(Storage="_LogType", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string LogType
		{
			get
			{
				return this._LogType;
			}
			set
			{
				if ((this._LogType != value))
				{
					this.OnLogTypeChanging(value);
					this.SendPropertyChanging();
					this._LogType = value;
					this.SendPropertyChanged("LogType");
					this.OnLogTypeChanged();
				}
			}
		}
		
		[Column(Storage="_Machine", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Machine
		{
			get
			{
				return this._Machine;
			}
			set
			{
				if ((this._Machine != value))
				{
					this.OnMachineChanging(value);
					this.SendPropertyChanging();
					this._Machine = value;
					this.SendPropertyChanged("Machine");
					this.OnMachineChanged();
				}
			}
		}
		
		[Column(Storage="_LogDate", DbType="DateTime NOT NULL")]
		public System.DateTime LogDate
		{
			get
			{
				return this._LogDate;
			}
			set
			{
				if ((this._LogDate != value))
				{
					this.OnLogDateChanging(value);
					this.SendPropertyChanging();
					this._LogDate = value;
					this.SendPropertyChanged("LogDate");
					this.OnLogDateChanged();
				}
			}
		}
		
		[Column(Storage="_UserLoginName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string UserLoginName
		{
			get
			{
				return this._UserLoginName;
			}
			set
			{
				if ((this._UserLoginName != value))
				{
					this.OnUserLoginNameChanging(value);
					this.SendPropertyChanging();
					this._UserLoginName = value;
					this.SendPropertyChanged("UserLoginName");
					this.OnUserLoginNameChanged();
				}
			}
		}
		
		[Column(Storage="_AppId", DbType="NVarChar(100)")]
		public string AppId
		{
			get
			{
				return this._AppId;
			}
			set
			{
				if ((this._AppId != value))
				{
					this.OnAppIdChanging(value);
					this.SendPropertyChanging();
					this._AppId = value;
					this.SendPropertyChanged("AppId");
					this.OnAppIdChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
