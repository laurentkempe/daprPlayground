$GrpcServiceDapr = 'dapr.exe run --log-level debug --app-id grpcservice --app-protocol grpc --app-port 5000 --dapr-grpc-port 50001 --config .\dapr\config.yaml -- dotnet run --urls=http://localhost:5000/ -p GrpcStreamService/GrpcStreamService.csproj'
$GrpcService = '--title "Grpc service Dapr" -- pwsh.exe -Interactive -NoExit -Command ' + "$GrpcServiceDapr"

$cmd = '-M -w -1 nt -d . ' + $GrpcService

Start-Process wt $cmd
