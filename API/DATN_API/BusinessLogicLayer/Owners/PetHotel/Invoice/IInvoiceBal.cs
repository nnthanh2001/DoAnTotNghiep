using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Entities.OwnerModels.PetHotelModel.Invoice;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Owners.PetHotel.Invoice
{
    public interface IInvoiceBal
    {
        Task<OrderModel> Add(OrderModel doc);
        Task<bool> Update(string _id);
        Task<bool> Delete(int invoiceID);
        Task<List<OrderModel>> GetAll();
        Task<OrderModel> GetId(string id);
        Task<List<OrderModel>> GetOrderByDay(string date);
        Task<List<OrderModel>> GetOrderByCustomer(string userid);
    }
}
