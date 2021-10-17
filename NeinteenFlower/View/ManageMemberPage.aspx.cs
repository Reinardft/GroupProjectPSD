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
    public partial class ManageMemberPage : System.Web.UI.Page
    {
        private List<MsMember> listMembers;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!EmployeeController.IsAdmin())
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }
                else
                {
                    listMembers = MemberController.GetTheMemberList();
                    GridView1.DataSource = listMembers;
                    GridView1.DataBind();

                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string email = row.Cells[5].Text;
            string id = MemberController.GetMemberId(email);
            MemberController.DeleteMember(int.Parse(id));
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string email = row.Cells[5].Text;
            MemberController.GetId(email);
        }
    }
}