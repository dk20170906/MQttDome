@echo.服务卸载中..........
@echo off
@sc stop MQTTNetService
@sc delete MQTTNetService
@sc stop MQTTNetService
@echo off
@echo.卸载完毕
@pause