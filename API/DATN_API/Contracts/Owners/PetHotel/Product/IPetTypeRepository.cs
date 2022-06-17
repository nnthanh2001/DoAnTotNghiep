using Entities.OwnerModels.PetHotelModel.Product;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Owners.PetHotel.Product
{
    public interface IPetTypeRepository
    {
        Task<PetTypeModel> Add(PetTypeModel doc);
        Task<bool> Update(FilterDefinition<PetTypeModel> filter, UpdateDefinition<PetTypeModel> update);
        Task<bool> Delete(FilterDefinition<PetTypeModel> filter);
        Task<List<PetTypeModel>> GetAll();
        Task<PetTypeModel> GetId(FilterDefinition<PetTypeModel> filter);
    }
}
