using Entities.OwnerModels.PetHotelModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.OwnerModels.PetHotelModel.Product
{
    public class PetTypeModel : BaseModel
    {
        public int petTypeID { get; set; }
        public string petTypeName { get; set; }
        public string select { get; set; }
    }
}
