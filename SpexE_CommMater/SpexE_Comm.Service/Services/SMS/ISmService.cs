using System;
using System.Collections.Generic;
using System.Text;

namespace SpexE_Comm.Service
{
    public interface ISmService
    {
        bool SendSms(string mobileNumber, string messageContent, string senderName);
    }
}
