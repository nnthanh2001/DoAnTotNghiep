using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Status
{
    public class StatusModel : BaseModel
    {
        public int statusId { get; set; }

        public string statusName { get; set; }
    }
}
