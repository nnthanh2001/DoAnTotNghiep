using Entities.OwnerModels.PetHotelModel.Login;
using Entities.OwnerModels.PetHotelModel.User;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Owners.PetHotel.Login
{
    public interface ILoginRepository
    {
        Task<LoginModel> Add(LoginModel doc);
        Task<bool> Update(FilterDefinition<LoginModel> filter, UpdateDefinition<LoginModel> update);
        Task<bool> Delete(FilterDefinition<LoginModel> filter);
        Task<List<LoginModel>> GetAll();
        Task<UserModel> GetId(FilterDefinition<UserModel> filter);
    }
}
