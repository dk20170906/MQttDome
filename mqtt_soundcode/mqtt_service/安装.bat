@echo.���Եȣ�MqttNetServiceAddUserAndPassword����װ����............

@echo off

@title ��װwindows����MqttNetServiceAddUserAndPassword

@sc create MqttNetServiceAddUserAndPassword binPath="%~dp0\MqttNetServiceAddUserAndPassword.exe" 

@sc config MqttNetServiceAddUserAndPassword start= auto

@sc start MqttNetServiceAddUserAndPassword
@echo.MqttNetServiceAddUserAndPassword�������
pause

