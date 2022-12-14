using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpexE_Comm.Data.Data;
using SpexE_Comm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpexE_Comm.Service
{
    public class MembershipService : IMembershipService
    {
        #region Constructor
        private readonly IEncryptionService _encryptionService;
        private readonly ICommonService _commonService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MembershipService(IEncryptionService encryptionService,
            ICommonService commonService,
            IHttpContextAccessor httpContextAccessor)
        {
            this._encryptionService = encryptionService;
            this._commonService = commonService;
            this._httpContextAccessor = httpContextAccessor;
        }

        #endregion


        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="membershipModel"></param>
        /// <param name="enableUser"></param>
        /// <returns></returns>
        public async Task<MembershipModel> CreateUser(MembershipModel membershipModel, bool enableUser = false)
        {
            try
            {
                Membership membership = new Membership();
                if (!string.IsNullOrEmpty(membershipModel.Password) && !string.IsNullOrEmpty(membershipModel.Email))
                {
                    using (var SpexE_Comm = new SpexE_CommContext())
                    {
                        var checkEmail = SpexE_Comm.Membership.Any(x => x.Email == membershipModel.Email);
                        if (!checkEmail)
                        {
                            var userId = Guid.NewGuid();

                            User user = new User
                            {
                                UserId = userId,
                                UserName = membershipModel.Email
                            };
                            SpexE_Comm.User.Add(user);

                            membership.IsActive = true;
                            membership.UserId = userId;
                            membership.Email = membershipModel.Email;
                            membership.FirstName = membershipModel.FirstName;
                            membership.LastName = membershipModel.LastName;
                            membership.PrivacyPolicy = membershipModel.IsPrivacyPolicyCheck;
                            membership.Password = _encryptionService.EncryptData(membershipModel.Password);
                            membership = _encryptionService.UpdateMembershipModel(membershipModel, membership);
                            membership.Address = membershipModel.Address;
                            membership.PhoneNumber = membershipModel.PhoneNumber;
                            membership.CityId = (membershipModel.CityId > 0) ? membershipModel.CityId : 1;
                            membership.IsEmailVerified = true;
                            membership.RegistrationDate = DateTime.Now;
                            membership.ProfileImageUrl = membershipModel.ProfileImageUrl;
                            SpexE_Comm.Add(membership);
                            await SpexE_Comm.SaveChangesAsync();
                            membershipModel.Status = true;
                            membershipModel.UserId = membership.UserId;
                        }
                        else
                        {
                            var membershipUser = SpexE_Comm.Membership.Where(x => x.Email == membershipModel.Email).FirstOrDefault();
                            if (membershipUser.IsEmailVerified)
                            {
                                membershipUser.FirstName = membershipModel.FirstName;
                                membershipUser.LastName = membershipModel.LastName;
                                membershipUser = _encryptionService.UpdateMembershipModel(membershipModel, membershipUser);
                                membershipUser.Address = membershipModel.Address;
                                membershipUser.PhoneNumber = membershipModel.PhoneNumber;
                                SpexE_Comm.Update(membershipUser);
                                await SpexE_Comm.SaveChangesAsync();
                                membershipModel.Status = true;
                                membershipModel.UserId = membershipUser.UserId;
                            }
                        }
                    }
                }

                if (string.IsNullOrEmpty(membershipModel.Password) && !string.IsNullOrEmpty(membershipModel.PhoneNumber))
                {
                    using (var SpexE_Comm = new SpexE_CommContext())
                    {
                        var checkPhone = SpexE_Comm.Membership.Any(x => _commonService.FormateMobileNumber(x.PhoneNumber) == _commonService.FormateMobileNumber(membershipModel.PhoneNumber));
                        if (!checkPhone)
                        {
                            var userId = Guid.NewGuid();

                            User user = new User
                            {
                                UserId = userId,
                                UserName = membershipModel.Email
                            };
                            SpexE_Comm.User.Add(user);

                            membership.IsActive = true;
                            membership.UserId = userId;
                            membership.Email = membershipModel.Email;
                            membership.FirstName = membershipModel.FirstName;
                            membership.LastName = membershipModel.LastName;
                            membership.PrivacyPolicy = membershipModel.IsPrivacyPolicyCheck;
                            membership.Address = membershipModel.Address;
                            membership.PhoneNumber = membershipModel.PhoneNumber;
                            membership.CityId = (membershipModel.CityId > 0) ? membershipModel.CityId : 1;
                            membership.IsEmailVerified = true;
                            membership.RegistrationDate = DateTime.Now;
                            SpexE_Comm.Add(membership);
                            await SpexE_Comm.SaveChangesAsync();
                            membershipModel.Status = true;
                            membershipModel.IsPhone = true;
                            membershipModel.UserId = membership.UserId;

                        }
                    }
                }
                return membershipModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Assign role to user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        public async Task<bool> AssignRole(Guid userId, string role)
        {
            bool result = false;
            try
            {
                using (var SpexE_Comm = new SpexE_CommContext())
                {
                    var checkUser = SpexE_Comm.UserRole.Where(x => x.UserId == userId);
                    if (checkUser != null)
                    {
                        SpexE_Comm.UserRole.RemoveRange(checkUser);
                        await SpexE_Comm.SaveChangesAsync();
                    }

                    Guid roleId = SpexE_Comm.Role.Where(x => x.RoleName == role).FirstOrDefault().RoleId;
                    var checkUserRole = SpexE_Comm.UserRole.Any(x => x.RoleId == roleId && x.UserId == userId);
                    if (!checkUserRole)
                    {
                        UserRole userRole = new UserRole
                        {
                            UserId = userId,
                            RoleId = roleId
                        };
                        SpexE_Comm.Add(userRole);
                        await SpexE_Comm.SaveChangesAsync();
                        result = true;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Check if a user is log in
        /// </summary>
        /// <param name="membership"></param>
        /// <returns></returns>
        public LogInResponseModel LogIn(MembershipModel membership, bool isApirequest = false)
        {
            LogInResponseModel logInResponseModel = new LogInResponseModel();
            //bool isValidated = false;
            if (!string.IsNullOrEmpty(membership.Email) && !string.IsNullOrEmpty(membership.Password))
            {
                var role = this.GetRoleByEmail(membership.Email);
                if (!string.IsNullOrEmpty(role))
                {
                    using (var spexE_Comm = new SpexE_CommContext())
                    {

                        var userData = spexE_Comm.Membership.Where(x => (x.Email == membership.Email) && (x.IsActive == true) && (x.IsEmailVerified)).FirstOrDefault();
                        if (userData != null)
                        {
                            logInResponseModel.UserId = userData.UserId;
                            logInResponseModel.Email = userData.Email;
                            logInResponseModel.PhoneNumber = userData.PhoneNumber;
                            logInResponseModel.UserName = string.Format(ConstantVariableModel.DISPLAY_NAME, userData.FirstName, !string.IsNullOrEmpty(userData.LastName) ? userData.LastName : string.Empty);
                            SaveDeviceInformation(userData.UserId);
                            var time = DateTime.Now;
                            spexE_Comm.Update(userData);
                            spexE_Comm.SaveChanges();

                            if (string.IsNullOrEmpty(userData.UserSalt))
                            {
                                if (!membership.Password.Equals(_encryptionService.AESDecryptData((userData.Password), true, string.Empty)))
                                {
                                    logInResponseModel.IsLoggedIn = false;
                                    return logInResponseModel;
                                }
                                else
                                {
                                    logInResponseModel.IsLoggedIn = true;
                                }
                                logInResponseModel.SaltEnabled = false;
                            }
                            else
                            {
                                if (!membership.Password.Equals(_encryptionService.AESDecryptData((userData.Password), true, userData.UserSalt)))
                                {
                                    logInResponseModel.IsLoggedIn = false;
                                    return logInResponseModel;
                                }
                                else
                                {
                                    logInResponseModel.IsLoggedIn = true;
                                }
                                logInResponseModel.SaltEnabled = true;
                            }

                            if (!isApirequest)
                                SaveDeviceInformation(userData.UserId);
                        }
                    }
                }
            }
            else if (!string.IsNullOrEmpty(membership.PhoneNumber))
            {
                var role = this.GetRoleByNumber(membership.PhoneNumber);
                if (!string.IsNullOrEmpty(role))
                {
                    using (var spexE_Comm = new SpexE_CommContext())
                    { 
                        var userData = spexE_Comm.Membership.Where(x => x.PhoneNumber.Equals(_commonService.FormateMobileNumber(membership.PhoneNumber)) || x.PhoneNumber.Equals(_commonService.FormateMobileNumberWithHyphen(membership.PhoneNumber)) && (x.IsActive == true) && (x.IsMobileNumberVerified)).FirstOrDefault();
                        if(userData != null)
                        {
                            logInResponseModel.UserId = userData.UserId;
                            logInResponseModel.Email = userData.Email;
                            logInResponseModel.PhoneNumber = userData.PhoneNumber;
                            logInResponseModel.UserName = string.Format(ConstantVariableModel.DISPLAY_NAME, userData.FirstName, !string.IsNullOrEmpty(userData.LastName) ? userData.LastName : string.Empty);
                            logInResponseModel.IsLoggedIn = true;
                            SaveDeviceInformation(userData.UserId);
                            var time = DateTime.Now;
                            spexE_Comm.Update(userData);
                            spexE_Comm.SaveChanges();
                        }
                        if (!isApirequest)
                            SaveDeviceInformation(userData.UserId);
                    }
                }
            }
            return logInResponseModel;
        }

        /// <summary>
        /// Find user role by Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string GetRoleByEmail(string email)
        {
            var user = this.GetUserByEmail(email);
            if (user != null)
            {
                using (var spexE_Comm = new SpexE_CommContext())
                {
                    var userData = spexE_Comm.UserRole.Include(x => x.Role).Where(x => x.UserId == user.UserId).FirstOrDefault();
                    return userData.Role.RoleName;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Find user role by Phone Number
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string GetRoleByNumber(string phoneNumber)
        {
            var user = this.GetUserByPhone(phoneNumber);
            if (user != null)
            {
                using (var spexE_Comm = new SpexE_CommContext())
                {
                    var userData = spexE_Comm.UserRole.Include(x => x.Role).Where(x => x.UserId == user.UserId).FirstOrDefault();
                    return userData.Role.RoleName;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// find user by email Id
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Membership GetUserByEmail(string email)
        {
            using (var spexE_Comm = new SpexE_CommContext())
            {
                return spexE_Comm.Membership.
                    Include(x => x.User).ThenInclude(x => x.UserRole).ThenInclude(x => x.Role).
                    Where(x => x.Email == email).FirstOrDefault();
            }
        }

        /// <summary>
        /// find user by Phone Number
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Membership GetUserByPhone(string phoneNumber)
        {
            using (var spexE_Comm = new SpexE_CommContext())
            {
                return spexE_Comm.Membership.
                    Include(x => x.User).ThenInclude(x => x.UserRole).ThenInclude(x => x.Role).
                    Where(x => x.PhoneNumber.Equals(_commonService.FormateMobileNumber(phoneNumber)) || x.PhoneNumber.Equals(_commonService.FormateMobileNumberWithHyphen(phoneNumber))).FirstOrDefault();
            }
        }

        /// <summary>
        /// Save Device Information  
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public bool SaveDeviceInformation(Guid UserId)
        {
            bool isSaved = false;
            using (var spexE_Comm = new SpexE_CommContext())
            {
                var user = spexE_Comm.Membership.Where(x => x.UserId == UserId).FirstOrDefault();

                var time = DateTime.Now;
                string formattedTime = time.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                UserDeviceInformation userDeviceInformation = new UserDeviceInformation();
                userDeviceInformation.UserId = UserId;

                userDeviceInformation.DeviceIp = GetIPAddress();
                if (!user.IsEmailVerified)
                {
                    userDeviceInformation.RegistrationDate = formattedTime;
                }
                else
                {
                    userDeviceInformation.RegistrationDate = "";
                }
                userDeviceInformation.LastLogIn = formattedTime;

                spexE_Comm.UserDeviceInformation.Add(userDeviceInformation);
                spexE_Comm.SaveChanges();
                isSaved = true;
            }
            return isSaved;
        }


        /// <summary>
        /// Save Device Information
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="deviceIp"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public bool SaveDeviceInformation(Guid UserId, string deviceIp, string deviceId)
        {
            bool isSaved = false;
            using (var spexE_comm = new SpexE_CommContext())
            {
                var user = spexE_comm.Membership.Where(x => x.UserId == UserId).FirstOrDefault();

                var time = DateTime.Now;
                string formattedTime = time.ToString("dddd, dd MMMM yyyy HH:mm:ss");

                var startDate = time.Date;
                var endDate = time.Date.AddDays(1).AddTicks(-1);
                var udInfo = spexE_comm.UserDeviceInformation.Where(x => x.UserId == UserId && x.LastLogInDate >= startDate && x.LastLogInDate <= endDate).FirstOrDefault();
                if (udInfo == null)
                {

                    UserDeviceInformation userDeviceInformation = new UserDeviceInformation();
                    userDeviceInformation.UserId = UserId;
                    userDeviceInformation.DeviceIp = deviceIp;
                    userDeviceInformation.DeviceId = deviceId;
                    if (!user.IsEmailVerified)
                    {
                        userDeviceInformation.RegistrationDate = formattedTime;
                    }
                    else
                    {
                        userDeviceInformation.RegistrationDate = "";
                    }
                    userDeviceInformation.LastLogIn = formattedTime;
                    userDeviceInformation.LastLogInDate = time;
                    spexE_comm.UserDeviceInformation.Add(userDeviceInformation);
                    spexE_comm.SaveChanges();
                    isSaved = true;
                }
            }
            return isSaved;
        }

        /// <summary>
        /// Get User IPAddress 
        /// </summary>
        /// <returns></returns>
        public string GetIPAddress()
        {
            string address = "";
            address = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return address;
        }

        public Membership GetUserByMobileNumber(string PhoneNumber)
        {
            Membership membership = new Membership();
            if (!string.IsNullOrEmpty(PhoneNumber))
            {
                using(var _spexE_CommContext = new SpexE_CommContext())
                {
                    membership = _spexE_CommContext.Membership.Where(x => x.PhoneNumber.Equals(_commonService.FormateMobileNumber(PhoneNumber)) || x.PhoneNumber.Equals(_commonService.FormateMobileNumberWithHyphen(PhoneNumber))).FirstOrDefault();
                }
            }
            return membership;
        }
    }
}
