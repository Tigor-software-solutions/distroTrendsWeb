CREATE TABLE [dbo].[tbl_Rating]
(
	[Id] [int] IDENTITY (1,1) NOT NULL,
	[DistroEditionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Usability] [tinyint] NULL,
	[Stability] [tinyint] NULL,
	[UserFriendly] [tinyint] NULL,
	CONSTRAINT [PK_tbl_Rating] PRIMARY KEY CLUSTERED
	(
		[Id] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	CONSTRAINT [IX_tbl_Rating] UNIQUE NONCLUSTERED
	(
		[DistroEditionId] ASC,
		[UserId] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY  = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
	CONSTRAINT [FK_tbl_Rating_tbl_DistroEdition] FOREIGN KEY
	(
		[DistroEditionId]
	)
	REFERENCES [dbo].[tbl_DistroEdition]
	(
		[Id]
	),
	CONSTRAINT [FK_tbl_Rating_tbl_Rating] FOREIGN KEY
	(
		[UserId]
	)
	REFERENCES [dbo].[tbl_User]
	(
		[Id]
	)
) ON [PRIMARY]
GO
