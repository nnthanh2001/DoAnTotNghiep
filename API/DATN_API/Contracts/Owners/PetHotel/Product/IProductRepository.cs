using Entities.OwnerModels.PetHotelModel.Client.Cart;
using Entities.OwnerModels.PetHotelModel.Product;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Owners.PetHotel.Product
{
    public interface IProductRepository
    {
        Task<ProductBaseModel> Add(ProductBaseModel doc);
        Task<bool> Update(FilterDefinition<ProductBaseModel> filter, UpdateDefinition<ProductBaseModel> update);
        Task<bool> Delete(FilterDefinition<ProductModel> filter);
        Task<List<ProductModel>> GetAll();
        Task<List<ProductModel>> GetTopProduct(SortDefinition<ProductModel> sort = null, int limit = 0);
        Task<List<ProductModel>> GetPaging<ProductModel>(string database, string table, FilterDefinition<ProductModel> filter, FilterDefinition<ProductModel> sort, int pageIndex = 1, int pageSize = 10);
        Task<List<ProductModel>> GetProduct(SortDefinition<ProductModel> sort = null, FilterDefinition<ProductModel> filter = null);
        Task<ProductModel> GetId(FilterDefinition<ProductModel> filter);
        Task<List<ProductModel>> GetListProductById(FilterDefinition<ProductModel> filter);
        Task<ProductFormModel> GetProductFormById(FilterDefinition<ProductFormModel> filter);
    }
}
