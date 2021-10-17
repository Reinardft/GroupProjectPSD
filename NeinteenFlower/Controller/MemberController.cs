using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class MemberController
    {
        public static string Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return "Email or Password cannot be empty !";
            }
            else
            {
                MsMember member = MemberHandler.Login(email, password);
                if (member == null)
                {
                    return "User does not exist !";
                }
                else
                {
                    HttpContext.Current.Response.Redirect("~/View/HomePage.aspx");
                }
            }
            return "";
        }

        public static string InsertMember(string email, string password, string name, string age, string gender, string phoneNumber, string address)
        {
            int count = 0;

            if (!string.IsNullOrEmpty(email))
            {
                if (MemberHandler.IsUnique(email) == false)
                {
                    count = 1;
                    return "Email must be unique";
                }
                if (!GuestController.IsEmailValid(email))
                {
                    count = 1;
                    return "Email must using a correct email format";
                }
                count = 0;
            }
            else
            {
                count = 1;
                return "Email cannot be empty!";
            }

            if (!string.IsNullOrEmpty(password))
            {
                if (password.Length < 3 || password.Length > 20)
                {
                    count = 1;
                    return "Minimal Password length is 3 characters and 20 characters is the maximal";
                }
                count = 0;
            }
            else
            {
                count = 1;
                return "Password cannot be empty!";
            }

            if (!string.IsNullOrEmpty(name))
            {
                if ((name.Length < 3 || name.Length > 20))
                {
                    count = 1;
                    return "Minimal name length is 3 characters and 20 characters is the maximal";
                }
                if (!name.All(char.IsLetter))
                {
                    count = 1;
                    return "Name must be letter";
                }
                count = 0;
            }
            else
            {
                count = 1;
                return "Name cannot be empty!";
            }

            if (!string.IsNullOrEmpty(age))
            {
                DateTime dt = DateTime.Now;
                DateTime dob = Convert.ToDateTime(age);

                int days = dt.Day - dob.Day;
                int months = dt.Month - dob.Month;
                int years = dt.Year - dob.Year;

                if (days < 0)
                {
                    dt = dt.AddMonths(-1);
                    days += DateTime.DaysInMonth(dt.Year, dt.Month);
                }
                if (months < 0)
                {
                    dt = dt.AddYears(-1);
                    months += 12;
                }
                if (years < 17)
                {
                    count = 1;
                    return "Minimal age is 17 years old";
                }
                count = 0;
            }
            else
            {
                count = 1;
                return "Age cannot be empty!";
            }

            if (gender.Equals("Male") || gender.Equals("Female"))
            {
                count = 0;
            }
            else
            {
                count = 1;
                return "Gender must be chosen";
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                if (!phoneNumber.All(char.IsDigit))
                {
                    count = 1;
                    return "Phone number must be numeric";
                }
                count = 0;
            }
            else
            {
                count = 1;
                return "Phone Number cannot be empty!";
            }

            if (!string.IsNullOrEmpty(address))
            {
                if (!address.Contains("Street"))
                {
                    count = 1;
                    return "Address must contain the word Street";
                }
                count = 0;
            }
            else
            {
                count = 1;
                return "Address cannot be empty!";
            }

            if (count == 0)
            {
                DateTime ageDOB = DateTime.Parse(age);
                MemberHandler.Insert(name, ageDOB, gender, address, phoneNumber, email, password);
            }
            return "Success insert";
        }

        public static Boolean IsMember()
        {
            MsMember member = (MsMember)HttpContext.Current.Session["member"];
            if (member == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static List<MsMember> GetTheMemberList()
        {
            List<MsMember> members = MemberHandler.GetMemberList();
            return members;
        }

        public static string GetMemberId(string email)
        {
            MsMember member = MemberHandler.GetMemberByEmail(email);
            string id = member.MemberID.ToString();
            return id;
        }

        public static void GetId(string email)
        {
            MsMember member = MemberHandler.GetMemberByEmail(email);
            string id = member.MemberID.ToString();
            HttpContext.Current.Response.Redirect("~/View/UpdateMemberPage.aspx?id=" + id);

        }

        public static MsMember GetMemberId(int id)
        {
            return MemberHandler.GetMemberById(id);
        }


        public static void DeleteMember(int id)
        {
            MemberHandler.Delete(id);
            HttpContext.Current.Response.Redirect("~/View/ManageMemberPage.aspx");
        }

        public static string UpdateMember(int id, string email, string password, string name, string age, string gender, string phoneNumber, string address)
        {
            int count = 0;

            if (!string.IsNullOrEmpty(email))
            {
                if (MemberHandler.IsUnique(email) == false)
                {
                    count = 1;
                    return "Email must be unique";
                }
                if (!GuestController.IsEmailValid(email))
                {
                    count = 1;
                    return "Email must using a correct email format";
                }
                count = 0;
            }
            else
            {
                count = 1;
                return "Email cannot be empty!";
            }

            if (!string.IsNullOrEmpty(password))
            {
                if (password.Length < 3 || password.Length > 20)
                {
                    count = 1;
                    return "Minimal Password length is 3 characters and 20 characters is the maximal";
                }
                count = 0;
            }
            else
            {
                count = 1;
                return "Password cannot be empty!";
            }

            if (!string.IsNullOrEmpty(name))
            {
                bool isLetter = char.IsLetter(name.FirstOrDefault());
                if ((name.Length < 3 || name.Length > 20))
                {
                    count = 1;
                    return "Minimal name length is 3 characters and 20 characters is the maximal";
                }
                if (isLetter == false)
                {
                    count = 1;
                    return "Name must be letter";
                }
                count = 0;
            }
            else
            {
                count = 1;
                return "Name cannot be empty!";
            }

            if (!string.IsNullOrEmpty(age))
            {
                DateTime dt = DateTime.Now;
                DateTime dob = Convert.ToDateTime(age);

                int days = dt.Day - dob.Day;
                int months = dt.Month - dob.Month;
                int years = dt.Year - dob.Year;

                if (days < 0)
                {
                    dt = dt.AddMonths(-1);
                    days += DateTime.DaysInMonth(dt.Year, dt.Month);
                }
                if (months < 0)
                {
                    dt = dt.AddYears(-1);
                    months += 12;
                }
                if (years < 17)
                {
                    count = 1;
                    return "Minimal age is 17 years old";
                }
                count = 0;
            }
            else
            {
                count = 1;
                return "Age cannot be empty!";
            }

            if (gender.Equals("Male") || gender.Equals("Female"))
            {
                count = 0;
            }
            else
            {
                count = 1;
                return "Gender must be chosen";
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                if (!phoneNumber.All(char.IsDigit))
                {
                    count = 1;
                    return "Phone number must be numeric";
                }
                count = 0;
            }
            else
            {
                count = 1;
                return "Phone Number cannot be empty!";
            }

            if (!string.IsNullOrEmpty(address))
            {
                if (!address.Contains("Street"))
                {
                    count = 1;
                    return "Address must contain the word Street";
                }
                count = 0;
            }
            else
            {
                count = 1;
                return "Address cannot be empty!";
            }

            if (count == 0)
            {
                DateTime ageDOB = DateTime.Parse(age);
                MemberHandler.Update(id, name, ageDOB, gender, address, phoneNumber, email, password);
                return "Update Success";
            }
            return "Success Update";
        }
    }
}