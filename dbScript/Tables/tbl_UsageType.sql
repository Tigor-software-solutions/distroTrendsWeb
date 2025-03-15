CREATE TABLE [dbo].[tbl_UsageType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](4) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](200) NOT NULL
) ON [PRIMARY]
GO