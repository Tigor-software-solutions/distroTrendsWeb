USE [distroTrends]
GO

/****** Object:  Table [dbo].[tbl_Points]    Script Date: 04-06-2021 10:10:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Points](
	[distroId] [int] NOT NULL,
	[Date] [datetime] NULL,
	[GoogleTrendsPoints] [decimal](18, 2) NULL,
	[GoogleTrendsPointsFinal] [decimal](18, 2) NULL,
	[GoogleTrendsWeightage] [decimal](18, 2) NULL,
	[DistroWatchPoints] [decimal](18, 2) NULL,
	[DistroWatchPointsFinal] [decimal](18, 2) NULL,
	[DistroWatchWeightage] [decimal](18, 2) NULL,
	[TotalPoints] [decimal](18, 2) NULL
) ON [PRIMARY]
GO


