USE [WindowsLogs]
GO
/****** Object:  Table [dbo].[EventLog]    Script Date: 05/15/2010 15:57:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EventLog](
	[Message] [nvarchar](1000) NULL,
	[EventID] [int] NOT NULL,
	[Category] [nvarchar](20) NOT NULL,
	[MachineName] [nvarchar](20) NOT NULL,
	[Source] [nvarchar](20) NOT NULL,
	[TimeWritten] [datetime] NOT NULL,
	[TimeGenerated] [datetime] NOT NULL,
	[UserName] [nvarchar](20) NULL,
	[EventLogEntryType] [nvarchar](12) NOT NULL,
	[Winlog] [nvarchar](12) NOT NULL,
	[AuditMachineName] [nchar](10) NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  StoredProcedure [dbo].[EventLog_sp]    Script Date: 05/15/2010 15:57:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventLog_sp]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




--------------------------------------------------------------------------------------------
	-- Autor:		moviedo
	-- Creacion:		14/05/2010 16:27:24
	-- Descripcion: 	Realiza una busqueda por parametros de la tabla EventLog
	--------------------------------------------------------------------------------------------
	-- Operadores posibles de usar:
	--
	-- <> | > | >= | < | <= | = | %_ | _% | %% | []
	--
	--------------------------------------------------------------------------------------------
	create PROCEDURE [dbo].[EventLog_sp]

	@Category NVarChar(20)  = NULL,

	@MachineName NVarChar(20)  = NULL,

	@Source NVarChar(20)  = NULL,

	@TimeGenerated DateTime  = NULL,

	@UserName NVarChar(20) = NULL,

	@EventLogEntryType NVarChar(12)  = NULL,

	@Winlog NVarChar(12)  = NULL,

	@AuditMachineName NVarChar(20) = NULL

	AS
	BEGIN
	SET NOCOUNT ON
	SET DATEFORMAT DMY

	----------------------------------------
	-- Definimos Variables
	----------------------------------------
	DECLARE @sql        nvarchar(4000)
	DECLARE @parametros nvarchar(4000)

	SET @sql = N'' SELECT * FROM EventLog  WHERE 1 = 1 ''

	


	
	-- Category = TYPE NVarChar
	IF (@Category IS NOT NULL)
	BEGIN
	SET @sql = @sql + '' AND Category  LIKE  @Category ''
	END
	
	

	
	-- MachineName = TYPE NVarChar
	IF (@MachineName IS NOT NULL)
	BEGIN
	SET @sql = @sql + '' AND MachineName  LIKE  ''''%'''' + @MachineName + ''''%''''''
	END
	
	

	
	-- Source = TYPE NVarChar
	IF (@Source IS NOT NULL)
	BEGIN
	SET @sql = @sql + '' AND Source  LIKE  @Source ''
	END
	
	
--	-- TimeGenerated = TYPE DateTime
--	
	 IF (@TimeGenerated IS NOT NULL AND @TimeGenerated <> '''' )
	BEGIN
	  SET @sql = @sql + '' AND (TimeGenerated >= @TimeGeneratedDesde AND TimeGenerated <= )'' + CONVERT(DATETIME, CONVERT(VARCHAR(10), getdate(), 103), 103)
	END

	

	
	-- UserName = TYPE NVarChar
	IF (@UserName IS NOT NULL)
	BEGIN
	SET @sql = @sql + '' AND UserName  LIKE  ''''%'''' + @UserName + ''''%''''''
	END
	
	

	
	-- EventLogEntryType = TYPE NVarChar
	IF (@EventLogEntryType IS NOT NULL)
	BEGIN
	SET @sql = @sql + '' AND EventLogEntryType  =   @EventLogEntryType ''
	END
	
	

	
	-- Winlog = TYPE NVarChar
	IF (@Winlog IS NOT NULL)
	BEGIN
	SET @sql = @sql + '' AND Winlog  =  @Winlog ''
	END
	
	

	
	-- AuditMachineName = TYPE NChar
	IF (@AuditMachineName IS NOT NULL)
	BEGIN
	SET @sql = @sql + '' AND AuditMachineName  LIKE  @AuditMachineName ''
	END
	
	


	SELECT @parametros = ''	

@Category NVarChar(20) ,

@MachineName NVarChar(20) ,

@Source NVarChar(20) ,


@TimeWritten DateTime ,


@TimeGenerated DateTime ,

@UserName NVarChar(20)	,

@EventLogEntryType NVarChar(12) ,

@Winlog NVarChar(12) ,

@AuditMachineName NVarChar(20) ''

	EXEC sp_executesql @sql, @parametros, @Category, @MachineName, @Source,

@TimeGenerated, @UserName, @EventLogEntryType, @Winlog, @AuditMachineName
	END

	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EventLog_i]    Script Date: 05/15/2010 15:57:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventLog_i]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--------------------------------------------------------------------------------------------
	-- Author     :		 moviedo
	-- Date       :	   2010-04-19T19:26:41
	-- Description: 	 [Description]
	--------------------------------------------------------------------------------------------
	CREATE PROCEDURE [dbo].[EventLog_i]
	
	(	@Message NVarChar(1000)= NULL,
	 @EventID INT = NULL,
	 @Category NVarChar(20) = NULL,
	 @MachineName NVarChar(20) = NULL,
	 @Source NVarChar(20)= NULL,
	 @TimeWritten DateTime = NULL,
	 @TimeGenerated DATETIME = NULL,
	 @UserName NVarChar(20)= NULL,
	 @EventLogEntryType NVarChar(12)= NULL,
	 @Winlog NVarChar(12)= NULL,
	 @AuditMachineName NVarChar(12)= NULL
	)
	
	AS
	
	
	
	
	
	INSERT INTO EventLog
	(
		[Message]
		,EventID
		,Category
		,MachineName
		,Source
		,TimeWritten
		,TimeGenerated
		,UserName
		,EventLogEntryType
		,Winlog
	,AuditMachineName
	)
	VALUES
	(
		@Message,
		@EventID,
		@Category,
		@MachineName,
		@Source,
		@TimeWritten,
		@TimeGenerated,
		@UserName,
		@EventLogEntryType,
		@Winlog,@AuditMachineName
	)
' 
END
GO
