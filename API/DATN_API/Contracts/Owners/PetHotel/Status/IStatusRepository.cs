using Entities.OwnerModels.PetHotelModel.Status;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Owners.PetHotel.Status
{
    public interface IStatusRepository
    {
        Task<List<StatusModel>> GetAll(SortDefinition<StatusModel> sort = null, int limit = 0);
        Task<StatusModel> Add(StatusModel doc);
        Task<bool> Update(FilterDefinition<StatusModel> filter, UpdateDefinition<StatusModel> update);
        Task<bool> Delete(FilterDefinition<StatusModel> filter);
        Task<StatusModel> GetId(FilterDefinition<StatusModel> filter);
    }
}
