using SpexE_Comm.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpexE_Comm.Factory.Factory
{
    public class MembershipFactory : IMembershipFactory
    {
        public MembershipModel SpexRegisterModelToMembershipModel(MembershipModel membershipModel)
        {
            MembershipModel membership = new MembershipModel
            {
                FirstName = membershipModel.FirstName,
                LastName = membershipModel.LastName,
                Email = membershipModel.Email,
                PhoneNumber = membershipModel.PhoneNumber,
                Password = membershipModel.Password,
                ProfileImageUrl = membershipModel.ProfileImageUrl
            };

            return membershipModel;
        }
    }
}
