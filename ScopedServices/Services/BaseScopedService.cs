using Microsoft.Extensions.Logging;

namespace ScopedServices.Services
{
    public class BaseScopedService
    {
        public BaseScopedService(ILogger<BaseScopedService> logger)
        {
            logger.LogInformation("BaseScopedService ctor");
        }
    }
}
