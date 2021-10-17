using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class TransactionController
    {
        public static void InsertTransaction()
        {
            MsMember member = (MsMember)HttpContext.Current.Session["member"];
            TransactionHandler.InsertHeader(member.MemberID, 3, DateTime.Now, 0);
        }

        public static string InsertDetail(int qty)
        {
            if (qty > 100 || qty < 1)
            {
                return "Quantity must be between 1 to 100";
            }
            else
            {
                string id = HttpContext.Current.Request.QueryString["id"];
                TransactionHandler.InsertDetail(TransactionHandler.GetLastTransactionId(), int.Parse(id), qty);
                HttpContext.Current.Response.Redirect("~/View/PreorderPage.aspx");
            }
            return "";
        }
    }
}