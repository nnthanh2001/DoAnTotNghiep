using BusinessLogicLayer.BusinessWrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(await businessWrapper.category.GetParent());
        }
        [HttpGet("GetCategoryChild")]
        public async Task<IActionResult> GetCategoryChild()
        {
            return Ok(await businessWrapper.category.GetChild());
        }
        [HttpGet("GetCategoryByOderNo")]
        public async Task<IActionResult> GetCategoryByOderNo()
        {
            return Ok(await businessWrapper.category.GetCategoryByOderNo());
        }
    }
}
