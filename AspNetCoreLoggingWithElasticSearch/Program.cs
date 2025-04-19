using AspNetCoreLoggingWithElasticSearch;
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

app.UseMiddleware<UserContextEnrichmentMiddleware>();

app.MapControllers();

app.Run();