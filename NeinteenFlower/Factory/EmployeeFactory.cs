using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class EmployeeFactory
    {
        public static MsEmployee CreateEmployee(string name, DateTime dob, string gender, string address, string phone, string email, int salary, string password, string role)
        {
            MsEmployee employee = new MsEmployee();
            employee.EmployeeName = name;
            employee.EmployeeDOB = dob;
            employee.EmployeeGender = gender;
            employee.EmployeeAddress = address;
            employee.EmployeePhone = phone;
            employee.EmployeeEmail = email;
            employee.EmployeeSalary = salary;
            employee.EmployeePassword = password;
            employee.EmployeeRole = role;
            return employee;
        }
        public static MsEmployee CreateEmployeeLogin(string email, string password)
        {
            MsEmployee employee = new MsEmployee();
            employee.EmployeeEmail = email;
            employee.EmployeePassword = password;
            return employee;
        }
    }
}