using SpexE_Comm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpexE_Comm.Factory
{
    public interface IMembershipFactory
    {
        MembershipModel SpexRegisterModelToMembershipModel(MembershipModel membershipModel);
    }
}
