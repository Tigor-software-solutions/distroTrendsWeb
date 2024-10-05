set server = "236PCWIN11\SQLEXPRESS"
set database = "distroTrends"
set folderInput = Tables\MasterData\
set folderOutput = Output\MasterData\

mkdir %folderInput %
mkdir %folderOutput %

sqlcmd -S %server % -d %database % -i %folderInput %tbl_Distro.sql -o %folderOutput %tbl_Distro.txt
sqlcmd -S %server % -d %database % -i %folderInput %tbl_Edition.sql -o %folderOutput %tbl_Edition.txt
sqlcmd -S %server % -d %database % -i %folderInput %tbl_Version.sql -o %folderOutput %tbl_Version.txt

pause
echo Execution complete, please check output.txt for results.
