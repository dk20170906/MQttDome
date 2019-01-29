@echo.请稍等，MqttNetServiceAddUserAndPassword服务安装启中............

@echo off

@title 安装windows服务：MqttNetServiceAddUserAndPassword

@sc create MqttNetServiceAddUserAndPassword binPath="%~dp0\MqttNetServiceAddUserAndPassword.exe" 

@sc config MqttNetServiceAddUserAndPassword start= auto

@sc start MqttNetServiceAddUserAndPassword
@echo.MqttNetServiceAddUserAndPassword启动完毕
pause

