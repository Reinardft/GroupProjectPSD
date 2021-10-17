using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class EmployeeHandler
    {
        public static MsEmployee Login(string email, string password)
        {
            MsEmployee employee = EmployeeFactory.CreateEmployeeLogin(email, password);
            return EmployeeRepository.Login(employee);
        }

        public static Boolean Insert(string name, DateTime dob, string gender, string address, string phone, string email, int salary, string password, string role)
        {
            MsEmployee empolyee = EmployeeRepository.GetEmployeeByEmail(email);

            if (empolyee != null)
            {
                return false;
            }

            MsEmployee newEmployee = EmployeeFactory.CreateEmployee(name, dob, gender, address, phone, email, salary, password, role);
            EmployeeRepository.Insert(newEmployee);
            return true;
        }

        public static void Update(int id, string name, DateTime dob, string gender, string address, string phone, string email, int salary, string password, string role)
        {

            EmployeeRepository.Update(id, name, dob, gender, address, phone, email, salary, password, role);
        }

        public static void Delete(int id)
        {
            EmployeeRepository.Delete(id);
        }

        public static bool IsUnique(string email)
        {
            return EmployeeRepository.IsUnique(email);
        }

        public static List<MsEmployee> GetEmployeesList()
        {
            return EmployeeRepository.GetEmployeeList();
        }

        public static MsEmployee GetEmployeeById(int id)
        {
            return EmployeeRepository.GetEmployeeById(id);
        }

        public static MsEmployee GetEmployeeByEmail(string email)
        {
            return EmployeeRepository.GetEmployeeByEmail(email);
        }

        public static void setPassword( int id, string password)
        {
            EmployeeRepository.SetPassword(id, password);
        }
    }
}