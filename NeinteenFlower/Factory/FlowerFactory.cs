using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class FlowerFactory
    {
        public static MsFlower CreateFlower(string name, int type, string description, int price, string imageUrl)
        {
            MsFlower flower = new MsFlower();
            flower.FlowerName = name;
            flower.FlowerTypeID = type;
            flower.FlowerDescription = description;
            flower.FlowerPrice = price;
            flower.FlowerImage = imageUrl;
            return flower;
        }
    }
}