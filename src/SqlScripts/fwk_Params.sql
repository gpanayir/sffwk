USE [fwkdata]
GO
/****** Object:  ForeignKey [FK_fwk_Param_fwk_Param]    Script Date: 08/11/2012 09:51:55 ******/
ALTER TABLE [dbo].[fwk_Param] DROP CONSTRAINT [FK_fwk_Param_fwk_Param]
GO
/****** Object:  ForeignKey [FK_Param_ParamType]    Script Date: 08/11/2012 09:51:55 ******/
ALTER TABLE [dbo].[fwk_Param] DROP CONSTRAINT [FK_Param_ParamType]
GO
/****** Object:  ForeignKey [FK_ParamType_ParamType]    Script Date: 08/11/2012 09:51:55 ******/
ALTER TABLE [dbo].[fwk_ParamType] DROP CONSTRAINT [FK_ParamType_ParamType]
GO
/****** Object:  Table [dbo].[fwk_Param]    Script Date: 08/11/2012 09:51:55 ******/
ALTER TABLE [dbo].[fwk_Param] DROP CONSTRAINT [FK_fwk_Param_fwk_Param]
GO
ALTER TABLE [dbo].[fwk_Param] DROP CONSTRAINT [FK_Param_ParamType]
GO
ALTER TABLE [dbo].[fwk_Param] DROP CONSTRAINT [DF_Param_Enabled]
GO
ALTER TABLE [dbo].[fwk_Param] DROP CONSTRAINT [DF_fwk_Param_Culture]
GO
DROP TABLE [dbo].[fwk_Param]
GO
/****** Object:  Table [dbo].[fwk_ParamType]    Script Date: 08/11/2012 09:51:55 ******/
ALTER TABLE [dbo].[fwk_ParamType] DROP CONSTRAINT [FK_ParamType_ParamType]
GO
ALTER TABLE [dbo].[fwk_ParamType] DROP CONSTRAINT [DF_ParamType_Enabled]
GO
DROP TABLE [dbo].[fwk_ParamType]
GO
/****** Object:  Table [dbo].[fwk_ParamType]    Script Date: 08/11/2012 09:51:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fwk_ParamType](
	[ParamTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ParentId] [int] NULL,
	[Description] [nchar](10) NULL,
	[Enabled] [bit] NOT NULL CONSTRAINT [DF_ParamType_Enabled]  DEFAULT ((1)),
 CONSTRAINT [PK_Params] PRIMARY KEY CLUSTERED 
(
	[ParamTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fwk_Param]    Script Date: 08/11/2012 09:51:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fwk_Param](
	[ParamId] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ParamTypeId] [int] NOT NULL,
	[Description] [varchar](50) NULL,
	[Enabled] [bit] NOT NULL CONSTRAINT [DF_Param_Enabled]  DEFAULT ((1)),
	[Culture] [char](5) NOT NULL CONSTRAINT [DF_fwk_Param_Culture]  DEFAULT ('es-AR'),
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Param] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_fwk_Param_fwk_Param]    Script Date: 08/11/2012 09:51:55 ******/
ALTER TABLE [dbo].[fwk_Param]  WITH CHECK ADD  CONSTRAINT [FK_fwk_Param_fwk_Param] FOREIGN KEY([Id])
REFERENCES [dbo].[fwk_Param] ([Id])
GO
ALTER TABLE [dbo].[fwk_Param] CHECK CONSTRAINT [FK_fwk_Param_fwk_Param]
GO
/****** Object:  ForeignKey [FK_Param_ParamType]    Script Date: 08/11/2012 09:51:55 ******/
ALTER TABLE [dbo].[fwk_Param]  WITH CHECK ADD  CONSTRAINT [FK_Param_ParamType] FOREIGN KEY([ParamTypeId])
REFERENCES [dbo].[fwk_ParamType] ([ParamTypeId])
GO
ALTER TABLE [dbo].[fwk_Param] CHECK CONSTRAINT [FK_Param_ParamType]
GO
/****** Object:  ForeignKey [FK_ParamType_ParamType]    Script Date: 08/11/2012 09:51:55 ******/
ALTER TABLE [dbo].[fwk_ParamType]  WITH CHECK ADD  CONSTRAINT [FK_ParamType_ParamType] FOREIGN KEY([ParentId])
REFERENCES [dbo].[fwk_ParamType] ([ParamTypeId])
GO
ALTER TABLE [dbo].[fwk_ParamType] CHECK CONSTRAINT [FK_ParamType_ParamType]
GO
