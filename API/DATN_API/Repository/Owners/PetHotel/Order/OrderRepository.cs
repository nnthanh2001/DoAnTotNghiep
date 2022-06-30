using Contracts.AQL;
using Contracts.Owners.PetHotel.Order;
using Entities.Database;
using Entities.OwnerModels.PetHotelModel.Client.Cart;
using MongoDB.Driver;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.Order
{
    public class OrderRepository : RepositoryBase<OrderModel>, IOrderRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.Order.ToString();

        IQuery query;
        public OrderRepository(IQuery query) : base(query)
        {
            this.query = query;
        }

        public Task<OrderModel> Add(OrderModel doc) => query.Add(db, table, doc);
        public Task<bool> Delete(FilterDefinition<OrderModel> filter) => query.Delete(db, table, filter);
        public Task<List<OrderModel>> GetAll() => query.GetAll<OrderModel>(db, table);
        public Task<OrderModel> GetId(FilterDefinition<OrderModel> filter) => query.GetId(db, table, filter);
        public Task<bool> Update(FilterDefinition<OrderModel> filter, UpdateDefinition<OrderModel> update) => query.Update(db, table, filter, update);
    }
}
