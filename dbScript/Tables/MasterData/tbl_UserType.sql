IF NOT EXISTS (
		SELECT *
		FROM tbl_UserType
		WHERE Code = 'SD'
		)
BEGIN
	INSERT INTO [dbo].[tbl_UserType] (
		[Code]
		,[Name]
		,[Description]
		)
	VALUES (
		"SD"
		,"Software Developer"
		,"Software Developer"
		)
END
GO

IF NOT EXISTS (
		SELECT *
		FROM tbl_UserType
		WHERE Code = 'HU'
		)
BEGIN
	INSERT INTO [dbo].[tbl_UserType] (
		[Code]
		,[Name]
		,[Description]
		)
	VALUES (
		"HU"
		,"Home User"
		,"Home User"
		)
END
GO

IF NOT EXISTS (
		SELECT *
		FROM tbl_UserType
		WHERE Code = 'S'
		)
BEGIN
	INSERT INTO [dbo].[tbl_UserType] (
		[Code]
		,[Name]
		,[Description]
		)
	VALUES (
		"S"
		,"Student"
		,"Student"
		)
END
GO

IF NOT EXISTS (
		SELECT *
		FROM tbl_UserType
		WHERE Code = 'Pro'
		)
BEGIN
	INSERT INTO [dbo].[tbl_UserType] (
		[Code]
		,[Name]
		,[Description]
		)
	VALUES (
		"Pro"
		,"Professional"
		,"Professional"
		)
END
GO


