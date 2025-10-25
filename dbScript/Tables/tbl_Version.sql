CREATE TABLE [dbo].[tbl_Version](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DistroEditionId] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[ReleaseDate] [date] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbl_Version]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Version_tbl_DistroEdition] FOREIGN KEY([DistroEditionId])
REFERENCES [dbo].[tbl_DistroEdition] ([Id])
GO

ALTER TABLE [dbo].[tbl_Version] CHECK CONSTRAINT [FK_tbl_Version_tbl_DistroEdition]
GO