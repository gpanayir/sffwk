%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_regsql.exe -E -S localhost -d pubs -A all -sqlexportonly c:\membership.sql
pause



%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_regsql.exe -E -S localhost -d pepo -A all -sqlexportonly c:\membership.sql

aspnet_regsql.exe -S <Server> -U <Username> -P <Password> -ed -d Northwind -et -t Employees