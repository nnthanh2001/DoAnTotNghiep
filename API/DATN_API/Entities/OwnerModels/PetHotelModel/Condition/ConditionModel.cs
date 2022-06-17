using Entities.OwnerModels.PetHotelModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.OwnerModels.PetHotelModel.Condition
{
    public class ConditionModel : BaseModel
    {
        public int conditionID { get; set; }
        public int price { get; set; }
        public string condition { get; set; }
    }
}
