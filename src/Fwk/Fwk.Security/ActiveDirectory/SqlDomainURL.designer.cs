﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fwk.Security.ActiveDirectory
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
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="Logs")]
	public partial class SqlDomainURLDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Create Definitions
    partial void OnCreated();
    partial void InsertDomainsUrl(DomainsUrl instance);
    partial void UpdateDomainsUrl(DomainsUrl instance);
    partial void DeleteDomainsUrl(DomainsUrl instance);
    #endregion
		
		public SqlDomainURLDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SqlDomainURLDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SqlDomainURLDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SqlDomainURLDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<DomainsUrl> DomainsUrls
		{
			get
			{
				return this.GetTable<DomainsUrl>();
			}
		}
	}
	
	[Table(Name="dbo.DomainsUrl")]
	public partial class DomainsUrl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _DomainName;
		
		private string _LDAPPath;
		
		private string _Usr;
		
		private string _Pwd;
		
    #region Extensibility Create Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDomainNameChanging(string value);
    partial void OnDomainNameChanged();
    partial void OnLDAPPathChanging(string value);
    partial void OnLDAPPathChanged();
    partial void OnUsrChanging(string value);
    partial void OnUsrChanged();
    partial void OnPwdChanging(string value);
    partial void OnPwdChanged();
    #endregion
		
		public DomainsUrl()
		{
			OnCreated();
		}
		
		[Column(Storage="_DomainName", DbType="NVarChar(8) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string DomainName
		{
			get
			{
				return this._DomainName;
			}
			set
			{
				if ((this._DomainName != value))
				{
					this.OnDomainNameChanging(value);
					this.SendPropertyChanging();
					this._DomainName = value;
					this.SendPropertyChanged("DomainName");
					this.OnDomainNameChanged();
				}
			}
		}
		
		[Column(Storage="_LDAPPath", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string LDAPPath
		{
			get
			{
				return this._LDAPPath;
			}
			set
			{
				if ((this._LDAPPath != value))
				{
					this.OnLDAPPathChanging(value);
					this.SendPropertyChanging();
					this._LDAPPath = value;
					this.SendPropertyChanged("LDAPPath");
					this.OnLDAPPathChanged();
				}
			}
		}
		
		[Column(Storage="_Usr", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Usr
		{
			get
			{
				return this._Usr;
			}
			set
			{
				if ((this._Usr != value))
				{
					this.OnUsrChanging(value);
					this.SendPropertyChanging();
					this._Usr = value;
					this.SendPropertyChanged("Usr");
					this.OnUsrChanged();
				}
			}
		}
		
		[Column(Storage="_Pwd", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Pwd
		{
			get
			{
				return this._Pwd;
			}
			set
			{
				if ((this._Pwd != value))
				{
					this.OnPwdChanging(value);
					this.SendPropertyChanging();
					this._Pwd = value;
					this.SendPropertyChanged("Pwd");
					this.OnPwdChanged();
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
