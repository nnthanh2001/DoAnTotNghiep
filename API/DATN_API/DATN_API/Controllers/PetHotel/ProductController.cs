using BusinessLogicLayer.BusinessWrapper;
using Entities;
using Entities.OwnerModels.PetHotelModel.Category;
using Entities.OwnerModels.PetHotelModel.Product;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATN_API.Controllers.PetHotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IBusinessWrapper businessWrapper;
        public ProductController(IBusinessWrapper businessWrapper)
        {
            this.businessWrapper = businessWrapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductBaseModel doc)
        {
            var result = businessWrapper.product.Add(doc);
            return Ok(await result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductBaseModel doc, string _id)
        {
            return Ok(await businessWrapper.product.Update(doc, _id));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string _id)
        {
            return Ok(await businessWrapper.product.Delete(_id));
        }
        [HttpGet("Admin")]
        public async Task<IActionResult> GetAllProductFormAdmin()
        {
            return Ok(await businessWrapper.product.GetProduct());
        }
        [HttpGet("User")]
        public async Task<IActionResult> GetAllProduct(string keyWord = " ", int pageIndex = 1)
        {
            return Ok(await businessWrapper.product.GetProduct());
        }
        [HttpGet("TopProduct(4)")]
        public async Task<IActionResult> GetTopProduct()
        {
            return Ok(await businessWrapper.product.GetTop());
        }
        [HttpGet("BestProduct")]
        public async Task<IActionResult> GetBestProduct()
        {
            return Ok(await businessWrapper.product.GetBest());
        }
        [HttpGet("{_id}")]
        public  async Task<IActionResult> GetProductID(string _id)
        {
            return Ok(await businessWrapper.product.GetId(_id));
        }
        [HttpGet("EditProduct/{_id}")]
        public async Task<IActionResult> EditProductID(string _id)
        {
            return Ok(await businessWrapper.product.EditProduct(_id));
        }
        [HttpGet("AddProduct")]
        public async Task<IActionResult> AddProduct()
        {
            return Ok(await businessWrapper.product.AddProduct());
        }
    }
}
