using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

#if DEBUG
Debugger.Launch();
#endif

app.MapGet("/", () => "Hello Dapr World!");

app.Run();