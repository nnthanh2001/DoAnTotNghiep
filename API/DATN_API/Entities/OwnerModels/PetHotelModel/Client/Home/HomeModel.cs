using Entities.OwnerModels.PetHotelModel;
using Entities.OwnerModels.PetHotelModel.Category;
using Entities.OwnerModels.PetHotelModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.OwnerModels.PetHotelModel.Client.Home
{
    public class HomeModel
    {
        public List<CategoryModel> category { get; set; }
        public List<ProductModel> productNew { get; set; }
        public List<ProductModel> productBest { get; set; }
        public List<ServiceModel> service { get; set; }
    }
}
