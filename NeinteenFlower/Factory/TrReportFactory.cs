using NeinteenFlower.Dataset;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class TrReportFactory
    {
        public static TrReportDataset PopulateDataset(MsMember m)
        {
            TrReportDataset dataset = new TrReportDataset();

            var headerTrHeader = dataset.TrHeader;
            var headerTrDetail = dataset.TrDetail;
            var headerFlower = dataset.MsFlower;
            int total;
            foreach(TrHeader h in m.TrHeaders)
            {
                var rowTrHeader = headerTrHeader.NewRow();
                rowTrHeader["TransactionID"] = h.TransactionID;
                rowTrHeader["TransactionDate"] = h.TransactionDate;
                rowTrHeader["EmployeeName"] = h.MsEmployee.EmployeeName;
                rowTrHeader["DiscountPercentage"] = h.DiscountPercentage;
                total = 0;
                foreach (TrDetail d in h.TrDetails)
                {
                    var rowTrDetail = headerTrDetail.NewRow();
                    rowTrDetail["FlowerID"] = d.FlowerID;
                    rowTrDetail["Quantity"] = d.Quantity;
                    rowTrDetail["SubTotal"] = d.Quantity * d.MsFlower.FlowerPrice;
                    headerTrDetail.Rows.Add(rowTrDetail);

                    var rowFlower = headerFlower.NewRow();
                    rowFlower["FlowerName"] = d.MsFlower.FlowerName;
                    rowFlower["FlowerPrice"] = d.MsFlower.FlowerPrice;
                    headerFlower.Rows.Add(rowFlower);
                    total += d.Quantity * d.MsFlower.FlowerPrice;
                }
                rowTrHeader["GrandTotal"] = total;
                headerTrHeader.Rows.Add(rowTrHeader);

            }

            return dataset;
        }
    }
}