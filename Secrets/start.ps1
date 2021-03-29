$SecretDapr = 'dapr.exe run --dapr-grpc-port 50001 --components-path .\client\components\'
$Secret = '--title "Secret" -- pwsh.exe -Interactive -NoExit -Command ' + "$SecretDapr"

$cmd = '-M -w -1 nt -d . ' + $Secret + ';'

Start-Process wt $cmd
