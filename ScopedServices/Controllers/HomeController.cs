using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
