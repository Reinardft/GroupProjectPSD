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
    public partial class ManageEmployeePage : System.Web.UI.Page
    {
        private List<MsEmployee> listEmployees;
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
                    listEmployees = EmployeeController.GetTheEmployeeList();
                    GridView1.DataSource = listEmployees;
                    GridView1.DataBind();

                }
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string email = row.Cells[5].Text;
            EmployeeController.GetId(email);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string email = row.Cells[5].Text;
            string id = EmployeeController.GetEmployeeId(email);
            EmployeeController.DeleteEmployee(int.Parse(id));
        }
    }
}