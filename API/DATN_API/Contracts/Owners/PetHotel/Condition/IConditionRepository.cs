using Entities.OwnerModels.PetHotelModel.Condition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.PetHotel.Condition
{
    public interface IConditionRepository
    {
        Task<List<ConditionModel>> GetAll();
    }
}
