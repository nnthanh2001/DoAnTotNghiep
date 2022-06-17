using Entities.OwnerModels.PetHotelModel.Base;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DigitalCollection : BaseModel
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReferenceId { get; set; }
        public int DigitalAssetType { get; set; }
        public int MaxSupply { get; set; }
    }
}
