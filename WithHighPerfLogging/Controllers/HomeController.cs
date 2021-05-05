using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WithHighPerfLogging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // appsettings.json
            // "WithHighPerfLogging.Controllers.HomeController": "Trace"

            AppLogger.TraceMessage(_logger);
            AppLogger.TraceMessage(_logger, "any message-1");
            AppLogger.TraceMessage(_logger, "any message-2", 42);
            AppLogger.DebugMessage(_logger, "debug message");

            return Ok("Completed");
        }
    }
}
