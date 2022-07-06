using Contracts.AQL;
using Contracts.Owners.PetHotel.Statistical;
using Entities.Database;
using Entities.OwnerModels.PetHotelModel.Statistical;
using MongoDB.Driver;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.Statistical
{
    public class StatisticalRepository : RepositoryBase<StatisticalModel>, IStatisticalRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.Statistical.ToString();

        IQuery query;
        public StatisticalRepository(IQuery query) : base(query)
        {
            this.query = query;
        }

        public Task<StatisticalModel> Add(StatisticalModel doc) => query.Add(db, table, doc);
        public Task<bool> Delete(FilterDefinition<StatisticalModel> filter) => query.Delete(db, table, filter);
        public Task<List<StatisticalModel>> GetAll() => query.GetAll<StatisticalModel>(db, table);
        public Task<StatisticalModel> GetId(FilterDefinition<StatisticalModel> filter) => query.GetId(db, table, filter);
        public Task<List<StatisticalModel>> GetListStatisticalById(FilterDefinition<StatisticalModel> filter) => query.GetListById<StatisticalModel>(db, table, filter);
        public Task<StatisticalModel> GetServiceFormById(FilterDefinition<StatisticalModel> filter) => query.GetId(db, table, filter);
        public Task<bool> Update(FilterDefinition<StatisticalModel> filter, UpdateDefinition<StatisticalModel> update) => query.Update(db, table, filter, update);

        
    }
}
