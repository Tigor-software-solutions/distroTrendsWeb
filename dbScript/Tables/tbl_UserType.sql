CREATE TABLE [dbo].[tbl_UserType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
	[Description] [varchar](200) NOT NULL
) ON [PRIMARY]
GO