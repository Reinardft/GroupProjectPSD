using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class TransactionHandler
    {
        public static void InsertHeader(int memberId, int employeeId, DateTime transactionDate, float discount)
        {
            TrHeader h = TransactionHeaderFactory.CreateTransactionHeader(memberId, employeeId, transactionDate, discount);
            TrHeaderRepository.Insert(h);
        }
        public static void InsertDetail(int transactionId, int flowerId, int quantity)
        {
            TrDetail d = TransactionDetailFactory.CreateTransactionDetail(transactionId, flowerId, quantity);
            TrDetailRepository.Insert(d);
        }
        
        public static int GetLastTransactionId()
        {
            TrHeader h = TrHeaderRepository.GetLastTransaction();
            return h.TransactionID;
        }
    }
}