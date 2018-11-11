using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AspNetCoreLoggingWithElasticSearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));

                    // 为了提高性能 只添加两个provider(console,serilog) 而且console只能用在Development和Staging 
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddSerilog();
                })
                .UseStartup<Startup>();
    }
}
