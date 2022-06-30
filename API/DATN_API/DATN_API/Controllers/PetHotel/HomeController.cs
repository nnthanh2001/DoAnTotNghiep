using BusinessLogicLayer.BusinessWrapper;
using Entities.OwnerModels.PetHotelModel.Client.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN_API.Controllers.PetHotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        IBusinessWrapper businessWrapper;
        public HomeController(IBusinessWrapper businessWrapper)
        {
            this.businessWrapper = businessWrapper;
        }
        [HttpGet]
        public async Task<IActionResult> HomePage()
        {
            var category = await businessWrapper.category.GetCategoryParent();
            var productNew = await businessWrapper.product.GetTop();
            var productBest = await businessWrapper.product.GetBest();
            var service = await businessWrapper.service.GetTop();
            var home = new HomeModel();
            home.category = category;
            home.productNew = productNew;
            home.productBest = productBest;
            home.service = service;
            return Ok(home);

        }
    }
}
