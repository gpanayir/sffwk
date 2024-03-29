
/****** Object:  Table [dbo].[fwk_ConfigManager]    Script Date: 08/05/2010 10:04:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fwk_ConfigManager](
	[ConfigurationFileName] [nvarchar](50) NOT NULL,
	[group] [nvarchar](50) NOT NULL,
	[key] [nvarchar](50) NOT NULL,
	[encrypted] [bit] NOT NULL CONSTRAINT [DF_fwk_ConfigManager_encrypted]  DEFAULT ((0)),
	[value] [nvarchar](1000) NULL,
 CONSTRAINT [PK_fwk_ConfigManager_1] PRIMARY KEY CLUSTERED 
(
	[ConfigurationFileName] ASC,
	[group] ASC,
	[key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del grupo. Este valor agruma propiedades (keys)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fwk_ConfigManager', @level2type=N'COLUMN',@level2name=N'group'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la propiedad. Ejemplo: RutaDeImagenes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fwk_ConfigManager', @level2type=N'COLUMN',@level2name=N'key'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Determina si este valor esta encriptado en la base de datos o no' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fwk_ConfigManager', @level2type=N'COLUMN',@level2name=N'encrypted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor de la propiedad' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fwk_ConfigManager', @level2type=N'COLUMN',@level2name=N'value'


GO
/****** Objeto:  StoredProcedure [dbo].[fwk_ConfigManager_PIVOT]    Fecha de la secuencia de comandos: 07/26/2012 14:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



 CREATE PROCEDURE [dbo].[fwk_ConfigManager_PIVOT]
      @columns VARCHAR(2000)
 AS
 --DECLARE @columns2 VARCHAR(2000)
--SET @columns2 = 'bb_config.en-US,bb_config.es-AR,bb_config.es-AR_local'
                             
 
DECLARE @query VARCHAR(4000)
 
SET @query = '
Select [group],[key] , ' + @columns + ' FROM (
SELECT *
FROM fwk_ConfigManager) p
PIVOT
(
MAX([value])
FOR ConfigurationFileName IN (' + @columns + ')
)
AS p'
--select @query
EXECUTE(@query)
----SELECT * FROM fwk_ConfigManager
--SELECT [key] ,[bb_config.en-ES] ,[bb_config.es-AR] FROM (
--
--SELECT * FROM fwk_ConfigManager) p
--PIVOT
--( 
--MAX([value])
--	FOR ConfigurationFileName IN ([bb_config.en-ES] ,[bb_config.es-AR])
--)
--AS p
--
