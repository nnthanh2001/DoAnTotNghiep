using BusinessLogicLayer.BusinessWrapper;
using Entities.OwnerModels.PetHotelModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN_API.Controllers.PetHotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        IBusinessWrapper businessWrapper;
        public ServiceController(IBusinessWrapper businessWrapper)
        {
            this.businessWrapper = businessWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await businessWrapper.service.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> AddService(ServiceModel doc)
        {
            return Ok(await businessWrapper.service.Add(doc));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(ServiceModel doc, string _id)
        {
            return Ok(await businessWrapper.service.Update(doc, _id));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteService(string _id)
        {
            return Ok(await businessWrapper.service.Delete(_id));
        }
        [HttpGet("{_id}")]
        public async Task<IActionResult> GetService(string _id)
        {
            return Ok(await businessWrapper.service.GetId(_id));
        }
        [HttpGet("EditService/{_id}")]
        public async Task<IActionResult> EditService(string _id)
        {
            return Ok(await businessWrapper.service.EditService(_id));
        }
        [HttpGet("TopService(3)")]
        public async Task<IActionResult> GetTopService()
        {
            return Ok(await businessWrapper.service.GetTop());
        }
    }
}
