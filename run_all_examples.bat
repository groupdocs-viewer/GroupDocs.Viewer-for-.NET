@echo off
echo Running GroupDocs.Viewer for .NET Examples...
echo.
echo Choose a runner:
echo   1. Framework (net462)
echo   2. Net (net10.0)
echo   3. NetWindows (net10.0-windows7.0)
echo.
set /p choice="Enter choice (default=2): "
if "%choice%"=="" dotnet run --project Examples\GroupDocs.Viewer.Examples.CSharp.Net\GroupDocs.Viewer.Examples.CSharp.Net.csproj & goto :eof
if "%choice%"=="1" dotnet run --project Examples\GroupDocs.Viewer.Examples.CSharp.Framework\GroupDocs.Viewer.Examples.CSharp.Framework.csproj
if "%choice%"=="2" dotnet run --project Examples\GroupDocs.Viewer.Examples.CSharp.Net\GroupDocs.Viewer.Examples.CSharp.Net.csproj
if "%choice%"=="3" dotnet run --project Examples\GroupDocs.Viewer.Examples.CSharp.NetWindows\GroupDocs.Viewer.Examples.CSharp.NetWindows.csproj
pause
