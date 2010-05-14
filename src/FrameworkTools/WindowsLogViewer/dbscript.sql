USE [WindowsLogs]
GO
/****** Object:  Table [dbo].[EventLog]    Script Date: 04/19/2010 22:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[EventLog_i]    Script Date: 04/19/2010 22:58:41 ******/
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
GO
