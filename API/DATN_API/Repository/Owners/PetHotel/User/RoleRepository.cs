using Contracts.AQL;
using Contracts.Owners.PetHotel.User;
using Entities.Database;
using Entities.OwnerModels.PetHotelModel.User;
using MongoDB.Driver;
using Repository.RepositoryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.User
{
    public class RoleRepository : RepositoryBase<RoleModel>, IRoleRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.Role.ToString();

        IQuery query;
        public RoleRepository(IQuery query) : base(query)
        {
            this.query = query;
        }
        public Task<List<RoleModel>> GetAll() => query.GetAll<RoleModel>(db, table);

        public Task<RoleModel> GetId(FilterDefinition<RoleModel> filter) => query.GetId(db, table, filter);
    }
}
