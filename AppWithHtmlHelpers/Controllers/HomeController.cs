using Microsoft.AspNetCore.Mvc;

namespace AppWithHtmlHelpers.Controllers
{
    [Route("{controller=Home}/{action=Index}")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
