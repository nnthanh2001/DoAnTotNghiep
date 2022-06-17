using Entities.OwnerModels.PetHotelModel.Base;
using Entities.OwnerModels.PetHotelModel.Status;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Entities.OwnerModels.PetHotelModel.User
{

    [BsonIgnoreExtraElements]
    public class UserFormModel : UserModel
    {
        public List<RoleModel> roleList { get; set; }
        public List<StatusModel> statusList { get; set; }
        
    }
    [BsonIgnoreExtraElements]
    public class UserModel : UserBaseModel
    {
        public string roleName { get; set; }
        public string statusName { get; set; }
        public string userHandle { get; set; }
        public string password { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class UserBaseModel : BaseModel
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public int roleID { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public int statusID { get; set; }
       
    }

}
