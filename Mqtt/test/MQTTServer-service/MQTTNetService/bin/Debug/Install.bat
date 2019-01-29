@echo.请稍等，MQTTNetServiceAddUser服务安装启动中............
@echo off
@title 安装windows服务：MQTTNetServiceAddUser
@sc create MQTTNetServiceAddUser binPath="%~dp0\MQTTNetService.exe"
@sc config MQTTNetServiceAddUser start= auto
@sc start MQTTNetServiceAddUser
@echo.MQTTNetServiceAddUser服务启动完毕
pause


