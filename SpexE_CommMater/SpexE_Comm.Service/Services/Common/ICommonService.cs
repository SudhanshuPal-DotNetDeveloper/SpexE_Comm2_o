using System;
using System.Collections.Generic;
using System.Text;

namespace SpexE_Comm.Service
{
    public interface ICommonService
    {
        string FormateMobileNumber(string mobileNumber);
        string GenerateOpt(int digit = 0);
        string FormateMobileNumberWithHyphen(string mobileNumber);
    }
}
