using Entities.Base;
using Entities.Product;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Order
{
    [BsonIgnoreExtraElements]
    public class OrderModel : BaseModel
    {
        public int orderID { get; set; }
        public Shipping shipping { get; set; }
        public List<ProductList> productList { get; set; }
        public string payment { get; set; }
        public int subTotal { get; set; }
        public string status { get; set; }
        public string date { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class ProductList : ProductOnCart
    {
        public string productHandle { get; set; }
        public string image { get; set; }
        public int quantity { get; set; }
        public int total { get; set; }



    }
    [BsonIgnoreExtraElements]
    public class ProductOnCart : BaseModel
    {
        public string productName { get; set; }
        public int price { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Shipping
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public long phone { get; set; }
        public string email { get; set; }
        public string addressDelivery { get; set; }
    }

}
