using Microsoft.AspNetCore.Http;
using SpexE_Comm.Data.Data;
using SpexE_Comm.Model;
using SpexE_Comm.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpexE_Comm.Web.Helper.CurrentUser
{
    public class CurrentUser : ICurrentUser
    {
        #region Constructor

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEncryptionService _encryptionService;
        private readonly IMembershipService _membershipService;
        public CurrentUser(IHttpContextAccessor httpContextAccessor,
            IEncryptionService encryptionService,
            IMembershipService membershipService)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._encryptionService = encryptionService;
            this._membershipService = membershipService;
        }

        #endregion
        public string GetIPAddress()
        {
            string address = "";
            address = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return address;
        }

        /// <summary>
        /// This method is used to get current logged in user details
        /// </summary>
        /// <returns></returns>
        public Membership GetCurrentUser()
        {
            Membership membership = new Membership();
            try
            {
                string userName = _httpContextAccessor.HttpContext.User.Identity.Name;

                var cookies = _httpContextAccessor.HttpContext.Request.Cookies[ConstantVariableModel.Key];
                if (cookies != null)
                {
                    string userEmail = _encryptionService.AESDecryptData(cookies, true);
                    //string userEmail  = _membershipService.GetName(cookies);
                    var currentUser = _membershipService.GetUserByEmail(userEmail);
                    if (currentUser != null)
                    {
                        membership = currentUser;
                        //membership.Password = (currentUser.UserProfileDetail.FirstOrDefault() != null) ? currentUser.UserProfileDetail.FirstOrDefault().ProfileImageUrl : string.Empty;
                    }
                    else
                    {
                        membership = null;
                    }
                    //Getting image url in password property
                }
                else
                {
                    membership = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return membership;
        }
    }
}
