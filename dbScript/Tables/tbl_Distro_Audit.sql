CREATE TABLE [dbo].[tbl_Distro_Audit] (
    [AuditId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [DistroId] [int] NOT NULL, -- References tbl_Distro.Id
    [Code] [varchar](8) NOT NULL,
    [Name] [varchar](20) NOT NULL,
    [Description] [varchar](1000) NULL,
    [ImageURL] [varchar](50) NULL,
    [HomePage] [varchar](50) NULL,
    [ActionType] BIT NOT NULL, -- 'INSERT', 'UPDATE', 'DELETE'
    [ChangedBy] [varchar](20) NOT NULL, -- Username or system identifier
    [ChangedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [ChangeReason] [varchar](200) NULL -- Optional: reason for change
);