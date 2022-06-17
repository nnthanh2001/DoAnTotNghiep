using Entities.Base;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Product
{
    public class ProductFormModel : ProductModel
    {
        //public List<PetTypeModel> petTypeList { get; set; }
        //public List<ProductTypeModel> productTypeList { get; set; }
        public List<ProductModel> productList { get; set; }
        //public List<StatusModel> statusList { get; set; }
    }

    [Serializable]
    [BsonIgnoreExtraElements]
    public class ProductModel : BaseModel
    {

        public int productID { get; set; }
        public int imageID { get; set; }
        public string productName { get; set; }
        public int petTypeID { get; set; }
        public string petTypeName { get; set; }
        public int productTypeID { get; set; }
        public string productTypeName { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int statusID { get; set; }
        public string statusName { get; set; }
        public int bestProduct { get; set; }
        public string bestProductExpired { get; set; }
        public bool usingExpired { get; set; }
        public string productHandle { get; set; }

    }
}
