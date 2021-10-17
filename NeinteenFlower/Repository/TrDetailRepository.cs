using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class TrDetailRepository
    {
        static NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();

        public static void Insert(TrDetail d)
        {
            db.TrDetails.Add(d);
            db.SaveChanges();
        }
    }
}