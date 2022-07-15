using BusinessLogicLayer.BusinessWrapper;
using Entities.OwnerModels.PetHotelModel.Login;
using Entities.OwnerModels.PetHotelModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DATN_API.Controllers.PetHotel
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IBusinessWrapper BusinessWrapper;
        public UserController(IBusinessWrapper BusinessWrapper)
        {
            this.BusinessWrapper = BusinessWrapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var get = await BusinessWrapper.userForm.GetAll();
            return Ok(get);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserBaseModel doc)
        {
            var add = await BusinessWrapper.user.Add(doc);
            return Ok(add);
        }
        [HttpPut("{_id}")]
        public async Task<IActionResult> UpdateUser(UserBaseModel doc, string _id)
        {
            var upd = await BusinessWrapper.userForm.Update(doc, _id);
            return Ok(upd);
        }
        [HttpGet("{_id}")]
        public async Task<IActionResult> GetUserID(string _id)
        {
            var getUserID = await BusinessWrapper.userForm.GetId(_id);
            return Ok(getUserID);
        }
        [HttpDelete("{_id}")]
        public async Task<IActionResult> DeleteUser(string _id)
        {
            var del = await BusinessWrapper.userForm.Delete(_id);
            return Ok(del);

        }
        [HttpPost("SignInAdmin")]
        public async Task<IActionResult> GetIdStaff(LoginModel login)
        {
            var mess = await BusinessWrapper.login.GetIdStaff(login);
            return Ok(mess);
        }
        [HttpPost("SignInCustomer")]
        public async Task<IActionResult> GetIdCustomer(LoginModel login)
        {
            var mess = await BusinessWrapper.login.GetIdCustomer(login);
            return Ok(mess);
        }
        [HttpGet("EditUser/{_id}")]
        public async Task<IActionResult> EditUser(string _id)
        {
            var get = await BusinessWrapper.userForm.EditUser(_id);
            return Ok(get);
        }
        [HttpGet("AddUser")]
        public async Task<IActionResult> AddUser()
        {
            var get = await BusinessWrapper.userForm.AddUser();
            return Ok(get);
        }
        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetRole()
        {
            int roleID = 5;
            var get = await BusinessWrapper.userForm.GetByCondition(roleID);
            return Ok(get);
        }
        
    }
}
