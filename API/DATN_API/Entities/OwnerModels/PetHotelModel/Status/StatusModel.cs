using Entities.OwnerModels.PetHotelModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.OwnerModels.PetHotelModel.Status
{
    public class StatusModel:BaseModel
    {
        
        public int statusID { get; set; }
        
        public string statusName { get; set; }
        public string select { get; set; }

    }
}
