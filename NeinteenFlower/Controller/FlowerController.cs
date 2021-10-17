using NeinteenFlower.Handler;
using NeinteenFlower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeinteenFlower.Controller
{
    public class FlowerController
    {
        public static List<MsFlower> GetFlowerList()
        {
            return FlowerHandler.GetFlowerList();
        }

        public static string GetFlowerID(string flowerName)
        {
            MsFlower flower = FlowerHandler.GetFlowerName(flowerName);
            string id = flower.FlowerID.ToString();
            return id;
        }

        public static MsFlower GetOneFlower()
        {
            string reqId = HttpContext.Current.Request.QueryString["id"];
            if(reqId == null)
            {
                HttpContext.Current.Response.Redirect("~/View/HomePage.aspx");
                return null;
            }
            else
            {
                int id = int.Parse(reqId);
                return FlowerHandler.GetOneFlower(id);
            }
        }
        public static MsFlower GetOneFlower(int flowerId)
        {
            return FlowerHandler.GetOneFlower(flowerId);
        }
        public static string Insert(string name, string type, string description, string strPrice, HttpPostedFile file)
        {
            int price = 0;
            int typeId = 0;
            int count = 0;
            string imageUrl = "";

            if (name.Equals("")) return "Flower Name Must be filled ";
            if (name.Length < 5) return "Flower Name minimal length is 5 characters ";
            else count++;

            if (file.FileName.EndsWith(".jpg"))
            {
                var filepath = HttpContext.Current.Server.MapPath("~/Image/" + file.FileName);
                imageUrl = "../Image/" + file.FileName;
                file.SaveAs(filepath);
                count++;
            }
            else return "Image extension must ends with “.jpg” ";

            if (description.Length < 50) return "Description must be longer than 50 characters ";
            else count++;

            if (!type.Equals("Daisies") && !type.Equals("Lilies") && !type.Equals("Roses")) return "Must be either 'Daisies', 'Lilies' or 'Roses' ";
            if (type.Equals("Daisies"))
            {
                typeId = 1;
                count++;
            }
            if (type.Equals("Lilies"))
            {
                typeId = 2;
                count++;
            }
            if (type.Equals("Roses"))
            {
                typeId = 3;
                count++;
            }

            if (!strPrice.Equals(""))
            {
                if (!strPrice.All(char.IsDigit)) return "Price must be numeric ";
                else
                {
                    price = int.Parse(strPrice);
                    if (price < 20 || price > 100) return "Price must be between 20 and 100 inclusively ";
                    else count++;
                }
            }
            else return "Price cannot be empty ";

            if (count == 5)
            {
                FlowerHandler.Insert(name, typeId, description, price, imageUrl);

                return "Flower Input Success ";
            }
            else return "";
        }

        public static string Update(string id, string name, string type, string description, string strPrice, HttpPostedFile file)
        {
            int price = 0;
            int typeId = 0;
            int count = 0;
            string imageUrl = "";

            if (name.Equals("")) return "Flower Name Must be filled ";
            if (name.Length < 5) return "Flower Name minimal length is 5 characters ";
            else count++;

            if (file.FileName.EndsWith(".jpg"))
            {
                var filepath = HttpContext.Current.Server.MapPath("~/Image/" + file.FileName);
                imageUrl = "../Image/" + file.FileName;
                file.SaveAs(filepath);
                count++;
            }
            else return "Image extension must ends with “.jpg” ";

            if (description.Length < 50) return "Description must be longer than 50 characters ";
            else count++;

            if (!type.Equals("Daisies") && !type.Equals("Lilies") && !type.Equals("Roses")) return "Must be either 'Daisies', 'Lilies' or 'Roses' ";
            if (type.Equals("Daisies"))
            {
                typeId = 1;
                count++;
            }
            if (type.Equals("Lilies"))
            {
                typeId = 2;
                count++;
            }
            if (type.Equals("Roses"))
            {
                typeId = 3;
                count++;
            }

            if (!strPrice.Equals(""))
            {
                if (!strPrice.All(char.IsDigit)) return "Price must be numeric ";
                else
                {
                    price = int.Parse(strPrice);
                    if (price < 20 || price > 100) return "Price must be between 20 and 100 inclusively ";
                    else count++;
                }
            }
            else return "Price cannot be empty ";

            if (count == 5)
            {
                id = HttpContext.Current.Request.QueryString["id"];
                FlowerHandler.Update(int.Parse(id), name, typeId, description, price, imageUrl);

                return "Flower Update Success ";
            }
            else return "";
        }

        public static void Delete(MsFlower flower)
        {
            if (flower != null)
            {
                FlowerHandler.Delete(flower);
                HttpContext.Current.Response.Redirect("~/View/ManageflowerPage.aspx");
            }
            else return;
        }
    }
}