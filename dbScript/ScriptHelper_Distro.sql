use distroTrends

SELECT *
FROM tbl_distro

SELECT *
FROM tbl_Edition

SELECT *
FROM tbl_Version

SELECT *
FROM tbl_DistroEdition


SELECT * FROM tbl_Edition E
Inner Join tbl_DistroEdition D ON E.Id = D.EditionId
Where D.DistroId = 3

--Fetch Distro Info
select D.*, DE.*, V.*
from tbl_Version V
Inner Join tbl_DistroEdition DE ON V.DistroEditionId = DE.Id
Inner Join tbl_Distro D on D.Id = DE.DistroId
Inner Join tbl_Edition E on E.Id = DE.EditionId
Order By D.Id

