using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();

builder.Logging.ClearProviders();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Logging.AddSerilog(logger);

if (builder.Environment.IsDevelopment())
{
    builder.Logging.AddConsole();
}


var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();