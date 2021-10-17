using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class TrHeaderRepository
    {

        static NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();

        public static void Insert (TrHeader h)
        {
            db.TrHeaders.Add(h);
            db.SaveChanges();
        }

        public static TrHeader GetLastTransaction()
        {
            List<TrHeader> list = (from x in db.TrHeaders select x).ToList();
            TrHeader h = list[list.Count - 1];
            return h;
        }
    }
}