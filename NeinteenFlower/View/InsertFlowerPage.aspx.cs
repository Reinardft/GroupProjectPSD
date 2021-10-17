using NeinteenFlower.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class InsertFlowerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!EmployeeController.IsStaff())
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
        }

        protected void InsertBtn_Click(object sender, EventArgs e)
        {
            string name = NameTxt.Text;
            string description = DescriptionTxt.Text;
            string type = FlowerTypeTxt.Text;
            string strPrice = PriceTxt.Text;
            HttpPostedFile file = ImageUpload.PostedFile;

            ErrorMsg.Text = FlowerController.Insert(name, type, description, strPrice, file);
        }
    }
}