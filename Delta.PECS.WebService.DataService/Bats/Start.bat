echo off
echo ****************************
echo ��װDataService����
echo ****************************
pause
cd /d "%~dp0"
echo *���ڰ�װ����. . .
%SystemRoot%\Microsoft.NET\Framework\v2.0.50727\installutil /LogFile= DataService.exe > InstallService.log
echo *����װ���
echo *������������. . .
sc failure "DataService" reset= 86400 actions= restart/60000 >> InstallService.log
sc start "DataService" >> InstallService.log
echo *�����������
echo *��ϸ��־�鿴InstallService.log
pause

