call "00_Config.bat"

sqlcmd -S %server % -i CreateDb.sql -o Output\output.txt
pause
echo Now about to end...
