using Entities.OwnerModels.PetHotelModel.Base;
using Entities.OwnerModels.PetHotelModel.Condition;
using Entities.OwnerModels.PetHotelModel.Status;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.OwnerModels.PetHotelModel
{
    [BsonIgnoreExtraElements]
    public class ServiceFormModel : ServiceModel
    {
        public List<StatusModel> statusList { get; set; }
        public List<ConditionModel> conditionList { get; set; }
        
    }
    [BsonIgnoreExtraElements]
    public class ServiceModel : ServiceBaseModel
    {
        
        public string statusName { get; set; }
        public string condition { get; set; }
        public string serviceHandle { get; set; }
        public int price { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class ServiceBaseModel : BaseModel
    {
       
        public int serviceID { get; set; }
        public string serviceName { get; set; }
       
        public string unit { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int conditionID { get; set; }
        public int statusID { get; set; }
        

    }
    
}
