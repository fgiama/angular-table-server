using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountriesApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CountriesApi.Controllers
{
    public class DummyController : Controller
    {
        private CountriesDataContext _ctx;
        public DummyController(CountriesDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}