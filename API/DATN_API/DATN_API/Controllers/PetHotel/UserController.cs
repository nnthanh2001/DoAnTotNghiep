﻿using BusinessLogicLayer.BusinessWrapper;
using Entities.OwnerModels.PetHotelModel.Login;
using Entities.OwnerModels.PetHotelModel.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
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
        public async Task<IActionResult> AddUser(UserFormModel doc)
        {
            var add = await BusinessWrapper.userForm.Add(doc);
            return Ok(add);
        }
        [HttpPut]
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
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string _id)
        {
            var del = await BusinessWrapper.userForm.Delete(_id);
            return Ok(del);

        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(LoginModel login)
        {
            var add = await BusinessWrapper.login.GetId(login);

            return Ok(add);
        }
        [HttpGet("EditUser/{_id}")]
        public async Task<IActionResult> EditUser(string _id)
        {
            var get = await BusinessWrapper.userForm.EditUser(_id);
            return Ok(get);
        }
    }
}