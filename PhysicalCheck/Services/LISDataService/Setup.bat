@echo off
set CURRENT_DIR=%cd%
installutil  %CURRENT_DIR%\LISDataService.exe
net start LISDataService

