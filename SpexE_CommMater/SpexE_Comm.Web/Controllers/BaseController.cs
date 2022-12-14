using Microsoft.AspNetCore.Mvc;
using SpexE_Comm.Service;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpexE_Comm.Web.Controllers
{
    public class BaseController : Controller
    {
        #region Constructor
        private readonly IMembershipService _membershipService;

        public BaseController(IMembershipService membershipService)
        {
            this._membershipService = membershipService;
        }

        #endregion

        #region Method

        /// <summary>
        /// 404 Page not Found
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            return View();
        }
        /// <summary>
        /// Validating Phone number on registration
        /// </summary>Method to validate user contact number
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public IActionResult ValidatePhoneNumbers(string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                var contactDetails = _membershipService.GetUserByMobileNumber(phoneNumber);
                if (contactDetails != null)
                {
                    if (contactDetails.PhoneNumber != null)
                    {
                        return Json($"Contact number {phoneNumber} is already registered.");
                    }
                    else
                    {
                        return Json(true);
                    }
                }
            }
            return Json(true);
        }

        /// <summary>
        /// Validating Email on Registration
        /// </summary>Method to validate user Email
        /// <param name="email"></param>
        /// <returns></returns>
        public IActionResult ValidateEmailAddress(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var contactDetails = _membershipService.GetUserByEmail(email);
                if (contactDetails != null)
                {
                    if (contactDetails.Email != null)
                    {
                        return Json($"Email {email} is already registered.");
                    }
                    else
                    {
                        return Json(true);
                    }
                }
            }
            return Json(true);
        }

        #endregion
    }
}
