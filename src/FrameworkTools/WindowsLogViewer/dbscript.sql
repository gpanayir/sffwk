USE [WindowsLogs]
GO
/****** Objeto:  StoredProcedure [dbo].[EventLog_sp]    Fecha de la secuencia de comandos: 05/18/2010 16:58:22 ******/
DROP PROCEDURE [dbo].[EventLog_sp]
GO
/****** Objeto:  Table [dbo].[EventLog]    Fecha de la secuencia de comandos: 05/18/2010 16:58:25 ******/
DROP TABLE [dbo].[EventLog]
GO
/****** Objeto:  StoredProcedure [dbo].[EventLog_i]    Fecha de la secuencia de comandos: 05/18/2010 16:58:21 ******/
DROP PROCEDURE [dbo].[EventLog_i]
GO
/****** Objeto:  StoredProcedure [dbo].[EventLog_sp]    Fecha de la secuencia de comandos: 05/18/2010 16:58:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	CREATE PROCEDURE [dbo].[EventLog_sp]
	@Category NVarChar(20)  = NULL,
	@MachineName NVarChar(20)  = NULL,
	@Source NVarChar(20)  = NULL,
	@TimeGenerated DateTime  = NULL,
	@UserName NVarChar(20) = NULL,
	@EventLogEntryType NVarChar(12)  = NULL,
	@Winlog NVarChar(12)  = NULL,
	@AuditMachineName NVarChar(20) = NULL,
	@EventId BIGINT = null
	AS
	BEGIN
	SET NOCOUNT ON
	SET DATEFORMAT DMY

	----------------------------------------
	-- Definimos Variables
	----------------------------------------
	DECLARE @sql        nvarchar(4000)
	DECLARE @parametros nvarchar(4000)

	SET @sql = N' SELECT * FROM EventLog  WHERE 1 = 1 '
	
	-- Category = TYPE NVarChar
	IF (@Category IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND Category  LIKE  @Category '
	END
		
	-- MachineName = TYPE NVarChar
	IF (@MachineName IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND MachineName  LIKE  ''%'' + @MachineName + ''%'''
	END
	
	-- Source = TYPE NVarChar
	IF (@Source IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND Source  LIKE  ''%'' + @Source + ''%'''
	END
	
--	-- TimeGenerated = TYPE DateTime
--	
	 IF (@TimeGenerated IS NOT NULL AND @TimeGenerated <> '' )
	BEGIN
	  SET @sql = @sql + ' AND (TimeGenerated >= @TimeGeneratedDesde AND TimeGenerated <= )' + CONVERT(DATETIME, CONVERT(VARCHAR(10), getdate(), 103), 103)
	END
	
	-- UserName = TYPE NVarChar
	IF (@UserName IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND UserName  LIKE  ''%'' + @UserName + ''%'''
	END
	
	-- EventLogEntryType = TYPE NVarChar
	IF (@EventLogEntryType IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND EventLogEntryType  =   @EventLogEntryType '
	END
	
	-- Winlog = TYPE NVarChar
	IF (@Winlog IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND Winlog  =  @Winlog '
	END
	
	

	
	-- AuditMachineName = TYPE NChar
	IF (@AuditMachineName IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND AuditMachineName  LIKE  @AuditMachineName + ''%'''
	END
	
IF (@EventId IS NOT NULL)
	BEGIN
	SET @sql = @sql + ' AND EventId  =  @EventId '
	END

--SELECT  @sql

	SELECT @parametros = '	
@Category NVarChar(20) ,
@MachineName NVarChar(20) ,
@Source NVarChar(20) ,
@TimeGenerated DateTime ,
@UserName NVarChar(20)	,
@EventLogEntryType NVarChar(12) ,
@Winlog NVarChar(12) ,
@AuditMachineName NVarChar(20),
@EventId bigint '

	EXEC sp_executesql @sql, @parametros, 
@Category, 
@MachineName, 
@Source,
@TimeGenerated, 
@UserName, 
@EventLogEntryType, 
@Winlog, 
@AuditMachineName,
@EventId
	END
GO
/****** Objeto:  Table [dbo].[EventLog]    Fecha de la secuencia de comandos: 05/18/2010 16:58:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventLog](
	[Message] [nvarchar](2000) NULL,
	[EventID] [bigint] NOT NULL,
	[Category] [nvarchar](20) NOT NULL,
	[MachineName] [nvarchar](20) NOT NULL,
	[Source] [nvarchar](20) NOT NULL,
	[TimeWritten] [datetime] NOT NULL,
	[TimeGenerated] [datetime] NOT NULL,
	[UserName] [nvarchar](20) NULL,
	[EventLogEntryType] [nvarchar](12) NOT NULL,
	[Winlog] [nvarchar](12) NOT NULL,
	[AuditMachineName] [nvarchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Objeto:  StoredProcedure [dbo].[EventLog_i]    Fecha de la secuencia de comandos: 05/18/2010 16:58:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------------------
	-- Author     :		 moviedo
	-- Date       :	   2010-04-19T19:26:41
	-- Description: 	 [Description]
	--------------------------------------------------------------------------------------------
	CREATE PROCEDURE [dbo].[EventLog_i]
	
	(	@Message NVarChar(1000)= NULL,
	 @EventID bigint = NULL,
	 @Category NVarChar(20) = NULL,
	 @MachineName NVarChar(20) = NULL,
	 @Source NVarChar(20)= NULL,
	 @TimeWritten DateTime = NULL,
	 @TimeGenerated DATETIME = NULL,
	 @UserName NVarChar(20)= NULL,
	 @EventLogEntryType NVarChar(12)= NULL,
	 @Winlog NVarChar(12)= NULL,
	 @AuditMachineName NVarChar(20)= NULL
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
GO
