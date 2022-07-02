using BusinessLogicLayer.BusinessWrapper;
using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN_API.Controllers.PetHotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IBusinessWrapper businessWrapper;
        public OrderController(IBusinessWrapper businessWrapper)
        {
            this.businessWrapper = businessWrapper;
        }
        [HttpPost]
        public async Task<IActionResult> Order(OrderModel doc)
        {
            return Ok(await businessWrapper.invoice.Add(doc));
        }
    }
}
