using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class TransactionHeaderFactory
    {
        public static TrHeader CreateTransactionHeader(int memberId, int employeeId, DateTime transactionDate, float discount)
        {
            TrHeader transactionHeader = new TrHeader()
            {
                MemberID = memberId,
                EmployeeID = employeeId,
                TransactionDate = transactionDate,
                DiscountPercentage = discount,
            };
            return transactionHeader;
        }
    }
}