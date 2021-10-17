using NeinteenFlower.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class InsertMemberPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EmployeeController.IsAdmin())
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxt.Text;
            string password = PasswordTxt.Text;
            string name = NameTxt.Text;
            string age = AgeTxt.Text;
            string gender = GenderList.SelectedValue.ToString();
            string phoneNumber = PhoneNumberTxt.Text;
            string address = AddressTxt.Text;

            ErrorMsg.Text = MemberController.InsertMember(email, password, name, age, gender, phoneNumber, address);
        }
    }
}