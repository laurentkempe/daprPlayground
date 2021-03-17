$ProxyDapr = 'dapr.exe run --app-id proxy --app-port 5001 --dapr-http-port 3501 --app-ssl dotnet run -- --urls=https://localhost:5001/ -p WeatherForecastProxyService/WeatherForecastProxyService.csproj'
$Proxy = '--title "Proxy" -- pwsh.exe -Interactive -NoExit -Command ' + "$ProxyDapr"

$BackendDapr = 'dapr.exe run --app-id backend --app-port 5000 --dapr-http-port 3500 --app-ssl dotnet run -- --urls=https://localhost:5000/ -p WeatherForecastService/WeatherForecastService.csproj'
$Backend = '--title "Backend" -- pwsh.exe -Interactive -NoExit -Command ' + "$BackendDapr"

$cmd = '-M -w -1 nt -d . ' + $Proxy + '; split-pane -d . ' + $Backend

Start-Process wt $cmd
