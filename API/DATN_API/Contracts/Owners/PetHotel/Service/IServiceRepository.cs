using Entities.OwnerModels.PetHotelModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Owners.PetHotel.Service
{
    public interface IServiceRepository
    {
        Task<ServiceModel> Add(ServiceModel doc);
        Task<bool> Update(FilterDefinition<ServiceModel> filter, UpdateDefinition<ServiceModel> update);
        Task<bool> Delete(FilterDefinition<ServiceModel> filter);
        Task<List<ServiceModel>> GetAll();
        Task<List<ServiceModel>> GetTopService(SortDefinition<ServiceModel> sort = null, int limit = 0);
        Task<ServiceModel> GetId(FilterDefinition<ServiceModel> filter);
        Task<ServiceFormModel> GetServiceFormById(FilterDefinition<ServiceFormModel> filter);
    }
}
