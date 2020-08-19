using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Filters;

namespace WebApplication.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [AuthorizationFilter]
        public IActionResult Get()
        {
            return Ok(new List<string>() { "value1", "value2" });
        }

        // GET api/values/5
        [AuthorizationFilter]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"value {id}");
        }

    }
}
