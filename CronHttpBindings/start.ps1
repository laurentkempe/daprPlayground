$WorkerDapr = 'dapr.exe run --app-id worker --app-port 5001 --dapr-http-port 3501 --app-ssl --components-path .\dapr\components\ dotnet run -- --urls=https://localhost:5001/ -p Worker/Worker.csproj'
$Worker = '--title "Worker" -- pwsh.exe -Interactive -NoExit -Command ' + "$WorkerDapr"

$cmd = '-M -w -1 nt -d . ' + $Worker

Start-Process wt $cmd
