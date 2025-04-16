using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register Startup class for configuration
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);

app.Run();