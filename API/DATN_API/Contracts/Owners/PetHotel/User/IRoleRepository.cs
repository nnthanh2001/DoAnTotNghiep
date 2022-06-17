using Entities.OwnerModels.PetHotelModel.User;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Owners.PetHotel.User
{
    public interface IRoleRepository
    {
        Task<List<RoleModel>> GetAll();
        Task<RoleModel> GetId(FilterDefinition<RoleModel> filter);
    }
}
