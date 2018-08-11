cd /d "D:\workspace\IntegrationTesting\IntegrationTesting" &msbuild "IntegrationTesting.csproj" /t:sdvViewer /p:configuration="Release" /p:platform=Any CPU
exit %errorlevel% 