using Microsoft.AspNetCore.Mvc;
using ScopedServices.Services;

namespace ScopedServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] BaseScopedService scopedService)
        {
            return Ok("Hello world");
        }
    }
}
