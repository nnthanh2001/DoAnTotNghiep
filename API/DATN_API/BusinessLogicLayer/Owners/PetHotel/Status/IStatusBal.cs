using Entities.OwnerModels.PetHotelModel.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.PetHotel.Status
{
    public interface IStatusBal
    {
        Task<List<StatusModel>> GetAll();
    }
}
