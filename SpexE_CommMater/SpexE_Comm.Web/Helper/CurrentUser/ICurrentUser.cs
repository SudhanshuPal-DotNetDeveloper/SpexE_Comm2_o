using SpexE_Comm.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpexE_Comm.Web.Helper.CurrentUser
{
    public interface ICurrentUser
    {
        string GetIPAddress();
        Membership GetCurrentUser();
    }
}
