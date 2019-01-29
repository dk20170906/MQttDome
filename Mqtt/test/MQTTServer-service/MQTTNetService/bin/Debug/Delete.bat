@echo.MQTTNetServiceAddUser服务卸载中..........
@echo off
@sc stop MQTTNetServiceAddUser
@sc delete MQTTNetServiceAddUser
@echo off
@echo.MQTTNetServiceAddUser卸载完毕
@pause