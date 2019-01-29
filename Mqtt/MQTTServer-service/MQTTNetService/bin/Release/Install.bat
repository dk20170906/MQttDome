@echo.请稍等，服务安装启动中............
@echo off
@title 安装windows服务：MQTTNetService
@sc create MQTTNetService binPath="%~dp0\MQTTNetService.exe"
@sc config MQTTNetService start= auto
@sc start MQTTNetService 
@echo.启动完毕
pause