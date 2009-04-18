ECHO cd C:\Projects\Fwk 3.0\Libraries\Framework\

@SET SPDIR="C:\Projects\Fwk 3.0\Samples\Arquitectura\Service\WebServiceDispatcher"

@ECHO OFF
ECHO:
ECHO  ** Se esta por copiar los asemblies del framework al servidor **
ECHO:
pause

copy Fwk.Bases.dll %SPDIR%\bin\
copy Fwk.Bases.pdb %SPDIR%\bin\

copy Fwk.Blocking.dll %SPDIR%\bin\
copy Fwk.Blocking.pdb %SPDIR%\bin\

copy Fwk.Security.dll %SPDIR%\bin\
copy Fwk.Security.pdb %SPDIR%\bin\


pause
