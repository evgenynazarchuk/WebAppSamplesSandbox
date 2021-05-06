using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ProductMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProductMVC.Controllers
{
    [Route("{controller=Home}/{action=Index}")]
    public class HomeController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(DatabaseContext db, ILogger<HomeController> logger)
        {
            this._logger = logger;
            this._db = db;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Products()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Orders()
        {
            var orders = _db.Orders.Include(x => x.Product).ToList();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Buy([FromQuery]Guid? id)
        {
            if (id is null)
                return BadRequest("Product not found");

            var product = this._db.Products.SingleOrDefault(x => x.Id == id);
        
            return View(product);
        }
        
        [HttpPost]
        public IActionResult Buy([FromForm]Order order)
        {
            this._db.Orders.Add(order);
            this._db.SaveChanges();

            return RedirectToAction("Orders");
        }
    }
}
