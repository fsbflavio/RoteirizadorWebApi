using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RoteirizadorWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("API REST para app de roteamento");
        }
    }
}
