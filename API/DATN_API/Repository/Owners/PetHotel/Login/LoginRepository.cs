using Contracts.AQL;
using Contracts.Owners.PetHotel.Login;
using Entities.Database;
using Entities.OwnerModels.PetHotelModel.Login;
using Entities.OwnerModels.PetHotelModel.User;
using MongoDB.Driver;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.Login
{
    public class LoginRepository : RepositoryBase<LoginModel>, ILoginRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.User.ToString();

        IQuery query;
        public LoginRepository(IQuery query) : base(query)
        {
            this.query = query;
        }
        public Task<LoginModel> Add(LoginModel doc) => query.Add(db, table, doc);
        public Task<bool> Delete(FilterDefinition<LoginModel> filter) => query.Delete(db, table, filter);
        public Task<List<LoginModel>> GetAll() => query.GetAll<LoginModel>(db, table);
        public Task<UserModel> GetId(FilterDefinition<UserModel> filter) => query.GetId(db, table, filter);
        public Task<bool> Update(FilterDefinition<LoginModel> filter, UpdateDefinition<LoginModel> update) => query.Update(db, table, filter, update);

    }
}
