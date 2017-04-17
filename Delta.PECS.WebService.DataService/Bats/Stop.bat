echo off
echo ****************************
echo 卸载DataService服务
echo ****************************
pause
cd /d "%~dp0"
echo *正在停止服务. . .
sc stop "DataService" > InstallService.log
echo *服务已停止
echo *正在卸载服务. . .
%SystemRoot%\Microsoft.NET\Framework\v2.0.50727\installutil /LogFile= /u DataService.exe >> InstallService.log
echo *服务卸载完成
echo *详细日志查看InstallService.log
pause