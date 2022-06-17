using Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Cart
{
    [Serializable]
    public class CartModel
    {
        public int cartID { get; set; }
        public ProductModel product { get; set; }
        public int quantity { get; set; }
        
    }
}
