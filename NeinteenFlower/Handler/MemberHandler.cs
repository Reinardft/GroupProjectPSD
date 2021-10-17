using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class MemberHandler
    {
        public static MsMember Login(string email, string password)
        {
            MsMember member = MemberFactory.CreateMemberLogin(email, password);
            return MemberRepository.Login(member);
        }

        public static Boolean Insert(string name, DateTime dob, string gender, string address, string phone, string email, string password)
        {
            MsMember member = MemberRepository.GetMemberByEmail(email);

            if (member != null)
            {
                return false;
            }

            MsMember newMember = MemberFactory.CreateMember(name, dob, gender, address, phone, email, password);
            MemberRepository.Insert(newMember);
            return true;
        }

        public static void Update(int id, string name, DateTime dob, string gender, string address, string phone, string email, string password)
        {

            MemberRepository.Update(id, name, dob, gender, address, phone, email, password);
        }

        public static void Delete(int id)
        {
            MemberRepository.Delete(id);
        }
        public static bool IsUnique(string email)
        {
            return MemberRepository.IsUnique(email);
        }
        public static List<MsMember> GetMemberList()
        {
            return MemberRepository.GetMemberList();
        }
        public static MsMember GetMemberByEmail(string email)
        {
            return MemberRepository.GetMemberByEmail(email);
        }
        public static MsMember GetMemberById(int id)
        {
            return MemberRepository.GetMemberById(id);
        }
        public static void setPassword(int id, string password)
        {
            MemberRepository.SetPassword(id, password);
        }
    }
}