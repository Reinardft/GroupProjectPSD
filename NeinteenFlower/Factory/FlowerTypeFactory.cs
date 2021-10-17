using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Factory
{
    public class FlowerTypeFactory
    {
        public static MsFlowerType CreateFlowerType(string typeName)
        {
            MsFlowerType flowerType = new MsFlowerType();
            flowerType.FlowerTypeName = typeName;
            return flowerType;
        }
    }
}