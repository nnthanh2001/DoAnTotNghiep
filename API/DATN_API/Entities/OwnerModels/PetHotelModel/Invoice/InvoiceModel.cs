using Entities.OwnerModels.PetHotelModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.OwnerModels.PetHotelModel.Invoice
{
    public class InvoiceModel : BaseModel
    {
        public int invoiceID { get; set; }
        public string customerName { get; set; }
        public string total { get; set; }
        public string deliveryAddress { get; set; }
        public string date { get; set; }
        public string customerPhone { get; set; }
        public string payment { get; set; }
        public string staffName { get; set; }
        public string status { get; set; }
    }
}
