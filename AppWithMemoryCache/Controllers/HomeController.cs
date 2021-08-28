using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AppWithMemoryCache.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly PersonService _personService;

        public HomeController(PersonService personService)
        {
            this._personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPerson([FromQuery] Guid? id)
        {
            if (id.HasValue)
            {
                Person person = await this._personService.GetAsync(id.Value);
                if (person is not null)
                    return Ok(person);
                else return NotFound();
            }
            else
                return Ok(await this._personService.GetAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] Person person)
        {
            if (person is not null)
            {
                if (await this._personService.ExistAsync(person.Id))
                    return BadRequest("Person is exist");

                return Ok(await this._personService.Add(person));
            }
            else
                return BadRequest("Person value is not valid");
        }
    }
}
