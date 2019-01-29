@echo.服务MqttNetServiceAddUserAndPassword卸载中..........

@echo off

@sc stop MqttNetServiceAddUserAndPassword

@sc delete MqttNetServiceAddUserAndPassword
@echo off

@echo.MqttNetServiceAddUserAndPassword卸载完毕

@pause