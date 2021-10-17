using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class MemberFactory
    {
        public static MsMember CreateMember(string name, DateTime dob, string gender, string address, string phone, string email, string password)
        {
            MsMember member = new MsMember();
            member.MemberName = name;
            member.MemberDOB = dob;
            member.MemberGender = gender;
            member.MemberAddress = address;
            member.MemberPhone = phone;
            member.MemberEmail = email;
            member.MemberPassword = password;
            return member;
        }

        public static MsMember CreateMemberLogin(string email, string password)
        {
            MsMember member = new MsMember();
            member.MemberEmail = email;
            member.MemberPassword = password;
            return member;
        }
    }
}