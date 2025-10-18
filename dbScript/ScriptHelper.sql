use distroTrends

SELECT *
FROM tbl_distro

SELECT *
FROM tbl_Edition

SELECT *
FROM tbl_Version

SELECT *
FROM tbl_UserType

select * 
from tbl_user

select * 
from tbl_rating

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

update tbl_Distro
set Description = 'Ubuntu Desc'
where Code = 'UBUNTU'

select * from tbl_Distro_Log

--Fetch Ratings
select D.Name, E.Name, U.Name, Usability, Stability, UserFriendly 
from tbl_Rating R
Inner Join tbl_DistroEdition DE ON R.DistroEditionId = DE.Id
Inner Join tbl_User U ON R.UserId = U.Id
Inner Join tbl_Distro D on D.Id = DE.DistroId
Inner Join tbl_Edition E on E.Id = DE.EditionId


--
LinuxMint	2.500000	5.000000	5
Ubuntu	2.500000	4.500000	5

--Fetch Ratings
select D.Name, AVG(CAST(Usability AS DECIMAL(10,1))) as Usability, AVG(CAST(Stability AS DECIMAL(10,1))) as Stability, AVG(UserFriendly) as UserFriendly
from tbl_Rating R
Inner Join tbl_DistroEdition DE ON R.DistroEditionId = DE.Id
Inner Join tbl_User U ON R.UserId = U.Id
Inner Join tbl_Distro D on D.Id = DE.DistroId
Inner Join tbl_Edition E on E.Id = DE.EditionId
Group By D.Name


