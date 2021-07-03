using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QSpace.API.Controllers
{
    public class Controller1 : BaseController
    {
        [HttpGet]
        public IActionResult Methode1()
        {
            return Ok("Hend: Hi :)");
        }
    }
}
