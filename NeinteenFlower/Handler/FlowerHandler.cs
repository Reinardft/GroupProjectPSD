using NeinteenFlower.Factory;
using NeinteenFlower.Model;
using NeinteenFlower.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Handler
{
    public class FlowerHandler
    {
        public static List<MsFlower> GetFlowerList()
        {
            return FlowerRepository.GetFlowerList();
        }

        public static MsFlower GetOneFlower(int flowerId)
        {
            return FlowerRepository.GetOneFlower(flowerId);
        }

        public static MsFlower GetFlowerName(string flowerName)
        {
            return FlowerRepository.GetFlowerName(flowerName);
        }

        public static void Insert(string name, int typeId, string description, int price, string imageUrl)
        {
            MsFlower flower = FlowerFactory.CreateFlower(name, typeId, description, price, imageUrl);

            FlowerRepository.Insert(flower);
        }

        public static void Update(int id, string name, int typeId, string description, int price, string imageUrl)
        {
            FlowerRepository.Update(id, name, typeId, description, price, imageUrl);
        }

        public static void Delete(MsFlower flower)
        {
            FlowerRepository.Delete(flower);
        }
    }
}