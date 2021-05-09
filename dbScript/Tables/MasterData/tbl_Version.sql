IF NOT EXISTS (
		SELECT *
		FROM [tbl_Version]
		WHERE [Name] = '20.1'
		)
BEGIN
	INSERT INTO [dbo].[tbl_Version] (
		[Name]
		,[ReleaseDate]
		)
	VALUES (
		'20.1'
		,'2021-01-08'
		)
END
GO


