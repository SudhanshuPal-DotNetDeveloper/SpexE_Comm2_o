using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpexE_Comm.Admin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SpexE_Comm.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
