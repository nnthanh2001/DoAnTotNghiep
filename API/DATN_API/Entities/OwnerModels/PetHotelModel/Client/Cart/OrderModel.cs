using Entities.OwnerModels.PetHotelModel.Base;
using Entities.OwnerModels.PetHotelModel.Product;
using Entities.OwnerModels.PetHotelModel.User;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.OwnerModels.PetHotelModel.Client.Cart
{

    [BsonIgnoreExtraElements]
    public class OrderModel : BaseModel
    {
        public Shipping shipping { get; set; }
        public List<ProductList> productList { get; set; }
        public string payment { get; set; }
        public int subTotal { get; set; }
        public string status { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class ProductList: ProductOnCart
    {
        
        public int quantity { get; set; }
        public int total { get 
            { 
                return quantity * price; 
            } 
        }
           

    }
    [BsonIgnoreExtraElements]
    public class Shipping
    {
        public string userId { get; set; }
        public string userName { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string addressDelivery { get; set; }
    }

}
