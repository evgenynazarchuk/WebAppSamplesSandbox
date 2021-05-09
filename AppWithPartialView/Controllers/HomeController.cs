using Microsoft.AspNetCore.Mvc;

namespace AppWithPartialView.Controllers
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
