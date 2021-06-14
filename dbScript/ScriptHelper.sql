use distroTrends

SELECT *
FROM tbl_distro

SELECT *
FROM tbl_Edition

SELECT *
FROM tbl_Version

SELECT *
FROM tbl_DistroEdition

SELECT *
FROM tbl_EditionVersion

SELECT * FROM tbl_Edition E
Inner Join tbl_DistroEdition D ON E.Id = D.EditionId
Where D.DistroId = 3

select * from tbl_Points
where distroId = 1
Order by Date Desc;

--truncate table tbl_Points

exec sp_CalculatePoints