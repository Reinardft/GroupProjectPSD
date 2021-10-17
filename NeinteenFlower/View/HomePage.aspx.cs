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
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (EmployeeController.IsAdmin() || EmployeeController.IsStaff())
            {
                MsEmployee x = (MsEmployee)HttpContext.Current.Session["employee"];
                UsernameLbl.Text = x.EmployeeName.ToString();
                if (EmployeeController.IsAdmin())
                {
                    ManageEmployeeBtn.Visible = true;
                    ManageMemberBtn.Visible = true;
                }
                else
                {
                    ManageFlowerBtn.Visible = true;
                }
            }
            else if(MemberController.IsMember())
            {
                MsMember x = (MsMember)HttpContext.Current.Session["member"];
                UsernameLbl.Text = x.MemberName.ToString();
                PreorderBtn.Visible = true;
                ViewTransactionBtn.Visible = true;
            }
            else
            {
                Response.Redirect("~/View/LoginPage.aspx");
            }
        }

        protected void ManageFlowerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageFlowerPage.aspx");
        }

        protected void ManageMemberBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageMemberPage.aspx");
        }

        protected void ManageEmployeeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageEmployeePage.aspx");
        }

        protected void PreorderBtn_Click(object sender, EventArgs e)
        {
            TransactionController.InsertTransaction();
            Response.Redirect("~/View/PreorderPage.aspx");
        }

        protected void ViewTransactionBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionHistoryPage.aspx");
        }
    }
}