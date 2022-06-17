using Contracts.AQL;
using Contracts.Owners.PetHotel.Service;
using Entities.Database;
using Entities.OwnerModels.PetHotelModel;
using MongoDB.Driver;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.Service
{
    public class ServiceRepository : RepositoryBase<ServiceModel>, IServiceRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.Service.ToString();

        IQuery query;
        public ServiceRepository(IQuery query) : base(query)
        {
            this.query = query;
        }

        public Task<ServiceModel> Add(ServiceModel doc) => query.Add(db, table, doc);
        public Task<bool> Delete(FilterDefinition<ServiceModel> filter) => query.Delete(db, table, filter);
        public Task<List<ServiceModel>> GetAll() => query.GetAll<ServiceModel>(db, table);
        public Task<ServiceModel> GetId(FilterDefinition<ServiceModel> filter) => query.GetId(db, table, filter);

        public Task<List<ServiceModel>> GetTopService(SortDefinition<ServiceModel> sort = null, int limit = 0) => query.GetAll<ServiceModel>(db, table, null, sort, limit);
        public Task<ServiceFormModel> GetServiceFormById(FilterDefinition<ServiceFormModel> filter) => query.GetId(db, table, filter);
        public Task<bool> Update(FilterDefinition<ServiceModel> filter, UpdateDefinition<ServiceModel> update) => query.Update(db, table, filter, update);
    }
}
