IF NOT EXISTS (
		SELECT *
		FROM [tbl_Version]
		WHERE [Name] = '20.1'
			AND DistroEditionId = (
				SELECT DE.Id
				FROM tbl_DistroEdition DE
				INNER JOIN tbl_Distro D ON D.Id = DE.DistroId
				INNER JOIN tbl_Edition E ON DE.EditionId = E.Id
				WHERE Code = 'LINUXMIN'
					AND E.Name = 'Cinnamon'
				)
		)
BEGIN
	INSERT INTO [dbo].[tbl_Version] (
		[DistroEditionId]
		,[Name]
		,[ReleaseDate]
		)
	VALUES (
		(
			SELECT DE.Id
				FROM tbl_DistroEdition DE
				INNER JOIN tbl_Distro D ON D.Id = DE.DistroId
				INNER JOIN tbl_Edition E ON DE.EditionId = E.Id
				WHERE Code = 'LINUXMIN'
					AND E.Name = 'Cinnamon'
			)
		,'20.1'
		,'2021-01-08'
		)
END
GO

IF NOT EXISTS (
		SELECT *
		FROM [tbl_Version]
		WHERE [Name] = '20.1'
			AND DistroEditionId = (
				SELECT DE.Id
				FROM tbl_DistroEdition DE
				INNER JOIN tbl_Distro D ON D.Id = DE.DistroId
				INNER JOIN tbl_Edition E ON DE.EditionId = E.Id
				WHERE Code = 'LINUXMIN'
					AND E.Name = 'MATE'
				)
		)
BEGIN
	INSERT INTO [dbo].[tbl_Version] (
		[DistroEditionId]
		,[Name]
		,[ReleaseDate]
		)
	VALUES (
		(
			SELECT DE.Id
				FROM tbl_DistroEdition DE
				INNER JOIN tbl_Distro D ON D.Id = DE.DistroId
				INNER JOIN tbl_Edition E ON DE.EditionId = E.Id
				WHERE Code = 'LINUXMIN'
					AND E.Name = 'MATE'
			)
		,'20.1'
		,'2021-01-08'
		)
END
GO


IF NOT EXISTS (
		SELECT *
		FROM [tbl_Version]
		WHERE [Name] = '22.2'
			AND DistroEditionId = (
				SELECT DE.Id
				FROM tbl_DistroEdition DE
				INNER JOIN tbl_Distro D ON D.Id = DE.DistroId
				INNER JOIN tbl_Edition E ON DE.EditionId = E.Id
				WHERE Code = 'LINUXMIN'
					AND E.Name = 'Cinnamon'
				)
		)
BEGIN
	INSERT INTO [dbo].[tbl_Version] (
		[DistroEditionId]
		,[Name]
		,[ReleaseDate]
		)
	VALUES (
		(
			SELECT DE.Id
				FROM tbl_DistroEdition DE
				INNER JOIN tbl_Distro D ON D.Id = DE.DistroId
				INNER JOIN tbl_Edition E ON DE.EditionId = E.Id
				WHERE Code = 'LINUXMIN'
					AND E.Name = 'Cinnamon'
			)
		,'22.2'
		,'2025-09-04'
		)
END
GO


IF NOT EXISTS (
		SELECT *
		FROM [tbl_Version]
		WHERE [Name] = '25.10'
			AND DistroEditionId = (
				SELECT DE.Id
				FROM tbl_DistroEdition DE
				INNER JOIN tbl_Distro D ON D.Id = DE.DistroId
				INNER JOIN tbl_Edition E ON DE.EditionId = E.Id
				WHERE Code = 'UBUNTU'
					AND E.Name = 'GNOME'
				)
		)
BEGIN
	INSERT INTO [dbo].[tbl_Version] (
		[DistroEditionId]
		,[Name]
		,[ReleaseDate]
		)
	VALUES (
		(
			SELECT DE.Id
				FROM tbl_DistroEdition DE
				INNER JOIN tbl_Distro D ON D.Id = DE.DistroId
				INNER JOIN tbl_Edition E ON DE.EditionId = E.Id
				WHERE Code = 'UBUNTU'
					AND E.Name = 'GNOME'
			)
		,'25.10'
		,'2025-10-09'
		)
END
GO


IF NOT EXISTS (
		SELECT *
		FROM [tbl_Version]
		WHERE [Name] = '18'
			AND DistroEditionId = (
				SELECT DE.Id
				FROM tbl_DistroEdition DE
				INNER JOIN tbl_Distro D ON D.Id = DE.DistroId
				INNER JOIN tbl_Edition E ON DE.EditionId = E.Id
				WHERE Code = 'ZORIN'
					AND E.Name = 'GNOME'
				)
		)
BEGIN
	INSERT INTO [dbo].[tbl_Version] (
		[DistroEditionId]
		,[Name]
		,[ReleaseDate]
		)
	VALUES (
		(
			SELECT DE.Id
				FROM tbl_DistroEdition DE
				INNER JOIN tbl_Distro D ON D.Id = DE.DistroId
				INNER JOIN tbl_Edition E ON DE.EditionId = E.Id
				WHERE Code = 'ZORIN'
					AND E.Name = 'GNOME'
			)
		,'18'
		,'2025-10-14'
		)
END
GO

