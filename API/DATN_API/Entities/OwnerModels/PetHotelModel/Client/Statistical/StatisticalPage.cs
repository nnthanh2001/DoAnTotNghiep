using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Entities.OwnerModels.PetHotelModel.Statistical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.OwnerModels.PetHotelModel.Client.Statistical
{
    public class StatisticalPage
    {
        public List<StatisticalModel> statisticalList { get; set; }
        public long totalOfAllBill { get; set; }
        public int totalOrderToDay { get; set; }
        public long totalMoneyToDay { get; set; }
    }
}
