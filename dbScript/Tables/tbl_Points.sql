CREATE TABLE [dbo].[tbl_Points](
	[distroId] [int] NOT NULL,
	[Date] [date] NULL,
	[GoogleTrendsPoints] [decimal](18, 2) NULL,
	[GoogleTrendsPointsFinal] [decimal](18, 2) NULL,
	[GoogleTrendsWeightage] [decimal](18, 2) NULL,
	[DistroWatchPoints] [decimal](18, 2) NULL,
	[DistroWatchPointsFinal] [decimal](18, 2) NULL,
	[DistroWatchWeightage] [decimal](18, 2) NULL,
	[TotalPoints] [decimal](18, 2) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbl_Points] ADD  CONSTRAINT [DF_tbl_Points_Date]  DEFAULT (getdate()) FOR [Date]
GO


