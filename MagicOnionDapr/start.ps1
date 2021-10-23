$MagicOnionServerDapr = 'dapr.exe run --log-level debug --app-id MagicOnionServer --app-protocol grpc --app-port 5000 --dapr-grpc-port 50001 --config .\dapr\config.yaml -- dotnet run --urls=http://localhost:5000/ -p MagicOnionServer/MagicOnionServer.csproj'
$MagicOnionServer = '--title "MagicOnion server Dapr" -- pwsh.exe -Interactive -NoExit -Command ' + "$MagicOnionServerDapr"

$cmd = '-M -w -1 nt -d . ' + $MagicOnionServer

Start-Process wt $cmd
