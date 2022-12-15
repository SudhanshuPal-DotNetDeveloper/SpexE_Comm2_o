using SpexE_Comm.Data.Data;
using SpexE_Comm.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpexE_Comm.Service
{
    public interface IMembershipService
    {
        Task<MembershipModel> CreateUser(MembershipModel membershipModel, bool enableUser = false);
        Task<bool> AssignRole(Guid userId, string role);
        Membership GetUserByEmail(string email);
        bool SaveDeviceInformation(Guid UserId, string deviceIp, string deviceId);
        LogInResponseModel LogIn(MembershipModel membership, bool isApirequest = false);
        string GetRoleByEmail(string email);
        Membership GetUserByMobileNumber(string PhoneNumber);
    }
}
