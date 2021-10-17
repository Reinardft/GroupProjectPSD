using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Repository
{
    public class FlowerRepository
    {
        static NeinteenFlowerDBEntities db = new NeinteenFlowerDBEntities();

        public static List<MsFlower> GetFlowerList()
        {
            return (from x in db.MsFlowers select x).ToList();
        }

        public static MsFlower GetOneFlower(int flowerId)
        {
            MsFlower query = (from x in db.MsFlowers where x.FlowerID == flowerId select x).FirstOrDefault();
            return query;
        }

        public static MsFlower GetFlowerName(string flowerName)
        {
            MsFlower query = (from x in db.MsFlowers where x.FlowerName == flowerName select x).FirstOrDefault();
            return query;
        }

        public static void Insert(MsFlower flower)
        {
            db.MsFlowers.Add(flower);
            db.SaveChanges();
        }

        public static void Delete(MsFlower flower)
        {
            db.MsFlowers.Remove(flower);
            db.SaveChanges();
        }

        public static void Update(int id, string name, int typeId, string description, int price, string imageUrl)
        {
            var query = (from x in db.MsFlowers where x.FlowerID == id select x).FirstOrDefault();

            query.FlowerName = name;
            query.FlowerImage = imageUrl;
            query.FlowerDescription = description;
            query.FlowerTypeID = typeId;
            query.FlowerPrice = price;

            db.SaveChanges();
        }
    }
}