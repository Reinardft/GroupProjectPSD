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
    public partial class UpdateMemberPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString["id"];
            if(id == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            if (!IsPostBack)
            {
                if (!EmployeeController.IsAdmin())
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }
                MsMember member = MemberController.GetMemberId(int.Parse(id));

                if (member != null)
                {
                EmailTxt.Text = member.MemberEmail;
                PasswordTxt.Text = member.MemberPassword;
                NameTxt.Text = member.MemberName;
                AgeTxt.Text = member.MemberDOB.ToString("yyyy-MM-dd");
                GenderList.Items.FindByValue(member.MemberGender).Selected = true;
                PhoneNumberTxt.Text = member.MemberPhone;
                AddressTxt.Text = member.MemberAddress;
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

            ErrorMsg.Text = MemberController.UpdateMember(int.Parse(id), email, password, name, age, gender, phoneNumber, address);
        }
    }
}