using BusinessLogicLayer.BusinessWrapper;
using Contracts.RepositoryWrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN_API.Controllers.PetHotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticalController : ControllerBase
    {
        IBusinessWrapper businessWrapper;
        IRepositoryWrapper repository;
        public StatisticalController(IBusinessWrapper businessWrapper, IRepositoryWrapper repository)
        {
            this.businessWrapper = businessWrapper;
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await businessWrapper.statistical.GetAll());
        }
        [HttpGet("{_id}")]
        public async Task<IActionResult> GetId(string _id)
        {
            return Ok(await businessWrapper.statistical.GetId(_id));
        }
        [HttpGet("GetStatisticalByMonth")]
        public async Task<IActionResult> GetStatisticalByMonth(string month)
        {
            return Ok(await businessWrapper.statistical.GetStatisticalByMonth(month));
        }
    }
}
