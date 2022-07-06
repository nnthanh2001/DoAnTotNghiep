using Entities.Base;
using Entities.Condition;
using Entities.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Service
{
    public class ServiceFormModel : ServiceModel
    {
        public List<StatusModel> statusList { get; set; }
        public List<ConditionModel> conditionList { get; set; }
    }
    public class ServiceModel : ServiceBaseModel
    {

        public string statusName { get; set; }
        public string condition { get; set; }
    }
    public class ServiceBaseModel : BaseModel
    {
        public int serviceID { get; set; }
        public string serviceName { get; set; }
        public int price { get; set; }
        public string unit { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int conditionID { get; set; }
        public int statusID { get; set; }
        public string serviceHandle { get; set; }

    }
}
