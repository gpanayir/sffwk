USE Celam
/****** Objeto:  Table [dbo].[aspnet_Rules]    Fecha de la secuencia de comandos: 04/26/2010 10:19:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Rules]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Rules](
	[name] [nchar](50) NULL,
	[expression] [nvarchar](max) NULL,
	[ApplicationId] [uniqueidentifier] NULL
) ON [PRIMARY]
END
GO
/****** Objeto:  Table [dbo].[DomainsUrl]    Fecha de la secuencia de comandos: 04/26/2010 10:19:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DomainsUrl]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DomainsUrl](
	[DomainName] [nvarchar](8) NOT NULL,
	[LDAPPath] [nvarchar](100) NOT NULL,
	[Usr] [nvarchar](20) NOT NULL,
	[Pwd] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_ADDomains] PRIMARY KEY CLUSTERED 
(
	[DomainName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Objeto:  Table [dbo].[aspnet_RulesInCategory]    Fecha de la secuencia de comandos: 04/26/2010 10:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_RulesInCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_RulesInCategory](
	[CategoryId] [int] NOT NULL,
	[RuleName] [nvarchar](50) NOT NULL,
	[ApplicationId] [uniqueidentifier] NULL
) ON [PRIMARY]
END
GO
/****** Objeto:  Table [dbo].[aspnet_RulesCategory]    Fecha de la secuencia de comandos: 04/26/2010 10:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_RulesCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_RulesCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ParentCategoryId] [int] NULL CONSTRAINT [DF_aspnet_RulesCategory_ParenCategoryId]  DEFAULT ((0)),
	[Name] [nvarchar](50) NULL,
	[ApplicationId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_aspnet_RulesCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
