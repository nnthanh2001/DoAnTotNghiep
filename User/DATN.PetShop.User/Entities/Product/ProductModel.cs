using Entities.Base;
using Entities.Category;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class ProductPage
    {
        public List<CategoryModel> category { get; set; }
        public List<ProductModel> product { get; set; }
    }

    public class ProductFormModel : ProductModel
    {
       
        public List<ProductModel> productList { get; set; }
        
    }

    [Serializable]
    [BsonIgnoreExtraElements]
    public class ProductModel : ProductOnCart
    {
        public int categoryID { get; set; }
        public string productID { get; set; }
        public int petTypeID { get; set; }
        public string petTypeName { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int statusID { get; set; }
        public string statusName { get; set; }
        public int bestProduct { get; set; }
        public string bestProductExpired { get; set; }
        public bool usingExpired { get; set; }
        public string productHandle { get; set; }

    }
    [BsonIgnoreExtraElements]
    public class ProductOnCart : BaseModel
    {
        public string image { get; set; }
        public string productName { get; set; }
        public int price { get; set; }
    }
}
