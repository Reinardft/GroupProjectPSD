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
    public partial class Pre_OrderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MsFlower flower = FlowerController.GetOneFlower();
            if (!IsPostBack)
            {
                if (!MemberController.IsMember())
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }
                
                if (flower != null)
                {
                    FlowerNameLbl.Text = flower.FlowerName;
                    Image.ImageUrl = flower.FlowerImage;
                    DescriptionLbl.Text = flower.FlowerDescription;
                    PriceLbl.Text = flower.FlowerPrice.ToString();
                }
                else ErrorMsg.Text = "Flower doesn't exist";
            }
        }

        protected void PreorderBtn_Click(object sender, EventArgs e)
        {
            string qty = QuantityTxt.Text;
            ErrorMsg.Text =  TransactionController.InsertDetail(int.Parse(qty));
        }
    }
}