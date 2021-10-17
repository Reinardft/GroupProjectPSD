using NeinteenFlower.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (EmployeeController.IsAdmin() || EmployeeController.IsStaff() || MemberController.IsMember())
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }
                if (Request.Cookies["user"] != null)
                {
                    EmailTxt.Text = Request.Cookies["user"]["email"];
                    PasswordTxt.Text = Request.Cookies["user"]["password"];
                }
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            ErrorMsg.Text = GuestController.Login(EmailTxt.Text, PasswordTxt.Text, RememberMe.Checked);
        }
    }
}