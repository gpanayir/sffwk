


@ECHO OFF

cd C:\Archivos de programa\Microsoft Visual Studio 9.0\VC

ECHO ** Convertir archivo .resx a .resource. **


rmdir /s /q  es-ES
rmdir /s /q  en-US
rmdir /s /q  es
rmdir /s /q  en
pause
Resgen strings.es-ES.resx
mkdir es-ES
Al.exe /embed:strings.es-ES.resources /culture:es-ES /out:MUI_Application.resources.dll
move MUI_Application.resources.dll es-ES\MUI_Application.resources.dll
move strings.es-ES.resources es-ES\strings.es-ES.resources

Resgen strings.en-US.resx
mkdir en-US
Al.exe /embed:strings.en-US.resources /culture:en-US /out:MUI_Application.resources.dll
move MUI_Application.resources.dll  en-US\MUI_Application.resources.dll
move strings.en-US.resources en-US\strings.en-US.resources

Resgen strings.en.resx
mkdir en
Al.exe /embed:strings.en.resources /culture:en /out:MUI_Application.resources.dll
move MUI_Application.resources.dll  en\MUI_Application.resources.dll
move strings.en.resources en\strings.en.resources


Resgen strings.es.resx
mkdir es
Al.exe /embed:strings.es.resources /culture:es /out:MUI_Application.resources.dll
move MUI_Application.resources.dll es\MUI_Application.resources.dll
move strings.es.resources es\strings.es.resources

pause
exit




