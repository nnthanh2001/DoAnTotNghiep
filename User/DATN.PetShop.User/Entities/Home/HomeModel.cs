using Entities.Category;
using Entities.Product;
using Entities.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Home
{
    public class HomeModel
    {
        public List<CategoryModel> category { get; set; }
        public List<ProductModel> productNew { get; set; }
        public List<ProductModel> productBest { get; set; }
        public List<ServiceModel> service { get; set; }
    }
}
