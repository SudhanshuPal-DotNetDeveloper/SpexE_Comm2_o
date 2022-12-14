using SpexE_Comm.Data.Data;
using SpexE_Comm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpexE_Comm.Service
{
    public interface IEncryptionService
    {
        string EncryptData(string password);
        Membership UpdateMembershipModel(MembershipModel membershipModel, Membership membership);
        string AESDecryptData(string encryptPassword, bool IsAuthentication = false, string userSalt = null);
        string AESDecrypt(string data, string userSalt = null);
        string AESEncryptData(string password, bool IsAuthentication = false, string userSalt = null);
        string DecryptApiKey(string encryptPassword);
        string DecryptData(string encryptPassword);
    }
}
