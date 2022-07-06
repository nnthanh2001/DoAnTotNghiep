using Entities.OwnerModels.PetHotelModel.Statistical;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Owners.PetHotel.Statistical
{
    public interface IStatisticalRepository
    {
        
        Task<StatisticalModel> Add(StatisticalModel doc);
        Task<bool> Update(FilterDefinition<StatisticalModel> filter, UpdateDefinition<StatisticalModel> update);
        Task<bool> Delete(FilterDefinition<StatisticalModel> filter);
        Task<List<StatisticalModel>> GetAll();
        Task<List<StatisticalModel>> GetListStatisticalById(FilterDefinition<StatisticalModel> filter);
        Task<StatisticalModel> GetId(FilterDefinition<StatisticalModel> filter);
       
        Task<StatisticalModel> GetServiceFormById(FilterDefinition<StatisticalModel> filter);
    }
}
