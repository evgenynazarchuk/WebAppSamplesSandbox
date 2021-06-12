using Microsoft.AspNetCore.Mvc;

namespace DotNetAngular.Controllers
{
    [Controller]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult GetData()
        {
            return Content("Hello world");
        }
    }
}
