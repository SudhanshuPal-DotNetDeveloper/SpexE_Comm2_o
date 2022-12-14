using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpexE_Comm.Factory;
using SpexE_Comm.Model;
using SpexE_Comm.Service;
using SpexE_Comm.Web.Helper.CurrentUser;
using System;
using Microsoft.AspNetCore;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static SpexE_Comm.Model.ConstantVariableModel;
using SpexE_Comm.Service.Services;

namespace SpexE_Comm.Web.Controllers
{
    public class AccountController : Controller
    {
        #region Contructor

        private readonly IMembershipFactory _membershipFactory;
        private readonly IMembershipService _membershipService;
        private readonly IEncryptionService _encryptionService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly ICommonService _commonService;
        private readonly ISmService _smService;
        private readonly IFirebaseCloudStorageService _firebaseCloudStorageService;

        public AccountController(IMembershipFactory membershipFactory,
            IMembershipService membershipService,
            IEncryptionService encryptionService,
            IHttpContextAccessor httpContextAccessor,
            ICurrentUser currentUser,
            ICommonService commonService,
            ISmService smService,
            IFirebaseCloudStorageService firebaseCloudStorageService)
        {
            this._membershipFactory = membershipFactory;
            this._membershipService = membershipService;
            this._encryptionService = encryptionService;
            this._httpContextAccessor = httpContextAccessor;
            this._currentUser = currentUser;
            this._commonService = commonService;
            this._smService = smService;
            this._firebaseCloudStorageService = firebaseCloudStorageService;
        }

        #endregion

        #region Register
        /// <summary>
        /// User Register View
        /// </summary>
        /// <returns></returns>
        public ActionResult UserRegister()
        {
            var currentUser = _currentUser.GetCurrentUser();
            if(currentUser != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(MembershipModel membershipModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(membershipModel.FirstName) && !string.IsNullOrEmpty(membershipModel.PhoneNumber) && !string.IsNullOrEmpty(membershipModel.Email))
                    {
                        if (membershipModel.Password.Equals(membershipModel.ConfirmPassword))
                        {
                            var memberShip = _membershipFactory.SpexRegisterModelToMembershipModel(membershipModel);
                            var isRegistered = await _membershipService.CreateUser(membershipModel);
                            if (isRegistered.Status)
                            {
                                await _membershipService.AssignRole(isRegistered.UserId, SpexE_commRole.CUSTOMER);
                                membershipModel.Role = SpexE_commRole.CUSTOMER;
                                this.CheckCookies(isRegistered.Email);
                                return RedirectToAction("UserDashboard", "Dashboard");
                            }
                        }
                        else
                        {
                            return View();
                        }
                    }
                    else
                    {
                        return View();
                    }
                }
                return View();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Login Logout

        public ActionResult UserLogin()
        {
            var cookies = _httpContextAccessor.HttpContext.Request.Cookies[Key];
            if (cookies != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }


        /// <summary>
        /// This method is used to validate user details
        /// </summary>
        /// <param name="membershipModel"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UserLogin(MembershipModel membershipModel)
        {
            try
            {
                if (!string.IsNullOrEmpty(membershipModel.Email) && !string.IsNullOrEmpty(membershipModel.Password))
                {
                    membershipModel.Email = membershipModel.Email;
                    membershipModel.Password = membershipModel.Password;
                    var loginResponse = _membershipService.LogIn(membershipModel);
                    if (loginResponse.IsLoggedIn)
                    {
                        if (!loginResponse.IsTwoFactorAuthenticationEnabled)
                        {
                            this.CheckCookies(membershipModel.Email);
                            Response response = new Response
                            {
                                ResponseCode = Convert.ToInt32(ResponseCode.SUCCESS),
                                RedirectUrl = "/Home/Index"
                            };
                            _membershipService.SaveDeviceInformation(loginResponse.UserId, _currentUser.GetIPAddress(), string.Empty);
                            return Json(response);
                        }
                        else
                        {
                            var encryptedUserId = _encryptionService.EncryptData(Convert.ToString(loginResponse.UserId));
                            var otpSent = this.SendVerificationCode(loginResponse.PhoneNumber, loginResponse.Email);
                            Response response = new Response
                            {
                                ResponseCode = Convert.ToInt32(ResponseCode.SUCCESS),
                                RedirectUrl = "/sigin-in/step-2/" + encryptedUserId + "/" + otpSent
                            };
                            return Json(response);
                        }
                    }
                    else
                    {
                        Response response = new Response
                        {
                            ResponseCode = Convert.ToInt32(ResponseCode.FAIL),
                            ResponseMessage = ErrorMessage.INVALID_USER
                        };
                        return Json(response);
                    }
                }
                else if (!string.IsNullOrEmpty(membershipModel.PhoneNumber))
                {
                    var loginResponse = _membershipService.LogIn(membershipModel);
                    if (loginResponse.IsLoggedIn)
                    {
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
                }
                return Json(string.Empty);
            }
            catch (Exception ex)
            {
                Response response = new Response
                {
                    ResponseCode = Convert.ToInt32(ResponseCode.FAIL),
                    ResponseMessage = ErrorMessage.ERROR_MESSAGE
                };
                return Json(response);
            }
        }


        /// <summary>
        /// Send Varification using SMS
        /// </summary>
        /// <param name="contactNumber"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public string SendVerificationCode(string contactNumber, string emailId = "")
        {
            var otp = _commonService.GenerateOpt();
            var message = string.Format(SMS.RecordMessage.OTP_MESSAGE_REGISTER, otp);

            dynamic _otpObject = new ExpandoObject();
            _otpObject.OTP = _encryptionService.EncryptData(otp);
            if (!string.IsNullOrEmpty(contactNumber))
            {
                //_otpObject.isSMSSent = _smService.SendSms(contactNumber, message.Replace(HtmlTags.BREAK, System.Environment.NewLine), string.Empty);

            }
            return _otpObject.OTP;
        }

        public IActionResult OtpVarification(OtpModel otpModel)
        {
            Response response = new Response();
            if (otpModel != null)
            {
                if(!string.IsNullOrEmpty(otpModel.PhoneNumber))
                {
                    var user = _membershipService.GetUserByMobileNumber(otpModel.PhoneNumber);
                    if (user != null)
                    {
                        this.CheckCookies(user.Email);

                        response.ResponseCode = Convert.ToInt32(ResponseCode.SUCCESS);
                        response.RedirectUrl = "/Dashboard/UserDashboard";
                        return Json(response);
                    }
                }
                else
                {
                    response.ResponseCode = Convert.ToInt32(ResponseCode.FAIL);
                    response.ResponseMessage = ConstantVariableModel.SMS.RecordMessage.INVALID_OTP;
                }
            }
            else
            {
                response.ResponseCode = Convert.ToInt32(ResponseCode.FAIL);
                response.ResponseMessage = ConstantVariableModel.SMS.RecordMessage.INVALID_OTP;
            }
            return Json(response);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            if (Request.Cookies[USER_NAME] != null)
            {
                CookieOptions opt = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Delete(USER_NAME);
            }
            if (Request.Cookies[Key] != null)
            {
                CookieOptions opt = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Delete(Key);
            }
            //if (Request.Cookies[RETURNURL] != null)
            //{
            //    CookieOptions opt = new CookieOptions
            //    {
            //        Expires = DateTime.Now.AddDays(-1)
            //    };
            //    Response.Cookies.Delete(ConstantsVariablesModel.RETURNURL);
            //}

            //if (Request.Cookies[ConstantsVariablesModel.ADMIN_USER] != null)
            //{
            //    CookieOptions opt = new CookieOptions
            //    {
            //        Expires = DateTime.Now.AddDays(-1)
            //    };
            //    Response.Cookies.Delete(ConstantsVariablesModel.ADMIN_USER);
            //}

            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var timeOut = Convert.ToInt32(Session_TIME.TIME_OUT);
            return RedirectToAction("Index", "Home");
        }


        #endregion

        #region Cookies
        /// <summary>
        /// Clear User Cookie
        /// </summary>
        private void ClearCookies()
        {
            if (Request.Cookies[USER_NAME] != null)
            {
                CookieOptions opt = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Delete(USER_NAME);
            }
            if (Request.Cookies[Key] != null)
            {
                CookieOptions opt = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Delete(Key);
            }
        }


        /// <summary>
        /// Check User by Email using cookies
        /// </summary>
        /// <param name="email"></param>
        private void CheckCookies(string email)
        {

            string userName = string.Empty;
            if (!string.IsNullOrEmpty(email))
            {
                var user = _membershipService.GetUserByEmail(email);
                if (user != null)
                {
                    userName = (!string.IsNullOrEmpty(user.FirstName) ? (user.FirstName + " " + user.LastName) : email);
                }
            }
            var timeOut = Convert.ToInt32(Session_TIME.TIME_OUT);
            Set(Key, _encryptionService.AESEncryptData(email, true), timeOut);
            Set(USER_NAME, userName, timeOut);
        }


        /// <summary>
        /// Create Set Method to set the Copokies
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        public void Set(string key, string value, int expireTime)
        {
            var options = new Microsoft.AspNetCore.Http.CookieOptions()
            {
                Path = "/",
                HttpOnly = false,
                IsEssential = true, //<- there
                Expires = DateTime.Now.AddMonths(expireTime),
            };
            Response.Cookies.Append(key, value, options);
        }

#endregion

    }
}
