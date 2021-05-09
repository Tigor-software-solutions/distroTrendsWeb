CREATE TABLE #myTable (
	NameE NVARCHAR(50)
	,NameV NVARCHAR(50)
	)

--Insert data into Temporary Tables    
INSERT INTO #myTable
VALUES (
	'Cinnamon'
	,'20.1'
	);

INSERT INTO #myTable
VALUES (
	'MATE'
	,'20.1'
	);

INSERT INTO #myTable
VALUES (
	'Xfce'
	,'20.1'
	);

DECLARE @NameE VARCHAR(50)
DECLARE @NameV VARCHAR(50)

DECLARE db_cursor CURSOR
FOR
SELECT NameE
	,NameV
FROM #myTable

OPEN db_cursor

FETCH NEXT
FROM db_cursor
INTO @NameE
	,@NameV

WHILE @@FETCH_STATUS = 0
BEGIN
	IF NOT EXISTS (
			SELECT *
			FROM tbl_EditionVersion
			WHERE
				EditionId = (
					SELECT id
					FROM tbl_Edition
					WHERE [Name] = @NameE
					)
				AND VersionId = (
					SELECT id
					FROM tbl_Version
					WHERE [Name] = @NameV
					)
			)
	BEGIN
		INSERT INTO [dbo].[tbl_EditionVersion] (
			[EditionId]
			,[VersionId]
			)
		VALUES (
			(
				SELECT id
				FROM tbl_Edition
				WHERE [Name] = @NameE
				)
			,(
				SELECT id
				FROM tbl_Version
				WHERE [Name] = @NameV
				)
			)
	END

	FETCH NEXT
	FROM db_cursor
	INTO @NameE
		,@NameV
END

CLOSE db_cursor

DEALLOCATE db_cursor

DROP TABLE #myTable
