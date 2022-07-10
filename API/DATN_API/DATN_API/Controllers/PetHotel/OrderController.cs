using BusinessLogicLayer.BusinessWrapper;
using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [HttpGet("GetOrder")]
        public async Task<IActionResult> GetOrder()
        {
            return Ok(await businessWrapper.order.GetAll());
        }
        [HttpGet("GetOrderByID/{_id}")]
        public async Task<IActionResult> GetOrderByID(string _id)
        {
            return Ok(await businessWrapper.order.GetId(_id));
        }

        [HttpGet]
        public int randomID()
        {
            Random r = new Random();
            int n = r.Next();
            return n;
        }
        [HttpPost]
        public async Task<IActionResult> Order(OrderModel doc)
        {
            return Ok(await businessWrapper.order.Add(doc));
        }
        [HttpGet("GetOrderByDay")]
        public async Task<IActionResult> GetOrderByDay(string date)
        {
            return Ok(await businessWrapper.order.GetOrderByDay(date));
        }
    }
}
