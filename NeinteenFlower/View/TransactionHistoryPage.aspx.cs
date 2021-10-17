using NeinteenFlower.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeinteenFlower.View
{
    public partial class TransactionHistoryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!MemberController.IsMember())
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            else
            {
                TrReport.ReportSource = TrReportController.ReportData();
            }
        }
    }
}