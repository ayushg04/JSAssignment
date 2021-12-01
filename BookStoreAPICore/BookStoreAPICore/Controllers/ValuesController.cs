using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Val 1", "Val 2", "Val 3", "Val 4", "Val 5" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "the value is" + id;
        }
    }
}
