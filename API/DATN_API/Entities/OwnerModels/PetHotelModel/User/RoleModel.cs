using Entities.OwnerModels.PetHotelModel.Base;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.OwnerModels.PetHotelModel.User
{
    
    public class RoleModel : BaseModel
    {
        public int roleID { get; set; }
        public string roleName { get; set; }
        public string select { get; set; }
        public int salary { get; set; }
    }
}
