/****** Object:  Table [dbo].[aspnet_RulesInCategory]    Script Date: 07/14/2012 11:18:42 ******/
DROP TABLE [dbo].[aspnet_RulesInCategory]
GO
/****** Object:  Table [dbo].[aspnet_Rules]    Script Date: 07/14/2012 11:18:42 ******/
DROP TABLE [dbo].[aspnet_Rules]
GO
/****** Object:  Table [dbo].[aspnet_RulesCategory]    Script Date: 07/14/2012 11:18:42 ******/
ALTER TABLE [dbo].[aspnet_RulesCategory] DROP CONSTRAINT [DF_aspnet_RulesCategory_ParenCategoryId]
GO
DROP TABLE [dbo].[aspnet_RulesCategory]
GO
/****** Object:  Table [dbo].[aspnet_RulesCategory]    Script Date: 07/14/2012 11:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  Table [dbo].[aspnet_Rules]    Script Date: 07/14/2012 11:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Rules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
	[expression] [nvarchar](max) NULL,
	[ApplicationId] [uniqueidentifier] NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_aspnet_Rules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aspnet_RulesInCategory]    Script Date: 07/14/2012 11:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_RulesInCategory](
	[CategoryId] [int] NOT NULL,
	[RuleId] [int] NOT NULL,
	[ApplicationId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_aspnet_RulesInCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[RuleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
