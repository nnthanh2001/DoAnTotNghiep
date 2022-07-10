using DataAccessLayer.Owners.PetHotel.Page;
using Entities.OwnerModels.PetHotelModel.Base;
using Entities.OwnerModels.PetHotelModel.Category;
using Entities.OwnerModels.PetHotelModel.Status;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Entities.OwnerModels.PetHotelModel.Product
{
    public class ProductPage
    {
        public List<CategoryModel> category { get; set; }
        public List<ProductModel> product { get; set; }
    }
    public class ProductDetailPage
    {
        public ProductBaseModel productDetail { get; set; }
        public List<ProductModel> productList { get; set; }
    }


    [BsonIgnoreExtraElements]
    public class ProductFormModel : ProductModel
    {
        public List<PetTypeModel> petTypeList { get; set; }
        public List<StatusModel> statusList { get; set; }
        public List<PageModel> pageList { get; set; }
        public List<CategoryModel> categoryList { get; set; }
    }

    

   [BsonIgnoreExtraElements]
    public class ProductModel : ProductBaseModel
    {
        public string petTypeName { get; set; }
        public string statusName { get; set; }
        public string categoryName { get; set; }
        
    }
    [BsonIgnoreExtraElements]
    public class ProductBaseModel : ProductOnCart
    {
        
        
        public int petTypeID { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public string image { get; set; }
        public int statusID { get; set; }
        public int categoryID { get; set; }
        public int bestProduct { get; set; }
        public string bestProductExpired { get; set; }
        public bool usingExpired { get; set; }
        public string productHandle { get; set; }
        public string productID { get; set; }

    }
    [BsonIgnoreExtraElements]
    public class ProductOnCart : BaseModel
    {
        
        public string productName { get; set; }
        public int price { get; set; }
    }
}
