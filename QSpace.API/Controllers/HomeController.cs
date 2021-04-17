using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QSpace.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QSpace.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }

    }
}
