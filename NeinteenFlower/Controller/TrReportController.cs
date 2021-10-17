using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using NeinteenFlower.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class TrReportController
    {
        public static TrReport ReportData()
        {
            MsMember member = (MsMember)HttpContext.Current.Session["member"];
            TrReport report = new TrReport();
            report.SetDataSource(TrReportHandler.GetDataset(member.MemberID));
            return report;
        }
    }
}