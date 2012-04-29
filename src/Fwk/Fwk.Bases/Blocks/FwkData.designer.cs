﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="fwkdata")]
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
    partial void InsertParamType(ParamType instance);
    partial void UpdateParamType(ParamType instance);
    partial void DeleteParamType(ParamType instance);
    partial void InsertParam(Param instance);
    partial void UpdateParam(Param instance);
    partial void DeleteParam(Param instance);
    #endregion
		
		public FwkDatacontext() : 
				base(global::Fwk.Bases.Properties.Settings.Default.fwkdataConnectionString, mappingSource)
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
		
		public System.Data.Linq.Table<ParamType> ParamTypes
		{
			get
			{
				return this.GetTable<ParamType>();
			}
		}
		
		public System.Data.Linq.Table<Param> Params
		{
			get
			{
				return this.GetTable<Param>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.fwk_ConfigMannager")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConfigurationFileName", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[group]", Storage="_group", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[key]", Storage="_key", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_encrypted", DbType="Bit NOT NULL")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_value", DbType="NVarChar(1000)")]
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.fwk_Logs")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="VarBinary(2000) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Source", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogType", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Machine", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogDate", DbType="DateTime NOT NULL")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserLoginName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AppId", DbType="NVarChar(100)")]
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ParamType")]
	public partial class ParamType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ParamTypeId;
		
		private string _Name;
		
		private System.Nullable<int> _ParamTypeRefId;
		
		private string _Description;
		
		private EntitySet<ParamType> _ParamTypes;
		
		private EntitySet<Param> _Params;
		
		private EntityRef<ParamType> _ParamType1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnParamTypeIdChanging(int value);
    partial void OnParamTypeIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnParamTypeRefIdChanging(System.Nullable<int> value);
    partial void OnParamTypeRefIdChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public ParamType()
		{
			this._ParamTypes = new EntitySet<ParamType>(new Action<ParamType>(this.attach_ParamTypes), new Action<ParamType>(this.detach_ParamTypes));
			this._Params = new EntitySet<Param>(new Action<Param>(this.attach_Params), new Action<Param>(this.detach_Params));
			this._ParamType1 = default(EntityRef<ParamType>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParamTypeId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ParamTypeId
		{
			get
			{
				return this._ParamTypeId;
			}
			set
			{
				if ((this._ParamTypeId != value))
				{
					this.OnParamTypeIdChanging(value);
					this.SendPropertyChanging();
					this._ParamTypeId = value;
					this.SendPropertyChanged("ParamTypeId");
					this.OnParamTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParamTypeRefId", DbType="Int")]
		public System.Nullable<int> ParamTypeRefId
		{
			get
			{
				return this._ParamTypeRefId;
			}
			set
			{
				if ((this._ParamTypeRefId != value))
				{
					if (this._ParamType1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnParamTypeRefIdChanging(value);
					this.SendPropertyChanging();
					this._ParamTypeRefId = value;
					this.SendPropertyChanged("ParamTypeRefId");
					this.OnParamTypeRefIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NChar(10)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ParamType_ParamType", Storage="_ParamTypes", ThisKey="ParamTypeId", OtherKey="ParamTypeRefId")]
		public EntitySet<ParamType> ParamTypes
		{
			get
			{
				return this._ParamTypes;
			}
			set
			{
				this._ParamTypes.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ParamType_Param", Storage="_Params", ThisKey="ParamTypeId", OtherKey="ParamTypeId")]
		public EntitySet<Param> Params
		{
			get
			{
				return this._Params;
			}
			set
			{
				this._Params.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ParamType_ParamType", Storage="_ParamType1", ThisKey="ParamTypeRefId", OtherKey="ParamTypeId", IsForeignKey=true)]
		public ParamType ParamType1
		{
			get
			{
				return this._ParamType1.Entity;
			}
			set
			{
				ParamType previousValue = this._ParamType1.Entity;
				if (((previousValue != value) 
							|| (this._ParamType1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ParamType1.Entity = null;
						previousValue.ParamTypes.Remove(this);
					}
					this._ParamType1.Entity = value;
					if ((value != null))
					{
						value.ParamTypes.Add(this);
						this._ParamTypeRefId = value.ParamTypeId;
					}
					else
					{
						this._ParamTypeRefId = default(Nullable<int>);
					}
					this.SendPropertyChanged("ParamType1");
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
		
		private void attach_ParamTypes(ParamType entity)
		{
			this.SendPropertyChanging();
			entity.ParamType1 = this;
		}
		
		private void detach_ParamTypes(ParamType entity)
		{
			this.SendPropertyChanging();
			entity.ParamType1 = null;
		}
		
		private void attach_Params(Param entity)
		{
			this.SendPropertyChanging();
			entity.ParamType = this;
		}
		
		private void detach_Params(Param entity)
		{
			this.SendPropertyChanging();
			entity.ParamType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Param")]
	public partial class Param : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ParamId;
		
		private string _Name;
		
		private int _ParamTypeId;
		
		private int _ParentId;
		
		private string _Description;
		
		private bool _Enabled;
		
		private EntityRef<ParamType> _ParamType;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnParamIdChanging(int value);
    partial void OnParamIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnParamTypeIdChanging(int value);
    partial void OnParamTypeIdChanged();
    partial void OnParentIdChanging(int value);
    partial void OnParentIdChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnEnabledChanging(bool value);
    partial void OnEnabledChanged();
    #endregion
		
		public Param()
		{
			this._ParamType = default(EntityRef<ParamType>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParamId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ParamId
		{
			get
			{
				return this._ParamId;
			}
			set
			{
				if ((this._ParamId != value))
				{
					this.OnParamIdChanging(value);
					this.SendPropertyChanging();
					this._ParamId = value;
					this.SendPropertyChanged("ParamId");
					this.OnParamIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParamTypeId", DbType="Int NOT NULL")]
		public int ParamTypeId
		{
			get
			{
				return this._ParamTypeId;
			}
			set
			{
				if ((this._ParamTypeId != value))
				{
					if (this._ParamType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnParamTypeIdChanging(value);
					this.SendPropertyChanging();
					this._ParamTypeId = value;
					this.SendPropertyChanged("ParamTypeId");
					this.OnParamTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentId", DbType="Int NOT NULL")]
		public int ParentId
		{
			get
			{
				return this._ParentId;
			}
			set
			{
				if ((this._ParentId != value))
				{
					this.OnParentIdChanging(value);
					this.SendPropertyChanging();
					this._ParentId = value;
					this.SendPropertyChanged("ParentId");
					this.OnParentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NChar(50)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Enabled", DbType="Bit NOT NULL")]
		public bool Enabled
		{
			get
			{
				return this._Enabled;
			}
			set
			{
				if ((this._Enabled != value))
				{
					this.OnEnabledChanging(value);
					this.SendPropertyChanging();
					this._Enabled = value;
					this.SendPropertyChanged("Enabled");
					this.OnEnabledChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ParamType_Param", Storage="_ParamType", ThisKey="ParamTypeId", OtherKey="ParamTypeId", IsForeignKey=true)]
		public ParamType ParamType
		{
			get
			{
				return this._ParamType.Entity;
			}
			set
			{
				ParamType previousValue = this._ParamType.Entity;
				if (((previousValue != value) 
							|| (this._ParamType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ParamType.Entity = null;
						previousValue.Params.Remove(this);
					}
					this._ParamType.Entity = value;
					if ((value != null))
					{
						value.Params.Add(this);
						this._ParamTypeId = value.ParamTypeId;
					}
					else
					{
						this._ParamTypeId = default(int);
					}
					this.SendPropertyChanged("ParamType");
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
