using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Entities.Base
{
    public class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("_id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string _id { get; set; }
    }
}
