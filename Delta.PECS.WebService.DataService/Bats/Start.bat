echo off
echo ****************************
echo 安装DataService服务
echo ****************************
pause
cd /d "%~dp0"
echo *正在安装服务. . .
%SystemRoot%\Microsoft.NET\Framework\v2.0.50727\installutil /LogFile= DataService.exe > InstallService.log
echo *服务安装完成
echo *正在启动服务. . .
sc failure "DataService" reset= 86400 actions= restart/60000 >> InstallService.log
sc start "DataService" >> InstallService.log
echo *服务启动完成
echo *详细日志查看InstallService.log
pause

