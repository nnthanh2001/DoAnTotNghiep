using Entities.OwnerModels.PetHotelModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.PetHotel.User
{
    public interface IRoleBal
    {
        Task<List<RoleModel>> GetAll();
    }
}
