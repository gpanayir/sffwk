﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fwk.Security.Membership
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="aspnetdb")]
	public partial class RuleProviderDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertaspnet_RulesCategory(Fwk.Security.aspnet_RulesCategory instance);
    partial void Updateaspnet_RulesCategory(Fwk.Security.aspnet_RulesCategory instance);
    partial void Deleteaspnet_RulesCategory(Fwk.Security.aspnet_RulesCategory instance);
    partial void Insertaspnet_Application(Fwk.Security.aspnet_Application instance);
    partial void Updateaspnet_Application(Fwk.Security.aspnet_Application instance);
    partial void Deleteaspnet_Application(Fwk.Security.aspnet_Application instance);
    #endregion
		
		public RuleProviderDataContext() : 
				base(global::Fwk.Security.Properties.Settings.Default.aspnetdbConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public RuleProviderDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public RuleProviderDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public RuleProviderDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public RuleProviderDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Fwk.Security.aspnet_Rule> aspnet_Rules
		{
			get
			{
				return this.GetTable<Fwk.Security.aspnet_Rule>();
			}
		}
		
		public System.Data.Linq.Table<Fwk.Security.aspnet_RulesInCategory> aspnet_RulesInCategories
		{
			get
			{
				return this.GetTable<Fwk.Security.aspnet_RulesInCategory>();
			}
		}
		
		public System.Data.Linq.Table<Fwk.Security.aspnet_RulesCategory> aspnet_RulesCategories
		{
			get
			{
				return this.GetTable<Fwk.Security.aspnet_RulesCategory>();
			}
		}
		
		public System.Data.Linq.Table<Fwk.Security.aspnet_Application> aspnet_Applications
		{
			get
			{
				return this.GetTable<Fwk.Security.aspnet_Application>();
			}
		}
	}
}
namespace Fwk.Security
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.aspnet_Rules")]
	public partial class aspnet_Rule
	{
		
		private string _name;
		
		private string _expression;
		
		private System.Nullable<System.Guid> _ApplicationId;
		
		public aspnet_Rule()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NChar(50)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_expression", DbType="NVarChar(MAX)")]
		public string expression
		{
			get
			{
				return this._expression;
			}
			set
			{
				if ((this._expression != value))
				{
					this._expression = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationId", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					this._ApplicationId = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.aspnet_RulesInCategory")]
	public partial class aspnet_RulesInCategory
	{
		
		private int _CategoryId;
		
		private string _RuleName;
		
		private System.Nullable<System.Guid> _ApplicationId;
		
		public aspnet_RulesInCategory()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryId", DbType="Int NOT NULL")]
		public int CategoryId
		{
			get
			{
				return this._CategoryId;
			}
			set
			{
				if ((this._CategoryId != value))
				{
					this._CategoryId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RuleName", DbType="NChar(50) NOT NULL", CanBeNull=false)]
		public string RuleName
		{
			get
			{
				return this._RuleName;
			}
			set
			{
				if ((this._RuleName != value))
				{
					this._RuleName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationId", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					this._ApplicationId = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.aspnet_RulesCategory")]
	public partial class aspnet_RulesCategory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CategoryId;
		
		private System.Nullable<int> _ParentCategoryId;
		
		private string _Name;
		
		private System.Nullable<System.Guid> _ApplicationId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCategoryIdChanging(int value);
    partial void OnCategoryIdChanged();
    partial void OnParentCategoryIdChanging(System.Nullable<int> value);
    partial void OnParentCategoryIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnApplicationIdChanging(System.Nullable<System.Guid> value);
    partial void OnApplicationIdChanged();
    #endregion
		
		public aspnet_RulesCategory()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int CategoryId
		{
			get
			{
				return this._CategoryId;
			}
			set
			{
				if ((this._CategoryId != value))
				{
					this.OnCategoryIdChanging(value);
					this.SendPropertyChanging();
					this._CategoryId = value;
					this.SendPropertyChanged("CategoryId");
					this.OnCategoryIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentCategoryId", DbType="Int")]
		public System.Nullable<int> ParentCategoryId
		{
			get
			{
				return this._ParentCategoryId;
			}
			set
			{
				if ((this._ParentCategoryId != value))
				{
					this.OnParentCategoryIdChanging(value);
					this.SendPropertyChanging();
					this._ParentCategoryId = value;
					this.SendPropertyChanged("ParentCategoryId");
					this.OnParentCategoryIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationId", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.aspnet_Applications")]
	public partial class aspnet_Application : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ApplicationName;
		
		private string _LoweredApplicationName;
		
		private System.Guid _ApplicationId;
		
		private string _Description;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnApplicationNameChanging(string value);
    partial void OnApplicationNameChanged();
    partial void OnLoweredApplicationNameChanging(string value);
    partial void OnLoweredApplicationNameChanged();
    partial void OnApplicationIdChanging(System.Guid value);
    partial void OnApplicationIdChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public aspnet_Application()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationName", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string ApplicationName
		{
			get
			{
				return this._ApplicationName;
			}
			set
			{
				if ((this._ApplicationName != value))
				{
					this.OnApplicationNameChanging(value);
					this.SendPropertyChanging();
					this._ApplicationName = value;
					this.SendPropertyChanged("ApplicationName");
					this.OnApplicationNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoweredApplicationName", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string LoweredApplicationName
		{
			get
			{
				return this._LoweredApplicationName;
			}
			set
			{
				if ((this._LoweredApplicationName != value))
				{
					this.OnLoweredApplicationNameChanging(value);
					this.SendPropertyChanging();
					this._LoweredApplicationName = value;
					this.SendPropertyChanged("LoweredApplicationName");
					this.OnLoweredApplicationNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(256)")]
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
