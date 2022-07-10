using Contracts.AQL;
using Contracts.Owners.PetHotel.Status;
using Entities.Database;
using Entities.OwnerModels.PetHotelModel.Status;
using Entities.OwnerModels.PetHotelModel.User;
using MongoDB.Driver;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.Status
{
    public class StatusRepository : RepositoryBase<StatusModel>, IStatusRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.Status.ToString();

        IQuery query;
        public StatusRepository(IQuery query) : base(query)
        {
            this.query = query;
        }

        public Task<StatusModel> Add(StatusModel doc) => query.Add(db, table, doc);
        public Task<bool> Delete(FilterDefinition<StatusModel> filter) => query.Delete(db, table, filter);
        public Task<List<StatusModel>> GetAll(SortDefinition<StatusModel> sort = null, int limit = 0) => query.GetAll(db, table, null, sort, limit);
        public Task<StatusModel> GetId(FilterDefinition<StatusModel> filter) => query.GetId(db, table, filter);
        public Task<bool> Update(FilterDefinition<StatusModel> filter, UpdateDefinition<StatusModel> update) => query.Update(db, table, filter, update);

    }




}
