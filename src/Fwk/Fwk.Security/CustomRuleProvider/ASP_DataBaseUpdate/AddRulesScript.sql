USE [aspnetdb]
GO
/****** Objeto:  Table [dbo].[aspnet_Rules]    Fecha de la secuencia de comandos: 03/10/2009 12:07:38 ******/
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
/****** Objeto:  StoredProcedure [dbo].[aspnet_Rules_i]    Fecha de la secuencia de comandos: 03/10/2009 12:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Rules_i]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create PROCEDURE [dbo].[aspnet_Rules_i]
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

 ' 
END
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_Rules_s]    Fecha de la secuencia de comandos: 03/10/2009 12:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Rules_s]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
	CREATE PROCEDURE [dbo].[aspnet_Rules_s]
	 @ApplicationName  nvarchar(256)
	
	
	AS
	
	 DECLARE @ApplicationId uniqueidentifier
    SELECT  @ApplicationId = NULL
    SELECT  @ApplicationId = ApplicationId FROM aspnet_Applications WHERE LOWER(@ApplicationName) = LoweredApplicationName
    IF (@ApplicationId IS NULL)
        RETURN(1)
	
	SELECT
	name
	,expression
	,ApplicationId


	FROM aspnet_Rules
	
	where ApplicationId = @ApplicationId


' 
END
GO
