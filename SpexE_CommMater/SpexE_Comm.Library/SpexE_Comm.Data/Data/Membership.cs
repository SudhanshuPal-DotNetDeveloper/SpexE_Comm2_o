using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SpexE_Comm.Data.Data
{
    public partial class Membership
    {
        public Membership()
        {
            UserDeviceInformation = new HashSet<UserDeviceInformation>();
        }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool PrivacyPolicy { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsMobileNumberVerified { get; set; }
        public bool IsEmailVerified { get; set; }
        public string UserSalt { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string ProfileImageUrl { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<UserDeviceInformation> UserDeviceInformation { get; set; }
    }
}
