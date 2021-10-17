using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class EmployeeController
    {
        public static string Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return "Email or Password cannot be empty !";
            }
            else
            {
                MsEmployee employee = EmployeeHandler.Login(email, password);
                if (employee == null)
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

        public static string InsertEmployee(string email, string password, string name, string age, string gender, string phone, string address, string salary, string role)
        {
            int count = 0;
            int salaryInt = 0;

            if (!string.IsNullOrEmpty(email))
            {
                if (EmployeeHandler.IsUnique(email) == false)
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

            if (!string.IsNullOrEmpty(phone))
            {
                if (!phone.All(char.IsDigit))
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

            if (!string.IsNullOrEmpty(salary))
            {
                
                if (char.IsNumber(salary.FirstOrDefault()) == false) return " Salary must be numeric !\n";
                else count = 0;

                salaryInt = int.Parse(salary);
                if (salaryInt < 100 || salaryInt > 1000) return " Salary must between 100 to 1000 inclusively! \n";
                else count = 0;
            }
            else
            {
                count = 1;
                return " Salary cannot be empty! \n";
            }

            if (!string.IsNullOrEmpty(role))
            {
                if (role.Equals("Staff") || role.Equals("Administrator"))
                {
                    count = 0;
                }
                else return "Role must either \'Staff\' or \'Administrator\' \n";
            }
            else
            {
                count = 1;
                return "Role cannot be empty! \n";
            }

            if (count == 0)
            {
                DateTime ageDOB = DateTime.Parse(age);
                EmployeeHandler.Insert(name, ageDOB, gender, address, phone, email, salaryInt, password, role);
                return "Insert Success";
            }
            else
            {
                return "Insert error";
            }
        }

        public static Boolean IsAdmin()
        {
            MsEmployee employee = (MsEmployee)HttpContext.Current.Session["employee"];
            if (employee == null)
            {
                return false;
            }
            else
            {
                if (employee.EmployeeRole.Equals("Administrator"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static Boolean IsStaff()
        {
            MsEmployee employee = (MsEmployee)HttpContext.Current.Session["employee"];
            if (employee == null)
            {
                return false;
            }
            else
            {
                if (employee.EmployeeRole.Equals("Staff"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<MsEmployee> GetTheEmployeeList()
        {
            List<MsEmployee> employees = EmployeeHandler.GetEmployeesList();
            return employees;
        }

        public static string GetEmployeeId(string email)
        {
            MsEmployee employee = EmployeeHandler.GetEmployeeByEmail(email);
            string id = employee.EmployeeID.ToString();
            return id;
        }

        public static void GetId(string email)
        {
            MsEmployee employee = EmployeeHandler.GetEmployeeByEmail(email);
            string id = employee.EmployeeID.ToString();
            HttpContext.Current.Response.Redirect("~/View/UpdateEmployeePage.aspx?id=" + id);
        }

        public static MsEmployee GetEmployeeId(int id)
        {
            return EmployeeHandler.GetEmployeeById(id);
        }

        public static void DeleteEmployee(int id)
        {
            EmployeeHandler.Delete(id);
            HttpContext.Current.Response.Redirect("~/View/ManageEmployeePage.aspx");
        }

        public static string UpdateEmployee(int id, string email, string password, string name, string age, string gender, string phone, string address, string salary, string role)
        {
            int count = 0;
            int salaryInt = 0;

            if (!string.IsNullOrEmpty(email))
            {
                if (EmployeeHandler.IsUnique(email) == false)
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

            if (!string.IsNullOrEmpty(phone))
            {
                if (!phone.All(char.IsDigit))
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

            if (!string.IsNullOrEmpty(salary))
            {
                salaryInt = int.Parse(salary);
                if (char.IsNumber(salary.FirstOrDefault()) == false) return " Salary must be numeric !\n";
                else count = 0;

                if (salaryInt < 100 || salaryInt > 1000) return " Salary must between 100 to 1000 inclusively! \n";
                else count = 0;
            }
            else
            {
                count = 1;
                return " Salary cannot be empty! \n";
            }

            if (!string.IsNullOrEmpty(role))
            {
                if (role.Equals("Staff") || role.Equals("Administrator"))
                {
                    count = 0;
                }
                else return "Role must either \'Staff\' or \'Administrator\' \n";
            }
            else
            {
                count = 1;
                return "Role cannot be empty! \n";
            }

            if (count == 0)
            {
                DateTime ageDOB = DateTime.Parse(age);
                EmployeeHandler.Update(id, name, ageDOB, gender, address, phone, email, salaryInt, password, role);
                return "Update Success";
            }
            return "Update Success";
        }
    }

}