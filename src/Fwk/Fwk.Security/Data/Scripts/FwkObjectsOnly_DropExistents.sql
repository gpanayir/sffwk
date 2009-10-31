/****** Objeto:  StoredProcedure [dbo].[aspnet_Rules_g_exist]    Fecha de la secuencia de comandos: 10/30/2009 11:48:00 ******/
DROP PROCEDURE [dbo].[aspnet_Rules_g_exist]
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_Rules_i]    Fecha de la secuencia de comandos: 10/30/2009 11:47:57 ******/
DROP PROCEDURE [dbo].[aspnet_Rules_i]
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_Rules_s]    Fecha de la secuencia de comandos: 10/30/2009 11:47:57 ******/
DROP PROCEDURE [dbo].[aspnet_Rules_s]
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_Categories_s]    Fecha de la secuencia de comandos: 10/30/2009 11:48:00 ******/
DROP PROCEDURE [dbo].[aspnet_Categories_s]
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_RulesCategory_s]    Fecha de la secuencia de comandos: 10/30/2009 11:47:59 ******/
DROP PROCEDURE [dbo].[aspnet_RulesCategory_s]
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_RulesCategory_g]    Fecha de la secuencia de comandos: 10/30/2009 11:47:58 ******/
DROP PROCEDURE [dbo].[aspnet_RulesCategory_g]
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_RulesCategory_i]    Fecha de la secuencia de comandos: 10/30/2009 11:47:59 ******/
DROP PROCEDURE [dbo].[aspnet_RulesCategory_i]
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_RulesCategory_d]    Fecha de la secuencia de comandos: 10/30/2009 11:47:58 ******/
DROP PROCEDURE [dbo].[aspnet_RulesCategory_d]
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_RulesCategory_u]    Fecha de la secuencia de comandos: 10/30/2009 11:47:59 ******/
DROP PROCEDURE [dbo].[aspnet_RulesCategory_u]
GO
/****** Objeto:  Table [dbo].[aspnet_RulesCategory]    Fecha de la secuencia de comandos: 10/30/2009 11:48:02 ******/
DROP TABLE [dbo].[aspnet_RulesCategory]
GO
/****** Objeto:  Table [dbo].[aspnet_Rules]    Fecha de la secuencia de comandos: 10/30/2009 11:48:04 ******/
DROP TABLE [dbo].[aspnet_Rules]
GO
/****** Objeto:  Table [dbo].[aspnet_RulesInCategory]    Fecha de la secuencia de comandos: 10/30/2009 11:48:01 ******/
DROP TABLE [dbo].[aspnet_RulesInCategory]
GO
/****** Objeto:  Table [dbo].[aspnet_RulesInCategory]    Fecha de la secuencia de comandos: 10/30/2009 11:48:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aspnet_RulesInCategory](
	[CategoryId] [int] NOT NULL,
	[RuleName] [nchar](50) NOT NULL,
	[ApplicationId] [uniqueidentifier] NULL
) ON [PRIMARY]
GO
/****** Objeto:  Table [dbo].[aspnet_Rules]    Fecha de la secuencia de comandos: 10/30/2009 11:48:04 ******/
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
/****** Objeto:  Table [dbo].[aspnet_RulesCategory]    Fecha de la secuencia de comandos: 10/30/2009 11:48:02 ******/
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
/****** Objeto:  StoredProcedure [dbo].[aspnet_RulesCategory_g]    Fecha de la secuencia de comandos: 10/30/2009 11:47:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------------------
        -- Autor:		AAguirre
        -- Creacion:		01/07/2009 03:14:29 p.m.
        -- Descripcion: 	Realiza una busqueda por parametros de la tabla aspnet_RulesCategory
        --------------------------------------------------------------------------------------------
        -- Operadores posibles de usar:
        --
        -- <> | > | >= | < | <= | = | %_ | _% | %% | []
        --
        --------------------------------------------------------------------------------------------
        CREATE PROCEDURE [dbo].[aspnet_RulesCategory_g]
	        -- Lista de Parámetros
	        @OrdenDeRegistros 					    VARCHAR(100) = null,
        	@CategoryId int ,

	@ParentCategoryId int  = NULL,

	@Name nvarchar(50)  = NULL,

	@ApplicationId VARCHAR(36)  = NULL

        AS
        BEGIN
	        SET NOCOUNT ON
	        SET DATEFORMAT DMY

	        ----------------------------------------
	        -- Definimos Variables
	        ----------------------------------------
	        DECLARE @sql        nvarchar(4000)
	        DECLARE @parametros nvarchar(4000)

	        SET @sql = N' SELECT * FROM aspnet_RulesCategory  WHERE 1 = 1 '

        
				-- CategoryId = TYPE int
            IF (@CategoryId IS NOT NULL)
            BEGIN
			        SET @sql = @sql + ' AND CategoryId =  @CategoryId '
            END
					

				-- ParenCategoryId = TYPE int
            IF (@ParentCategoryId IS NOT NULL)
            BEGIN
			        SET @sql = @sql + ' AND ParentCategoryId =  @ParentCategoryId '
            END
					

				-- Name = TYPE nvarchar
             IF (@Name IS NOT NULL)
             BEGIN
			        SET @sql = @sql + ' AND Name  LIKE  @Name '
             END
					


	        IF (@OrdenDeRegistros IS NOT NULL AND @OrdenDeRegistros <> '')
	        BEGIN
		        SET @sql = @sql + ' ORDER BY ' + @OrdenDeRegistros
	        END

	        SELECT @parametros = '	@CategoryId int ,

	@ParentCategoryId int  = NULL,

	@Name nvarchar(50)  = NULL,

	@ApplicationId VARCHAR(36)  = NULL'

	        EXEC sp_executesql @sql, @parametros, @CategoryId, @ParentCategoryId, @Name, @ApplicationId
        END
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_Rules_g_exist]    Fecha de la secuencia de comandos: 10/30/2009 11:48:00 ******/
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
/****** Objeto:  StoredProcedure [dbo].[aspnet_Rules_i]    Fecha de la secuencia de comandos: 10/30/2009 11:47:57 ******/
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
/****** Objeto:  StoredProcedure [dbo].[aspnet_Rules_s]    Fecha de la secuencia de comandos: 10/30/2009 11:47:57 ******/
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
/****** Objeto:  StoredProcedure [dbo].[aspnet_Categories_s]    Fecha de la secuencia de comandos: 10/30/2009 11:48:00 ******/
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
/****** Objeto:  StoredProcedure [dbo].[aspnet_RulesCategory_s]    Fecha de la secuencia de comandos: 10/30/2009 11:47:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------------------
	        -- Author     :		 AAguirre
	        -- Date       :	   2009-07-01T15:14:29
	        -- Description: 	 Procedimiento de búsqueda de aspnet_RulesCategory.
	        --------------------------------------------------------------------------------------------
	CREATE PROCEDURE [dbo].[aspnet_RulesCategory_s]
	
	
	
	AS
					
					
	
  SELECT
  CategoryId
,ParentCategoryId
,Name
,ApplicationId

  FROM aspnet_RulesCategory
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_RulesCategory_i]    Fecha de la secuencia de comandos: 10/30/2009 11:47:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------------------
	        -- Author     :		 AAguirre
	        -- Date       :	   2009-07-01T15:14:29
	        -- Description: 	 Procedimiento de creación de aspnet_RulesCategory.
	        --------------------------------------------------------------------------------------------
	CREATE PROCEDURE [dbo].[aspnet_RulesCategory_i]
	
	(	@CategoryId int OUTPUT,
	@ParentCategoryId int  = NULL,
	@Name nvarchar(50)  = NULL,
	@ApplicationId VARCHAR(64)  = NULL
)
	
	AS
					
					
	
INSERT INTO aspnet_RulesCategory
(
ParentCategoryId
,Name
,ApplicationId

)
VALUES
(
	@ParentCategoryId,
	@Name,
	@ApplicationId

)
  
				
	        Set @CategoryId = @@Identity
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_RulesCategory_d]    Fecha de la secuencia de comandos: 10/30/2009 11:47:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------------------
	        -- Author     :		 AAguirre
	        -- Date       :	   2009-07-01T15:14:29
	        -- Description: 	 Procedimiento de eliminación de aspnet_RulesCategory.
	        --------------------------------------------------------------------------------------------
	CREATE PROCEDURE [dbo].[aspnet_RulesCategory_d]
	
	(	@CategoryId int 
)
	
	AS
					
					
	
DELETE FROM aspnet_RulesCategory
WHERE CategoryId = @CategoryId
GO
/****** Objeto:  StoredProcedure [dbo].[aspnet_RulesCategory_u]    Fecha de la secuencia de comandos: 10/30/2009 11:47:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------------------------------------------------------------------------
	        -- Author     :		 AAguirre
	        -- Date       :	   2009-07-01T15:14:29
	        -- Description: 	 Procedimiento de actualización de aspnet_RulesCategory.
	        --------------------------------------------------------------------------------------------
	CREATE PROCEDURE [dbo].[aspnet_RulesCategory_u]
	
	(	@CategoryId int ,
	@ParentCategoryId int  = NULL,
	@Name nvarchar(50)  = NULL,
	@ApplicationId VARCHAR(36)  = NULL
)
	
	AS
					
					
	
UPDATE aspnet_RulesCategory
SET 
ParentCategoryId = @ParentCategoryId,
Name = @Name,
ApplicationId = @ApplicationId

WHERE CategoryId = @CategoryId
GO
