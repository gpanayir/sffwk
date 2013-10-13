ECHO ** generador**


@set "vs=\Microsoft Visual Studio 10.0\VC"

 @SET "SPDIR= %PROGRAMFILES%%vs%"

@if not "%PROGRAMFILES(X86)%" == "" (
 @SET "SPDIR= %PROGRAMFILES(X86)%%vs%"
)


@echo %SPDIR%

cd %SPDIR%


@ECHO OFF
ECHO:
ECHO  ** Se limpio el directorio correctamente **
ECHO:
pause
