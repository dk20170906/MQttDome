@echo.���Եȣ�MQTTNetServiceAddUser����װ������............
@echo off
@title ��װwindows����MQTTNetServiceAddUser
@sc create MQTTNetServiceAddUser binPath="%~dp0\MQTTNetService.exe"
@sc config MQTTNetServiceAddUser start= auto
@sc start MQTTNetServiceAddUser
@echo.MQTTNetServiceAddUser�����������
pause


