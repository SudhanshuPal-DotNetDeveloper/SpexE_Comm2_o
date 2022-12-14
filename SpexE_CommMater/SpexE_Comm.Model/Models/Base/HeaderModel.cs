using System;
using System.Collections.Generic;
using System.Text;

namespace SpexE_Comm.Model.Models.Base
{
    public partial class HeaderModel
    {
        public string UserName { get; set; }
        public string SearchTerm { get; set; }
        public int CartItems { get; set; }
    }
}
