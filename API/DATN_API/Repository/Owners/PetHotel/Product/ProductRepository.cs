using Contracts.AQL;
using Contracts.Owners.PetHotel.Product;
using Entities.Database;
using Entities.OwnerModels.PetHotelModel.Product;
using MongoDB.Driver;
using Repository.RepositoryBase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Owners.PetHotel.Product
{
    public class ProductRepository : RepositoryBase<ProductFormModel>, IProductRepository
    {
        protected string db = Database.PetHotel.ToString();
        protected string table = Table.Product.ToString();
        protected string tableProduct = Table.ProductForm.ToString();

        IQuery query;
        public ProductRepository(IQuery query) : base(query)
        {
            this.query = query;
        }

        public Task<ProductBaseModel> Add(ProductBaseModel doc) => query.Add(db, table, doc);
        public Task<bool> Delete(FilterDefinition<ProductModel> filter) => query.Delete(db, table, filter);
        public Task<List<ProductModel>> GetAll() => query.GetAll<ProductModel>(db, table);
        public Task<List<ProductFormModel>> GetPaging<ProductFormModel>(string database, string table, FilterDefinition<ProductFormModel> filter, FilterDefinition<ProductFormModel> sort, int pageIndex = 1, int pageSize = 10)
            => query.GetPaging<ProductFormModel>(database, table, filter, sort, pageIndex, pageSize);
        public Task<ProductModel> GetId(FilterDefinition<ProductModel> filter) => query.GetId(db, table, filter);
        public Task<List<ProductModel>> GetProduct() => query.GetAll<ProductModel>(db, table);
        public Task<List<ProductModel>> GetTopProduct(SortDefinition<ProductModel> sort = null, int limit = 0) => query.GetAll<ProductModel>(db, table, null,sort,limit);
        public Task<bool> Update(FilterDefinition<ProductBaseModel> filter, UpdateDefinition<ProductBaseModel> update) => query.Update(db, table, filter, update);
        public Task<ProductFormModel> GetProductFormById(FilterDefinition<ProductFormModel> filter) => query.GetId(db, table, filter);

    }
}
