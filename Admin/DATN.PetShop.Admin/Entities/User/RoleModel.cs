using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.User
{
    public class RoleModel : BaseModel
    {

        public int roleID { get; set; }
        public string roleName { get; set; }
        public string select { get; set; }
    }
}
