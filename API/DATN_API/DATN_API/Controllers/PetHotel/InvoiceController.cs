using BusinessLogicLayer.BusinessWrapper;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DATN_API.Controllers.PetHotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        IBusinessWrapper businessWrapper;
        public InvoiceController(IBusinessWrapper businessWrapper)
        {
            this.businessWrapper = businessWrapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await businessWrapper.order.GetAll());
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            return Ok(await businessWrapper.order.Delete(id));
        }
    }
}
