CREATE TABLE [dbo].[tbl_Distro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](8) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Description] [varchar](1000) NULL,
	[ImageURL] [varchar](50) NULL,
	[HomePage] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_Distro] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


