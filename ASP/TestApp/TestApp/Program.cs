var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await app.RunAsync();
await Task.Delay(10000);
await app.StopAsync();