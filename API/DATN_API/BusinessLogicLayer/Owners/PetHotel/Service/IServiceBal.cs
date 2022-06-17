using Entities.OwnerModels.PetHotelModel;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.PetHotel.Service
{
    public interface IServiceBal
    {
        Task<ServiceModel> Add(ServiceModel doc);
        Task<bool> Update(ServiceModel service, string _id);
        Task<bool> Delete(string _id);
        Task<List<ServiceModel>> GetAll();
        Task<ServiceModel> GetId(string _id);
        Task<ServiceFormModel> EditService(string _id);
        Task<List<ServiceModel>> GetTop();
    }
}
