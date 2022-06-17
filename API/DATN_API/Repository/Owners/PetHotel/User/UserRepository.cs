using Contracts.AQL;
using Contracts.Owners.PetHotel.Staff;
using Entities.Database;
using Entities.OwnerModels.PetHotelModel.Status;
using Entities.OwnerModels.PetHotelModel.User;
using MongoDB.Driver;
using Repository.RepositoryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.User
{
    public class UserFormRepository : RepositoryBase<UserFormModel>, IUserFormRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.UserForm.ToString();

        IQuery query;
        public UserFormRepository(IQuery query) : base(query)
        {
            this.query = query;
        }

        public Task<UserFormModel> Add(UserFormModel doc) => query.Add(db, table, doc);
        public Task<bool> Delete(FilterDefinition<UserFormModel> filter) => query.Delete(db, table, filter);
       
        public Task<bool> Update(FilterDefinition<UserFormModel> filter, UpdateDefinition<UserFormModel> update) => query.Update(db, table, filter, update);
        public Task<List<UserFormModel>> GetAll() => query.GetAll<UserFormModel>(db, table);

    }
    public class UserRepository : RepositoryBase<UserModel>, IUserRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.User.ToString();

        IQuery query;
        public UserRepository(IQuery query) : base(query)
        {
            this.query = query;
        }
        public Task<UserModel> Add(UserModel doc) => query.Add(db, table, doc);
        public Task<bool> Delete(FilterDefinition<UserModel> filter) => query.Delete(db, table, filter);
        public Task<List<UserModel>> GetAll() => query.GetAll<UserModel>(db, table);
        public Task<UserModel> GetId(FilterDefinition<UserModel> filter) => query.GetId(db, table, filter);
        public Task<bool> Update(FilterDefinition<UserModel> filter, UpdateDefinition<UserModel> update) => query.Update(db, table, filter, update);
        public Task<UserFormModel> GetUserFormById(FilterDefinition<UserFormModel> filter) => query.GetId(db, table, filter);
    }
}
