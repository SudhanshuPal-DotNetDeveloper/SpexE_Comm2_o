using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpexE_Comm.Service
{
    public class CommonService : ICommonService
    {
        public string FormateMobileNumber(string mobileNumber)
        {
            string formatedNumber = string.Empty;
            if (!string.IsNullOrEmpty(mobileNumber))
            {
                if (mobileNumber.IndexOf("-") >= 0)
                {
                    formatedNumber = mobileNumber.Replace("-", "");
                }
                else
                {
                    formatedNumber = mobileNumber;
                }
            }
            return formatedNumber;
        }

        public string GenerateOpt(int digit = 0)
        {
            Random generator = new Random();
            int max = (digit == 0) ? 1000000 : 9999;
            int min = (digit == 0) ? 0 : 1000;

            string ranFormat = (digit == 0) ? "D6" : "D" + digit.ToString();

            String r = generator.Next(min, max).ToString(ranFormat);
            if (r.Distinct().Count() == 1)
            {
                r = GenerateOpt();
            }
            return r;
        }

        public string FormateMobileNumberWithHyphen(string mobileNumber)
        {
            string formatedNumber = string.Empty;
            if (!string.IsNullOrEmpty(mobileNumber))
            {
                if (mobileNumber.IndexOf("-") >= 0)
                {
                    return mobileNumber;
                }
                else
                {
                    return mobileNumber.Substring(0, 3) + "-" + mobileNumber.Substring(3, 3) + "-" + mobileNumber.Substring(6, 4);
                }
            }
            return mobileNumber;
        }
    }
}
