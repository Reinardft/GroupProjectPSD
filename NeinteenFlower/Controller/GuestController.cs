using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class GuestController
    {
        public static string Login(string email, string password, bool check)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return "Email or Password cannot be empty !";
            }
            else
            {
                MsMember member = MemberHandler.Login(email, password);
                MsEmployee employee = EmployeeHandler.Login(email, password);
                if (employee == null && member == null)
                {
                    return "User does not exist !";
                }
                else if (employee != null)
                {
                    HttpContext.Current.Session.Add("employee", employee);

                    if (check == true)
                    {
                        HttpCookie cookie = new HttpCookie("user");
                        cookie["email"] = employee.EmployeeEmail.ToString();
                        cookie["password"] = employee.EmployeePassword.ToString();
                        cookie.Expires = DateTime.Now.AddDays(1);
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }
                    HttpContext.Current.Response.Redirect("~/View/HomePage.aspx");
                }
                else if (member != null)
                {
                    HttpContext.Current.Session.Add("member", member);

                    if (check == true)
                    {
                        HttpCookie cookie = new HttpCookie("user");
                        cookie["email"] = member.MemberEmail.ToString();
                        cookie["password"] = member.MemberPassword.ToString();
                        cookie.Expires = DateTime.Now.AddDays(1);
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }
                    HttpContext.Current.Response.Redirect("~/View/HomePage.aspx");
                }
            }
            return "";
        }

        public static void Logout()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["user"];
            
            if(cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            HttpContext.Current.Session.Remove("member");
            HttpContext.Current.Session.Remove("employee");
            HttpContext.Current.Response.Redirect("~/View/LoginPage.aspx");
        }
  
        public static bool IsEmailValid(string email)
        {
            string[] split = email.Split('@');

            if (split.Length != 2)
                return false;

            if (!split[1].Contains("."))
                return false;

            if (email.StartsWith("@"))
                return false;

            if (!Char.IsLetter((split[0])[0]))
                return false;

            if (split[0].Length == 0 || split[1].Length < 3)
                return false;

            if (email.EndsWith("."))
                return false;

            if (email.Contains("..") || email.Contains(".@") || email.Contains("@.") || email.Contains("._."))
                return false;

            foreach (char c in email)
            {
                if (!Char.IsLetter(c) && !Char.IsNumber(c) && c != '_' && c != '.' && c != '@')
                    return false;
            }

            return true;
        }

        public static string Register(string email, string password, string name, string age, string gender, string phoneNumber, string address)
        {
            string errorMsg = MemberController.InsertMember(email, password, name, age, gender, phoneNumber, address);
            return errorMsg;
        }

        public static string RandomCaptcha()
        {
            string captcha = "";
            Random random = new Random();
            int x = 0;
            for (int i = 0; i < 6; i++)
            {
                if (i > 2)
                {
                    x = random.Next(9);
                    captcha += x.ToString();
                }
                else
                {
                    x = random.Next(25);
                    captcha += ((char)(x + 97)).ToString();
                }
            }
            return captcha;
        }

        public static string Forgot(string email, string captcha, string newPass)
        {
            string errorMsg = "";
            MsEmployee employee = EmployeeHandler.GetEmployeeByEmail(email);
            MsMember member = MemberHandler.GetMemberByEmail(email);
            if (member == null && employee == null)
            {
                errorMsg += "Email does not exist ";
            }
            if (member != null && newPass.Equals(captcha))
            {
                MemberHandler.setPassword(member.MemberID, newPass);
                HttpContext.Current.Response.Redirect("~/View/LoginPage.aspx");
            }
            else if(employee != null && newPass.Equals(captcha))
            {
                EmployeeHandler.setPassword(employee.EmployeeID, newPass);
                HttpContext.Current.Response.Redirect("~/View/LoginPage.aspx");
            }
            else
            {
                errorMsg += "New Password must be same as captcha";
            }
            return errorMsg;
        }
    }
}