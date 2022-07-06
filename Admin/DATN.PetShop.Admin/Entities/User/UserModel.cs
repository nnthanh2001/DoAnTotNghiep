using Entities.Base;
using Entities.Status;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.User
{

    [BsonIgnoreExtraElements]
    public class UserFormModel : UserModel
    {
        public List<RoleModel> roleList { get; set; }
        public List<StatusModel> statusList { get; set; }
        public List<UserModel> userList { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class UserModel : UserBaseModel
    {
        public string roleName { get; set; }
        public string statusName { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class UserBaseModel : BaseModel
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public int roleID { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public long phone { get; set; }
        public int statusID { get; set; }
        public string password { get; set; }
        public string userHandle { get; set; }
    }
}
