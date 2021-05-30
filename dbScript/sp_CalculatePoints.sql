CREATE
	OR

ALTER PROCEDURE sp_CalculatePoints
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @distroId DECIMAL(18, 2);
	DECLARE @date DATETIME;
	DECLARE @GoogleTrendsPoints DECIMAL(18, 2);
	DECLARE @DistroWatchPoints DECIMAL(18, 2);
	DECLARE @GoogleTrendsPointsFinal DECIMAL(18, 2);
	DECLARE @GoogleTrendsWeightage DECIMAL(18, 2);
	DECLARE @DistroWatchPointsFinal DECIMAL(18, 2);
	DECLARE @DistroWatchWeightage DECIMAL(18, 2);
	DECLARE @TotalPoints DECIMAL(18, 2);

	DECLARE db_cursor CURSOR
	FOR
	SELECT distroId
		,DATE
		,GoogleTrendsPoints
		,DistroWatchPoints
	FROM tbl_Point
	WHERE TotalPoints IS NULL

	OPEN db_cursor

	FETCH NEXT
	FROM db_cursor
	INTO @distroId
		,@date
		,@GoogleTrendsPoints
		,@DistroWatchPoints

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @GoogleTrendsPointsFinal = @GoogleTrendsPoints * 0.1;
		SET @GoogleTrendsWeightage = @GoogleTrendsPointsFinal * 0.7;
		SET @DistroWatchPointsFinal = @DistroWatchPoints * 0.1;
		SET @DistroWatchWeightage = @DistroWatchPointsFinal * 0.3;
		SET @TotalPoints = @GoogleTrendsWeightage + @DistroWatchWeightage;

		UPDATE tbl_Point
		SET GoogleTrendsPointsFinal = @GoogleTrendsPointsFinal
			,GoogleTrendsWeightage = @GoogleTrendsWeightage
			,DistroWatchPointsFinal = @DistroWatchPointsFinal
			,DistroWatchWeightage = @DistroWatchWeightage
			,TotalPoints = @TotalPoints
		WHERE distroId = @distroId

		FETCH NEXT
		FROM db_cursor
		INTO @distroId
			,@date
			,@GoogleTrendsPoints
			,@DistroWatchPoints
	END

	CLOSE db_cursor

	DEALLOCATE db_cursor
END
GO


