using BusinessLogicLayer.BusinessWrapper;
using Contracts.RepositoryWrapper;
using DATN_API.Helpers;
using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Entities.OwnerModels.PetHotelModel.Product;
using Entities.OwnerModels.PetHotelModel.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATN_API.Controllers.PetHotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        IBusinessWrapper businessWrapper;
        IRepositoryWrapper repository;
        public CartController(IBusinessWrapper businessWrapper, IRepositoryWrapper repository)
        {
            this.businessWrapper = businessWrapper;
            this.repository = repository;
        }





        //[HttpGet("Order")]
        //public async Task<IActionResult> Invoice(string id)
        //{

        //    var productList = SessionHelper.GetObjectFromJson<List<CartModel>>(HttpContext.Session, "cart");
        //    if (productList == null)
        //    {
        //        return NotFound();
        //    }
        //    var user = await businessWrapper.userForm.GetId(id);

        //    var shoppingCart = new OrderModel();


        //    shoppingCart.productList = productList;
        //    shoppingCart.Shipping = user;
        //    shoppingCart.subTotal = productList.Sum(item => item.total);

        //    return Ok(shoppingCart);
        //}
        [HttpGet]
        public IActionResult Index(OrderModel cart)
        {
            if (cart == null)
            {
                return NotFound();
            }
            var productList = cart.productList;
            cart.subTotal = productList.Sum(item => item.total);

            return Ok(cart);

        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> Order(OrderModel cart)
        {
            var user = cart.shipping;
            var productList = cart.productList;
            var product_idList = productList.Select(x => x._id).ToList();

            var filter = Builders<ProductModel>.Filter.In(q => q._id, product_idList);

            var getProduct = await repository.productRepository.GetListProductById(filter);

            var pl = new List<ProductList>();
            if (getProduct != null && getProduct.Count > 0)
            {
                foreach (var item in getProduct)
                {
                    var _pid = item._id;
                    var qty = product_idList.Where(x => x == _pid).Count();
                    var itemP = productList.Where(x => x._id == _pid).FirstOrDefault();
                    var p = new ProductList
                    {
                        _id = _pid,
                        productName = item.productName,
                        price = item.price,
                        quantity = itemP.quantity = qty,
                    };
                    
                    pl.Add(p);
                }

            }
            cart.subTotal = pl.Sum(item => item.total);
            cart.productList = pl;
            return Ok(cart);
        }

        //[HttpDelete("DeleteItem/")]
        //public IActionResult Remove(string id)
        //{
        //    if (id == null || id == "")
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        List<CartModel> cart = SessionHelper.GetObjectFromJson<List<CartModel>>(HttpContext.Session, "cart");
        //        int index = isExist(id);
        //        cart.RemoveAt(index);
        //        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        //        return RedirectToAction("Index");
        //    }

        //}

        //private int isExist(string id)
        //{
        //    List<CartModel> cart = SessionHelper.GetObjectFromJson<List<CartModel>>(HttpContext.Session, "cart");
        //    for (int i = 0; i < cart.Count; i++)
        //    {
        //        if (cart[i].product._id.Equals(id))
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

    }
}
