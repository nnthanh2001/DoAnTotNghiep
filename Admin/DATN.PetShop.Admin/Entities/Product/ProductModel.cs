using Entities.Base;
using Entities.Category;
using Entities.Status;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Entities.Product
{
    [BsonIgnoreExtraElements]
    public class ProductFormModel : ProductModel
    {
        public List<PetTypeModel> petTypeList { get; set; }
        
        public List<StatusModel> statusList { get; set; }
        public List<CategoryModel> categoryList { get; set; }
    }



    [BsonIgnoreExtraElements]
    public class ProductModel : ProductBaseModel
    {
        public string petTypeName { get; set; }
        public string productTypeName { get; set; }
        public string statusName { get; set; }
        public int bestProduct { get; set; }
        public string bestProductExpired { get; set; }
        public bool usingExpired { get; set; }
        public string categoryName { get; set; }
        public int productTypeID { get; set; }
        public string productHandle { get; set; }
        
    }
    public class ProductBaseModel : BaseModel
    {
        public int quantity { get; set; }
        public string productID { get; set; }
        public string image { get; set; }
        public string productName { get; set; }
        public int petTypeID { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int statusID { get; set; }
        public int categoryID { get; set; }


    }
}
