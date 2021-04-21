USE [distroTrends]
GO
IF NOT EXISTS (
	SELECT * 
	FROM Distro 
	WHERE Code ='UBUNTU'
)
BEGIN
INSERT INTO [dbo].[Distro]
           ([Code]
           ,[Name]
           ,[Description]
           ,[HomePage])
     VALUES
           ('UBUNTU'
           ,'Ubuntu'
           ,'Ubuntu Desc'
           ,'ubuntu.com')
		   END
GO

IF NOT EXISTS (
	SELECT * 
	FROM Distro 
	WHERE Code ='ZORIN'
)
BEGIN
INSERT INTO [dbo].[Distro]
           ([Code]
           ,[Name]
           ,[Description]
           ,[HomePage])
     VALUES
           ('ZORIN'
           ,'Zorin'
           ,'Zorin Desc'
           ,'https://zorinos.com/')
END
GO



