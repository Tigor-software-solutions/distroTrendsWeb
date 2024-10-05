IF NOT EXISTS (
		SELECT *
		FROM [tbl_Version]
		WHERE [Name] = '20.1'
			AND distroId = (
				SELECT Id
				FROM tbl_Distro
				WHERE Code = 'LINUXMIN'
				)
		)
BEGIN
	INSERT INTO [dbo].[tbl_Version] (
		distroId
		,[Name]
		,[ReleaseDate]
		)
	VALUES (
		(
			SELECT Id
			FROM tbl_Distro
			WHERE Code = 'LINUXMIN'
			)
		,'20.1'
		,'2021-01-08'
		)
END
GO

IF NOT EXISTS (
		SELECT *
		FROM [tbl_Version]
		WHERE [Name] = '22'
			AND distroId = (
				SELECT Id
				FROM tbl_Distro
				WHERE Code = 'LINUXMIN'
				)
		)
BEGIN
	INSERT INTO [dbo].[tbl_Version] (
		distroId
		,[Name]
		,[ReleaseDate]
		)
	VALUES (
		(
			SELECT Id
			FROM tbl_Distro
			WHERE Code = 'LINUXMIN'
			)
		,'22'
		,'2024-07-25'
		)
END
GO


