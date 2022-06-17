using Entities.OwnerModels.PetHotelModel.Invoice;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.PetHotel.Invoice
{
    public interface IInvoiceBal
    {
        Task<InvoiceModel> Add(InvoiceModel doc);
        Task<bool> Update(FilterDefinition<InvoiceModel> filter, UpdateDefinition<InvoiceModel> update);
        Task<bool> Delete(int invoiceID);
        Task<List<InvoiceModel>> GetAll();
        Task<InvoiceModel> GetId(int invoiceID);
    }
}
