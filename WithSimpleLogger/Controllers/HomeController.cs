using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WithSimpleLogger.Controllers
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

        // GET localhost/home
        [HttpGet]
        public IActionResult Get()
        {

            // appsettings.json
            // "WithSimpleLogger.Controllers.HomeController": "Trace"

            // Trace = 0 (trace, debug, information, crtical, error, warning)
            // Debug = 1 (debug, information, crtical, error, warning)
            // Information = 2 (information, crtical, error, warning)
            // Warning = 3 (crtical, error, warning)
            // Error = 4 (critical, error)
            // Critical = 5 (only critical)
            // None = 6 (no loggin)


            _logger.LogCritical("Critical message");
            _logger.LogDebug("Debug message");
            _logger.LogError("Error message");
            _logger.LogInformation("Information message");
            _logger.LogTrace("Trace message");
            _logger.LogWarning("Warning message");

            return Ok("Completed");
        }
    }
}
