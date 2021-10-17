using NeinteenFlower.Controller;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class UpdateEmployeePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (id == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            if (!IsPostBack)
            {
                if (!EmployeeController.IsAdmin())
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }

                MsEmployee employee = EmployeeController.GetEmployeeId(int.Parse(id));

                if (employee != null)
                {
                    EmailTxt.Text = employee.EmployeeEmail;
                    PasswordTxt.Text = employee.EmployeePassword;
                    NameTxt.Text = employee.EmployeeName;
                    var date = DateTime.Parse(employee.EmployeeDOB.ToString());
                    AgeTxt.Text = date.ToString("yyyy-MM-dd");
                    GenderList.Items.FindByValue(employee.EmployeeGender).Selected = true;
                    PhoneNumberTxt.Text = employee.EmployeePhone;
                    AddressTxt.Text = employee.EmployeeAddress;
                    SalaryTxt.Text = (employee.EmployeeSalary).ToString();
                    RoleTxt.Text = employee.EmployeeRole;
                }
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string email = EmailTxt.Text;
            string password = PasswordTxt.Text;
            string name = NameTxt.Text;
            string age = AgeTxt.Text;
            string gender = GenderList.SelectedValue.ToString();
            string phoneNumber = PhoneNumberTxt.Text;
            string address = AddressTxt.Text;
            string salary = SalaryTxt.Text;
            string role = RoleTxt.Text;

            ErrorMsg.Text = EmployeeController.UpdateEmployee(int.Parse(id), email, password, name, age, gender, phoneNumber, address, salary, role);
        }
    }
}