CREATE TABLE [dbo].[Distro] (
	[Id] [int] IDENTITY(1, 1) NOT NULL
	,[Code] [nchar](8) NOT NULL
	,[Name] [varchar](50) NOT NULL
	,[Description] [varchar](200) NULL
	,[HomePage] [varchar](200) NULL
	) ON [PRIMARY]
GO


