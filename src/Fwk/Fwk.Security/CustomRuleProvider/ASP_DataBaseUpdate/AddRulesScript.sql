USE [BigBang]
GO
/****** Objeto:  Table [dbo].[aspnet_Rules]    Fecha de la secuencia de comandos: 06/18/2009 16:05:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_Rules](
	[name] [nchar](50) NULL,
	[expression] [nvarchar](max) NULL,
	[ApplicationId] [uniqueidentifier] NULL
) ON [PRIMARY]
GO
/****** Objeto:  Table [dbo].[aspnet_RulesCategory]    Fecha de la secuencia de comandos: 06/18/2009 16:05:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_RulesCategory](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ParenCategoryId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[ApplicationId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_aspnet_RulesCategory] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_Rules_g_exist]    Fecha de la secuencia de comandos: 06/18/2009 16:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[aspnet_Rules_g_exist]
    @ApplicationName                        nvarchar(256),
    @name                               nvarchar(50),
    @exist                               bit = 0   output
AS

set @exist = 0

 DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications 
WHERE LOWER(@ApplicationName) = LoweredApplicationName


    IF (@ApplicationId IS NULL)
        RETURN 0
 
select [name] from dbo.aspnet_Rules where 

(@ApplicationId = @ApplicationId)
and
([name] = @name)
    
if (@@rowcount <> 0)
	set @exist = 1
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_Rules_i]    Fecha de la secuencia de comandos: 06/18/2009 16:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
create PROCEDURE [dbo].[aspnet_Rules_i]
    @ApplicationName                        nvarchar(256),
    @name                               nvarchar(50),
    @expression                               nvarchar(MAX)
   
AS



 DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM dbo.aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN 0
 
    INSERT INTO dbo.aspnet_Rules
                ( ApplicationId,
                  [name],
                  expression
                   )
         VALUES ( @ApplicationId,
                  @name,
                  @expression
                   )
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_Rules_s]    Fecha de la secuencia de comandos: 06/18/2009 16:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[aspnet_Rules_s]
	 @ApplicationName  nvarchar(256)
	
	
	AS
	
	 DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(0)
	
	SELECT
	name
	,expression
	,ApplicationId


	FROM aspnet_Rules
	
	where ApplicationId = @ApplicationId
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_Categories_s]    Fecha de la secuencia de comandos: 06/18/2009 16:05:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[aspnet_Categories_s]
(
  @ApplicationName  nvarchar(256)
)
AS

    
 DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId 
    FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(0)
        
SELECT * FROM dbo.aspnet_RulesCategory where ApplicationId = @ApplicationId
GO
