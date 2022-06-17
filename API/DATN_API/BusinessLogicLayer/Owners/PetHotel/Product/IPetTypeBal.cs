using Entities.OwnerModels.PetHotelModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.PetHotel.Product
{
    public interface IPetTypeBal
    {
        Task<List<PetTypeModel>> GetAll();
    }
}
