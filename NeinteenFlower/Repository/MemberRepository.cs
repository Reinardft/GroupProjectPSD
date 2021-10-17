using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class MemberRepository
    {

        static NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();

        public static List<MsMember> GetMemberList()
        {
            return (from x in db.MsMembers select x).ToList();
        }

        public static MsMember Login(MsMember member)
        {
            var query = from x in db.MsMembers where x.MemberEmail.Equals(member.MemberEmail) && x.MemberPassword.Equals(member.MemberPassword) select x;
            return (query).FirstOrDefault();
        }

        public static void Insert(MsMember member)
        {
            db.MsMembers.Add(member);
            db.SaveChanges();
        } 

        public static void Delete(int memberId)
        {
            var query = (from x in db.MsMembers where x.MemberID == memberId select x).FirstOrDefault();
            db.MsMembers.Remove(query);
            db.SaveChanges();
        }

        public static void Update(int id, string name, DateTime dob, string gender, string address, string phone, string email, string password)
        {
            MsMember query = (from x in db.MsMembers where x.MemberID == id select x).FirstOrDefault();

            query.MemberName = name;
            query.MemberDOB = dob;
            query.MemberGender = gender;
            query.MemberAddress = address;
            query.MemberPhone = phone;
            query.MemberEmail = email;
            query.MemberPassword = password;

            db.SaveChanges();
        }

        public static Boolean IsUnique(string email)
        {
            var query = (from x in db.MsMembers where x.MemberEmail.Equals(email) select x).FirstOrDefault();
            if(query == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static MsMember GetMemberByEmail(string email)
        {
            var query = from x in db.MsMembers where x.MemberEmail.Equals(email) select x;
            return (query).FirstOrDefault();
        }

        public static MsMember GetMemberById(int id)
        {
            MsMember member = db.MsMembers.Where(x => x.MemberID == id).FirstOrDefault();
            return member;
        }

        public static void SetPassword(int id, string password)
        {
            MsMember query = (from x in db.MsMembers where x.MemberID == id select x).FirstOrDefault();
            query.MemberPassword = password;

            db.SaveChanges();
        }
    }
}