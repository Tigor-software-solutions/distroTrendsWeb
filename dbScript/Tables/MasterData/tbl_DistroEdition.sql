CREATE TABLE #myTable (
	Code NCHAR(8)
	,Name NVARCHAR(50)
	)

--Insert data into Temporary Tables    
INSERT INTO #myTable
VALUES (
	'UBUNTU'
	,'GNOME'
	);

INSERT INTO #myTable
VALUES (
	'LINUXMIN'
	,'Cinnamon'
	);

INSERT INTO #myTable
VALUES (
	'LINUXMIN'
	,'MATE'
	);

INSERT INTO #myTable
VALUES (
	'LINUXMIN'
	,'Xfce'
	);

INSERT INTO #myTable
VALUES (
	'ZORIN'
	,'GNOME'
	);

DECLARE @Code NCHAR(8)
DECLARE @Name VARCHAR(50)

DECLARE db_cursor CURSOR
FOR
SELECT Code
	,Name
FROM #myTable

OPEN db_cursor

FETCH NEXT
FROM db_cursor
INTO @Code
	,@Name

WHILE @@FETCH_STATUS = 0
BEGIN
	IF NOT EXISTS (
			SELECT *
			FROM tbl_DistroEdition
			WHERE DistroId = (
					SELECT id
					FROM tbl_Distro
					WHERE code = @Code
					)
				AND EditionId = (
					SELECT id
					FROM tbl_Edition
					WHERE [Name] = @Name
					)
			)
	BEGIN
		INSERT INTO [dbo].[tbl_DistroEdition] (
			[DistroId]
			,[EditionId]
			)
		VALUES (
			(
				SELECT id
				FROM tbl_Distro
				WHERE code = @Code
				)
			,(
				SELECT id
				FROM tbl_Edition
				WHERE [Name] = @Name
				)
			)
	END

	FETCH NEXT
	FROM db_cursor
	INTO @Code
		,@Name
END

CLOSE db_cursor

DEALLOCATE db_cursor

DROP TABLE #myTable
	/*
INSERT INTO [dbo].[tbl_DistroEdition] (
	[DistroId]
	,[EditionId]
	)
VALUES (
	(
		SELECT id
		FROM tbl_Distro
		WHERE code = 'Mint'
		)
	,(
		SELECT id
		FROM tbl_Edition
		WHERE [Name] = 'Cinnamon'
		)
	)
GO
*/
