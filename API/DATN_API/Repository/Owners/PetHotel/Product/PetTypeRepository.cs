using Contracts.AQL;
using Contracts.Owners.PetHotel.Product;
using Entities.Database;
using Entities.OwnerModels.PetHotelModel.Product;
using MongoDB.Driver;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.Product
{
    public class PetTypeRepository:RepositoryBase<PetTypeModel>, IPetTypeRepository
    {
        protected string db = Database.PetHotel.ToString();
    protected string table = Table.PetType.ToString();

    IQuery query;
    public PetTypeRepository(IQuery query) : base(query)
    {
        this.query = query;
    }
        public Task<PetTypeModel> Add(PetTypeModel doc) => query.Add(db, table, doc);
        public Task<bool> Delete(FilterDefinition<PetTypeModel> filter) => query.Delete(db, table, filter);
        public Task<List<PetTypeModel>> GetAll() => query.GetAll<PetTypeModel>(db, table);
        public Task<PetTypeModel> GetId(FilterDefinition<PetTypeModel> filter) => query.GetId(db, table, filter);
        public Task<bool> Update(FilterDefinition<PetTypeModel> filter, UpdateDefinition<PetTypeModel> update) => query.Update(db, table, filter, update);

    }
}
