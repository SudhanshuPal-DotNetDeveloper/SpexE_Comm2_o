using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SpexE_Comm.Data.Data
{
    public partial class UserDeviceInformation
    {
        public decimal Id { get; set; }
        public Guid? UserId { get; set; }
        public string DeviceId { get; set; }
        public string DeviceIp { get; set; }
        public string RegistrationDate { get; set; }
        public string LastLogIn { get; set; }
        public DateTime? LastLogInDate { get; set; }

        public virtual Membership User { get; set; }
    }
}
