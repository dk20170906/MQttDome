@echo.���Եȣ�����װ������............
@echo off
@title ��װwindows����MQTTNetService
@sc create MQTTNetService binPath="%~dp0\MQTTNetService.exe"
@sc config MQTTNetService start= auto
@sc start MQTTNetService 
@echo.�������
pause