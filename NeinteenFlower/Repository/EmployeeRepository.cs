using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class EmployeeRepository
    {
        static NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();

        public static List<MsEmployee> GetEmployeeList()
        {
            return (from x in db.MsEmployees select x).ToList();
        }

        public static MsEmployee Login(MsEmployee employee)
        {
            var query = from x in db.MsEmployees where x.EmployeeEmail.Equals(employee.EmployeeEmail) && x.EmployeePassword.Equals(employee.EmployeePassword) select x;
            return (query).FirstOrDefault();
        }

        public static void Insert(MsEmployee employee)
        {
            db.MsEmployees.Add(employee);
            db.SaveChanges();
        }

        public static void Delete(int employeeId)
        {
            var query = (from x in db.MsEmployees where x.EmployeeID == employeeId select x).FirstOrDefault();
            db.MsEmployees.Remove(query);
            db.SaveChanges();
        }

        public static void Update(int id, string name, DateTime dob, string gender, string address, string phone, string email, int salary, string password, string role)
        {
            MsEmployee query = (from x in db.MsEmployees where x.EmployeeID == id select x).FirstOrDefault();

            query.EmployeeName = name;
            query.EmployeeDOB = dob;
            query.EmployeeGender = gender;
            query.EmployeeAddress = address;
            query.EmployeePhone = phone;
            query.EmployeeEmail = email;
            query.EmployeeSalary = salary;
            query.EmployeePassword = password;
            query.EmployeeRole = role;
            db.SaveChanges();
        }

        public static Boolean IsUnique(string email)
        {
            var query = (from x in db.MsEmployees where x.EmployeeEmail.Equals(email) select x).FirstOrDefault();
            if (query == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public static MsEmployee GetEmployeeById(int id)
        {
            MsEmployee employee = db.MsEmployees.Where(x => x.EmployeeID == id).FirstOrDefault();
            return employee;
        }

        public static MsEmployee GetEmployeeByEmail(string email)
        {
            var query = from x in db.MsEmployees where x.EmployeeEmail.Equals(email) select x;
            return (query).FirstOrDefault();
        }

        public static void SetPassword(int id, string password)
        {
            MsEmployee query = (from x in db.MsEmployees where x.EmployeeID == id select x).FirstOrDefault();
            query.EmployeePassword = password;

            db.SaveChanges();
        }
    }
}