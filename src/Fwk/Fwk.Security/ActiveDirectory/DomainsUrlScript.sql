﻿USE [xxxxxx]
GO
/****** Object:  Table [dbo].[DomainUrlInfo]    Script Date: 03/05/2010 11:44:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DomainUrlInfo](
	[DomainName] [nvarchar](8) NOT NULL,
	[LDAPPath] [nvarchar](100) NOT NULL,
	[Usr] [nvarchar](20) NOT NULL,
	[Pwd] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_ADDomains] PRIMARY KEY CLUSTERED 
(
	[DomainName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
