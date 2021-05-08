using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWithResponseCache.Controllers
{
    [Route("{controller=Home}/{action=Index}")]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [ResponseCache(Duration = 10000, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(CacheProfileName = "No Cache")]
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(CacheProfileName = "Public Cache")]
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(CacheProfileName = "Private Cache")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
