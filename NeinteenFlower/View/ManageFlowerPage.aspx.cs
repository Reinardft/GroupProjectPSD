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
    public partial class ManageFlowerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!EmployeeController.IsStaff())
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }
                List<MsFlower> flowers = FlowerController.GetFlowerList();
                GridView1.DataSource = flowers;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string name = row.Cells[0].Text;
            string id = FlowerController.GetFlowerID(name);

            MsFlower flowers = FlowerController.GetOneFlower(int.Parse(id));

            FlowerController.Delete(flowers);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string name = row.Cells[0].Text;
            string id = FlowerController.GetFlowerID(name);

            Response.Redirect("~/View/UpdateFlowerPage.aspx?id=" + id);
        }
    }
}