using NeinteenFlower.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class ForgotPasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (EmployeeController.IsAdmin() || EmployeeController.IsStaff() || MemberController.IsMember())
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }
                CaptchaLbl.Text = GuestController.RandomCaptcha();
            }
        }

        protected void ChangePasswordBtn_Click(object sender, EventArgs e)
        {
            ErrorMsg.Text = GuestController.Forgot(EmailTxt.Text, CaptchaLbl.Text, NewPasswordTxt.Text);
        }
    }
}