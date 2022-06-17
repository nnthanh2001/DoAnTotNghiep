using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Entities.OwnerModels.PetHotelModel.Base
{
    public abstract class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string _id { get; set; }
    }
}
