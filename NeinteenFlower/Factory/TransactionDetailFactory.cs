using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class TransactionDetailFactory
    {
        public static TrDetail CreateTransactionDetail (int transactionId, int flowerId, int quantity)
        {
            TrDetail transactionDetail = new TrDetail()
            {
                TransactionID = transactionId,
                FlowerID = flowerId,
                Quantity = quantity,
            };
            return transactionDetail;
        }
    }
}