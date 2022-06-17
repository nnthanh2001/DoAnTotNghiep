using BusinessLogicLayer.Owners.PetHotel.Login;
using Contracts.RepositoryWrapper;
using Entities.OwnerModels.PetHotelModel.Login;
using Entities.OwnerModels.PetHotelModel.User;
using Entities.OwnerModels.Request;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Owners.PetHotel.Login
{
    public class LoginDal : ILoginBal
    {
        readonly IRepositoryWrapper repository;

        public LoginDal(IRepositoryWrapper repository)
        {
            this.repository = repository;

        }
        public async Task<RequestModel<UserModel>> GetId(LoginModel login)
        {
            var response = new RequestModel<UserModel> { HttpStatusCode = 400 };

            var filter = (Builders<UserModel>.Filter.Eq(q => q.email, login.userName) | Builders<UserModel>.Filter.Eq(q => q.phone, login.userName))
           & Builders<UserModel>.Filter.Eq(q => q.password, login.password);
            var signin = await repository.loginRepository.GetId(filter);
            if (signin != null)
            {
                response.model = signin;
                response.HttpStatusCode = 200;
            }
            else
            {
                response.message = "Vui lòng nhập đúng tài khoản mật khẩu!";
            }
            return response;
        }
    }
}
