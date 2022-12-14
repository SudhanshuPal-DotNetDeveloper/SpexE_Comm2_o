using Microsoft.AspNetCore.Mvc;
using SpexE_Comm.Web.Helper.CurrentUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpexE_Comm.Web.Controllers
{
    public class DashboardController : Controller
    {
        #region Constructor

        private readonly ICurrentUser _currentUser;

        public DashboardController(ICurrentUser currentUser)
        {
            this._currentUser = currentUser;
        }

        #endregion

        #region Method 

        // <summary>
        /// User Dashboard View
        /// </summary>
        /// <returns></returns>
        public ActionResult UserDashboard()
        {
            var currentUser = _currentUser.GetCurrentUser();
            return View();
        }

        #endregion
    }
}
