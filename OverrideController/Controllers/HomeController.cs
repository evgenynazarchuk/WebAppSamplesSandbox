using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OverrideController.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : AuthController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetResult()
        {
            return Content("Ok");
        }
    }
}
