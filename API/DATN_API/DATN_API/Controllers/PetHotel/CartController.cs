using BusinessLogicLayer.BusinessWrapper;
using Contracts.RepositoryWrapper;
using DATN_API.Helpers;
using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Entities.OwnerModels.PetHotelModel.Product;
using Entities.OwnerModels.PetHotelModel.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                        image = item.image,
                        productHandle = item.productHandle,
                        quantity = itemP.quantity = qty,
                    };

                    pl.Add(p);
                }

            }
            cart.subTotal = pl.Sum(item => item.total);
            cart.productList = pl;
            return Ok(cart);
        }
    }
}
