rem echo off
Powershell.exe -executionpolicy remotesigned -File .\getlibs.ps1
set /p toto=Finish [y/n]?: