using Entities.OwnerModels.PetHotelModel.Status;
using Entities.OwnerModels.PetHotelModel.User;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.PetHotel
{
    public interface IUserFormBal
    {
        Task<UserFormModel> Add(UserFormModel doc);
        Task<bool> Update(UserBaseModel doc, string _id);
        Task<bool> Delete(string _id);
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetId(string _id);
        Task<UserFormModel> EditUser(string _id);
    }
    public interface IUserBal
    {
        Task<UserModel> Add(UserModel doc);
        Task<bool> Update(UserModel doc, string _id);
        Task<bool> Delete(string _id);
        Task<List<UserModel>> GetAll();
        //Task<UserModel> GetId(string _id);
    }
}
