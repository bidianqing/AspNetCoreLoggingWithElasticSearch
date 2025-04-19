namespace AspNetCoreLoggingWithElasticSearch
{
    public class UserContextEnrichmentMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<UserContextEnrichmentMiddleware> _logger;

        public UserContextEnrichmentMiddleware(RequestDelegate next, ILogger<UserContextEnrichmentMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var state = new List<KeyValuePair<string, object>>
                {
                    new("UserId", context.User.Identity.Name),
                };

                using (_logger.BeginScope(state))
                {
                    await _next(context);
                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}
