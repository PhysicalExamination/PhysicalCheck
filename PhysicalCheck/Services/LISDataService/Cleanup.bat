@echo off
net stop LISDataService
set CURRENT_DIR=%cd%
installutil /u %CURRENT_DIR%\LISDataService.exe
