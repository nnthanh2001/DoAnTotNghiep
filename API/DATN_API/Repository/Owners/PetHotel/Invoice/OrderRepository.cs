using Contracts.AQL;
using Contracts.Owners.PetHotel.Invoice;
using Entities.Database;
using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Entities.OwnerModels.PetHotelModel.Invoice;
using MongoDB.Driver;
using Repository.RepositoryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.Invoice
{
    public class OrderRepository : RepositoryBase<InvoiceModel>, IInvoiceRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.Order.ToString();

        IQuery query;
        public OrderRepository(IQuery query) : base(query)
        {
            this.query = query;
        }

        public Task<OrderModel> Add(OrderModel doc) => query.Add(db, table, doc);
        public Task<bool> Delete(FilterDefinition<InvoiceModel> filter) => query.Delete(db, table, filter);
        public Task<List<OrderModel>> GetAll(SortDefinition<OrderModel> sort = null) => query.GetAll<OrderModel>(db, table, null, sort);
        public Task<List<OrderModel>> GetListOrderByName(FilterDefinition<OrderModel> filter,SortDefinition<OrderModel> sort = null) => query.GetListById(db, table, filter, sort);
        public Task<OrderModel> GetId(FilterDefinition<OrderModel> filter) => query.GetId(db, table, filter);
        public Task<List<OrderModel>> GetListOrderByDate(FilterDefinition<OrderModel> filter, SortDefinition<OrderModel> sort = null) => query.GetListById(db, table, filter, sort);
        public Task<bool> Update(FilterDefinition<OrderModel> filter, UpdateDefinition<OrderModel> update) => query.Update(db, table, filter, update);
    }
}
