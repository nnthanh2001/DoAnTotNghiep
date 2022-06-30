using BusinessLogicLayer.BusinessWrapper;
using Entities.OwnerModels.PetHotelModel.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace DATN_API.Controllers.PetHotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IBusinessWrapper businessWrapper;
        public CategoryController(IBusinessWrapper businessWrapper)
        {
            this.businessWrapper = businessWrapper;
        }
        [HttpGet("GetCategoryParent")]
        public async Task<IActionResult> GetCategoryParent()
        {
            return Ok(await businessWrapper.category.GetCategoryParent());
        }
        [HttpGet("GetCategoryChild")]
        public async Task<IActionResult> GetCategoryChild()
        {
            return Ok(await businessWrapper.category.GetCategoryChild());
        }
        [HttpGet("GetCategoryByOderNo")]
        public async Task<IActionResult> GetCategoryByOderNo()
        {
            return Ok(await businessWrapper.category.GetCategoryByOderNo());
        }
        [HttpGet("GetProductByCategory")]
        public async Task<IActionResult> GetProductByCategory(int id)
        {
            return Ok(await businessWrapper.product.GetProductByCategory(id));
        }
    }
}
