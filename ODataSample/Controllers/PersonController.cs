namespace ODataSample.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ODataSample.Models;
    using Microsoft.AspNetCore.OData.Routing;
    using Microsoft.AspNetCore.OData;
    using Microsoft.AspNetCore.OData.Query;

    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        public readonly List<Person> Persons = new List<Person>
        {
            new Person() { Id = 1, FullName = "Evgeny 1", Age = 21 },
            new Person() { Id = 2, FullName = "Evgeny 2", Age = 22 },
            new Person() { Id = 3, FullName = "Evgeny 3", Age = 23 },
            new Person() { Id = 4, FullName = "Evgeny 4", Age = 24 },
            new Person() { Id = 5, FullName = "Evgeny 5", Age = 25 },
            new Person() { Id = 6, FullName = "Evgeny 6", Age = 26 },
            new Person() { Id = 7, FullName = "Evgeny 7", Age = 27 },
            new Person() { Id = 8, FullName = "Evgeny 8", Age = 28 },
        };

        [EnableQuery]
        [HttpGet]
        public ActionResult<IQueryable<Person>> Get()
        {
            return Ok(this.Persons.AsQueryable());
        }
    }
}
