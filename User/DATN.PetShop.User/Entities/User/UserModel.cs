using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.User
{
    public class UserModel : BaseModel
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
