using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SpexE_Comm.Model
{
    public partial class MembershipModel
    {
        public Guid UserId { get; set; }
        [EmailAddress]
        //[Remote(action: "ValidateEmailAddress", controller: "Base")]
        [Required(ErrorMessage = "Please Enter Your Email Address !!")]
        public string Email { get; set; }
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Please enter minimum 6 digits.")]
        [Required(ErrorMessage = "Please Enter Your Password !!")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirmation Password is not match")]
        [Required(ErrorMessage = "Please Enter Confirm Password !!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Please Enter Your First Password !!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Last Name !!")]
        public string LastName { get; set; }
        public bool PrivacyPolicy { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public bool IsActive { get; set; }
        [Remote(action: "ValidatePhoneNumbers", controller: "Base")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Required(ErrorMessage = "Please Enter Your Contact Number !!")]
        public string PhoneNumber { get; set; }
        public bool IsMobileNumberVerified { get; set; }
        public bool IsEmailVerified { get; set; }
        public string UserSalt { get; set; }
        [Required(ErrorMessage = "Please Select Your Role !!")]
        public string Role { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool IsPrivacyPolicyCheck { get; set; }
        public bool Status { get; set; }
        public bool IsPhone { get; set; }
        public string ProfileImageUrl { get; set; }
        public string OTP { get; set; }
    }

    public class ApplicationUser : IdentityUser
    {
    }

    public class LogInResponseModel
    {
        public bool IsLoggedIn { get; set; }
        public bool IsTwoFactorAuthenticationEnabled { get; set; }
        public Guid UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool SaltEnabled { get; set; }
    }

    public class PhoneValidationModel
    {
        public bool IsExist { get; set; }
        public bool IsLogin { get; set; }
    }

}
