IF NOT EXISTS (
		SELECT *
		FROM [tbl_Edition]
		WHERE [Name] = 'Cinnamon'
		)
BEGIN
	INSERT INTO [dbo].[tbl_Edition] ([Name])
	VALUES ('Cinnamon')
END
GO

IF NOT EXISTS (
		SELECT *
		FROM [tbl_Edition]
		WHERE [Name] = 'MATE'
		)
BEGIN
	INSERT INTO [dbo].[tbl_Edition] ([Name])
	VALUES ('MATE')
END
GO

IF NOT EXISTS (
		SELECT *
		FROM [tbl_Edition]
		WHERE [Name] = 'Xfce'
		)
BEGIN
	INSERT INTO [dbo].[tbl_Edition] ([Name])
	VALUES ('Xfce')
END
GO


