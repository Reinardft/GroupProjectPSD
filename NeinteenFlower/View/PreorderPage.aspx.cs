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
    public partial class PreorderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!MemberController.IsMember())
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }
                List<MsFlower> flowers = FlowerController.GetFlowerList();
                GridView1.DataSource = flowers;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Preorder")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string name = row.Cells[0].Text;
                string id = FlowerController.GetFlowerID(name);

                Response.Redirect("~/View/Pre OrderPage.aspx?id=" + id);
            }
        }
    }
}