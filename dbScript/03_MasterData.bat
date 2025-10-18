call "00_Config.bat"

set folderInput = Tables\MasterData\
set folderOutput = Output\MasterData\

mkdir %folderInput %
mkdir %folderOutput %

sqlcmd -S %server % -d %database % -U %username % -P %password % -i %folderInput %tbl_Distro.sql -o %folderOutput %tbl_Distro.txt
sqlcmd -S %server % -d %database % -U %username % -P %password % -i %folderInput %tbl_Edition.sql -o %folderOutput %tbl_Edition.txt
sqlcmd -S %server % -d %database % -U %username % -P %password % -i %folderInput %tbl_EditionVersion.sql -o %folderOutput %tbl_EditionVersion.txt
sqlcmd -S %server % -d %database % -U %username % -P %password % -i %folderInput %tbl_DistroEdition.sql -o %folderOutput %tbl_DistroEdition.txt
sqlcmd -S %server % -d %database % -U %username % -P %password % -i %folderInput %tbl_UsageType.sql -o %folderOutput %tbl_UsageType.txt
sqlcmd -S %server % -d %database % -U %username % -P %password % -i %folderInput %tbl_Version.sql -o %folderOutput %tbl_Version.txt

pause
echo Execution complete, please check output.txt for results.
