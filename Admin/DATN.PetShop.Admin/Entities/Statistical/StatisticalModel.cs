using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Statistical
{
    public class StatisticalPage
    {
        public List<StatisticalModel> statisticalList { get; set; }
        public long totalOfAllBill { get; set; }
        public int totalOrderToDay { get; set; }
        public long totalMoneyToDay { get; set; }
    }
    public class StatisticalModel : BaseModel
    {
        public string month { get; set; }
        public long totalCost { get; set; }
        public int nuberOfOrder { get; set; }
        public long totalIncome { get; set; }
        public long turnover { get; set; }
        public int turnoverID { get; set; }
        public List<CostList> costList { get; set; }
    }
    public class CostList
    {
        public int costID { get; set; }
        public string costName { get; set; }
        public int costPrice { get; set; }
    }
}
