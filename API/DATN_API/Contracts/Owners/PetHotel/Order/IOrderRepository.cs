using Entities.OwnerModels.PetHotelModel.Client.Cart;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Owners.PetHotel.Order
{
    public interface IOrderRepository
    {
        Task<OrderModel> Add(OrderModel doc);
        Task<bool> Update(FilterDefinition<OrderModel> filter, UpdateDefinition<OrderModel> update);
        Task<bool> Delete(FilterDefinition<OrderModel> filter);
        Task<List<OrderModel>> GetAll();
        Task<List<OrderModel>> GetListOrderById(FilterDefinition<OrderModel> filter);
        Task<OrderModel> GetId(FilterDefinition<OrderModel> filter);
    }
}
