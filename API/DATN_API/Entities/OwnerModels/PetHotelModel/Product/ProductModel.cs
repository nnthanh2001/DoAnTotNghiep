using DataAccessLayer.Owners.PetHotel.Page;
using Entities.OwnerModels.PetHotelModel.Base;
using Entities.OwnerModels.PetHotelModel.Category;
using Entities.OwnerModels.PetHotelModel.Status;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Entities.OwnerModels.PetHotelModel.Product
{
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
        public string productTypeName { get; set; }
        public string statusName { get; set; }
       
        public string categoryName { get; set; }
        public string productHandle { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class ProductBaseModel : BaseModel
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public int petTypeID { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int statusID { get; set; }
        public int categoryID { get; set; }
        public int bestProduct { get; set; }
        public string bestProductExpired { get; set; }
        public bool usingExpired { get; set; }


    }
}
