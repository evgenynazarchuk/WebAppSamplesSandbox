﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsTableComponent.Models;

namespace JsTableComponent.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Person> GetPerson()
        {
            return new Person[]
                {
                    new Person{ FirstName = "F1", LastName = "L1" },
                    new Person{ FirstName = "F2", LastName = "L2" },
                    new Person{ FirstName = "F3", LastName = "L3" },
                };
        }
    }
}
