using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OverrideActionResult.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetBlock()
        {
            return new HtmlBlockResult("Hello world");
        }
    }
}
