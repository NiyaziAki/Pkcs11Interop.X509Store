@setlocal

set SIGNTOOL="C:\Program Files (x86)\Microsoft SDKs\ClickOnce\SignTool\signtool.exe"

@rem Define signing options
set CERTHASH=6962926e92cdd663aa8f42e7211df022f1bb5ffe
set TSAURL=http://time.certum.pl/
set LIBNAME=Pkcs11Interop.X509Store
set LIBURL=https://www.pkcs11interop.net/

@rem Sign all assemblies using SHA1withRSA algorithm
%SIGNTOOL% sign /sha1 %CERTHASH% /fd sha1 /tr %TSAURL% /td sha1 /d %LIBNAME% /du %LIBURL% ^
net461\Pkcs11Interop.X509Store.dll || goto :error

@rem Sign all assemblies using SHA256withRSA algorithm
%SIGNTOOL% sign /sha1 %CERTHASH% /as /fd sha256 /tr %TSAURL% /td sha256 /d %LIBNAME% /du %LIBURL% ^
net461\Pkcs11Interop.X509Store.dll || goto :error

@echo *** SIGNING SUCCESSFUL ***
@endlocal
@exit /b 0

:error
@echo *** SIGNING FAILED ***
@endlocal
@exit /b 1
