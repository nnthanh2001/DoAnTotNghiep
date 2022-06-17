using Contracts.AQL;
using Contracts.Owners.PetHotel.Category;
using Entities.Database;
using Entities.OwnerModels.PetHotelModel.Category;
using MongoDB.Driver;
using Repository.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.Category
{
    public class CategoryRepository : RepositoryBase<CategoryModel>, ICategoryRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.Category.ToString();

        IQuery query;
        public CategoryRepository(IQuery query) : base(query)
        {
            this.query = query;
        }
        public Task<CategoryModel> Add(CategoryModel doc) => query.Add(db, table, doc);
        public Task<bool> Delete(FilterDefinition<CategoryModel> filter) => query.Delete(db, table, filter);
        public Task<List<CategoryModel>> GetAll() => query.GetAll<CategoryModel>(db, table);
        public Task<CategoryModel> GetId(FilterDefinition<CategoryModel> filter) => query.GetId(db, table, filter);

        public Task<List<CategoryModel>> GetTopCategory(SortDefinition<CategoryModel> sort = null, int limit = 0)
         => query.GetAll<CategoryModel>(db, table, null, sort, limit);

        public Task<bool> Update(FilterDefinition<CategoryModel> filter, UpdateDefinition<CategoryModel> update) => query.Update(db, table, filter, update);
    }
}
