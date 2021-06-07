$WebSite = '--title "WebSite" -- pwsh.exe -Interactive -NoExit -WorkingDirectory ./WebSite -Command dotnet run'

$Service = '--title "Service" -- pwsh.exe -Interactive -NoExit -WorkingDirectory ./Service -Command dotnet run'

$cmd = '-M -w -1 nt -d . ' + $WebSite + '; split-pane -d . ' + $Service

Start-Process wt $cmd
Start-Process http://localhost:16686/search
Start-Process https://localhost:5001/
