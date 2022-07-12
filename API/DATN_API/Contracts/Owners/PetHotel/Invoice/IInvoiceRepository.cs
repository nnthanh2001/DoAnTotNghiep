using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Entities.OwnerModels.PetHotelModel.Invoice;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Owners.PetHotel.Invoice
{
    public interface IInvoiceRepository
    {
        Task<OrderModel> Add(OrderModel doc);
        Task<bool> Update(FilterDefinition<InvoiceModel> filter, UpdateDefinition<InvoiceModel> update);
        Task<bool> Delete(FilterDefinition<InvoiceModel> filter);
        Task<List<OrderModel>> GetAll(SortDefinition<OrderModel> sort = null);
        Task<List<OrderModel>> GetListOrderByName(FilterDefinition<OrderModel> filter, SortDefinition<OrderModel> sort = null);
        Task<OrderModel> GetId(FilterDefinition<OrderModel> filter);
        Task<List<OrderModel>> GetListOrderByDate(FilterDefinition<OrderModel> filter, SortDefinition<OrderModel> sort = null);
    }
}
