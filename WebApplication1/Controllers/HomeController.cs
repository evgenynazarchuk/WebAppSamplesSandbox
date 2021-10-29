using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        public HomeController() { }

        [HttpPost]
        public async Task<IActionResult> CreateEntity([FromBody] Message message)
        {
            await Task.Delay(1000);
            return Ok(new Message { Id = 1, Text = message.Text });
        }
    }
}
