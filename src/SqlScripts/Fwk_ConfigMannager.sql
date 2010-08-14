
/****** Object:  Table [dbo].[fwk_ConfigMannager]    Script Date: 08/05/2010 10:04:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fwk_ConfigMannager](
	[ConfigurationFileName] [nvarchar](50) NOT NULL,
	[group] [nvarchar](50) NOT NULL,
	[key] [nvarchar](50) NOT NULL,
	[encrypted] [bit] NOT NULL CONSTRAINT [DF_fwk_ConfigMannager_encrypted]  DEFAULT ((0)),
	[value] [nvarchar](1000) NULL,
 CONSTRAINT [PK_fwk_ConfigMannager_1] PRIMARY KEY CLUSTERED 
(
	[ConfigurationFileName] ASC,
	[group] ASC,
	[key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del grupo. Este valor agruma propiedades (keys)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fwk_ConfigMannager', @level2type=N'COLUMN',@level2name=N'group'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la propiedad. Ejemplo: RutaDeImagenes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fwk_ConfigMannager', @level2type=N'COLUMN',@level2name=N'key'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Determina si este valor esta encriptado en la base de datos o no' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fwk_ConfigMannager', @level2type=N'COLUMN',@level2name=N'encrypted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Valor de la propiedad' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fwk_ConfigMannager', @level2type=N'COLUMN',@level2name=N'value'