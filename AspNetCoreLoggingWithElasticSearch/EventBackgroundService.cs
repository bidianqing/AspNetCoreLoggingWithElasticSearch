using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreLoggingWithElasticSearch
{
    public class EventBackgroundService : BackgroundService
    {
        private readonly ILogger _logger;
        public EventBackgroundService(ILogger<EventBackgroundService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("test");

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
