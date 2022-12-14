using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SpexE_Comm.Data.Data
{
    public partial class SpexCommKeys
    {
        public decimal Id { get; set; }
        public string ApiName { get; set; }
        public string ApiKey { get; set; }
        public bool? IsActive { get; set; }
        public int ApiCode { get; set; }
        public bool? IsEncrypted { get; set; }
    }
}
