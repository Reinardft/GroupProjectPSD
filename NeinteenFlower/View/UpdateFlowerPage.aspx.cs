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
    public partial class UpdateFlowerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsFlower flower = FlowerController.GetOneFlower();
            if (!IsPostBack)
            {
                if (!EmployeeController.IsStaff())
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }
                
                if (flower != null)
                {
                    NameTxt.Text = flower.FlowerName;
                    ImgUpload.ImageUrl = flower.FlowerImage;
                    DescriptionTxt.Text = flower.FlowerDescription;
                    FlowerTypeTxt.Text = flower.MsFlowerType.FlowerTypeName;
                    PriceTxt.Text = flower.FlowerPrice.ToString();
                }
                else ErrorMsg.Text = "Flower doesn't exist";
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string name = NameTxt.Text;
            string description = DescriptionTxt.Text;
            string type = FlowerTypeTxt.Text;
            string strPrice = PriceTxt.Text;
            HttpPostedFile file = ImageUpload.PostedFile;

            ErrorMsg.Text = FlowerController.Update(id, name, type, description, strPrice, file);
        }
    }
}