set server = "236PCWIN11\SQLEXPRESS"
set database = "distroTrends"

mkdir Output

sqlcmd -S %server % -d %database % -i Tables\tbl_Distro.sql -o Output\tbl_Distro.txt

sqlcmd -S %server % -d %database % -i Tables\tbl_Edition.sql -o Output\tbl_Edition.txt

sqlcmd -S %server % -d %database % -i Tables\tbl_Version.sql -o Output\tbl_Version.txt

pause
echo Execution complete, please check output.txt for results.
