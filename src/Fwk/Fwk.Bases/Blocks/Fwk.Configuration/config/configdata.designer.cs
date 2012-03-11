﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fwk.Bases.Blocks.Fwk.Configuration.config
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="fwktest")]
	public partial class configdataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertfwk_ConfigMannager(fwk_ConfigMannager instance);
    partial void Updatefwk_ConfigMannager(fwk_ConfigMannager instance);
    partial void Deletefwk_ConfigMannager(fwk_ConfigMannager instance);
    #endregion
		
		public configdataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public configdataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public configdataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public configdataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
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
}
#pragma warning restore 1591
