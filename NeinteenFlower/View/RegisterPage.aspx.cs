using NeinteenFlower.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (EmployeeController.IsAdmin() || EmployeeController.IsStaff() || MemberController.IsMember())
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxt.Text;
            string password = PasswordTxt.Text;
            string name = NameTxt.Text;
            string dob = AgeTxt.Text;
            string gender = Gender.SelectedValue.ToString();
            string phone = PhoneNumberTxt.Text;
            string address = AddressTxt.Text;
            ErrorMsg.Text = GuestController.Register(email, password, name, dob, gender, phone, address);
        }
    }
}