using Entities.OwnerModels.PetHotelModel.Status;
using Entities.OwnerModels.PetHotelModel.User;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Owners.PetHotel.Staff
{
    public interface IUserFormRepository 
    {
        
        Task<UserFormModel> Add(UserFormModel doc);
        Task<bool> Update(FilterDefinition<UserFormModel> filter, UpdateDefinition<UserFormModel> update);
        Task<bool> Delete(FilterDefinition<UserFormModel> filter);
        Task<List<UserFormModel>> GetAll();
        

    }
    public interface IUserRepository
    {
        Task<UserModel> Add(UserModel doc);
        Task<bool> Update(FilterDefinition<UserModel> filter, UpdateDefinition<UserModel> update);
        Task<bool> Delete(FilterDefinition<UserModel> filter);
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetId(FilterDefinition<UserModel> filter);
        Task<UserFormModel> GetUserFormById(FilterDefinition<UserFormModel> filter);
    }
}
