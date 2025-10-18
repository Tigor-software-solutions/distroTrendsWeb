call "00_Config.bat"

mkdir Output

sqlcmd -S %server % -d %database % -U %username % -P %password % -i Tables\tbl_Distro.sql -o Output\tbl_Distro.txt

sqlcmd -S %server % -d %database % -U %username % -P %password % -i Tables\tbl_Edition.sql -o Output\tbl_Edition.txt

sqlcmd -S %server % -d %database % -U %username % -P %password % -i Tables\tbl_DistroEdition.sql -o Output\tbl_DistroEdition.txt

sqlcmd -S %server % -d %database % -U %username % -P %password % -i Tables\tbl_User.sql -o Output\tbl_User.txt

sqlcmd -S %server % -d %database % -U %username % -P %password % -i Tables\tbl_Rating.sql -o Output\tbl_Rating.txt

sqlcmd -S %server % -d %database % -U %username % -P %password % -i Tables\tbl_UsageType.sql -o Output\tbl_UsageType.txt

sqlcmd -S %server % -d %database % -U %username % -P %password % -i Tables\tbl_UserType.sql -o Output\tbl_UserType.txt

sqlcmd -S %server % -d %database % -U %username % -P %password % -i Tables\tbl_Version.sql -o Output\tbl_Version.txt

sqlcmd -S %server % -d %database % -i Tables\tbl_User.sql -o Output\tbl_User.txt

pause
echo Execution complete, please check output.txt for results.
