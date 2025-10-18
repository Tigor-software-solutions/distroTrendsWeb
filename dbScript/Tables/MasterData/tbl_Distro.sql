IF NOT EXISTS (
		SELECT *
		FROM tbl_Distro
		WHERE Code = 'UBUNTU'
		)
BEGIN
	INSERT INTO [dbo].[tbl_Distro] (
		[Code]
		,[Name]
		,[Description]
		,[HomePage]
		)
	VALUES (
		'UBUNTU'
		,'Ubuntu'
		,'Ubuntu Desc'
		,'https://ubuntu.com'
		)
END
GO

IF NOT EXISTS (
		SELECT *
		FROM tbl_Distro
		WHERE Code = 'ZORIN'
		)
BEGIN
	INSERT INTO [dbo].tbl_Distro (
		[Code]
		,[Name]
		,[Description]
		,[HomePage]
		)
	VALUES (
		'ZORIN'
		,'Zorin'
		,'Zorin Desc'
		,'https://zorinos.com/'
		)
END
GO

IF NOT EXISTS (
		SELECT *
		FROM tbl_Distro
		WHERE Code = 'LINUXMIN'
		)
BEGIN
	INSERT INTO [dbo].tbl_Distro (
		[Code]
		,[Name]
		,[Description]
		,[HomePage]
		)
	VALUES (
		'LINUXMIN'
		,'LinuxMint'
		,'Linux Mint Desc'
		,'https://linuxmint.com/'
		)
END
GO


