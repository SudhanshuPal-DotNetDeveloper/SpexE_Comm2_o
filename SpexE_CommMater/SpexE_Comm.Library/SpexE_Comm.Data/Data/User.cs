using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SpexE_Comm.Data.Data
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public virtual Membership UserNavigation { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
