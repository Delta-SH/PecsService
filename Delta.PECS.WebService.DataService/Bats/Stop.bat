echo off
echo ****************************
echo ж��DataService����
echo ****************************
pause
cd /d "%~dp0"
echo *����ֹͣ����. . .
sc stop "DataService" > InstallService.log
echo *������ֹͣ
echo *����ж�ط���. . .
%SystemRoot%\Microsoft.NET\Framework\v2.0.50727\installutil /LogFile= /u DataService.exe >> InstallService.log
echo *����ж�����
echo *��ϸ��־�鿴InstallService.log
pause