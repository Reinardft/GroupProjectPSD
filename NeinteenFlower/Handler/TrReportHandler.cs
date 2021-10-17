using NeinteenFlower.Dataset;
using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class TrReportHandler
    {
        public static TrReportDataset GetDataset(int id)
        {
            MsMember m = MemberHandler.GetMemberById(id);
            return TrReportFactory.PopulateDataset(m);
        }
    }
}