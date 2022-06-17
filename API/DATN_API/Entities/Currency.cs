using Entities.OwnerModels.PetHotelModel.Base;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Currency : BaseModel
    {
        
        public string Name { get; set; }
        public int Type { get; set; }
        public string Symbol { get; set; }
        public int CirculatingSupply { get; set; }
        public bool hasMaxSupply { get; set; }
        public int MaxSupply { get; set; }
        public int Network { get; set; }
        public string ContractAddress { get; set; }
        public string CreatorAddress { get; set; }
        public string OwnerAddress { get; set; }
        public int TokenStandard { get; set; }
        public string Icon { get; set; }
    }
}
