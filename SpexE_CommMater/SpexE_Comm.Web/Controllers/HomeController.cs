using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpexE_Comm.Data.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SpexE_Comm.Web.Controllers
{
    public class HomeController : Controller
    {
        #region



        #endregion

        #region Method

        /// <summary>
        /// Index Method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// About Us Method
        /// </summary>
        /// <returns></returns>
        public IActionResult AboutUs()
        {
            return View();
        }

        #endregion
    }
}
