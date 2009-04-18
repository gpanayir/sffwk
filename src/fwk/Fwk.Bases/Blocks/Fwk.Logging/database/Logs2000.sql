USE [master]
GO
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'Logs')
BEGIN
CREATE DATABASE [Logs] ON  PRIMARY 
( NAME = N'Logs', FILENAME = N'c:\Archivos de programa\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Logs.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Logs_log', FILENAME = N'c:\Archivos de programa\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Logs_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 COLLATE Modern_Spanish_CI_AS
END

GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Logs].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Logs] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Logs] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Logs] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Logs] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Logs] SET ARITHABORT OFF 
GO
ALTER DATABASE [Logs] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Logs] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Logs] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Logs] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Logs] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Logs] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Logs] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Logs] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Logs] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Logs] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Logs] SET  READ_WRITE 
GO
ALTER DATABASE [Logs] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Logs] SET  MULTI_USER 
GO
if ( ((@@microsoftversion / power(2, 24) = 8) and (@@microsoftversion & 0xffff >= 760)) or 
		(@@microsoftversion / power(2, 24) >= 9) )begin 
	exec dbo.sp_dboption @dbname =  N'Logs', @optname = 'db chaining', @optvalue = 'OFF'
 end
USE [Logs]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Logs]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Logs](
	[Id] [varbinary](50) NOT NULL,
	[Message] [varchar](1000) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Source] [varchar](100) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Type] [varchar](100) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[Machine] [varchar](100) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[User] [varchar](100) COLLATE Modern_Spanish_CI_AS NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Logs_i]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Logs_i]
(
	@Id int ,
	@DateTime datetime ,
	@Message varchar(1000) ,
	@Source varchar(100) ,
	@Type varchar(100) ,
	@Machine varchar(100) ,
	@User varchar(100) 

)
AS
				
-- Description : Procedimiento de creación de Logs.
-- Author      : moviedo
-- Date        : 2006-11-16T11:59:20
				

INSERT INTO Logs
(
	Id,
	DateTime,
	Message,
	Source,
	Type,
	Machine,
	[User]

)
VALUES
(
	@Id,
	@DateTime,
	@Message,
	@Source,
	@Type,
	@Machine,
	@User

)


				
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Logs_u]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Logs_u]
(
	@Id int ,
	@DateTime datetime ,
	@Message varchar(1000) ,
	@Source varchar(100) ,
	@Type varchar(100) ,
	@Machine varchar(100) ,
	@User varchar(100) 

)
AS
				
-- Description : Procedimiento de actualización de Logs.
-- Author      : moviedo
-- Date        : 2006-11-16T11:59:20
				

UPDATE Logs
SET 
	DateTime = @DateTime,
	Message = @Message,
	Source = @Source,
	Type = @Type,
	Machine = @Machine,
	[User] = @User

WHERE Id = @Id 

				
				
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Logs_d]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Logs_d]
(
	@Id int 

)
AS
				
-- Description : Procedimiento de eliminación de Logs.
-- Author      : moviedo
-- Date        : 2006-11-16T11:59:20
				

DELETE FROM Logs
WHERE Id = @Id 

				
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Logs_g]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Logs_g]
(
	@Id int 

)
AS
				
-- Description : Procedimiento búsqueda de Logs por clave primaria.
-- Author      : moviedo
-- Date        : 2006-11-16T11:59:20
				

SELECT
	Id,
		DateTime,
		Message,
		Source,
		Type,
		Machine,
		User

FROM Logs
WHERE
Id = @Id 


				
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Logs_s]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Logs_s]
AS
				
-- Description : Procedimiento de búsqueda de Logs.
-- Author      : moviedo
-- Date        : 2006-11-16T11:59:20
				

SELECT
	Id,
		DateTime,
		Message,
		Source,
		Type,
		Machine,
		User

FROM Logs

				
' 
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Logs]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Logs](
	[Id] [varbinary](50) NOT NULL,
	[Message] [varchar](1000) NOT NULL,
	[Source] [varchar](100) NOT NULL,
	[Type] [varchar](100) NOT NULL,
	[Machine] [varchar](100) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[User] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
